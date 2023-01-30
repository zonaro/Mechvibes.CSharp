using System;
using System.Windows.Forms;

namespace Mechvibes.CSharp
{
    internal static class Program
    {
        #region Private Fields

        private static MainForm frm_MainWindow;

        #endregion Private Fields



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
            Application.Run(frm_MainWindow);
        }

        #endregion Private Methods
    }
}