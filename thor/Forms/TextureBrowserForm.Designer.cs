/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 27/07/2009
 * Time: 10:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class TextureBrowserForm
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
			this.textureGridControl1 = new thor.TextureGridControl();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textureGridControl1
			// 
			this.textureGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textureGridControl1.BackColor = System.Drawing.Color.Black;
			this.textureGridControl1.Location = new System.Drawing.Point(173, 0);
			this.textureGridControl1.MinimumSize = new System.Drawing.Size(300, 300);
			this.textureGridControl1.Name = "textureGridControl1";
			this.textureGridControl1.SelectedTexture = null;
			this.textureGridControl1.Size = new System.Drawing.Size(603, 381);
			this.textureGridControl1.TabIndex = 0;
			this.textureGridControl1.DoubleClick += new System.EventHandler(this.TextureGridControl1DoubleClick);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox1.Location = new System.Drawing.Point(12, 387);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(236, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
									"64x64",
									"128x128",
									"256x256",
									"512x512"});
			this.comboBox1.Location = new System.Drawing.Point(254, 386);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 2;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.IntegralHeight = false;
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(173, 208);
			this.listBox1.TabIndex = 3;
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.Location = new System.Drawing.Point(0, 207);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(173, 174);
			this.treeView1.TabIndex = 4;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOK.Location = new System.Drawing.Point(381, 387);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(73, 20);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.Location = new System.Drawing.Point(460, 387);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(73, 20);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// TextureBrowserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 477);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.textureGridControl1);
			this.MinimumSize = new System.Drawing.Size(500, 450);
			this.Name = "TextureBrowserForm";
			this.Text = "TextureBrowserForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox1;
		private thor.TextureGridControl textureGridControl1;
	}
}
