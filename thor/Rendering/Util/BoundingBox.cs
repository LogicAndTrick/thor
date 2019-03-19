/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 1/01/2009
 * Time: 6:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace thor
{
	/// <summary>
	/// A basic Axis-Aligned Bounding Box.
	/// </summary>
	public class BoundingBox
	{
		DecimalCoordinate topLeftHigh;
		DecimalCoordinate topRightHigh;
		DecimalCoordinate bottomLeftHigh;
		DecimalCoordinate bottomRightHigh;
		DecimalCoordinate topLeftLow;
		DecimalCoordinate topRightLow;
		DecimalCoordinate bottomLeftLow;
		DecimalCoordinate bottomRightLow;
		
		Color colour;
		
		decimal x;
		decimal y;
		decimal z;
		
		public Color Colour {
			get { return colour; }
			set { colour = value; }
		}
		
		public decimal X {
			get { return x; }
			set { x = value; }
		}
		
		public decimal Y {
			get { return y; }
			set { y = value; }
		}
		
		public decimal Z {
			get { return z; }
			set { z = value; }
		}
		
		public DecimalCoordinate TopLeftHigh {
			get { return topLeftHigh; }
			set { topLeftHigh = value; }
		}
		
		public DecimalCoordinate TopRightHigh {
			get { return topRightHigh; }
			set { topRightHigh = value; }
		}
		
		public DecimalCoordinate BottomLeftHigh {
			get { return bottomLeftHigh; }
			set { bottomLeftHigh = value; }
		}
		
		public DecimalCoordinate BottomRightHigh {
			get { return bottomRightHigh; }
			set { bottomRightHigh = value; }
		}
		
		public DecimalCoordinate TopLeftLow {
			get { return topLeftLow; }
			set { topLeftLow = value; }
		}
		
		public DecimalCoordinate TopRightLow {
			get { return topRightLow; }
			set { topRightLow = value; }
		}
		
		public DecimalCoordinate BottomLeftLow {
			get { return bottomLeftLow; }
			set { bottomLeftLow = value; }
		}
		
		public DecimalCoordinate BottomRightLow {
			get { return bottomRightLow; }
			set { bottomRightLow = value; }
		}
		
		public BoundingBox(DecimalCoordinate start, DecimalCoordinate end)
		{
			setBounds(start,end);
			this.colour = Color.Pink;
		}
		
		public BoundingBox(params DecimalCoordinate[] vertices)
		{
			setBounds(true,vertices);
			this.colour = Color.Pink;
		}
		
		public BoundingBox(BoundingBox b)
		{
			setBounds(b);
			this.colour = Color.Pink;
		}
		
		public void setBounds(bool usepoints, params DecimalCoordinate[] points)
		{
			if (points.Length < 1) return;
			decimal xLeast = points[0].getX();
			decimal xMost = points[0].getX();
			decimal yLeast = points[0].getY();
			decimal yMost = points[0].getY();
			decimal zLeast = points[0].getZ();
			decimal zMost = points[0].getZ();
			for (int i = 1; i < points.Length; i++) {
				if (points[i].getX() < xLeast) xLeast = points[i].getX();
				if (points[i].getX() > xMost)  xMost = points[i].getX();
				if (points[i].getY() < yLeast) yLeast = points[i].getY();
				if (points[i].getY() > yMost)  yMost = points[i].getY();
				if (points[i].getZ() < zLeast) zLeast = points[i].getZ();
				if (points[i].getZ() > zMost)  zMost = points[i].getZ();
			}
			
			DecimalCoordinate start = new DecimalCoordinate(xLeast,yLeast,zLeast);
			DecimalCoordinate end = new DecimalCoordinate(xMost,yMost,zMost);
			
			setBounds(start,end);
		}
		
		public void setBounds(DecimalCoordinate start, DecimalCoordinate end)
		{
			topLeftHigh = new DecimalCoordinate(start.getX(),end.getY(),end.getZ());
			topRightHigh = end.Clone();
			bottomLeftHigh = new DecimalCoordinate(start.getX(),start.getY(),end.getZ());
			bottomRightHigh = new DecimalCoordinate(end.getX(),start.getY(),end.getZ());
			
			topLeftLow = new DecimalCoordinate(start.getX(),end.getY(),start.getZ());
			topRightLow = new DecimalCoordinate(end.getX(),end.getY(),start.getZ());
			bottomLeftLow = start.Clone();
			bottomRightLow = new DecimalCoordinate(end.getX(),start.getY(),start.getZ());
			
			x = end.getX()-start.getX();
			y = end.getY()-start.getY();
			z = end.getZ()-start.getZ();
		}
		
		public void setBounds(BoundingBox b)
		{
			this.topLeftHigh = b.topLeftHigh.Clone();
			this.topRightHigh = b.topRightHigh.Clone();
			this.bottomLeftHigh = b.bottomLeftHigh.Clone();
			this.bottomRightHigh = b.bottomRightHigh.Clone();
			this.topLeftLow = b.topLeftLow.Clone();
			this.topRightLow = b.topRightLow.Clone();
			this.bottomLeftLow = b.bottomLeftLow.Clone();
			this.bottomRightLow = b.bottomRightLow.Clone();
			
			this.x = b.x;
			this.y = b.y;
			this.z = b.z;
		}
		
		public void setBounds(params BoundingBox[] boxes)
		{
			DecimalCoordinate[] points = new DecimalCoordinate[boxes.Length * 2];
			for (int i = 0, j = 0; j < boxes.Length * 2; i++, j += 2) {
				if ((object)boxes[i] == null) continue;
				points[j] = boxes[i].bottomLeftLow;
				points[j+1] = boxes[i].topRightHigh;
			}
			setBounds(true,points);
		}
		
		public bool withinBounds(int xPos, int yPos, NewGLMapView2D view)
		{
			DecimalCoordinate actualPos = view.relativeToAbsolute(new DecimalCoordinate(xPos,yPos,0));
			DecimalCoordinate tbll = view.NativeToXY(bottomLeftLow);
			DecimalCoordinate ttrh = view.NativeToXY(topRightHigh);
			if (actualPos.getX() < tbll.getX()) return false;
			if (actualPos.getX() > ttrh.getX()) return false;
			if (actualPos.getY() < tbll.getY()) return false;
			if (actualPos.getY() > ttrh.getY()) return false;
			return true;
		}
		
		public DecimalCoordinate[] getPointArray(NewGLMapView2D view)
		{
			DecimalCoordinate BL = view.NativeToXY(bottomLeftLow);
			DecimalCoordinate TR = view.NativeToXY(topRightHigh);
			DecimalCoordinate TL = new DecimalCoordinate(BL.X,TR.Y,0);
			DecimalCoordinate BR = new DecimalCoordinate(TR.X,BL.Y,0);
			DecimalCoordinate TC = new DecimalCoordinate(BL.X+(TR.X-BL.X)/2,TR.Y,0);
			DecimalCoordinate BC = new DecimalCoordinate(BL.X+(TR.X-BL.X)/2,BL.Y,0);
			DecimalCoordinate CL = new DecimalCoordinate(BL.X,BL.Y+(TR.Y-BL.Y)/2,0);
			DecimalCoordinate CR = new DecimalCoordinate(TR.X,BL.Y+(TR.Y-BL.Y)/2,0);
			return new DecimalCoordinate[] { TR, TC, TL, CL, CR, BR, BC, BL };
		}
		
		public void applyMove(NewGLMapView2D view, DecimalCoordinate position)
		{
			//position is the bottom left corner
			//decimal min = view.AssociatedDocument.Data.MapSizeLow;
			decimal max = view.AssociatedDocument.Data.MapSizeHigh;
			DecimalCoordinate newTR = position + new DecimalCoordinate(x,y,z);
			if (newTR.getX() > max) {
				decimal diff = newTR.getX() - max;
				position.setX(position.getX() - diff);
			}
			if (newTR.getY() > max) {
				decimal diff = newTR.getY() - max;
				position.setY(position.getY() - diff);
			}
			if (newTR.getZ() > max) {
				decimal diff = newTR.getZ() - max;
				position.setZ(position.getZ() - diff);
			}
			DecimalCoordinate dl = position - bottomLeftLow;
			//this will set the "unneeded" coordinate to 0.
			DecimalCoordinate dl2 = view.zeroUnusedDimension(dl);
			setBounds(bottomLeftLow+dl2,topRightHigh+dl2);
		}
		
		public void applyResize(BoxTool.ResizeHandle handle, NewGLMapView2D view, DecimalCoordinate position)
		{
			bool updatebx = false;
			bool updateby = false;
			bool updatetx = false;
			bool updatety = false;
			switch (handle) {
				case SelectTool.ResizeHandle.TopLeft:
					updatebx = updatety = true;
					break;
				case SelectTool.ResizeHandle.BottomRight:
					updatetx = updateby = true;
					break;
				case SelectTool.ResizeHandle.TopCentre:
					updatety = true;
					break;
				case SelectTool.ResizeHandle.BottomCentre:
					updateby = true;
					break;
				case SelectTool.ResizeHandle.TopRight:
					updatetx = updatety = true;
					break;
				case SelectTool.ResizeHandle.BottomLeft:
					updatebx = updateby = true;
					break;
				case SelectTool.ResizeHandle.CentreLeft:
					updatebx = true;
					break;
				case SelectTool.ResizeHandle.CentreRight:
					updatetx = true;
					break;
				default:
					throw new Exception();
			}
			DecimalCoordinate tns = view.NativeToXY(position);
			DecimalCoordinate ab = view.NativeToXY(bottomLeftLow);
			DecimalCoordinate at = view.NativeToXY(topRightHigh);
			if (updatebx) ab.X = tns.X;
			if (updateby) ab.Y = tns.Y;
			if (updatetx) at.X = tns.X;
			if (updatety) at.Y = tns.Y;
			if (updatebx && ab.X > at.X) ab.X = at.X;
			if (updateby && ab.Y > at.Y) ab.Y = at.Y;
			if (updatetx && at.X < ab.X) at.X = ab.X;
			if (updatety && at.Y < ab.Y) at.Y = ab.Y;
			ab = view.XYtoNative(ab);
			at = view.XYtoNative(at);
			ab += (bottomLeftLow - view.zeroUnusedDimension(bottomLeftLow));
			at += (topRightHigh - view.zeroUnusedDimension(topRightHigh));
			setBounds(true,ab,at);
		}
		
		public DecimalCoordinate[][] getFaces()
		{
			DecimalCoordinate[][] ret = new DecimalCoordinate[6][];
			ret[0] = new DecimalCoordinate[] {
				bottomLeftHigh.Clone(), bottomRightHigh.Clone(),
				bottomRightLow.Clone(), BottomLeftLow.Clone()
			};
			ret[1] = new DecimalCoordinate[] {
				topRightHigh.Clone(), topLeftHigh.Clone(),
				topLeftLow.Clone(), topRightLow.Clone()
			};
			ret[2] = new DecimalCoordinate[] {
				topLeftHigh.Clone(), bottomLeftHigh.Clone(),
				bottomLeftLow.Clone(), topLeftLow.Clone()
			};
			ret[3] = new DecimalCoordinate[] {
				bottomRightHigh.Clone(), topRightHigh.Clone(),
				topRightLow.Clone(), bottomRightLow.Clone()
			};
			ret[4] = new DecimalCoordinate[] {
				topLeftHigh.Clone(), topRightHigh.Clone(),
				bottomRightHigh.Clone(), bottomLeftHigh.Clone()
			};
			ret[5] = new DecimalCoordinate[] {
				bottomLeftLow.Clone(), bottomRightLow.Clone(), topRightLow.Clone(), topLeftLow.Clone()
			};
			return ret;
		}
		
		public MapFace[] getMapFaces()
		{
			MapFace[] faces = new MapFace[6];
			DecimalCoordinate[][] faceCoords = getFaces();
			for (int i = 0; i < 6; i++) {
				MapFace f = new MapFace();
				
				f.addVertices(faceCoords[i]);
				f.Plane = new DecimalPlane(faceCoords[i][0], faceCoords[i][1], faceCoords[i][2]);
				
				faces[i] = f;
			}
			return faces;
		}
		
		public bool intersect(BoundingBox that)
		{
			if (this.bottomLeftLow.X >= that.topRightHigh.X) return false;
			if (that.bottomLeftLow.X >= this.topRightHigh.X) return false;
			
			if (this.bottomLeftLow.Y >= that.topRightHigh.Y) return false;
			if (that.bottomLeftLow.Y >= this.topRightHigh.Y) return false;
			
			if (this.bottomLeftLow.Z >= that.topRightHigh.Z) return false;
			if (that.bottomLeftLow.Z >= this.topRightHigh.Z) return false;
			
			return true;
		}
		
		/* http://www.gamedev.net/community/forums/topic.asp?topic_id=338987 */
		public bool intersectLine(DecimalCoordinate start, DecimalCoordinate finish)
		{
			if (start.X < bottomLeftLow.X && finish.X < bottomLeftLow.X) return false;
			if (start.X > topRightHigh.X && finish.X > topRightHigh.X) return false;
			
			if (start.Y < bottomLeftLow.Y && finish.Y < bottomLeftLow.Y) return false;
			if (start.Y > topRightHigh.Y && finish.Y > topRightHigh.Y) return false;
			
			if (start.Z < bottomLeftLow.Z && finish.Z < bottomLeftLow.Z) return false;
			if (start.Z > topRightHigh.Z && finish.Z > topRightHigh.Z) return false;
			
			DecimalCoordinate d = (finish - start) / 2;
			DecimalCoordinate e = (topRightHigh - bottomLeftLow) / 2;
			DecimalCoordinate c = start + d - (bottomLeftLow + topRightHigh) / 2;
			DecimalCoordinate ad = d.absolute();
			DecimalCoordinate adm = d * -1;
			
			if (Math.Abs(c.X) > e.X + ad.X) return false;
			if (Math.Abs(c.Y) > e.Y + ad.Y) return false;
			if (Math.Abs(c.Z) > e.Z + ad.Z) return false;
			
			DecimalCoordinate dca = d.cross(c).absolute();
			
			if (dca.X > e.Y * ad.Z + e.Z * ad.Y) return false;
			if (dca.Y > e.Z * ad.X + e.X * ad.Z) return false;
			if (dca.Z > e.X * ad.Y + e.Y * ad.X) return false;
			
			return true;
		}
	}
}
