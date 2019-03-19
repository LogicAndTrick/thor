/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/06/2009
 * Time: 4:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace thor
{
	/// <summary>
	/// Description of StaticHotkeys.
	/// </summary>
	public static class StaticHotkeys
	{
		private static object[][] hotKeys = new object[][] {
		  //new object[] { "Identifier", 			new Hotkeys.hotkeyTrigger(delegate), 				"Default", 		"Description" },
			new object[] { "FourView_Auto", 		new Hotkeys.hotkeyTrigger(FourView_Auto), 			"Ctrl+A", 		"Autosize the 4 Views" },
			new object[] { "FourView_TopLeft", 		new Hotkeys.hotkeyTrigger(FourView_TopLeft), 		"F5", 			"Focus on the 3D View" },
			new object[] { "FourView_TopRight", 	new Hotkeys.hotkeyTrigger(FourView_TopRight), 		"F2", 			"Focus on the XY View" },
			new object[] { "FourView_BottomLeft", 	new Hotkeys.hotkeyTrigger(FourView_BottomLeft), 	"F4", 			"Focus on the YZ View" },
			new object[] { "FourView_BottomRight", 	new Hotkeys.hotkeyTrigger(FourView_BottomRight), 	"F3", 			"Focus on the XZ View" },
			new object[] { "FourView_All", 			new Hotkeys.hotkeyTrigger(FourView_All), 			"F6", 			"Return to 4 View Focus" },
			
			new object[] { "File_New", 				new Hotkeys.hotkeyTrigger(File_New),				"Ctrl+N", 		"Create a new map" },
			new object[] { "File_Open", 			new Hotkeys.hotkeyTrigger(File_Open),				"Ctrl+O", 		"Open an existing map" },
			new object[] { "File_Save", 			new Hotkeys.hotkeyTrigger(File_Save),				"Ctrl+S", 		"Save the current map" },
			new object[] { "File_Export", 			new Hotkeys.hotkeyTrigger(File_Export),				"Ctrl+E", 		"Export the current map" },
			new object[] { "File_Compile", 			new Hotkeys.hotkeyTrigger(File_Compile),			"F9", 			"Compile the current map" },
			
			new object[] { "Grid_Increase", 		new Hotkeys.hotkeyTrigger(Grid_Increase),			"]", 			"Increase the grid size of the current map" },
			new object[] { "Grid_Decrease", 		new Hotkeys.hotkeyTrigger(Grid_Decrease),			"[", 			"Decrease the grid size of the current map" },
			
			new object[] { "History_Undo",			new Hotkeys.hotkeyTrigger(History_Undo),			"Ctrl+Z",		"Undo" },
			new object[] { "History_Redo",			new Hotkeys.hotkeyTrigger(History_Redo),			"Ctrl+Y",		"Redo" },
			
			new object[] { "Map_Properties",		new Hotkeys.hotkeyTrigger(Map_Properties),			"Alt+Enter",	"Open the object properties dialog." }
		};
		
		public static void subscribeAll(Hotkeys hk)
		{
			foreach (object[] o in hotKeys) {
				hk.subscribe((string)o[2], (Hotkeys.hotkeyTrigger)o[1]);
			}
		}
		
		#region Four View
		public static void FourView_Auto()
		{
			if (Accessor.Instance.getActiveForm() != null) {
				Accessor.Instance.getActiveForm().Views.autosize();
			}
		}
		
		public static void FourView_TopLeft()
		{
			if (Accessor.Instance.getActiveForm() != null) {
				Accessor.Instance.getActiveForm().Views.Display = QuadSplitControl.DisplayMode.TopLeft;
			}
		}
		
		public static void FourView_TopRight()
		{
			if (Accessor.Instance.getActiveForm() != null) {
				Accessor.Instance.getActiveForm().Views.Display = QuadSplitControl.DisplayMode.TopRight;
			}
		}
		
		public static void FourView_BottomLeft()
		{
			if (Accessor.Instance.getActiveForm() != null) {
				Accessor.Instance.getActiveForm().Views.Display = QuadSplitControl.DisplayMode.BottomLeft;
			}
		}
		
		public static void FourView_BottomRight()
		{
			if (Accessor.Instance.getActiveForm() != null) {
				Accessor.Instance.getActiveForm().Views.Display = QuadSplitControl.DisplayMode.BottomRight;
			}
		}
		
		public static void FourView_All()
		{
			if (Accessor.Instance.getActiveForm() != null) {
				Accessor.Instance.getActiveForm().Views.Display = QuadSplitControl.DisplayMode.Normal;
			}
		}
		#endregion
		
		#region File
		public static void File_New()
		{
			Accessor.Instance.Main.NewMap();
		}
		
		public static void File_Open()
		{
			Accessor.Instance.Main.OpenMap();
		}
		
		public static void File_Save()
		{
			Accessor.Instance.Main.SaveMap();
		}
		
		public static void File_Export()
		{
			//Accessor.Instance.Main
		}
		
		public static void File_Compile()
		{
			Accessor.Instance.Main.RunMap();
		}
		#endregion
		
		#region Grid
		public static void Grid_Increase()
		{
			Document doc = Accessor.Instance.getActiveDocument();
			if (doc != null) {
				doc.incGridDistance();
			}
		}
		public static void Grid_Decrease()
		{
			Document doc = Accessor.Instance.getActiveDocument();
			if (doc != null) {
				doc.decGridDistance();
			}
		}
		#endregion
		
		#region History
		public static void History_Undo()
		{
			Document doc = Accessor.Instance.getActiveDocument();
			if (doc != null) {
				doc.History.Undo(doc.Map);
			}
		}
		public static void History_Redo()
		{
			Document doc = Accessor.Instance.getActiveDocument();
			if (doc != null) {
				doc.History.Redo(doc.Map);
			}
		}
		#endregion
		
		#region Map
		public static void Map_Properties()
		{
			Document doc = Accessor.Instance.getActiveDocument();
			if (doc != null) {
				doc.properties();
			}
		}
		#endregion
	}
}
