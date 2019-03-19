/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 27/12/2008
 * Time: 9:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using thor.Models;

namespace thor
{
	/// <summary>
	/// Document is the core of an open file. It holds the
	/// display window, as well as the 4 rendering windows.
	/// It also has the map itself, the undo levels, and
	/// the map tools (and the current selected tool).
	/// </summary>
	public class Document : IDisposable
	{
		GameData data;
		MapClass map;
		
		bool disposed;
		
		public bool Disposed {
			get { return disposed; }
		}
		
		List<MapObject> objectCache;
		
		DockEdit form;
		
		List<BaseTool> tools;
		BaseTool selectedTool;
		
		NewGLMapView2D xy2D;
		
		public NewGLMapView2D Xy2D {
			get { return xy2D; }
		}
		NewGLMapView2D xz2D;
		
		public NewGLMapView2D Xz2D {
			get { return xz2D; }
		}
		NewGLMapView2D yz2D;
		
		public NewGLMapView2D Yz2D {
			get { return yz2D; }
		}
		
		MapView3D view3D;
		
		public MapView3D View3D {
			get { return view3D; }
		}
		
		Game gameConfig;
		
		HistoryManager history;
		
		List<TexturePackage> packages;
		List<TextureObject> recentTextures;
		
		List<MapObject> selectedObjects;
		
		public List<MapObject> SelectedObjects {
			get { return selectedObjects; }
		}
		
		string mapFile;
		
		public string MapFile {
			get { return mapFile; }
			set { mapFile = value; }
		}
		
		public HistoryManager History {
			get { return history; }
		}
		
		public List<TextureObject> RecentTextures {
			get { return recentTextures; }
		}
		
		public Game GameConfig {
			get { return gameConfig; }
		}
		
		public List<MapObject> ObjectCache {
			get { return objectCache; }
		}
		
		public GameData Data {
			get { return data; }
			set { data = value; }
		}
		
		public MapClass Map {
			get { return map; }
			set { setMapClass(value); }
		}
		
		public DockEdit Form {
			get { return form; }
			set { form = value; }
		}
		
		public List<BaseTool> Tools {
			get { return tools; }
			set { tools = value; }
		}
		
		public BaseTool SelectedTool {
			get { return selectedTool; }
			set { selectedTool = value; }
		}
		
		TextureBrowserForm textureBrowser;
		EntityEditor entityEditor;
		
		private void setMapClass(MapClass m)
		{
			map = m;
			
			Dictionary<string, TextureObject> cache = new Dictionary<string, TextureObject>();
			List<MapObject> children = map.Worldspawn.getAllChildren();
			
			ProgressForm pgf = new ProgressForm();
			pgf.Text = "Loading Textures...";
			pgf.progressBar.Maximum = children.Count;
			pgf.Show();
			
			foreach (MapObject o in children) {
				if (o is MapSolid) {
					MapSolid s = (o as MapSolid);
					foreach (MapFace f in s.Faces) {
						string n = f.Texture;
						TextureObject t = null;
						if (cache.ContainsKey(n)) {
							t = cache[n];
							if (t != null) t.addReference();
						} else {
							foreach (TexturePackage p in packages) {
								t = p.getTextureObject(n);
								if (t != null) {
									t.addReference();
									break;
								}
							}
							// even if the texture is null it can be cached
							cache.Add(n, t);
						}
						f.TextureResource = t;
						f.calculateTextureCoordinates();
					}
				} else if (o is MapEntity) {
					MapEntity e = o as MapEntity;
					e.EntityData = data.getClass(e.Data.Name, GameDataClassTypes.Any);
				}
				pgf.progressBar.Value++;
			}
			
			pgf.Close();
			pgf.Dispose();
			
			updateCache();
		}
		
		public void addToMap(MapObject o)
		{
			map.Worldspawn.addChild(o);
			updateCache();
		}
		
		public void addToMap(List<MapObject> list)
		{
			foreach (MapObject o in list) map.Worldspawn.addChild(o);
			updateCache();
		}
		
		public void removeFromMap(MapObject o)
		{
			map.Worldspawn.removeChild(o);
			updateCache();
		}
		
		public void removeFromMap(List<MapObject> list)
		{
			foreach (MapObject o in list) map.Worldspawn.removeChild(o);
			updateCache();
		}
		
		public Document(Game config)
		{
			history = new HistoryManager(this);
			
			gameConfig = config;
			map = new MapClass();
			mapFile = "";
			objectCache = new List<MapObject>();
			selectedObjects = new List<MapObject>();
			updateCache();
			
			FGDParser parse = new FGDParser();
			data = new GameData();
			foreach (string fgd in gameConfig.FGDs) {
				data.merge(parse.parse(fgd));
			}
			
			form = new DockEdit(this);
			populateToolList();
			xy2D = new NewGLMapView2DXY(this);
			xz2D = new NewGLMapView2DXZ(this);
			yz2D = new NewGLMapView2DYZ(this);
			view3D = new MapView3D(this);
			xy2D.Dock = System.Windows.Forms.DockStyle.Fill;
			xz2D.Dock = System.Windows.Forms.DockStyle.Fill;
			yz2D.Dock = System.Windows.Forms.DockStyle.Fill;
			view3D.Dock = System.Windows.Forms.DockStyle.Fill;
			form.Views.TopRightPanel.Controls.Add(xy2D);
			form.Views.BottomLeftPanel.Controls.Add(yz2D);
			form.Views.BottomRightPanel.Controls.Add(xz2D);
			form.Views.TopLeftPanel.Controls.Add(view3D);
			packages = new List<TexturePackage>();
			recentTextures = new List<TextureObject>();
			textureBrowser = new TextureBrowserForm();
			foreach (string wad in gameConfig.WADs) {
				TexturePackage pkg = TextureManager.addWADFile(wad);
				pkg.addSubscriber(this);
				packages.Add(pkg);
				textureBrowser.addPackage(pkg);
			}
			
			entityEditor = new EntityEditor(this);
			disposed = false;
		}
		
		public static Document makeDummyDocument()
		{
			return new Document(true);
		}
		
		private Document(bool dummy)
		{
			
		}
		
		public TextureObject showTextureBrowser()
		{
			if (textureBrowser.ShowDialog() == DialogResult.OK) {
				return textureBrowser.SelectedTexture;
			} else {
				return null;
			}
		}
		
		public void refreshAllViews()
		{
			refresh2DViews();
			refresh3DView();
		}
		
		public void refresh3DView()
		{
			if (view3D != null) view3D.update();
		}
		
		public void refresh2DViews()
		{
			if (xy2D != null) xy2D.update();
			if (xz2D != null) xz2D.update();
			if (yz2D != null) yz2D.update();
		}
		
		public void updateCache()
		{
			objectCache.Clear();
			selectedObjects.Clear();
			foreach (MapObject o in map.Worldspawn.getAllChildren()) {
				objectCache.Add(o);
				if (o.Selected) selectedObjects.Add(o);
			}
			refreshAllViews();
		}
		
		public void unselectAllObjects()
		{
			foreach (MapObject o in selectedObjects) {
				o.setSelect(false);
			}
			selectedObjects.Clear();
		}
		
		public void setGridDistance(decimal dist)
		{
			
		}
		
		public void incGridDistance()
		{
			decimal dist = xy2D.GridSize;
			dist *= 2;
			if (dist > 1024) dist = xy2D.GridSize;
			xy2D.GridSize = dist;
			xz2D.GridSize = dist;
			yz2D.GridSize = dist;
			Accessor.Instance.Main.updateGridSize(dist);
			refreshAllViews();
		}
		
		public void decGridDistance()
		{
			decimal dist = xy2D.GridSize;
			dist /= 2;
			if (dist < 0.25m) dist = xy2D.GridSize;
			xy2D.GridSize = dist;
			yz2D.GridSize = dist;
			xz2D.GridSize = dist;
			Accessor.Instance.Main.updateGridSize(dist);
			refreshAllViews();
		}
		
		private void populateToolList()
		{
			tools = new List<BaseTool>();
			foreach (BaseTool t in Accessor.Instance.MasterToolList) tools.Add(t.Copy(this));
			selectedTool = tools[0];
			Accessor.Instance.Main.selectTool(selectedTool);
		}
		
		public BaseTool getTool(string name)
		{
			foreach (BaseTool t in tools) {
				if (t.ToolName.ToLower() == name.ToLower()) {
					return t;
				}
			}
			return null;
		}
		
		public void selectTool(string name)
		{
			foreach (BaseTool t in tools) {
				if (t.ToolName == name) {
					selectedTool.selected(false);
					selectedTool = t;
					selectedTool.selected(true);
					refreshAllViews();
					return;
				}
			}
		}
		
		public void properties()
		{
			entityEditor.Show(Accessor.Instance.Main);
		}
		
		public void show()
		{
			form.TabPageContextMenuStrip = Accessor.Instance.Main.dockTabMenu;
			form.Show(Accessor.Instance.Main.dockMain);
			form.Views.autosize();
		}
		
		public void compile()
		{
			Build bld = gameConfig.Build;
			if (!File.Exists(mapFile)) {
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "RMF Files (*.rmf)|*.rmf|MAP Files (*.map)|*.map|VMF Files (*.vmf)|*.vmf";
				sfd.InitialDirectory = gameConfig.MapDirectory;
				if (sfd.ShowDialog() == DialogResult.OK) {
					mapFile = sfd.FileName;
					MapParserInterface p = MapParserFactory.GetParser(mapFile);
					p.save(this, mapFile);
				} else {
					return;
				}
			}
			MAPParser mp = new MAPParser();
			string noExtName = Path.GetFileNameWithoutExtension(mapFile);
			string saveDir = Path.GetDirectoryName(mapFile);
			string mapSaved = Path.ChangeExtension(mapFile, "map");
			string bspPath = Path.ChangeExtension(mapFile, "bsp");
			string bspName = Path.GetFileName(bspPath);
			string mapDir = Path.Combine(Path.Combine(gameConfig.GameDirectory, gameConfig.ModDirectory), "maps");
			if (!gameConfig.IsWON) {
				string stmins = Accessor.Instance.ThorSettings.getString("SteamInstallDir");
				string stmusr = Accessor.Instance.ThorSettings.getString("SteamUsername");
				string stmapp = Path.Combine(Path.Combine(stmins, "steamapps"), stmusr);
				mapDir = Path.Combine(stmapp, mapDir);
			}
			mp.save(this, mapSaved);
			string[] batch = new string[] {
				"\"" + Path.Combine(bld.ExecutableFolder, bld.CsgExecutable) + "\" \"" + mapSaved + "\" " + bld.CsgFlags,
				"\"" + Path.Combine(bld.ExecutableFolder, bld.BspExecutable) + "\" \"" + mapSaved + "\" " + bld.BspFlags,
				"\"" + Path.Combine(bld.ExecutableFolder, bld.VisExecutable) + "\" \"" + mapSaved + "\" " + bld.VisFlags,
				"\"" + Path.Combine(bld.ExecutableFolder, bld.RadExecutable) + "\" \"" + mapSaved + "\" " + bld.RadFlags,
				"copy \"" + bspPath + "\" \"" + Path.Combine(mapDir, bspName) + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "bsp") + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "lin") + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "log") + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "p0") + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "p1") + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "p2") + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "p3") + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "prt") + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "pts") + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "wic") + "\"",
				//let's not delete the map file.
				//(Path.GetExtension(mapFile) != "map") ? "" : "del \"" + Path.ChangeExtension(mapFile, "map") + "\"",
				"del \"" + Path.ChangeExtension(mapFile, "bat") + "\""
			};
			string run = string.Join("\n", batch);
			string bat = Path.ChangeExtension(mapFile, "bat");
			File.WriteAllText(bat, run);
			System.Diagnostics.Process.Start(bat);
		}
		
		public void Dispose()
		{
			xy2D.Dispose();
			xz2D.Dispose();
			yz2D.Dispose();
			view3D.Dispose();
		}
	}
}
