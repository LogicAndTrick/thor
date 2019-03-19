/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/01/2009
 * Time: 2:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class DockVisgroups
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
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Visgroups:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(3, 33);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(202, 193);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(194, 167);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "User";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(194, 167);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Auto";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// DockVisgroups
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(204, 187);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label1);
			this.MinimumSize = new System.Drawing.Size(212, 221);
			this.Name = "DockVisgroups";
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label1;
	}
}
