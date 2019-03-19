/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 20/06/2009
 * Time: 12:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using OpenTK.Graphics.OpenGL;

namespace thor
{
	/// <summary>
	/// Description of NewGLMapView2DXY.
	/// </summary>
	public class NewGLMapView2DXY : NewGLMapView2D
	{
		public NewGLMapView2DXY(Document doc) : base(doc)
		{
			orientation = Orientation2D.XY;
		}
		
		protected override void drawCamera()
		{
			GL.Translate(this.Width / 2, this.Height / 2, 0);
			GL.Scale((double)zoom, (double)zoom, 0);
			GL.Translate(-center.DX, -center.DY, 0);
		}
		
		public override DecimalCoordinate XYtoNative(DecimalCoordinate orig)
		{
			DecimalCoordinate ret = orig.Clone();
			ret.Z = 0;
			return ret;
		}
		
		public override DecimalCoordinate NativeToXY(DecimalCoordinate orig)
		{
			DecimalCoordinate ret = orig.Clone();
			ret.Z = 0;
			return ret;
		}
		
		public override DecimalCoordinate zeroUnusedDimension(DecimalCoordinate orig)
		{
			DecimalCoordinate ret = orig.Clone();
			ret.Z = 0;
			return ret;
		}
	}
}
