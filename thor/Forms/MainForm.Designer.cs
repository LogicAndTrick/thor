/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 4/09/2008
 * Time: 11:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace thor
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.tmrReload = new System.Windows.Forms.Timer(this.components);
			this.openVMF = new System.Windows.Forms.OpenFileDialog();
			this.dockMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmNew = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
			this.RMFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.objectDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmRun = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteSpecialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmMap = new System.Windows.Forms.ToolStripMenuItem();
			this.snapToGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gridSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.smallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.largerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.showSelectedBrushNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.entityReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkForProblemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.diffMapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.loadPointfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closePointfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadPortalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closePortalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.showInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mapPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autosize4ViewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.centerViewsOnSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToBrushNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmTools = new System.Windows.Forms.ToolStripMenuItem();
			this.carveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.makeHollowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ungroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.tieToEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveToWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.textureApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceTexturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textureLockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textureBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.soundBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fgdEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.transformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.snapSelectedToGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.snapSelectedToGridIndividuallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.centerOriginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.alignObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flipObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createPrefabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tspTop = new System.Windows.Forms.ToolStripPanel();
			this.stsMain = new System.Windows.Forms.StatusStrip();
			this.tslBtmLeft = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tspLeft = new System.Windows.Forms.ToolStripPanel();
			this.tspRight = new System.Windows.Forms.ToolStripPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.printToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.copyToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.pasteToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.dockTabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
			this.copyFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMain.SuspendLayout();
			this.stsMain.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.dockTabMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.Items.AddRange(new object[] {
									"WHAT",
									"THE",
									"SHIT"});
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(121, 21);
			// 
			// tmrReload
			// 
			this.tmrReload.Enabled = true;
			this.tmrReload.Interval = 10;
			// 
			// openVMF
			// 
			this.openVMF.Filter = "Valve Map Files (.vmf) | *.vmf";
			// 
			// dockMain
			// 
			this.dockMain.ActiveAutoHideContent = null;
			this.dockMain.BackColor = System.Drawing.SystemColors.Control;
			this.dockMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockMain.DockBottomPortion = 200;
			this.dockMain.DockLeftPortion = 58;
			this.dockMain.DockRightPortion = 218;
			this.dockMain.DockTopPortion = 65;
			this.dockMain.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
			this.dockMain.Location = new System.Drawing.Point(0, 50);
			this.dockMain.Name = "dockMain";
			this.dockMain.Size = new System.Drawing.Size(792, 391);
			this.dockMain.TabIndex = 14;
			this.dockMain.ContentRemoved += new System.EventHandler<WeifenLuo.WinFormsUI.Docking.DockContentEventArgs>(this.DockMainContentRemoved);
			// 
			// mnuMain
			// 
			this.mnuMain.Dock = System.Windows.Forms.DockStyle.None;
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsmFile,
									this.tsmEdit,
									this.tsmMap,
									this.viewToolStripMenuItem,
									this.tsmTools,
									this.pluginsToolStripMenuItem,
									this.tsmWindow,
									this.tsmHelp});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(792, 24);
			this.mnuMain.TabIndex = 4;
			this.mnuMain.Text = "menuStrip1";
			// 
			// tsmFile
			// 
			this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsmNew,
									this.tsmOpen,
									this.tsmClose,
									this.tsmSave,
									this.tsmSaveAs,
									this.toolStripSeparator2,
									this.tsmExport,
									this.toolStripSeparator3,
									this.tsmRun,
									this.toolStripSeparator4,
									this.tsmExit});
			this.tsmFile.Name = "tsmFile";
			this.tsmFile.Size = new System.Drawing.Size(35, 20);
			this.tsmFile.Text = "File";
			// 
			// tsmNew
			// 
			this.tsmNew.Name = "tsmNew";
			this.tsmNew.ShortcutKeyDisplayString = "Ctrl+N";
			this.tsmNew.Size = new System.Drawing.Size(163, 22);
			this.tsmNew.Text = "New";
			this.tsmNew.Click += new System.EventHandler(this.TsmNewClick);
			// 
			// tsmOpen
			// 
			this.tsmOpen.Name = "tsmOpen";
			this.tsmOpen.ShortcutKeyDisplayString = "Ctrl+O";
			this.tsmOpen.Size = new System.Drawing.Size(163, 22);
			this.tsmOpen.Text = "Open...";
			this.tsmOpen.Click += new System.EventHandler(this.TsmOpenClick);
			// 
			// tsmClose
			// 
			this.tsmClose.Name = "tsmClose";
			this.tsmClose.Size = new System.Drawing.Size(163, 22);
			this.tsmClose.Text = "Close";
			// 
			// tsmSave
			// 
			this.tsmSave.Name = "tsmSave";
			this.tsmSave.ShortcutKeyDisplayString = "Ctrl+S";
			this.tsmSave.Size = new System.Drawing.Size(163, 22);
			this.tsmSave.Text = "Save";
			// 
			// tsmSaveAs
			// 
			this.tsmSaveAs.Name = "tsmSaveAs";
			this.tsmSaveAs.Size = new System.Drawing.Size(163, 22);
			this.tsmSaveAs.Text = "Save As...";
			this.tsmSaveAs.Click += new System.EventHandler(this.TsmSaveAsClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
			// 
			// tsmExport
			// 
			this.tsmExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.RMFToolStripMenuItem,
									this.MAPToolStripMenuItem,
									this.objectDumpToolStripMenuItem});
			this.tsmExport.Name = "tsmExport";
			this.tsmExport.Size = new System.Drawing.Size(163, 22);
			this.tsmExport.Text = "Export...";
			// 
			// RMFToolStripMenuItem
			// 
			this.RMFToolStripMenuItem.Name = "RMFToolStripMenuItem";
			this.RMFToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.RMFToolStripMenuItem.Text = "RMF";
			// 
			// MAPToolStripMenuItem
			// 
			this.MAPToolStripMenuItem.Name = "MAPToolStripMenuItem";
			this.MAPToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.MAPToolStripMenuItem.Text = "MAP";
			// 
			// objectDumpToolStripMenuItem
			// 
			this.objectDumpToolStripMenuItem.Name = "objectDumpToolStripMenuItem";
			this.objectDumpToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.objectDumpToolStripMenuItem.Text = "Object Dump";
			this.objectDumpToolStripMenuItem.Click += new System.EventHandler(this.ObjectDumpToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
			// 
			// tsmRun
			// 
			this.tsmRun.Name = "tsmRun";
			this.tsmRun.ShortcutKeyDisplayString = "F9";
			this.tsmRun.Size = new System.Drawing.Size(163, 22);
			this.tsmRun.Text = "Run Map...";
			this.tsmRun.Click += new System.EventHandler(this.TsmRunClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(160, 6);
			// 
			// tsmExit
			// 
			this.tsmExit.Name = "tsmExit";
			this.tsmExit.Size = new System.Drawing.Size(163, 22);
			this.tsmExit.Text = "Exit";
			// 
			// tsmEdit
			// 
			this.tsmEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.undoToolStripMenuItem,
									this.redoToolStripMenuItem,
									this.toolStripSeparator5,
									this.findToolStripMenuItem,
									this.replaceToolStripMenuItem,
									this.toolStripSeparator6,
									this.cutToolStripMenuItem,
									this.copyToolStripMenuItem,
									this.pasteToolStripMenuItem,
									this.pasteSpecialToolStripMenuItem,
									this.deleteToolStripMenuItem,
									this.toolStripSeparator7,
									this.selectNoneToolStripMenuItem,
									this.selectAllToolStripMenuItem,
									this.toolStripSeparator8,
									this.propertiesToolStripMenuItem});
			this.tsmEdit.Name = "tsmEdit";
			this.tsmEdit.Size = new System.Drawing.Size(37, 20);
			this.tsmEdit.Text = "Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Z";
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.undoToolStripMenuItem.Text = "Undo";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Y";
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.redoToolStripMenuItem.Text = "Redo";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(225, 6);
			// 
			// findToolStripMenuItem
			// 
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+F";
			this.findToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.findToolStripMenuItem.Text = "Find...";
			// 
			// replaceToolStripMenuItem
			// 
			this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
			this.replaceToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+R";
			this.replaceToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.replaceToolStripMenuItem.Text = "Replace...";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(225, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.cutToolStripMenuItem.Text = "Cut";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			// 
			// pasteSpecialToolStripMenuItem
			// 
			this.pasteSpecialToolStripMenuItem.Name = "pasteSpecialToolStripMenuItem";
			this.pasteSpecialToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+V";
			this.pasteSpecialToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.pasteSpecialToolStripMenuItem.Text = "Paste Special...";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeyDisplayString = "Del";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(225, 6);
			// 
			// selectNoneToolStripMenuItem
			// 
			this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
			this.selectNoneToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Q";
			this.selectNoneToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.selectNoneToolStripMenuItem.Text = "Select None";
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+A";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(225, 6);
			// 
			// propertiesToolStripMenuItem
			// 
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			this.propertiesToolStripMenuItem.ShortcutKeyDisplayString = "Alt+Enter";
			this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.propertiesToolStripMenuItem.Text = "Properties";
			// 
			// tsmMap
			// 
			this.tsmMap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.snapToGridToolStripMenuItem,
									this.showGridToolStripMenuItem,
									this.gridSizeToolStripMenuItem,
									this.toolStripSeparator9,
									this.showSelectedBrushNumberToolStripMenuItem,
									this.entityReportToolStripMenuItem,
									this.checkForProblemsToolStripMenuItem,
									this.diffMapFileToolStripMenuItem,
									this.toolStripSeparator10,
									this.loadPointfileToolStripMenuItem,
									this.closePointfileToolStripMenuItem,
									this.loadPortalFileToolStripMenuItem,
									this.closePortalFileToolStripMenuItem,
									this.toolStripSeparator11,
									this.showInformationToolStripMenuItem,
									this.mapPropertiesToolStripMenuItem});
			this.tsmMap.Name = "tsmMap";
			this.tsmMap.Size = new System.Drawing.Size(39, 20);
			this.tsmMap.Text = "Map";
			// 
			// snapToGridToolStripMenuItem
			// 
			this.snapToGridToolStripMenuItem.Checked = true;
			this.snapToGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.snapToGridToolStripMenuItem.Name = "snapToGridToolStripMenuItem";
			this.snapToGridToolStripMenuItem.ShortcutKeyDisplayString = "Shift+W";
			this.snapToGridToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.snapToGridToolStripMenuItem.Text = "Snap to Grid";
			// 
			// showGridToolStripMenuItem
			// 
			this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
			this.showGridToolStripMenuItem.ShortcutKeyDisplayString = "Shift+R";
			this.showGridToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.showGridToolStripMenuItem.Text = "Show Grid";
			// 
			// gridSizeToolStripMenuItem
			// 
			this.gridSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.smallerToolStripMenuItem,
									this.largerToolStripMenuItem});
			this.gridSizeToolStripMenuItem.Name = "gridSizeToolStripMenuItem";
			this.gridSizeToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.gridSizeToolStripMenuItem.Text = "Grid Size";
			// 
			// smallerToolStripMenuItem
			// 
			this.smallerToolStripMenuItem.Name = "smallerToolStripMenuItem";
			this.smallerToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.smallerToolStripMenuItem.Text = "Smaller";
			// 
			// largerToolStripMenuItem
			// 
			this.largerToolStripMenuItem.Name = "largerToolStripMenuItem";
			this.largerToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.largerToolStripMenuItem.Text = "Larger";
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(222, 6);
			// 
			// showSelectedBrushNumberToolStripMenuItem
			// 
			this.showSelectedBrushNumberToolStripMenuItem.Name = "showSelectedBrushNumberToolStripMenuItem";
			this.showSelectedBrushNumberToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.showSelectedBrushNumberToolStripMenuItem.Text = "Show Selected Brush Number";
			// 
			// entityReportToolStripMenuItem
			// 
			this.entityReportToolStripMenuItem.Name = "entityReportToolStripMenuItem";
			this.entityReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.entityReportToolStripMenuItem.Text = "Entity Report...";
			// 
			// checkForProblemsToolStripMenuItem
			// 
			this.checkForProblemsToolStripMenuItem.Name = "checkForProblemsToolStripMenuItem";
			this.checkForProblemsToolStripMenuItem.ShortcutKeyDisplayString = "Alt+P";
			this.checkForProblemsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.checkForProblemsToolStripMenuItem.Text = "Check for Problems";
			// 
			// diffMapFileToolStripMenuItem
			// 
			this.diffMapFileToolStripMenuItem.Name = "diffMapFileToolStripMenuItem";
			this.diffMapFileToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.diffMapFileToolStripMenuItem.Text = "Diff Map File";
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(222, 6);
			// 
			// loadPointfileToolStripMenuItem
			// 
			this.loadPointfileToolStripMenuItem.Name = "loadPointfileToolStripMenuItem";
			this.loadPointfileToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.loadPointfileToolStripMenuItem.Text = "Load Pointfile...";
			// 
			// closePointfileToolStripMenuItem
			// 
			this.closePointfileToolStripMenuItem.Name = "closePointfileToolStripMenuItem";
			this.closePointfileToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.closePointfileToolStripMenuItem.Text = "Close Pointfile";
			// 
			// loadPortalFileToolStripMenuItem
			// 
			this.loadPortalFileToolStripMenuItem.Name = "loadPortalFileToolStripMenuItem";
			this.loadPortalFileToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.loadPortalFileToolStripMenuItem.Text = "Load Portal File";
			// 
			// closePortalFileToolStripMenuItem
			// 
			this.closePortalFileToolStripMenuItem.Name = "closePortalFileToolStripMenuItem";
			this.closePortalFileToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.closePortalFileToolStripMenuItem.Text = "Close Portal File";
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(222, 6);
			// 
			// showInformationToolStripMenuItem
			// 
			this.showInformationToolStripMenuItem.Name = "showInformationToolStripMenuItem";
			this.showInformationToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.showInformationToolStripMenuItem.Text = "Show Information";
			// 
			// mapPropertiesToolStripMenuItem
			// 
			this.mapPropertiesToolStripMenuItem.Name = "mapPropertiesToolStripMenuItem";
			this.mapPropertiesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.mapPropertiesToolStripMenuItem.Text = "Map Properties...";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.autosize4ViewsToolStripMenuItem,
									this.toolStripSeparator12,
									this.centerViewsOnSelectionToolStripMenuItem,
									this.goToCoordinatesToolStripMenuItem,
									this.goToBrushNumberToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// autosize4ViewsToolStripMenuItem
			// 
			this.autosize4ViewsToolStripMenuItem.Name = "autosize4ViewsToolStripMenuItem";
			this.autosize4ViewsToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
			this.autosize4ViewsToolStripMenuItem.Text = "Autosize 4 Views";
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(259, 6);
			// 
			// centerViewsOnSelectionToolStripMenuItem
			// 
			this.centerViewsOnSelectionToolStripMenuItem.Name = "centerViewsOnSelectionToolStripMenuItem";
			this.centerViewsOnSelectionToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+E";
			this.centerViewsOnSelectionToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
			this.centerViewsOnSelectionToolStripMenuItem.Text = "Center Views on Selection";
			// 
			// goToCoordinatesToolStripMenuItem
			// 
			this.goToCoordinatesToolStripMenuItem.Name = "goToCoordinatesToolStripMenuItem";
			this.goToCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
			this.goToCoordinatesToolStripMenuItem.Text = "Go to Coordinates...";
			// 
			// goToBrushNumberToolStripMenuItem
			// 
			this.goToBrushNumberToolStripMenuItem.Name = "goToBrushNumberToolStripMenuItem";
			this.goToBrushNumberToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+G";
			this.goToBrushNumberToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
			this.goToBrushNumberToolStripMenuItem.Text = "Go to Brush Number...";
			// 
			// tsmTools
			// 
			this.tsmTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.carveToolStripMenuItem,
									this.makeHollowToolStripMenuItem,
									this.toolStripSeparator13,
									this.groupToolStripMenuItem,
									this.ungroupToolStripMenuItem,
									this.toolStripSeparator14,
									this.tieToEntityToolStripMenuItem,
									this.moveToWorldToolStripMenuItem,
									this.toolStripSeparator15,
									this.textureApplicationToolStripMenuItem,
									this.replaceTexturesToolStripMenuItem,
									this.textureLockToolStripMenuItem,
									this.textureBrowserToolStripMenuItem,
									this.toolStripSeparator16,
									this.soundBrowserToolStripMenuItem,
									this.fgdEditorToolStripMenuItem,
									this.toolStripSeparator17,
									this.transformToolStripMenuItem,
									this.snapSelectedToGridToolStripMenuItem,
									this.snapSelectedToGridIndividuallyToolStripMenuItem,
									this.centerOriginsToolStripMenuItem,
									this.alignObjectsToolStripMenuItem,
									this.flipObjectsToolStripMenuItem,
									this.createPrefabToolStripMenuItem,
									this.toolStripSeparator18,
									this.optionsToolStripMenuItem});
			this.tsmTools.Name = "tsmTools";
			this.tsmTools.Size = new System.Drawing.Size(44, 20);
			this.tsmTools.Text = "Tools";
			// 
			// carveToolStripMenuItem
			// 
			this.carveToolStripMenuItem.Name = "carveToolStripMenuItem";
			this.carveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+C";
			this.carveToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.carveToolStripMenuItem.Text = "Carve";
			// 
			// makeHollowToolStripMenuItem
			// 
			this.makeHollowToolStripMenuItem.Name = "makeHollowToolStripMenuItem";
			this.makeHollowToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+H";
			this.makeHollowToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.makeHollowToolStripMenuItem.Text = "Make Hollow...";
			// 
			// toolStripSeparator13
			// 
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(310, 6);
			// 
			// groupToolStripMenuItem
			// 
			this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
			this.groupToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+G";
			this.groupToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.groupToolStripMenuItem.Text = "Group";
			// 
			// ungroupToolStripMenuItem
			// 
			this.ungroupToolStripMenuItem.Name = "ungroupToolStripMenuItem";
			this.ungroupToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+U";
			this.ungroupToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.ungroupToolStripMenuItem.Text = "Ungroup";
			// 
			// toolStripSeparator14
			// 
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(310, 6);
			// 
			// tieToEntityToolStripMenuItem
			// 
			this.tieToEntityToolStripMenuItem.Name = "tieToEntityToolStripMenuItem";
			this.tieToEntityToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+T";
			this.tieToEntityToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.tieToEntityToolStripMenuItem.Text = "Tie to Entity";
			// 
			// moveToWorldToolStripMenuItem
			// 
			this.moveToWorldToolStripMenuItem.Name = "moveToWorldToolStripMenuItem";
			this.moveToWorldToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+W";
			this.moveToWorldToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.moveToWorldToolStripMenuItem.Text = "Move to World";
			// 
			// toolStripSeparator15
			// 
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(310, 6);
			// 
			// textureApplicationToolStripMenuItem
			// 
			this.textureApplicationToolStripMenuItem.Name = "textureApplicationToolStripMenuItem";
			this.textureApplicationToolStripMenuItem.ShortcutKeyDisplayString = "Shift+A";
			this.textureApplicationToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.textureApplicationToolStripMenuItem.Text = "Texture Application";
			// 
			// replaceTexturesToolStripMenuItem
			// 
			this.replaceTexturesToolStripMenuItem.Name = "replaceTexturesToolStripMenuItem";
			this.replaceTexturesToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.replaceTexturesToolStripMenuItem.Text = "Replace Textures...";
			// 
			// textureLockToolStripMenuItem
			// 
			this.textureLockToolStripMenuItem.Checked = true;
			this.textureLockToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.textureLockToolStripMenuItem.Name = "textureLockToolStripMenuItem";
			this.textureLockToolStripMenuItem.ShortcutKeyDisplayString = "Shift+L";
			this.textureLockToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.textureLockToolStripMenuItem.Text = "Texture Lock";
			// 
			// textureBrowserToolStripMenuItem
			// 
			this.textureBrowserToolStripMenuItem.Name = "textureBrowserToolStripMenuItem";
			this.textureBrowserToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.textureBrowserToolStripMenuItem.Text = "Texture Browser";
			this.textureBrowserToolStripMenuItem.Click += new System.EventHandler(this.TextureBrowserToolStripMenuItemClick);
			// 
			// toolStripSeparator16
			// 
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(310, 6);
			// 
			// soundBrowserToolStripMenuItem
			// 
			this.soundBrowserToolStripMenuItem.Name = "soundBrowserToolStripMenuItem";
			this.soundBrowserToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S";
			this.soundBrowserToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.soundBrowserToolStripMenuItem.Text = "Sound Browser...";
			// 
			// fgdEditorToolStripMenuItem
			// 
			this.fgdEditorToolStripMenuItem.Name = "fgdEditorToolStripMenuItem";
			this.fgdEditorToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.fgdEditorToolStripMenuItem.Text = "FGD Editor...";
			this.fgdEditorToolStripMenuItem.Click += new System.EventHandler(this.FgdEditorToolStripMenuItemClick);
			// 
			// toolStripSeparator17
			// 
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(310, 6);
			// 
			// transformToolStripMenuItem
			// 
			this.transformToolStripMenuItem.Name = "transformToolStripMenuItem";
			this.transformToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+M";
			this.transformToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.transformToolStripMenuItem.Text = "Transform";
			// 
			// snapSelectedToGridToolStripMenuItem
			// 
			this.snapSelectedToGridToolStripMenuItem.Name = "snapSelectedToGridToolStripMenuItem";
			this.snapSelectedToGridToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+B";
			this.snapSelectedToGridToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.snapSelectedToGridToolStripMenuItem.Text = "Snap Selected to Grid";
			// 
			// snapSelectedToGridIndividuallyToolStripMenuItem
			// 
			this.snapSelectedToGridIndividuallyToolStripMenuItem.Name = "snapSelectedToGridIndividuallyToolStripMenuItem";
			this.snapSelectedToGridIndividuallyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+B";
			this.snapSelectedToGridIndividuallyToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.snapSelectedToGridIndividuallyToolStripMenuItem.Text = "Snap Selected to Grid Individually";
			// 
			// centerOriginsToolStripMenuItem
			// 
			this.centerOriginsToolStripMenuItem.Name = "centerOriginsToolStripMenuItem";
			this.centerOriginsToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.centerOriginsToolStripMenuItem.Text = "Center Origins";
			// 
			// alignObjectsToolStripMenuItem
			// 
			this.alignObjectsToolStripMenuItem.Name = "alignObjectsToolStripMenuItem";
			this.alignObjectsToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.alignObjectsToolStripMenuItem.Text = "Align Objects";
			// 
			// flipObjectsToolStripMenuItem
			// 
			this.flipObjectsToolStripMenuItem.Name = "flipObjectsToolStripMenuItem";
			this.flipObjectsToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.flipObjectsToolStripMenuItem.Text = "Flip Objects";
			// 
			// createPrefabToolStripMenuItem
			// 
			this.createPrefabToolStripMenuItem.Name = "createPrefabToolStripMenuItem";
			this.createPrefabToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+R";
			this.createPrefabToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.createPrefabToolStripMenuItem.Text = "Create Prefab";
			// 
			// toolStripSeparator18
			// 
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(310, 6);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
			this.optionsToolStripMenuItem.Text = "Options...";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItemClick);
			// 
			// pluginsToolStripMenuItem
			// 
			this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
			this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.pluginsToolStripMenuItem.Text = "Plugins";
			// 
			// tsmWindow
			// 
			this.tsmWindow.Name = "tsmWindow";
			this.tsmWindow.Size = new System.Drawing.Size(57, 20);
			this.tsmWindow.Text = "Window";
			// 
			// tsmHelp
			// 
			this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.helpToolStripMenuItem,
									this.toolStripSeparator19,
									this.aboutToolStripMenuItem});
			this.tsmHelp.Name = "tsmHelp";
			this.tsmHelp.Size = new System.Drawing.Size(40, 20);
			this.tsmHelp.Text = "Help";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.helpToolStripMenuItem.Text = "Help...";
			// 
			// toolStripSeparator19
			// 
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(123, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			// 
			// tspTop
			// 
			this.tspTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.tspTop.Location = new System.Drawing.Point(0, 24);
			this.tspTop.Name = "tspTop";
			this.tspTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.tspTop.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.tspTop.Size = new System.Drawing.Size(1004, 0);
			// 
			// stsMain
			// 
			this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tslBtmLeft,
									this.toolStripStatusLabel1,
									this.toolStripStatusLabel2});
			this.stsMain.Location = new System.Drawing.Point(0, 441);
			this.stsMain.Name = "stsMain";
			this.stsMain.Size = new System.Drawing.Size(792, 22);
			this.stsMain.TabIndex = 6;
			this.stsMain.Text = "statusStrip1";
			// 
			// tslBtmLeft
			// 
			this.tslBtmLeft.Name = "tslBtmLeft";
			this.tslBtmLeft.Size = new System.Drawing.Size(34, 17);
			this.tslBtmLeft.Text = "Hello!";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(634, 17);
			this.toolStripStatusLabel1.Spring = true;
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(109, 17);
			this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
			// 
			// tspLeft
			// 
			this.tspLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.tspLeft.Location = new System.Drawing.Point(0, 25);
			this.tspLeft.Name = "tspLeft";
			this.tspLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tspLeft.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tspLeft.Size = new System.Drawing.Size(0, 503);
			// 
			// tspRight
			// 
			this.tspRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.tspRight.Location = new System.Drawing.Point(1004, 24);
			this.tspRight.Name = "tspRight";
			this.tspRight.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tspRight.RowMargin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.tspRight.Size = new System.Drawing.Size(0, 504);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newToolStripButton1,
									this.openToolStripButton1,
									this.saveToolStripButton1,
									this.printToolStripButton1,
									this.toolStripSeparator21,
									this.cutToolStripButton1,
									this.copyToolStripButton1,
									this.pasteToolStripButton1,
									this.toolStripSeparator22,
									this.helpToolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(3, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(208, 25);
			this.toolStrip1.TabIndex = 19;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// newToolStripButton1
			// 
			this.newToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton1.Image")));
			this.newToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton1.Name = "newToolStripButton1";
			this.newToolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.newToolStripButton1.Text = "&New";
			this.newToolStripButton1.Click += new System.EventHandler(this.NewToolStripButton1Click);
			// 
			// openToolStripButton1
			// 
			this.openToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton1.Image")));
			this.openToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton1.Name = "openToolStripButton1";
			this.openToolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton1.Text = "&Open";
			// 
			// saveToolStripButton1
			// 
			this.saveToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton1.Image")));
			this.saveToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton1.Name = "saveToolStripButton1";
			this.saveToolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton1.Text = "&Save";
			this.saveToolStripButton1.Click += new System.EventHandler(this.SaveToolStripButton1Click);
			// 
			// printToolStripButton1
			// 
			this.printToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton1.Image")));
			this.printToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripButton1.Name = "printToolStripButton1";
			this.printToolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.printToolStripButton1.Text = "&Print";
			// 
			// toolStripSeparator21
			// 
			this.toolStripSeparator21.Name = "toolStripSeparator21";
			this.toolStripSeparator21.Size = new System.Drawing.Size(6, 25);
			// 
			// cutToolStripButton1
			// 
			this.cutToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cutToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton1.Image")));
			this.cutToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripButton1.Name = "cutToolStripButton1";
			this.cutToolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.cutToolStripButton1.Text = "C&ut";
			// 
			// copyToolStripButton1
			// 
			this.copyToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.copyToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton1.Image")));
			this.copyToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripButton1.Name = "copyToolStripButton1";
			this.copyToolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.copyToolStripButton1.Text = "&Copy";
			// 
			// pasteToolStripButton1
			// 
			this.pasteToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pasteToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton1.Image")));
			this.pasteToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripButton1.Name = "pasteToolStripButton1";
			this.pasteToolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.pasteToolStripButton1.Text = "&Paste";
			// 
			// toolStripSeparator22
			// 
			this.toolStripSeparator22.Name = "toolStripSeparator22";
			this.toolStripSeparator22.Size = new System.Drawing.Size(6, 25);
			// 
			// helpToolStripButton1
			// 
			this.helpToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton1.Image")));
			this.helpToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton1.Name = "helpToolStripButton1";
			this.helpToolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.helpToolStripButton1.Text = "He&lp";
			this.helpToolStripButton1.Click += new System.EventHandler(this.HelpToolStripButton1Click);
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.AutoScroll = true;
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(792, 1);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(792, 50);
			this.toolStripContainer1.TabIndex = 21;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mnuMain);
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			// 
			// dockTabMenu
			// 
			this.dockTabMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.closeToolStripMenuItem,
									this.closeAllToolStripMenuItem,
									this.closeAllButThisToolStripMenuItem,
									this.toolStripSeparator1,
									this.saveToolStripMenuItem,
									this.saveAllToolStripMenuItem,
									this.saveAllToolStripMenuItem1,
									this.toolStripSeparator23,
									this.copyFilePathToolStripMenuItem,
									this.openContainingFolderToolStripMenuItem});
			this.dockTabMenu.Name = "dockTabMenu";
			this.dockTabMenu.Size = new System.Drawing.Size(165, 192);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.closeToolStripMenuItem.Text = "Close";
			// 
			// closeAllToolStripMenuItem
			// 
			this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
			this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.closeAllToolStripMenuItem.Text = "Close All";
			// 
			// closeAllButThisToolStripMenuItem
			// 
			this.closeAllButThisToolStripMenuItem.Name = "closeAllButThisToolStripMenuItem";
			this.closeAllButThisToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.closeAllButThisToolStripMenuItem.Text = "Close All but this";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveAllToolStripMenuItem
			// 
			this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
			this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.saveAllToolStripMenuItem.Text = "Save As...";
			// 
			// saveAllToolStripMenuItem1
			// 
			this.saveAllToolStripMenuItem1.Name = "saveAllToolStripMenuItem1";
			this.saveAllToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
			this.saveAllToolStripMenuItem1.Text = "Save All";
			// 
			// toolStripSeparator23
			// 
			this.toolStripSeparator23.Name = "toolStripSeparator23";
			this.toolStripSeparator23.Size = new System.Drawing.Size(161, 6);
			// 
			// copyFilePathToolStripMenuItem
			// 
			this.copyFilePathToolStripMenuItem.Name = "copyFilePathToolStripMenuItem";
			this.copyFilePathToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.copyFilePathToolStripMenuItem.Text = "Copy File Path";
			// 
			// openContainingFolderToolStripMenuItem
			// 
			this.openContainingFolderToolStripMenuItem.Name = "openContainingFolderToolStripMenuItem";
			this.openContainingFolderToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.openContainingFolderToolStripMenuItem.Text = "Open Folder";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 463);
			this.Controls.Add(this.dockMain);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.stsMain);
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.MainMenuStrip = this.mnuMain;
			this.Name = "MainForm";
			this.Text = "wat?";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Activated += new System.EventHandler(this.MainFormActivated);
			this.Enter += new System.EventHandler(this.MainFormActivated);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyUp);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.stsMain.ResumeLayout(false);
			this.stsMain.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.dockTabMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem objectDumpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem RMFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem MAPToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fgdEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem textureBrowserToolStripMenuItem;
		public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem openContainingFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyFilePathToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
		private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem closeAllButThisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		public System.Windows.Forms.ContextMenuStrip dockTabMenu;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStripButton helpToolStripButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
		private System.Windows.Forms.ToolStripButton pasteToolStripButton1;
		private System.Windows.Forms.ToolStripButton copyToolStripButton1;
		private System.Windows.Forms.ToolStripButton cutToolStripButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
		private System.Windows.Forms.ToolStripButton printToolStripButton1;
		private System.Windows.Forms.ToolStripButton saveToolStripButton1;
		private System.Windows.Forms.ToolStripButton openToolStripButton1;
		private System.Windows.Forms.ToolStripButton newToolStripButton1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		public WeifenLuo.WinFormsUI.Docking.DockPanel dockMain;
		public System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
		private System.Windows.Forms.ToolStripMenuItem createPrefabToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem flipObjectsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem alignObjectsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem centerOriginsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem snapSelectedToGridIndividuallyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem snapSelectedToGridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem transformToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
		private System.Windows.Forms.ToolStripMenuItem soundBrowserToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
		private System.Windows.Forms.ToolStripMenuItem textureLockToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem replaceTexturesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem textureApplicationToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
		private System.Windows.Forms.ToolStripMenuItem moveToWorldToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tieToEntityToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.ToolStripMenuItem ungroupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
		private System.Windows.Forms.ToolStripMenuItem makeHollowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem carveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToBrushNumberToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToCoordinatesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem centerViewsOnSelectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripMenuItem autosize4ViewsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mapPropertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showInformationToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem closePortalFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadPortalFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closePointfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadPointfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem diffMapFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkForProblemsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem entityReportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showSelectedBrushNumberToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem largerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem smallerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gridSizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem snapToGridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteSpecialToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		public System.Windows.Forms.ToolStripPanel tspLeft;
		public System.Windows.Forms.ToolStripPanel tspRight;
		public System.Windows.Forms.ToolStripStatusLabel tslBtmLeft;
		public System.Windows.Forms.StatusStrip stsMain;
		private System.Windows.Forms.OpenFileDialog openVMF;
		private System.Windows.Forms.Timer tmrReload;
		public System.Windows.Forms.MenuStrip mnuMain;
		public System.Windows.Forms.ToolStripMenuItem tsmFile;
		public System.Windows.Forms.ToolStripMenuItem tsmNew;
		public System.Windows.Forms.ToolStripMenuItem tsmOpen;
		public System.Windows.Forms.ToolStripMenuItem tsmClose;
		public System.Windows.Forms.ToolStripMenuItem tsmSave;
		public System.Windows.Forms.ToolStripMenuItem tsmSaveAs;
		public System.Windows.Forms.ToolStripMenuItem tsmExport;
		public System.Windows.Forms.ToolStripMenuItem tsmRun;
		public System.Windows.Forms.ToolStripMenuItem tsmExit;
		public System.Windows.Forms.ToolStripMenuItem tsmEdit;
		public System.Windows.Forms.ToolStripMenuItem tsmMap;
		public System.Windows.Forms.ToolStripMenuItem tsmTools;
		public System.Windows.Forms.ToolStripMenuItem tsmWindow;
		public System.Windows.Forms.ToolStripMenuItem tsmHelp;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		public System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
		public System.Windows.Forms.ToolStripPanel tspTop;

	}
}
