using System;
using System.Windows.Forms;

namespace timeapp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
#if NET
            //Per-Monitor V2 DPI awareness first: sharp and the right size on each monitor
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#else
            //(.NET Framework 4.6.2 has no TLS 1.2 by default: the public IP lookup is HTTPS)
            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
