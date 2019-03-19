/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 11/10/2008
 * Time: 5:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace thor
{
	/// <summary>
	/// Stores an entire map, including visgroups, entities, and camera data.
	/// </summary>
	public class MapClass
	{
		decimal version;
		List<MapVisgroup> visgroups;
		MapWorld worldspawn;
		decimal activecamera;
		List<MapCamera> cameras;
		
		/// <summary>
		/// Get the current list of cameras.
		/// </summary>
		public List<MapCamera> Cameras {
			get { return cameras; }
		}
		
		/// <summary>
		/// Get the current list of visgroups.
		/// </summary>
		public List<MapVisgroup> Visgroups {
			get { return visgroups; }
		}
		
		/// <summary>
		/// Get or set the current active camera.
		/// </summary>
		public decimal Activecamera {
			get { return activecamera; }
			set { activecamera = value; }
		}
		
		/// <summary>
		/// Get or set the map version.
		/// </summary>
		public decimal Version {
			get { return version; }
			set { version = value; }
		}
		
		/// <summary>
		/// Get or set the worldspawn entity.
		/// </summary>
		public MapWorld Worldspawn {
			get { return worldspawn; }
			set { worldspawn = value; }
		}
		
		/// <summary>
		/// Add a visgroup to the visgroup list.
		/// </summary>
		/// <param name="mv">The MapVisgroup object to add.</param>
		public void addVisgroup(MapVisgroup mv)
		{
			visgroups.Add(mv);
		}
		
		/// <summary>
		/// Add a camera to the camera list.
		/// </summary>
		/// <param name="mc">The MapCamera object to add.</param>
		public void addCamera(MapCamera mc)
		{
			cameras.Add(mc);
		}
		
		/// <summary>
		/// Basic constructor.
		/// </summary>
		public MapClass()
		{
			visgroups = new List<MapVisgroup>();
			worldspawn = new MapWorld();
			activecamera = -1;
			cameras = new List<MapCamera>();
		}
		
		public string Dump()
		{
			string ret = worldspawn.dump(0) + "\n";
			foreach (MapVisgroup v in visgroups) {
				ret += "\n"+v;
			}
			return ret;
		}
	}
}
