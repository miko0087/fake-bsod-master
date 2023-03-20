using System;
using System.Windows.Forms;

namespace bs
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Customizer form = new Customizer();
			Application.Run(form);
		}
	}
}
