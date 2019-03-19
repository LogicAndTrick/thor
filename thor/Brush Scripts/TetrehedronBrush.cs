/*
 * Created by SharpDevelop.
 * User: s4142421
 * Date: 24/04/2009
 * Time: 10:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace thor
{
	/// <summary>
	/// Description of TetrehedronBrush.
	/// </summary>
	public class TetrehedronBrush : BrushInterface
	{
		public TetrehedronBrush()
		{
		}
		
		public string getName()
		{
			return "Tetrahedron";
		}
		
		public BrushInterface copy()
		{
			return new TetrehedronBrush();
		}
		
		public List<MapObject> makeBrush(BoundingBox box)
		{
			List<MapObject> newbrush = new List<MapObject>();
			Random rnd = new Random();
			MapSolid block = new MapSolid();
			block.Colour = Color.FromArgb(255,0,rnd.Next(50,256),rnd.Next(50,256));
			MapFace[] faces = new MapFace[4];
			for (int j = 0; j < 4; j++) {
				faces[j] = new MapFace();
				faces[j].Uaxis = new Vector4(1,0,0,0);
				faces[j].Vaxis = new Vector4(0,-1,0,0);
				faces[j].Rotation = 0;
				faces[j].Uscale = 0.25m;
				faces[j].Vscale = 0.25m;
			}
			//
			faces[0].addVertex(box.BottomRightLow.Clone());
			faces[0].addVertex(box.TopLeftLow.Clone());
			faces[0].addVertex(box.BottomLeftLow.Clone());
			faces[0].Plane = new DecimalPlane(box.BottomRightLow.Clone(),box.TopLeftLow.Clone(),box.BottomLeftLow.Clone());
			//
			faces[1].addVertex(box.BottomLeftLow.Clone());
			faces[1].addVertex(box.BottomLeftHigh.Clone());
			faces[1].addVertex(box.BottomRightLow.Clone());
			faces[1].Plane = new DecimalPlane(box.BottomLeftLow.Clone(),box.BottomLeftHigh.Clone(),box.BottomRightLow.Clone());
			//
			faces[2].addVertex(box.TopLeftLow.Clone());
			faces[2].addVertex(box.BottomLeftHigh.Clone());
			faces[2].addVertex(box.BottomLeftLow.Clone());
			faces[2].Plane = new DecimalPlane(box.TopLeftLow.Clone(),box.BottomLeftHigh.Clone(),box.BottomLeftLow.Clone());
			//
			faces[3].addVertex(box.BottomLeftHigh.Clone());
			faces[3].addVertex(box.TopLeftLow.Clone());
			faces[3].addVertex(box.BottomRightLow.Clone());
			faces[3].Plane = new DecimalPlane(box.BottomLeftHigh.Clone(),box.TopLeftLow.Clone(),box.BottomRightLow.Clone());
			//
			block.addFace(faces[0]);
			block.addFace(faces[1]);
			block.addFace(faces[2]);
			block.addFace(faces[3]);
			block.reCalcBBox();
			return newbrush;
		}
	}
}
