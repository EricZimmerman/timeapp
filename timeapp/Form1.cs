using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

// namespaces...
namespace timeapp
{
    // public classes...
    public partial class Form1 : Form
    {
        private TimeSpan? _cdTimeSpan;

        private TimeSpan? _swTimeSpan;

        private long startTicks;

        // public constructors...
        public Form1()
        {
            InitializeComponent();
        }

        // private methods...
        private void Form1_Load(object sender, EventArgs e)
        {
            tcMain.SelectedIndexChanged += (ss, ee) =>
            {
                timer1.Enabled = tcMain.SelectedIndex == 0;

            };

            lblStatus.Text = string.Empty;
            lblIPAddress4.Text = string.Empty;
            lblIPAddress6.Text = string.Empty;

            ckTopMost.CheckedChanged += (ss, ee) => { TopMost = ckTopMost.Checked; };

            ckGetPublicIp.CheckedChanged += async (ss, ee) =>
            {
               
                lblIPAddress4.Text = string.Empty;
                lblIPAddress6.Text = string.Empty;
                lblStatus.Text = string.Empty;

                if (ckGetPublicIp.Checked)
                {
                    lblStatus.Text = string.Empty;

                    try
                    {
                        var ip4 = await new WebClient().DownloadStringTaskAsync("http://ipv4.icanhazip.com");

                        lblIPAddress4.Text = $"Public IPv4 address:\r\n{ip4}";
                    }
                    catch (Exception exception)
                    {
                        lblStatus.Text = $"Error getting IPv4: {exception.Message}";
                    }

                    try
                    {
                        var ip6 = await new WebClient().DownloadStringTaskAsync("http://ipv6.icanhazip.com");

                        lblIPAddress6.Text = $"Public IPv6 address:\r\n{ip6}";
                    }
                    catch (Exception exception)
                    {
                        lblStatus.Text += $"\r\nError getting IPv6: {exception.Message}";
                    }

                 
                 
                }

            };

            Closing += (ss, ee) =>
            {
                if (MessageBox.Show("Are you sure you want to exit?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                {
                    ee.Cancel = true;
                }
            };

            btnStartSw.Click += (ss, ee) =>
            {
                timerSw.Start();
                btnStartSw.Enabled = false;
                btnStopSw.Enabled = true;

                 startTicks = DateTimeOffset.Now.Ticks;
            };

            btnResetSw.Click += (ss, ee) =>
            {
                lblElapsed.Text = "0";

                _swTimeSpan = new TimeSpan(0);
            };

            btnStopSw.Click += (ss, ee) =>
            {
                timerSw.Stop();
                btnStartSw.Enabled = true;
                btnStopSw.Enabled = false;
            };

            timerSw.Tick += (ss, ee) =>
            {
               

                var foo = DateTimeOffset.Now.Ticks - startTicks;

                _swTimeSpan = new TimeSpan(foo);

                lblElapsed.Text = _swTimeSpan.Value.ToString(@"d\.hh\:mm\:ss\.ff");
            };

            btnStartCd.Click += (ss, ee) =>
            {
                timerCountdown.Start();
                btnStartCd.Enabled = false;
                btnStopCd.Enabled = true;
                panelSettings.Visible = false;

                if (_cdTimeSpan == null)
                {
                    _cdTimeSpan = new TimeSpan((int) numDays.Value, (int) numHours.Value, (int) numMins.Value,
                        (int) numSecs.Value);
                }
            };

            btnResetCd.Click += (ss, ee) =>
            {
                lblCountdown.Text = "0";
                lblCountdown.ForeColor = Color.Black;

                btnStopCd.PerformClick();

                _cdTimeSpan = null;
            };

            btnStopCd.Click += (ss, ee) =>
            {
                timerCountdown.Stop();
                btnStartCd.Enabled = true;
                btnStopCd.Enabled = false;
                panelSettings.Visible = true;
            };

            timerCountdown.Tick += (ss, ee) =>
            {
                if (_cdTimeSpan == null)
                {
                    return;
                }

                var foo = _cdTimeSpan.Value.Subtract(TimeSpan.FromMilliseconds(timerCountdown.Interval));

                _cdTimeSpan = foo;//new TimeSpan(foo);// _cdTimeSpan.Value.Subtract(TimeSpan.FromMilliseconds(timerSw.Interval));

                if (_cdTimeSpan.Value > TimeSpan.Zero)
                {
                    lblCountdown.Text = _cdTimeSpan.Value.ToString(@"d\.hh\:mm\:ss");
                    lblCountdown.ForeColor = Color.Black;
                }
                else
                {
                    lblCountdown.Text = _cdTimeSpan.Value.ToString(@"\-d\.hh\:mm\:ss");
                    lblCountdown.ForeColor = Color.Red;
                }
            };


            timer1.Tick +=  (ss, ee) =>
            {
                lblLocalTime.Text = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff zz");
                lblUTCTime.Text = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff zz");

               
            };
        }

    
     
    }
}