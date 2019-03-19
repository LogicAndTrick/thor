/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 25/07/2009
 * Time: 5:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of BuildControl.
	/// </summary>
	public class BuildControl : UserControl
	{
		protected string commandLineSwitch;
		protected string toolTipText;
		
		public string ToolTipText {
			get { return toolTipText; }
			set { setToolTipText(value); }
		}
		
		public string CommandLineSwitch {
			get { return commandLineSwitch; }
			set { commandLineSwitch = value; }
		}
		
		public virtual void setToolTipText(string s)
		{
			toolTipText = s;
		}
		
		public virtual string getCommandLine()
		{
			return "";
		}
		
		public virtual void setCommandLine(string s)
		{
			// do nothing
		}
	}
}
