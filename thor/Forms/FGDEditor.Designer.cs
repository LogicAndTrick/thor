/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 19/01/2009
 * Time: 2:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class FGDEditor
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
			this.lstClass = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmbFilter = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnClassDescApply = new System.Windows.Forms.Button();
			this.btnClassDescReset = new System.Windows.Forms.Button();
			this.txtClassDescription = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lstBehaviours = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.btnBehaviourRemove = new System.Windows.Forms.Button();
			this.btnBehaviourNew = new System.Windows.Forms.Button();
			this.btnBehaviourApply = new System.Windows.Forms.Button();
			this.txtBehaviourValue = new System.Windows.Forms.TextBox();
			this.cmbBehaviourType = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnBaseClassRemove = new System.Windows.Forms.Button();
			this.btnBaseClassAdd = new System.Windows.Forms.Button();
			this.lstBaseClasses = new System.Windows.Forms.ListBox();
			this.cmbBaseClassAdd = new System.Windows.Forms.ComboBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnPropRemove = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.btnPropNew = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.btnPropApply = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.txtPropLongDesc = new System.Windows.Forms.TextBox();
			this.txtPropName = new System.Windows.Forms.TextBox();
			this.cmbPropType = new System.Windows.Forms.ComboBox();
			this.txtPropShortDesc = new System.Windows.Forms.TextBox();
			this.txtPropDefault = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.lstPropChoices = new System.Windows.Forms.ListView();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtPropChoiceKey = new System.Windows.Forms.TextBox();
			this.txtPropChoiceName = new System.Windows.Forms.TextBox();
			this.btnPropChoiceRemove = new System.Windows.Forms.Button();
			this.btnPropChoiceAdd = new System.Windows.Forms.Button();
			this.lstProperties = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.btnIORemove = new System.Windows.Forms.Button();
			this.btnIONew = new System.Windows.Forms.Button();
			this.btnIOApply = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.txtIOLongDesc = new System.Windows.Forms.TextBox();
			this.txtIOName = new System.Windows.Forms.TextBox();
			this.cmbIOChoose = new System.Windows.Forms.ComboBox();
			this.cmbIOType = new System.Windows.Forms.ComboBox();
			this.lstIO = new System.Windows.Forms.ListView();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.label10 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.lstFlags = new System.Windows.Forms.ListView();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.chkFlagsDefaultOn = new System.Windows.Forms.CheckBox();
			this.txtFlagsKey = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.btnFlagsApply = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.btnFlagsNew = new System.Windows.Forms.Button();
			this.btnFlagsRemove = new System.Windows.Forms.Button();
			this.txtFlagsName = new System.Windows.Forms.TextBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.txtPreview = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnMapSizeUnset = new System.Windows.Forms.Button();
			this.btnMapSizeSet = new System.Windows.Forms.Button();
			this.txtMapSizeLow = new System.Windows.Forms.TextBox();
			this.txtMapSizeHigh = new System.Windows.Forms.TextBox();
			this.btnIncludeRemove = new System.Windows.Forms.Button();
			this.btnIncludeAdd = new System.Windows.Forms.Button();
			this.txtIncludeAdd = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.lstIncludes = new System.Windows.Forms.ListBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstClass
			// 
			this.lstClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.lstClass.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1});
			this.lstClass.FullRowSelect = true;
			this.lstClass.Location = new System.Drawing.Point(12, 51);
			this.lstClass.Name = "lstClass";
			this.lstClass.Size = new System.Drawing.Size(165, 428);
			this.lstClass.TabIndex = 0;
			this.lstClass.UseCompatibleStateImageBehavior = false;
			this.lstClass.View = System.Windows.Forms.View.Details;
			this.lstClass.SelectedIndexChanged += new System.EventHandler(this.LstClassSelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Class";
			this.columnHeader1.Width = 138;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(839, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openToolStripMenuItem,
									this.saveToolStripMenuItem,
									this.saveAsToolStripMenuItem,
									this.closeToolStripMenuItem,
									this.toolStripSeparator1,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.saveAsToolStripMenuItem.Text = "Save As...";
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.closeToolStripMenuItem.Text = "Close";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// cmbFilter
			// 
			this.cmbFilter.FormattingEnabled = true;
			this.cmbFilter.Items.AddRange(new object[] {
									"Any",
									"Base",
									"Filter",
									"KeyFrame",
									"Move",
									"NPC",
									"Point",
									"Solid"});
			this.cmbFilter.Location = new System.Drawing.Point(56, 24);
			this.cmbFilter.Name = "cmbFilter";
			this.cmbFilter.Size = new System.Drawing.Size(121, 21);
			this.cmbFilter.TabIndex = 2;
			this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.CmbFilterSelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 21);
			this.label1.TabIndex = 3;
			this.label1.Text = "Filter";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Location = new System.Drawing.Point(183, 51);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(644, 428);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(636, 402);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Behaviour";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnClassDescApply);
			this.groupBox4.Controls.Add(this.btnClassDescReset);
			this.groupBox4.Controls.Add(this.txtClassDescription);
			this.groupBox4.Location = new System.Drawing.Point(320, 6);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(310, 179);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Class Description";
			// 
			// btnClassDescApply
			// 
			this.btnClassDescApply.Location = new System.Drawing.Point(148, 150);
			this.btnClassDescApply.Name = "btnClassDescApply";
			this.btnClassDescApply.Size = new System.Drawing.Size(75, 23);
			this.btnClassDescApply.TabIndex = 8;
			this.btnClassDescApply.Text = "Apply";
			this.btnClassDescApply.UseVisualStyleBackColor = true;
			this.btnClassDescApply.Click += new System.EventHandler(this.BtnClassDescApplyClick);
			// 
			// btnClassDescReset
			// 
			this.btnClassDescReset.Location = new System.Drawing.Point(229, 150);
			this.btnClassDescReset.Name = "btnClassDescReset";
			this.btnClassDescReset.Size = new System.Drawing.Size(75, 23);
			this.btnClassDescReset.TabIndex = 8;
			this.btnClassDescReset.Text = "Reset";
			this.btnClassDescReset.UseVisualStyleBackColor = true;
			this.btnClassDescReset.Click += new System.EventHandler(this.BtnClassDescResetClick);
			// 
			// txtClassDescription
			// 
			this.txtClassDescription.Location = new System.Drawing.Point(6, 19);
			this.txtClassDescription.Multiline = true;
			this.txtClassDescription.Name = "txtClassDescription";
			this.txtClassDescription.Size = new System.Drawing.Size(298, 125);
			this.txtClassDescription.TabIndex = 7;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lstBehaviours);
			this.groupBox2.Controls.Add(this.btnBehaviourRemove);
			this.groupBox2.Controls.Add(this.btnBehaviourNew);
			this.groupBox2.Controls.Add(this.btnBehaviourApply);
			this.groupBox2.Controls.Add(this.txtBehaviourValue);
			this.groupBox2.Controls.Add(this.cmbBehaviourType);
			this.groupBox2.Location = new System.Drawing.Point(6, 191);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(624, 205);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Other Behaviours";
			// 
			// lstBehaviours
			// 
			this.lstBehaviours.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader2,
									this.columnHeader3});
			this.lstBehaviours.FullRowSelect = true;
			this.lstBehaviours.Location = new System.Drawing.Point(6, 19);
			this.lstBehaviours.Name = "lstBehaviours";
			this.lstBehaviours.Size = new System.Drawing.Size(330, 180);
			this.lstBehaviours.TabIndex = 9;
			this.lstBehaviours.UseCompatibleStateImageBehavior = false;
			this.lstBehaviours.View = System.Windows.Forms.View.Details;
			this.lstBehaviours.SelectedIndexChanged += new System.EventHandler(this.LstBehavioursSelectedIndexChanged);
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			this.columnHeader2.Width = 103;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Value";
			this.columnHeader3.Width = 199;
			// 
			// btnBehaviourRemove
			// 
			this.btnBehaviourRemove.Location = new System.Drawing.Point(536, 72);
			this.btnBehaviourRemove.Name = "btnBehaviourRemove";
			this.btnBehaviourRemove.Size = new System.Drawing.Size(82, 24);
			this.btnBehaviourRemove.TabIndex = 8;
			this.btnBehaviourRemove.Text = "Remove";
			this.btnBehaviourRemove.UseVisualStyleBackColor = true;
			this.btnBehaviourRemove.Click += new System.EventHandler(this.BtnBehaviourRemoveClick);
			// 
			// btnBehaviourNew
			// 
			this.btnBehaviourNew.Location = new System.Drawing.Point(444, 72);
			this.btnBehaviourNew.Name = "btnBehaviourNew";
			this.btnBehaviourNew.Size = new System.Drawing.Size(86, 24);
			this.btnBehaviourNew.TabIndex = 8;
			this.btnBehaviourNew.Text = "Add as New";
			this.btnBehaviourNew.UseVisualStyleBackColor = true;
			this.btnBehaviourNew.Click += new System.EventHandler(this.BtnBehaviourNewClick);
			// 
			// btnBehaviourApply
			// 
			this.btnBehaviourApply.Location = new System.Drawing.Point(342, 72);
			this.btnBehaviourApply.Name = "btnBehaviourApply";
			this.btnBehaviourApply.Size = new System.Drawing.Size(96, 24);
			this.btnBehaviourApply.TabIndex = 8;
			this.btnBehaviourApply.Text = "Apply Changes";
			this.btnBehaviourApply.UseVisualStyleBackColor = true;
			this.btnBehaviourApply.Click += new System.EventHandler(this.BtnBehaviourApplyClick);
			// 
			// txtBehaviourValue
			// 
			this.txtBehaviourValue.Location = new System.Drawing.Point(342, 46);
			this.txtBehaviourValue.Name = "txtBehaviourValue";
			this.txtBehaviourValue.Size = new System.Drawing.Size(276, 20);
			this.txtBehaviourValue.TabIndex = 7;
			// 
			// cmbBehaviourType
			// 
			this.cmbBehaviourType.FormattingEnabled = true;
			this.cmbBehaviourType.Items.AddRange(new object[] {
									"color",
									"iconsprite",
									"sphere",
									"studio",
									"studioprop"});
			this.cmbBehaviourType.Location = new System.Drawing.Point(342, 19);
			this.cmbBehaviourType.Name = "cmbBehaviourType";
			this.cmbBehaviourType.Size = new System.Drawing.Size(276, 21);
			this.cmbBehaviourType.TabIndex = 6;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnBaseClassRemove);
			this.groupBox1.Controls.Add(this.btnBaseClassAdd);
			this.groupBox1.Controls.Add(this.lstBaseClasses);
			this.groupBox1.Controls.Add(this.cmbBaseClassAdd);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(308, 179);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Base Classes";
			// 
			// btnBaseClassRemove
			// 
			this.btnBaseClassRemove.Location = new System.Drawing.Point(194, 46);
			this.btnBaseClassRemove.Name = "btnBaseClassRemove";
			this.btnBaseClassRemove.Size = new System.Drawing.Size(56, 21);
			this.btnBaseClassRemove.TabIndex = 6;
			this.btnBaseClassRemove.Text = "Remove";
			this.btnBaseClassRemove.UseVisualStyleBackColor = true;
			this.btnBaseClassRemove.Click += new System.EventHandler(this.BtnBaseClassRemoveClick);
			// 
			// btnBaseClassAdd
			// 
			this.btnBaseClassAdd.Location = new System.Drawing.Point(132, 46);
			this.btnBaseClassAdd.Name = "btnBaseClassAdd";
			this.btnBaseClassAdd.Size = new System.Drawing.Size(56, 21);
			this.btnBaseClassAdd.TabIndex = 6;
			this.btnBaseClassAdd.Text = "Add";
			this.btnBaseClassAdd.UseVisualStyleBackColor = true;
			this.btnBaseClassAdd.Click += new System.EventHandler(this.BtnBaseClassAddClick);
			// 
			// lstBaseClasses
			// 
			this.lstBaseClasses.FormattingEnabled = true;
			this.lstBaseClasses.Location = new System.Drawing.Point(6, 19);
			this.lstBaseClasses.Name = "lstBaseClasses";
			this.lstBaseClasses.Size = new System.Drawing.Size(120, 147);
			this.lstBaseClasses.TabIndex = 5;
			// 
			// cmbBaseClassAdd
			// 
			this.cmbBaseClassAdd.FormattingEnabled = true;
			this.cmbBaseClassAdd.Location = new System.Drawing.Point(132, 19);
			this.cmbBaseClassAdd.MaxDropDownItems = 20;
			this.cmbBaseClassAdd.Name = "cmbBaseClassAdd";
			this.cmbBaseClassAdd.Size = new System.Drawing.Size(170, 21);
			this.cmbBaseClassAdd.TabIndex = 4;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox6);
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Controls.Add(this.lstProperties);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(636, 402);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Properties";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label2);
			this.groupBox6.Controls.Add(this.label3);
			this.groupBox6.Controls.Add(this.btnPropRemove);
			this.groupBox6.Controls.Add(this.label4);
			this.groupBox6.Controls.Add(this.btnPropNew);
			this.groupBox6.Controls.Add(this.label5);
			this.groupBox6.Controls.Add(this.btnPropApply);
			this.groupBox6.Controls.Add(this.label6);
			this.groupBox6.Controls.Add(this.txtPropLongDesc);
			this.groupBox6.Controls.Add(this.txtPropName);
			this.groupBox6.Controls.Add(this.cmbPropType);
			this.groupBox6.Controls.Add(this.txtPropShortDesc);
			this.groupBox6.Controls.Add(this.txtPropDefault);
			this.groupBox6.Location = new System.Drawing.Point(6, 165);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(256, 231);
			this.groupBox6.TabIndex = 9;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Property";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Name";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 21);
			this.label3.TabIndex = 3;
			this.label3.Text = "Type";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnPropRemove
			// 
			this.btnPropRemove.Location = new System.Drawing.Point(166, 196);
			this.btnPropRemove.Name = "btnPropRemove";
			this.btnPropRemove.Size = new System.Drawing.Size(75, 23);
			this.btnPropRemove.TabIndex = 7;
			this.btnPropRemove.Text = "Remove";
			this.btnPropRemove.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 20);
			this.label4.TabIndex = 3;
			this.label4.Text = "Short Desc.";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnPropNew
			// 
			this.btnPropNew.Location = new System.Drawing.Point(87, 196);
			this.btnPropNew.Name = "btnPropNew";
			this.btnPropNew.Size = new System.Drawing.Size(75, 23);
			this.btnPropNew.TabIndex = 7;
			this.btnPropNew.Text = "Add as New";
			this.btnPropNew.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 20);
			this.label5.TabIndex = 3;
			this.label5.Text = "Default";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnPropApply
			// 
			this.btnPropApply.Location = new System.Drawing.Point(8, 196);
			this.btnPropApply.Name = "btnPropApply";
			this.btnPropApply.Size = new System.Drawing.Size(75, 23);
			this.btnPropApply.TabIndex = 7;
			this.btnPropApply.Text = "Apply";
			this.btnPropApply.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 121);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 20);
			this.label6.TabIndex = 3;
			this.label6.Text = "Long Desc.";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPropLongDesc
			// 
			this.txtPropLongDesc.Location = new System.Drawing.Point(87, 121);
			this.txtPropLongDesc.Multiline = true;
			this.txtPropLongDesc.Name = "txtPropLongDesc";
			this.txtPropLongDesc.Size = new System.Drawing.Size(154, 66);
			this.txtPropLongDesc.TabIndex = 6;
			// 
			// txtPropName
			// 
			this.txtPropName.Location = new System.Drawing.Point(87, 16);
			this.txtPropName.Name = "txtPropName";
			this.txtPropName.Size = new System.Drawing.Size(154, 20);
			this.txtPropName.TabIndex = 4;
			// 
			// cmbPropType
			// 
			this.cmbPropType.FormattingEnabled = true;
			this.cmbPropType.Items.AddRange(new object[] {
									"axis",
									"angle",
									"bool",
									"choices",
									"color255",
									"color1",
									"decal",
									"filterclass",
									"flags",
									"float",
									"integer",
									"material",
									"node_dest",
									"origin",
									"pointentityclass",
									"scene",
									"sidelist",
									"sound",
									"sprite",
									"string",
									"studio",
									"target_destination",
									"target_name_or_class",
									"target_source",
									"vecline",
									"vector",
									"void"});
			this.cmbPropType.Location = new System.Drawing.Point(87, 42);
			this.cmbPropType.Name = "cmbPropType";
			this.cmbPropType.Size = new System.Drawing.Size(154, 21);
			this.cmbPropType.TabIndex = 5;
			// 
			// txtPropShortDesc
			// 
			this.txtPropShortDesc.Location = new System.Drawing.Point(87, 69);
			this.txtPropShortDesc.Name = "txtPropShortDesc";
			this.txtPropShortDesc.Size = new System.Drawing.Size(154, 20);
			this.txtPropShortDesc.TabIndex = 4;
			// 
			// txtPropDefault
			// 
			this.txtPropDefault.Location = new System.Drawing.Point(87, 95);
			this.txtPropDefault.Name = "txtPropDefault";
			this.txtPropDefault.Size = new System.Drawing.Size(154, 20);
			this.txtPropDefault.TabIndex = 4;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.lstPropChoices);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.txtPropChoiceKey);
			this.groupBox5.Controls.Add(this.txtPropChoiceName);
			this.groupBox5.Controls.Add(this.btnPropChoiceRemove);
			this.groupBox5.Controls.Add(this.btnPropChoiceAdd);
			this.groupBox5.Location = new System.Drawing.Point(268, 165);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(362, 231);
			this.groupBox5.TabIndex = 8;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Choices";
			// 
			// lstPropChoices
			// 
			this.lstPropChoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader9,
									this.columnHeader10});
			this.lstPropChoices.Location = new System.Drawing.Point(6, 19);
			this.lstPropChoices.Name = "lstPropChoices";
			this.lstPropChoices.Size = new System.Drawing.Size(349, 122);
			this.lstPropChoices.TabIndex = 0;
			this.lstPropChoices.UseCompatibleStateImageBehavior = false;
			this.lstPropChoices.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Key";
			this.columnHeader9.Width = 73;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Name";
			this.columnHeader10.Width = 172;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 148);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(47, 20);
			this.label11.TabIndex = 3;
			this.label11.Text = "Key";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(6, 174);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(47, 20);
			this.label12.TabIndex = 3;
			this.label12.Text = "Name";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPropChoiceKey
			// 
			this.txtPropChoiceKey.Location = new System.Drawing.Point(59, 148);
			this.txtPropChoiceKey.Name = "txtPropChoiceKey";
			this.txtPropChoiceKey.Size = new System.Drawing.Size(296, 20);
			this.txtPropChoiceKey.TabIndex = 4;
			// 
			// txtPropChoiceName
			// 
			this.txtPropChoiceName.Location = new System.Drawing.Point(59, 174);
			this.txtPropChoiceName.Name = "txtPropChoiceName";
			this.txtPropChoiceName.Size = new System.Drawing.Size(296, 20);
			this.txtPropChoiceName.TabIndex = 4;
			// 
			// btnPropChoiceRemove
			// 
			this.btnPropChoiceRemove.Location = new System.Drawing.Point(132, 200);
			this.btnPropChoiceRemove.Name = "btnPropChoiceRemove";
			this.btnPropChoiceRemove.Size = new System.Drawing.Size(67, 20);
			this.btnPropChoiceRemove.TabIndex = 6;
			this.btnPropChoiceRemove.Text = "Remove";
			this.btnPropChoiceRemove.UseVisualStyleBackColor = true;
			this.btnPropChoiceRemove.Click += new System.EventHandler(this.BtnBaseClassRemoveClick);
			// 
			// btnPropChoiceAdd
			// 
			this.btnPropChoiceAdd.Location = new System.Drawing.Point(59, 200);
			this.btnPropChoiceAdd.Name = "btnPropChoiceAdd";
			this.btnPropChoiceAdd.Size = new System.Drawing.Size(67, 19);
			this.btnPropChoiceAdd.TabIndex = 6;
			this.btnPropChoiceAdd.Text = "Add";
			this.btnPropChoiceAdd.UseVisualStyleBackColor = true;
			this.btnPropChoiceAdd.Click += new System.EventHandler(this.BtnBaseClassAddClick);
			// 
			// lstProperties
			// 
			this.lstProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7,
									this.columnHeader8});
			this.lstProperties.Location = new System.Drawing.Point(6, 6);
			this.lstProperties.Name = "lstProperties";
			this.lstProperties.Size = new System.Drawing.Size(624, 153);
			this.lstProperties.TabIndex = 0;
			this.lstProperties.UseCompatibleStateImageBehavior = false;
			this.lstProperties.View = System.Windows.Forms.View.Details;
			this.lstProperties.SelectedIndexChanged += new System.EventHandler(this.LstPropertiesSelectedIndexChanged);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Name";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Type";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Short Description";
			this.columnHeader6.Width = 110;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Default";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Long Description";
			this.columnHeader8.Width = 293;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox7);
			this.tabPage3.Controls.Add(this.lstIO);
			this.tabPage3.Controls.Add(this.label10);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(636, 402);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Input/Output";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.label13);
			this.groupBox7.Controls.Add(this.label15);
			this.groupBox7.Controls.Add(this.label14);
			this.groupBox7.Controls.Add(this.btnIORemove);
			this.groupBox7.Controls.Add(this.btnIONew);
			this.groupBox7.Controls.Add(this.btnIOApply);
			this.groupBox7.Controls.Add(this.label17);
			this.groupBox7.Controls.Add(this.txtIOLongDesc);
			this.groupBox7.Controls.Add(this.txtIOName);
			this.groupBox7.Controls.Add(this.cmbIOChoose);
			this.groupBox7.Controls.Add(this.cmbIOType);
			this.groupBox7.Location = new System.Drawing.Point(374, 29);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(256, 237);
			this.groupBox7.TabIndex = 10;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Inputs and Outputs";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(6, 46);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(75, 20);
			this.label13.TabIndex = 3;
			this.label13.Text = "Name";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(6, 19);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(75, 21);
			this.label15.TabIndex = 3;
			this.label15.Text = "Input/Output";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(6, 72);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(75, 21);
			this.label14.TabIndex = 3;
			this.label14.Text = "Type";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnIORemove
			// 
			this.btnIORemove.Location = new System.Drawing.Point(166, 208);
			this.btnIORemove.Name = "btnIORemove";
			this.btnIORemove.Size = new System.Drawing.Size(75, 23);
			this.btnIORemove.TabIndex = 7;
			this.btnIORemove.Text = "Remove";
			this.btnIORemove.UseVisualStyleBackColor = true;
			// 
			// btnIONew
			// 
			this.btnIONew.Location = new System.Drawing.Point(87, 208);
			this.btnIONew.Name = "btnIONew";
			this.btnIONew.Size = new System.Drawing.Size(75, 23);
			this.btnIONew.TabIndex = 7;
			this.btnIONew.Text = "Add as New";
			this.btnIONew.UseVisualStyleBackColor = true;
			// 
			// btnIOApply
			// 
			this.btnIOApply.Location = new System.Drawing.Point(8, 208);
			this.btnIOApply.Name = "btnIOApply";
			this.btnIOApply.Size = new System.Drawing.Size(75, 23);
			this.btnIOApply.TabIndex = 7;
			this.btnIOApply.Text = "Apply";
			this.btnIOApply.UseVisualStyleBackColor = true;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(6, 99);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(75, 20);
			this.label17.TabIndex = 3;
			this.label17.Text = "Long Desc.";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtIOLongDesc
			// 
			this.txtIOLongDesc.Location = new System.Drawing.Point(87, 99);
			this.txtIOLongDesc.Multiline = true;
			this.txtIOLongDesc.Name = "txtIOLongDesc";
			this.txtIOLongDesc.Size = new System.Drawing.Size(154, 103);
			this.txtIOLongDesc.TabIndex = 6;
			// 
			// txtIOName
			// 
			this.txtIOName.Location = new System.Drawing.Point(87, 46);
			this.txtIOName.Name = "txtIOName";
			this.txtIOName.Size = new System.Drawing.Size(154, 20);
			this.txtIOName.TabIndex = 4;
			// 
			// cmbIOChoose
			// 
			this.cmbIOChoose.FormattingEnabled = true;
			this.cmbIOChoose.Location = new System.Drawing.Point(87, 19);
			this.cmbIOChoose.Name = "cmbIOChoose";
			this.cmbIOChoose.Size = new System.Drawing.Size(154, 21);
			this.cmbIOChoose.TabIndex = 5;
			// 
			// cmbIOType
			// 
			this.cmbIOType.FormattingEnabled = true;
			this.cmbIOType.Items.AddRange(new object[] {
									"axis",
									"angle",
									"bool",
									"choices",
									"color255",
									"color1",
									"decal",
									"filterclass",
									"flags",
									"float",
									"integer",
									"material",
									"node_dest",
									"origin",
									"pointentityclass",
									"scene",
									"sidelist",
									"sound",
									"sprite",
									"string",
									"studio",
									"target_destination",
									"target_name_or_class",
									"target_source",
									"vecline",
									"vector",
									"void"});
			this.cmbIOType.Location = new System.Drawing.Point(87, 72);
			this.cmbIOType.Name = "cmbIOType";
			this.cmbIOType.Size = new System.Drawing.Size(154, 21);
			this.cmbIOType.TabIndex = 5;
			// 
			// lstIO
			// 
			this.lstIO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader11,
									this.columnHeader12,
									this.columnHeader13,
									this.columnHeader16});
			this.lstIO.Location = new System.Drawing.Point(6, 29);
			this.lstIO.Name = "lstIO";
			this.lstIO.Size = new System.Drawing.Size(362, 367);
			this.lstIO.TabIndex = 1;
			this.lstIO.UseCompatibleStateImageBehavior = false;
			this.lstIO.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "I/O";
			this.columnHeader11.Width = 52;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Name";
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Type";
			this.columnHeader13.Width = 58;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "Description";
			this.columnHeader16.Width = 158;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 3);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(624, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "Inputs and outputs are for Source games only. If you are editing a Goldsource FGD" +
			", leave this blank.";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.lstFlags);
			this.tabPage4.Controls.Add(this.groupBox8);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(636, 402);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Flags";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// lstFlags
			// 
			this.lstFlags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader14,
									this.columnHeader15,
									this.columnHeader17});
			this.lstFlags.Location = new System.Drawing.Point(6, 6);
			this.lstFlags.Name = "lstFlags";
			this.lstFlags.Size = new System.Drawing.Size(333, 390);
			this.lstFlags.TabIndex = 0;
			this.lstFlags.UseCompatibleStateImageBehavior = false;
			this.lstFlags.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Key";
			this.columnHeader14.Width = 93;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Name";
			this.columnHeader15.Width = 123;
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "On/Off";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.chkFlagsDefaultOn);
			this.groupBox8.Controls.Add(this.txtFlagsKey);
			this.groupBox8.Controls.Add(this.label16);
			this.groupBox8.Controls.Add(this.btnFlagsApply);
			this.groupBox8.Controls.Add(this.label18);
			this.groupBox8.Controls.Add(this.btnFlagsNew);
			this.groupBox8.Controls.Add(this.btnFlagsRemove);
			this.groupBox8.Controls.Add(this.txtFlagsName);
			this.groupBox8.Location = new System.Drawing.Point(345, 6);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(285, 128);
			this.groupBox8.TabIndex = 9;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Flags";
			// 
			// chkFlagsDefaultOn
			// 
			this.chkFlagsDefaultOn.Location = new System.Drawing.Point(59, 68);
			this.chkFlagsDefaultOn.Name = "chkFlagsDefaultOn";
			this.chkFlagsDefaultOn.Size = new System.Drawing.Size(104, 24);
			this.chkFlagsDefaultOn.TabIndex = 17;
			this.chkFlagsDefaultOn.Text = "Default On";
			this.chkFlagsDefaultOn.UseVisualStyleBackColor = true;
			// 
			// txtFlagsKey
			// 
			this.txtFlagsKey.Location = new System.Drawing.Point(59, 16);
			this.txtFlagsKey.Name = "txtFlagsKey";
			this.txtFlagsKey.Size = new System.Drawing.Size(216, 20);
			this.txtFlagsKey.TabIndex = 14;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(6, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(47, 20);
			this.label16.TabIndex = 12;
			this.label16.Text = "Key";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnFlagsApply
			// 
			this.btnFlagsApply.Location = new System.Drawing.Point(59, 98);
			this.btnFlagsApply.Name = "btnFlagsApply";
			this.btnFlagsApply.Size = new System.Drawing.Size(68, 22);
			this.btnFlagsApply.TabIndex = 15;
			this.btnFlagsApply.Text = "Apply";
			this.btnFlagsApply.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(6, 42);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(47, 20);
			this.label18.TabIndex = 11;
			this.label18.Text = "Name";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnFlagsNew
			// 
			this.btnFlagsNew.Location = new System.Drawing.Point(133, 98);
			this.btnFlagsNew.Name = "btnFlagsNew";
			this.btnFlagsNew.Size = new System.Drawing.Size(68, 23);
			this.btnFlagsNew.TabIndex = 16;
			this.btnFlagsNew.Text = "Add";
			this.btnFlagsNew.UseVisualStyleBackColor = true;
			// 
			// btnFlagsRemove
			// 
			this.btnFlagsRemove.Location = new System.Drawing.Point(207, 97);
			this.btnFlagsRemove.Name = "btnFlagsRemove";
			this.btnFlagsRemove.Size = new System.Drawing.Size(68, 23);
			this.btnFlagsRemove.TabIndex = 16;
			this.btnFlagsRemove.Text = "Remove";
			this.btnFlagsRemove.UseVisualStyleBackColor = true;
			// 
			// txtFlagsName
			// 
			this.txtFlagsName.Location = new System.Drawing.Point(59, 42);
			this.txtFlagsName.Name = "txtFlagsName";
			this.txtFlagsName.Size = new System.Drawing.Size(216, 20);
			this.txtFlagsName.TabIndex = 13;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.txtPreview);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(636, 402);
			this.tabPage5.TabIndex = 0;
			this.tabPage5.Text = "Preview";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// txtPreview
			// 
			this.txtPreview.BackColor = System.Drawing.SystemColors.Window;
			this.txtPreview.Location = new System.Drawing.Point(3, 3);
			this.txtPreview.Multiline = true;
			this.txtPreview.Name = "txtPreview";
			this.txtPreview.ReadOnly = true;
			this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtPreview.Size = new System.Drawing.Size(630, 396);
			this.txtPreview.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.btnMapSizeUnset);
			this.groupBox3.Controls.Add(this.btnMapSizeSet);
			this.groupBox3.Controls.Add(this.txtMapSizeLow);
			this.groupBox3.Controls.Add(this.txtMapSizeHigh);
			this.groupBox3.Controls.Add(this.btnIncludeRemove);
			this.groupBox3.Controls.Add(this.btnIncludeAdd);
			this.groupBox3.Controls.Add(this.txtIncludeAdd);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.lstIncludes);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Location = new System.Drawing.Point(12, 485);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(815, 95);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Additional Data";
			// 
			// btnMapSizeUnset
			// 
			this.btnMapSizeUnset.Location = new System.Drawing.Point(523, 68);
			this.btnMapSizeUnset.Name = "btnMapSizeUnset";
			this.btnMapSizeUnset.Size = new System.Drawing.Size(45, 21);
			this.btnMapSizeUnset.TabIndex = 8;
			this.btnMapSizeUnset.Text = "Unset";
			this.btnMapSizeUnset.UseVisualStyleBackColor = true;
			// 
			// btnMapSizeSet
			// 
			this.btnMapSizeSet.Location = new System.Drawing.Point(472, 68);
			this.btnMapSizeSet.Name = "btnMapSizeSet";
			this.btnMapSizeSet.Size = new System.Drawing.Size(45, 21);
			this.btnMapSizeSet.TabIndex = 8;
			this.btnMapSizeSet.Text = "Set";
			this.btnMapSizeSet.UseVisualStyleBackColor = true;
			// 
			// txtMapSizeLow
			// 
			this.txtMapSizeLow.Location = new System.Drawing.Point(472, 42);
			this.txtMapSizeLow.Name = "txtMapSizeLow";
			this.txtMapSizeLow.Size = new System.Drawing.Size(96, 20);
			this.txtMapSizeLow.TabIndex = 7;
			// 
			// txtMapSizeHigh
			// 
			this.txtMapSizeHigh.Location = new System.Drawing.Point(472, 16);
			this.txtMapSizeHigh.Name = "txtMapSizeHigh";
			this.txtMapSizeHigh.Size = new System.Drawing.Size(96, 20);
			this.txtMapSizeHigh.TabIndex = 7;
			// 
			// btnIncludeRemove
			// 
			this.btnIncludeRemove.Location = new System.Drawing.Point(256, 46);
			this.btnIncludeRemove.Name = "btnIncludeRemove";
			this.btnIncludeRemove.Size = new System.Drawing.Size(56, 21);
			this.btnIncludeRemove.TabIndex = 6;
			this.btnIncludeRemove.Text = "Remove";
			this.btnIncludeRemove.UseVisualStyleBackColor = true;
			this.btnIncludeRemove.Click += new System.EventHandler(this.BtnBaseClassRemoveClick);
			// 
			// btnIncludeAdd
			// 
			this.btnIncludeAdd.Location = new System.Drawing.Point(194, 46);
			this.btnIncludeAdd.Name = "btnIncludeAdd";
			this.btnIncludeAdd.Size = new System.Drawing.Size(56, 21);
			this.btnIncludeAdd.TabIndex = 6;
			this.btnIncludeAdd.Text = "Add";
			this.btnIncludeAdd.UseVisualStyleBackColor = true;
			this.btnIncludeAdd.Click += new System.EventHandler(this.BtnBaseClassAddClick);
			// 
			// txtIncludeAdd
			// 
			this.txtIncludeAdd.Location = new System.Drawing.Point(194, 20);
			this.txtIncludeAdd.Name = "txtIncludeAdd";
			this.txtIncludeAdd.Size = new System.Drawing.Size(118, 20);
			this.txtIncludeAdd.TabIndex = 4;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(384, 42);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(82, 20);
			this.label9.TabIndex = 3;
			this.label9.Text = "Map Size Low";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lstIncludes
			// 
			this.lstIncludes.FormattingEnabled = true;
			this.lstIncludes.Location = new System.Drawing.Point(68, 16);
			this.lstIncludes.Name = "lstIncludes";
			this.lstIncludes.Size = new System.Drawing.Size(120, 69);
			this.lstIncludes.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(384, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(82, 20);
			this.label8.TabIndex = 3;
			this.label8.Text = "Map Size High";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 20);
			this.label7.TabIndex = 3;
			this.label7.Text = "Includes";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FGDEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(839, 588);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbFilter);
			this.Controls.Add(this.lstClass);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FGDEditor";
			this.Text = "FGD Editor";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnPropRemove;
		private System.Windows.Forms.Button btnPropNew;
		private System.Windows.Forms.Button btnPropApply;
		private System.Windows.Forms.TextBox txtPropLongDesc;
		private System.Windows.Forms.ComboBox cmbPropType;
		private System.Windows.Forms.TextBox txtPropDefault;
		private System.Windows.Forms.TextBox txtPropShortDesc;
		private System.Windows.Forms.TextBox txtPropName;
		private System.Windows.Forms.ListView lstProperties;
		private System.Windows.Forms.TextBox txtFlagsName;
		private System.Windows.Forms.Button btnFlagsRemove;
		private System.Windows.Forms.Button btnFlagsNew;
		private System.Windows.Forms.Button btnFlagsApply;
		private System.Windows.Forms.TextBox txtFlagsKey;
		private System.Windows.Forms.CheckBox chkFlagsDefaultOn;
		private System.Windows.Forms.ListView lstFlags;
		private System.Windows.Forms.ListView lstIO;
		private System.Windows.Forms.ComboBox cmbIOType;
		private System.Windows.Forms.ComboBox cmbIOChoose;
		private System.Windows.Forms.TextBox txtIOName;
		private System.Windows.Forms.TextBox txtIOLongDesc;
		private System.Windows.Forms.Button btnIOApply;
		private System.Windows.Forms.Button btnIONew;
		private System.Windows.Forms.Button btnIORemove;
		private System.Windows.Forms.Button btnPropChoiceAdd;
		private System.Windows.Forms.Button btnPropChoiceRemove;
		private System.Windows.Forms.TextBox txtPropChoiceName;
		private System.Windows.Forms.TextBox txtPropChoiceKey;
		private System.Windows.Forms.ListView lstPropChoices;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button btnClassDescReset;
		private System.Windows.Forms.Button btnClassDescApply;
		private System.Windows.Forms.TextBox txtClassDescription;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtPreview;
		private System.Windows.Forms.ListBox lstIncludes;
		private System.Windows.Forms.TextBox txtIncludeAdd;
		private System.Windows.Forms.Button btnIncludeAdd;
		private System.Windows.Forms.Button btnIncludeRemove;
		private System.Windows.Forms.TextBox txtMapSizeHigh;
		private System.Windows.Forms.TextBox txtMapSizeLow;
		private System.Windows.Forms.Button btnMapSizeSet;
		private System.Windows.Forms.Button btnMapSizeUnset;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnBehaviourRemove;
		private System.Windows.Forms.ListView lstBehaviours;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ComboBox cmbBaseClassAdd;
		private System.Windows.Forms.ListBox lstBaseClasses;
		private System.Windows.Forms.Button btnBaseClassAdd;
		private System.Windows.Forms.Button btnBaseClassRemove;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbBehaviourType;
		private System.Windows.Forms.TextBox txtBehaviourValue;
		private System.Windows.Forms.Button btnBehaviourApply;
		private System.Windows.Forms.Button btnBehaviourNew;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ComboBox cmbFilter;
		private System.Windows.Forms.ListView lstClass;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
	}
}
