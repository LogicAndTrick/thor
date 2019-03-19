/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/01/2009
 * Time: 7:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class DockObject
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbObjectList = new System.Windows.Forms.ComboBox();
			this.nudNumber = new System.Windows.Forms.NumericUpDown();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "Move Selected:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(137, 10);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(68, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "To World";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(62, 10);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(69, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "To Entity";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Objects:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbObjectList
			// 
			this.cmbObjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbObjectList.Enabled = false;
			this.cmbObjectList.FormattingEnabled = true;
			this.cmbObjectList.Location = new System.Drawing.Point(3, 62);
			this.cmbObjectList.Name = "cmbObjectList";
			this.cmbObjectList.Size = new System.Drawing.Size(202, 21);
			this.cmbObjectList.TabIndex = 3;
			// 
			// nudNumber
			// 
			this.nudNumber.Enabled = false;
			this.nudNumber.Location = new System.Drawing.Point(136, 39);
			this.nudNumber.Name = "nudNumber";
			this.nudNumber.Size = new System.Drawing.Size(69, 20);
			this.nudNumber.TabIndex = 4;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(115, 89);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(90, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "Create Prefab";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// DockObject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(211, 118);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.nudNumber);
			this.Controls.Add(this.cmbObjectList);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "DockObject";
			((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox cmbObjectList;
		private System.Windows.Forms.NumericUpDown nudNumber;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
	}
}
