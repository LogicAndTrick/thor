/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 26/04/2009
 * Time: 1:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using thor.Models;
using Thorm;

namespace thor
{
	/// <summary>
	/// Description of Settings.
	/// </summary>
	public class Settings
	{
		public Settings()
		{
			
		}
		
		#region Saving and Loading Data
		
		public void saveData(System.Collections.IList coll)
		{
			foreach (Control c in coll) {
				string name = ControlValueHandler.getName(c);
				if (name != null) {
					string val = ControlValueHandler.getValue(c);
					Setting st = Data.DB.Query<Setting>().Where("settingKey", Condition.Equal, name).ExecuteSingle();
					if (st != null) {
						st.Val = val;
					} else {
						st = new Setting();
						st.Key = name;
						st.Val = val;
						Data.DB.Insert(st);
					}
				}
			}
			Data.DB.Save();
		}
		
		public void saveNewData(System.Collections.IList coll)
		{
			foreach (Control c in coll) {
				string name = ControlValueHandler.getName(c);
				if (name != null) {
					string val = ControlValueHandler.getValue(c);
					Setting st = Data.DB.Query<Setting>().Where("settingKey", Condition.Equal, name).ExecuteSingle();
					if (st == null) {
						st = new Setting();
						st.Key = name;
						st.Val = val;
						Data.DB.Insert(st);
					}
				}
			}
			Data.DB.Save();
		}
		
		public void loadData(System.Collections.IList coll)
		{
			foreach (Control c in coll) {
				string name = ControlValueHandler.getName(c);
				if (name != null) {
					Setting st = Data.DB.Query<Setting>().Where("settingKey", Condition.Equal, name).ExecuteSingle();
					if (st != null) {
						ControlValueHandler.setValue(c, st.Val);
					}
				} else if (c.Name == "tree_builds") {
					TreeView v = (TreeView)c;
					loadBuildConfigs(v);
				} else if (c.Name == "tree_games") {
					TreeView v = (TreeView)c;
					loadGameConfigs(v);
				}
			}
		}
		
		public void loadBuildConfigs(TreeView tree)
		{
			tree.Nodes.Clear();
			tree.Nodes.Add("Goldsource");
			tree.Nodes.Add("Source");
			foreach (Build bld in Data.DB.List<Build>()) {
				tree.Nodes[bld.EngineID - 1].Nodes.Add(bld.Name);
			}
			tree.ExpandAll();
		}
		
		public void loadGameConfigs(TreeView tree)
		{
			tree.Nodes.Clear();
			tree.Nodes.Add("Goldsource (WON)");
			tree.Nodes.Add("Goldsource (Steam)");
			tree.Nodes.Add("Source");
			foreach (Game game in Data.DB.List<Game>()) {
				int tmp = game.EngineID;
				if (game.IsWON) tmp = 0;
				tree.Nodes[tmp].Nodes.Add(game.Name);
			}
			tree.ExpandAll();
		}
		
		#endregion
		
		#region Accessing Data
		public Color getColour(string name)
		{
			Setting st = Data.DB.Query<Setting>().Where("settingKey", Condition.Equal, name).ExecuteSingle();
			if (st != null) {
				return Color.FromArgb(int.Parse(st.Val));
			}
			else {
				return Color.Black;
			}
		}
		
		public bool getBool(string name)
		{
			Setting st = Data.DB.Query<Setting>().Where("settingKey", Condition.Equal, name).ExecuteSingle();
			if (st != null) {
				return (st.Val == "true");
			}
			else {
				return false;
			}
		}
		
		public decimal getDecimal(string name)
		{
			Setting st = Data.DB.Query<Setting>().Where("settingKey", Condition.Equal, name).ExecuteSingle();
			if (st != null) {
				return decimal.Parse(st.Val);
			}
			else {
				return 0;
			}
		}
		
		public int getInt(string name)
		{
			Setting st = Data.DB.Query<Setting>().Where("settingKey", Condition.Equal, name).ExecuteSingle();
			if (st != null) {
				return int.Parse(st.Val);
			}
			else {
				return 0;
			}
		}
		
		public string getString(string name)
		{
			Setting st = Data.DB.Query<Setting>().Where("settingKey", Condition.Equal, name).ExecuteSingle();
			if (st != null) {
				return st.Val;
			}
			else {
				return "";
			}
		}
		#endregion
		
		#region Build Configs
		public bool isValidBuildName(string name)
		{
			return (name != "" && isUniqueBuildName(name));
		}
		
		private bool isUniqueBuildName(string name)
		{
			Build b = Data.DB.Query<Build>().Where("buildName", Condition.Equal, name).ExecuteSingle();
			return b == null;
		}
		
		private string getUniqueBuildName()
		{
			string start = "New Config ";
			int count = 1;
			string ret;
			do {
				ret = start + count;
				count++;
			} while (!isUniqueBuildName(ret));
			return ret;
		}
		
		public Build newBuildConfig()
		{
			Build ret = new Build();
			ret.Name = getUniqueBuildName();
			return ret;
		}
		#endregion
		
		#region Build Presets
		public List<string> presetsInDirectory(string path)
		{
			List<string> ret = new List<string>();
			if (Directory.Exists(path)) {
				foreach (Preset p in Data.DB.List<Preset>()) {
					if (File.Exists(Path.Combine(path, p.BspExecutable)) &&
					   		(File.Exists(Path.Combine(path, p.CsgExecutable)) || p.CsgExecutable == "") &&
						    File.Exists(Path.Combine(path, p.VisExecutable)) &&
						    File.Exists(Path.Combine(path, p.RadExecutable))) {
						ret.Add(p.Name);
					}
				}
			}
			return ret;
		}
		#endregion
		
		#region Game Configs
		public bool isValidGameName(string name)
		{
			return (name != "" && isUniqueGameName(name));
		}
		
		private bool isUniqueGameName(string name)
		{
			Game b = Data.DB.Query<Game>().Where("gameName", Condition.Equal, name).ExecuteSingle();
			return b == null;
		}
		
		private string getUniqueGameName()
		{
			string start = "New Game ";
			int count = 1;
			string ret;
			do {
				ret = start + count;
				count++;
			} while (!isUniqueGameName(ret));
			return ret;
		}
		
		public Game newGameConfig()
		{
			Game ret = new Game();
			ret.Name = getUniqueGameName();
			return ret;
		}
		#endregion
	}
}
