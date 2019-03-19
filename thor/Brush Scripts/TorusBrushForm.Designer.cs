/*
 * Created by SharpDevelop.
 * User: s4142421
 * Date: 5/05/2009
 * Time: 11:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class TorusBrushForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Width of ring:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 1;
			this.numericUpDown1.Increment = new decimal(new int[] {
									1,
									0,
									0,
									65536});
			this.numericUpDown1.Location = new System.Drawing.Point(140, 9);
			this.numericUpDown1.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									65536});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(80, 20);
			this.numericUpDown1.TabIndex = 1;
			this.numericUpDown1.Value = new decimal(new int[] {
									1,
									0,
									0,
									65536});
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Number of tube sides:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(140, 35);
			this.numericUpDown2.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									65536});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(80, 20);
			this.numericUpDown2.TabIndex = 1;
			this.numericUpDown2.Value = new decimal(new int[] {
									8,
									0,
									0,
									0});
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(119, 61);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(101, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 61);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(101, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// TorusBrushForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(230, 90);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.numericUpDown2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "TorusBrushForm";
			this.Text = "TorusBrushForm";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label1;
	}
}
