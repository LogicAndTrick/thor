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
	/// The base object that entities are based on.
	/// Can be a worldspawn, group, entity, or brush.
	/// </summary>
	public abstract class MapObject
	{
		protected string classname;
		protected List<int> visgroups;
		protected Color colour;
		protected List<MapObject> children;
		protected bool selected;
		protected bool render;
		protected MapObject parent;
		
		public MapObject Parent {
			get { return parent; }
			set { parent = value; }
		}
		
		protected BoundingBox bbox;
		
		public BoundingBox Bbox {
			get { return bbox; }
		}
		
		public bool Selected {
			get { return selected; }
			set { selected = value; }
		}
		
		public bool Render {
			get { return render; }
			set { render = value; }
		}
		
		/// <summary>
		/// Get the current list of children.
		/// </summary>
		public List<MapObject> Children {
			get { return children; }
		}
		
		/// <summary>
		/// Get or set the classname of the object.
		/// </summary>
		public string Classname {
			get { return classname; }
			set { classname = value; }
		}
		
		/// <summary>
		/// Get or set the visgroups of the object.
		/// </summary>
		public List<int> Visgroups {
			get { return visgroups; }
			set { visgroups = value; }
		}
		
		/// <summary>
		/// Get or set the render colour of the object.
		/// </summary>
		public Color Colour {
			get { return colour; }
			set { colour = value; }
		}
		
		/// <summary>
		/// Add a child to the children list.
		/// </summary>
		/// <param name="mo">The MapObject subclass to add.</param>
		public void addChild(MapObject mo)
		{
			mo.parent = this;
			children.Add(mo);
		}
		
		public void addChildren(List<MapObject> list)
		{
			foreach (MapObject o in list) addChild(o);
		}
		
		public bool removeChild(MapObject mo)
		{
			if (children.Contains(mo)) {
				children.Remove(mo);
				mo.parent = null;
				return true;
			}
			foreach (MapObject m in children) {
				if (m.removeChild(mo)) return true;
			}
			return false;
		}
		
		/// <summary>
		/// Basic constructor.
		/// </summary>
		public MapObject()
		{
			classname = "";
			visgroups = new List<int>();
			colour = Color.FromArgb(0,0,0,0);
			children = new List<MapObject>();
			selected = false;
			render = true;
		}
		
		protected List<MapObject> selectChildren(BoundingBox box)
		{
			List<MapObject> selObj = new List<MapObject>();
			foreach (MapObject o in children) {
				selObj.AddRange(o.selectTest(box));
			}
			return selObj;
		}
		
		public List<MapObject> getAllChildren()
		{
			List<MapObject> ret = new List<MapObject>();
			ret.AddRange(children);
			foreach(MapObject o in children) ret.AddRange(o.getAllChildren());
			return ret;
		}
		
		public abstract List<MapObject> selectTest(BoundingBox box);
		public abstract void setSelect(bool sel);
		
		public virtual void selectAllChildren(bool sel)
		{
			foreach (MapObject o in children) {
				o.setSelect(sel);
				o.selectAllChildren(sel);
			}
		}
		
		public void transformChildren(CoordinateTransformation transform)
		{
			foreach (MapObject o in children) o.applyTransformation(transform);
		}
		
		public abstract void applyTransformation(CoordinateTransformation transform);
		public abstract bool intersectLine2D(DecimalCoordinate start, DecimalCoordinate finish, decimal tolerance);
		public abstract bool intersectLine3D(DecimalCoordinate start, DecimalCoordinate finish);
		
		public virtual DecimalCoordinate getIntersectLine3D(DecimalCoordinate start, DecimalCoordinate finish) { return null; }
		
		public abstract MapObject copy(CoordinateTransformation transform);
		public abstract MapObject copyExact();
		public abstract void copySettings(MapObject o);
		
		public abstract string dump(int tabs);
		public string dumpChildren(int tabs)
		{
			string s = "";
			foreach (MapObject o in children) {
				s += o.dump(tabs) + "\r\n";
			}
			return s;
		}
	}
}
