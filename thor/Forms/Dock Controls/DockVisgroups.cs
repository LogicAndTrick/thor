/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/01/2009
 * Time: 2:38 PM
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
	/// Description of DockVisgroups.
	/// </summary>
	public partial class DockVisgroups : DockContent
	{
		public DockVisgroups()
		{
			InitializeComponent();
			/**/this.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Float;
			this.AutoHidePortion = 218;
			this.ShowHint = DockState.DockRight;
			this.TabText = "Visgroups";
			this.Text = "Visgroups";/**/
		}
	}
}
