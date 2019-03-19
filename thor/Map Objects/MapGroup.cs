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
	public class MapGroup : MapObject
	{
		public MapGroup() : base()
		{
			
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
			MapGroup grp = new MapGroup();
			grp.Classname = classname;
			grp.Visgroups.AddRange(visgroups);
			grp.Colour = Color.FromArgb(255,0,transform.Rand.Next(50,256),transform.Rand.Next(50,256));
			grp.bbox = null;
			foreach (MapObject mo in children) {
				grp.addChild(mo.copy(transform));
			}
			return grp;
		}
		
		public override MapObject copyExact()
		{
			MapGroup grp = new MapGroup();
			grp.parent = parent;
			grp.Classname = classname;
			grp.Visgroups.AddRange(visgroups);
			grp.Colour = colour;
			grp.bbox = null;
			foreach (MapObject mo in children) {
				grp.addChild(mo.copyExact());
			}
			return grp;
		}
		
		public override void copySettings(MapObject o)
		{
			if (o is MapGroup) {
				MapGroup g = o as MapGroup;
				parent = g.parent;
				classname = g.classname;
				visgroups.Clear();
				visgroups.AddRange(g.visgroups);
				colour = g.colour;
				bbox = null;
				this.children.Clear();
				foreach (MapObject mo in g.children) {
					this.addChild(mo.copyExact());
				}
			}
		}
		
		public override string dump(int tabs)
		{
			string tabstr = "";
			for (int i = 0; i < tabs; i++) tabstr += "\t";
			string s = tabstr + "-GROUP-\r\n";
			foreach (int v in visgroups) {
				s += tabstr + "visgroup: " + v + "\r\n";
			}
			s += tabstr + "children: \r\n" + dumpChildren(tabs + 1);
			return s;
		}
	}
}
