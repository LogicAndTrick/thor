/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 25/12/2008
 * Time: 4:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of QuadSplitPanel.
	/// </summary>
	public partial class QuadSplitPanel : Panel
	{
		private QuadSplitControl owner;
		public QuadSplitPanel(QuadSplitControl pnt)
		{
			owner = pnt; 
			InitializeComponent();
		}
		
		[EditorBrowsableAttribute()]
		protected override void OnMouseMove(MouseEventArgs e)
		{
			owner.MouseOver(e);
			base.OnMouseMove(e);
		}
	}
}
