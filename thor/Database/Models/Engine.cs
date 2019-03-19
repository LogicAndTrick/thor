/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 1/11/2009
 * Time: 10:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Thorm;

namespace thor.Models
{
	/// <summary>
	/// Description of Engine.
	/// </summary>
	[Table(Name="Engines")]
	public class Engine
	{
		public Engine()
		{
			builds = new Many<Build>();
			presets = new Many<Preset>();
			games = new Many<Game>();
		}
		
		private int? id;
		private string name;
		private Many<Build> builds;
		private Many<Preset> presets;
		private Many<Game> games;
		
		[Column(Name="engineID"), PrimaryKey]
		public int? ID {
			get { return id; }
			set { id = value; }
		}
		
		[Column(Name="engineName")]
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		[Many(OtherKey="buildEngine")]
		public List<Build> Builds {
			get { return builds.Entities; }
		}
		
		[Many(OtherKey="presetEngine")]
		public List<Preset> Presets {
			get { return presets.Entities; }
		}
		
		[Many(OtherKey="gameEngine")]
		public List<Game> Games {
			get { return games.Entities; }
		}
	}
}
