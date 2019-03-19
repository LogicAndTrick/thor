/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 19/12/2008
 * Time: 6:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class EntityEditor
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
			this.tbcTabs = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnKeyValuesPaste = new System.Windows.Forms.Button();
			this.BtnKeyValuesCopy = new System.Windows.Forms.Button();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.txtHelp = new System.Windows.Forms.TextBox();
			this.btnHelp = new System.Windows.Forms.Button();
			this.btnSmartEdit = new System.Windows.Forms.Button();
			this.lstKeyValues = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.cmbClass = new System.Windows.Forms.ComboBox();
			this.cmbValue = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.angleControl1 = new thor.AngleControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.clstFlags = new System.Windows.Forms.CheckedListBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.label11 = new System.Windows.Forms.Label();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.tbcTabs.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbcTabs
			// 
			this.tbcTabs.Controls.Add(this.tabPage1);
			this.tbcTabs.Controls.Add(this.tabPage2);
			this.tbcTabs.Controls.Add(this.tabPage3);
			this.tbcTabs.Controls.Add(this.tabPage4);
			this.tbcTabs.Controls.Add(this.tabPage5);
			this.tbcTabs.Location = new System.Drawing.Point(12, 12);
			this.tbcTabs.Name = "tbcTabs";
			this.tbcTabs.SelectedIndex = 0;
			this.tbcTabs.Size = new System.Drawing.Size(682, 406);
			this.tbcTabs.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnKeyValuesPaste);
			this.tabPage1.Controls.Add(this.BtnKeyValuesCopy);
			this.tabPage1.Controls.Add(this.txtComments);
			this.tabPage1.Controls.Add(this.txtHelp);
			this.tabPage1.Controls.Add(this.btnHelp);
			this.tabPage1.Controls.Add(this.btnSmartEdit);
			this.tabPage1.Controls.Add(this.lstKeyValues);
			this.tabPage1.Controls.Add(this.cmbClass);
			this.tabPage1.Controls.Add(this.cmbValue);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.angleControl1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(674, 380);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Class Info";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnKeyValuesPaste
			// 
			this.btnKeyValuesPaste.Location = new System.Drawing.Point(124, 46);
			this.btnKeyValuesPaste.Name = "btnKeyValuesPaste";
			this.btnKeyValuesPaste.Size = new System.Drawing.Size(44, 20);
			this.btnKeyValuesPaste.TabIndex = 7;
			this.btnKeyValuesPaste.Text = "Paste";
			this.btnKeyValuesPaste.UseVisualStyleBackColor = true;
			// 
			// BtnKeyValuesCopy
			// 
			this.BtnKeyValuesCopy.Location = new System.Drawing.Point(74, 47);
			this.BtnKeyValuesCopy.Name = "BtnKeyValuesCopy";
			this.BtnKeyValuesCopy.Size = new System.Drawing.Size(44, 20);
			this.BtnKeyValuesCopy.TabIndex = 7;
			this.BtnKeyValuesCopy.Text = "Copy";
			this.BtnKeyValuesCopy.UseVisualStyleBackColor = true;
			// 
			// txtComments
			// 
			this.txtComments.Location = new System.Drawing.Point(402, 275);
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(266, 91);
			this.txtComments.TabIndex = 6;
			// 
			// txtHelp
			// 
			this.txtHelp.Location = new System.Drawing.Point(402, 157);
			this.txtHelp.Multiline = true;
			this.txtHelp.Name = "txtHelp";
			this.txtHelp.ReadOnly = true;
			this.txtHelp.Size = new System.Drawing.Size(266, 91);
			this.txtHelp.TabIndex = 6;
			// 
			// btnHelp
			// 
			this.btnHelp.Location = new System.Drawing.Point(473, 7);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(74, 23);
			this.btnHelp.TabIndex = 4;
			this.btnHelp.Text = "Help";
			this.btnHelp.UseVisualStyleBackColor = true;
			// 
			// btnSmartEdit
			// 
			this.btnSmartEdit.Location = new System.Drawing.Point(393, 7);
			this.btnSmartEdit.Name = "btnSmartEdit";
			this.btnSmartEdit.Size = new System.Drawing.Size(74, 23);
			this.btnSmartEdit.TabIndex = 4;
			this.btnSmartEdit.Text = "Smart Edit";
			this.btnSmartEdit.UseVisualStyleBackColor = true;
			// 
			// lstKeyValues
			// 
			this.lstKeyValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.lstKeyValues.FullRowSelect = true;
			this.lstKeyValues.GridLines = true;
			this.lstKeyValues.Location = new System.Drawing.Point(6, 73);
			this.lstKeyValues.MultiSelect = false;
			this.lstKeyValues.Name = "lstKeyValues";
			this.lstKeyValues.Size = new System.Drawing.Size(390, 301);
			this.lstKeyValues.TabIndex = 3;
			this.lstKeyValues.UseCompatibleStateImageBehavior = false;
			this.lstKeyValues.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Property Name";
			this.columnHeader1.Width = 162;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value";
			this.columnHeader2.Width = 201;
			// 
			// cmbClass
			// 
			this.cmbClass.FormattingEnabled = true;
			this.cmbClass.Location = new System.Drawing.Point(57, 7);
			this.cmbClass.Name = "cmbClass";
			this.cmbClass.Size = new System.Drawing.Size(260, 21);
			this.cmbClass.TabIndex = 2;
			// 
			// cmbValue
			// 
			this.cmbValue.FormattingEnabled = true;
			this.cmbValue.Location = new System.Drawing.Point(402, 73);
			this.cmbValue.Name = "cmbValue";
			this.cmbValue.Size = new System.Drawing.Size(266, 21);
			this.cmbValue.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(402, 251);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 21);
			this.label4.TabIndex = 1;
			this.label4.Text = "Comments:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(402, 133);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 21);
			this.label3.TabIndex = 1;
			this.label3.Text = "Help:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 46);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(62, 21);
			this.label5.TabIndex = 1;
			this.label5.Text = "Keyvalues:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Class:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// angleControl1
			// 
			this.angleControl1.Location = new System.Drawing.Point(553, 6);
			this.angleControl1.Name = "angleControl1";
			this.angleControl1.ShowLabel = false;
			this.angleControl1.ShowTextBox = true;
			this.angleControl1.Size = new System.Drawing.Size(115, 46);
			this.angleControl1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button4);
			this.tabPage2.Controls.Add(this.button3);
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Controls.Add(this.listView1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(674, 380);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Outputs";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(593, 205);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 6;
			this.button4.Text = "Delete";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(512, 205);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "Paste";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(431, 205);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "Copy";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(350, 205);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(6, 205);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 169);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Edit Entry";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(171, 122);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(104, 20);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Once Only";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Increment = new decimal(new int[] {
									1,
									0,
									0,
									131072});
			this.numericUpDown1.Location = new System.Drawing.Point(115, 122);
			this.numericUpDown1.Maximum = new decimal(new int[] {
									1000000,
									0,
									0,
									0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
			this.numericUpDown1.TabIndex = 2;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 120);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(103, 20);
			this.label10.TabIndex = 0;
			this.label10.Text = "Delay (seconds):";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(115, 94);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(197, 20);
			this.textBox4.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(6, 94);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(103, 20);
			this.label9.TabIndex = 0;
			this.label9.Text = "Parameter Override:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(115, 68);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(197, 20);
			this.textBox3.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 68);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(103, 20);
			this.label8.TabIndex = 0;
			this.label8.Text = "Input:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(115, 42);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(197, 20);
			this.textBox2.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 42);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(103, 20);
			this.label7.TabIndex = 0;
			this.label7.Text = "Target Name:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(115, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(197, 20);
			this.textBox1.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(103, 20);
			this.label6.TabIndex = 0;
			this.label6.Text = "Output Name:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader8,
									this.columnHeader9,
									this.columnHeader7,
									this.columnHeader10});
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(6, 6);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(662, 193);
			this.listView1.TabIndex = 4;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Output Name";
			this.columnHeader5.Width = 92;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Target";
			this.columnHeader6.Width = 91;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Input";
			this.columnHeader8.Width = 101;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Parameter";
			this.columnHeader9.Width = 103;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Delay";
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Only Once";
			this.columnHeader10.Width = 79;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.listView2);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(674, 380);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Inputs";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// listView2
			// 
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader4,
									this.columnHeader3,
									this.columnHeader11,
									this.columnHeader12,
									this.columnHeader13,
									this.columnHeader14});
			this.listView2.GridLines = true;
			this.listView2.Location = new System.Drawing.Point(6, 6);
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(662, 368);
			this.listView2.TabIndex = 5;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Source";
			this.columnHeader4.Width = 91;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Output Name";
			this.columnHeader3.Width = 92;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Input";
			this.columnHeader11.Width = 101;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Parameter";
			this.columnHeader12.Width = 103;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Delay";
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Only Once";
			this.columnHeader14.Width = 79;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.clstFlags);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(674, 380);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Flags";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// clstFlags
			// 
			this.clstFlags.FormattingEnabled = true;
			this.clstFlags.Location = new System.Drawing.Point(6, 6);
			this.clstFlags.Name = "clstFlags";
			this.clstFlags.Size = new System.Drawing.Size(662, 364);
			this.clstFlags.TabIndex = 0;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.label11);
			this.tabPage5.Controls.Add(this.treeView1);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(674, 380);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Visgroup";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 3);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(103, 20);
			this.label11.TabIndex = 1;
			this.label11.Text = "Member of group:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(6, 26);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(662, 348);
			this.treeView1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(619, 424);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(538, 424);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			// 
			// EntityEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 459);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tbcTabs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EntityEditor";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "EntityEditor";
			this.tbcTabs.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private thor.AngleControl angleControl1;
		private System.Windows.Forms.CheckedListBox clstFlags;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.Button btnSmartEdit;
		private System.Windows.Forms.ListView lstKeyValues;
		private System.Windows.Forms.ComboBox cmbValue;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbClass;
		private System.Windows.Forms.TextBox txtHelp;
		private System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.Button BtnKeyValuesCopy;
		private System.Windows.Forms.Button btnKeyValuesPaste;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tbcTabs;
	}
}
