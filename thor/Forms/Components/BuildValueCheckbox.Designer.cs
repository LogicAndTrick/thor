/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 25/07/2009
 * Time: 7:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class BuildValueCheckbox
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
			this.components = new System.ComponentModel.Container();
			this.chkEnabled = new System.Windows.Forms.CheckBox();
			this.nudValue = new System.Windows.Forms.NumericUpDown();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.cmbValue = new System.Windows.Forms.ComboBox();
			this.tipHelper = new System.Windows.Forms.ToolTip(this.components);
			this.pnlColour = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
			this.SuspendLayout();
			// 
			// chkEnabled
			// 
			this.chkEnabled.BackColor = System.Drawing.Color.Transparent;
			this.chkEnabled.Location = new System.Drawing.Point(0, 1);
			this.chkEnabled.Name = "chkEnabled";
			this.chkEnabled.Size = new System.Drawing.Size(100, 20);
			this.chkEnabled.TabIndex = 0;
			this.chkEnabled.Text = "label";
			this.chkEnabled.UseVisualStyleBackColor = false;
			this.chkEnabled.CheckedChanged += new System.EventHandler(this.ChkEnabledCheckedChanged);
			// 
			// nudValue
			// 
			this.nudValue.Location = new System.Drawing.Point(39, 2);
			this.nudValue.Maximum = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.nudValue.Name = "nudValue";
			this.nudValue.Size = new System.Drawing.Size(32, 20);
			this.nudValue.TabIndex = 1;
			this.nudValue.ValueChanged += new System.EventHandler(this.NudValueValueChanged);
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(77, 1);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(32, 20);
			this.txtValue.TabIndex = 2;
			this.txtValue.TextChanged += new System.EventHandler(this.TxtValueTextChanged);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(115, 1);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(32, 20);
			this.btnBrowse.TabIndex = 3;
			this.btnBrowse.Text = "...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
			// 
			// cmbValue
			// 
			this.cmbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbValue.FormattingEnabled = true;
			this.cmbValue.Location = new System.Drawing.Point(153, 1);
			this.cmbValue.Name = "cmbValue";
			this.cmbValue.Size = new System.Drawing.Size(32, 21);
			this.cmbValue.TabIndex = 4;
			this.cmbValue.SelectedIndexChanged += new System.EventHandler(this.CmbValueSelectedIndexChanged);
			// 
			// tipHelper
			// 
			this.tipHelper.AutoPopDelay = 5000;
			this.tipHelper.InitialDelay = 300;
			this.tipHelper.ReshowDelay = 100;
			// 
			// pnlColour
			// 
			this.pnlColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlColour.Location = new System.Drawing.Point(141, 2);
			this.pnlColour.Name = "pnlColour";
			this.pnlColour.Size = new System.Drawing.Size(18, 19);
			this.pnlColour.TabIndex = 5;
			this.pnlColour.BackColorChanged += new System.EventHandler(this.PnlColourBackColorChanged);
			this.pnlColour.Click += new System.EventHandler(this.PnlColourClick);
			// 
			// BuildValueCheckbox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cmbValue);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.nudValue);
			this.Controls.Add(this.chkEnabled);
			this.Controls.Add(this.pnlColour);
			this.Name = "BuildValueCheckbox";
			this.Size = new System.Drawing.Size(188, 22);
			((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Panel pnlColour;
		private System.Windows.Forms.ToolTip tipHelper;
		private System.Windows.Forms.NumericUpDown nudValue;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.ComboBox cmbValue;
		private System.Windows.Forms.CheckBox chkEnabled;
	}
}
