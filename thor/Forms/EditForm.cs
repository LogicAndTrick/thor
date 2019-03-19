/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 30/12/2008
 * Time: 11:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of EditForm.
	/// </summary>
	public partial class EditForm : Form
	{
		private Document associatedDocument;
		
		public QuadSplitControl Views {
			get { return qscViews; }
			set { qscViews = value; }
		}
		
		public Document AssociatedDocument {
			get { return associatedDocument; }
			set { associatedDocument = value; }
		}
		
		public EditForm(Document doc)
		{
			InitializeComponent();
			associatedDocument = doc;
		}
	}
}
