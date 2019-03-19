/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 7/08/2009
 * Time: 6:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of ToolForm.
	/// </summary>
	public class HotkeyEnabledForm : Form
	{
		public HotkeyEnabledForm()
		{
			this.KeyPreview = true;
			this.KeyDown += new KeyEventHandler(ToolForm_KeyDown);
			this.KeyUp += new KeyEventHandler(ToolForm_KeyUp);
		}

		void ToolForm_KeyDown(object sender, KeyEventArgs e)
		{
			Accessor.Instance.ThorHotkeys.keyDown(e);
		}

		void ToolForm_KeyUp(object sender, KeyEventArgs e)
		{
			Accessor.Instance.ThorHotkeys.keyUp(e);
		}
	}
}
