/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 10/09/2008
 * Time: 7:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class SettingsForm
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("WON Goldsource");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Steam Goldsource");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Source");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Goldsource");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Source");
			this.tbcSettings = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.tab2DViews = new System.Windows.Forms.TabPage();
			this.o_2DNudge = new System.Windows.Forms.CheckBox();
			this.o_2DNudgeDistance = new System.Windows.Forms.NumericUpDown();
			this.o_2DCrosshair = new System.Windows.Forms.CheckBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.o_RotationSnapStyle_3 = new System.Windows.Forms.RadioButton();
			this.o_RotationSnapStyle_1 = new System.Windows.Forms.RadioButton();
			this.o_RotationSnapStyle_2 = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.o_col_2DHighlight2Colour = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.o_col_2DBackgroundColour = new System.Windows.Forms.Panel();
			this.o_col_2DBoundaryColour = new System.Windows.Forms.Panel();
			this.o_col_2DZeroAxisColour = new System.Windows.Forms.Panel();
			this.label19 = new System.Windows.Forms.Label();
			this.o_Highlight1On = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.o_Highlight2On = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.o_col_2DHighlight1Colour = new System.Windows.Forms.Panel();
			this.o_col_2DGridColour = new System.Windows.Forms.Panel();
			this.o_Highlight1Distance = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.o_GridSnapStyle_1 = new System.Windows.Forms.RadioButton();
			this.o_GridSnapStyle_2 = new System.Windows.Forms.RadioButton();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.o_HideGridLimit = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.o_HideGridFactor = new System.Windows.Forms.DomainUpDown();
			this.o_DefaultGridSize = new System.Windows.Forms.DomainUpDown();
			this.tab3DViews = new System.Windows.Forms.TabPage();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.o_3DInvertX = new System.Windows.Forms.CheckBox();
			this.o_3DInvertY = new System.Windows.Forms.CheckBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.o_3DTimeToTopSpeed = new System.Windows.Forms.TrackBar();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.o_3DForwardSpeed = new System.Windows.Forms.TrackBar();
			this.label15 = new System.Windows.Forms.Label();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.o_3DBackClippingPane = new System.Windows.Forms.TrackBar();
			this.label16 = new System.Windows.Forms.Label();
			this.tabGame = new System.Windows.Forms.TabPage();
			this.tabGameSubTabs = new System.Windows.Forms.TabControl();
			this.tabConfigDirectories = new System.Windows.Forms.TabPage();
			this.btnGameChangeName = new System.Windows.Forms.Button();
			this.grpConfigGame = new System.Windows.Forms.GroupBox();
			this.txtGameWONDir = new System.Windows.Forms.TextBox();
			this.lblGameWONDir = new System.Windows.Forms.Label();
			this.btnGameDirBrowse = new System.Windows.Forms.Button();
			this.lblGameSteamDir = new System.Windows.Forms.Label();
			this.cmbGameSteamDir = new System.Windows.Forms.ComboBox();
			this.lblGameMod = new System.Windows.Forms.Label();
			this.cmbGameMod = new System.Windows.Forms.ComboBox();
			this.lblGameName = new System.Windows.Forms.Label();
			this.cmbGameBuild = new System.Windows.Forms.ComboBox();
			this.grpConfigSaving = new System.Windows.Forms.GroupBox();
			this.lblGameMapSaveDir = new System.Windows.Forms.Label();
			this.chkGameEnableAutosave = new System.Windows.Forms.CheckBox();
			this.txtGameMapDir = new System.Windows.Forms.TextBox();
			this.btnGameMapDirBrowse = new System.Windows.Forms.Button();
			this.txtGameAutosaveDir = new System.Windows.Forms.TextBox();
			this.lblGameAutosaveDir = new System.Windows.Forms.Label();
			this.btnGameAutosaveDirBrowse = new System.Windows.Forms.Button();
			this.chkGameMapDiffAutosaveDir = new System.Windows.Forms.CheckBox();
			this.lblGameBuild = new System.Windows.Forms.Label();
			this.txtGameName = new System.Windows.Forms.TextBox();
			this.cmbGameEngine = new System.Windows.Forms.ComboBox();
			this.lblGameEngine = new System.Windows.Forms.Label();
			this.tabConfigEntities = new System.Windows.Forms.TabPage();
			this.lblGameFGD = new System.Windows.Forms.Label();
			this.btnGameAddFGD = new System.Windows.Forms.Button();
			this.lblConfigBrushEnt = new System.Windows.Forms.Label();
			this.btnGameRemoveFGD = new System.Windows.Forms.Button();
			this.lblConfigPointEnt = new System.Windows.Forms.Label();
			this.lstGameFGD = new System.Windows.Forms.ListBox();
			this.cmbGameBrushEnt = new System.Windows.Forms.ComboBox();
			this.cmbGamePointEnt = new System.Windows.Forms.ComboBox();
			this.tabConfigTextures = new System.Windows.Forms.TabPage();
			this.lblGameWAD = new System.Windows.Forms.Label();
			this.nudGameLightmapScale = new System.Windows.Forms.NumericUpDown();
			this.lblConfigLightmapScale = new System.Windows.Forms.Label();
			this.btnGameAddWAD = new System.Windows.Forms.Button();
			this.nudGameTextureScale = new System.Windows.Forms.NumericUpDown();
			this.lstGameWAD = new System.Windows.Forms.ListBox();
			this.lblConfigTextureScale = new System.Windows.Forms.Label();
			this.btnGameRemoveWAD = new System.Windows.Forms.Button();
			this.tree_games = new System.Windows.Forms.TreeView();
			this.btnGameRemove = new System.Windows.Forms.Button();
			this.btnGameAdd = new System.Windows.Forms.Button();
			this.tabBuild = new System.Windows.Forms.TabPage();
			this.tabBuildSubTabs = new System.Windows.Forms.TabControl();
			this.tabBuildGeneral = new System.Windows.Forms.TabPage();
			this.btnBuildChangeName = new System.Windows.Forms.Button();
			this.lblBuildName = new System.Windows.Forms.Label();
			this.txtBuildName = new System.Windows.Forms.TextBox();
			this.lblBuildEngine = new System.Windows.Forms.Label();
			this.cmbBuildEngine = new System.Windows.Forms.ComboBox();
			this.tabBuildExecutables = new System.Windows.Forms.TabPage();
			this.lstBuildPresets = new System.Windows.Forms.ListBox();
			this.lblBuildExeFolder = new System.Windows.Forms.Label();
			this.lblBuildBSP = new System.Windows.Forms.Label();
			this.txtBuildExeFolder = new System.Windows.Forms.TextBox();
			this.lblBuildCSG = new System.Windows.Forms.Label();
			this.cmbBuildRAD = new System.Windows.Forms.ComboBox();
			this.cmbBuildBSP = new System.Windows.Forms.ComboBox();
			this.lblBuildDetectedPresets = new System.Windows.Forms.Label();
			this.lblBuildVIS = new System.Windows.Forms.Label();
			this.cmbBuildVIS = new System.Windows.Forms.ComboBox();
			this.cmbBuildCSG = new System.Windows.Forms.ComboBox();
			this.lblBuildRAD = new System.Windows.Forms.Label();
			this.btnBuildExeFolderBrowse = new System.Windows.Forms.Button();
			this.tabBuildPostCompile = new System.Windows.Forms.TabPage();
			this.lblBuildCommandLine = new System.Windows.Forms.Label();
			this.chkBuildCopyBSP = new System.Windows.Forms.CheckBox();
			this.chkBuildAskBeforeRun = new System.Windows.Forms.CheckBox();
			this.radBuildRunGame = new System.Windows.Forms.RadioButton();
			this.txtBuildCommandLine = new System.Windows.Forms.TextBox();
			this.radBuildRunGameOnChange = new System.Windows.Forms.RadioButton();
			this.chkBuildShowLog = new System.Windows.Forms.CheckBox();
			this.radBuildDontRunGame = new System.Windows.Forms.RadioButton();
			this.tabBuildAdvanced = new System.Windows.Forms.TabPage();
			this.tabBuildAdvancedSubTabs = new System.Windows.Forms.TabControl();
			this.tabBuildAdvancedCSG = new System.Windows.Forms.TabPage();
			this.label20 = new System.Windows.Forms.Label();
			this.buildValueCheckbox9 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox6 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox8 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox13 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox12 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox10 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox5 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox7 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox4 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox3 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox11 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox2 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox14 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox1 = new thor.BuildValueCheckbox();
			this.tabBuildAdvancedBSP = new System.Windows.Forms.TabPage();
			this.buildValueCheckbox26 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox21 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox20 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox19 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox18 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox17 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox16 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox15 = new thor.BuildValueCheckbox();
			this.tabBuildAdvancedVIS = new System.Windows.Forms.TabPage();
			this.buildValueCheckbox23 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox24 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox22 = new thor.BuildValueCheckbox();
			this.tabBuildAdvancedRAD = new System.Windows.Forms.TabPage();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.buildValueCheckbox44 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox45 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox46 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox56 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox47 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox54 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox52 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox50 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox48 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox53 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox51 = new thor.BuildValueCheckbox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buildValueCheckbox25 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox28 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox38 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox35 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox37 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox29 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox33 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox68 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox31 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox34 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox49 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox27 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox30 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox32 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox36 = new thor.BuildValueCheckbox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buildValueCheckbox39 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox41 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox40 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox42 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox43 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox57 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox55 = new thor.BuildValueCheckbox();
			this.tabBuildAdvancedShared = new System.Windows.Forms.TabPage();
			this.buildValueCheckbox67 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox62 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox66 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox61 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox65 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox60 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox64 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox59 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox63 = new thor.BuildValueCheckbox();
			this.buildValueCheckbox58 = new thor.BuildValueCheckbox();
			this.tabBuildAdvancedPreview = new System.Windows.Forms.TabPage();
			this.txtBuildAdvancedPreview = new System.Windows.Forms.TextBox();
			this.lblBuildTEMPAdvancedConfig = new System.Windows.Forms.Label();
			this.btnBuildRemove = new System.Windows.Forms.Button();
			this.btnBuildAdd = new System.Windows.Forms.Button();
			this.tree_builds = new System.Windows.Forms.TreeView();
			this.tabSteam = new System.Windows.Forms.TabPage();
			this.o_SteamInstallDir = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.btnSteamInstallDirBrowse = new System.Windows.Forms.Button();
			this.o_SteamUsername = new System.Windows.Forms.ComboBox();
			this.tabHotkeys = new System.Windows.Forms.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.chKey = new System.Windows.Forms.ColumnHeader();
			this.ckKeyCombo = new System.Windows.Forms.ColumnHeader();
			this.chTrigger = new System.Windows.Forms.ColumnHeader();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.trackBar3 = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.lblConfigSteamDir = new System.Windows.Forms.Label();
			this.btnConfigListSteamGames = new System.Windows.Forms.Button();
			this.btnConfigSteamDirBrowse = new System.Windows.Forms.Button();
			this.cmbConfigSteamUser = new System.Windows.Forms.ComboBox();
			this.lblConfigSteamUser = new System.Windows.Forms.Label();
			this.btnCancelSettings = new System.Windows.Forms.Button();
			this.btnApplyAndCloseSettings = new System.Windows.Forms.Button();
			this.btnApplySettings = new System.Windows.Forms.Button();
			this.tbcSettings.SuspendLayout();
			this.tab2DViews.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.o_2DNudgeDistance)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.o_Highlight1Distance)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.o_HideGridLimit)).BeginInit();
			this.tab3DViews.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.o_3DTimeToTopSpeed)).BeginInit();
			this.groupBox13.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.o_3DForwardSpeed)).BeginInit();
			this.groupBox14.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.o_3DBackClippingPane)).BeginInit();
			this.tabGame.SuspendLayout();
			this.tabGameSubTabs.SuspendLayout();
			this.tabConfigDirectories.SuspendLayout();
			this.grpConfigGame.SuspendLayout();
			this.grpConfigSaving.SuspendLayout();
			this.tabConfigEntities.SuspendLayout();
			this.tabConfigTextures.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudGameLightmapScale)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudGameTextureScale)).BeginInit();
			this.tabBuild.SuspendLayout();
			this.tabBuildSubTabs.SuspendLayout();
			this.tabBuildGeneral.SuspendLayout();
			this.tabBuildExecutables.SuspendLayout();
			this.tabBuildPostCompile.SuspendLayout();
			this.tabBuildAdvanced.SuspendLayout();
			this.tabBuildAdvancedSubTabs.SuspendLayout();
			this.tabBuildAdvancedCSG.SuspendLayout();
			this.tabBuildAdvancedBSP.SuspendLayout();
			this.tabBuildAdvancedVIS.SuspendLayout();
			this.tabBuildAdvancedRAD.SuspendLayout();
			this.groupBox15.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabBuildAdvancedShared.SuspendLayout();
			this.tabBuildAdvancedPreview.SuspendLayout();
			this.tabSteam.SuspendLayout();
			this.tabHotkeys.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
			this.groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// tbcSettings
			// 
			this.tbcSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tbcSettings.Controls.Add(this.tabGeneral);
			this.tbcSettings.Controls.Add(this.tab2DViews);
			this.tbcSettings.Controls.Add(this.tab3DViews);
			this.tbcSettings.Controls.Add(this.tabGame);
			this.tbcSettings.Controls.Add(this.tabBuild);
			this.tbcSettings.Controls.Add(this.tabSteam);
			this.tbcSettings.Controls.Add(this.tabHotkeys);
			this.tbcSettings.Location = new System.Drawing.Point(12, 12);
			this.tbcSettings.Name = "tbcSettings";
			this.tbcSettings.SelectedIndex = 0;
			this.tbcSettings.Size = new System.Drawing.Size(744, 537);
			this.tbcSettings.TabIndex = 0;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(736, 511);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "General";
			this.tabGeneral.UseVisualStyleBackColor = true;
			// 
			// tab2DViews
			// 
			this.tab2DViews.Controls.Add(this.o_2DNudge);
			this.tab2DViews.Controls.Add(this.o_2DNudgeDistance);
			this.tab2DViews.Controls.Add(this.o_2DCrosshair);
			this.tab2DViews.Controls.Add(this.groupBox6);
			this.tab2DViews.Controls.Add(this.groupBox3);
			this.tab2DViews.Controls.Add(this.label2);
			this.tab2DViews.Controls.Add(this.groupBox4);
			this.tab2DViews.Controls.Add(this.groupBox5);
			this.tab2DViews.Location = new System.Drawing.Point(4, 22);
			this.tab2DViews.Name = "tab2DViews";
			this.tab2DViews.Padding = new System.Windows.Forms.Padding(3);
			this.tab2DViews.Size = new System.Drawing.Size(736, 511);
			this.tab2DViews.TabIndex = 1;
			this.tab2DViews.Text = "2D Views";
			this.tab2DViews.UseVisualStyleBackColor = true;
			// 
			// o_2DNudge
			// 
			this.o_2DNudge.Checked = true;
			this.o_2DNudge.CheckState = System.Windows.Forms.CheckState.Checked;
			this.o_2DNudge.Location = new System.Drawing.Point(6, 30);
			this.o_2DNudge.Name = "o_2DNudge";
			this.o_2DNudge.Size = new System.Drawing.Size(126, 24);
			this.o_2DNudge.TabIndex = 0;
			this.o_2DNudge.Text = "Arrow keys nudge by";
			this.o_2DNudge.UseVisualStyleBackColor = true;
			// 
			// o_2DNudgeDistance
			// 
			this.o_2DNudgeDistance.Location = new System.Drawing.Point(132, 31);
			this.o_2DNudgeDistance.Maximum = new decimal(new int[] {
									10,
									0,
									0,
									0});
			this.o_2DNudgeDistance.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.o_2DNudgeDistance.Name = "o_2DNudgeDistance";
			this.o_2DNudgeDistance.Size = new System.Drawing.Size(34, 20);
			this.o_2DNudgeDistance.TabIndex = 2;
			this.o_2DNudgeDistance.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// o_2DCrosshair
			// 
			this.o_2DCrosshair.Location = new System.Drawing.Point(6, 6);
			this.o_2DCrosshair.Name = "o_2DCrosshair";
			this.o_2DCrosshair.Size = new System.Drawing.Size(225, 24);
			this.o_2DCrosshair.TabIndex = 0;
			this.o_2DCrosshair.Text = "Crosshair cursor in 2D views";
			this.o_2DCrosshair.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.o_RotationSnapStyle_3);
			this.groupBox6.Controls.Add(this.o_RotationSnapStyle_1);
			this.groupBox6.Controls.Add(this.o_RotationSnapStyle_2);
			this.groupBox6.Location = new System.Drawing.Point(6, 60);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(247, 114);
			this.groupBox6.TabIndex = 0;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Rotation Style";
			// 
			// o_RotationSnapStyle_3
			// 
			this.o_RotationSnapStyle_3.Location = new System.Drawing.Point(14, 79);
			this.o_RotationSnapStyle_3.Name = "o_RotationSnapStyle_3";
			this.o_RotationSnapStyle_3.Size = new System.Drawing.Size(137, 24);
			this.o_RotationSnapStyle_3.TabIndex = 2;
			this.o_RotationSnapStyle_3.Text = "No rotational snapping";
			this.o_RotationSnapStyle_3.UseVisualStyleBackColor = true;
			// 
			// o_RotationSnapStyle_1
			// 
			this.o_RotationSnapStyle_1.Checked = true;
			this.o_RotationSnapStyle_1.Location = new System.Drawing.Point(14, 19);
			this.o_RotationSnapStyle_1.Name = "o_RotationSnapStyle_1";
			this.o_RotationSnapStyle_1.Size = new System.Drawing.Size(182, 24);
			this.o_RotationSnapStyle_1.TabIndex = 2;
			this.o_RotationSnapStyle_1.TabStop = true;
			this.o_RotationSnapStyle_1.Text = "Press shift to snap to 15 degrees";
			this.o_RotationSnapStyle_1.UseVisualStyleBackColor = true;
			// 
			// o_RotationSnapStyle_2
			// 
			this.o_RotationSnapStyle_2.Location = new System.Drawing.Point(14, 49);
			this.o_RotationSnapStyle_2.Name = "o_RotationSnapStyle_2";
			this.o_RotationSnapStyle_2.Size = new System.Drawing.Size(230, 24);
			this.o_RotationSnapStyle_2.TabIndex = 2;
			this.o_RotationSnapStyle_2.Text = "Snap to 15 degrees unless shift is pressed";
			this.o_RotationSnapStyle_2.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.o_col_2DHighlight2Colour);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.o_col_2DBackgroundColour);
			this.groupBox3.Controls.Add(this.o_col_2DBoundaryColour);
			this.groupBox3.Controls.Add(this.o_col_2DZeroAxisColour);
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Controls.Add(this.o_Highlight1On);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.o_Highlight2On);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.o_col_2DHighlight1Colour);
			this.groupBox3.Controls.Add(this.o_col_2DGridColour);
			this.groupBox3.Controls.Add(this.o_Highlight1Distance);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Location = new System.Drawing.Point(6, 271);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(409, 178);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Grid Colour Settings";
			// 
			// o_col_2DHighlight2Colour
			// 
			this.o_col_2DHighlight2Colour.BackColor = System.Drawing.Color.DarkRed;
			this.o_col_2DHighlight2Colour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.o_col_2DHighlight2Colour.Location = new System.Drawing.Point(94, 139);
			this.o_col_2DHighlight2Colour.Name = "o_col_2DHighlight2Colour";
			this.o_col_2DHighlight2Colour.Size = new System.Drawing.Size(51, 17);
			this.o_col_2DHighlight2Colour.TabIndex = 2;
			this.o_col_2DHighlight2Colour.Click += new System.EventHandler(this.panelChangeBGColour);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(14, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 17);
			this.label6.TabIndex = 1;
			this.label6.Text = "Background:";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(14, 139);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(74, 17);
			this.label9.TabIndex = 1;
			this.label9.Text = "Highlight 2:";
			// 
			// o_col_2DBackgroundColour
			// 
			this.o_col_2DBackgroundColour.BackColor = System.Drawing.Color.Black;
			this.o_col_2DBackgroundColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.o_col_2DBackgroundColour.Location = new System.Drawing.Point(94, 24);
			this.o_col_2DBackgroundColour.Name = "o_col_2DBackgroundColour";
			this.o_col_2DBackgroundColour.Size = new System.Drawing.Size(51, 17);
			this.o_col_2DBackgroundColour.TabIndex = 2;
			this.o_col_2DBackgroundColour.Click += new System.EventHandler(this.panelChangeBGColour);
			// 
			// o_col_2DBoundaryColour
			// 
			this.o_col_2DBoundaryColour.BackColor = System.Drawing.Color.Red;
			this.o_col_2DBoundaryColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.o_col_2DBoundaryColour.Location = new System.Drawing.Point(94, 93);
			this.o_col_2DBoundaryColour.Name = "o_col_2DBoundaryColour";
			this.o_col_2DBoundaryColour.Size = new System.Drawing.Size(51, 17);
			this.o_col_2DBoundaryColour.TabIndex = 2;
			this.o_col_2DBoundaryColour.Click += new System.EventHandler(this.panelChangeBGColour);
			// 
			// o_col_2DZeroAxisColour
			// 
			this.o_col_2DZeroAxisColour.BackColor = System.Drawing.Color.Aqua;
			this.o_col_2DZeroAxisColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.o_col_2DZeroAxisColour.Location = new System.Drawing.Point(94, 70);
			this.o_col_2DZeroAxisColour.Name = "o_col_2DZeroAxisColour";
			this.o_col_2DZeroAxisColour.Size = new System.Drawing.Size(51, 17);
			this.o_col_2DZeroAxisColour.TabIndex = 2;
			this.o_col_2DZeroAxisColour.Click += new System.EventHandler(this.panelChangeBGColour);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(14, 93);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(74, 17);
			this.label19.TabIndex = 1;
			this.label19.Text = "Boundaries:";
			// 
			// o_Highlight1On
			// 
			this.o_Highlight1On.Checked = true;
			this.o_Highlight1On.CheckState = System.Windows.Forms.CheckState.Checked;
			this.o_Highlight1On.Location = new System.Drawing.Point(149, 117);
			this.o_Highlight1On.Name = "o_Highlight1On";
			this.o_Highlight1On.Size = new System.Drawing.Size(98, 17);
			this.o_Highlight1On.TabIndex = 0;
			this.o_Highlight1On.Text = "Highlight every";
			this.o_Highlight1On.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(14, 70);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(74, 17);
			this.label10.TabIndex = 1;
			this.label10.Text = "Zero Axes:";
			// 
			// o_Highlight2On
			// 
			this.o_Highlight2On.Checked = true;
			this.o_Highlight2On.CheckState = System.Windows.Forms.CheckState.Checked;
			this.o_Highlight2On.Location = new System.Drawing.Point(149, 139);
			this.o_Highlight2On.Name = "o_Highlight2On";
			this.o_Highlight2On.Size = new System.Drawing.Size(170, 17);
			this.o_Highlight2On.TabIndex = 0;
			this.o_Highlight2On.Text = "Highlight every 1024 units";
			this.o_Highlight2On.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(286, 118);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(53, 17);
			this.label11.TabIndex = 3;
			this.label11.Text = "grid lines";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(14, 47);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(74, 17);
			this.label7.TabIndex = 1;
			this.label7.Text = "Grid:";
			// 
			// o_col_2DHighlight1Colour
			// 
			this.o_col_2DHighlight1Colour.BackColor = System.Drawing.Color.White;
			this.o_col_2DHighlight1Colour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.o_col_2DHighlight1Colour.Location = new System.Drawing.Point(94, 116);
			this.o_col_2DHighlight1Colour.Name = "o_col_2DHighlight1Colour";
			this.o_col_2DHighlight1Colour.Size = new System.Drawing.Size(51, 17);
			this.o_col_2DHighlight1Colour.TabIndex = 2;
			this.o_col_2DHighlight1Colour.Click += new System.EventHandler(this.panelChangeBGColour);
			// 
			// o_col_2DGridColour
			// 
			this.o_col_2DGridColour.BackColor = System.Drawing.Color.Gainsboro;
			this.o_col_2DGridColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.o_col_2DGridColour.Location = new System.Drawing.Point(94, 47);
			this.o_col_2DGridColour.Name = "o_col_2DGridColour";
			this.o_col_2DGridColour.Size = new System.Drawing.Size(51, 17);
			this.o_col_2DGridColour.TabIndex = 2;
			this.o_col_2DGridColour.Click += new System.EventHandler(this.panelChangeBGColour);
			// 
			// o_Highlight1Distance
			// 
			this.o_Highlight1Distance.Location = new System.Drawing.Point(249, 114);
			this.o_Highlight1Distance.Maximum = new decimal(new int[] {
									32,
									0,
									0,
									0});
			this.o_Highlight1Distance.Minimum = new decimal(new int[] {
									2,
									0,
									0,
									0});
			this.o_Highlight1Distance.Name = "o_Highlight1Distance";
			this.o_Highlight1Distance.Size = new System.Drawing.Size(34, 20);
			this.o_Highlight1Distance.TabIndex = 2;
			this.o_Highlight1Distance.Value = new decimal(new int[] {
									8,
									0,
									0,
									0});
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(14, 116);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(74, 17);
			this.label8.TabIndex = 1;
			this.label8.Text = "Highlight 1:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(170, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "unit(s)";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.o_GridSnapStyle_1);
			this.groupBox4.Controls.Add(this.o_GridSnapStyle_2);
			this.groupBox4.Location = new System.Drawing.Point(259, 60);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(247, 114);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Snap to Grid";
			// 
			// o_GridSnapStyle_1
			// 
			this.o_GridSnapStyle_1.Checked = true;
			this.o_GridSnapStyle_1.Location = new System.Drawing.Point(14, 19);
			this.o_GridSnapStyle_1.Name = "o_GridSnapStyle_1";
			this.o_GridSnapStyle_1.Size = new System.Drawing.Size(182, 24);
			this.o_GridSnapStyle_1.TabIndex = 2;
			this.o_GridSnapStyle_1.TabStop = true;
			this.o_GridSnapStyle_1.Text = "Hold alt to ignore snapping";
			this.o_GridSnapStyle_1.UseVisualStyleBackColor = true;
			// 
			// o_GridSnapStyle_2
			// 
			this.o_GridSnapStyle_2.Location = new System.Drawing.Point(14, 49);
			this.o_GridSnapStyle_2.Name = "o_GridSnapStyle_2";
			this.o_GridSnapStyle_2.Size = new System.Drawing.Size(213, 24);
			this.o_GridSnapStyle_2.TabIndex = 2;
			this.o_GridSnapStyle_2.Text = "Ignore snapping unless alt is pressed";
			this.o_GridSnapStyle_2.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.o_HideGridLimit);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.label13);
			this.groupBox5.Controls.Add(this.o_HideGridFactor);
			this.groupBox5.Controls.Add(this.o_DefaultGridSize);
			this.groupBox5.Location = new System.Drawing.Point(6, 180);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(409, 85);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Grid Settings";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Default grid size:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// o_HideGridLimit
			// 
			this.o_HideGridLimit.Location = new System.Drawing.Point(127, 54);
			this.o_HideGridLimit.Maximum = new decimal(new int[] {
									10,
									0,
									0,
									0});
			this.o_HideGridLimit.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.o_HideGridLimit.Name = "o_HideGridLimit";
			this.o_HideGridLimit.Size = new System.Drawing.Size(34, 20);
			this.o_HideGridLimit.TabIndex = 2;
			this.o_HideGridLimit.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(14, 54);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(113, 20);
			this.label12.TabIndex = 3;
			this.label12.Text = "Hide grid smaller than";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(167, 54);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(110, 20);
			this.label13.TabIndex = 3;
			this.label13.Text = "pixel(s), by a factor of";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// o_HideGridFactor
			// 
			this.o_HideGridFactor.Items.Add("64");
			this.o_HideGridFactor.Items.Add("32");
			this.o_HideGridFactor.Items.Add("16");
			this.o_HideGridFactor.Items.Add("8");
			this.o_HideGridFactor.Items.Add("4");
			this.o_HideGridFactor.Items.Add("2");
			this.o_HideGridFactor.Location = new System.Drawing.Point(277, 54);
			this.o_HideGridFactor.Name = "o_HideGridFactor";
			this.o_HideGridFactor.Size = new System.Drawing.Size(38, 20);
			this.o_HideGridFactor.TabIndex = 0;
			this.o_HideGridFactor.Text = "8";
			// 
			// o_DefaultGridSize
			// 
			this.o_DefaultGridSize.Items.Add("1024");
			this.o_DefaultGridSize.Items.Add("512");
			this.o_DefaultGridSize.Items.Add("256");
			this.o_DefaultGridSize.Items.Add("128");
			this.o_DefaultGridSize.Items.Add("64");
			this.o_DefaultGridSize.Items.Add("32");
			this.o_DefaultGridSize.Items.Add("16");
			this.o_DefaultGridSize.Items.Add("8");
			this.o_DefaultGridSize.Items.Add("4");
			this.o_DefaultGridSize.Items.Add("2");
			this.o_DefaultGridSize.Items.Add("1");
			this.o_DefaultGridSize.Location = new System.Drawing.Point(105, 25);
			this.o_DefaultGridSize.Name = "o_DefaultGridSize";
			this.o_DefaultGridSize.SelectedIndex = 4;
			this.o_DefaultGridSize.Size = new System.Drawing.Size(49, 20);
			this.o_DefaultGridSize.TabIndex = 0;
			this.o_DefaultGridSize.Text = "64";
			// 
			// tab3DViews
			// 
			this.tab3DViews.Controls.Add(this.groupBox11);
			this.tab3DViews.Controls.Add(this.groupBox12);
			this.tab3DViews.Controls.Add(this.groupBox13);
			this.tab3DViews.Controls.Add(this.groupBox14);
			this.tab3DViews.Location = new System.Drawing.Point(4, 22);
			this.tab3DViews.Name = "tab3DViews";
			this.tab3DViews.Padding = new System.Windows.Forms.Padding(3);
			this.tab3DViews.Size = new System.Drawing.Size(736, 511);
			this.tab3DViews.TabIndex = 4;
			this.tab3DViews.Text = "3D Views";
			this.tab3DViews.UseVisualStyleBackColor = true;
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.o_3DInvertX);
			this.groupBox11.Controls.Add(this.o_3DInvertY);
			this.groupBox11.Location = new System.Drawing.Point(438, 6);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(146, 98);
			this.groupBox11.TabIndex = 3;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Mouselook";
			// 
			// o_3DInvertX
			// 
			this.o_3DInvertX.Location = new System.Drawing.Point(27, 49);
			this.o_3DInvertX.Name = "o_3DInvertX";
			this.o_3DInvertX.Size = new System.Drawing.Size(104, 24);
			this.o_3DInvertX.TabIndex = 0;
			this.o_3DInvertX.Text = "Invert X Axis";
			this.o_3DInvertX.UseVisualStyleBackColor = true;
			// 
			// o_3DInvertY
			// 
			this.o_3DInvertY.Location = new System.Drawing.Point(27, 19);
			this.o_3DInvertY.Name = "o_3DInvertY";
			this.o_3DInvertY.Size = new System.Drawing.Size(104, 24);
			this.o_3DInvertY.TabIndex = 0;
			this.o_3DInvertY.Text = "Invert Y Axis";
			this.o_3DInvertY.UseVisualStyleBackColor = true;
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.o_3DTimeToTopSpeed);
			this.groupBox12.Controls.Add(this.label14);
			this.groupBox12.Location = new System.Drawing.Point(6, 214);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(426, 98);
			this.groupBox12.TabIndex = 2;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Time to Top Speed";
			// 
			// o_3DTimeToTopSpeed
			// 
			this.o_3DTimeToTopSpeed.AutoSize = false;
			this.o_3DTimeToTopSpeed.BackColor = System.Drawing.SystemColors.Window;
			this.o_3DTimeToTopSpeed.Location = new System.Drawing.Point(6, 20);
			this.o_3DTimeToTopSpeed.Maximum = 50;
			this.o_3DTimeToTopSpeed.Name = "o_3DTimeToTopSpeed";
			this.o_3DTimeToTopSpeed.Size = new System.Drawing.Size(414, 42);
			this.o_3DTimeToTopSpeed.TabIndex = 0;
			this.o_3DTimeToTopSpeed.TickFrequency = 10000;
			this.o_3DTimeToTopSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.o_3DTimeToTopSpeed.Value = 5;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(6, 65);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(414, 23);
			this.label14.TabIndex = 1;
			this.label14.Text = "0.5 sec";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.o_3DForwardSpeed);
			this.groupBox13.Controls.Add(this.label15);
			this.groupBox13.Location = new System.Drawing.Point(6, 110);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(426, 98);
			this.groupBox13.TabIndex = 2;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Forward Speed";
			// 
			// o_3DForwardSpeed
			// 
			this.o_3DForwardSpeed.AutoSize = false;
			this.o_3DForwardSpeed.BackColor = System.Drawing.SystemColors.Window;
			this.o_3DForwardSpeed.Location = new System.Drawing.Point(6, 20);
			this.o_3DForwardSpeed.Maximum = 5000;
			this.o_3DForwardSpeed.Minimum = 100;
			this.o_3DForwardSpeed.Name = "o_3DForwardSpeed";
			this.o_3DForwardSpeed.Size = new System.Drawing.Size(414, 42);
			this.o_3DForwardSpeed.TabIndex = 0;
			this.o_3DForwardSpeed.TickFrequency = 10000;
			this.o_3DForwardSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.o_3DForwardSpeed.Value = 1000;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(6, 65);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(414, 23);
			this.label15.TabIndex = 1;
			this.label15.Text = "1000 units/sec";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.o_3DBackClippingPane);
			this.groupBox14.Controls.Add(this.label16);
			this.groupBox14.Location = new System.Drawing.Point(6, 6);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(426, 98);
			this.groupBox14.TabIndex = 2;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Back Clipping Pane";
			// 
			// o_3DBackClippingPane
			// 
			this.o_3DBackClippingPane.AutoSize = false;
			this.o_3DBackClippingPane.BackColor = System.Drawing.SystemColors.Window;
			this.o_3DBackClippingPane.Location = new System.Drawing.Point(6, 20);
			this.o_3DBackClippingPane.Maximum = 10000;
			this.o_3DBackClippingPane.Minimum = 2000;
			this.o_3DBackClippingPane.Name = "o_3DBackClippingPane";
			this.o_3DBackClippingPane.Size = new System.Drawing.Size(414, 42);
			this.o_3DBackClippingPane.TabIndex = 0;
			this.o_3DBackClippingPane.TickFrequency = 10000;
			this.o_3DBackClippingPane.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.o_3DBackClippingPane.Value = 5000;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(6, 65);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(414, 23);
			this.label16.TabIndex = 1;
			this.label16.Text = "4000";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabGame
			// 
			this.tabGame.Controls.Add(this.tabGameSubTabs);
			this.tabGame.Controls.Add(this.tree_games);
			this.tabGame.Controls.Add(this.btnGameRemove);
			this.tabGame.Controls.Add(this.btnGameAdd);
			this.tabGame.Location = new System.Drawing.Point(4, 22);
			this.tabGame.Name = "tabGame";
			this.tabGame.Padding = new System.Windows.Forms.Padding(3);
			this.tabGame.Size = new System.Drawing.Size(736, 511);
			this.tabGame.TabIndex = 2;
			this.tabGame.Text = "Game Configurations";
			this.tabGame.UseVisualStyleBackColor = true;
			// 
			// tabGameSubTabs
			// 
			this.tabGameSubTabs.Controls.Add(this.tabConfigDirectories);
			this.tabGameSubTabs.Controls.Add(this.tabConfigEntities);
			this.tabGameSubTabs.Controls.Add(this.tabConfigTextures);
			this.tabGameSubTabs.ItemSize = new System.Drawing.Size(58, 18);
			this.tabGameSubTabs.Location = new System.Drawing.Point(245, 6);
			this.tabGameSubTabs.Name = "tabGameSubTabs";
			this.tabGameSubTabs.SelectedIndex = 0;
			this.tabGameSubTabs.Size = new System.Drawing.Size(477, 423);
			this.tabGameSubTabs.TabIndex = 23;
			this.tabGameSubTabs.Visible = false;
			// 
			// tabConfigDirectories
			// 
			this.tabConfigDirectories.Controls.Add(this.btnGameChangeName);
			this.tabConfigDirectories.Controls.Add(this.grpConfigGame);
			this.tabConfigDirectories.Controls.Add(this.lblGameName);
			this.tabConfigDirectories.Controls.Add(this.cmbGameBuild);
			this.tabConfigDirectories.Controls.Add(this.grpConfigSaving);
			this.tabConfigDirectories.Controls.Add(this.lblGameBuild);
			this.tabConfigDirectories.Controls.Add(this.txtGameName);
			this.tabConfigDirectories.Controls.Add(this.cmbGameEngine);
			this.tabConfigDirectories.Controls.Add(this.lblGameEngine);
			this.tabConfigDirectories.Location = new System.Drawing.Point(4, 22);
			this.tabConfigDirectories.Name = "tabConfigDirectories";
			this.tabConfigDirectories.Padding = new System.Windows.Forms.Padding(3);
			this.tabConfigDirectories.Size = new System.Drawing.Size(469, 397);
			this.tabConfigDirectories.TabIndex = 0;
			this.tabConfigDirectories.Text = "General";
			this.tabConfigDirectories.UseVisualStyleBackColor = true;
			// 
			// btnGameChangeName
			// 
			this.btnGameChangeName.Location = new System.Drawing.Point(220, 9);
			this.btnGameChangeName.Name = "btnGameChangeName";
			this.btnGameChangeName.Size = new System.Drawing.Size(93, 20);
			this.btnGameChangeName.TabIndex = 21;
			this.btnGameChangeName.Text = "Change Name";
			this.btnGameChangeName.UseVisualStyleBackColor = true;
			this.btnGameChangeName.Click += new System.EventHandler(this.BtnGameChangeNameClick);
			// 
			// grpConfigGame
			// 
			this.grpConfigGame.Controls.Add(this.txtGameWONDir);
			this.grpConfigGame.Controls.Add(this.lblGameWONDir);
			this.grpConfigGame.Controls.Add(this.btnGameDirBrowse);
			this.grpConfigGame.Controls.Add(this.lblGameSteamDir);
			this.grpConfigGame.Controls.Add(this.cmbGameSteamDir);
			this.grpConfigGame.Controls.Add(this.lblGameMod);
			this.grpConfigGame.Controls.Add(this.cmbGameMod);
			this.grpConfigGame.Location = new System.Drawing.Point(6, 89);
			this.grpConfigGame.Name = "grpConfigGame";
			this.grpConfigGame.Size = new System.Drawing.Size(445, 111);
			this.grpConfigGame.TabIndex = 19;
			this.grpConfigGame.TabStop = false;
			this.grpConfigGame.Text = "Game";
			// 
			// txtGameWONDir
			// 
			this.txtGameWONDir.Location = new System.Drawing.Point(68, 16);
			this.txtGameWONDir.Name = "txtGameWONDir";
			this.txtGameWONDir.Size = new System.Drawing.Size(269, 20);
			this.txtGameWONDir.TabIndex = 5;
			this.txtGameWONDir.Text = "(WON only) example: C:\\Sierra\\Half-Life";
			this.txtGameWONDir.TextChanged += new System.EventHandler(this.TxtGameWONDirTextChanged);
			// 
			// lblGameWONDir
			// 
			this.lblGameWONDir.Location = new System.Drawing.Point(6, 16);
			this.lblGameWONDir.Name = "lblGameWONDir";
			this.lblGameWONDir.Size = new System.Drawing.Size(56, 20);
			this.lblGameWONDir.TabIndex = 6;
			this.lblGameWONDir.Text = "Game Dir";
			this.lblGameWONDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnGameDirBrowse
			// 
			this.btnGameDirBrowse.Location = new System.Drawing.Point(343, 15);
			this.btnGameDirBrowse.Name = "btnGameDirBrowse";
			this.btnGameDirBrowse.Size = new System.Drawing.Size(67, 23);
			this.btnGameDirBrowse.TabIndex = 8;
			this.btnGameDirBrowse.Text = "Browse...";
			this.btnGameDirBrowse.UseVisualStyleBackColor = true;
			this.btnGameDirBrowse.Click += new System.EventHandler(this.BtnGameDirBrowseClick);
			// 
			// lblGameSteamDir
			// 
			this.lblGameSteamDir.Location = new System.Drawing.Point(16, 43);
			this.lblGameSteamDir.Name = "lblGameSteamDir";
			this.lblGameSteamDir.Size = new System.Drawing.Size(45, 20);
			this.lblGameSteamDir.TabIndex = 9;
			this.lblGameSteamDir.Text = "Game";
			this.lblGameSteamDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbGameSteamDir
			// 
			this.cmbGameSteamDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGameSteamDir.FormattingEnabled = true;
			this.cmbGameSteamDir.Items.AddRange(new object[] {
									"(Steam only) Half-Life",
									"Counter-Strike"});
			this.cmbGameSteamDir.Location = new System.Drawing.Point(67, 42);
			this.cmbGameSteamDir.Name = "cmbGameSteamDir";
			this.cmbGameSteamDir.Size = new System.Drawing.Size(240, 21);
			this.cmbGameSteamDir.TabIndex = 10;
			this.cmbGameSteamDir.SelectedIndexChanged += new System.EventHandler(this.CmbGameSteamDirSelectedIndexChanged);
			// 
			// lblGameMod
			// 
			this.lblGameMod.Location = new System.Drawing.Point(16, 70);
			this.lblGameMod.Name = "lblGameMod";
			this.lblGameMod.Size = new System.Drawing.Size(45, 20);
			this.lblGameMod.TabIndex = 9;
			this.lblGameMod.Text = "Mod";
			this.lblGameMod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbGameMod
			// 
			this.cmbGameMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGameMod.FormattingEnabled = true;
			this.cmbGameMod.Items.AddRange(new object[] {
									"Valve"});
			this.cmbGameMod.Location = new System.Drawing.Point(67, 69);
			this.cmbGameMod.Name = "cmbGameMod";
			this.cmbGameMod.Size = new System.Drawing.Size(240, 21);
			this.cmbGameMod.TabIndex = 10;
			this.cmbGameMod.SelectedIndexChanged += new System.EventHandler(this.updateSelectedGameConfig);
			// 
			// lblGameName
			// 
			this.lblGameName.Location = new System.Drawing.Point(6, 9);
			this.lblGameName.Name = "lblGameName";
			this.lblGameName.Size = new System.Drawing.Size(69, 20);
			this.lblGameName.TabIndex = 6;
			this.lblGameName.Text = "Config Name";
			this.lblGameName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbGameBuild
			// 
			this.cmbGameBuild.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGameBuild.FormattingEnabled = true;
			this.cmbGameBuild.Location = new System.Drawing.Point(81, 62);
			this.cmbGameBuild.Name = "cmbGameBuild";
			this.cmbGameBuild.Size = new System.Drawing.Size(121, 21);
			this.cmbGameBuild.TabIndex = 10;
			this.cmbGameBuild.SelectedIndexChanged += new System.EventHandler(this.updateSelectedGameConfig);
			// 
			// grpConfigSaving
			// 
			this.grpConfigSaving.Controls.Add(this.lblGameMapSaveDir);
			this.grpConfigSaving.Controls.Add(this.chkGameEnableAutosave);
			this.grpConfigSaving.Controls.Add(this.txtGameMapDir);
			this.grpConfigSaving.Controls.Add(this.btnGameMapDirBrowse);
			this.grpConfigSaving.Controls.Add(this.txtGameAutosaveDir);
			this.grpConfigSaving.Controls.Add(this.lblGameAutosaveDir);
			this.grpConfigSaving.Controls.Add(this.btnGameAutosaveDirBrowse);
			this.grpConfigSaving.Controls.Add(this.chkGameMapDiffAutosaveDir);
			this.grpConfigSaving.Location = new System.Drawing.Point(6, 206);
			this.grpConfigSaving.Name = "grpConfigSaving";
			this.grpConfigSaving.Size = new System.Drawing.Size(445, 179);
			this.grpConfigSaving.TabIndex = 20;
			this.grpConfigSaving.TabStop = false;
			this.grpConfigSaving.Text = "Saving";
			// 
			// lblGameMapSaveDir
			// 
			this.lblGameMapSaveDir.Location = new System.Drawing.Point(9, 27);
			this.lblGameMapSaveDir.Name = "lblGameMapSaveDir";
			this.lblGameMapSaveDir.Size = new System.Drawing.Size(80, 20);
			this.lblGameMapSaveDir.TabIndex = 6;
			this.lblGameMapSaveDir.Text = "Map Save Dir";
			this.lblGameMapSaveDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkGameEnableAutosave
			// 
			this.chkGameEnableAutosave.Checked = true;
			this.chkGameEnableAutosave.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkGameEnableAutosave.Location = new System.Drawing.Point(95, 53);
			this.chkGameEnableAutosave.Name = "chkGameEnableAutosave";
			this.chkGameEnableAutosave.Size = new System.Drawing.Size(225, 24);
			this.chkGameEnableAutosave.TabIndex = 18;
			this.chkGameEnableAutosave.Text = "Enable autosave for this config";
			this.chkGameEnableAutosave.UseVisualStyleBackColor = true;
			this.chkGameEnableAutosave.CheckedChanged += new System.EventHandler(this.updateSelectedGameConfig);
			// 
			// txtGameMapDir
			// 
			this.txtGameMapDir.Location = new System.Drawing.Point(95, 27);
			this.txtGameMapDir.Name = "txtGameMapDir";
			this.txtGameMapDir.Size = new System.Drawing.Size(225, 20);
			this.txtGameMapDir.TabIndex = 5;
			this.txtGameMapDir.Text = "Default folder to save VMF/RMF files";
			this.txtGameMapDir.TextChanged += new System.EventHandler(this.updateSelectedGameConfig);
			// 
			// btnGameMapDirBrowse
			// 
			this.btnGameMapDirBrowse.Location = new System.Drawing.Point(326, 25);
			this.btnGameMapDirBrowse.Name = "btnGameMapDirBrowse";
			this.btnGameMapDirBrowse.Size = new System.Drawing.Size(67, 23);
			this.btnGameMapDirBrowse.TabIndex = 8;
			this.btnGameMapDirBrowse.Text = "Browse...";
			this.btnGameMapDirBrowse.UseVisualStyleBackColor = true;
			this.btnGameMapDirBrowse.Click += new System.EventHandler(this.BtnGameMapDirBrowseClick);
			// 
			// txtGameAutosaveDir
			// 
			this.txtGameAutosaveDir.BackColor = System.Drawing.SystemColors.Window;
			this.txtGameAutosaveDir.Location = new System.Drawing.Point(95, 109);
			this.txtGameAutosaveDir.Name = "txtGameAutosaveDir";
			this.txtGameAutosaveDir.Size = new System.Drawing.Size(225, 20);
			this.txtGameAutosaveDir.TabIndex = 11;
			this.txtGameAutosaveDir.Text = "Folder to put autosaves in";
			this.txtGameAutosaveDir.TextChanged += new System.EventHandler(this.updateSelectedGameConfig);
			// 
			// lblGameAutosaveDir
			// 
			this.lblGameAutosaveDir.Location = new System.Drawing.Point(9, 109);
			this.lblGameAutosaveDir.Name = "lblGameAutosaveDir";
			this.lblGameAutosaveDir.Size = new System.Drawing.Size(80, 20);
			this.lblGameAutosaveDir.TabIndex = 12;
			this.lblGameAutosaveDir.Text = "Autosave Dir";
			this.lblGameAutosaveDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnGameAutosaveDirBrowse
			// 
			this.btnGameAutosaveDirBrowse.Location = new System.Drawing.Point(326, 107);
			this.btnGameAutosaveDirBrowse.Name = "btnGameAutosaveDirBrowse";
			this.btnGameAutosaveDirBrowse.Size = new System.Drawing.Size(67, 23);
			this.btnGameAutosaveDirBrowse.TabIndex = 13;
			this.btnGameAutosaveDirBrowse.Text = "Browse...";
			this.btnGameAutosaveDirBrowse.UseVisualStyleBackColor = true;
			this.btnGameAutosaveDirBrowse.Click += new System.EventHandler(this.BtnGameAutosaveDirBrowseClick);
			// 
			// chkGameMapDiffAutosaveDir
			// 
			this.chkGameMapDiffAutosaveDir.Checked = true;
			this.chkGameMapDiffAutosaveDir.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkGameMapDiffAutosaveDir.Location = new System.Drawing.Point(95, 83);
			this.chkGameMapDiffAutosaveDir.Name = "chkGameMapDiffAutosaveDir";
			this.chkGameMapDiffAutosaveDir.Size = new System.Drawing.Size(225, 20);
			this.chkGameMapDiffAutosaveDir.TabIndex = 14;
			this.chkGameMapDiffAutosaveDir.Text = "Use a different directory for autosaves";
			this.chkGameMapDiffAutosaveDir.UseVisualStyleBackColor = true;
			this.chkGameMapDiffAutosaveDir.CheckedChanged += new System.EventHandler(this.ChkGameMapDiffAutosaveDirCheckedChanged);
			// 
			// lblGameBuild
			// 
			this.lblGameBuild.Location = new System.Drawing.Point(13, 61);
			this.lblGameBuild.Name = "lblGameBuild";
			this.lblGameBuild.Size = new System.Drawing.Size(62, 20);
			this.lblGameBuild.TabIndex = 9;
			this.lblGameBuild.Text = "Build Profile";
			this.lblGameBuild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtGameName
			// 
			this.txtGameName.Location = new System.Drawing.Point(81, 9);
			this.txtGameName.Name = "txtGameName";
			this.txtGameName.Size = new System.Drawing.Size(133, 20);
			this.txtGameName.TabIndex = 5;
			this.txtGameName.Text = "A_Config";
			// 
			// cmbGameEngine
			// 
			this.cmbGameEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGameEngine.FormattingEnabled = true;
			this.cmbGameEngine.Items.AddRange(new object[] {
									"Goldsource (WON)",
									"Goldsource (Steam)",
									"Source"});
			this.cmbGameEngine.Location = new System.Drawing.Point(81, 35);
			this.cmbGameEngine.Name = "cmbGameEngine";
			this.cmbGameEngine.Size = new System.Drawing.Size(121, 21);
			this.cmbGameEngine.TabIndex = 7;
			this.cmbGameEngine.SelectedIndexChanged += new System.EventHandler(this.CmbGameEngineSelectedIndexChanged);
			// 
			// lblGameEngine
			// 
			this.lblGameEngine.Location = new System.Drawing.Point(30, 36);
			this.lblGameEngine.Name = "lblGameEngine";
			this.lblGameEngine.Size = new System.Drawing.Size(45, 20);
			this.lblGameEngine.TabIndex = 6;
			this.lblGameEngine.Text = "Engine";
			this.lblGameEngine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabConfigEntities
			// 
			this.tabConfigEntities.Controls.Add(this.lblGameFGD);
			this.tabConfigEntities.Controls.Add(this.btnGameAddFGD);
			this.tabConfigEntities.Controls.Add(this.lblConfigBrushEnt);
			this.tabConfigEntities.Controls.Add(this.btnGameRemoveFGD);
			this.tabConfigEntities.Controls.Add(this.lblConfigPointEnt);
			this.tabConfigEntities.Controls.Add(this.lstGameFGD);
			this.tabConfigEntities.Controls.Add(this.cmbGameBrushEnt);
			this.tabConfigEntities.Controls.Add(this.cmbGamePointEnt);
			this.tabConfigEntities.Location = new System.Drawing.Point(4, 22);
			this.tabConfigEntities.Name = "tabConfigEntities";
			this.tabConfigEntities.Padding = new System.Windows.Forms.Padding(3);
			this.tabConfigEntities.Size = new System.Drawing.Size(469, 397);
			this.tabConfigEntities.TabIndex = 1;
			this.tabConfigEntities.Text = "Entities";
			this.tabConfigEntities.UseVisualStyleBackColor = true;
			// 
			// lblGameFGD
			// 
			this.lblGameFGD.Location = new System.Drawing.Point(15, 3);
			this.lblGameFGD.Name = "lblGameFGD";
			this.lblGameFGD.Size = new System.Drawing.Size(93, 20);
			this.lblGameFGD.TabIndex = 9;
			this.lblGameFGD.Text = "Game Data Files";
			this.lblGameFGD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnGameAddFGD
			// 
			this.btnGameAddFGD.Location = new System.Drawing.Point(389, 26);
			this.btnGameAddFGD.Name = "btnGameAddFGD";
			this.btnGameAddFGD.Size = new System.Drawing.Size(74, 23);
			this.btnGameAddFGD.TabIndex = 1;
			this.btnGameAddFGD.Text = "Add...";
			this.btnGameAddFGD.UseVisualStyleBackColor = true;
			this.btnGameAddFGD.Click += new System.EventHandler(this.BtnGameAddFGDClick);
			// 
			// lblConfigBrushEnt
			// 
			this.lblConfigBrushEnt.Location = new System.Drawing.Point(66, 220);
			this.lblConfigBrushEnt.Name = "lblConfigBrushEnt";
			this.lblConfigBrushEnt.Size = new System.Drawing.Size(112, 20);
			this.lblConfigBrushEnt.TabIndex = 9;
			this.lblConfigBrushEnt.Text = "Default Brush Entity";
			this.lblConfigBrushEnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnGameRemoveFGD
			// 
			this.btnGameRemoveFGD.Location = new System.Drawing.Point(389, 55);
			this.btnGameRemoveFGD.Name = "btnGameRemoveFGD";
			this.btnGameRemoveFGD.Size = new System.Drawing.Size(74, 23);
			this.btnGameRemoveFGD.TabIndex = 3;
			this.btnGameRemoveFGD.Text = "Remove";
			this.btnGameRemoveFGD.UseVisualStyleBackColor = true;
			this.btnGameRemoveFGD.Click += new System.EventHandler(this.BtnGameRemoveFGDClick);
			// 
			// lblConfigPointEnt
			// 
			this.lblConfigPointEnt.Location = new System.Drawing.Point(66, 193);
			this.lblConfigPointEnt.Name = "lblConfigPointEnt";
			this.lblConfigPointEnt.Size = new System.Drawing.Size(112, 20);
			this.lblConfigPointEnt.TabIndex = 9;
			this.lblConfigPointEnt.Text = "Default Point Entity";
			this.lblConfigPointEnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lstGameFGD
			// 
			this.lstGameFGD.FormattingEnabled = true;
			this.lstGameFGD.Items.AddRange(new object[] {
									"half-life.fgd",
									"etc."});
			this.lstGameFGD.Location = new System.Drawing.Point(15, 26);
			this.lstGameFGD.Name = "lstGameFGD";
			this.lstGameFGD.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstGameFGD.Size = new System.Drawing.Size(368, 160);
			this.lstGameFGD.TabIndex = 16;
			// 
			// cmbGameBrushEnt
			// 
			this.cmbGameBrushEnt.DropDownHeight = 300;
			this.cmbGameBrushEnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGameBrushEnt.FormattingEnabled = true;
			this.cmbGameBrushEnt.IntegralHeight = false;
			this.cmbGameBrushEnt.Items.AddRange(new object[] {
									"Valve"});
			this.cmbGameBrushEnt.Location = new System.Drawing.Point(184, 219);
			this.cmbGameBrushEnt.Name = "cmbGameBrushEnt";
			this.cmbGameBrushEnt.Size = new System.Drawing.Size(199, 21);
			this.cmbGameBrushEnt.TabIndex = 10;
			this.cmbGameBrushEnt.SelectedIndexChanged += new System.EventHandler(this.updateSelectedGameConfig);
			// 
			// cmbGamePointEnt
			// 
			this.cmbGamePointEnt.DropDownHeight = 300;
			this.cmbGamePointEnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGamePointEnt.FormattingEnabled = true;
			this.cmbGamePointEnt.IntegralHeight = false;
			this.cmbGamePointEnt.Items.AddRange(new object[] {
									"Valve"});
			this.cmbGamePointEnt.Location = new System.Drawing.Point(184, 192);
			this.cmbGamePointEnt.Name = "cmbGamePointEnt";
			this.cmbGamePointEnt.Size = new System.Drawing.Size(199, 21);
			this.cmbGamePointEnt.TabIndex = 10;
			this.cmbGamePointEnt.SelectedIndexChanged += new System.EventHandler(this.updateSelectedGameConfig);
			// 
			// tabConfigTextures
			// 
			this.tabConfigTextures.Controls.Add(this.lblGameWAD);
			this.tabConfigTextures.Controls.Add(this.nudGameLightmapScale);
			this.tabConfigTextures.Controls.Add(this.lblConfigLightmapScale);
			this.tabConfigTextures.Controls.Add(this.btnGameAddWAD);
			this.tabConfigTextures.Controls.Add(this.nudGameTextureScale);
			this.tabConfigTextures.Controls.Add(this.lstGameWAD);
			this.tabConfigTextures.Controls.Add(this.lblConfigTextureScale);
			this.tabConfigTextures.Controls.Add(this.btnGameRemoveWAD);
			this.tabConfigTextures.Location = new System.Drawing.Point(4, 22);
			this.tabConfigTextures.Name = "tabConfigTextures";
			this.tabConfigTextures.Padding = new System.Windows.Forms.Padding(3);
			this.tabConfigTextures.Size = new System.Drawing.Size(469, 397);
			this.tabConfigTextures.TabIndex = 2;
			this.tabConfigTextures.Text = "Textures";
			this.tabConfigTextures.UseVisualStyleBackColor = true;
			// 
			// lblGameWAD
			// 
			this.lblGameWAD.Location = new System.Drawing.Point(15, 3);
			this.lblGameWAD.Name = "lblGameWAD";
			this.lblGameWAD.Size = new System.Drawing.Size(80, 20);
			this.lblGameWAD.TabIndex = 9;
			this.lblGameWAD.Text = "WAD Textures";
			this.lblGameWAD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nudGameLightmapScale
			// 
			this.nudGameLightmapScale.Location = new System.Drawing.Point(332, 218);
			this.nudGameLightmapScale.Name = "nudGameLightmapScale";
			this.nudGameLightmapScale.Size = new System.Drawing.Size(51, 20);
			this.nudGameLightmapScale.TabIndex = 17;
			this.nudGameLightmapScale.Value = new decimal(new int[] {
									16,
									0,
									0,
									0});
			this.nudGameLightmapScale.ValueChanged += new System.EventHandler(this.updateSelectedGameConfig);
			// 
			// lblConfigLightmapScale
			// 
			this.lblConfigLightmapScale.Location = new System.Drawing.Point(209, 218);
			this.lblConfigLightmapScale.Name = "lblConfigLightmapScale";
			this.lblConfigLightmapScale.Size = new System.Drawing.Size(117, 20);
			this.lblConfigLightmapScale.TabIndex = 9;
			this.lblConfigLightmapScale.Text = "Default Lightmap Scale";
			this.lblConfigLightmapScale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnGameAddWAD
			// 
			this.btnGameAddWAD.Location = new System.Drawing.Point(389, 26);
			this.btnGameAddWAD.Name = "btnGameAddWAD";
			this.btnGameAddWAD.Size = new System.Drawing.Size(74, 23);
			this.btnGameAddWAD.TabIndex = 1;
			this.btnGameAddWAD.Text = "Add...";
			this.btnGameAddWAD.UseVisualStyleBackColor = true;
			this.btnGameAddWAD.Click += new System.EventHandler(this.BtnGameAddWADClick);
			// 
			// nudGameTextureScale
			// 
			this.nudGameTextureScale.DecimalPlaces = 2;
			this.nudGameTextureScale.Increment = new decimal(new int[] {
									5,
									0,
									0,
									131072});
			this.nudGameTextureScale.Location = new System.Drawing.Point(332, 192);
			this.nudGameTextureScale.Name = "nudGameTextureScale";
			this.nudGameTextureScale.Size = new System.Drawing.Size(51, 20);
			this.nudGameTextureScale.TabIndex = 17;
			this.nudGameTextureScale.Value = new decimal(new int[] {
									25,
									0,
									0,
									131072});
			this.nudGameTextureScale.ValueChanged += new System.EventHandler(this.updateSelectedGameConfig);
			// 
			// lstGameWAD
			// 
			this.lstGameWAD.FormattingEnabled = true;
			this.lstGameWAD.Items.AddRange(new object[] {
									"(Goldsource only)",
									"halflife.wad",
									"etc."});
			this.lstGameWAD.Location = new System.Drawing.Point(15, 26);
			this.lstGameWAD.Name = "lstGameWAD";
			this.lstGameWAD.Size = new System.Drawing.Size(368, 160);
			this.lstGameWAD.TabIndex = 16;
			// 
			// lblConfigTextureScale
			// 
			this.lblConfigTextureScale.Location = new System.Drawing.Point(209, 192);
			this.lblConfigTextureScale.Name = "lblConfigTextureScale";
			this.lblConfigTextureScale.Size = new System.Drawing.Size(117, 20);
			this.lblConfigTextureScale.TabIndex = 9;
			this.lblConfigTextureScale.Text = "Default Texture Scale";
			this.lblConfigTextureScale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnGameRemoveWAD
			// 
			this.btnGameRemoveWAD.Location = new System.Drawing.Point(389, 55);
			this.btnGameRemoveWAD.Name = "btnGameRemoveWAD";
			this.btnGameRemoveWAD.Size = new System.Drawing.Size(74, 23);
			this.btnGameRemoveWAD.TabIndex = 3;
			this.btnGameRemoveWAD.Text = "Remove";
			this.btnGameRemoveWAD.UseVisualStyleBackColor = true;
			this.btnGameRemoveWAD.Click += new System.EventHandler(this.BtnGameRemoveWADClick);
			// 
			// tree_games
			// 
			this.tree_games.Location = new System.Drawing.Point(6, 6);
			this.tree_games.Name = "tree_games";
			treeNode1.Name = "nodeWHL";
			treeNode1.Text = "WON Goldsource";
			treeNode2.Name = "nodeSHL";
			treeNode2.Text = "Steam Goldsource";
			treeNode3.Name = "nodeSource";
			treeNode3.Text = "Source";
			this.tree_games.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode1,
									treeNode2,
									treeNode3});
			this.tree_games.Size = new System.Drawing.Size(154, 448);
			this.tree_games.TabIndex = 0;
			this.tree_games.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_gamesAfterSelect);
			// 
			// btnGameRemove
			// 
			this.btnGameRemove.Location = new System.Drawing.Point(166, 35);
			this.btnGameRemove.Name = "btnGameRemove";
			this.btnGameRemove.Size = new System.Drawing.Size(73, 23);
			this.btnGameRemove.TabIndex = 3;
			this.btnGameRemove.Text = "Remove";
			this.btnGameRemove.UseVisualStyleBackColor = true;
			// 
			// btnGameAdd
			// 
			this.btnGameAdd.Location = new System.Drawing.Point(166, 6);
			this.btnGameAdd.Name = "btnGameAdd";
			this.btnGameAdd.Size = new System.Drawing.Size(73, 23);
			this.btnGameAdd.TabIndex = 1;
			this.btnGameAdd.Text = "Add New";
			this.btnGameAdd.UseVisualStyleBackColor = true;
			this.btnGameAdd.Click += new System.EventHandler(this.BtnGameAddClick);
			// 
			// tabBuild
			// 
			this.tabBuild.Controls.Add(this.tabBuildSubTabs);
			this.tabBuild.Controls.Add(this.btnBuildRemove);
			this.tabBuild.Controls.Add(this.btnBuildAdd);
			this.tabBuild.Controls.Add(this.tree_builds);
			this.tabBuild.Location = new System.Drawing.Point(4, 22);
			this.tabBuild.Name = "tabBuild";
			this.tabBuild.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuild.Size = new System.Drawing.Size(736, 511);
			this.tabBuild.TabIndex = 3;
			this.tabBuild.Text = "Build Programs";
			this.tabBuild.UseVisualStyleBackColor = true;
			// 
			// tabBuildSubTabs
			// 
			this.tabBuildSubTabs.Controls.Add(this.tabBuildGeneral);
			this.tabBuildSubTabs.Controls.Add(this.tabBuildExecutables);
			this.tabBuildSubTabs.Controls.Add(this.tabBuildPostCompile);
			this.tabBuildSubTabs.Controls.Add(this.tabBuildAdvanced);
			this.tabBuildSubTabs.Location = new System.Drawing.Point(245, 6);
			this.tabBuildSubTabs.Name = "tabBuildSubTabs";
			this.tabBuildSubTabs.SelectedIndex = 0;
			this.tabBuildSubTabs.Size = new System.Drawing.Size(477, 499);
			this.tabBuildSubTabs.TabIndex = 29;
			this.tabBuildSubTabs.Visible = false;
			// 
			// tabBuildGeneral
			// 
			this.tabBuildGeneral.Controls.Add(this.btnBuildChangeName);
			this.tabBuildGeneral.Controls.Add(this.lblBuildName);
			this.tabBuildGeneral.Controls.Add(this.txtBuildName);
			this.tabBuildGeneral.Controls.Add(this.lblBuildEngine);
			this.tabBuildGeneral.Controls.Add(this.cmbBuildEngine);
			this.tabBuildGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabBuildGeneral.Name = "tabBuildGeneral";
			this.tabBuildGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuildGeneral.Size = new System.Drawing.Size(469, 473);
			this.tabBuildGeneral.TabIndex = 0;
			this.tabBuildGeneral.Text = "General";
			this.tabBuildGeneral.UseVisualStyleBackColor = true;
			// 
			// btnBuildChangeName
			// 
			this.btnBuildChangeName.Location = new System.Drawing.Point(223, 6);
			this.btnBuildChangeName.Name = "btnBuildChangeName";
			this.btnBuildChangeName.Size = new System.Drawing.Size(90, 20);
			this.btnBuildChangeName.TabIndex = 20;
			this.btnBuildChangeName.Text = "Change Name";
			this.btnBuildChangeName.UseVisualStyleBackColor = true;
			this.btnBuildChangeName.Click += new System.EventHandler(this.BtnBuildChangeNameClick);
			// 
			// lblBuildName
			// 
			this.lblBuildName.Location = new System.Drawing.Point(9, 6);
			this.lblBuildName.Name = "lblBuildName";
			this.lblBuildName.Size = new System.Drawing.Size(69, 20);
			this.lblBuildName.TabIndex = 18;
			this.lblBuildName.Text = "Config Name";
			this.lblBuildName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBuildName
			// 
			this.txtBuildName.Location = new System.Drawing.Point(84, 6);
			this.txtBuildName.Name = "txtBuildName";
			this.txtBuildName.Size = new System.Drawing.Size(133, 20);
			this.txtBuildName.TabIndex = 14;
			this.txtBuildName.Text = "ZHLT";
			// 
			// lblBuildEngine
			// 
			this.lblBuildEngine.Location = new System.Drawing.Point(33, 33);
			this.lblBuildEngine.Name = "lblBuildEngine";
			this.lblBuildEngine.Size = new System.Drawing.Size(45, 20);
			this.lblBuildEngine.TabIndex = 16;
			this.lblBuildEngine.Text = "Engine";
			this.lblBuildEngine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbBuildEngine
			// 
			this.cmbBuildEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBuildEngine.FormattingEnabled = true;
			this.cmbBuildEngine.Items.AddRange(new object[] {
									"Goldsource",
									"Source"});
			this.cmbBuildEngine.Location = new System.Drawing.Point(84, 32);
			this.cmbBuildEngine.Name = "cmbBuildEngine";
			this.cmbBuildEngine.Size = new System.Drawing.Size(121, 21);
			this.cmbBuildEngine.TabIndex = 19;
			this.cmbBuildEngine.SelectedIndexChanged += new System.EventHandler(this.CmbBuildEngineSelectedIndexChanged);
			// 
			// tabBuildExecutables
			// 
			this.tabBuildExecutables.Controls.Add(this.lstBuildPresets);
			this.tabBuildExecutables.Controls.Add(this.lblBuildExeFolder);
			this.tabBuildExecutables.Controls.Add(this.lblBuildBSP);
			this.tabBuildExecutables.Controls.Add(this.txtBuildExeFolder);
			this.tabBuildExecutables.Controls.Add(this.lblBuildCSG);
			this.tabBuildExecutables.Controls.Add(this.cmbBuildRAD);
			this.tabBuildExecutables.Controls.Add(this.cmbBuildBSP);
			this.tabBuildExecutables.Controls.Add(this.lblBuildDetectedPresets);
			this.tabBuildExecutables.Controls.Add(this.lblBuildVIS);
			this.tabBuildExecutables.Controls.Add(this.cmbBuildVIS);
			this.tabBuildExecutables.Controls.Add(this.cmbBuildCSG);
			this.tabBuildExecutables.Controls.Add(this.lblBuildRAD);
			this.tabBuildExecutables.Controls.Add(this.btnBuildExeFolderBrowse);
			this.tabBuildExecutables.Location = new System.Drawing.Point(4, 22);
			this.tabBuildExecutables.Name = "tabBuildExecutables";
			this.tabBuildExecutables.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuildExecutables.Size = new System.Drawing.Size(469, 473);
			this.tabBuildExecutables.TabIndex = 1;
			this.tabBuildExecutables.Text = "Build Programs";
			this.tabBuildExecutables.UseVisualStyleBackColor = true;
			// 
			// lstBuildPresets
			// 
			this.lstBuildPresets.FormattingEnabled = true;
			this.lstBuildPresets.Items.AddRange(new object[] {
									"ZHLT",
									"Quake Tools"});
			this.lstBuildPresets.Location = new System.Drawing.Point(6, 90);
			this.lstBuildPresets.Name = "lstBuildPresets";
			this.lstBuildPresets.Size = new System.Drawing.Size(167, 69);
			this.lstBuildPresets.TabIndex = 22;
			this.lstBuildPresets.SelectedIndexChanged += new System.EventHandler(this.LstBuildPresetsSelectedIndexChanged);
			// 
			// lblBuildExeFolder
			// 
			this.lblBuildExeFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBuildExeFolder.Location = new System.Drawing.Point(6, 7);
			this.lblBuildExeFolder.Name = "lblBuildExeFolder";
			this.lblBuildExeFolder.Size = new System.Drawing.Size(176, 20);
			this.lblBuildExeFolder.TabIndex = 17;
			this.lblBuildExeFolder.Text = "Folder containing build executables:";
			this.lblBuildExeFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblBuildBSP
			// 
			this.lblBuildBSP.Location = new System.Drawing.Point(179, 66);
			this.lblBuildBSP.Name = "lblBuildBSP";
			this.lblBuildBSP.Size = new System.Drawing.Size(34, 20);
			this.lblBuildBSP.TabIndex = 16;
			this.lblBuildBSP.Text = "BSP";
			this.lblBuildBSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBuildExeFolder
			// 
			this.txtBuildExeFolder.Location = new System.Drawing.Point(6, 29);
			this.txtBuildExeFolder.Name = "txtBuildExeFolder";
			this.txtBuildExeFolder.Size = new System.Drawing.Size(323, 20);
			this.txtBuildExeFolder.TabIndex = 15;
			this.txtBuildExeFolder.Text = "example: C:\\hammer_alt";
			this.txtBuildExeFolder.TextChanged += new System.EventHandler(this.TxtBuildExeFolderTextChanged);
			// 
			// lblBuildCSG
			// 
			this.lblBuildCSG.Location = new System.Drawing.Point(179, 93);
			this.lblBuildCSG.Name = "lblBuildCSG";
			this.lblBuildCSG.Size = new System.Drawing.Size(34, 20);
			this.lblBuildCSG.TabIndex = 16;
			this.lblBuildCSG.Text = "CSG";
			this.lblBuildCSG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbBuildRAD
			// 
			this.cmbBuildRAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBuildRAD.FormattingEnabled = true;
			this.cmbBuildRAD.Location = new System.Drawing.Point(219, 146);
			this.cmbBuildRAD.Name = "cmbBuildRAD";
			this.cmbBuildRAD.Size = new System.Drawing.Size(234, 21);
			this.cmbBuildRAD.TabIndex = 19;
			this.cmbBuildRAD.SelectedIndexChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// cmbBuildBSP
			// 
			this.cmbBuildBSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBuildBSP.FormattingEnabled = true;
			this.cmbBuildBSP.Location = new System.Drawing.Point(219, 65);
			this.cmbBuildBSP.Name = "cmbBuildBSP";
			this.cmbBuildBSP.Size = new System.Drawing.Size(234, 21);
			this.cmbBuildBSP.TabIndex = 19;
			this.cmbBuildBSP.SelectedIndexChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// lblBuildDetectedPresets
			// 
			this.lblBuildDetectedPresets.Location = new System.Drawing.Point(6, 66);
			this.lblBuildDetectedPresets.Name = "lblBuildDetectedPresets";
			this.lblBuildDetectedPresets.Size = new System.Drawing.Size(167, 20);
			this.lblBuildDetectedPresets.TabIndex = 17;
			this.lblBuildDetectedPresets.Text = "Detected presets:";
			this.lblBuildDetectedPresets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblBuildVIS
			// 
			this.lblBuildVIS.Location = new System.Drawing.Point(179, 120);
			this.lblBuildVIS.Name = "lblBuildVIS";
			this.lblBuildVIS.Size = new System.Drawing.Size(34, 20);
			this.lblBuildVIS.TabIndex = 16;
			this.lblBuildVIS.Text = "VIS";
			this.lblBuildVIS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbBuildVIS
			// 
			this.cmbBuildVIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBuildVIS.FormattingEnabled = true;
			this.cmbBuildVIS.Location = new System.Drawing.Point(219, 119);
			this.cmbBuildVIS.Name = "cmbBuildVIS";
			this.cmbBuildVIS.Size = new System.Drawing.Size(234, 21);
			this.cmbBuildVIS.TabIndex = 19;
			this.cmbBuildVIS.SelectedIndexChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// cmbBuildCSG
			// 
			this.cmbBuildCSG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBuildCSG.FormattingEnabled = true;
			this.cmbBuildCSG.Location = new System.Drawing.Point(219, 92);
			this.cmbBuildCSG.Name = "cmbBuildCSG";
			this.cmbBuildCSG.Size = new System.Drawing.Size(234, 21);
			this.cmbBuildCSG.TabIndex = 19;
			this.cmbBuildCSG.SelectedIndexChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// lblBuildRAD
			// 
			this.lblBuildRAD.Location = new System.Drawing.Point(179, 147);
			this.lblBuildRAD.Name = "lblBuildRAD";
			this.lblBuildRAD.Size = new System.Drawing.Size(34, 20);
			this.lblBuildRAD.TabIndex = 16;
			this.lblBuildRAD.Text = "RAD";
			this.lblBuildRAD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnBuildExeFolderBrowse
			// 
			this.btnBuildExeFolderBrowse.Location = new System.Drawing.Point(335, 27);
			this.btnBuildExeFolderBrowse.Name = "btnBuildExeFolderBrowse";
			this.btnBuildExeFolderBrowse.Size = new System.Drawing.Size(67, 23);
			this.btnBuildExeFolderBrowse.TabIndex = 20;
			this.btnBuildExeFolderBrowse.Text = "Browse...";
			this.btnBuildExeFolderBrowse.UseVisualStyleBackColor = true;
			this.btnBuildExeFolderBrowse.Click += new System.EventHandler(this.BtnBuildExeFolderBrowseClick);
			// 
			// tabBuildPostCompile
			// 
			this.tabBuildPostCompile.Controls.Add(this.lblBuildCommandLine);
			this.tabBuildPostCompile.Controls.Add(this.chkBuildCopyBSP);
			this.tabBuildPostCompile.Controls.Add(this.chkBuildAskBeforeRun);
			this.tabBuildPostCompile.Controls.Add(this.radBuildRunGame);
			this.tabBuildPostCompile.Controls.Add(this.txtBuildCommandLine);
			this.tabBuildPostCompile.Controls.Add(this.radBuildRunGameOnChange);
			this.tabBuildPostCompile.Controls.Add(this.chkBuildShowLog);
			this.tabBuildPostCompile.Controls.Add(this.radBuildDontRunGame);
			this.tabBuildPostCompile.Location = new System.Drawing.Point(4, 22);
			this.tabBuildPostCompile.Name = "tabBuildPostCompile";
			this.tabBuildPostCompile.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuildPostCompile.Size = new System.Drawing.Size(469, 473);
			this.tabBuildPostCompile.TabIndex = 2;
			this.tabBuildPostCompile.Text = "After Compiling";
			this.tabBuildPostCompile.UseVisualStyleBackColor = true;
			// 
			// lblBuildCommandLine
			// 
			this.lblBuildCommandLine.Location = new System.Drawing.Point(7, 178);
			this.lblBuildCommandLine.Name = "lblBuildCommandLine";
			this.lblBuildCommandLine.Size = new System.Drawing.Size(107, 20);
			this.lblBuildCommandLine.TabIndex = 28;
			this.lblBuildCommandLine.Text = "Game command line";
			this.lblBuildCommandLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkBuildCopyBSP
			// 
			this.chkBuildCopyBSP.Checked = true;
			this.chkBuildCopyBSP.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBuildCopyBSP.Location = new System.Drawing.Point(6, 7);
			this.chkBuildCopyBSP.Name = "chkBuildCopyBSP";
			this.chkBuildCopyBSP.Size = new System.Drawing.Size(256, 23);
			this.chkBuildCopyBSP.TabIndex = 30;
			this.chkBuildCopyBSP.Text = "Copy BSP into <mod>/maps folder on compile";
			this.chkBuildCopyBSP.UseVisualStyleBackColor = true;
			this.chkBuildCopyBSP.CheckedChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// chkBuildAskBeforeRun
			// 
			this.chkBuildAskBeforeRun.Checked = true;
			this.chkBuildAskBeforeRun.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBuildAskBeforeRun.Location = new System.Drawing.Point(7, 152);
			this.chkBuildAskBeforeRun.Name = "chkBuildAskBeforeRun";
			this.chkBuildAskBeforeRun.Size = new System.Drawing.Size(171, 23);
			this.chkBuildAskBeforeRun.TabIndex = 29;
			this.chkBuildAskBeforeRun.Text = "Ask before running game";
			this.chkBuildAskBeforeRun.UseVisualStyleBackColor = true;
			this.chkBuildAskBeforeRun.CheckedChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// radBuildRunGame
			// 
			this.radBuildRunGame.Location = new System.Drawing.Point(6, 65);
			this.radBuildRunGame.Name = "radBuildRunGame";
			this.radBuildRunGame.Size = new System.Drawing.Size(104, 23);
			this.radBuildRunGame.TabIndex = 26;
			this.radBuildRunGame.Text = "Run game";
			this.radBuildRunGame.UseVisualStyleBackColor = true;
			this.radBuildRunGame.CheckedChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// txtBuildCommandLine
			// 
			this.txtBuildCommandLine.Location = new System.Drawing.Point(120, 178);
			this.txtBuildCommandLine.Name = "txtBuildCommandLine";
			this.txtBuildCommandLine.Size = new System.Drawing.Size(225, 20);
			this.txtBuildCommandLine.TabIndex = 27;
			this.txtBuildCommandLine.Text = "-dev -console";
			this.txtBuildCommandLine.TextChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// radBuildRunGameOnChange
			// 
			this.radBuildRunGameOnChange.Checked = true;
			this.radBuildRunGameOnChange.Location = new System.Drawing.Point(6, 93);
			this.radBuildRunGameOnChange.Name = "radBuildRunGameOnChange";
			this.radBuildRunGameOnChange.Size = new System.Drawing.Size(192, 24);
			this.radBuildRunGameOnChange.TabIndex = 25;
			this.radBuildRunGameOnChange.TabStop = true;
			this.radBuildRunGameOnChange.Text = "Run game only if the BSP changed";
			this.radBuildRunGameOnChange.UseVisualStyleBackColor = true;
			this.radBuildRunGameOnChange.CheckedChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// chkBuildShowLog
			// 
			this.chkBuildShowLog.Checked = true;
			this.chkBuildShowLog.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBuildShowLog.Location = new System.Drawing.Point(6, 36);
			this.chkBuildShowLog.Name = "chkBuildShowLog";
			this.chkBuildShowLog.Size = new System.Drawing.Size(256, 23);
			this.chkBuildShowLog.TabIndex = 31;
			this.chkBuildShowLog.Text = "Show compile log";
			this.chkBuildShowLog.UseVisualStyleBackColor = true;
			this.chkBuildShowLog.CheckedChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// radBuildDontRunGame
			// 
			this.radBuildDontRunGame.Location = new System.Drawing.Point(6, 123);
			this.radBuildDontRunGame.Name = "radBuildDontRunGame";
			this.radBuildDontRunGame.Size = new System.Drawing.Size(104, 23);
			this.radBuildDontRunGame.TabIndex = 24;
			this.radBuildDontRunGame.Text = "Do nothing";
			this.radBuildDontRunGame.UseVisualStyleBackColor = true;
			this.radBuildDontRunGame.CheckedChanged += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// tabBuildAdvanced
			// 
			this.tabBuildAdvanced.Controls.Add(this.tabBuildAdvancedSubTabs);
			this.tabBuildAdvanced.Controls.Add(this.lblBuildTEMPAdvancedConfig);
			this.tabBuildAdvanced.Location = new System.Drawing.Point(4, 22);
			this.tabBuildAdvanced.Name = "tabBuildAdvanced";
			this.tabBuildAdvanced.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuildAdvanced.Size = new System.Drawing.Size(469, 473);
			this.tabBuildAdvanced.TabIndex = 3;
			this.tabBuildAdvanced.Text = "Advanced";
			this.tabBuildAdvanced.UseVisualStyleBackColor = true;
			// 
			// tabBuildAdvancedSubTabs
			// 
			this.tabBuildAdvancedSubTabs.Controls.Add(this.tabBuildAdvancedCSG);
			this.tabBuildAdvancedSubTabs.Controls.Add(this.tabBuildAdvancedBSP);
			this.tabBuildAdvancedSubTabs.Controls.Add(this.tabBuildAdvancedVIS);
			this.tabBuildAdvancedSubTabs.Controls.Add(this.tabBuildAdvancedRAD);
			this.tabBuildAdvancedSubTabs.Controls.Add(this.tabBuildAdvancedShared);
			this.tabBuildAdvancedSubTabs.Controls.Add(this.tabBuildAdvancedPreview);
			this.tabBuildAdvancedSubTabs.Location = new System.Drawing.Point(6, 33);
			this.tabBuildAdvancedSubTabs.Name = "tabBuildAdvancedSubTabs";
			this.tabBuildAdvancedSubTabs.SelectedIndex = 0;
			this.tabBuildAdvancedSubTabs.Size = new System.Drawing.Size(457, 434);
			this.tabBuildAdvancedSubTabs.TabIndex = 19;
			// 
			// tabBuildAdvancedCSG
			// 
			this.tabBuildAdvancedCSG.Controls.Add(this.label20);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox9);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox6);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox8);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox13);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox12);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox10);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox5);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox7);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox4);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox3);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox11);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox2);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox14);
			this.tabBuildAdvancedCSG.Controls.Add(this.buildValueCheckbox1);
			this.tabBuildAdvancedCSG.Location = new System.Drawing.Point(4, 22);
			this.tabBuildAdvancedCSG.Name = "tabBuildAdvancedCSG";
			this.tabBuildAdvancedCSG.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuildAdvancedCSG.Size = new System.Drawing.Size(449, 408);
			this.tabBuildAdvancedCSG.TabIndex = 0;
			this.tabBuildAdvancedCSG.Text = "CSG";
			this.tabBuildAdvancedCSG.UseVisualStyleBackColor = true;
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.Location = new System.Drawing.Point(93, 268);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(238, 36);
			this.label20.TabIndex = 2;
			this.label20.Text = "+WADINCLUDE";
			// 
			// buildValueCheckbox9
			// 
			this.buildValueCheckbox9.Checked = false;
			this.buildValueCheckbox9.CommandLineSwitch = "-brushunion";
			this.buildValueCheckbox9.Label = "Brush Union";
			this.buildValueCheckbox9.Location = new System.Drawing.Point(15, 174);
			this.buildValueCheckbox9.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox9.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox9.Name = "buildValueCheckbox9";
			this.buildValueCheckbox9.NumValue = new decimal(new int[] {
									95,
									0,
									0,
									0});
			this.buildValueCheckbox9.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox9.TabIndex = 1;
			this.buildValueCheckbox9.TextValue = "";
			this.buildValueCheckbox9.ToolTipText = "Threshold to warn about overlapping brushes.";
			this.buildValueCheckbox9.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox9.ValueWidth = 80;
			this.buildValueCheckbox9.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox6
			// 
			this.buildValueCheckbox6.Checked = false;
			this.buildValueCheckbox6.CommandLineSwitch = "-onlyents";
			this.buildValueCheckbox6.Label = "Only Entities";
			this.buildValueCheckbox6.Location = new System.Drawing.Point(239, 174);
			this.buildValueCheckbox6.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox6.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox6.Name = "buildValueCheckbox6";
			this.buildValueCheckbox6.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox6.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox6.TabIndex = 1;
			this.buildValueCheckbox6.TextValue = "";
			this.buildValueCheckbox6.ToolTipText = "Do an entity update from .map to .bsp.";
			this.buildValueCheckbox6.ValueWidth = 80;
			this.buildValueCheckbox6.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox8
			// 
			this.buildValueCheckbox8.Checked = false;
			this.buildValueCheckbox8.CommandLineSwitch = "-tiny";
			this.buildValueCheckbox8.Label = "Tiny";
			this.buildValueCheckbox8.Location = new System.Drawing.Point(15, 146);
			this.buildValueCheckbox8.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox8.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox8.Name = "buildValueCheckbox8";
			this.buildValueCheckbox8.NumValue = new decimal(new int[] {
									5,
									0,
									0,
									65536});
			this.buildValueCheckbox8.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox8.TabIndex = 1;
			this.buildValueCheckbox8.TextValue = "";
			this.buildValueCheckbox8.ToolTipText = "Minmum brush face surface area before it is discarded.";
			this.buildValueCheckbox8.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox8.ValueWidth = 80;
			this.buildValueCheckbox8.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox13
			// 
			this.buildValueCheckbox13.Checked = false;
			this.buildValueCheckbox13.CommandLineSwitch = "-wadconfig";
			this.buildValueCheckbox13.Label = "WAD config";
			this.buildValueCheckbox13.Location = new System.Drawing.Point(15, 90);
			this.buildValueCheckbox13.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox13.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox13.Name = "buildValueCheckbox13";
			this.buildValueCheckbox13.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox13.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox13.TabIndex = 1;
			this.buildValueCheckbox13.TextValue = "";
			this.buildValueCheckbox13.ToolTipText = "Manually specify a path to the wad.cfg file.";
			this.buildValueCheckbox13.ValueType = thor.BuildValueCheckboxType.Text;
			this.buildValueCheckbox13.ValueWidth = 80;
			this.buildValueCheckbox13.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox12
			// 
			this.buildValueCheckbox12.Checked = false;
			this.buildValueCheckbox12.CommandLineSwitch = "-wadcfgfile";
			this.buildValueCheckbox12.Label = "wad.cfg File";
			this.buildValueCheckbox12.Location = new System.Drawing.Point(15, 62);
			this.buildValueCheckbox12.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox12.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox12.Name = "buildValueCheckbox12";
			this.buildValueCheckbox12.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox12.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox12.TabIndex = 1;
			this.buildValueCheckbox12.TextValue = "";
			this.buildValueCheckbox12.ToolTipText = "Manually specify a path to the wad.cfg file.";
			this.buildValueCheckbox12.ValueType = thor.BuildValueCheckboxType.File;
			this.buildValueCheckbox12.ValueWidth = 80;
			this.buildValueCheckbox12.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox10
			// 
			this.buildValueCheckbox10.Checked = false;
			this.buildValueCheckbox10.CommandLineSwitch = "-hullfile";
			this.buildValueCheckbox10.Label = "Hull file";
			this.buildValueCheckbox10.Location = new System.Drawing.Point(239, 118);
			this.buildValueCheckbox10.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox10.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox10.Name = "buildValueCheckbox10";
			this.buildValueCheckbox10.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox10.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox10.TabIndex = 1;
			this.buildValueCheckbox10.TextValue = "";
			this.buildValueCheckbox10.ToolTipText = "Reads in custom collision hull dimensions.";
			this.buildValueCheckbox10.ValueType = thor.BuildValueCheckboxType.File;
			this.buildValueCheckbox10.ValueWidth = 80;
			this.buildValueCheckbox10.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox5
			// 
			this.buildValueCheckbox5.Checked = false;
			this.buildValueCheckbox5.CommandLineSwitch = "-nullfile";
			this.buildValueCheckbox5.Label = "Null file";
			this.buildValueCheckbox5.Location = new System.Drawing.Point(239, 146);
			this.buildValueCheckbox5.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox5.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox5.Name = "buildValueCheckbox5";
			this.buildValueCheckbox5.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox5.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox5.TabIndex = 1;
			this.buildValueCheckbox5.TextValue = "";
			this.buildValueCheckbox5.ToolTipText = "Specify list of entities to retexture with NULL.";
			this.buildValueCheckbox5.ValueType = thor.BuildValueCheckboxType.File;
			this.buildValueCheckbox5.ValueWidth = 80;
			this.buildValueCheckbox5.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox7
			// 
			this.buildValueCheckbox7.Checked = false;
			this.buildValueCheckbox7.CommandLineSwitch = "-noskyclip";
			this.buildValueCheckbox7.Label = "No Sky Clip";
			this.buildValueCheckbox7.Location = new System.Drawing.Point(239, 62);
			this.buildValueCheckbox7.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox7.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox7.Name = "buildValueCheckbox7";
			this.buildValueCheckbox7.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox7.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox7.TabIndex = 1;
			this.buildValueCheckbox7.TextValue = "";
			this.buildValueCheckbox7.ToolTipText = "Disable automatic clipping of SKY brushes.";
			this.buildValueCheckbox7.ValueWidth = 80;
			this.buildValueCheckbox7.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox4
			// 
			this.buildValueCheckbox4.Checked = false;
			this.buildValueCheckbox4.CommandLineSwitch = "-cliptype";
			this.buildValueCheckbox4.DropDownItems.AddRange(new object[] {
									"legacy",
									"smallest",
									"normalized",
									"simple",
									"precise"});
			this.buildValueCheckbox4.Label = "Cliptype";
			this.buildValueCheckbox4.Location = new System.Drawing.Point(239, 90);
			this.buildValueCheckbox4.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox4.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox4.Name = "buildValueCheckbox4";
			this.buildValueCheckbox4.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox4.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox4.TabIndex = 1;
			this.buildValueCheckbox4.TextValue = "";
			this.buildValueCheckbox4.ToolTipText = "Sets the clip type. Legacy is the default value.";
			this.buildValueCheckbox4.ValueType = thor.BuildValueCheckboxType.DropDown;
			this.buildValueCheckbox4.ValueWidth = 80;
			this.buildValueCheckbox4.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox3
			// 
			this.buildValueCheckbox3.Checked = false;
			this.buildValueCheckbox3.CommandLineSwitch = "-noclipeconomy";
			this.buildValueCheckbox3.Label = "No Clip Economy";
			this.buildValueCheckbox3.Location = new System.Drawing.Point(239, 34);
			this.buildValueCheckbox3.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox3.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox3.Name = "buildValueCheckbox3";
			this.buildValueCheckbox3.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox3.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox3.TabIndex = 0;
			this.buildValueCheckbox3.TextValue = "";
			this.buildValueCheckbox3.ToolTipText = "Turn clipnode economy mode off.";
			this.buildValueCheckbox3.ValueWidth = 80;
			this.buildValueCheckbox3.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox11
			// 
			this.buildValueCheckbox11.Checked = false;
			this.buildValueCheckbox11.CommandLineSwitch = "-nonulltex";
			this.buildValueCheckbox11.Label = "No Null Textures";
			this.buildValueCheckbox11.Location = new System.Drawing.Point(15, 118);
			this.buildValueCheckbox11.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox11.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox11.Name = "buildValueCheckbox11";
			this.buildValueCheckbox11.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox11.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox11.TabIndex = 0;
			this.buildValueCheckbox11.TextValue = "";
			this.buildValueCheckbox11.ToolTipText = "Turns off null texture stripping.";
			this.buildValueCheckbox11.ValueWidth = 80;
			this.buildValueCheckbox11.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox2
			// 
			this.buildValueCheckbox2.Checked = false;
			this.buildValueCheckbox2.CommandLineSwitch = "-noclip";
			this.buildValueCheckbox2.Label = "No Clip";
			this.buildValueCheckbox2.Location = new System.Drawing.Point(239, 6);
			this.buildValueCheckbox2.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox2.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox2.Name = "buildValueCheckbox2";
			this.buildValueCheckbox2.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox2.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox2.TabIndex = 0;
			this.buildValueCheckbox2.TextValue = "";
			this.buildValueCheckbox2.ToolTipText = "Don\'t create clipping hull.";
			this.buildValueCheckbox2.ValueWidth = 80;
			this.buildValueCheckbox2.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox14
			// 
			this.buildValueCheckbox14.Checked = false;
			this.buildValueCheckbox14.CommandLineSwitch = "-wadautodetect";
			this.buildValueCheckbox14.Label = "WAD Auto Detect";
			this.buildValueCheckbox14.Location = new System.Drawing.Point(15, 34);
			this.buildValueCheckbox14.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox14.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox14.Name = "buildValueCheckbox14";
			this.buildValueCheckbox14.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox14.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox14.TabIndex = 0;
			this.buildValueCheckbox14.TextValue = "";
			this.buildValueCheckbox14.ToolTipText = "Force auto-detection of wadfiles.";
			this.buildValueCheckbox14.ValueWidth = 80;
			this.buildValueCheckbox14.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox1
			// 
			this.buildValueCheckbox1.Checked = false;
			this.buildValueCheckbox1.CommandLineSwitch = "-nowadtextures";
			this.buildValueCheckbox1.Label = "No WAD Textures";
			this.buildValueCheckbox1.Location = new System.Drawing.Point(15, 6);
			this.buildValueCheckbox1.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox1.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox1.Name = "buildValueCheckbox1";
			this.buildValueCheckbox1.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox1.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox1.TabIndex = 0;
			this.buildValueCheckbox1.TextValue = "";
			this.buildValueCheckbox1.ToolTipText = "Include all used textures into bsp.";
			this.buildValueCheckbox1.ValueWidth = 80;
			this.buildValueCheckbox1.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// tabBuildAdvancedBSP
			// 
			this.tabBuildAdvancedBSP.Controls.Add(this.buildValueCheckbox26);
			this.tabBuildAdvancedBSP.Controls.Add(this.buildValueCheckbox21);
			this.tabBuildAdvancedBSP.Controls.Add(this.buildValueCheckbox20);
			this.tabBuildAdvancedBSP.Controls.Add(this.buildValueCheckbox19);
			this.tabBuildAdvancedBSP.Controls.Add(this.buildValueCheckbox18);
			this.tabBuildAdvancedBSP.Controls.Add(this.buildValueCheckbox17);
			this.tabBuildAdvancedBSP.Controls.Add(this.buildValueCheckbox16);
			this.tabBuildAdvancedBSP.Controls.Add(this.buildValueCheckbox15);
			this.tabBuildAdvancedBSP.Location = new System.Drawing.Point(4, 22);
			this.tabBuildAdvancedBSP.Name = "tabBuildAdvancedBSP";
			this.tabBuildAdvancedBSP.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuildAdvancedBSP.Size = new System.Drawing.Size(449, 408);
			this.tabBuildAdvancedBSP.TabIndex = 1;
			this.tabBuildAdvancedBSP.Text = "BSP";
			this.tabBuildAdvancedBSP.UseVisualStyleBackColor = true;
			// 
			// buildValueCheckbox26
			// 
			this.buildValueCheckbox26.Checked = false;
			this.buildValueCheckbox26.CommandLineSwitch = "-nonulltex";
			this.buildValueCheckbox26.Label = "No Null Textures";
			this.buildValueCheckbox26.Location = new System.Drawing.Point(15, 202);
			this.buildValueCheckbox26.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox26.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox26.Name = "buildValueCheckbox26";
			this.buildValueCheckbox26.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox26.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox26.TabIndex = 2;
			this.buildValueCheckbox26.TextValue = "";
			this.buildValueCheckbox26.ToolTipText = "Don\'t strip NULL faces.";
			this.buildValueCheckbox26.ValueWidth = 80;
			this.buildValueCheckbox26.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox21
			// 
			this.buildValueCheckbox21.Checked = false;
			this.buildValueCheckbox21.CommandLineSwitch = "-noopt";
			this.buildValueCheckbox21.Label = "No Optimization";
			this.buildValueCheckbox21.Location = new System.Drawing.Point(15, 174);
			this.buildValueCheckbox21.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox21.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox21.Name = "buildValueCheckbox21";
			this.buildValueCheckbox21.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox21.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox21.TabIndex = 2;
			this.buildValueCheckbox21.TextValue = "";
			this.buildValueCheckbox21.ToolTipText = "Don\'t optimize planes on BSP write. Not for final runs.";
			this.buildValueCheckbox21.ValueWidth = 80;
			this.buildValueCheckbox21.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox20
			// 
			this.buildValueCheckbox20.Checked = false;
			this.buildValueCheckbox20.CommandLineSwitch = "-nofill";
			this.buildValueCheckbox20.Label = "No Fill";
			this.buildValueCheckbox20.Location = new System.Drawing.Point(15, 146);
			this.buildValueCheckbox20.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox20.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox20.Name = "buildValueCheckbox20";
			this.buildValueCheckbox20.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox20.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox20.TabIndex = 2;
			this.buildValueCheckbox20.TextValue = "";
			this.buildValueCheckbox20.ToolTipText = "Don\'t fill outside (will mask LEAKs.) Not for final runs.";
			this.buildValueCheckbox20.ValueWidth = 80;
			this.buildValueCheckbox20.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox19
			// 
			this.buildValueCheckbox19.Checked = false;
			this.buildValueCheckbox19.CommandLineSwitch = "-noclip";
			this.buildValueCheckbox19.Label = "No Clip";
			this.buildValueCheckbox19.Location = new System.Drawing.Point(15, 118);
			this.buildValueCheckbox19.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox19.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox19.Name = "buildValueCheckbox19";
			this.buildValueCheckbox19.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox19.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox19.TabIndex = 2;
			this.buildValueCheckbox19.TextValue = "";
			this.buildValueCheckbox19.ToolTipText = "Don\'t process the clipping hull. Not for final runs.";
			this.buildValueCheckbox19.ValueWidth = 80;
			this.buildValueCheckbox19.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox18
			// 
			this.buildValueCheckbox18.Checked = false;
			this.buildValueCheckbox18.CommandLineSwitch = "-notjunc";
			this.buildValueCheckbox18.Label = "No T-junctions";
			this.buildValueCheckbox18.Location = new System.Drawing.Point(15, 90);
			this.buildValueCheckbox18.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox18.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox18.Name = "buildValueCheckbox18";
			this.buildValueCheckbox18.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox18.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox18.TabIndex = 2;
			this.buildValueCheckbox18.TextValue = "";
			this.buildValueCheckbox18.ToolTipText = "Don\'t break edges on t-junctions. Not for final runs.";
			this.buildValueCheckbox18.ValueWidth = 80;
			this.buildValueCheckbox18.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox17
			// 
			this.buildValueCheckbox17.Checked = false;
			this.buildValueCheckbox17.CommandLineSwitch = "-maxnodesize";
			this.buildValueCheckbox17.Label = "Max Node Size";
			this.buildValueCheckbox17.Location = new System.Drawing.Point(15, 62);
			this.buildValueCheckbox17.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox17.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox17.Name = "buildValueCheckbox17";
			this.buildValueCheckbox17.NumValue = new decimal(new int[] {
									1024,
									0,
									0,
									0});
			this.buildValueCheckbox17.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox17.TabIndex = 2;
			this.buildValueCheckbox17.TextValue = "";
			this.buildValueCheckbox17.ToolTipText = "Sets the maximum portal node size.";
			this.buildValueCheckbox17.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox17.ValueWidth = 80;
			this.buildValueCheckbox17.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox16
			// 
			this.buildValueCheckbox16.Checked = false;
			this.buildValueCheckbox16.CommandLineSwitch = "-subdivide";
			this.buildValueCheckbox16.Label = "Subdivide";
			this.buildValueCheckbox16.Location = new System.Drawing.Point(15, 34);
			this.buildValueCheckbox16.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox16.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox16.Name = "buildValueCheckbox16";
			this.buildValueCheckbox16.NumValue = new decimal(new int[] {
									240,
									0,
									0,
									0});
			this.buildValueCheckbox16.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox16.TabIndex = 2;
			this.buildValueCheckbox16.TextValue = "";
			this.buildValueCheckbox16.ToolTipText = "Sets the face subdivide size.";
			this.buildValueCheckbox16.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox16.ValueWidth = 80;
			this.buildValueCheckbox16.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox15
			// 
			this.buildValueCheckbox15.Checked = false;
			this.buildValueCheckbox15.CommandLineSwitch = "-leakonly";
			this.buildValueCheckbox15.Label = "Leak Only";
			this.buildValueCheckbox15.Location = new System.Drawing.Point(15, 6);
			this.buildValueCheckbox15.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox15.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox15.Name = "buildValueCheckbox15";
			this.buildValueCheckbox15.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox15.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox15.TabIndex = 1;
			this.buildValueCheckbox15.TextValue = "";
			this.buildValueCheckbox15.ToolTipText = "Run BSP only enough to check for LEAKs.";
			this.buildValueCheckbox15.ValueWidth = 80;
			this.buildValueCheckbox15.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// tabBuildAdvancedVIS
			// 
			this.tabBuildAdvancedVIS.Controls.Add(this.buildValueCheckbox23);
			this.tabBuildAdvancedVIS.Controls.Add(this.buildValueCheckbox24);
			this.tabBuildAdvancedVIS.Controls.Add(this.buildValueCheckbox22);
			this.tabBuildAdvancedVIS.Location = new System.Drawing.Point(4, 22);
			this.tabBuildAdvancedVIS.Name = "tabBuildAdvancedVIS";
			this.tabBuildAdvancedVIS.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuildAdvancedVIS.Size = new System.Drawing.Size(449, 408);
			this.tabBuildAdvancedVIS.TabIndex = 2;
			this.tabBuildAdvancedVIS.Text = "VIS";
			this.tabBuildAdvancedVIS.UseVisualStyleBackColor = true;
			// 
			// buildValueCheckbox23
			// 
			this.buildValueCheckbox23.Checked = false;
			this.buildValueCheckbox23.CommandLineSwitch = "-fast";
			this.buildValueCheckbox23.Label = "Fast Vis";
			this.buildValueCheckbox23.Location = new System.Drawing.Point(15, 34);
			this.buildValueCheckbox23.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox23.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox23.Name = "buildValueCheckbox23";
			this.buildValueCheckbox23.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox23.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox23.TabIndex = 4;
			this.buildValueCheckbox23.TextValue = "";
			this.buildValueCheckbox23.ToolTipText = "Fast vis.";
			this.buildValueCheckbox23.ValueWidth = 80;
			this.buildValueCheckbox23.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox24
			// 
			this.buildValueCheckbox24.Checked = false;
			this.buildValueCheckbox24.CommandLineSwitch = "-maxdistance";
			this.buildValueCheckbox24.Label = "Max Distance";
			this.buildValueCheckbox24.Location = new System.Drawing.Point(15, 62);
			this.buildValueCheckbox24.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox24.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox24.Name = "buildValueCheckbox24";
			this.buildValueCheckbox24.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox24.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox24.TabIndex = 3;
			this.buildValueCheckbox24.TextValue = "";
			this.buildValueCheckbox24.ToolTipText = "Alter the maximum distance for visibility.";
			this.buildValueCheckbox24.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox24.ValueWidth = 80;
			this.buildValueCheckbox24.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox22
			// 
			this.buildValueCheckbox22.Checked = false;
			this.buildValueCheckbox22.CommandLineSwitch = "-full";
			this.buildValueCheckbox22.Label = "Full Vis";
			this.buildValueCheckbox22.Location = new System.Drawing.Point(15, 6);
			this.buildValueCheckbox22.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox22.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox22.Name = "buildValueCheckbox22";
			this.buildValueCheckbox22.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox22.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox22.TabIndex = 3;
			this.buildValueCheckbox22.TextValue = "";
			this.buildValueCheckbox22.ToolTipText = "Full vis.";
			this.buildValueCheckbox22.ValueWidth = 80;
			this.buildValueCheckbox22.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// tabBuildAdvancedRAD
			// 
			this.tabBuildAdvancedRAD.Controls.Add(this.groupBox15);
			this.tabBuildAdvancedRAD.Controls.Add(this.groupBox2);
			this.tabBuildAdvancedRAD.Controls.Add(this.groupBox1);
			this.tabBuildAdvancedRAD.Controls.Add(this.buildValueCheckbox57);
			this.tabBuildAdvancedRAD.Controls.Add(this.buildValueCheckbox55);
			this.tabBuildAdvancedRAD.Location = new System.Drawing.Point(4, 22);
			this.tabBuildAdvancedRAD.Name = "tabBuildAdvancedRAD";
			this.tabBuildAdvancedRAD.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuildAdvancedRAD.Size = new System.Drawing.Size(449, 408);
			this.tabBuildAdvancedRAD.TabIndex = 3;
			this.tabBuildAdvancedRAD.Text = "RAD";
			this.tabBuildAdvancedRAD.UseVisualStyleBackColor = true;
			// 
			// groupBox15
			// 
			this.groupBox15.Controls.Add(this.buildValueCheckbox44);
			this.groupBox15.Controls.Add(this.buildValueCheckbox45);
			this.groupBox15.Controls.Add(this.buildValueCheckbox46);
			this.groupBox15.Controls.Add(this.buildValueCheckbox56);
			this.groupBox15.Controls.Add(this.buildValueCheckbox47);
			this.groupBox15.Controls.Add(this.buildValueCheckbox54);
			this.groupBox15.Controls.Add(this.buildValueCheckbox52);
			this.groupBox15.Controls.Add(this.buildValueCheckbox50);
			this.groupBox15.Controls.Add(this.buildValueCheckbox48);
			this.groupBox15.Controls.Add(this.buildValueCheckbox53);
			this.groupBox15.Controls.Add(this.buildValueCheckbox51);
			this.groupBox15.Location = new System.Drawing.Point(270, 6);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(173, 340);
			this.groupBox15.TabIndex = 8;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Numbers";
			// 
			// buildValueCheckbox44
			// 
			this.buildValueCheckbox44.Checked = false;
			this.buildValueCheckbox44.CommandLineSwitch = "-bounce";
			this.buildValueCheckbox44.Label = "Bounce";
			this.buildValueCheckbox44.Location = new System.Drawing.Point(6, 19);
			this.buildValueCheckbox44.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox44.MinValue = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.buildValueCheckbox44.Name = "buildValueCheckbox44";
			this.buildValueCheckbox44.NumValue = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.buildValueCheckbox44.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox44.TabIndex = 5;
			this.buildValueCheckbox44.TextValue = "";
			this.buildValueCheckbox44.ToolTipText = "Set number of radiosity bounces.";
			this.buildValueCheckbox44.ValueType = thor.BuildValueCheckboxType.Integer;
			this.buildValueCheckbox44.ValueWidth = 60;
			this.buildValueCheckbox44.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox45
			// 
			this.buildValueCheckbox45.Checked = false;
			this.buildValueCheckbox45.CommandLineSwitch = "-maxlight";
			this.buildValueCheckbox45.Label = "Max Light";
			this.buildValueCheckbox45.Location = new System.Drawing.Point(6, 47);
			this.buildValueCheckbox45.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox45.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox45.Name = "buildValueCheckbox45";
			this.buildValueCheckbox45.NumValue = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.buildValueCheckbox45.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox45.TabIndex = 5;
			this.buildValueCheckbox45.TextValue = "";
			this.buildValueCheckbox45.ToolTipText = "Set maximum light intensity value.";
			this.buildValueCheckbox45.ValueType = thor.BuildValueCheckboxType.Integer;
			this.buildValueCheckbox45.ValueWidth = 60;
			this.buildValueCheckbox45.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox46
			// 
			this.buildValueCheckbox46.Checked = false;
			this.buildValueCheckbox46.CommandLineSwitch = "-smooth";
			this.buildValueCheckbox46.Label = "Smooth";
			this.buildValueCheckbox46.Location = new System.Drawing.Point(6, 75);
			this.buildValueCheckbox46.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox46.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox46.Name = "buildValueCheckbox46";
			this.buildValueCheckbox46.NumValue = new decimal(new int[] {
									50,
									0,
									0,
									0});
			this.buildValueCheckbox46.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox46.TabIndex = 5;
			this.buildValueCheckbox46.TextValue = "";
			this.buildValueCheckbox46.ToolTipText = "Set smoothing threshold for blending (in degrees).";
			this.buildValueCheckbox46.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox46.ValueWidth = 60;
			this.buildValueCheckbox46.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox56
			// 
			this.buildValueCheckbox56.Checked = false;
			this.buildValueCheckbox56.CommandLineSwitch = "-sky";
			this.buildValueCheckbox56.Label = "Sky";
			this.buildValueCheckbox56.Location = new System.Drawing.Point(6, 299);
			this.buildValueCheckbox56.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox56.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox56.Name = "buildValueCheckbox56";
			this.buildValueCheckbox56.NumValue = new decimal(new int[] {
									5,
									0,
									0,
									65536});
			this.buildValueCheckbox56.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox56.TabIndex = 5;
			this.buildValueCheckbox56.TextValue = "";
			this.buildValueCheckbox56.ToolTipText = "Set ambient sunlight contribution in the shade outside.";
			this.buildValueCheckbox56.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox56.ValueWidth = 60;
			this.buildValueCheckbox56.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox47
			// 
			this.buildValueCheckbox47.Checked = false;
			this.buildValueCheckbox47.CommandLineSwitch = "-chop";
			this.buildValueCheckbox47.Label = "Chop";
			this.buildValueCheckbox47.Location = new System.Drawing.Point(6, 103);
			this.buildValueCheckbox47.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox47.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox47.Name = "buildValueCheckbox47";
			this.buildValueCheckbox47.NumValue = new decimal(new int[] {
									64,
									0,
									0,
									0});
			this.buildValueCheckbox47.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox47.TabIndex = 5;
			this.buildValueCheckbox47.TextValue = "";
			this.buildValueCheckbox47.ToolTipText = "Set radiosity patch size for normal textures.";
			this.buildValueCheckbox47.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox47.ValueWidth = 60;
			this.buildValueCheckbox47.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox54
			// 
			this.buildValueCheckbox54.Checked = false;
			this.buildValueCheckbox54.CommandLineSwitch = "-gamma";
			this.buildValueCheckbox54.Label = "Gamma";
			this.buildValueCheckbox54.Location = new System.Drawing.Point(6, 271);
			this.buildValueCheckbox54.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox54.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox54.Name = "buildValueCheckbox54";
			this.buildValueCheckbox54.NumValue = new decimal(new int[] {
									5,
									0,
									0,
									65536});
			this.buildValueCheckbox54.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox54.TabIndex = 5;
			this.buildValueCheckbox54.TextValue = "";
			this.buildValueCheckbox54.ToolTipText = "Set global gamma value.";
			this.buildValueCheckbox54.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox54.ValueWidth = 60;
			this.buildValueCheckbox54.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox52
			// 
			this.buildValueCheckbox52.Checked = false;
			this.buildValueCheckbox52.CommandLineSwitch = "-scale";
			this.buildValueCheckbox52.Label = "Scale";
			this.buildValueCheckbox52.Location = new System.Drawing.Point(6, 243);
			this.buildValueCheckbox52.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox52.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox52.Name = "buildValueCheckbox52";
			this.buildValueCheckbox52.NumValue = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.buildValueCheckbox52.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox52.TabIndex = 5;
			this.buildValueCheckbox52.TextValue = "";
			this.buildValueCheckbox52.ToolTipText = "Set global light scaling value.";
			this.buildValueCheckbox52.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox52.ValueWidth = 60;
			this.buildValueCheckbox52.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox50
			// 
			this.buildValueCheckbox50.Checked = false;
			this.buildValueCheckbox50.CommandLineSwitch = "-coring";
			this.buildValueCheckbox50.Label = "Coring";
			this.buildValueCheckbox50.Location = new System.Drawing.Point(6, 159);
			this.buildValueCheckbox50.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox50.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox50.Name = "buildValueCheckbox50";
			this.buildValueCheckbox50.NumValue = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.buildValueCheckbox50.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox50.TabIndex = 5;
			this.buildValueCheckbox50.TextValue = "";
			this.buildValueCheckbox50.ToolTipText = "Set lighting threshold before blackness.";
			this.buildValueCheckbox50.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox50.ValueWidth = 60;
			this.buildValueCheckbox50.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox48
			// 
			this.buildValueCheckbox48.Checked = false;
			this.buildValueCheckbox48.CommandLineSwitch = "-texchop";
			this.buildValueCheckbox48.Label = "Tex Chop";
			this.buildValueCheckbox48.Location = new System.Drawing.Point(6, 131);
			this.buildValueCheckbox48.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox48.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox48.Name = "buildValueCheckbox48";
			this.buildValueCheckbox48.NumValue = new decimal(new int[] {
									32,
									0,
									0,
									0});
			this.buildValueCheckbox48.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox48.TabIndex = 5;
			this.buildValueCheckbox48.TextValue = "";
			this.buildValueCheckbox48.ToolTipText = "Set radiosity patch size for texture light faces.";
			this.buildValueCheckbox48.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox48.ValueWidth = 60;
			this.buildValueCheckbox48.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox53
			// 
			this.buildValueCheckbox53.Checked = false;
			this.buildValueCheckbox53.CommandLineSwitch = "-fade";
			this.buildValueCheckbox53.Label = "Fade";
			this.buildValueCheckbox53.Location = new System.Drawing.Point(6, 215);
			this.buildValueCheckbox53.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox53.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox53.Name = "buildValueCheckbox53";
			this.buildValueCheckbox53.NumValue = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.buildValueCheckbox53.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox53.TabIndex = 5;
			this.buildValueCheckbox53.TextValue = "";
			this.buildValueCheckbox53.ToolTipText = "Set global fade. (larger values = shorter lights)";
			this.buildValueCheckbox53.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox53.ValueWidth = 60;
			this.buildValueCheckbox53.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox51
			// 
			this.buildValueCheckbox51.Checked = false;
			this.buildValueCheckbox51.CommandLineSwitch = "-dlight";
			this.buildValueCheckbox51.Label = "Direct Light";
			this.buildValueCheckbox51.Location = new System.Drawing.Point(6, 187);
			this.buildValueCheckbox51.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox51.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox51.Name = "buildValueCheckbox51";
			this.buildValueCheckbox51.NumValue = new decimal(new int[] {
									25,
									0,
									0,
									0});
			this.buildValueCheckbox51.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox51.TabIndex = 5;
			this.buildValueCheckbox51.TextValue = "";
			this.buildValueCheckbox51.ToolTipText = "Set direct lighting threshold.";
			this.buildValueCheckbox51.ValueType = thor.BuildValueCheckboxType.Decimal;
			this.buildValueCheckbox51.ValueWidth = 60;
			this.buildValueCheckbox51.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.buildValueCheckbox25);
			this.groupBox2.Controls.Add(this.buildValueCheckbox28);
			this.groupBox2.Controls.Add(this.buildValueCheckbox38);
			this.groupBox2.Controls.Add(this.buildValueCheckbox35);
			this.groupBox2.Controls.Add(this.buildValueCheckbox37);
			this.groupBox2.Controls.Add(this.buildValueCheckbox29);
			this.groupBox2.Controls.Add(this.buildValueCheckbox33);
			this.groupBox2.Controls.Add(this.buildValueCheckbox68);
			this.groupBox2.Controls.Add(this.buildValueCheckbox31);
			this.groupBox2.Controls.Add(this.buildValueCheckbox34);
			this.groupBox2.Controls.Add(this.buildValueCheckbox49);
			this.groupBox2.Controls.Add(this.buildValueCheckbox27);
			this.groupBox2.Controls.Add(this.buildValueCheckbox30);
			this.groupBox2.Controls.Add(this.buildValueCheckbox32);
			this.groupBox2.Controls.Add(this.buildValueCheckbox36);
			this.groupBox2.Location = new System.Drawing.Point(6, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(258, 245);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Switches";
			// 
			// buildValueCheckbox25
			// 
			this.buildValueCheckbox25.Checked = false;
			this.buildValueCheckbox25.CommandLineSwitch = "-sparse";
			this.buildValueCheckbox25.Label = "Sparse";
			this.buildValueCheckbox25.Location = new System.Drawing.Point(6, 19);
			this.buildValueCheckbox25.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox25.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox25.Name = "buildValueCheckbox25";
			this.buildValueCheckbox25.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox25.Size = new System.Drawing.Size(86, 22);
			this.buildValueCheckbox25.TabIndex = 5;
			this.buildValueCheckbox25.TextValue = "";
			this.buildValueCheckbox25.ToolTipText = "Enable low memory vismatrix algorithm.";
			this.buildValueCheckbox25.ValueWidth = 80;
			this.buildValueCheckbox25.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox28
			// 
			this.buildValueCheckbox28.Checked = false;
			this.buildValueCheckbox28.CommandLineSwitch = "-extra";
			this.buildValueCheckbox28.Label = "Extra";
			this.buildValueCheckbox28.Location = new System.Drawing.Point(6, 75);
			this.buildValueCheckbox28.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox28.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox28.Name = "buildValueCheckbox28";
			this.buildValueCheckbox28.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox28.Size = new System.Drawing.Size(86, 22);
			this.buildValueCheckbox28.TabIndex = 5;
			this.buildValueCheckbox28.TextValue = "";
			this.buildValueCheckbox28.ToolTipText = "Improve lighting quality by doing 9 point oversampling.";
			this.buildValueCheckbox28.ValueWidth = 80;
			this.buildValueCheckbox28.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox38
			// 
			this.buildValueCheckbox38.Checked = false;
			this.buildValueCheckbox38.CommandLineSwitch = "-rgbtransfers";
			this.buildValueCheckbox38.Label = "RGB Transfers";
			this.buildValueCheckbox38.Location = new System.Drawing.Point(6, 159);
			this.buildValueCheckbox38.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox38.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox38.Name = "buildValueCheckbox38";
			this.buildValueCheckbox38.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox38.Size = new System.Drawing.Size(106, 22);
			this.buildValueCheckbox38.TabIndex = 5;
			this.buildValueCheckbox38.TextValue = "";
			this.buildValueCheckbox38.ToolTipText = "Enables RGB Transfers (for custom shadows.)";
			this.buildValueCheckbox38.ValueWidth = 80;
			this.buildValueCheckbox38.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox35
			// 
			this.buildValueCheckbox35.Checked = false;
			this.buildValueCheckbox35.CommandLineSwitch = "-nodiffuse";
			this.buildValueCheckbox35.Label = "No Diffuse";
			this.buildValueCheckbox35.Location = new System.Drawing.Point(137, 131);
			this.buildValueCheckbox35.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox35.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox35.Name = "buildValueCheckbox35";
			this.buildValueCheckbox35.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox35.Size = new System.Drawing.Size(109, 22);
			this.buildValueCheckbox35.TabIndex = 5;
			this.buildValueCheckbox35.TextValue = "";
			this.buildValueCheckbox35.ToolTipText = "Disables light_environment diffuse hack.";
			this.buildValueCheckbox35.ValueWidth = 80;
			this.buildValueCheckbox35.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox37
			// 
			this.buildValueCheckbox37.Checked = false;
			this.buildValueCheckbox37.CommandLineSwitch = "-customshadowwithbounce";
			this.buildValueCheckbox37.Label = "Bounce Shadows";
			this.buildValueCheckbox37.Location = new System.Drawing.Point(6, 187);
			this.buildValueCheckbox37.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox37.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox37.Name = "buildValueCheckbox37";
			this.buildValueCheckbox37.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox37.Size = new System.Drawing.Size(106, 22);
			this.buildValueCheckbox37.TabIndex = 5;
			this.buildValueCheckbox37.TextValue = "";
			this.buildValueCheckbox37.ToolTipText = "Enables custom shadows with bounce light.";
			this.buildValueCheckbox37.ValueWidth = 80;
			this.buildValueCheckbox37.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox29
			// 
			this.buildValueCheckbox29.Checked = false;
			this.buildValueCheckbox29.CommandLineSwitch = "-circus";
			this.buildValueCheckbox29.Label = "Circus";
			this.buildValueCheckbox29.Location = new System.Drawing.Point(6, 103);
			this.buildValueCheckbox29.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox29.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox29.Name = "buildValueCheckbox29";
			this.buildValueCheckbox29.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox29.Size = new System.Drawing.Size(86, 22);
			this.buildValueCheckbox29.TabIndex = 5;
			this.buildValueCheckbox29.TextValue = "";
			this.buildValueCheckbox29.ToolTipText = "Enable \'circus\' mode for locating unlit lightmaps.";
			this.buildValueCheckbox29.ValueWidth = 80;
			this.buildValueCheckbox29.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox33
			// 
			this.buildValueCheckbox33.Checked = false;
			this.buildValueCheckbox33.CommandLineSwitch = "-incremental";
			this.buildValueCheckbox33.Label = "Incremental";
			this.buildValueCheckbox33.Location = new System.Drawing.Point(6, 131);
			this.buildValueCheckbox33.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox33.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox33.Name = "buildValueCheckbox33";
			this.buildValueCheckbox33.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox33.Size = new System.Drawing.Size(106, 22);
			this.buildValueCheckbox33.TabIndex = 5;
			this.buildValueCheckbox33.TextValue = "";
			this.buildValueCheckbox33.ToolTipText = "Use or create an incremental transfer list file.";
			this.buildValueCheckbox33.ValueWidth = 80;
			this.buildValueCheckbox33.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox68
			// 
			this.buildValueCheckbox68.Checked = false;
			this.buildValueCheckbox68.CommandLineSwitch = "-nodynbounce";
			this.buildValueCheckbox68.Label = "No Dyn. Bounce";
			this.buildValueCheckbox68.Location = new System.Drawing.Point(137, 187);
			this.buildValueCheckbox68.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox68.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox68.Name = "buildValueCheckbox68";
			this.buildValueCheckbox68.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox68.Size = new System.Drawing.Size(109, 22);
			this.buildValueCheckbox68.TabIndex = 5;
			this.buildValueCheckbox68.TextValue = "";
			this.buildValueCheckbox68.ToolTipText = "Disable bounce for dynamic lights.";
			this.buildValueCheckbox68.ValueWidth = 80;
			this.buildValueCheckbox68.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox31
			// 
			this.buildValueCheckbox31.Checked = false;
			this.buildValueCheckbox31.CommandLineSwitch = "-nolerp";
			this.buildValueCheckbox31.Label = "No Interpolation";
			this.buildValueCheckbox31.Location = new System.Drawing.Point(137, 159);
			this.buildValueCheckbox31.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox31.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox31.Name = "buildValueCheckbox31";
			this.buildValueCheckbox31.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox31.Size = new System.Drawing.Size(109, 22);
			this.buildValueCheckbox31.TabIndex = 5;
			this.buildValueCheckbox31.TextValue = "";
			this.buildValueCheckbox31.ToolTipText = "Disable radiosity interpolation, nearest point instead.";
			this.buildValueCheckbox31.ValueWidth = 80;
			this.buildValueCheckbox31.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox34
			// 
			this.buildValueCheckbox34.Checked = false;
			this.buildValueCheckbox34.CommandLineSwitch = "-dump";
			this.buildValueCheckbox34.Label = "Dump";
			this.buildValueCheckbox34.Location = new System.Drawing.Point(6, 47);
			this.buildValueCheckbox34.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox34.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox34.Name = "buildValueCheckbox34";
			this.buildValueCheckbox34.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox34.Size = new System.Drawing.Size(86, 22);
			this.buildValueCheckbox34.TabIndex = 5;
			this.buildValueCheckbox34.TextValue = "";
			this.buildValueCheckbox34.ToolTipText = "Dumps light patches to a file for hlrad debugging info.";
			this.buildValueCheckbox34.ValueWidth = 80;
			this.buildValueCheckbox34.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox49
			// 
			this.buildValueCheckbox49.Checked = false;
			this.buildValueCheckbox49.CommandLineSwitch = "-notexscale";
			this.buildValueCheckbox49.Label = "No Tex Scale";
			this.buildValueCheckbox49.Location = new System.Drawing.Point(6, 215);
			this.buildValueCheckbox49.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox49.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox49.Name = "buildValueCheckbox49";
			this.buildValueCheckbox49.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox49.Size = new System.Drawing.Size(106, 22);
			this.buildValueCheckbox49.TabIndex = 5;
			this.buildValueCheckbox49.TextValue = "";
			this.buildValueCheckbox49.ToolTipText = "Do not scale radiosity patches with texture scale.";
			this.buildValueCheckbox49.ValueWidth = 60;
			this.buildValueCheckbox49.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox27
			// 
			this.buildValueCheckbox27.Checked = false;
			this.buildValueCheckbox27.CommandLineSwitch = "-nomatrix";
			this.buildValueCheckbox27.Label = "No Matrix";
			this.buildValueCheckbox27.Location = new System.Drawing.Point(137, 19);
			this.buildValueCheckbox27.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox27.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox27.Name = "buildValueCheckbox27";
			this.buildValueCheckbox27.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox27.Size = new System.Drawing.Size(109, 22);
			this.buildValueCheckbox27.TabIndex = 5;
			this.buildValueCheckbox27.TextValue = "";
			this.buildValueCheckbox27.ToolTipText = "Disable usage of vismatrix entirely.";
			this.buildValueCheckbox27.ValueWidth = 80;
			this.buildValueCheckbox27.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox30
			// 
			this.buildValueCheckbox30.Checked = false;
			this.buildValueCheckbox30.CommandLineSwitch = "-noopaque";
			this.buildValueCheckbox30.Label = "No Opaque";
			this.buildValueCheckbox30.Location = new System.Drawing.Point(137, 47);
			this.buildValueCheckbox30.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox30.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox30.Name = "buildValueCheckbox30";
			this.buildValueCheckbox30.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox30.Size = new System.Drawing.Size(109, 22);
			this.buildValueCheckbox30.TabIndex = 5;
			this.buildValueCheckbox30.TextValue = "";
			this.buildValueCheckbox30.ToolTipText = "Disable the opaque zhlt_lightflags for this compile.";
			this.buildValueCheckbox30.ValueWidth = 80;
			this.buildValueCheckbox30.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox32
			// 
			this.buildValueCheckbox32.Checked = false;
			this.buildValueCheckbox32.CommandLineSwitch = "-noskyfix";
			this.buildValueCheckbox32.Label = "No Sky Fix";
			this.buildValueCheckbox32.Location = new System.Drawing.Point(137, 75);
			this.buildValueCheckbox32.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox32.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox32.Name = "buildValueCheckbox32";
			this.buildValueCheckbox32.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox32.Size = new System.Drawing.Size(109, 22);
			this.buildValueCheckbox32.TabIndex = 5;
			this.buildValueCheckbox32.TextValue = "";
			this.buildValueCheckbox32.ToolTipText = "Disable light_environment being global.";
			this.buildValueCheckbox32.ValueWidth = 80;
			this.buildValueCheckbox32.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox36
			// 
			this.buildValueCheckbox36.Checked = false;
			this.buildValueCheckbox36.CommandLineSwitch = "-nospotpoints";
			this.buildValueCheckbox36.Label = "No Spot Points";
			this.buildValueCheckbox36.Location = new System.Drawing.Point(137, 103);
			this.buildValueCheckbox36.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox36.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox36.Name = "buildValueCheckbox36";
			this.buildValueCheckbox36.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox36.Size = new System.Drawing.Size(109, 22);
			this.buildValueCheckbox36.TabIndex = 5;
			this.buildValueCheckbox36.TextValue = "";
			this.buildValueCheckbox36.ToolTipText = "Disables light_spot spherical point sources.";
			this.buildValueCheckbox36.ValueWidth = 80;
			this.buildValueCheckbox36.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buildValueCheckbox39);
			this.groupBox1.Controls.Add(this.buildValueCheckbox41);
			this.groupBox1.Controls.Add(this.buildValueCheckbox40);
			this.groupBox1.Controls.Add(this.buildValueCheckbox42);
			this.groupBox1.Controls.Add(this.buildValueCheckbox43);
			this.groupBox1.Location = new System.Drawing.Point(6, 257);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(258, 114);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Colours";
			// 
			// buildValueCheckbox39
			// 
			this.buildValueCheckbox39.Checked = false;
			this.buildValueCheckbox39.CheckWidth = 75;
			this.buildValueCheckbox39.CommandLineSwitch = "-ambient";
			this.buildValueCheckbox39.Label = "Ambient";
			this.buildValueCheckbox39.Location = new System.Drawing.Point(6, 19);
			this.buildValueCheckbox39.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox39.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox39.Name = "buildValueCheckbox39";
			this.buildValueCheckbox39.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox39.Size = new System.Drawing.Size(102, 22);
			this.buildValueCheckbox39.TabIndex = 5;
			this.buildValueCheckbox39.TextValue = "";
			this.buildValueCheckbox39.ToolTipText = "Set ambient world light.";
			this.buildValueCheckbox39.ValueType = thor.BuildValueCheckboxType.Colour;
			this.buildValueCheckbox39.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox41
			// 
			this.buildValueCheckbox41.Checked = false;
			this.buildValueCheckbox41.CheckWidth = 75;
			this.buildValueCheckbox41.CommandLineSwitch = "-colourscale";
			this.buildValueCheckbox41.Label = "Scale";
			this.buildValueCheckbox41.Location = new System.Drawing.Point(137, 47);
			this.buildValueCheckbox41.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox41.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox41.Name = "buildValueCheckbox41";
			this.buildValueCheckbox41.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox41.Size = new System.Drawing.Size(102, 22);
			this.buildValueCheckbox41.TabIndex = 5;
			this.buildValueCheckbox41.TextValue = "";
			this.buildValueCheckbox41.ToolTipText = "Sets different lightscale values.";
			this.buildValueCheckbox41.ValueType = thor.BuildValueCheckboxType.Colour;
			this.buildValueCheckbox41.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox40
			// 
			this.buildValueCheckbox40.Checked = false;
			this.buildValueCheckbox40.CheckWidth = 75;
			this.buildValueCheckbox40.CommandLineSwitch = "-colourgamma";
			this.buildValueCheckbox40.Label = "Gamma";
			this.buildValueCheckbox40.Location = new System.Drawing.Point(6, 47);
			this.buildValueCheckbox40.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox40.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox40.Name = "buildValueCheckbox40";
			this.buildValueCheckbox40.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox40.Size = new System.Drawing.Size(102, 22);
			this.buildValueCheckbox40.TabIndex = 5;
			this.buildValueCheckbox40.TextValue = "";
			this.buildValueCheckbox40.ToolTipText = "Sets different gamma values.";
			this.buildValueCheckbox40.ValueType = thor.BuildValueCheckboxType.Colour;
			this.buildValueCheckbox40.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox42
			// 
			this.buildValueCheckbox42.Checked = false;
			this.buildValueCheckbox42.CheckWidth = 75;
			this.buildValueCheckbox42.CommandLineSwitch = "-colourjitter";
			this.buildValueCheckbox42.Label = "Jitter";
			this.buildValueCheckbox42.Location = new System.Drawing.Point(137, 19);
			this.buildValueCheckbox42.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox42.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox42.Name = "buildValueCheckbox42";
			this.buildValueCheckbox42.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox42.Size = new System.Drawing.Size(102, 22);
			this.buildValueCheckbox42.TabIndex = 5;
			this.buildValueCheckbox42.TextValue = "";
			this.buildValueCheckbox42.ToolTipText = "Adds noise, independent colours, for dithering.";
			this.buildValueCheckbox42.ValueType = thor.BuildValueCheckboxType.Colour;
			this.buildValueCheckbox42.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox43
			// 
			this.buildValueCheckbox43.Checked = false;
			this.buildValueCheckbox43.CheckWidth = 75;
			this.buildValueCheckbox43.CommandLineSwitch = "-softlight";
			this.buildValueCheckbox43.Label = "Soft Light";
			this.buildValueCheckbox43.Location = new System.Drawing.Point(6, 75);
			this.buildValueCheckbox43.MaxValue = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.buildValueCheckbox43.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox43.Name = "buildValueCheckbox43";
			this.buildValueCheckbox43.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox43.Size = new System.Drawing.Size(147, 22);
			this.buildValueCheckbox43.TabIndex = 5;
			this.buildValueCheckbox43.TextValue = "";
			this.buildValueCheckbox43.ToolTipText = "Adds noise, independent colours, for dithering.";
			this.buildValueCheckbox43.ValueType = thor.BuildValueCheckboxType.ColourBrightness;
			this.buildValueCheckbox43.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox57
			// 
			this.buildValueCheckbox57.Checked = false;
			this.buildValueCheckbox57.CheckWidth = 80;
			this.buildValueCheckbox57.CommandLineSwitch = "-lights";
			this.buildValueCheckbox57.Label = "Lights File";
			this.buildValueCheckbox57.Location = new System.Drawing.Point(6, 380);
			this.buildValueCheckbox57.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox57.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox57.Name = "buildValueCheckbox57";
			this.buildValueCheckbox57.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox57.Size = new System.Drawing.Size(440, 22);
			this.buildValueCheckbox57.TabIndex = 5;
			this.buildValueCheckbox57.TextValue = "";
			this.buildValueCheckbox57.ToolTipText = "Manually specify a lights.rad file to use.";
			this.buildValueCheckbox57.ValueType = thor.BuildValueCheckboxType.File;
			this.buildValueCheckbox57.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox55
			// 
			this.buildValueCheckbox55.Checked = false;
			this.buildValueCheckbox55.CheckWidth = 70;
			this.buildValueCheckbox55.CommandLineSwitch = "";
			this.buildValueCheckbox55.DropDownFormatting = "-falloff 1?-falloff 2";
			this.buildValueCheckbox55.DropDownItems.AddRange(new object[] {
									"Inv Linear",
									"Inv Square"});
			this.buildValueCheckbox55.Label = "Falloff";
			this.buildValueCheckbox55.Location = new System.Drawing.Point(276, 352);
			this.buildValueCheckbox55.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox55.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox55.Name = "buildValueCheckbox55";
			this.buildValueCheckbox55.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox55.Size = new System.Drawing.Size(161, 22);
			this.buildValueCheckbox55.TabIndex = 5;
			this.buildValueCheckbox55.TextValue = "";
			this.buildValueCheckbox55.ToolTipText = "Set global falloff mode.";
			this.buildValueCheckbox55.ValueType = thor.BuildValueCheckboxType.DropDown;
			this.buildValueCheckbox55.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// tabBuildAdvancedShared
			// 
			this.tabBuildAdvancedShared.Controls.Add(this.buildValueCheckbox67);
			this.tabBuildAdvancedShared.Controls.Add(this.buildValueCheckbox62);
			this.tabBuildAdvancedShared.Controls.Add(this.buildValueCheckbox66);
			this.tabBuildAdvancedShared.Controls.Add(this.buildValueCheckbox61);
			this.tabBuildAdvancedShared.Controls.Add(this.buildValueCheckbox65);
			this.tabBuildAdvancedShared.Controls.Add(this.buildValueCheckbox60);
			this.tabBuildAdvancedShared.Controls.Add(this.buildValueCheckbox64);
			this.tabBuildAdvancedShared.Controls.Add(this.buildValueCheckbox59);
			this.tabBuildAdvancedShared.Controls.Add(this.buildValueCheckbox63);
			this.tabBuildAdvancedShared.Controls.Add(this.buildValueCheckbox58);
			this.tabBuildAdvancedShared.Location = new System.Drawing.Point(4, 22);
			this.tabBuildAdvancedShared.Name = "tabBuildAdvancedShared";
			this.tabBuildAdvancedShared.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuildAdvancedShared.Size = new System.Drawing.Size(449, 408);
			this.tabBuildAdvancedShared.TabIndex = 4;
			this.tabBuildAdvancedShared.Text = "Shared";
			this.tabBuildAdvancedShared.UseVisualStyleBackColor = true;
			// 
			// buildValueCheckbox67
			// 
			this.buildValueCheckbox67.Checked = false;
			this.buildValueCheckbox67.CommandLineSwitch = "-dev";
			this.buildValueCheckbox67.DropDownFormatting = "switch index";
			this.buildValueCheckbox67.DropDownItems.AddRange(new object[] {
									"Always",
									"Error",
									"Warning",
									"Message",
									"Fluff",
									"Spam",
									"Megaspam"});
			this.buildValueCheckbox67.Label = "Developer";
			this.buildValueCheckbox67.Location = new System.Drawing.Point(15, 254);
			this.buildValueCheckbox67.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox67.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox67.Name = "buildValueCheckbox67";
			this.buildValueCheckbox67.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox67.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox67.TabIndex = 0;
			this.buildValueCheckbox67.TextValue = "";
			this.buildValueCheckbox67.ToolTipText = "Compile with developer message.";
			this.buildValueCheckbox67.ValueType = thor.BuildValueCheckboxType.DropDown;
			this.buildValueCheckbox67.ValueWidth = 80;
			this.buildValueCheckbox67.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox62
			// 
			this.buildValueCheckbox62.Checked = false;
			this.buildValueCheckbox62.CommandLineSwitch = "-nolog";
			this.buildValueCheckbox62.Label = "No Log";
			this.buildValueCheckbox62.Location = new System.Drawing.Point(15, 116);
			this.buildValueCheckbox62.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox62.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox62.Name = "buildValueCheckbox62";
			this.buildValueCheckbox62.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox62.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox62.TabIndex = 0;
			this.buildValueCheckbox62.TextValue = "";
			this.buildValueCheckbox62.ToolTipText = "Do not generate the compile logfiles.";
			this.buildValueCheckbox62.ValueWidth = 80;
			this.buildValueCheckbox62.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox66
			// 
			this.buildValueCheckbox66.Checked = false;
			this.buildValueCheckbox66.CommandLineSwitch = "-noinfo";
			this.buildValueCheckbox66.Label = "No Info";
			this.buildValueCheckbox66.Location = new System.Drawing.Point(15, 228);
			this.buildValueCheckbox66.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox66.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox66.Name = "buildValueCheckbox66";
			this.buildValueCheckbox66.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox66.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox66.TabIndex = 0;
			this.buildValueCheckbox66.TextValue = "";
			this.buildValueCheckbox66.ToolTipText = "Do not show tool configuration information.";
			this.buildValueCheckbox66.ValueWidth = 80;
			this.buildValueCheckbox66.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox61
			// 
			this.buildValueCheckbox61.Checked = false;
			this.buildValueCheckbox61.CommandLineSwitch = null;
			this.buildValueCheckbox61.DropDownFormatting = "-low?-high";
			this.buildValueCheckbox61.DropDownItems.AddRange(new object[] {
									"Low",
									"High"});
			this.buildValueCheckbox61.Label = "Priority";
			this.buildValueCheckbox61.Location = new System.Drawing.Point(15, 90);
			this.buildValueCheckbox61.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox61.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox61.Name = "buildValueCheckbox61";
			this.buildValueCheckbox61.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox61.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox61.TabIndex = 0;
			this.buildValueCheckbox61.TextValue = "";
			this.buildValueCheckbox61.ToolTipText = "Run program an altered priority level.";
			this.buildValueCheckbox61.ValueType = thor.BuildValueCheckboxType.DropDown;
			this.buildValueCheckbox61.ValueWidth = 80;
			this.buildValueCheckbox61.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox65
			// 
			this.buildValueCheckbox65.Checked = false;
			this.buildValueCheckbox65.CommandLineSwitch = "-verbose";
			this.buildValueCheckbox65.Label = "Verbose";
			this.buildValueCheckbox65.Location = new System.Drawing.Point(15, 200);
			this.buildValueCheckbox65.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox65.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox65.Name = "buildValueCheckbox65";
			this.buildValueCheckbox65.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox65.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox65.TabIndex = 0;
			this.buildValueCheckbox65.TextValue = "";
			this.buildValueCheckbox65.ToolTipText = null;
			this.buildValueCheckbox65.ValueWidth = 80;
			this.buildValueCheckbox65.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox60
			// 
			this.buildValueCheckbox60.Checked = false;
			this.buildValueCheckbox60.CommandLineSwitch = "-chart";
			this.buildValueCheckbox60.Label = "Chart";
			this.buildValueCheckbox60.Location = new System.Drawing.Point(15, 62);
			this.buildValueCheckbox60.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox60.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox60.Name = "buildValueCheckbox60";
			this.buildValueCheckbox60.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox60.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox60.TabIndex = 0;
			this.buildValueCheckbox60.TextValue = "";
			this.buildValueCheckbox60.ToolTipText = "Display bsp statitics.";
			this.buildValueCheckbox60.ValueWidth = 80;
			this.buildValueCheckbox60.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox64
			// 
			this.buildValueCheckbox64.Checked = false;
			this.buildValueCheckbox64.CommandLineSwitch = "-estimate";
			this.buildValueCheckbox64.Label = "Estimate";
			this.buildValueCheckbox64.Location = new System.Drawing.Point(15, 172);
			this.buildValueCheckbox64.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox64.MinValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox64.Name = "buildValueCheckbox64";
			this.buildValueCheckbox64.NumValue = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.buildValueCheckbox64.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox64.TabIndex = 0;
			this.buildValueCheckbox64.TextValue = "";
			this.buildValueCheckbox64.ToolTipText = "Display estimated time during compile.";
			this.buildValueCheckbox64.ValueWidth = 80;
			this.buildValueCheckbox64.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox59
			// 
			this.buildValueCheckbox59.Checked = false;
			this.buildValueCheckbox59.CommandLineSwitch = "-lightdata";
			this.buildValueCheckbox59.Label = "Light Data";
			this.buildValueCheckbox59.Location = new System.Drawing.Point(15, 34);
			this.buildValueCheckbox59.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox59.MinValue = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.buildValueCheckbox59.Name = "buildValueCheckbox59";
			this.buildValueCheckbox59.NumValue = new decimal(new int[] {
									6144,
									0,
									0,
									0});
			this.buildValueCheckbox59.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox59.TabIndex = 0;
			this.buildValueCheckbox59.TextValue = "";
			this.buildValueCheckbox59.ToolTipText = "Alter maximum lighting memory limit (in kb).";
			this.buildValueCheckbox59.ValueType = thor.BuildValueCheckboxType.Integer;
			this.buildValueCheckbox59.ValueWidth = 80;
			this.buildValueCheckbox59.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox63
			// 
			this.buildValueCheckbox63.Checked = false;
			this.buildValueCheckbox63.CommandLineSwitch = "-threads";
			this.buildValueCheckbox63.Label = "Threads";
			this.buildValueCheckbox63.Location = new System.Drawing.Point(15, 144);
			this.buildValueCheckbox63.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox63.MinValue = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.buildValueCheckbox63.Name = "buildValueCheckbox63";
			this.buildValueCheckbox63.NumValue = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.buildValueCheckbox63.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox63.TabIndex = 0;
			this.buildValueCheckbox63.TextValue = "";
			this.buildValueCheckbox63.ToolTipText = "Manually specify the number of threads to run.";
			this.buildValueCheckbox63.ValueType = thor.BuildValueCheckboxType.Integer;
			this.buildValueCheckbox63.ValueWidth = 80;
			this.buildValueCheckbox63.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// buildValueCheckbox58
			// 
			this.buildValueCheckbox58.Checked = false;
			this.buildValueCheckbox58.CommandLineSwitch = "-texdata";
			this.buildValueCheckbox58.Label = "Texture Data";
			this.buildValueCheckbox58.Location = new System.Drawing.Point(15, 6);
			this.buildValueCheckbox58.MaxValue = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.buildValueCheckbox58.MinValue = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.buildValueCheckbox58.Name = "buildValueCheckbox58";
			this.buildValueCheckbox58.NumValue = new decimal(new int[] {
									8192,
									0,
									0,
									0});
			this.buildValueCheckbox58.Size = new System.Drawing.Size(188, 22);
			this.buildValueCheckbox58.TabIndex = 0;
			this.buildValueCheckbox58.TextValue = "";
			this.buildValueCheckbox58.ToolTipText = "Alter maximum texture memory limit (in kb.)";
			this.buildValueCheckbox58.ValueType = thor.BuildValueCheckboxType.Integer;
			this.buildValueCheckbox58.ValueWidth = 80;
			this.buildValueCheckbox58.Changed += new System.EventHandler(this.updateSelectedBuildConfig);
			// 
			// tabBuildAdvancedPreview
			// 
			this.tabBuildAdvancedPreview.Controls.Add(this.txtBuildAdvancedPreview);
			this.tabBuildAdvancedPreview.Location = new System.Drawing.Point(4, 22);
			this.tabBuildAdvancedPreview.Name = "tabBuildAdvancedPreview";
			this.tabBuildAdvancedPreview.Padding = new System.Windows.Forms.Padding(3);
			this.tabBuildAdvancedPreview.Size = new System.Drawing.Size(449, 408);
			this.tabBuildAdvancedPreview.TabIndex = 5;
			this.tabBuildAdvancedPreview.Text = "Preview";
			this.tabBuildAdvancedPreview.UseVisualStyleBackColor = true;
			// 
			// txtBuildAdvancedPreview
			// 
			this.txtBuildAdvancedPreview.BackColor = System.Drawing.SystemColors.Window;
			this.txtBuildAdvancedPreview.Location = new System.Drawing.Point(6, 6);
			this.txtBuildAdvancedPreview.Multiline = true;
			this.txtBuildAdvancedPreview.Name = "txtBuildAdvancedPreview";
			this.txtBuildAdvancedPreview.ReadOnly = true;
			this.txtBuildAdvancedPreview.Size = new System.Drawing.Size(437, 396);
			this.txtBuildAdvancedPreview.TabIndex = 3;
			// 
			// lblBuildTEMPAdvancedConfig
			// 
			this.lblBuildTEMPAdvancedConfig.Location = new System.Drawing.Point(6, 5);
			this.lblBuildTEMPAdvancedConfig.Name = "lblBuildTEMPAdvancedConfig";
			this.lblBuildTEMPAdvancedConfig.Size = new System.Drawing.Size(457, 33);
			this.lblBuildTEMPAdvancedConfig.TabIndex = 18;
			this.lblBuildTEMPAdvancedConfig.Text = "These will be set as default settings of the compile dialog, but you can change t" +
			"hen for each compile if you want.";
			// 
			// btnBuildRemove
			// 
			this.btnBuildRemove.Location = new System.Drawing.Point(166, 35);
			this.btnBuildRemove.Name = "btnBuildRemove";
			this.btnBuildRemove.Size = new System.Drawing.Size(73, 23);
			this.btnBuildRemove.TabIndex = 12;
			this.btnBuildRemove.Text = "Remove";
			this.btnBuildRemove.UseVisualStyleBackColor = true;
			// 
			// btnBuildAdd
			// 
			this.btnBuildAdd.Location = new System.Drawing.Point(166, 6);
			this.btnBuildAdd.Name = "btnBuildAdd";
			this.btnBuildAdd.Size = new System.Drawing.Size(73, 23);
			this.btnBuildAdd.TabIndex = 10;
			this.btnBuildAdd.Text = "Add New";
			this.btnBuildAdd.UseVisualStyleBackColor = true;
			this.btnBuildAdd.Click += new System.EventHandler(this.BtnBuildAddClick);
			// 
			// tree_builds
			// 
			this.tree_builds.Location = new System.Drawing.Point(6, 6);
			this.tree_builds.Name = "tree_builds";
			treeNode4.Name = "nodeHL";
			treeNode4.Text = "Goldsource";
			treeNode5.Name = "nodeSource";
			treeNode5.Text = "Source";
			this.tree_builds.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode4,
									treeNode5});
			this.tree_builds.Size = new System.Drawing.Size(154, 448);
			this.tree_builds.TabIndex = 9;
			this.tree_builds.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_buildsAfterSelect);
			// 
			// tabSteam
			// 
			this.tabSteam.Controls.Add(this.o_SteamInstallDir);
			this.tabSteam.Controls.Add(this.label17);
			this.tabSteam.Controls.Add(this.button1);
			this.tabSteam.Controls.Add(this.label18);
			this.tabSteam.Controls.Add(this.btnSteamInstallDirBrowse);
			this.tabSteam.Controls.Add(this.o_SteamUsername);
			this.tabSteam.Location = new System.Drawing.Point(4, 22);
			this.tabSteam.Name = "tabSteam";
			this.tabSteam.Padding = new System.Windows.Forms.Padding(3);
			this.tabSteam.Size = new System.Drawing.Size(736, 511);
			this.tabSteam.TabIndex = 5;
			this.tabSteam.Text = "Steam";
			this.tabSteam.UseVisualStyleBackColor = true;
			// 
			// o_SteamInstallDir
			// 
			this.o_SteamInstallDir.Location = new System.Drawing.Point(109, 20);
			this.o_SteamInstallDir.Name = "o_SteamInstallDir";
			this.o_SteamInstallDir.Size = new System.Drawing.Size(225, 20);
			this.o_SteamInstallDir.TabIndex = 5;
			this.o_SteamInstallDir.TextChanged += new System.EventHandler(this.SteamInstallDirTextChanged);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(6, 20);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(97, 20);
			this.label17.TabIndex = 6;
			this.label17.Text = "Steam Directory";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(237, 44);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(115, 25);
			this.button1.TabIndex = 8;
			this.button1.Text = "List Available Games";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(6, 47);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(97, 20);
			this.label18.TabIndex = 6;
			this.label18.Text = "Steam Username";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSteamInstallDirBrowse
			// 
			this.btnSteamInstallDirBrowse.Location = new System.Drawing.Point(340, 18);
			this.btnSteamInstallDirBrowse.Name = "btnSteamInstallDirBrowse";
			this.btnSteamInstallDirBrowse.Size = new System.Drawing.Size(67, 23);
			this.btnSteamInstallDirBrowse.TabIndex = 8;
			this.btnSteamInstallDirBrowse.Text = "Browse...";
			this.btnSteamInstallDirBrowse.UseVisualStyleBackColor = true;
			this.btnSteamInstallDirBrowse.Click += new System.EventHandler(this.BtnSteamInstallDirBrowseClick);
			// 
			// o_SteamUsername
			// 
			this.o_SteamUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.o_SteamUsername.FormattingEnabled = true;
			this.o_SteamUsername.Location = new System.Drawing.Point(109, 46);
			this.o_SteamUsername.Name = "o_SteamUsername";
			this.o_SteamUsername.Size = new System.Drawing.Size(121, 21);
			this.o_SteamUsername.TabIndex = 7;
			// 
			// tabHotkeys
			// 
			this.tabHotkeys.Controls.Add(this.listView1);
			this.tabHotkeys.Location = new System.Drawing.Point(4, 22);
			this.tabHotkeys.Name = "tabHotkeys";
			this.tabHotkeys.Padding = new System.Windows.Forms.Padding(3);
			this.tabHotkeys.Size = new System.Drawing.Size(736, 511);
			this.tabHotkeys.TabIndex = 6;
			this.tabHotkeys.Text = "Hotkeys";
			this.tabHotkeys.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chKey,
									this.ckKeyCombo,
									this.chTrigger});
			this.listView1.Location = new System.Drawing.Point(6, 6);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(724, 499);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// chKey
			// 
			this.chKey.Text = "Key";
			// 
			// ckKeyCombo
			// 
			this.ckKeyCombo.Text = "Key Combination";
			// 
			// chTrigger
			// 
			this.chTrigger.Text = "Action";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.checkBox6);
			this.groupBox10.Controls.Add(this.checkBox5);
			this.groupBox10.Location = new System.Drawing.Point(6, 19);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(426, 83);
			this.groupBox10.TabIndex = 3;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Mouselook";
			// 
			// checkBox6
			// 
			this.checkBox6.Location = new System.Drawing.Point(27, 49);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(104, 24);
			this.checkBox6.TabIndex = 0;
			this.checkBox6.Text = "Invert X Axis";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.Location = new System.Drawing.Point(27, 19);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(104, 24);
			this.checkBox5.TabIndex = 0;
			this.checkBox5.Text = "Invert Y Axis";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.trackBar3);
			this.groupBox9.Controls.Add(this.label5);
			this.groupBox9.Location = new System.Drawing.Point(6, 319);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(426, 98);
			this.groupBox9.TabIndex = 2;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Time to Top Speed";
			// 
			// trackBar3
			// 
			this.trackBar3.AutoSize = false;
			this.trackBar3.BackColor = System.Drawing.SystemColors.Window;
			this.trackBar3.Location = new System.Drawing.Point(6, 20);
			this.trackBar3.Maximum = 50;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new System.Drawing.Size(414, 42);
			this.trackBar3.TabIndex = 0;
			this.trackBar3.TickFrequency = 10000;
			this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar3.Value = 5;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 65);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(414, 23);
			this.label5.TabIndex = 1;
			this.label5.Text = "0.5 sec";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.trackBar2);
			this.groupBox8.Controls.Add(this.label1);
			this.groupBox8.Location = new System.Drawing.Point(6, 215);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(426, 98);
			this.groupBox8.TabIndex = 2;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Forward Speed";
			// 
			// trackBar2
			// 
			this.trackBar2.AutoSize = false;
			this.trackBar2.BackColor = System.Drawing.SystemColors.Window;
			this.trackBar2.Location = new System.Drawing.Point(6, 20);
			this.trackBar2.Maximum = 5000;
			this.trackBar2.Minimum = 100;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(414, 42);
			this.trackBar2.TabIndex = 0;
			this.trackBar2.TickFrequency = 10000;
			this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar2.Value = 1000;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 65);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(414, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "1000 units/sec";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.trackBar1);
			this.groupBox7.Controls.Add(this.label4);
			this.groupBox7.Location = new System.Drawing.Point(6, 108);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(426, 98);
			this.groupBox7.TabIndex = 2;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Back Clipping Pane";
			// 
			// trackBar1
			// 
			this.trackBar1.AutoSize = false;
			this.trackBar1.BackColor = System.Drawing.SystemColors.Window;
			this.trackBar1.Location = new System.Drawing.Point(6, 20);
			this.trackBar1.Maximum = 10000;
			this.trackBar1.Minimum = 2000;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(414, 42);
			this.trackBar1.TabIndex = 0;
			this.trackBar1.TickFrequency = 10000;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar1.Value = 5000;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(414, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "4000";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblConfigSteamDir
			// 
			this.lblConfigSteamDir.Location = new System.Drawing.Point(12, 9);
			this.lblConfigSteamDir.Name = "lblConfigSteamDir";
			this.lblConfigSteamDir.Size = new System.Drawing.Size(97, 20);
			this.lblConfigSteamDir.TabIndex = 6;
			this.lblConfigSteamDir.Text = "Steam Directory";
			this.lblConfigSteamDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnConfigListSteamGames
			// 
			this.btnConfigListSteamGames.Location = new System.Drawing.Point(243, 33);
			this.btnConfigListSteamGames.Name = "btnConfigListSteamGames";
			this.btnConfigListSteamGames.Size = new System.Drawing.Size(115, 25);
			this.btnConfigListSteamGames.TabIndex = 8;
			this.btnConfigListSteamGames.Text = "List Available Games";
			this.btnConfigListSteamGames.UseVisualStyleBackColor = true;
			// 
			// btnConfigSteamDirBrowse
			// 
			this.btnConfigSteamDirBrowse.Location = new System.Drawing.Point(346, 7);
			this.btnConfigSteamDirBrowse.Name = "btnConfigSteamDirBrowse";
			this.btnConfigSteamDirBrowse.Size = new System.Drawing.Size(67, 23);
			this.btnConfigSteamDirBrowse.TabIndex = 8;
			this.btnConfigSteamDirBrowse.Text = "Browse...";
			this.btnConfigSteamDirBrowse.UseVisualStyleBackColor = true;
			// 
			// cmbConfigSteamUser
			// 
			this.cmbConfigSteamUser.FormattingEnabled = true;
			this.cmbConfigSteamUser.Location = new System.Drawing.Point(115, 35);
			this.cmbConfigSteamUser.Name = "cmbConfigSteamUser";
			this.cmbConfigSteamUser.Size = new System.Drawing.Size(121, 21);
			this.cmbConfigSteamUser.TabIndex = 7;
			this.cmbConfigSteamUser.Text = "Penguinboy77";
			// 
			// lblConfigSteamUser
			// 
			this.lblConfigSteamUser.Location = new System.Drawing.Point(12, 36);
			this.lblConfigSteamUser.Name = "lblConfigSteamUser";
			this.lblConfigSteamUser.Size = new System.Drawing.Size(97, 20);
			this.lblConfigSteamUser.TabIndex = 6;
			this.lblConfigSteamUser.Text = "Steam Username";
			this.lblConfigSteamUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCancelSettings
			// 
			this.btnCancelSettings.Location = new System.Drawing.Point(681, 555);
			this.btnCancelSettings.Name = "btnCancelSettings";
			this.btnCancelSettings.Size = new System.Drawing.Size(75, 23);
			this.btnCancelSettings.TabIndex = 1;
			this.btnCancelSettings.Text = "Cancel";
			this.btnCancelSettings.UseVisualStyleBackColor = true;
			this.btnCancelSettings.Click += new System.EventHandler(this.BtnCancelSettingsClick);
			// 
			// btnApplyAndCloseSettings
			// 
			this.btnApplyAndCloseSettings.Location = new System.Drawing.Point(584, 555);
			this.btnApplyAndCloseSettings.Name = "btnApplyAndCloseSettings";
			this.btnApplyAndCloseSettings.Size = new System.Drawing.Size(91, 23);
			this.btnApplyAndCloseSettings.TabIndex = 1;
			this.btnApplyAndCloseSettings.Text = "Apply and Close";
			this.btnApplyAndCloseSettings.UseVisualStyleBackColor = true;
			this.btnApplyAndCloseSettings.Click += new System.EventHandler(this.BtnApplyAndCloseSettingsClick);
			// 
			// btnApplySettings
			// 
			this.btnApplySettings.Location = new System.Drawing.Point(503, 555);
			this.btnApplySettings.Name = "btnApplySettings";
			this.btnApplySettings.Size = new System.Drawing.Size(75, 23);
			this.btnApplySettings.TabIndex = 1;
			this.btnApplySettings.Text = "Apply";
			this.btnApplySettings.UseVisualStyleBackColor = true;
			this.btnApplySettings.Click += new System.EventHandler(this.BtnApplySettingsClick);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(768, 590);
			this.Controls.Add(this.btnApplySettings);
			this.Controls.Add(this.btnApplyAndCloseSettings);
			this.Controls.Add(this.btnCancelSettings);
			this.Controls.Add(this.tbcSettings);
			this.Name = "SettingsForm";
			this.ShowInTaskbar = false;
			this.Text = "SettingsForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseWithoutSaving);
			this.tbcSettings.ResumeLayout(false);
			this.tab2DViews.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.o_2DNudgeDistance)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.o_Highlight1Distance)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.o_HideGridLimit)).EndInit();
			this.tab3DViews.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.o_3DTimeToTopSpeed)).EndInit();
			this.groupBox13.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.o_3DForwardSpeed)).EndInit();
			this.groupBox14.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.o_3DBackClippingPane)).EndInit();
			this.tabGame.ResumeLayout(false);
			this.tabGameSubTabs.ResumeLayout(false);
			this.tabConfigDirectories.ResumeLayout(false);
			this.tabConfigDirectories.PerformLayout();
			this.grpConfigGame.ResumeLayout(false);
			this.grpConfigGame.PerformLayout();
			this.grpConfigSaving.ResumeLayout(false);
			this.grpConfigSaving.PerformLayout();
			this.tabConfigEntities.ResumeLayout(false);
			this.tabConfigTextures.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudGameLightmapScale)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudGameTextureScale)).EndInit();
			this.tabBuild.ResumeLayout(false);
			this.tabBuildSubTabs.ResumeLayout(false);
			this.tabBuildGeneral.ResumeLayout(false);
			this.tabBuildGeneral.PerformLayout();
			this.tabBuildExecutables.ResumeLayout(false);
			this.tabBuildExecutables.PerformLayout();
			this.tabBuildPostCompile.ResumeLayout(false);
			this.tabBuildPostCompile.PerformLayout();
			this.tabBuildAdvanced.ResumeLayout(false);
			this.tabBuildAdvancedSubTabs.ResumeLayout(false);
			this.tabBuildAdvancedCSG.ResumeLayout(false);
			this.tabBuildAdvancedBSP.ResumeLayout(false);
			this.tabBuildAdvancedVIS.ResumeLayout(false);
			this.tabBuildAdvancedRAD.ResumeLayout(false);
			this.groupBox15.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabBuildAdvancedShared.ResumeLayout(false);
			this.tabBuildAdvancedPreview.ResumeLayout(false);
			this.tabBuildAdvancedPreview.PerformLayout();
			this.tabSteam.ResumeLayout(false);
			this.tabSteam.PerformLayout();
			this.tabHotkeys.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			this.groupBox8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			this.groupBox7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox txtBuildAdvancedPreview;
		private System.Windows.Forms.TabPage tabBuildAdvancedPreview;
		private thor.BuildValueCheckbox buildValueCheckbox68;
		private thor.BuildValueCheckbox buildValueCheckbox58;
		private thor.BuildValueCheckbox buildValueCheckbox63;
		private thor.BuildValueCheckbox buildValueCheckbox59;
		private thor.BuildValueCheckbox buildValueCheckbox64;
		private thor.BuildValueCheckbox buildValueCheckbox60;
		private thor.BuildValueCheckbox buildValueCheckbox65;
		private thor.BuildValueCheckbox buildValueCheckbox61;
		private thor.BuildValueCheckbox buildValueCheckbox66;
		private thor.BuildValueCheckbox buildValueCheckbox62;
		private thor.BuildValueCheckbox buildValueCheckbox67;
		private thor.BuildValueCheckbox buildValueCheckbox55;
		private thor.BuildValueCheckbox buildValueCheckbox57;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private thor.BuildValueCheckbox buildValueCheckbox51;
		private thor.BuildValueCheckbox buildValueCheckbox49;
		private thor.BuildValueCheckbox buildValueCheckbox53;
		private thor.BuildValueCheckbox buildValueCheckbox48;
		private thor.BuildValueCheckbox buildValueCheckbox50;
		private thor.BuildValueCheckbox buildValueCheckbox52;
		private thor.BuildValueCheckbox buildValueCheckbox54;
		private thor.BuildValueCheckbox buildValueCheckbox47;
		private thor.BuildValueCheckbox buildValueCheckbox56;
		private thor.BuildValueCheckbox buildValueCheckbox46;
		private thor.BuildValueCheckbox buildValueCheckbox45;
		private System.Windows.Forms.GroupBox groupBox15;
		private thor.BuildValueCheckbox buildValueCheckbox44;
		private thor.BuildValueCheckbox buildValueCheckbox28;
		private thor.BuildValueCheckbox buildValueCheckbox32;
		private thor.BuildValueCheckbox buildValueCheckbox36;
		private thor.BuildValueCheckbox buildValueCheckbox29;
		private thor.BuildValueCheckbox buildValueCheckbox39;
		private thor.BuildValueCheckbox buildValueCheckbox41;
		private thor.BuildValueCheckbox buildValueCheckbox40;
		private thor.BuildValueCheckbox buildValueCheckbox42;
		private thor.BuildValueCheckbox buildValueCheckbox43;
		private thor.BuildValueCheckbox buildValueCheckbox33;
		private thor.BuildValueCheckbox buildValueCheckbox37;
		private thor.BuildValueCheckbox buildValueCheckbox30;
		private thor.BuildValueCheckbox buildValueCheckbox34;
		private thor.BuildValueCheckbox buildValueCheckbox38;
		private thor.BuildValueCheckbox buildValueCheckbox31;
		private thor.BuildValueCheckbox buildValueCheckbox35;
		private thor.BuildValueCheckbox buildValueCheckbox27;
		private thor.BuildValueCheckbox buildValueCheckbox25;
		private thor.BuildValueCheckbox buildValueCheckbox22;
		private thor.BuildValueCheckbox buildValueCheckbox24;
		private thor.BuildValueCheckbox buildValueCheckbox23;
		private thor.BuildValueCheckbox buildValueCheckbox15;
		private thor.BuildValueCheckbox buildValueCheckbox16;
		private thor.BuildValueCheckbox buildValueCheckbox17;
		private thor.BuildValueCheckbox buildValueCheckbox18;
		private thor.BuildValueCheckbox buildValueCheckbox19;
		private thor.BuildValueCheckbox buildValueCheckbox20;
		private thor.BuildValueCheckbox buildValueCheckbox21;
		private thor.BuildValueCheckbox buildValueCheckbox26;
		private System.Windows.Forms.Label label20;
		private thor.BuildValueCheckbox buildValueCheckbox14;
		private thor.BuildValueCheckbox buildValueCheckbox11;
		private thor.BuildValueCheckbox buildValueCheckbox10;
		private thor.BuildValueCheckbox buildValueCheckbox12;
		private thor.BuildValueCheckbox buildValueCheckbox13;
		private thor.BuildValueCheckbox buildValueCheckbox1;
		private thor.BuildValueCheckbox buildValueCheckbox2;
		private thor.BuildValueCheckbox buildValueCheckbox3;
		private thor.BuildValueCheckbox buildValueCheckbox4;
		private thor.BuildValueCheckbox buildValueCheckbox7;
		private thor.BuildValueCheckbox buildValueCheckbox5;
		private thor.BuildValueCheckbox buildValueCheckbox8;
		private thor.BuildValueCheckbox buildValueCheckbox6;
		private thor.BuildValueCheckbox buildValueCheckbox9;
		private System.Windows.Forms.TabPage tabBuildAdvancedShared;
		private System.Windows.Forms.TabPage tabBuildAdvancedRAD;
		private System.Windows.Forms.TabPage tabBuildAdvancedVIS;
		private System.Windows.Forms.TabPage tabBuildAdvancedBSP;
		private System.Windows.Forms.TabPage tabBuildAdvancedCSG;
		private System.Windows.Forms.TabControl tabBuildAdvancedSubTabs;
		private System.Windows.Forms.TextBox txtGameMapDir;
		private System.Windows.Forms.TabPage tabGame;
		private System.Windows.Forms.Button btnGameAdd;
		private System.Windows.Forms.Button btnGameRemove;
		private System.Windows.Forms.Button btnGameAddFGD;
		private System.Windows.Forms.Button btnGameAddWAD;
		private System.Windows.Forms.Button btnGameRemoveFGD;
		private System.Windows.Forms.Button btnGameRemoveWAD;
		private System.Windows.Forms.Label lblGameWAD;
		private System.Windows.Forms.Label lblGameBuild;
		private System.Windows.Forms.ComboBox cmbGameBuild;
		private System.Windows.Forms.ListBox lstGameWAD;
		private System.Windows.Forms.Label lblGameFGD;
		private System.Windows.Forms.ComboBox cmbGamePointEnt;
		private System.Windows.Forms.ComboBox cmbGameBrushEnt;
		private System.Windows.Forms.ListBox lstGameFGD;
		private System.Windows.Forms.NumericUpDown nudGameTextureScale;
		private System.Windows.Forms.NumericUpDown nudGameLightmapScale;
		private System.Windows.Forms.Label lblGameMapSaveDir;
		private System.Windows.Forms.Button btnGameMapDirBrowse;
		private System.Windows.Forms.TextBox txtGameAutosaveDir;
		private System.Windows.Forms.Label lblGameAutosaveDir;
		private System.Windows.Forms.Button btnGameAutosaveDirBrowse;
		private System.Windows.Forms.Label lblGameMod;
		private System.Windows.Forms.ComboBox cmbGameMod;
		private System.Windows.Forms.TextBox txtGameWONDir;
		private System.Windows.Forms.Label lblGameWONDir;
		private System.Windows.Forms.Button btnGameDirBrowse;
		private System.Windows.Forms.Label lblGameSteamDir;
		private System.Windows.Forms.ComboBox cmbGameSteamDir;
		private System.Windows.Forms.TextBox txtGameName;
		private System.Windows.Forms.Label lblGameName;
		private System.Windows.Forms.Label lblGameEngine;
		private System.Windows.Forms.ComboBox cmbGameEngine;
		private System.Windows.Forms.CheckBox chkGameMapDiffAutosaveDir;
		private System.Windows.Forms.CheckBox chkGameEnableAutosave;
		private System.Windows.Forms.TabControl tabGameSubTabs;
		private System.Windows.Forms.Button btnGameChangeName;
		private System.Windows.Forms.TreeView tree_games;
		private System.Windows.Forms.Button btnBuildChangeName;
		private System.Windows.Forms.TreeView tree_builds;
		private System.Windows.Forms.ColumnHeader chTrigger;
		private System.Windows.Forms.ColumnHeader ckKeyCombo;
		private System.Windows.Forms.ColumnHeader chKey;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.TabPage tabHotkeys;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Panel o_col_2DBoundaryColour;
		private System.Windows.Forms.Button btnCancelSettings;
		private System.Windows.Forms.Button btnApplyAndCloseSettings;
		private System.Windows.Forms.Button btnSteamInstallDirBrowse;
		private System.Windows.Forms.TrackBar o_3DTimeToTopSpeed;
		private System.Windows.Forms.CheckBox o_3DInvertX;
		private System.Windows.Forms.CheckBox o_3DInvertY;
		private System.Windows.Forms.TrackBar o_3DForwardSpeed;
		private System.Windows.Forms.TrackBar o_3DBackClippingPane;
		private System.Windows.Forms.TextBox o_SteamInstallDir;
		private System.Windows.Forms.ComboBox o_SteamUsername;
		private System.Windows.Forms.Button btnApplySettings;
		private System.Windows.Forms.CheckBox o_2DCrosshair;
		private System.Windows.Forms.RadioButton o_RotationSnapStyle_3;
		private System.Windows.Forms.RadioButton o_RotationSnapStyle_2;
		private System.Windows.Forms.RadioButton o_RotationSnapStyle_1;
		private System.Windows.Forms.NumericUpDown o_2DNudgeDistance;
		private System.Windows.Forms.CheckBox o_2DNudge;
		private System.Windows.Forms.RadioButton o_GridSnapStyle_2;
		private System.Windows.Forms.RadioButton o_GridSnapStyle_1;
		private System.Windows.Forms.DomainUpDown o_DefaultGridSize;
		private System.Windows.Forms.Panel o_col_2DHighlight2Colour;
		private System.Windows.Forms.Panel o_col_2DHighlight1Colour;
		private System.Windows.Forms.Panel o_col_2DGridColour;
		private System.Windows.Forms.Panel o_col_2DBackgroundColour;
		private System.Windows.Forms.Panel o_col_2DZeroAxisColour;
		private System.Windows.Forms.NumericUpDown o_Highlight1Distance;
		private System.Windows.Forms.CheckBox o_Highlight2On;
		private System.Windows.Forms.CheckBox o_Highlight1On;
		private System.Windows.Forms.DomainUpDown o_HideGridFactor;
		private System.Windows.Forms.NumericUpDown o_HideGridLimit;
		private System.Windows.Forms.TabPage tabBuildAdvanced;
		private System.Windows.Forms.TabPage tabBuildPostCompile;
		private System.Windows.Forms.TabPage tabBuildExecutables;
		private System.Windows.Forms.TabPage tabBuildGeneral;
		private System.Windows.Forms.TabControl tabBuildSubTabs;
		private System.Windows.Forms.TabPage tabConfigTextures;
		private System.Windows.Forms.TabPage tabConfigEntities;
		private System.Windows.Forms.TabPage tabConfigDirectories;
		private System.Windows.Forms.TabPage tab2DViews;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TabPage tabSteam;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.TabPage tab3DViews;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar trackBar2;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TrackBar trackBar3;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtBuildCommandLine;
		private System.Windows.Forms.CheckBox chkBuildCopyBSP;
		private System.Windows.Forms.Label lblConfigLightmapScale;
		private System.Windows.Forms.Label lblConfigTextureScale;
		private System.Windows.Forms.Label lblConfigBrushEnt;
		private System.Windows.Forms.Label lblConfigPointEnt;
		private System.Windows.Forms.Label lblConfigSteamDir;
		private System.Windows.Forms.Button btnConfigListSteamGames;
		private System.Windows.Forms.Button btnConfigSteamDirBrowse;
		private System.Windows.Forms.ComboBox cmbConfigSteamUser;
		private System.Windows.Forms.Label lblConfigSteamUser;
		private System.Windows.Forms.Button btnBuildExeFolderBrowse;
		private System.Windows.Forms.ComboBox cmbBuildEngine;
		private System.Windows.Forms.Label lblBuildEngine;
		private System.Windows.Forms.Label lblBuildExeFolder;
		private System.Windows.Forms.Label lblBuildName;
		private System.Windows.Forms.TextBox txtBuildExeFolder;
		private System.Windows.Forms.TextBox txtBuildName;
		private System.Windows.Forms.Button btnBuildRemove;
		private System.Windows.Forms.Button btnBuildAdd;
		private System.Windows.Forms.CheckBox chkBuildShowLog;
		private System.Windows.Forms.RadioButton radBuildDontRunGame;
		private System.Windows.Forms.CheckBox chkBuildAskBeforeRun;
		private System.Windows.Forms.RadioButton radBuildRunGameOnChange;
		private System.Windows.Forms.RadioButton radBuildRunGame;
		private System.Windows.Forms.Label lblBuildCommandLine;
		private System.Windows.Forms.ListBox lstBuildPresets;
		private System.Windows.Forms.Label lblBuildDetectedPresets;
		private System.Windows.Forms.ComboBox cmbBuildRAD;
		private System.Windows.Forms.ComboBox cmbBuildVIS;
		private System.Windows.Forms.Label lblBuildRAD;
		private System.Windows.Forms.ComboBox cmbBuildCSG;
		private System.Windows.Forms.Label lblBuildVIS;
		private System.Windows.Forms.ComboBox cmbBuildBSP;
		private System.Windows.Forms.Label lblBuildCSG;
		private System.Windows.Forms.Label lblBuildBSP;
		private System.Windows.Forms.Label lblBuildTEMPAdvancedConfig;
		private System.Windows.Forms.GroupBox grpConfigGame;
		private System.Windows.Forms.GroupBox grpConfigSaving;
		private System.Windows.Forms.TabPage tabBuild;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.TabControl tbcSettings;
	}
}
