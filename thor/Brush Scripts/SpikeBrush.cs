/*
 * Created by SharpDevelop.
 * User: s4142421
 * Date: 28/04/2009
 * Time: 12:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace thor
{
	/// <summary>
	/// Description of SpikeBrush.
	/// </summary>
	public class SpikeBrush : BrushInterface
	{
		public SpikeBrush()
		{
		}
		
		public string getName()
		{
			return "Spike";
		}
		
		public BrushInterface copy()
		{
			return new SpikeBrush();
		}
		
		public List<MapObject> makeBrush(BoundingBox box)
		{
			List<MapObject> newbrush = new List<MapObject>();
			Random rnd = new Random();
			MapSolid block = new MapSolid();
			block.Colour = Color.FromArgb(255,0,rnd.Next(50,256),rnd.Next(50,256));
			MapFace[] faces = new MapFace[5];
			decimal width = box.X;
			decimal length = box.Y;
			decimal height = box.Z;
			decimal major = width/2;
			decimal minor = length/2;
			DecimalCoordinate start = box.BottomLeftLow + new DecimalCoordinate(major,minor,height);
			for (int j = 0; j < 5; j++) {
				faces[j] = new MapFace();
				faces[j].Texture = "";
				faces[j].Uaxis = new Vector4(1,0,0,0);
				faces[j].Vaxis = new Vector4(0,-1,0,0);
				faces[j].Rotation = 0;
				faces[j].Uscale = 0.25m;
				faces[j].Vscale = 0.25m;
			}
			//
			faces[0].addVertex(box.BottomRightLow.Clone());
			faces[0].addVertex(box.TopRightLow.Clone());
			faces[0].addVertex(box.TopLeftLow.Clone());
			faces[0].addVertex(box.BottomLeftLow.Clone());
			faces[0].Plane = new DecimalPlane(box.BottomRightLow.Clone(),box.TopRightLow.Clone(),box.TopLeftLow.Clone());
			//
			faces[1].addVertex(box.BottomLeftLow.Clone());
			faces[1].addVertex(start.Clone());
			faces[1].addVertex(box.BottomRightLow.Clone());
			faces[1].Plane = new DecimalPlane(box.BottomLeftLow.Clone(),start.Clone(),box.BottomRightLow.Clone());
			//
			faces[2].addVertex(box.TopLeftLow.Clone());
			faces[2].addVertex(start.Clone());
			faces[2].addVertex(box.BottomLeftLow.Clone());
			faces[2].Plane = new DecimalPlane(box.TopLeftLow.Clone(),start.Clone(),box.BottomLeftLow.Clone());
			//
			faces[3].addVertex(box.BottomRightLow.Clone());
			faces[3].addVertex(start.Clone());
			faces[3].addVertex(box.TopRightLow.Clone());
			faces[3].Plane = new DecimalPlane(box.BottomRightLow.Clone(),start.Clone(),box.TopRightLow.Clone());
			//
			faces[4].addVertex(box.TopRightLow.Clone());
			faces[4].addVertex(start.Clone());
			faces[4].addVertex(box.TopLeftLow.Clone());
			faces[4].Plane = new DecimalPlane(box.TopRightLow.Clone(),start.Clone(),box.TopLeftLow.Clone());
			//
			block.addFace(faces[0]);
			block.addFace(faces[1]);
			block.addFace(faces[2]);
			block.addFace(faces[3]);
			block.addFace(faces[4]);
			block.reCalcBBox();
			newbrush.Add(block);
			return newbrush;
		}
	}
}
