/*
 * Created by SharpDevelop.
 * User: s4142421
 * Date: 5/05/2009
 * Time: 11:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of TorusBrushForm.
	/// </summary>
	public partial class TorusBrushForm : Form
	{
		private bool ok;
		
		public bool OK {
			get { return ok; }
		}
		
		public TorusBrushForm()
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
		
		public int getSides()
		{
			return (int)numericUpDown2.Value;
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
