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
	public enum FaceClassification {
		Front,
		Back,
		OnPlane,
		Spanning
	}
	
	public class MapFace
	{
		#region Class Variables
		protected string texture;
		protected TextureObject textureResource;
		protected Vector4 vaxis;
		protected Vector4 uaxis;
		protected decimal rotation;
		protected decimal uscale;
		protected decimal vscale;
		protected List<MapVertex> vertices;
		protected DecimalPlane plane;
		
		protected bool selected;
		protected bool drawSelected;
		
		protected Color colour;
		protected DecimalCoordinate center;
		
		protected BoundingBox bbox;
		
		protected MapSolid parent;
		#endregion
		
		#region Properties
		public Color Colour {
			get { return colour; }
			set { colour = value; }
		}
		
		public List<MapVertex> Vertices {
			get { return vertices; }
		}
		
		public string Texture {
			get { return texture; }
			set { texture = value; }
		}
		
		public TextureObject TextureResource {
			get { return textureResource; }
			set { textureResource = value; }
		}
		
		public Vector4 Vaxis {
			get { return vaxis; }
			set { vaxis = value; }
		}
		
		public Vector4 Uaxis {
			get { return uaxis; }
			set { uaxis = value; }
		}
		
		public decimal Rotation {
			get { return rotation; }
			set { rotation = value; }
		}
		
		public decimal Uscale {
			get { return uscale; }
			set { uscale = value; }
		}
		
		public decimal Vscale {
			get { return vscale; }
			set { vscale = value; }
		}
		
		public DecimalPlane Plane {
			get { return plane; }
			set { plane = value; }
		}
		
		public BoundingBox BBox {
			get { return bbox; }
		}
		
		public DecimalCoordinate Center {
			get { return center; }
			set { center = value; }
		}
		
		public bool Selected {
			get { return selected; }
			set { selected = value; }
		}
		
		public bool DrawSelected {
			get { return drawSelected; }
			set { drawSelected = value; }
		}
		
		public MapSolid Parent {
			get { return parent; }
			set { parent = value; }
		}
		#endregion
		
		#region Constructor
		public MapFace()
		{
			texture = "";
			vaxis = new Vector4();
			uaxis = new Vector4();
			rotation = 0;
			uscale = 0;
			vscale = 0;
			vertices = new List<MapVertex>();
			DecimalCoordinate c = new DecimalCoordinate(0,0,0);
			plane = new DecimalPlane(c,c,c);
			colour = Color.White;
			selected = false;
		}
		#endregion
		
		#region Vertices
		public virtual void addVertex(DecimalCoordinate c)
		{
			MapVertex v = new MapVertex(c);
			v.Parent = this;
			vertices.Add(v);
			reCalc2D();
		}
		
		public virtual void addVertices(params DecimalCoordinate[] coords)
		{
			foreach (DecimalCoordinate c in coords) {
				MapVertex v = new MapVertex(c);
				v.Parent = this;
				vertices.Add(v);
			}
			reCalc2D();
		}
		
		public void reCalc2D()
		{
			if (vertices.Count < 3) return;
			center = new DecimalCoordinate(0,0,0);
			foreach(MapVertex v in vertices) {
				DecimalCoordinate c = v.Location;
				center += c;
			}
			center /= vertices.Count;
			plane = new DecimalPlane(vertices[0].Location,vertices[1].Location,vertices[2].Location);
			
			bbox = getBBox();
		}
		
		private BoundingBox getBBox()
		{
			if (vertices.Count < 3) return null;
			List<DecimalCoordinate> tempverts = new List<DecimalCoordinate>();
			foreach (MapVertex v in vertices) tempverts.Add(v.Location);
			return new BoundingBox(tempverts.ToArray());
		}
		#endregion
		
		#region Textures
		public virtual void calculateTextureCoordinates()
		{
			if (textureResource == null) return;
			// u = [((coord dot u axis normal) / width ) / scale u] + [offset u / width ]
			// v = [((coord dot v axis normal) / height) / scale v] + [offset v / height]
			DecimalCoordinate vx = new DecimalCoordinate(vaxis.A, vaxis.B, vaxis.C);
			DecimalCoordinate ux = new DecimalCoordinate(uaxis.A, uaxis.B, uaxis.C);
			int w = textureResource.Width;
			int h = textureResource.Height;
			//
			//TexCoords[i].X = (V->Dot(vAxisU) * W * SX) + (vShift.X * W);
			//TexCoords[i].Y = (V->Dot(vAxisV) * H * SY) + (vShift.Y * H);
			//
			
			foreach (MapVertex v in vertices) {
				DecimalCoordinate c = v.Location;
				v.TextureU = ((c.dot(ux) / w) / uscale) + (uaxis.D / w);
				v.TextureV = ((c.dot(vx) / h) / vscale) + (vaxis.D / h);
			}
		}
		
		public void alignToWorld()
		{
			// this maps the texture coordinates to the world axes
			// so after this, the u and v axes will be a unit vector
			// in the x, y, or z direction. hammer seems to change the
			// value of this depending on the direction the plane normal is facing:
			// key: (x > 0 is east, x < 0 is west), (y > 0 is north, y < 0 is south)
			
			int facing = plane.generalFacing();
			
			// for the u axis, if the plane normal is facing east or west, it
			// points the u axis to the north. otherwise, to the east.
			
			if (facing == 1) uaxis.setCoordinate(new DecimalCoordinate(0, 1, 0));
			else uaxis.setCoordinate(new DecimalCoordinate(1, 0, 0));
			
			// for the v axis, if the plane normal is facing up or down,
			// it maps the v axis south. otherwise, it maps it directly down.
			
			if (facing == 3) vaxis.setCoordinate(new DecimalCoordinate(0, -1, 0));
			else vaxis.setCoordinate(new DecimalCoordinate(0, 0, -1));
			
			// too easy!
			
			calculateTextureCoordinates();
		}
		
		public void alignToFace()
		{
			// this is similar to the world alignment, except after setting the
			// vaxis to world, we need to figure out the uaxis alone the plane.
			// this is found by finding the normal between the vaxis and the plane normal.
			DecimalCoordinate vaxtemp;
			int facing = plane.generalFacing();
			
			if (facing == 3) vaxtemp = new DecimalCoordinate(0, -1, 0);
			else vaxtemp = new DecimalCoordinate(0, 0, -1);
			
			Log.DebugMessage(vaxtemp.ToString());
			
			uaxis.setCoordinate(vaxtemp.cross(plane.getNormal()).normalise());
			
			// now we use this new uaxis value to do the same with the vaxis (as it 
			// is still aligned to world
			
			vaxis.setCoordinate(plane.getNormal().cross(uaxis.getCoordinate()).normalise());
			
			// not too easy! had to shuffle the order of everything until i
			// got this right - the uaxis and vaxis order, and the order of
			// both cross products. what a pain!
			
			calculateTextureCoordinates();
		}
		public void copyTextureSettings(MapFace face)
		{
			//apply properties
			this.Rotation = face.Rotation;
			this.Uaxis = face.uaxis.copy();
			this.Vaxis = face.vaxis.copy();
			this.Uscale = face.uscale;
			this.Vscale = face.vscale;
		}
		
		public void AlignTo(MapFace face)
		{
			//recalulate texture axes
			DecimalCoordinate ua = face.Uaxis.getCoordinate().normalise();
			DecimalCoordinate va = face.Vaxis.getCoordinate().normalise();
			decimal ut = face.Uaxis.D;
			decimal vt = face.Vaxis.D;
			decimal us = face.Uscale;
			decimal vs = face.Vscale;
						
			// this code was ungodly difficult to figure out.
			// too many references to list, but there were tiny
			// bits of information all over the internet
			// which i finally manged to piece together into this
			// brick of comments (which are so whoever is maintaining
			// this [probably me] doesn't go on an insane rampage.)
			// i know it's working because i tweaked it until it
			// got the same values as hammer (or close enough).
			// it feels GREAT when you finally see that seam disappear :)
			
			//get the current "zero" values of the textures
			//(i.e. the translation that would be needed for
			//the (0,0) pixel to be at the origin)
			//since ua and va are unit vectors we can multiply by the
			//translation numbers, as they will end up as 1 (in the proper direction)
			//this is to hold the new translation values, after transformation
			DecimalCoordinate zeroU = ua * ut * us;
			DecimalCoordinate zeroV = va * vt * vs;
			
			//now we need to figure out the difference (in angle) between the two
			//planes, so we can rotate the texture that same amount
			DecimalCoordinate oldPlaneNormal = face.Plane.getNormal().normalise();
			DecimalCoordinate newPlaneNormal = this.Plane.getNormal().normalise();
			
			//get the axis that the new plane has rotated on (if it started at the old plane)
			DecimalCoordinate rotationAxis = oldPlaneNormal.cross(newPlaneNormal).normalise();
			
			//need a reference point that both faces can relate to - 
			//use the intersection point with the rotation axis plane.
			//i don't really understand this, so thank god the internet exists!
			DecimalPlane rotationPlane = new DecimalPlane(rotationAxis, 0);
			DecimalCoordinate intersect;
			if (Converter.getIntersect(face.Plane, this.Plane, rotationPlane, out intersect)) {
				//if we don't get here then there's no intersect - faces are parallel.
				//this means that the texture doesn't have to be rotated as it is
				//already on the same plane.
				
				//get the angle between the texture normal and the plane normal
				//the texture normal is the cross product of the U and V axes
				DecimalCoordinate textureNormal = ua.cross(va).normalise();
				
				//this is a bit tricky. since both axis and normal are unit vectors, their
				//dot product simplifies to A.B = cos(angle), i.e. the distance between the two.
				//multiplying the axis by cos(angle) will skew it correctly, to be able to put
				//the normal into the correct position.
				DecimalCoordinate axisTextureNormal = textureNormal - rotationAxis * rotationAxis.dot(textureNormal);
				DecimalCoordinate axisPlaneNormal = newPlaneNormal - rotationAxis * rotationAxis.dot(newPlaneNormal);
				
				axisTextureNormal = axisTextureNormal.normalise();
				axisPlaneNormal = axisPlaneNormal.normalise();
				
				//the angle between two vectors is acos of their dot product
				decimal dotVal = axisTextureNormal.dot(axisPlaneNormal);
				decimal angle = (decimal)Math.Acos((double)dotVal);
				//if the dot product is negative, something's
				//facing the wrong way! rotate 180 degrees
				//before rotating normally
				if (dotVal < 0) angle = (decimal)Math.PI - angle;
				
				//rotate the texture axis by the specified angle
				//around the rotation axis we found before
				CoordinateTransformation transform = new CoordinateTransformation();
				transform.AddRotationAxis(angle, rotationAxis);
				
				ua = transform.Operate(ua);
				va = transform.Operate(va);
				
				//rotate the zero vectors too, but start at the magic reference point
				transform = new CoordinateTransformation();
				transform.AddTranslation(intersect);
				transform.AddRotationAxis(angle, rotationAxis);
				transform.AddTranslation(-intersect);
				
				zeroU = transform.Operate(zeroU);
				zeroV = transform.Operate(zeroV);
			}
			
			//grab the new translation values ut and vt
			//(this cancels out the multiplication we did at the start)
			ut = ua.dot(zeroU) / us;
			vt = va.dot(zeroV) / vs;
			
			//apply properties
			this.Rotation = 0;
			this.Uaxis = new Vector4(ua, ut);
			this.Vaxis = new Vector4(va, vt);
			this.Uscale = us;
			this.Vscale = vs;
		}
		
		public void rotateTexture(decimal degrees)
		{
			//rotate around the texture normal
			DecimalCoordinate norm = vaxis.getCoordinate().cross(uaxis.getCoordinate()).normalise();
			
			CoordinateTransformation transform = new CoordinateTransformation();
			transform.AddRotationAxis(degrees * (decimal)Math.PI / 180, norm);
			
			uaxis.setCoordinate(transform.Operate(uaxis.getCoordinate()));
			vaxis.setCoordinate(transform.Operate(vaxis.getCoordinate()));
			
			// very too easy!
			
			calculateTextureCoordinates();
		}
		#endregion
		
		#region Transformation
		public virtual void applyTransformation(CoordinateTransformation transform)
		{
			foreach (MapVertex v in vertices) {
				v.applyTransformation(transform);
			}
			reCalc2D();
		}
		#endregion
		
		#region Intersection
		public bool edgeCollide(BoundingBox box)
		{
			for (int i = 0; i < vertices.Count-1; i++) {
				if (box.intersectLine(vertices[i].Location,vertices[i+1].Location)) {
					Log.LogMessage("Collision of {" + box.BottomLeftLow.round(1) + " " + box.TopRightHigh.round(1) + "} successful against: " + vertices[i].Location.round(1) + " " + vertices[i+1].Location.round(1));
					return true;
				}
			}
			if (box.intersectLine(vertices[vertices.Count-1].Location,vertices[0].Location)) {
				return true;
			}
			return false;
		}
		
		public bool intersectLine(DecimalCoordinate start, DecimalCoordinate finish, out DecimalCoordinate intersect)
		{
			// First find the intersect of the line with the plane
			intersect = plane.intersectLine(start, finish);
			if (intersect == null) return false;
			
			/* http://ozviz.wasp.uwa.edu.au/~pbourke/geometry/insidepoly/ */
			// Calculate the angle sum.
			// The sum will be 2 * PI if the point is inside the face.
			// I believe that because intersect must be on the plane, it will be 0 otherwise.
			// But I could be wrong.
			double sum = 0;
			for (int i = 0; i < vertices.Count; i++) {
				
				int i1 = i;
				int i2 = (i + 1) % vertices.Count;
				
				// Translate the vertices so that the intersect point is on the origin
				DecimalCoordinate v1 = vertices[i1].Location - intersect;
				DecimalCoordinate v2 = vertices[i2].Location - intersect;
				
				decimal m1 = v1.vectorMagnitude();
				decimal m2 = v2.vectorMagnitude();
				decimal nom = m1 * m2;
				if (nom < 0.001m) return true; // on vertex
				sum += Math.Acos((double)(v1.dot(v2) / nom));
			}
			
			return (Math.Abs(sum - Math.PI * 2) < 0.001);
		}
		#endregion
		
		#region Clipping
		public FaceClassification classify(DecimalPlane p)
		{
			int front = 0;
			int back = 0;
			int onplane = 0;
			int count = vertices.Count;
			
			foreach (MapVertex v in vertices) {
				DecimalCoordinate c = v.Location;
				int test = p.onPlane(c);
				if (test < 0) back++;
				else if (test > 0) front++;
				else {
					onplane++;
					back++;
					front++;
				}
			}
			
			if (onplane == count) return FaceClassification.OnPlane;
			if (front == count) return FaceClassification.Front;
			if (back == count) return FaceClassification.Back;
			return FaceClassification.Spanning;
		}
		#endregion
		
		#region Copy
		public virtual MapFace copy(CoordinateTransformation transform)
		{
			MapFace fac = new MapFace();
			fac.texture = texture;
			fac.textureResource = textureResource;
			fac.vaxis = vaxis.copy();
			fac.uaxis = uaxis.copy();
			fac.rotation = rotation;
			fac.uscale = uscale;
			fac.vscale = vscale;
			foreach (MapVertex v in vertices) {
				DecimalCoordinate c = v.Location;
				fac.addVertex(transform.Operate(c));
			}
			fac.calculateTextureCoordinates();
			return fac;
		}
		
		public virtual MapFace copyExact()
		{
			MapFace fac = new MapFace();
			fac.texture = texture;
			fac.textureResource = textureResource;
			fac.vaxis = vaxis.copy();
			fac.uaxis = uaxis.copy();
			fac.rotation = rotation;
			fac.uscale = uscale;
			fac.vscale = vscale;
			fac.selected = false;
			fac.drawSelected = false;
			fac.parent = null;
			fac.colour = colour;
			fac.plane = plane.copy();
			foreach (MapVertex v in vertices) {
				DecimalCoordinate c = v.Location;
				fac.addVertex(c.Clone());
			}
			fac.reCalc2D();
			fac.calculateTextureCoordinates();
			return fac;
		}
		#endregion
		
		public string dump(int tabs)
		{
			string tabstr = "";
			for (int i = 0; i < tabs; i++) tabstr += "\t";
			string s = tabstr + "-FACE-\r\n";
			s += tabstr + "plane: " + plane.ToString();
			return s;
		}
	}
}
