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
            ckTopMost.CheckedChanged += (ss, ee) =>
            {
                TopMost = ckTopMost.Checked;

            };

            ckGetPublicIp.CheckedChanged += (ss, ee) =>
            {
                updateIp = true;
                lblIPAddress.Text = "";
            };
        }

        private bool updateIp = true;
        private long nextUpdate;

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblLocalTime.Text = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff zz");
            lblUTCTime.Text = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff zz");

            if (ckGetPublicIp.Checked && updateIp)
            {
                try
                {
                    var ip = new WebClient().DownloadString("http://icanhazip.com");

                    string ipv4 = string.Empty;
                    try {
                        Regex regexObj = new Regex(@"\b(?:[0-9]{1,3}\.){3}[0-9]{1,3}\b");
                        ipv4 = regexObj.Match(ip).Value;
                    } catch (ArgumentException ex) {
                        // Syntax error in the regular expression
                    }

                    lblIPAddress.Text = $"Public IP address: {ipv4}";
                }
                catch (Exception exception)
                {
                    lblIPAddress.Text = $"Error getting IP: {exception.Message}";
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
