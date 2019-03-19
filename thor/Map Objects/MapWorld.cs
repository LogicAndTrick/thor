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
	/// The MapWorld is a representation of the worldspawn entity.
	/// It holds all the brushwork and entity data of a map.
	/// </summary>
	public class MapWorld : MapObject
	{
		MapEntityData data;
		List<MapPath> paths;
		
		/// <summary>
		/// Get the current list of paths.
		/// </summary>
		public List<MapPath> Paths {
			get { return paths; }
		}
		
		/// <summary>
		/// Get or set the current entity data.
		/// </summary>
		public MapEntityData Data {
			get { return data; }
			set { data = value; }
		}
		
		/// <summary>
		/// Add a path the the path list.
		/// </summary>
		/// <param name="mp">The MapPath object to add.</param>
		public void addPath(MapPath mp)
		{
			paths.Add(mp);
		}
		
		/// <summary>
		/// Basic constructor.
		/// </summary>
		public MapWorld() : base()
		{
			data = new MapEntityData();
			data.Name = "worldspawn";
			paths = new List<MapPath>();
		}
		
		public override List<MapObject> selectTest(BoundingBox box)
		{
			List<MapObject> selObj = new List<MapObject>();
			selObj.AddRange(selectChildren(box));
			return selObj;
		}
		
		public override void setSelect(bool sel)
		{
			selected = sel;
		}
		
		public override void applyTransformation(CoordinateTransformation transform)
		{
			//transformChildren(transform);
		}
		
		public override bool intersectLine2D(DecimalCoordinate start, DecimalCoordinate finish, decimal tolerance)
		{
			//return intersectLineChildren2D(start,finish,tolerance);
			return false;
		}
		
		public override bool intersectLine3D(DecimalCoordinate start, DecimalCoordinate finish)
		{
			//return intersectLineChildren3D(start,finish);
			return false;
		}
		
		public override MapObject copy(CoordinateTransformation transform)
		{
			throw new Exception("Can't copy a worldspawn.");
		}
		
		public override MapObject copyExact()
		{
			MapWorld wld = new MapWorld();
			wld.parent = parent;
			wld.Classname = classname;
			wld.Visgroups.AddRange(visgroups);
			wld.Colour = colour;
			wld.bbox = null;
			foreach (MapObject mo in children) {
				wld.addChild(mo.copyExact());
			}
			foreach (MapPath p in paths) {
				wld.addPath(p.copy());
			}
			wld.data = data.copy();
			return wld;
		}
		
		public override void copySettings(MapObject o)
		{
			if (o is MapWorld) {
				MapWorld w = o as MapWorld;
				parent = w.parent;
				classname = w.classname;
				visgroups.Clear();
				visgroups.AddRange(w.visgroups);
				colour = w.colour;
				bbox = null;
				this.children.Clear();
				foreach (MapObject mo in w.children) {
					this.addChild(mo.copyExact());
				}
				paths.Clear();
				foreach (MapPath p in w.paths) {
					addPath(p.copy());
				}
				data = w.data.copy();
			}
		}
		
		public override string dump(int tabs)
		{
			string tabstr = "";
			for (int i = 0; i < tabs; i++) tabstr += "\t";
			string s = tabstr + "-WORLD-\r\n";
			s += tabstr + "children: \r\n" + dumpChildren(tabs + 1);
			return s;
		}
	}
}
