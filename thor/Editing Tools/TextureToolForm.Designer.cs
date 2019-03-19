/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 7/08/2009
 * Time: 5:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class TextureToolForm
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.nudScaleX = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nudScaleY = new System.Windows.Forms.NumericUpDown();
			this.nudShiftX = new System.Windows.Forms.NumericUpDown();
			this.nudShiftY = new System.Windows.Forms.NumericUpDown();
			this.nudRotation = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.nudLightmap = new System.Windows.Forms.NumericUpDown();
			this.btnJustifyLeft = new System.Windows.Forms.Button();
			this.btnJustifyRight = new System.Windows.Forms.Button();
			this.btnJustifyTop = new System.Windows.Forms.Button();
			this.btnJustifyBottom = new System.Windows.Forms.Button();
			this.btnJustifyCenter = new System.Windows.Forms.Button();
			this.lblDetails = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.btnReplace = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.tgSelected = new thor.TextureGridControl();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbLeftClick = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbRightClick = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnJustifyFit = new System.Windows.Forms.Button();
			this.chkTreatAsOne = new System.Windows.Forms.CheckBox();
			this.btnAlignWorld = new System.Windows.Forms.Button();
			this.btnAlignFace = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button12 = new System.Windows.Forms.Button();
			this.tgRecent = new thor.TextureGridControl();
			this.label9 = new System.Windows.Forms.Label();
			this.txtRecentFilter = new System.Windows.Forms.TextBox();
			this.chkHideMask = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.nudScaleX)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudScaleY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudShiftX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudShiftY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRotation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLightmap)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(25, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Scale";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudScaleX
			// 
			this.nudScaleX.DecimalPlaces = 4;
			this.nudScaleX.Increment = new decimal(new int[] {
									1,
									0,
									0,
									131072});
			this.nudScaleX.Location = new System.Drawing.Point(25, 30);
			this.nudScaleX.Maximum = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.nudScaleX.Minimum = new decimal(new int[] {
									100000,
									0,
									0,
									-2147483648});
			this.nudScaleX.Name = "nudScaleX";
			this.nudScaleX.Size = new System.Drawing.Size(57, 20);
			this.nudScaleX.TabIndex = 1;
			this.nudScaleX.Value = new decimal(new int[] {
									100,
									0,
									0,
									131072});
			this.nudScaleX.ValueChanged += new System.EventHandler(this.NudScaleXValueChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.nudScaleX, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.nudScaleY, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.nudShiftX, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.nudShiftY, 2, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(156, 80);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 25);
			this.label2.TabIndex = 2;
			this.label2.Text = "X";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 26);
			this.label3.TabIndex = 2;
			this.label3.Text = "Y";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(91, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 25);
			this.label4.TabIndex = 0;
			this.label4.Text = "Shift";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudScaleY
			// 
			this.nudScaleY.DecimalPlaces = 4;
			this.nudScaleY.Increment = new decimal(new int[] {
									1,
									0,
									0,
									131072});
			this.nudScaleY.Location = new System.Drawing.Point(25, 56);
			this.nudScaleY.Maximum = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.nudScaleY.Minimum = new decimal(new int[] {
									100000,
									0,
									0,
									-2147483648});
			this.nudScaleY.Name = "nudScaleY";
			this.nudScaleY.Size = new System.Drawing.Size(57, 20);
			this.nudScaleY.TabIndex = 1;
			this.nudScaleY.Value = new decimal(new int[] {
									100,
									0,
									0,
									131072});
			this.nudScaleY.ValueChanged += new System.EventHandler(this.NudScaleYValueChanged);
			// 
			// nudShiftX
			// 
			this.nudShiftX.Location = new System.Drawing.Point(91, 30);
			this.nudShiftX.Maximum = new decimal(new int[] {
									4096,
									0,
									0,
									0});
			this.nudShiftX.Minimum = new decimal(new int[] {
									4096,
									0,
									0,
									-2147483648});
			this.nudShiftX.Name = "nudShiftX";
			this.nudShiftX.Size = new System.Drawing.Size(58, 20);
			this.nudShiftX.TabIndex = 1;
			this.nudShiftX.Value = new decimal(new int[] {
									1,
									0,
									0,
									65536});
			this.nudShiftX.ValueChanged += new System.EventHandler(this.NudShiftXValueChanged);
			// 
			// nudShiftY
			// 
			this.nudShiftY.Location = new System.Drawing.Point(91, 56);
			this.nudShiftY.Maximum = new decimal(new int[] {
									4096,
									0,
									0,
									0});
			this.nudShiftY.Minimum = new decimal(new int[] {
									4096,
									0,
									0,
									-2147483648});
			this.nudShiftY.Name = "nudShiftY";
			this.nudShiftY.Size = new System.Drawing.Size(58, 20);
			this.nudShiftY.TabIndex = 1;
			this.nudShiftY.Value = new decimal(new int[] {
									1,
									0,
									0,
									65536});
			this.nudShiftY.ValueChanged += new System.EventHandler(this.NudShiftYValueChanged);
			// 
			// nudRotation
			// 
			this.nudRotation.BackColor = System.Drawing.SystemColors.Window;
			this.nudRotation.DecimalPlaces = 2;
			this.nudRotation.Location = new System.Drawing.Point(239, 17);
			this.nudRotation.Maximum = new decimal(new int[] {
									360,
									0,
									0,
									0});
			this.nudRotation.Minimum = new decimal(new int[] {
									360,
									0,
									0,
									-2147483648});
			this.nudRotation.Name = "nudRotation";
			this.nudRotation.Size = new System.Drawing.Size(57, 20);
			this.nudRotation.TabIndex = 1;
			this.nudRotation.ValueChanged += new System.EventHandler(this.NudRotationValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(174, 13);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 25);
			this.label5.TabIndex = 0;
			this.label5.Text = "Rotation";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(174, 38);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(59, 25);
			this.label8.TabIndex = 0;
			this.label8.Text = "Lightmap";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudLightmap
			// 
			this.nudLightmap.Enabled = false;
			this.nudLightmap.Location = new System.Drawing.Point(239, 43);
			this.nudLightmap.Maximum = new decimal(new int[] {
									512,
									0,
									0,
									0});
			this.nudLightmap.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.nudLightmap.Name = "nudLightmap";
			this.nudLightmap.Size = new System.Drawing.Size(58, 20);
			this.nudLightmap.TabIndex = 1;
			this.nudLightmap.Value = new decimal(new int[] {
									16,
									0,
									0,
									0});
			this.nudLightmap.ValueChanged += new System.EventHandler(this.NudLightmapValueChanged);
			// 
			// btnJustifyLeft
			// 
			this.btnJustifyLeft.Location = new System.Drawing.Point(16, 39);
			this.btnJustifyLeft.Name = "btnJustifyLeft";
			this.btnJustifyLeft.Size = new System.Drawing.Size(20, 20);
			this.btnJustifyLeft.TabIndex = 3;
			this.btnJustifyLeft.Text = "L";
			this.btnJustifyLeft.UseVisualStyleBackColor = true;
			this.btnJustifyLeft.Click += new System.EventHandler(this.JustifyClick);
			// 
			// btnJustifyRight
			// 
			this.btnJustifyRight.Location = new System.Drawing.Point(64, 39);
			this.btnJustifyRight.Name = "btnJustifyRight";
			this.btnJustifyRight.Size = new System.Drawing.Size(20, 20);
			this.btnJustifyRight.TabIndex = 3;
			this.btnJustifyRight.Text = "R";
			this.btnJustifyRight.UseVisualStyleBackColor = true;
			this.btnJustifyRight.Click += new System.EventHandler(this.JustifyClick);
			// 
			// btnJustifyTop
			// 
			this.btnJustifyTop.Location = new System.Drawing.Point(40, 15);
			this.btnJustifyTop.Name = "btnJustifyTop";
			this.btnJustifyTop.Size = new System.Drawing.Size(20, 20);
			this.btnJustifyTop.TabIndex = 3;
			this.btnJustifyTop.Text = "T";
			this.btnJustifyTop.UseVisualStyleBackColor = true;
			this.btnJustifyTop.Click += new System.EventHandler(this.JustifyClick);
			// 
			// btnJustifyBottom
			// 
			this.btnJustifyBottom.Location = new System.Drawing.Point(40, 63);
			this.btnJustifyBottom.Name = "btnJustifyBottom";
			this.btnJustifyBottom.Size = new System.Drawing.Size(20, 20);
			this.btnJustifyBottom.TabIndex = 3;
			this.btnJustifyBottom.Text = "B";
			this.btnJustifyBottom.UseVisualStyleBackColor = true;
			this.btnJustifyBottom.Click += new System.EventHandler(this.JustifyClick);
			// 
			// btnJustifyCenter
			// 
			this.btnJustifyCenter.Location = new System.Drawing.Point(40, 39);
			this.btnJustifyCenter.Name = "btnJustifyCenter";
			this.btnJustifyCenter.Size = new System.Drawing.Size(20, 20);
			this.btnJustifyCenter.TabIndex = 3;
			this.btnJustifyCenter.Text = "C";
			this.btnJustifyCenter.UseVisualStyleBackColor = true;
			this.btnJustifyCenter.Click += new System.EventHandler(this.JustifyClick);
			// 
			// lblDetails
			// 
			this.lblDetails.Location = new System.Drawing.Point(12, 152);
			this.lblDetails.Name = "lblDetails";
			this.lblDetails.Size = new System.Drawing.Size(156, 23);
			this.lblDetails.TabIndex = 5;
			this.lblDetails.Text = "TEXTURENAMEANDSIZE";
			this.lblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(12, 97);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 6;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
			// 
			// btnReplace
			// 
			this.btnReplace.Location = new System.Drawing.Point(12, 126);
			this.btnReplace.Name = "btnReplace";
			this.btnReplace.Size = new System.Drawing.Size(75, 23);
			this.btnReplace.TabIndex = 6;
			this.btnReplace.Text = "Replace...";
			this.btnReplace.UseVisualStyleBackColor = true;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(93, 97);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 52);
			this.btnApply.TabIndex = 6;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
			// 
			// tgSelected
			// 
			this.tgSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tgSelected.BackColor = System.Drawing.Color.Black;
			this.tgSelected.DrawSizes = true;
			this.tgSelected.Location = new System.Drawing.Point(12, 178);
			this.tgSelected.MinimumSize = new System.Drawing.Size(100, 100);
			this.tgSelected.Name = "tgSelected";
			this.tgSelected.SelectedTexture = null;
			this.tgSelected.Size = new System.Drawing.Size(285, 179);
			this.tgSelected.TabIndex = 0;
			this.tgSelected.ThumbSize = thor.TextureThumbnailSize.Thumb256;
			this.tgSelected.SelectedTextureChanged += new thor.SelectedTextureChangedEventHandler(this.TgSelectedSelectedTextureChanged);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.Location = new System.Drawing.Point(12, 363);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 21);
			this.label6.TabIndex = 7;
			this.label6.Text = "Left Click:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbLeftClick
			// 
			this.cmbLeftClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmbLeftClick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLeftClick.FormattingEnabled = true;
			this.cmbLeftClick.Items.AddRange(new object[] {
									"Lift and Select",
									"Lift",
									"Select"});
			this.cmbLeftClick.Location = new System.Drawing.Point(88, 363);
			this.cmbLeftClick.Name = "cmbLeftClick";
			this.cmbLeftClick.Size = new System.Drawing.Size(159, 21);
			this.cmbLeftClick.TabIndex = 8;
			this.cmbLeftClick.SelectedIndexChanged += new System.EventHandler(this.ModeChanged);
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label7.Location = new System.Drawing.Point(12, 390);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 21);
			this.label7.TabIndex = 7;
			this.label7.Text = "Right Click:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbRightClick
			// 
			this.cmbRightClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmbRightClick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRightClick.FormattingEnabled = true;
			this.cmbRightClick.Items.AddRange(new object[] {
									"Apply Texture",
									"Apply Texture and Values"});
			this.cmbRightClick.Location = new System.Drawing.Point(88, 390);
			this.cmbRightClick.Name = "cmbRightClick";
			this.cmbRightClick.Size = new System.Drawing.Size(159, 21);
			this.cmbRightClick.TabIndex = 8;
			this.cmbRightClick.SelectedIndexChanged += new System.EventHandler(this.ModeChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnJustifyTop);
			this.groupBox1.Controls.Add(this.btnJustifyFit);
			this.groupBox1.Controls.Add(this.chkTreatAsOne);
			this.groupBox1.Controls.Add(this.btnJustifyRight);
			this.groupBox1.Controls.Add(this.btnJustifyBottom);
			this.groupBox1.Controls.Add(this.btnJustifyCenter);
			this.groupBox1.Controls.Add(this.btnJustifyLeft);
			this.groupBox1.Location = new System.Drawing.Point(303, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(102, 137);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Justify";
			// 
			// btnJustifyFit
			// 
			this.btnJustifyFit.Location = new System.Drawing.Point(16, 87);
			this.btnJustifyFit.Name = "btnJustifyFit";
			this.btnJustifyFit.Size = new System.Drawing.Size(68, 20);
			this.btnJustifyFit.TabIndex = 4;
			this.btnJustifyFit.Text = "Fit";
			this.btnJustifyFit.UseVisualStyleBackColor = true;
			this.btnJustifyFit.Click += new System.EventHandler(this.JustifyClick);
			// 
			// chkTreatAsOne
			// 
			this.chkTreatAsOne.Location = new System.Drawing.Point(6, 113);
			this.chkTreatAsOne.Name = "chkTreatAsOne";
			this.chkTreatAsOne.Size = new System.Drawing.Size(90, 21);
			this.chkTreatAsOne.TabIndex = 5;
			this.chkTreatAsOne.Text = "Treat as One";
			this.chkTreatAsOne.UseVisualStyleBackColor = true;
			// 
			// btnAlignWorld
			// 
			this.btnAlignWorld.Location = new System.Drawing.Point(6, 19);
			this.btnAlignWorld.Name = "btnAlignWorld";
			this.btnAlignWorld.Size = new System.Drawing.Size(53, 20);
			this.btnAlignWorld.TabIndex = 4;
			this.btnAlignWorld.Text = "World";
			this.btnAlignWorld.UseVisualStyleBackColor = true;
			this.btnAlignWorld.Click += new System.EventHandler(this.BtnAlignWorldClick);
			// 
			// btnAlignFace
			// 
			this.btnAlignFace.Location = new System.Drawing.Point(65, 19);
			this.btnAlignFace.Name = "btnAlignFace";
			this.btnAlignFace.Size = new System.Drawing.Size(53, 20);
			this.btnAlignFace.TabIndex = 4;
			this.btnAlignFace.Text = "Face";
			this.btnAlignFace.UseVisualStyleBackColor = true;
			this.btnAlignFace.Click += new System.EventHandler(this.BtnAlignFaceClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnAlignWorld);
			this.groupBox2.Controls.Add(this.btnAlignFace);
			this.groupBox2.Location = new System.Drawing.Point(174, 97);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(122, 52);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Align";
			// 
			// button12
			// 
			this.button12.Enabled = false;
			this.button12.Location = new System.Drawing.Point(180, 69);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(117, 23);
			this.button12.TabIndex = 11;
			this.button12.Text = "Smoothing Groups";
			this.button12.UseVisualStyleBackColor = true;
			// 
			// tgRecent
			// 
			this.tgRecent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tgRecent.BackColor = System.Drawing.Color.Black;
			this.tgRecent.DrawSizes = true;
			this.tgRecent.Location = new System.Drawing.Point(303, 178);
			this.tgRecent.MinimumSize = new System.Drawing.Size(100, 100);
			this.tgRecent.Name = "tgRecent";
			this.tgRecent.SelectedTexture = null;
			this.tgRecent.Size = new System.Drawing.Size(102, 179);
			this.tgRecent.SortTextures = false;
			this.tgRecent.TabIndex = 0;
			this.tgRecent.ThumbSize = thor.TextureThumbnailSize.Thumb64;
			this.tgRecent.SelectedTextureChanged += new thor.SelectedTextureChangedEventHandler(this.TgRecentSelectedTextureChanged);
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.Location = new System.Drawing.Point(303, 360);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(102, 24);
			this.label9.TabIndex = 12;
			this.label9.Text = "Filter Recent:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtRecentFilter
			// 
			this.txtRecentFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRecentFilter.Location = new System.Drawing.Point(303, 390);
			this.txtRecentFilter.Name = "txtRecentFilter";
			this.txtRecentFilter.Size = new System.Drawing.Size(100, 20);
			this.txtRecentFilter.TabIndex = 13;
			this.txtRecentFilter.TextChanged += new System.EventHandler(this.TxtRecentFilterTextChanged);
			// 
			// chkHideMask
			// 
			this.chkHideMask.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkHideMask.Location = new System.Drawing.Point(303, 152);
			this.chkHideMask.Name = "chkHideMask";
			this.chkHideMask.Size = new System.Drawing.Size(102, 23);
			this.chkHideMask.TabIndex = 14;
			this.chkHideMask.Text = "Hide Mask";
			this.chkHideMask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.chkHideMask.UseVisualStyleBackColor = true;
			this.chkHideMask.CheckedChanged += new System.EventHandler(this.ChkHideMaskCheckedChanged);
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(253, 363);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(20, 21);
			this.label10.TabIndex = 15;
			this.label10.Text = "?";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.label10, "Left Click Shortcuts:\r\nShift: Select all faces on a brush\r\nCtrl: Select multiple " +
						"faces\r\nShift+Ctrl: Invert selected faces on brush");
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(253, 390);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(20, 21);
			this.label11.TabIndex = 15;
			this.label11.Text = "?";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.label11, "Right Click Shortcuts:\r\nShift: Apply texture to all faces on a brush\r\nAlt: Apply " +
						"texture with alignment to last selected face\r\nShift+Alt: Apply with alignment to" +
						" all faces on a brush");
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 200;
			this.toolTip1.IsBalloon = true;
			this.toolTip1.ReshowDelay = 100;
			// 
			// TextureToolForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(417, 420);
			this.ControlBox = false;
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.chkHideMask);
			this.Controls.Add(this.txtRecentFilter);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmbRightClick);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cmbLeftClick);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tgRecent);
			this.Controls.Add(this.tgSelected);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.nudRotation);
			this.Controls.Add(this.btnReplace);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblDetails);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.nudLightmap);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "TextureToolForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Face Edit Dialog";
			((System.ComponentModel.ISupportInitialize)(this.nudScaleX)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudScaleY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudShiftX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudShiftY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRotation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLightmap)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnJustifyLeft;
		private System.Windows.Forms.Button btnJustifyTop;
		private System.Windows.Forms.Button btnJustifyBottom;
		private System.Windows.Forms.Button btnJustifyCenter;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button btnReplace;
		private System.Windows.Forms.Button btnJustifyFit;
		private System.Windows.Forms.CheckBox chkTreatAsOne;
		private System.Windows.Forms.Button btnAlignWorld;
		private System.Windows.Forms.Button btnAlignFace;
		private System.Windows.Forms.CheckBox chkHideMask;
		private System.Windows.Forms.Button btnJustifyRight;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtRecentFilter;
		private System.Windows.Forms.Label label9;
		private thor.TextureGridControl tgSelected;
		private thor.TextureGridControl tgRecent;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblDetails;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbLeftClick;
		private System.Windows.Forms.ComboBox cmbRightClick;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown nudScaleX;
		private System.Windows.Forms.NumericUpDown nudScaleY;
		private System.Windows.Forms.NumericUpDown nudShiftX;
		private System.Windows.Forms.NumericUpDown nudShiftY;
		private System.Windows.Forms.NumericUpDown nudRotation;
		private System.Windows.Forms.NumericUpDown nudLightmap;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
	}
}
