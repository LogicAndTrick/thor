/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 25/07/2009
 * Time: 11:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of CompileForm.
	/// </summary>
	public partial class CompileForm : Form
	{
		public CompileForm()
		{
			InitializeComponent();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Document doc = Accessor.Instance.getActiveDocument();
			if (doc != null) doc.compile();
			Close();
		}
	}
}
