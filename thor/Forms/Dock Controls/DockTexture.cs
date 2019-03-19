/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/01/2009
 * Time: 2:24 PM
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
	/// Description of DockTexture.
	/// </summary>
	public partial class DockTexture : DockContent
	{
		public DockTexture()
		{
			InitializeComponent();
			/**/this.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Float;
			this.AutoHidePortion = 218;
			this.ShowHint = DockState.DockRight;
			this.TabText = "Texture";
			this.Text = "Texture";/**/
		}
	}
}
