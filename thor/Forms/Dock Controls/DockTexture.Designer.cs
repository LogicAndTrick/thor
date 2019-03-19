/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/01/2009
 * Time: 2:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class DockTexture
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Texture Group:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(3, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(202, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Current Texture:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(3, 82);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(202, 21);
			this.comboBox2.TabIndex = 1;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Location = new System.Drawing.Point(3, 109);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(121, 107);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(130, 193);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Replace...";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(130, 164);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Browse...";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// DockTexture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Name = "DockTexture";
			this.Size = new System.Drawing.Size(208, 224);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
	}
}
