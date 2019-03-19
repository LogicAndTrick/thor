/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 4/09/2008
 * Time: 11:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(LuaExceptionHandler);
			Application.Run(new MainForm());
		}
		
		private static void PythonExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs args) {
			Exception e = args.Exception;
			/*if (e is LuaInterface.LuaException) MessageBox.Show("LUA internal error: " + e.Message);
			else */throw e;
		}
		
	}
}
