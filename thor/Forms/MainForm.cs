/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 4/09/2008
 * Time: 11:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using thor.Models;
using WeifenLuo.WinFormsUI.Docking;

namespace thor
{
	/// <summary>
	/// The main form of Thor
	/// </summary>
	public partial class MainForm : Form
	{
		private DockMapTools mapTools;
		
		public DockMapTools MapTools {
			get { return mapTools; }
		}
		private DockTexture textureTools;
		
		public DockTexture TextureTools {
			get { return textureTools; }
		}
		private DockVisgroups visgroupTools;
		
		public DockVisgroups VisgroupTools {
			get { return visgroupTools; }
		}
		private DockObject objectTools;
		
		public DockObject ObjectTools {
			get { return objectTools; }
		}
		private DockConsole messageConsole;
		
		public DockConsole MessageConsole {
			get { return messageConsole; }
		}
		
		public MainForm()
		{
			Accessor a = Accessor.Instance;
			InitializeComponent();
			makeToolStrip();
			
			mapTools = new DockMapTools();
			//mapTools.Show(dockMain);
			
			textureTools = new DockTexture();
			//textureTools.Show(dockMain);
			
			visgroupTools = new DockVisgroups();
			//visgroupTools.Show(dockMain);
			
			objectTools = new DockObject();
			//objectTools.Show(dockMain);
			
			messageConsole = new DockConsole();
			//messageConsole.Show(dockMain);
			
			dockMain.SuspendLayout(true);
			System.IO.Stream str = new System.IO.FileStream("test.xml",System.IO.FileMode.Open);
			dockMain.LoadFromXml(str, new DeserializeDockContent(GetContentFromPersistString));
			str.Close();
			dockMain.ResumeLayout(true,true);
			//a.add3DView(new OGLView());
		}

		
		void MainFormLoad(object sender, EventArgs e)
		{
			Accessor a = Accessor.Instance;
			a.setForm(this);
			a.init();
			// HLLibFunctions.getAllTexturesFromWad("D:\\Half-Life\\Wads\\halflife.wad");
		}
		
		public void LogMessage(string s)
		{
			messageConsole.WriteLine(s);
		}
		
		private void makeToolStrip()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			
			//
			//
			//
			
		}
		
		private IDockContent GetContentFromPersistString(string persistString)
		{
			if (persistString == typeof(DockMapTools).ToString())
				return mapTools;
			else if (persistString == typeof(DockTexture).ToString())
				return textureTools;
			else if (persistString == typeof(DockVisgroups).ToString())
				return visgroupTools;
			else if (persistString == typeof(DockObject).ToString())
				return objectTools;
			else if (persistString == typeof(DockConsole).ToString())
				return messageConsole;
			else
				return null;
		}
		
		//string downdir = "C:\\Documents and Settings\\Dan\\My Documents\\My Junk\\Downloads\\";
		
		public void OpenMap()
		{
			openVMF.Filter = "RMF Files (*.rmf)|*.rmf|MAP Files (*.map)|*.map|VMF Files (*.vmf)|*.vmf";
			if (openVMF.ShowDialog() == DialogResult.OK) {
				GameChooseForm gc = new GameChooseForm();
				if (gc.ShowDialog() == DialogResult.OK) {
					Document d = new Document(gc.SelectedConfig);
					d.MapFile = openVMF.FileName;
					MapParserInterface p = MapParserFactory.GetParser(openVMF.FileName);
					MapClass m;
					//try {
						m = p.parse(openVMF.FileName);
					//}
					//catch (Exception ex) {
					//	MessageBox.Show(ex.Message);
					//	return;
					//}
					d.Map = m;
					Accessor.Instance.OpenDocuments.Add(d);
					d.show();
				}
				gc.Dispose();
			}
		}
		
		public void NewMap()
		{
			GameChooseForm gc = new GameChooseForm();
			if (gc.ShowDialog() == DialogResult.OK) {
				Document d = new Document(gc.SelectedConfig);
				Accessor.Instance.OpenDocuments.Add(d);
				d.show();
			}
			gc.Dispose();
		}
		
		public void SaveMap()
		{
			
		}
		
		public void SaveMapAs()
		{
			Document doc = Accessor.Instance.getActiveDocument();
			if (doc == null) return;
			SaveFileDialog savemap = new SaveFileDialog();
			savemap.Filter = "RMF Files (*.rmf)|*.rmf|MAP Files (*.map)|*.map|VMF Files (*.vmf)|*.vmf";
			if (savemap.ShowDialog() == DialogResult.OK) {
				MapParserInterface p = MapParserFactory.GetParser(savemap.FileName);
				p.save(doc, savemap.FileName);
			}
			savemap.Dispose();
		}
		
		public void RunMap()
		{
			CompileForm cf = new CompileForm();
			cf.ShowDialog();
			cf.Dispose();
		}
		
		void TsbOpenClick(object sender, EventArgs e)
		{
			OpenMap();
		}
		
		void TsmOpenClick(object sender, EventArgs e)
		{
			OpenMap();
		}
		
		void TsmNewClick(object sender, EventArgs e)
		{
			NewMap();
		}
		
		void TsmSaveAsClick(object sender, EventArgs e)
		{
			SaveMapAs();
		}
		
		void OptionsToolStripMenuItemClick(object sender, EventArgs e)
		{
			SettingsForm settingsf = new SettingsForm();
			settingsf.ShowDialog();
			settingsf.Dispose();
		}
		
		void MainFormActivated(object sender, EventArgs e)
		{
			if (ActiveMdiChild is EditForm) {
				(ActiveMdiChild as EditForm).AssociatedDocument.refreshAllViews();
			}
		}
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			Accessor.Instance.ThorHotkeys.keyDown(e);
		}
		
		void MainFormKeyUp(object sender, KeyEventArgs e)
		{
			Accessor.Instance.ThorHotkeys.keyUp(e);
		}
		
		void NewToolStripButton1Click(object sender, EventArgs e)
		{
			NewMap();
		}
		
		void SaveToolStripButton1Click(object sender, EventArgs e)
		{
			SaveMap();
		}
		
		void HelpToolStripButton1Click(object sender, EventArgs e)
		{
			TestForm t = new TestForm();
			t.ShowDialog();
			t.Dispose();
		}
		
		public void addToolButton(BaseTool tool)
		{
			mapTools.AddTool(tool);
		}
		
		public void selectTool(BaseTool tool)
		{
			mapTools.selectTool(tool);
		}
		
		public void updateGridSize(decimal dist)
		{
			toolStripStatusLabel1.Text = "Grid: " + dist.ToString();
		}
		
		protected override void OnActivated(EventArgs e)
		{
			if (Accessor.Instance.Main != null) {
				Document doc = Accessor.Instance.getActiveDocument();
				if (doc != null) doc.refreshAllViews();
			}
			base.OnActivated(e);
		}
		
		void TsmRunClick(object sender, EventArgs e)
		{
			RunMap();
		}
		
		void TextureBrowserToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (Accessor.Instance.getActiveDocument() != null) {
				Accessor.Instance.getActiveDocument().showTextureBrowser();
			}
		}
		
		void FgdEditorToolStripMenuItemClick(object sender, EventArgs e)
		{
			FGDEditor editor = new FGDEditor();
			editor.ShowDialog();
			editor.Dispose();
		}
		
		void ObjectDumpToolStripMenuItemClick(object sender, EventArgs e)
		{
			Document doc = Accessor.Instance.getActiveDocument();
			if (doc == null) return;
			SaveFileDialog savemap = new SaveFileDialog();
			savemap.Filter = "Thor Object Dumps (*.tod)|*.tod";
			if (savemap.ShowDialog() == DialogResult.OK) {
				string a = "\r\n\r\nSELECTED OBJECTS\r\n";
				foreach (MapObject o in doc.SelectedObjects) a += o.dump(0) + "\r\n";
				System.IO.File.WriteAllText(savemap.FileName, doc.Map.Dump() + a);
			}
			savemap.Dispose();
		}
		
		void DockMainContentRemoved(object sender, DockContentEventArgs e)
		{
			if (e.Content is DockEdit) {
				(e.Content as DockEdit).Dispose();
				LogMessage("Content removed");
			}
		}
	}
}
