/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 25/12/2008
 * Time: 3:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class TestForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.newDockEdit1 = new thor.NewDockEdit();
			this.SuspendLayout();
			// 
			// newDockEdit1
			// 
			this.newDockEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.newDockEdit1.Location = new System.Drawing.Point(0, 0);
			this.newDockEdit1.Name = "newDockEdit1";
			this.newDockEdit1.Size = new System.Drawing.Size(826, 565);
			this.newDockEdit1.TabIndex = 0;
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(826, 565);
			this.Controls.Add(this.newDockEdit1);
			this.Name = "TestForm";
			this.Text = "TestForm";
			this.ResumeLayout(false);
		}
		private thor.NewDockEdit newDockEdit1;
	}
}
