/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/01/2009
 * Time: 11:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class DockMapTools
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// flowPanel
			// 
			this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowPanel.Location = new System.Drawing.Point(0, 0);
			this.flowPanel.Name = "flowPanel";
			this.flowPanel.Size = new System.Drawing.Size(115, 566);
			this.flowPanel.TabIndex = 1;
			// 
			// DockMapTools
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(115, 566);
			this.Controls.Add(this.flowPanel);
			this.Name = "DockMapTools";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.FlowLayoutPanel flowPanel;
	}
}
