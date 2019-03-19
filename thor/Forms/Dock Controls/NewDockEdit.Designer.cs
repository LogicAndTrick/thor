/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 4/11/2009
 * Time: 6:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class NewDockEdit
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
			this.quadSplitControl1 = new thor.QuadSplitControl();
			this.tabStrip1 = new thor.TabStrip();
			this.SuspendLayout();
			// 
			// quadSplitControl1
			// 
			this.quadSplitControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.quadSplitControl1.AutosizeViews = false;
			this.quadSplitControl1.BorderPadding = 3;
			this.quadSplitControl1.Display = thor.QuadSplitControl.DisplayMode.Normal;
			this.quadSplitControl1.HorizontalSplitLocation = 200;
			this.quadSplitControl1.Location = new System.Drawing.Point(0, 28);
			this.quadSplitControl1.MinHeight = 20;
			this.quadSplitControl1.MinWidth = 20;
			this.quadSplitControl1.Name = "quadSplitControl1";
			this.quadSplitControl1.Size = new System.Drawing.Size(820, 529);
			this.quadSplitControl1.SplitterWidth = 3;
			this.quadSplitControl1.TabIndex = 0;
			this.quadSplitControl1.VerticalSplitLocation = 400;
			// 
			// tabStrip1
			// 
			this.tabStrip1.ActiveTabBackColour = System.Drawing.SystemColors.ControlLightLight;
			this.tabStrip1.ActiveTabForeColour = System.Drawing.Color.Black;
			this.tabStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabStrip1.InactiveTabBackColour = System.Drawing.Color.LightGray;
			this.tabStrip1.InactiveTabForeColour = System.Drawing.Color.Black;
			this.tabStrip1.Location = new System.Drawing.Point(0, 3);
			this.tabStrip1.Name = "tabStrip1";
			this.tabStrip1.SelectedFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabStrip1.SelectedIndex = -1;
			this.tabStrip1.Size = new System.Drawing.Size(823, 19);
			this.tabStrip1.TabIndex = 1;
			// 
			// NewDockEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabStrip1);
			this.Controls.Add(this.quadSplitControl1);
			this.Name = "NewDockEdit";
			this.Size = new System.Drawing.Size(823, 560);
			this.ResumeLayout(false);
		}
		private thor.TabStrip tabStrip1;
		private thor.QuadSplitControl quadSplitControl1;
	}
}
