﻿/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/01/2009
 * Time: 11:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class DockEdit
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
			this.qscViews = new thor.QuadSplitControl();
			this.SuspendLayout();
			// 
			// qscViews
			// 
			this.qscViews.AutosizeViews = true;
			this.qscViews.BorderPadding = 0;
			this.qscViews.Display = thor.QuadSplitControl.DisplayMode.Normal;
			this.qscViews.Dock = System.Windows.Forms.DockStyle.Fill;
			this.qscViews.HorizontalSplitLocation = 136;
			this.qscViews.Location = new System.Drawing.Point(0, 0);
			this.qscViews.MinHeight = 20;
			this.qscViews.MinWidth = 20;
			this.qscViews.Name = "qscViews";
			this.qscViews.Size = new System.Drawing.Size(339, 273);
			this.qscViews.SplitterWidth = 3;
			this.qscViews.TabIndex = 1;
			this.qscViews.VerticalSplitLocation = 169;
			// 
			// DockEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 273);
			this.Controls.Add(this.qscViews);
			this.Name = "DockEdit";
			this.Text = "DockEdit";
			this.ResumeLayout(false);
		}
		private thor.QuadSplitControl qscViews;
	}
}
