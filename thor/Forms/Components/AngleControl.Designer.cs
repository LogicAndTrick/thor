/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 19/12/2008
 * Time: 6:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class AngleControl
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
			this.lblAngle = new System.Windows.Forms.Label();
			this.cmbAngles = new System.Windows.Forms.ComboBox();
			this.lblAngles = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblAngle
			// 
			this.lblAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAngle.Location = new System.Drawing.Point(75, 44);
			this.lblAngle.Name = "lblAngle";
			this.lblAngle.Size = new System.Drawing.Size(40, 20);
			this.lblAngle.TabIndex = 0;
			this.lblAngle.Text = "label1";
			this.lblAngle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// cmbAngles
			// 
			this.cmbAngles.FormattingEnabled = true;
			this.cmbAngles.Items.AddRange(new object[] {
									"Up",
									"Down"});
			this.cmbAngles.Location = new System.Drawing.Point(3, 20);
			this.cmbAngles.Name = "cmbAngles";
			this.cmbAngles.Size = new System.Drawing.Size(58, 21);
			this.cmbAngles.TabIndex = 7;
			this.cmbAngles.SelectedIndexChanged += new System.EventHandler(this.CmbAnglesSelectedIndexChanged);
			this.cmbAngles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbAnglesKeyDown);
			// 
			// lblAngles
			// 
			this.lblAngles.Location = new System.Drawing.Point(3, 1);
			this.lblAngles.Name = "lblAngles";
			this.lblAngles.Size = new System.Drawing.Size(45, 16);
			this.lblAngles.TabIndex = 6;
			this.lblAngles.Text = "Angles:";
			this.lblAngles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AngleControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cmbAngles);
			this.Controls.Add(this.lblAngles);
			this.Controls.Add(this.lblAngle);
			this.Name = "AngleControl";
			this.Size = new System.Drawing.Size(115, 64);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AngleControlMouseMove);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AngleControlMouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AngleControlMouseUp);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblAngles;
		private System.Windows.Forms.ComboBox cmbAngles;
		private System.Windows.Forms.Label lblAngle;
	}
}
