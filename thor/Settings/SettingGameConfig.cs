/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 22/07/2009
 * Time: 7:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace thor
{
	/// <summary>
	/// Description of SettingGameConfig.
	/// </summary>
	public class SettingGameConfig
	{
		int id;
		string name;
		int engine;
		bool won;
		int build;
		string gamedir;
		string moddir;
		string mapdir;
		string autodir;
		bool useauto;
		bool autoalt;
		List<string> fgds;
		string pointent;
		string brushent;
		List<string> wads;
		decimal texscale;
		int lightscale;
		
		public int Id {
			get { return id; }
			set { id = value; }
		}
		
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public int Engine {
			get { return engine; }
			set { engine = value; }
		}
		
		public bool Won {
			get { return won; }
			set { won = value; }
		}
		
		public int Build {
			get { return build; }
			set { build = value; }
		}
		
		public string Gamedir {
			get { return gamedir; }
			set { gamedir = value; }
		}
		
		public string Moddir {
			get { return moddir; }
			set { moddir = value; }
		}
		
		public string Mapdir {
			get { return mapdir; }
			set { mapdir = value; }
		}
		
		public string Autodir {
			get { return autodir; }
			set { autodir = value; }
		}
		
		public bool Useauto {
			get { return useauto; }
			set { useauto = value; }
		}
		
		public bool Autoalt {
			get { return autoalt; }
			set { autoalt = value; }
		}
		
		public List<string> Fgds {
			get { return fgds; }
			set { fgds = value; }
		}
		
		public string Pointent {
			get { return pointent; }
			set { pointent = value; }
		}
		
		public string Brushent {
			get { return brushent; }
			set { brushent = value; }
		}
		
		public List<string> Wads {
			get { return wads; }
			set { wads = value; }
		}
		
		public decimal Texscale {
			get { return texscale; }
			set { texscale = value; }
		}
		
		public int Lightscale {
			get { return lightscale; }
			set { lightscale = value; }
		}
		
		public SettingGameConfig(int ID)
		{
			id = ID;
			name = "config";
			engine = build = 1;
			won = useauto = autoalt = false;
			gamedir = moddir = mapdir = autodir = pointent = brushent = "";
			fgds = new List<string>();
			wads = new List<string>();
			texscale = 0.25m;
			lightscale = 16;
		}
		
		public string getFullDirectory()
		{
			return Path.Combine(gamedir, moddir);
		}
		
		public override string ToString()
		{
			return name;
		}
		
		public SettingGameConfig Copy()
		{
			SettingGameConfig ret = new SettingGameConfig(id);
			ret.name =  name;
			ret.engine = engine;
			ret.won = won;
			ret.build = build;
			ret.gamedir = gamedir;
			ret.moddir =  moddir;
			ret.mapdir =  mapdir;
			ret.autodir =  autodir;
			ret.useauto =  useauto;
			ret.autoalt =  autoalt;
			foreach (string s in fgds) ret.fgds.Add(s);
			ret.pointent =  pointent;
			ret.brushent =  brushent;
			foreach (string s in wads) ret.wads.Add(s);
			ret.texscale =  texscale;
			ret.lightscale =  lightscale;
			return ret;
		}
	}
}
