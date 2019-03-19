/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 1/11/2009
 * Time: 9:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Thorm;

namespace thor.Models
{
	/// <summary>
	/// Description of Build.
	/// </summary>
	[Table(Name="Builds")]
	public class Build
	{
		public Build()
		{
			engine = new One<Engine>();
			games = new Many<Game>();
		}
		
		private int? id;
		private string name;
		private int engineid;
		private string executablefolder;
		private string bspexecutable;
		private string csgexecutable;
		private string visexecutable;
		private string radexecutable;
		private string flags;
		private int copybsp;
		private int showlog;
		private int ask;
		private int runtype;
		private string commandline;
		private One<Engine> engine;
		private Many<Game> games;
		
		private string bspflags;
		private string csgflags;
		private string visflags;
		private string radflags;
		
		[Column(Name="buildID"), PrimaryKey]
		public int? ID {
			get { return id; }
			set { id = value; }
		}
		
		[Column(Name="buildName")]
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		[Column(Name="buildEngine")]
		public int EngineID {
			get { return engineid; }
			set { engineid = value; }
		}
		
		[Column(Name="buildExeFolder")]
		public string ExecutableFolder {
			get { return executablefolder; }
			set { executablefolder = value; }
		}
		
		[Column(Name="buildBspExe")]
		public string BspExecutable {
			get { return bspexecutable; }
			set { bspexecutable = value; }
		}
		
		[Column(Name="buildCsgExe")]
		public string CsgExecutable {
			get { return csgexecutable; }
			set { csgexecutable = value; }
		}
		
		[Column(Name="buildVisExe")]
		public string VisExecutable {
			get { return visexecutable; }
			set { visexecutable = value; }
		}
		
		[Column(Name="buildRadExe")]
		public string RadExecutable {
			get { return radexecutable; }
			set { radexecutable = value; }
		}
		
		[Column(Name="buildFlags")]
		public string Flags {
			get { return flags; }
			set { flags = value; UpdateFlags(false); }
		}
		
		public string BspFlags {
			get { return bspflags; }
			set { bspflags = value; UpdateFlags(true); }
		}
		
		public string CsgFlags {
			get { return csgflags; }
			set { csgflags = value; UpdateFlags(true); }
		}
		
		public string VisFlags {
			get { return visflags; }
			set { visflags = value; UpdateFlags(true); }
		}
		
		public string RadFlags {
			get { return radflags; }
			set { radflags = value; UpdateFlags(true); }
		}
		
		[Column(Name="buildCopyBsp")]
		public int _CopyBsp {
			get { return copybsp; }
			set { copybsp = value; }
		}
		
		public bool CopyBsp {
			get { return copybsp > 0; }
			set { copybsp = (value) ? 1 : 0; }
		}
		
		[Column(Name="buildShowLog")]
		public int _ShowLog {
			get { return showlog; }
			set { showlog = value; }
		}
		
		public bool ShowLog {
			get { return showlog > 0; }
			set { showlog = (value) ? 1 : 0; }
		}
		
		[Column(Name="buildAsk")]
		public int _AskBeforeRun {
			get { return ask; }
			set { ask = value; }
		}
		
		public bool AskBeforeRun {
			get { return ask > 0; }
			set { ask = (value) ? 1 : 0; }
		}
		
		[Column(Name="buildRunType")]
		public int RunType {
			get { return runtype; }
			set { runtype = value; }
		}
		
		[Column(Name="buildCommandLine")]
		public string CommandLine {
			get { return commandline; }
			set { commandline = value; }
		}
		
		[One(ThisKey="buildEngine")]
		public Engine Engine {
			get { return engine.Entity; }
		}
		
		[Many(OtherKey="gameBuild")]
		public List<Game> Games {
			get { return games.Entities; }
		}
		
		private void UpdateFlags(bool combined)
		{
			if (combined) {
				flags = csgflags + ";" + bspflags + ";" + visflags + ";" + radflags;
			} else {
				string[] spl = flags.Split(';');
				csgflags = spl[0];
				bspflags = spl[1];
				visflags = spl[2];
				radflags = spl[3];
			}
		}
	}
}
