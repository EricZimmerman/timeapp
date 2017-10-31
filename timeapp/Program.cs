using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// namespaces...
namespace timeapp
{
    // internal classes...
    internal static class Program
    {
        // private methods...
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
