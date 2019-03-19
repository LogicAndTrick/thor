/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 30/12/2008
 * Time: 11:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class GameChooseForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameChooseForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lstWONGS = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lstSteamGS = new System.Windows.Forms.ListBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lstSource = new System.Windows.Forms.ListBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.bthCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 86);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(225, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "WON Goldsource";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 86);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(225, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Steam Goldsource";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(225, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Source";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lstWONGS
			// 
			this.lstWONGS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
			this.lstWONGS.FormattingEnabled = true;
			this.lstWONGS.ItemHeight = 20;
			this.lstWONGS.Items.AddRange(new object[] {
									"1",
									"2",
									"3",
									"4",
									"5"});
			this.lstWONGS.Location = new System.Drawing.Point(25, 112);
			this.lstWONGS.Name = "lstWONGS";
			this.lstWONGS.Size = new System.Drawing.Size(187, 184);
			this.lstWONGS.TabIndex = 1;
			this.lstWONGS.SelectedIndexChanged += new System.EventHandler(this.LstWONGSSelectedIndexChanged);
			this.lstWONGS.DoubleClick += new System.EventHandler(this.LstGameDoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.lstWONGS);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(237, 307);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.Location = new System.Drawing.Point(6, 19);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(225, 56);
			this.panel1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Controls.Add(this.lstSteamGS);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(255, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(237, 307);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
			this.panel2.Location = new System.Drawing.Point(6, 19);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(225, 56);
			this.panel2.TabIndex = 0;
			// 
			// lstSteamGS
			// 
			this.lstSteamGS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
			this.lstSteamGS.FormattingEnabled = true;
			this.lstSteamGS.ItemHeight = 20;
			this.lstSteamGS.Items.AddRange(new object[] {
									"6",
									"7"});
			this.lstSteamGS.Location = new System.Drawing.Point(25, 112);
			this.lstSteamGS.Name = "lstSteamGS";
			this.lstSteamGS.Size = new System.Drawing.Size(187, 184);
			this.lstSteamGS.TabIndex = 1;
			this.lstSteamGS.SelectedIndexChanged += new System.EventHandler(this.LstSteamGSSelectedIndexChanged);
			this.lstSteamGS.DoubleClick += new System.EventHandler(this.LstGameDoubleClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel3);
			this.groupBox3.Controls.Add(this.lstSource);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new System.Drawing.Point(498, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(237, 307);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
			this.panel3.Location = new System.Drawing.Point(6, 19);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(225, 56);
			this.panel3.TabIndex = 0;
			// 
			// lstSource
			// 
			this.lstSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
			this.lstSource.FormattingEnabled = true;
			this.lstSource.ItemHeight = 20;
			this.lstSource.Items.AddRange(new object[] {
									"8",
									"9",
									"10"});
			this.lstSource.Location = new System.Drawing.Point(25, 112);
			this.lstSource.Name = "lstSource";
			this.lstSource.Size = new System.Drawing.Size(187, 184);
			this.lstSource.TabIndex = 1;
			this.lstSource.SelectedIndexChanged += new System.EventHandler(this.LstSourceSelectedIndexChanged);
			this.lstSource.DoubleClick += new System.EventHandler(this.LstGameDoubleClick);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(321, 325);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(113, 34);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "Use this Config";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// bthCancel
			// 
			this.bthCancel.Location = new System.Drawing.Point(660, 336);
			this.bthCancel.Name = "bthCancel";
			this.bthCancel.Size = new System.Drawing.Size(75, 23);
			this.bthCancel.TabIndex = 4;
			this.bthCancel.Text = "Cancel";
			this.bthCancel.UseVisualStyleBackColor = true;
			this.bthCancel.Click += new System.EventHandler(this.BthCancelClick);
			// 
			// GameChooseForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(746, 371);
			this.Controls.Add(this.bthCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "GameChooseForm";
			this.Text = "Choose Your Game";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox lstWONGS;
		private System.Windows.Forms.ListBox lstSteamGS;
		private System.Windows.Forms.ListBox lstSource;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button bthCancel;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
