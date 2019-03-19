/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 19/06/2009
 * Time: 1:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

using OpenTK.Graphics.OpenGL;

namespace thor
{
	/// <summary>
	/// Description of Renderer2D.
	/// </summary>
	public static class Renderer2D
	{
		public static void renderMapObject(MapObject o)
		{
			renderMapObject(o, false);
		}
		
		public static void renderMapObject(MapObject o, bool overrideColour)
		{
			renderMapObject(o, overrideColour, false);
		}
		
		public static void renderMapObject(MapObject o, bool overrideColour, bool disponly)
		{
			if (o is MapSolid) {
				renderMapSolid((MapSolid)o, overrideColour, disponly);
			} else if (o is MapGroup) {
				
			} else if (o is MapWorld) {
				
			} else if (o is MapEntity) {
				renderMapEntity(o as MapEntity, overrideColour);
			}
		}
		
		private static void renderMapEntity(MapEntity e, bool overrideColour)
		{
			if (e.Children.Count > 0 || (e.EntityData != null && e.EntityData.ClassType == GameDataClassTypes.Solid)) return;
			if (!overrideColour) {
				if (e.Selected) setColour(Color.Red);
				else setColour(e.Colour);
			}
			renderBox(e.Bbox);
		}
		
		private static void renderMapSolid(MapSolid o, bool overrideColour, bool disponly)
		{
			if (!overrideColour) {
				if (o.Selected) setColour(Color.Red);
				else GL.Color3(o.Colour);
			}
			MapSolid s = (MapSolid)o;
			foreach (MapFace f in s.Faces) {
				if (!o.ContainsDisplacement || !disponly || f is MapDisplacement) renderMapFace(f, o.Selected);
			}
		}
		
		private static void renderMapFace(MapFace f, bool selected)
		{
			if (f is MapDisplacement && selected) {
				renderMapDisplacement((MapDisplacement)f);
			} else {
				List<DecimalCoordinate> templist = new List<DecimalCoordinate>();
				foreach (MapVertex v in f.Vertices) {
					templist.Add(v.Location);
				}
				renderLineLoop(templist.ToArray());
				/*for (int i = 0; i < f.Vertices.Count - 1; i++) {
					DecimalCoordinate c1 = f.Vertices[i];
					DecimalCoordinate c2 = f.Vertices[i + 1];
					renderCoordinates(c1, c2);
				}*/
			}
		}
		
		private static void renderMapDisplacement(MapDisplacement d)
		{
			for (int i = 0; i < d.Resolution; i++) {
				bool flip = (i % 2 != 0);
				for (int j = 0; j < d.Resolution; j++) {
					int t = i;
					int b = i;
					if (flip) t++;
					else b++;
					renderLineLoop(d.Points[i,j], d.Points[i+1,j], d.Points[b,j+1]);
					renderLineLoop(d.Points[t,j], d.Points[i+1,j+1], d.Points[i,j+1]);
					flip = !flip;
				}
			}
		}
		
		private static void renderCoordinates(params DecimalCoordinate[] coords)
		{
			foreach (DecimalCoordinate c in coords) {
				GL.Vertex3(c.DX, c.DY, c.DZ);
			}
		}
		
		public static void renderLineStrip(params DecimalCoordinate[] coords)
		{
			if (coords.Length < 2) throw new Exception();
			for (int i = 0; i < coords.Length - 1; i++) {
				renderCoordinates(coords[i], coords[i + 1]);
			}
		}
		
		public static void renderLineLoop(params DecimalCoordinate[] coords)
		{
			renderLineStrip(coords);
			renderCoordinates(coords[coords.Length - 1], coords[0]);
		}
		
		public static void renderPolygon(params DecimalCoordinate[] coords)
		{
			renderCoordinates(coords);
		}
		
		public static void renderBox(DecimalCoordinate start, DecimalCoordinate finish)
		{
			renderBox(new BoundingBox(start, finish));
		}
		
		public static void renderBox(BoundingBox box)
		{
			renderLineLoop(box.BottomLeftLow, box.BottomLeftHigh, box.BottomRightHigh, box.BottomRightLow);
			renderLineLoop(box.BottomRightLow, box.BottomRightHigh, box.TopRightHigh, box.TopRightLow);
			renderLineLoop(box.TopRightLow, box.TopRightHigh, box.TopLeftHigh, box.TopLeftLow);
			renderLineLoop(box.TopLeftLow, box.TopLeftHigh, box.BottomLeftHigh, box.BottomLeftLow);
			renderLineLoop(box.TopLeftLow, box.BottomLeftLow, box.BottomRightLow, box.TopRightLow);
			renderLineLoop(box.BottomLeftHigh, box.TopLeftHigh, box.TopRightHigh, box.BottomRightHigh);
		}
		
		public static void renderCircle(DecimalCoordinate start, decimal radius, NewGLMapView2D view, bool polygon)
		{
			DecimalCoordinate[] points = new DecimalCoordinate[36];
			for (int i = 0; i < 36; i++) {
				double deg = i * 10 * Math.PI / 180;
				points[i] = view.XYtoNative(new DecimalCoordinate((decimal)Math.Cos(deg), (decimal)Math.Sin(deg), 0) * radius) + start;
			}
			if (polygon) renderPolygon(points);
			else renderLineLoop(points);
		}
		
		public static void renderRectangle(DecimalCoordinate start, DecimalCoordinate finish, NewGLMapView2D view, bool polygon)
		{
			DecimalCoordinate p1 = view.NativeToXY(start);
			DecimalCoordinate p3 = view.NativeToXY(finish);
			DecimalCoordinate p2 = new DecimalCoordinate(p3.X, p1.Y, 0);
			DecimalCoordinate p4 = new DecimalCoordinate(p1.X, p3.Y, 0);
			if (polygon) {
				renderPolygon(view.XYtoNative(p1),
				              view.XYtoNative(p2),
				              view.XYtoNative(p3),
				              view.XYtoNative(p4));
			} else {
				renderLineLoop(view.XYtoNative(p1),
				               view.XYtoNative(p2),
				               view.XYtoNative(p3),
				               view.XYtoNative(p4));
			}
		}
		
		public static void renderRectangle(DecimalCoordinate point, decimal offset, bool polygon)
		{
			DecimalCoordinate p1 = new DecimalCoordinate(point.X - offset, point.Y - offset, 0);
			DecimalCoordinate p3 = new DecimalCoordinate(point.X + offset, point.Y + offset, 0);
			DecimalCoordinate p2 = new DecimalCoordinate(p1.X, p3.Y, 0);
			DecimalCoordinate p4 = new DecimalCoordinate(p3.X, p1.Y, 0);
			if (polygon) {
				renderPolygon(p1,
				              p2,
				              p3,
				              p4);
			} else {
				renderLineLoop(p1,
				               p2,
				               p3,
				               p4);
			}
		}
		
		public static void setColour(Color c)
		{
			GL.Color3(c);
		}
		
		public static void setColourWithAlpha(Color c)
		{
			GL.Color4(c);
		}
		
		public static void setLineWidth(decimal d)
		{
			end();
			GL.LineWidth((float)d);
			begin();
		}
		
		public static void setLineMode()
		{
			GL.End();
			GL.Begin(BeginMode.Lines);
		}
		
		public static void setQuadMode()
		{
			GL.End();
			GL.Begin(BeginMode.Quads);
		}
		
		public static void setPolygonMode()
		{
			GL.End();
			GL.Begin(BeginMode.Polygon);
		}
		
		public static void switchTo3D()
		{
			GL.End();
			GL.Begin(BeginMode.Triangles);
		}
		
		public static void begin()
		{
			GL.Begin(BeginMode.Lines);
		}
		
		public static void end()
		{
			GL.End();
		}
		
		/// <summary>
		/// Creates a new matrix to modify; It is identical to
		/// the previous one until it is modified.
		/// </summary>
		public static void pushMatrix()
		{
			GL.End();
			GL.PushMatrix();
			GL.Begin(BeginMode.Lines);
		}
		
		/// <summary>
		/// Deletes the current matrix and switches to the next
		/// matrix in the stack.
		/// </summary>
		public static void popMatrix()
		{
			GL.End();
			GL.PopMatrix();
			GL.Begin(BeginMode.Lines);
		}
		
		/// <summary>
		/// Loads the Identity matrix into the current matrix
		/// on the top of the stack. (Resets it to 0,0,0)
		/// </summary>
		public static void loadIdentity()
		{
			GL.End();
			GL.LoadIdentity();
			GL.Begin(BeginMode.Lines);
		}
		
		public static void rotate(decimal angle, DecimalCoordinate vector)
		{
			GL.End();
			GL.Rotate((double)angle, vector.DX, vector.DY, vector.DZ);
			GL.Begin(BeginMode.Lines);
		}
		
		public static void translate(DecimalCoordinate vector)
		{
			GL.End();
			GL.Translate(vector.DX, vector.DY, vector.DZ);
			GL.Begin(BeginMode.Lines);
		}
		
		public static void scale(DecimalCoordinate vector)
		{
			GL.End();
			GL.Scale(vector.DX, vector.DY, vector.DZ);
			GL.Begin(BeginMode.Lines);
		}
		
		public static void skew(decimal amountx, decimal amounty, Orientation2D orient)
		{
			double sxy = 0;
			double sxz = 0;
			double syx = 0;
			double syz = 0;
			double szx = 0;
			double szy = 0;
			double sk1 = (double)amountx;
			double sk2 = (double)amounty;
			if (orient == Orientation2D.XY) {
				syx = sk2;
				sxy = sk1;
			} else if (orient == Orientation2D.XZ) {
				szx = sk2;
				sxz = sk1;
			} else if (orient == Orientation2D.YZ) {
				szy = sk2;
				syz = sk1;
			}
			//shear mapping
			double[] m = new double[] {
				1,   syx, szx,   0,
				sxy, 1,   szy,   0,
				sxz, syz,   1,   0,
				0,   0,     0,   1 };
			GL.End();
			GL.MultMatrix(m);
			GL.Begin(BeginMode.Lines);
		}
	}
}
