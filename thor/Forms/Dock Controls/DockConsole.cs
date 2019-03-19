/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 23/02/2009
 * Time: 9:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace thor
{
	/// <summary>
	/// Description of DockConsole.
	/// </summary>
	public partial class DockConsole : DockContent
	{
		public DockConsole()
		{
			InitializeComponent();
			/**/this.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Float;
			this.AutoHidePortion = 200;
			this.ShowHint = DockState.DockBottom;
			this.TabText = "Console";
			this.Text = "Console";/**/
		}
		
		public void WriteLine(string message)
		{
			if (listBox1.Items.Count == 50) listBox1.Items.RemoveAt(49);
			listBox1.Items.Insert(0,message);
		}
	}
}
