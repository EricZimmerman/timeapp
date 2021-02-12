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
                lblIPAddress4.Text = string.Empty;
                lblIPAddress6.Text = string.Empty;
                lblError.Text = string.Empty;
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

                    lblIPAddress4.Text = $"Public IPv4 address: {ip4}";
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

                    lblIPAddress6.Text = $"Public IPv6 address: {ip6}";
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
