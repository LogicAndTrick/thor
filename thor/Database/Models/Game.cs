/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 2/11/2009
 * Time: 11:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Thorm;

namespace thor.Models
{
	/// <summary>
	/// Description of Game.
	/// </summary>
	[Table(Name="Games")]
	public class Game
	{
		public Game()
		{
			engine = new One<Engine>();
			build = new One<Build>();
			fgdlist = new EventList<string>();
			fgdlist.Changed += new EventHandler<EventArgs<ChangeEvent>>(fgdlist_Changed);
			wadlist = new EventList<string>();
			wadlist.Changed += new EventHandler<EventArgs<ChangeEvent>>(wadlist_Changed);
		}
		
		void fgdlist_Changed(object sender, EventArgs<ChangeEvent> e)
		{
			UpdateFGDs(false);
		}

		void wadlist_Changed(object sender, EventArgs<ChangeEvent> e)
		{
			UpdateWADs(false);
		}
		
		void UpdateFGDs(bool list) {
			if (list) {
				fgdlist.Clear();
				fgdlist.AddRange(fgds.Split(';'));
			} else {
				fgds = String.Join(";", fgdlist.ToArray());
			}
		}
		
		void UpdateWADs(bool list) {
			if (list) {
				wadlist.Clear();
				wadlist.AddRange(wads.Split(';'));
			} else {
				wads = String.Join(";", wadlist.ToArray());
			}
		}
		
		private int? id;
		private string name;
		private int engineid;
		private int iswon;
		private int buildid;
		private string directory;
		private string mod;
		private string mapdir;
		private string autodir;
		private int useauto;
		private int autoalt;
		private string fgds;
		private string pointent;
		private string brushent;
		private string wads;
		private int texscale;
		private int lightscale;
		private One<Engine> engine;
		private One<Build> build;
		
		private EventList<string> fgdlist;
		private EventList<string> wadlist;
		
		[Column(Name="gameID"), PrimaryKey]
		public int? ID {
			get { return id; }
			set { id = value; }
		}
		
		[Column(Name="gameName")]
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		[Column(Name="gameEngine")]
		public int EngineID {
			get { return engineid; }
			set { engineid = value; }
		}
		
		[Column(Name="gameIsWON")]
		public int _WON {
			get { return iswon; }
			set { iswon = value; }
		}
		
		public bool IsWON {
			get { return iswon > 0; }
			set { iswon = (value) ? 1 : 0; }
		}
		
		[Column(Name="gameBuild")]
		public int BuildID {
			get { return buildid; }
			set { buildid = value; }
		}
		
		[Column(Name="gameDir")]
		public string GameDirectory {
			get { return directory; }
			set { directory = value; }
		}
		
		[Column(Name="gameMod")]
		public string ModDirectory {
			get { return mod; }
			set { mod = value; }
		}
		
		[Column(Name="gameMapDir")]
		public string MapDirectory {
			get { return mapdir; }
			set { mapdir = value; }
		}
		
		[Column(Name="gameAutoDir")]
		public string AutosaveDirectory {
			get { return autodir; }
			set { autodir = value; }
		}
		
		[Column(Name="gameUseAuto")]
		public int _AutosaveEnabled {
			get { return useauto; }
			set { useauto = value; }
		}
		
		public bool AutosaveEnabled {
			get { return useauto > 0; }
			set { useauto = (value) ? 1 : 0; }
		}
		
		[Column(Name="gameAutoAlt")]
		public int _UseAlternateAutosaveDirectory {
			get { return autoalt; }
			set { autoalt = value; }
		}
		
		public bool UseAlternateAutosaveDirectory {
			get { return autoalt > 0; }
			set { autoalt = (value) ? 1 : 0; }
		}
		
		[Column(Name="gameFGDs")]
		public string _FGD {
			get { return fgds; }
			set { fgds = value; UpdateFGDs(true); }
		}
		
		public EventList<string> FGDs {
			get { return fgdlist; }
		}
		
		[Column(Name="gamePointEnt")]
		public string PointEntity {
			get { return pointent; }
			set { pointent = value; }
		}
		
		[Column(Name="gameBrushEnt")]
		public string BrushEntity {
			get { return brushent; }
			set { brushent = value; }
		}
		
		[Column(Name="gameWADs")]
		public string _WAD {
			get { return wads; }
			set { wads = value; UpdateWADs(true); }
		}
		
		public EventList<string> WADs {
			get { return wadlist; }
		}
		
		[Column(Name="gameTexScale")]
		public int _TextureScale {
			get { return texscale; }
			set { texscale = value; }
		}
		
		public decimal TextureScale {
			get { return texscale / 100; }
			set { texscale = (int)Math.Round(value * 100); }
		}
		
		[Column(Name="gameLightScale")]
		public int LightmapScale {
			get { return lightscale; }
			set { lightscale = value; }
		}
		
		[One(ThisKey="gameEngine")]
		public Engine Engine {
			get { return engine.Entity; }
		}
		
		[One(ThisKey="gameBuild")]
		public Build Build {
			get { return build.Entity; }
		}
	}
}
