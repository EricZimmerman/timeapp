using System;

using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

// namespaces...
namespace timeapp
{
    // public classes...
    public partial class Form1 : Form
    {
        // public constructors...
        public Form1()
        {
            InitializeComponent();
        }

        // private methods...
        private void Form1_Load(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            lblIPAddress4.Text = string.Empty;
            lblIPAddress6.Text = string.Empty;


            ckTopMost.CheckedChanged += (ss, ee) =>
            {
                TopMost = ckTopMost.Checked;

            };

            ckGetPublicIp.CheckedChanged += (ss, ee) =>
            {
                updateIp = true;
                lblIPAddress4.Text = string.Empty;
                lblIPAddress6.Text = string.Empty;
                lblError.Text = string.Empty;
            };

            btnStartSw.Click += (ss, ee) =>
            {
                timerSw.Start();
                btnStartSw.Enabled = false;
                btnStopSw.Enabled = true;

                if (_swTimeSpan == null)
                {
                    _swTimeSpan = new TimeSpan(0);
                }
            };

            btnResetSw.Click += (ss, ee) =>
            {
                _swTimeSpan = null;
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

                if (_swTimeSpan == null)
                {
                    return;
                }
                 
                _swTimeSpan = _swTimeSpan.Value.Add(TimeSpan.FromMilliseconds(timerSw.Interval));

                lblElapsed.Text = _swTimeSpan.Value.ToString(@"d\.hh\:mm\:ss\.ff");
            };
            
            btnStartCd.Click += (ss, ee) =>
            {
                timerCountdown.Start();
                btnStartCd.Enabled = false;
                btnStopCd.Enabled = true;

                if (_cdTimeSpan == null)
                {
                    _cdTimeSpan = new TimeSpan(0);
                }
            };

            btnResetCd.Click += (ss, ee) =>
            {
                _cdTimeSpan = null;
                lblCountdown.Text = "0";
                
                _cdTimeSpan = new TimeSpan(0);
            };

            btnStopCd.Click += (ss, ee) =>
            {
                timerCountdown.Stop();
                btnStartCd.Enabled = true;
                btnStopCd.Enabled = false;
            };

            timerCountdown.Tick += (ss, ee) =>
            {

                if (_cdTimeSpan == null)
                {
                    return;
                }
                 
                _cdTimeSpan = _cdTimeSpan.Value.Add(TimeSpan.FromMilliseconds(timerSw.Interval));

                lblCountdown.Text = _cdTimeSpan.Value.ToString(@"d\.hh\:mm\:ss\.ff");
            };

        }

        private TimeSpan? _swTimeSpan = null; 
        private TimeSpan? _cdTimeSpan = null; 

        private bool updateIp = true;
        private long nextUpdate;

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblLocalTime.Text = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff zz");
            lblUTCTime.Text = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff zz");

            if (ckGetPublicIp.Checked && updateIp)
            {

                lblError.Text = string.Empty;

                try
                {
                    var ip4 = new WebClient().DownloadString("http://ipv4.icanhazip.com");

                    /*string ipv4 = string.Empty;
                    try {
                        Regex regexObj = new Regex(@"\b(?:[0-9]{1,3}\.){3}[0-9]{1,3}\b");
                        ipv4 = regexObj.Match(ip4).Value;
                    } catch (ArgumentException ex) {
                        // Syntax error in the regular expression
                    }*/

                    lblIPAddress4.Text = $"Public IPv4 address:\r\n{ip4}";
                }
                catch (Exception exception)
                {
                    lblError.Text = $"Error getting IPv4: {exception.Message}";
                }

                try
                {
                    var ip6 = new WebClient().DownloadString("http://ipv6.icanhazip.com");

                    /*string ipv6 = string.Empty;
                    try {
                        Regex regexObj = new Regex(@"\b(?:[0-9]{1,3}\.){3}[0-9]{1,3}\b");
                        ipv6 = regexObj.Match(ip4).Value;
                    } catch (ArgumentException ex) {
                        // Syntax error in the regular expression
                    }*/

                    lblIPAddress6.Text = $"Public IPv6 address:\r\n{ip6}";
                }
                catch (Exception exception)
                {
                    lblError.Text += $"\r\nError getting IPv6: {exception.Message}";
                }

                 
                nextUpdate = DateTime.Now.AddMinutes(5).Ticks;
                updateIp = false;
            }

            if (DateTime.Now.Ticks > nextUpdate)
            {
                updateIp = true;
            }

        }

      
    }
}
