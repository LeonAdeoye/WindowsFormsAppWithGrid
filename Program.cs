using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppWithGrid
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjM1NTA1QDMyMzAyZTMxMmUzMFM2YUYxSzc3QW9SRThUS2xoYUMwTkZxTkFLQkVuMDRqOWhIQVNhTk11MzQ9");
            // Before applying theme to SfDataGrid, required theme assembly should be loaded. Use Nugget to search for and install the package: Syncfusion.Office2016Theme.WinForms 
            SfSkinManager.LoadAssembly(typeof(Syncfusion.WinForms.Themes.Office2016Theme).Assembly);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
