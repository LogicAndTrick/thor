/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 2/11/2009
 * Time: 10:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Thorm;

namespace thor.Models
{
	/// <summary>
	/// Description of Preset.
	/// </summary>
	[Table(Name="Presets")]
	public class Preset
	{
		public Preset()
		{
			engine = new One<Engine>();
		}
		
		private int? id;
		private string name;
		private int engineid;
		private string bspexe;
		private string csgexe;
		private string visexe;
		private string radexe;
		private One<Engine> engine;
		
		[Column(Name="presetID"), PrimaryKey]
		public int? ID {
			get { return id; }
			set { id = value; }
		}
		
		[Column(Name="presetName")]
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		[Column(Name="presetEngine")]
		public int EngineID {
			get { return engineid; }
			set { engineid = value; }
		}
		
		[Column(Name="presetBspExe")]
		public string BspExecutable {
			get { return bspexe; }
			set { bspexe = value; }
		}
		
		[Column(Name="presetCsgExe")]
		public string CsgExecutable {
			get { return csgexe; }
			set { csgexe = value; }
		}
		
		[Column(Name="presetVisExe")]
		public string VisExecutable {
			get { return visexe; }
			set { visexe = value; }
		}
		
		[Column(Name="presetRadExe")]
		public string RadExecutable {
			get { return radexe; }
			set { radexe = value; }
		}
		
		[One(ThisKey="buildEngine")]
		public Engine Engine {
			get { return engine.Entity; }
		}
	}
}
