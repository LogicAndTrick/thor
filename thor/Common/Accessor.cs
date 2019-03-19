/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 4/09/2008
 * Time: 11:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using IronPython.Hosting;
using IronPython.Runtime.Exceptions;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace thor
{
	/// <summary>
	/// Description of Accessor.
	/// </summary>
	public sealed class Accessor
	{
		private static Accessor instance = new Accessor();
		private MainForm mnfm;
		private List<BaseTool> masterToolList;
		private List<BrushInterface> masterPrimitiveList;
		private List<Document> openDocuments;
		private Document dummyDoc;
		
		private Settings thorSettings;
		private Hotkeys thorHotkeys;
		
		public Settings ThorSettings {
			get { return thorSettings; }
		}
		
		public Hotkeys ThorHotkeys {
			get { return thorHotkeys; }
		}
		
		private bool control;
		private bool alt;
		private bool shift;
		private List<Keys> pressedKeys;
		
		public List<Keys> PressedKeys {
			get { return pressedKeys; }
			set { pressedKeys = value; }
		}
		
		public List<BrushInterface> MasterPrimitiveList {
			get { return masterPrimitiveList; }
		}
		
		public List<BaseTool> MasterToolList {
			get { return masterToolList; }
			set { masterToolList = value; }
		}
		
		public bool Control {
			get { return control; }
			set { control = value; }
		}
		
		public bool Alt {
			get { return alt; }
			set { alt = value; }
		}
		
		public bool Shift {
			get { return shift; }
			set { shift = value; }
		}
		
		public static Accessor Instance {
			get { return instance; }
		}
		
		public MainForm Main {
			get { return mnfm; }
			set { mnfm = value; initPython(); }
		}
		
		public List<Document> OpenDocuments {
			get { return openDocuments; }
			set { openDocuments = value; }
		}
		
		private Accessor()
		{
			openDocuments = new List<Document>();
			pressedKeys = new List<Keys>();
			control = alt = shift = false;
			dummyDoc = Document.makeDummyDocument();
			masterToolList = new List<BaseTool>();
			masterPrimitiveList = new List<BrushInterface>();
			thorSettings = new Settings();
			thorHotkeys = new Hotkeys();
			
			populateMasterToolList();
			populateMasterPrimitiveList();
		}
		
		public void init()
		{
			initPython();
			PythonExecFolder("Plugins",true);
			
			thorHotkeys.start();
			StaticHotkeys.subscribeAll(thorHotkeys);
			
			SettingsForm tempf = new SettingsForm();
			tempf.updateSettings();
			tempf.Dispose();
			
			//hotkeys here
		}
		
		private void populateMasterPrimitiveList()
		{
			addPrimitive(new BlockBrush());
			addPrimitive(new CylinderBrush());
			addPrimitive(new ConeBrush());
			addPrimitive(new PipeBrush());
			addPrimitive(new TetrehedronBrush());
			addPrimitive(new SpikeBrush());
			addPrimitive(new TorusBrush());
		}
		
		public void addPrimitive(BrushInterface bsh)
		{
			masterPrimitiveList.Add(bsh);
		}
		
		public BrushInterface getPrimitive(string name)
		{
			foreach (BrushInterface b in masterPrimitiveList) {
				if (b.getName() == name) return b;
			}
			return null;
		}
		
		private void populateMasterToolList()
		{
			//addTool(new OldSelectTool(dummyDoc));
			addTool(new SelectTool(dummyDoc));
			addTool(new CameraTool(dummyDoc));
			addTool(new EntityTool(dummyDoc));
			addTool(new BrushTool(dummyDoc));
			addTool(new TextureTool(dummyDoc));
			//decals
			addTool(new ClipTool(dummyDoc));
			addTool(new VMTool(dummyDoc));
		}
		
		public void addTool(BaseTool tool)
		{
			masterToolList.Add(tool);
			if (mnfm == null) return;
			mnfm.addToolButton(tool);
		}
		
		public void selectTool(string name)
		{
			if ((object)getActiveDocument() == null) return;
			else getActiveDocument().selectTool(name);
		}
		
		public static bool keyPressed(Keys k)
		{
			return Accessor.instance.pressedKeys.Contains(k);
		}
		
		#region Python
		ScriptEngine pyEngine;
		ScriptRuntime pyRuntime;
		public void initPython()
		{
			if ((object)mnfm == null) return;
			pyEngine = Python.CreateEngine();
			pyRuntime = pyEngine.Runtime;
			Assembly mainAssembly = Assembly.GetExecutingAssembly();
			
			//string rootDir = Directory.GetParent(mainAssembly.Location).FullName;
			
			pyRuntime.LoadAssembly(mainAssembly);
			pyRuntime.LoadAssembly(typeof(String).Assembly);
			pyRuntime.LoadAssembly(typeof(Uri).Assembly);
			pyRuntime.LoadAssembly(typeof(Form).Assembly);
			pyRuntime.LoadAssembly(typeof(System.Drawing.Color).Assembly);
			pyRuntime.LoadAssembly(typeof(OpenTK.GLControl).Assembly);
			pyRuntime.LoadAssembly(typeof(QuickForms.QuickForm).Assembly);
		}
		
		/* http://www.voidspace.org.uk/ironpython/hosting_api.shtml */
		public void PythonExec(string path)
		{
			ScriptEngine engine = Python.CreateEngine();
			try
			{
				ScriptSource script = pyEngine.CreateScriptSourceFromFile(path);
				CompiledCode code = script.Compile();
				ScriptScope scope = pyEngine.CreateScope();
				code.Execute(scope);
			}
			catch (SyntaxErrorException e)
			{
				string msg = "Syntax error in \"{0}\"";
				ShowError(msg, Path.GetFileName(path), e);
			}
			catch (SystemExitException e)
			{
				string msg = "SystemExit in \"{0}\"";
				ShowError(msg, Path.GetFileName(path), e);
			}
			
			catch (Exception e)
			{
				string msg = "Error loading plugin \"{0}\"";
				ShowError(msg, Path.GetFileName(path), e);
			}
		}
			
		public void ShowError(string title, string name, Exception e)
		{
			string caption = String.Format(title, name);
			ExceptionOperations eo = pyEngine.GetService<ExceptionOperations>();
			string error = eo.FormatException(e);
			MessageBox.Show(error, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
		public void PythonExecFolder(string folder, bool recursive)
		{
			SearchOption srch = SearchOption.TopDirectoryOnly;
			if (recursive) srch = SearchOption.AllDirectories;
			foreach (string file in Directory.GetFiles(folder,"*.py",srch))
			{
				PythonExec(file);
			}
		}
		#endregion
		
		#region Forms and Documents
		public void setForm(MainForm f)
		{
			this.mnfm = f;
			foreach (BaseTool tool in masterToolList) mnfm.addToolButton(tool);
			initPython();
		}
		
		public Document getActiveDocument()
		{
			if ((object)getActiveForm() == null) return null;
			else return getActiveForm().AssociatedDocument;
		}
		
		public DockEdit getActiveForm()
		{
			if (this.mnfm.dockMain.ActiveDocument is DockEdit) return (DockEdit)this.mnfm.dockMain.ActiveDocument;
			else return null;
		}
		#endregion
	}
}
