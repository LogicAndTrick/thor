/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 16/03/2009
 * Time: 9:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace thor
{
	/// <summary>
	/// Description of BlockBrush.
	/// </summary>
	public class BlockBrush : BrushInterface
	{
		public BlockBrush()
		{
		}
		
		public string getName()
		{
			return "Block";
		}
		
		public BrushInterface copy()
		{
			return new BlockBrush();
		}
		
		public List<MapObject> makeBrush(BoundingBox box)
		{
			List<MapObject> newbrush = new List<MapObject>();
			Random rnd = new Random();
			MapSolid block = new MapSolid();
			block.Colour = Color.FromArgb(255,0,rnd.Next(50,256),rnd.Next(50,256));
			foreach (DecimalCoordinate[] points in box.getFaces()) {
				MapFace mf = new MapFace();
				mf.Texture = "";
				mf.Uaxis = new Vector4(1,0,0,0);
				mf.Vaxis = new Vector4(0,-1,0,0);
				mf.Rotation = 0;
				mf.Uscale = 0.25m;
				mf.Vscale = 0.25m;
				foreach (DecimalCoordinate point in points) {
					mf.addVertex(point);
				}
				mf.Plane = new DecimalPlane(points[0],points[1],points[2]);
				mf.alignToWorld();
				block.addFace(mf);
			}
			block.reCalcBBox();
			newbrush.Add(block);
			return newbrush;
		}
	}
}
