using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Mechvibes.CSharp
{
	internal static class Program
	{
		private static MainForm frm_MainWindow;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

		 

			frm_MainWindow = new MainForm();

			Application.Run(frm_MainWindow);
		}

	 
	}
}
