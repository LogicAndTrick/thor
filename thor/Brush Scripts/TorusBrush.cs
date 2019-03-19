/*
 * Created by SharpDevelop.
 * User: s4142421
 * Date: 28/04/2009
 * Time: 12:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace thor
{
	/// <summary>
	/// Description of TorusBrush.
	/// </summary>
	public class TorusBrush : BrushInterface
	{
		private TorusBrushForm form;
		
		public TorusBrush()
		{
			form = new TorusBrushForm();
		}
		
		public string getName()
		{
			return "Torus";
		}
		
		public BrushInterface copy()
		{
			return new TorusBrush();
		}
		
		public List<MapObject> makeBrush(BoundingBox box)
		{
			int sides = Accessor.Instance.Main.ObjectTools.getNumber();
			List<MapObject> newbrush = new List<MapObject>();
			form.setMax(Math.Min(box.X/2-0.1m,box.Y/2-0.1m));
			form.ShowDialog();
			if (!form.OK) return newbrush;
			if (sides < 3) return newbrush;
			decimal ringwidth = form.getWidth();
			int ringsides = form.getSides();
			decimal width = box.X;
			decimal length = box.Y;
			decimal height = box.Z;
			decimal majorPrimary = (width-ringwidth)/2;
			decimal minorPrimary = (length-ringwidth)/2;
			decimal majorSecondary = ringwidth/2;
			decimal minorSecondary = height/2;
			DecimalCoordinate center = box.BottomLeftLow + new DecimalCoordinate(width/2,length/2,0);
			Random rnd = new Random();
			decimal addangle = (360 * (decimal)Math.PI / 180) / sides;
			decimal ringangle = (360 * (decimal)Math.PI / 180) / ringsides;
			DecimalCoordinate[] primaryPoints = new DecimalCoordinate[sides];
			DecimalCoordinate[] secondaryPoints = new DecimalCoordinate[ringsides];
			for (int i = 0; i < sides; i++) {
				decimal angle = i * addangle;
				decimal xval = center.X + majorPrimary * (decimal)Math.Cos((double)angle);
				decimal yval = center.Y + minorPrimary * (decimal)Math.Sin((double)angle);
				decimal zval = center.Z;
				primaryPoints[i] = new DecimalCoordinate(xval,yval,zval).round(0);
			}
			for (int i = 0; i < ringsides; i++) {
				decimal angle = i * ringangle;
				decimal xval = majorSecondary * (decimal)Math.Cos((double)angle);
				decimal yval = minorSecondary * (decimal)Math.Sin((double)angle);
				secondaryPoints[i] = new DecimalCoordinate(xval,yval,0).round(0);
			}
			
			MapFace[] faces = new MapFace[ringsides];
			for (int j = 0; j < ringsides; j++) {
				faces[j] = new MapFace();
				faces[j].Texture = "";
				faces[j].Uaxis = new Vector4(1,0,0,0);
				faces[j].Vaxis = new Vector4(0,-1,0,0);
				faces[j].Rotation = 0;
				faces[j].Uscale = 0.25m;
				faces[j].Vscale = 0.25m;
			}
			DecimalCoordinate addheight = new DecimalCoordinate(0,0,height/2);
			DecimalCoordinate[,] points = new DecimalCoordinate[sides,ringsides];
			for (int i = 0; i < sides; i++) {
				CoordinateTransformation transorm = new CoordinateTransformation();
				transorm.AddRotationOrigin(new DecimalCoordinate((decimal)Math.PI/2,0,i * addangle));
				for (int j = 0; j < ringsides; j++) {
					points[i,j] = primaryPoints[i] + transorm.Operate(secondaryPoints[j]) + addheight;
				}
			}
			for (int i = 0; i < sides; i++) {
				MapSolid block1 = new MapSolid();
				block1.Colour = Color.FromArgb(255,0,rnd.Next(50,256),rnd.Next(50,256));
				MapFace[] faces1 = new MapFace[ringsides+2];
				for (int j = 0; j < ringsides+2; j++) {
					faces1[j] = new MapFace();
					faces1[j].Texture = "";
					faces1[j].Uaxis = new Vector4(1,0,0,0);
					faces1[j].Vaxis = new Vector4(0,-1,0,0);
					faces1[j].Rotation = 0;
					faces1[j].Uscale = 0.25m;
					faces1[j].Vscale = 0.25m;
				}
				int index1 = i;
				int index2 = (i != (sides - 1)) ? (i + 1) : 0;
				for (int j = 0; j < ringsides; j++) {
					int index3 = j;
					int index4 = (j != (ringsides - 1)) ? (j + 1) : 0;
					faces1[j].addVertex(points[index1,index3]);
					faces1[j].addVertex(points[index1,index4]);
					faces1[j].addVertex(points[index2,index4]);
					faces1[j].addVertex(points[index2,index3]);
					block1.addFace(faces1[j]);
				}
				for (int j = 0; j < ringsides; j++) {
					faces1[ringsides].addVertex(points[index2,j]);
					faces1[ringsides+1].addVertex(points[index1,ringsides-1-j]);
				}
				block1.addFace(faces1[ringsides]);
				block1.addFace(faces1[ringsides+1]);
				block1.reCalcBBox();
				newbrush.Add(block1);
			}
			return newbrush;
		}
	}
}
