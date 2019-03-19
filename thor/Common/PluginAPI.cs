/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 3/05/2009
 * Time: 12:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace thor
{
	public delegate void PluginMenuFunction();
	/// <summary>
	/// Description of PluginAPI.
	/// </summary>
	public static class PluginAPI
	{
		public static void AddTool(BaseTool tool)
		{
			Accessor.Instance.addTool(tool);
		}
		
		public static void AddMenuItem(ToolStripMenuItem item)
		{
			Accessor.Instance.Main.pluginsToolStripMenuItem.DropDownItems.Add(item);
		}
	}
}
