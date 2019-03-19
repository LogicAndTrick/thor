/*
 * Created by SharpDevelop.
 * User: s4142421
 * Date: 24/04/2009
 * Time: 9:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of PipeBrushForm.
	/// </summary>
	public partial class PipeBrushForm : Form
	{
		private bool ok;
		
		public bool OK {
			get { return ok; }
		}
		
		public PipeBrushForm()
		{
			InitializeComponent();
			ok = false;
		}
		
		public void setMax(decimal val)
		{
			ok = false;
			numericUpDown1.Maximum = val;
		}
		
		public decimal getWidth()
		{
			return numericUpDown1.Value;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			ok = true;
			Hide();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Hide();
		}
	}
}
