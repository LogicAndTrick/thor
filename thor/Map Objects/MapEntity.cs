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
	/// A representation of a map entity.
	/// Holds an origin as well as entity data.
	/// </summary>
	public class MapEntity : MapObject
	{
		GameDataObject entityData;
		MapEntityData data;
		DecimalCoordinate origin;
		
		/// <summary>
		/// Get or set the FGD entity info
		/// </summary>
		public GameDataObject EntityData {
			get { return entityData; }
			set { setEntityData(value); }
		}
		
		private void setEntityData(GameDataObject edata)
		{
			entityData = edata;
			reCalc2D();
		}
		
		/// <summary>
		/// Get or set the map entity data.
		/// </summary>
		public MapEntityData Data {
			get { return data; }
			set { data = value; reCalc2D(); }
		}
		
		/// <summary>
		/// Get or set the origin.
		/// </summary>
		public DecimalCoordinate Origin {
			get { return origin; }
			set { origin = value; reCalc2D(); }
		}
		
		/// <summary>
		/// Basic constructor.
		/// </summary>
		public MapEntity() : base()
		{
			data = new MapEntityData();
			reCalc2D();
		}
		
		private void reCalc2D()
		{
			if ((object)origin == null) {
				bbox = null;
				return;
			}
			bool found = false;
			colour = Color.Magenta;
			if (entityData != null) {
				GameDataBehaviour behav = entityData.getBehaviour("size");
				DecimalCoordinate[] size;
				if (behav != null && (size = behav.getSize()) != null) {
					bbox = new BoundingBox(origin + size[0], origin + size[1]);
					found = true;
				}
				behav = entityData.getBehaviour("color");
				if (behav != null) {
					colour = behav.getColor();
				}
			}
			if (!found) {
				bbox = new BoundingBox(origin + new DecimalCoordinate(-8,-8,-8), origin + new DecimalCoordinate(8,8,8));
			}
		}
		
		public override List<MapObject> selectTest(BoundingBox box)
		{
			List<MapObject> selObj = new List<MapObject>();
			if (this.bbox.intersect(box)) {
				selObj.Add(this);
				setSelect(true);
			}
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
			origin = transform.Operate(origin);
			reCalc2D();
		}
		
		public override bool intersectLine2D(DecimalCoordinate start, DecimalCoordinate finish, decimal tolerance)
		{
			//TODO: proper collision!
			bool coll = false;
			DecimalCoordinate markAdd = new DecimalCoordinate(tolerance,tolerance,tolerance);
			BoundingBox oMarker = new BoundingBox(origin-markAdd,origin+markAdd);
			if (oMarker.intersectLine(start,finish)) {
				coll = true;
			}
			else {
				//create a long, thin bbox around the start, finish line, because this is 2d we can get away with it.
				BoundingBox edges = new BoundingBox(start-markAdd,finish+markAdd);
				MapFace[] faces = bbox.getMapFaces();
				foreach (MapFace f in faces) {
					if (f.edgeCollide(edges)) {
						//selObj.Add(this);
						coll = true;
						//string edgestr = "";
						//foreach (DecimalCoordinate dc in f.Vertices) edgestr += " [[" + dc.round(1).ToString() + "]] ";
						//Log.LogMessage("Collided against face: " + edgestr);
						break;
					}
				}
			}
			//return selObj;
			return coll;
		}
		
		public override bool intersectLine3D(DecimalCoordinate start, DecimalCoordinate finish)
		{
			//List<MapObject> selObj = new List<MapObject>();
			bool coll = false;
			if (bbox.intersectLine(start,finish)) {
				// we know that the bounding box has intersected with the line, now test the actual faces
				DecimalCoordinate d;
				MapFace[] faces = bbox.getMapFaces();
				foreach (MapFace f in faces) {
					if (f.intersectLine(start, finish, out d)) {
						coll = true;
						break;
					}
				}
			}
			return coll;
		}
		
		public override DecimalCoordinate getIntersectLine3D(DecimalCoordinate start, DecimalCoordinate finish)
		{
			DecimalCoordinate d = null;
			DecimalCoordinate ret = null;
			decimal? distHolder = null;
			MapFace[] faces = bbox.getMapFaces();
			foreach (MapFace f in faces) {
				if (f.intersectLine(start, finish, out d)) {
					decimal dist = (d - start).vectorMagnitude();
					if (distHolder == null || distHolder > dist) {
						ret = d.Clone();
						distHolder = dist;
					}
				}
			}
			return ret;
		}
		
		public override MapObject copy(CoordinateTransformation transform)
		{
			MapEntity ent = new MapEntity();
			ent.Classname = classname;
			ent.Visgroups.AddRange(visgroups);
			ent.Colour = Color.FromArgb(255,0,transform.Rand.Next(50,256),transform.Rand.Next(50,256));
			ent.bbox = new BoundingBox(bbox);
			ent.origin = transform.Operate(origin);
			ent.data = data.copy();
			foreach (MapObject mo in children) {
				ent.addChild(mo.copy(transform));
			}
			return ent;
		}
		
		public override MapObject copyExact()
		{
			MapEntity ent = new MapEntity();
			ent.parent = this.parent;
			ent.Classname = classname;
			ent.Visgroups.AddRange(visgroups);
			ent.Colour = colour;
			ent.bbox = new BoundingBox(bbox);
			ent.origin = origin.Clone();
			ent.data = data.copy();
			foreach (MapObject mo in children) {
				ent.addChild(mo.copyExact());
			}
			return ent;
		}
		
		public override void copySettings(MapObject o)
		{
			if (o is MapEntity) {
				MapEntity e = o as MapEntity;
				parent = e.parent;
				classname = e.classname;
				visgroups.Clear();
				visgroups.AddRange(e.visgroups);
				colour = e.colour;
				bbox = new BoundingBox(e.bbox);
				origin = e.origin.Clone();
				data = e.data.copy();
				this.children.Clear();
				foreach (MapObject mo in e.children) {
					this.addChild(mo.copyExact());
				}
			}
		}
		
		public override string dump(int tabs)
		{
			string tabstr = "";
			for (int i = 0; i < tabs; i++) tabstr += "\t";
			string s = tabstr + "-ENTITY-\r\n";
			foreach (int v in visgroups) {
				s += tabstr + "visgroup: " + v + "\r\n";
			}
			s += tabstr + "classname: " + classname + "\r\n";
			s += tabstr + "origin: " + origin + "\r\n";
			s += tabstr + "children: \r\n" + dumpChildren(tabs + 1);
			return s;
		}
	}
}
