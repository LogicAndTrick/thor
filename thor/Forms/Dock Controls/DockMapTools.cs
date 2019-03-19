/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/01/2009
 * Time: 11:12 AM
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
	/// Description of DockMapTools.
	/// </summary>
	public partial class DockMapTools : DockContent
	{
		public DockMapTools()
		{
			InitializeComponent();
			/**/this.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Float;
			this.AutoHidePortion = 58;
			this.ShowHint = DockState.DockLeft;
			this.TabText = "Tools";
			this.Text = "Tools";/**/
		}
		
		public void AddTool(BaseTool tool)
		{
			CheckBox newCheck = new System.Windows.Forms.CheckBox();
			newCheck.Appearance = System.Windows.Forms.Appearance.Button;
			newCheck.Location = new System.Drawing.Point(3, 3);
			newCheck.Name = tool.ToolName;
			newCheck.Size = new System.Drawing.Size(50, 44);
			//newCheck.Text = tool.ToolName;
			newCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			newCheck.UseVisualStyleBackColor = true;
			newCheck.Click += new System.EventHandler(this.CheckClicked);
			newCheck.BackgroundImage = tool.getImage();
			newCheck.BackgroundImageLayout = ImageLayout.Center;
			newCheck.BackColor = Color.Transparent;
			flowPanel.Controls.Add(newCheck);
		}
		
		private void CheckClicked(object sender, EventArgs e)
		{
			if (sender is CheckBox) {
				unselectAll();
				(sender as CheckBox).Checked = true;
				Accessor.Instance.selectTool((sender as CheckBox).Name);
			}
		}
		
		private void unselectAll()
		{
			foreach (CheckBox cx in flowPanel.Controls) cx.Checked = false;
		}
		
		public void selectTool(BaseTool tool)
		{
			foreach (CheckBox cx in flowPanel.Controls) {
				if (cx.Name == tool.ToolName) {
					unselectAll();
					cx.Checked = true;
				}
			}
		}
	}
}
