/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 19/03/2009
 * Time: 8:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace thor
{
	/// <summary>
	/// Description of PipeBrush.
	/// </summary>
	public class PipeBrush : BrushInterface
	{
		private PipeBrushForm form;
		
		public PipeBrush()
		{
			form = new PipeBrushForm();
		}
		
		public string getName()
		{
			return "Pipe";
		}
		
		public BrushInterface copy()
		{
			return new PipeBrush();
		}
		
		public List<MapObject> makeBrush(BoundingBox box)
		{
			int sides = Accessor.Instance.Main.ObjectTools.getNumber();
			List<MapObject> newbrush = new List<MapObject>();
			form.setMax(Math.Min(box.X/2-0.1m,box.Y/2-0.1m));
			form.ShowDialog();
			if (!form.OK) return newbrush;
			if (sides < 3) return newbrush;
			decimal wallwidth = form.getWidth();
			decimal width = box.X;
			decimal length = box.Y;
			decimal height = box.Z;
			decimal majorOut = width/2;
			decimal minorOut = length/2;
			decimal majorIn = majorOut - wallwidth;;
			decimal minorIn = minorOut - wallwidth;
			DecimalCoordinate start = box.BottomLeftLow + new DecimalCoordinate(majorOut,minorOut,0);
			Random rnd = new Random();
			decimal addangle = (360 * (decimal)Math.PI / 180) / sides;
			DecimalCoordinate[] outer = new DecimalCoordinate[sides];
			DecimalCoordinate[] inner = new DecimalCoordinate[sides];
			for (int i = 0; i < sides; i++) {
				decimal angle = i * addangle;
				decimal xval = start.X + majorOut * (decimal)Math.Cos((double)angle);
				decimal yval = start.Y + minorOut * (decimal)Math.Sin((double)angle);
				decimal zval = start.Z;
				outer[i] = new DecimalCoordinate(xval,yval,zval).round(0);
				xval = start.X + majorIn * (decimal)Math.Cos((double)angle);
				yval = start.Y + minorIn * (decimal)Math.Sin((double)angle);
				inner[i] = new DecimalCoordinate(xval,yval,zval).round(0);
			}
			for (int i = 0; i < sides; i++) {
				MapSolid block = new MapSolid();
				block.Colour = Color.FromArgb(255,0,rnd.Next(50,256),rnd.Next(50,256));
				//points
				int index1 = i;
				int index2 = (i != (sides - 1)) ? (i + 1) : 0;
				//add faces
				DecimalCoordinate ah = new DecimalCoordinate(0,0,height);
				MapFace[] faces = new MapFace[6];
				for (int j = 0; j < 6; j++) {
					faces[j] = new MapFace();
					faces[j].Texture = "";
					faces[j].Uaxis = new Vector4(1,0,0,0);
					faces[j].Vaxis = new Vector4(0,-1,0,0);
					faces[j].Rotation = 0;
					faces[j].Uscale = 0.25m;
					faces[j].Vscale = 0.25m;
				}
				//
				faces[0].addVertex(outer[index1]);
				faces[0].addVertex(outer[index1]+ah);
				faces[0].addVertex(outer[index2]+ah);
				faces[0].addVertex(outer[index2]);
				faces[0].Plane = new DecimalPlane(outer[index1],outer[index1]+ah,outer[index2]+ah);
				//
				faces[1].addVertex(inner[index2]);
				faces[1].addVertex(inner[index2]+ah);
				faces[1].addVertex(inner[index1]+ah);
				faces[1].addVertex(inner[index1]);
				faces[1].Plane = new DecimalPlane(inner[index2],inner[index2]+ah,inner[index1]+ah);
				//
				faces[2].addVertex(outer[index2]);
				faces[2].addVertex(outer[index2]+ah);
				faces[2].addVertex(inner[index2]+ah);
				faces[2].addVertex(inner[index2]);
				faces[2].Plane = new DecimalPlane(outer[index2],outer[index2]+ah,inner[index2]+ah);
				//
				faces[3].addVertex(inner[index1]);
				faces[3].addVertex(inner[index1]+ah);
				faces[3].addVertex(outer[index1]+ah);
				faces[3].addVertex(outer[index1]);
				faces[3].Plane = new DecimalPlane(inner[index1],inner[index1]+ah,outer[index1]+ah);
				//
				faces[4].addVertex(inner[index2]+ah);
				faces[4].addVertex(outer[index2]+ah);
				faces[4].addVertex(outer[index1]+ah);
				faces[4].addVertex(inner[index1]+ah);
				faces[4].Plane = new DecimalPlane(inner[index2]+ah,outer[index2]+ah,outer[index1]+ah);
				//
				faces[5].addVertex(inner[index1]);
				faces[5].addVertex(outer[index1]);
				faces[5].addVertex(outer[index2]);
				faces[5].addVertex(inner[index2]);
				faces[5].Plane = new DecimalPlane(inner[index1],outer[index1],outer[index2]);
				//
				foreach (MapFace mf in faces) block.addFace(mf);
				//
				block.reCalcBBox();
				newbrush.Add(block);
			}
			return newbrush;
		}
	}
}
