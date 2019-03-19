/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 11/09/2008
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace thor
{
	/// <summary>
	/// Description of SettingBuildConfig.
	/// </summary>
	public class SettingBuildConfig
	{
		int id;
		string name;
		int engine;
		string exefolder;
		string bspexe;
		string csgexe;
		string visexe;
		string radexe;
		bool copybsp;
		bool showlog;
		bool askrun;
		int runtype;
		string commandline;
		string csgflags;
		string bspflags;
		string visflags;
		string radflags;
		
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
		
		public string Exefolder {
			get { return exefolder; }
			set { exefolder = value; }
		}
		
		public string Bspexe {
			get { return bspexe; }
			set { bspexe = value; }
		}
		
		public string Csgexe {
			get { return csgexe; }
			set { csgexe = value; }
		}
		
		public string Visexe {
			get { return visexe; }
			set { visexe = value; }
		}
		
		public string Radexe {
			get { return radexe; }
			set { radexe = value; }
		}
		
		public bool Copybsp {
			get { return copybsp; }
			set { copybsp = value; }
		}
		
		public bool Showlog {
			get { return showlog; }
			set { showlog = value; }
		}
		
		public bool Askrun {
			get { return askrun; }
			set { askrun = value; }
		}
		
		public int Runtype {
			get { return runtype; }
			set { runtype = value; }
		}
		
		public string Commandline {
			get { return commandline; }
			set { commandline = value; }
		}
		
		public string Csgflags {
			get { return csgflags; }
			set { csgflags = value; }
		}
		
		public string Bspflags {
			get { return bspflags; }
			set { bspflags = value; }
		}
		
		public string Visflags {
			get { return visflags; }
			set { visflags = value; }
		}
		
		public string Radflags {
			get { return radflags; }
			set { radflags = value; }
		}
		
		public SettingBuildConfig(int n)
		{
			id = n;
			name = "Config";
			engine = runtype = 1;
			bspexe = csgexe = visexe = radexe = "(choose)";
			exefolder = "C:\\";
			copybsp = showlog = askrun = true;
			commandline = "-console";
			csgflags = bspflags = visflags = radflags = "";
		}
		
		public override string ToString()
		{
			return name;
		}
	}
}
