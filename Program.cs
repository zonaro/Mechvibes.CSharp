using InnerLibs;
using System;
using System.Windows.Forms;

namespace Mechvibes.CSharp
{
    internal static class Program
    {
        #region Private Fields

        private static MainForm frm_MainWindow;

        #endregion Private Fields

        internal static Settings settings = new Settings();


        #region Private Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frm_MainWindow = new MainForm();

            Program.settings = Program.settings.Load();

            Application.Run(frm_MainWindow);
        }

        #endregion Private Methods
    }
}