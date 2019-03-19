/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/01/2009
 * Time: 11:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace thor
{
	/// <summary>
	/// Description of DockEdit.
	/// </summary>
	public partial class DockEdit : DockContent
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
		
		public DockEdit(Document doc)
		{
			InitializeComponent();
			associatedDocument = doc;
			/**/this.DockAreas = DockAreas.Document;
			this.TabText = "Document";
			this.Text = "Document";/**/
		}
	}
}
