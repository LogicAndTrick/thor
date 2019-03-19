/*
 * Created by SharpDevelop.
 * User: s4142421
 * Date: 28/04/2009
 * Time: 12:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace thor
{
	/// <summary>
	/// Description of ConeBrush.
	/// </summary>
	public class ConeBrush : BrushInterface
	{
		public ConeBrush()
		{
		}
		
		public string getName()
		{
			return "Cone";
		}
		
		public BrushInterface copy()
		{
			return new ConeBrush();
		}
		
		public List<MapObject> makeBrush(BoundingBox box)
		{
			int sides = Accessor.Instance.Main.ObjectTools.getNumber();
			List<MapObject> newbrush = new List<MapObject>();
			if (sides < 3) return newbrush;
			decimal width = box.X;
			decimal length = box.Y;
			decimal height = box.Z;
			decimal major = width/2;
			decimal minor = length/2;
			DecimalCoordinate start = box.BottomLeftLow + new DecimalCoordinate(major,minor,0);
			Random rnd = new Random();
			MapSolid block = new MapSolid();
			block.Colour = Color.FromArgb(255,0,rnd.Next(50,256),rnd.Next(50,256));
			decimal addangle = (360 * (decimal)Math.PI / 180) / sides;
			DecimalCoordinate[] points = new DecimalCoordinate[sides];
			for (int i = 0; i < sides; i++) {
				decimal angle = i * addangle;
				decimal xval = start.X + major * (decimal)Math.Cos((double)angle);
				decimal yval = start.Y + minor * (decimal)Math.Sin((double)angle);
				decimal zval = start.Z;
				points[i] = new DecimalCoordinate(xval,yval,zval).round(0);
			}
			for (int i = 0; i < sides+1; i++) {
				MapFace mf = new MapFace();
				mf.Texture = "";
				mf.Uaxis = new Vector4(1,0,0,0);
				mf.Vaxis = new Vector4(0,-1,0,0);
				mf.Rotation = 0;
				mf.Uscale = 0.25m;
				mf.Vscale = 0.25m;
				DecimalCoordinate ah = new DecimalCoordinate(0,0,height);
				if (i < sides) {
					int seci = i+1;
					if (seci == sides) seci = 0;
					mf.addVertex(points[i]);
					mf.addVertex(start+ah);
					mf.addVertex(points[seci]);
					mf.Plane = new DecimalPlane(points[i],start+ah,points[seci]);
				}
				else if (i == sides) {
					ah.Z = 0;
					foreach (DecimalCoordinate dc in points) mf.addVertex(dc+ah);
					mf.Plane = new DecimalPlane(points[0] + ah,points[1] + ah,points[2] + ah);
				}
				block.addFace(mf);
			}
			block.reCalcBBox();
			newbrush.Add(block);
			return newbrush;
		}
	}
}
