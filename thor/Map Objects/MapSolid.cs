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

namespace thor
{
	public class MapSolid : MapObject
	{
		List<MapFace> faces;
		DecimalCoordinate center;
		
		bool containsDisplacement;
		
		public bool ContainsDisplacement {
			get { return containsDisplacement; }
		}
		
		public List<MapFace> Faces {
			get { return faces; }
		}
		
		public MapSolid() : base()
		{
			faces = new List<MapFace>();
			containsDisplacement = false;
		}
		
		#region Faces
		public void addFace(MapFace mf)
		{
			mf.Colour = this.colour;
			mf.Parent = this;
			faces.Add(mf);
			reCalcBBox();
			if (mf is MapDisplacement) containsDisplacement = true;
		}
		
		public void reCalcBBox()
		{
			if (faces.Count < 1) return;
			foreach (MapFace f in faces) if ((object)f.BBox == null) return;
			List<DecimalCoordinate> coords = new List<DecimalCoordinate>();
			center = new DecimalCoordinate(0,0,0);
			foreach (MapFace f in faces) {
				if ((object)f.Center != null) center += f.Center;
				if (((object)f.BBox) == null) continue;
				coords.Add(f.BBox.BottomLeftLow);
				coords.Add(f.BBox.TopRightHigh);
			}
			center /= faces.Count;
			bbox = new BoundingBox(coords.ToArray());
		}
		#endregion
		
		#region Transformations
		public override void applyTransformation(CoordinateTransformation transform)
		{
			foreach (MapFace f in faces) f.applyTransformation(transform);
			reCalcBBox();
		}
		#endregion
		
		#region Intersection and  Selecting
		public override List<MapObject> selectTest(BoundingBox box)
		{
			List<MapObject> selObj = new List<MapObject>();
			if (this.bbox.intersect(box)) {
				selObj.Add(this);
				setSelect(true);
			}
			return selObj;
		}
		
		public override void setSelect(bool sel)
		{
			selected = sel;
			foreach (MapFace f in faces) {
				f.Selected = sel;
				f.DrawSelected = true;
			}
		}
		
		public override bool intersectLine2D(DecimalCoordinate start, DecimalCoordinate finish, decimal tolerance)
		{
			//TODO: proper collision?
			//List<MapObject> selObj = new List<MapObject>();
			bool coll = false;
			DecimalCoordinate markAdd = new DecimalCoordinate(tolerance,tolerance,tolerance);
			BoundingBox oMarker = new BoundingBox(center-markAdd,center+markAdd);
			if (oMarker.intersectLine(start,finish)) {
				//Log.LogMessage("Collided against origin marker");
				//selObj.Add(this);
				coll = true;
			}
			else {
				//create a long, thin bbox around the start, finish line, because this is 2d we can get away with it.
				BoundingBox edges = new BoundingBox(start-markAdd,finish+markAdd);
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
		#endregion
		
		#region Clipping
		public MapSolid[] split(DecimalPlane p)
		{
			MapSolid s1 = (MapSolid)copyExact();
			MapSolid s2 = (MapSolid)copyExact();
			bool spanning = false;
			bool front = true;
			FaceClassification[] classes = new FaceClassification[faces.Count];
			for (int i = 0; i < faces.Count; i++) {
				FaceClassification fc = faces[i].classify(p);
				classes[i] = fc;
				if (fc == FaceClassification.Spanning) spanning = true;
				if (fc == FaceClassification.Back) front = false;
			}
			if (!spanning) {
				if (front) return new MapSolid[] { s1, null };
				else return new MapSolid[] { null, s2 };
			}
			
			s1.faces.Clear();
			s2.faces.Clear();
			List<DecimalPlane> pl1 = new List<DecimalPlane>();
			List<DecimalPlane> pl2 = new List<DecimalPlane>();
			
			for (int i = 0; i < faces.Count; i++) {
				if (classes[i] != FaceClassification.Back) pl1.Add(faces[i].Plane);
				if (classes[i] != FaceClassification.Front) pl2.Add(faces[i].Plane);
			}
			pl1.Add(p);
			pl2.Add(new DecimalPlane(-p.getNormal(), -p.getDist()));
			try {
			DecimalCoordinate[][] v1 = Converter.planesToVertices(pl1.ToArray());
			for (int i = 0; i < v1.Length; i++) {
				MapFace f = faces[0].copyExact();
				f.Vertices.Clear();
				f.Plane = new DecimalPlane(v1[i][0], v1[i][1], v1[i][2]);
				f.addVertices(v1[i]);
				f.alignToWorld();
				s1.addFace(f);
			}
			
			DecimalCoordinate[][] v2 = Converter.planesToVertices(pl2.ToArray());
			for (int i = 0; i < v2.Length; i++) {
				MapFace f = faces[0].copyExact();
				f.Vertices.Clear();
				f.Plane = new DecimalPlane(v2[i][0], v2[i][1], v2[i][2]);
				f.addVertices(v2[i]);
				f.alignToWorld();
				s2.addFace(f);
			}
			} catch (Exception) {
				Log.LogMessage("no " + DateTime.Now.ToBinary());
				return new MapSolid[] { null, null };
			}
			return new MapSolid[] { s1, s2 };
		}
		#endregion
		
		#region Copy
		public override MapObject copy(CoordinateTransformation transform)
		{
			MapSolid sol = new MapSolid();
			sol.parent = null;
			sol.containsDisplacement = this.containsDisplacement;
			sol.Classname = classname;
			sol.Visgroups.AddRange(visgroups);
			sol.colour = Color.FromArgb(255,0,transform.Rand.Next(50,256),transform.Rand.Next(50,256));
			sol.bbox = new BoundingBox(bbox);
			foreach (MapFace f in faces) {
				MapFace face = f.copy(transform);
				sol.addFace(face);
			}
			sol.reCalcBBox();
			return sol;
		}
		
		public override MapObject copyExact()
		{
			MapSolid sol = new MapSolid();
			sol.parent = this.parent;
			sol.containsDisplacement = this.containsDisplacement;
			sol.Classname = classname;
			sol.Visgroups.AddRange(visgroups);
			sol.colour = colour;
			sol.selected = false;
			sol.bbox = new BoundingBox(bbox);
			foreach (MapFace f in faces) {
				MapFace face = f.copyExact();
				sol.addFace(face);
			}
			sol.reCalcBBox();
			return sol;
		}
		
		public override void copySettings(MapObject o)
		{
			if (o is MapSolid) {
				MapSolid s = o as MapSolid;
				parent = s.parent;
				containsDisplacement = s.containsDisplacement;
				classname = s.classname;
				visgroups.Clear();
				visgroups.AddRange(s.visgroups);
				colour = s.colour;
				bbox = new BoundingBox(s.bbox);
				faces.Clear();
				foreach (MapFace f in s.faces) {
					addFace(f.copyExact());
				}
				reCalcBBox();
			}
		}
		#endregion
		
		public override string dump(int tabs)
		{
			string tabstr = "";
			for (int i = 0; i < tabs; i++) tabstr += "\t";
			string s = tabstr + "-SOLID-\r\n";
			foreach (int v in visgroups) {
				s += tabstr + "visgroup: " + v + "\r\n";
			}
			s += tabstr + "faces: \r\n";
			foreach (MapFace f in faces) s += f.dump(tabs + 1) + "\r\n";
			return s;
		}
	}
}
