/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 21/06/2009
 * Time: 9:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace thor
{
	/// <summary>
	/// Description of Renderer3D.
	/// </summary>
	public static class Renderer3D
	{
		public static void renderMapObject(MapObject o) {
			renderMapObject(o, false);
		}
		
		public static void renderMapObject(MapObject o, bool overrideColour)
		{
			if (!o.Render) return;
			
			if (o is MapSolid) {
				renderMapSolid((MapSolid)o, overrideColour);
			} else if (o is MapGroup) {
				
			} else if (o is MapWorld) {
				
			} else if (o is MapEntity) {
				renderMapEntity(o as MapEntity);
			}
		}
		
		private static void renderMapEntity(MapEntity e)
		{
			if (e.Children.Count > 0 || (e.EntityData != null && e.EntityData.ClassType == GameDataClassTypes.Solid)) return;
			disableTextures();
			if (e.Selected) setColour(Color.Red);
			else setColour(e.Colour);
			renderBox(e.Bbox);
			enableTextures();
		}
		
		private static void renderMapSolid(MapSolid o, bool overrideColour)
		{
			if (!overrideColour) {
				if (o.Selected) setColour(Color.Red);
				else GL.Color3(o.Colour);
			}
			MapSolid s = (MapSolid)o;
			foreach (MapFace f in s.Faces) {
				if (!s.ContainsDisplacement || f is MapDisplacement) renderMapFace(f);
			}
		}
		
		private static void renderMapFace(MapFace f)
		{
			if (f is MapDisplacement) {
				renderMapDisplacement((MapDisplacement)f);
			} else {
				if (f.TextureResource != null) {
					end();
					bindTexture(f.TextureResource);
					begin();
					setColourWithAlpha(Color.FromArgb(255, Color.White));
				} else {
					setColour(f.Colour);
				}
				if (f.Selected && f.DrawSelected) setColour(Color.Red);
				for (int i = 1; i < f.Vertices.Count - 1; i++) {
					if (f.TextureResource != null)
						textureCoordinates(f.Vertices[0].TextureU, f.Vertices[0].TextureV);
					renderCoordinates(f.Vertices[0].Location);
					
					if (f.TextureResource != null)
						textureCoordinates(f.Vertices[i].TextureU, f.Vertices[i].TextureV);
					renderCoordinates(f.Vertices[i].Location);
					
					if (f.TextureResource != null)
						textureCoordinates(f.Vertices[i+1].TextureU, f.Vertices[i+1].TextureV);
					renderCoordinates(f.Vertices[i+1].Location);
				}
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
					renderCoordinates(d.Points[i,j], d.Points[i+1,j], d.Points[b,j+1]);
					renderCoordinates(d.Points[t,j], d.Points[i+1,j+1], d.Points[i,j+1]);
					flip = !flip;
				}
			}
		}
		
		private static void bindTexture(TextureObject o)
		{
			GL.BindTexture(TextureTarget.Texture2D, o.GlId);
		}
		
		public static void renderBox(DecimalCoordinate start, DecimalCoordinate finish)
		{
			renderBox(new BoundingBox(start, finish));
		}
		
		public static void renderBox(BoundingBox box)
		{
			renderQuad(box.BottomLeftLow, box.BottomLeftHigh, box.BottomRightHigh, box.BottomRightLow);
			renderQuad(box.BottomRightLow, box.BottomRightHigh, box.TopRightHigh, box.TopRightLow);
			renderQuad(box.TopRightLow, box.TopRightHigh, box.TopLeftHigh, box.TopLeftLow);
			renderQuad(box.TopLeftLow, box.TopLeftHigh, box.BottomLeftHigh, box.BottomLeftLow);
			renderQuad(box.TopLeftLow, box.BottomLeftLow, box.BottomRightLow, box.TopRightLow);
			renderQuad(box.BottomLeftHigh, box.TopLeftHigh, box.TopRightHigh, box.BottomRightHigh);
		}
		
		public static void renderQuad(DecimalCoordinate p1, DecimalCoordinate p2, DecimalCoordinate p3, DecimalCoordinate p4)
		{
			renderCoordinates(p1, p2, p3, p1, p3, p4);
		}
		
		public static void renderCoordinates(params DecimalCoordinate[] coords)
		{
			foreach (DecimalCoordinate c in coords) {
				GL.Vertex3(c.DX, c.DY, c.DZ);
			}
		}
		
		private static void textureCoordinates(decimal x, decimal y)
		{
			GL.TexCoord2((double)x, (double)y);
		}
		
		public static void setColour(Color c)
		{
			GL.Color3(c);
		}
		
		public static void setColourWithAlpha(Color c)
		{
			GL.Color4(c);
		}
		
		public static void switchTo2D()
		{
			GL.End();
			GL.Begin(BeginMode.Lines);
		}
		
		public static void begin()
		{
			GL.Begin(BeginMode.Triangles);
		}
		
		public static void end()
		{
			GL.End();
		}
		
		public static void disableTextures()
		{
			end();
			GL.Disable(EnableCap.Texture2D);
			begin();
		}
		
		public static void enableTextures()
		{
			end();
			GL.Enable(EnableCap.Texture2D);
			begin();
		}
		
		public static void disableDepthTesting()
		{
			end();
			GL.Disable(EnableCap.DepthTest);
			begin();
		}
		
		public static void enableDepthTesting()
		{
			end();
			GL.Enable(EnableCap.DepthTest);
			begin();
		}
		
		/// <summary>
		/// Creates a new matrix to modify; It is identical to
		/// the previous one until it is modified.
		/// </summary>
		public static void pushMatrix()
		{
			GL.End();
			GL.PushMatrix();
			GL.Begin(BeginMode.Triangles);
		}
		
		/// <summary>
		/// Deletes the current matrix and switches to the next
		/// matrix in the stack.
		/// </summary>
		public static void popMatrix()
		{
			GL.End();
			GL.PopMatrix();
			GL.Begin(BeginMode.Triangles);
		}
		
		/// <summary>
		/// Loads the Identity matrix into the current matrix
		/// on the top of the stack. (Resets it to 0,0,0)
		/// </summary>
		public static void loadIdentity()
		{
			GL.End();
			GL.LoadIdentity();
			GL.Begin(BeginMode.Triangles);
		}
		
		public static void rotate(decimal angle, DecimalCoordinate vector)
		{
			GL.End();
			GL.Rotate((double)angle, vector.DX, vector.DY, vector.DZ);
			GL.Begin(BeginMode.Triangles);
		}
		
		public static void translate(DecimalCoordinate vector)
		{
			GL.End();
			GL.Translate(vector.DX, vector.DY, vector.DZ);
			GL.Begin(BeginMode.Triangles);
		}
		
		public static void scale(DecimalCoordinate vector)
		{
			GL.End();
			GL.Scale(vector.DX, vector.DY, vector.DZ);
			GL.Begin(BeginMode.Triangles);
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
