/*
 * Created by SharpDevelop.
 * User: s4142421
 * Date: 24/04/2009
 * Time: 10:43 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of ClipTool.
	/// </summary>
	public class ClipTool : BaseTool
	{
		DecimalCoordinate point1;
		DecimalCoordinate point2;
		DecimalCoordinate point3;
		
		ClipDrawingMode drawMode;
		
		decimal boxRadius;
		
		public enum ClipDrawingMode
		{
			None,
			Drawn,
			MovingPoint1,
			MovingPoint2,
			MovingPoint3
		}
		
		public ClipTool(Document doc) : base(doc)
		{
			toolName = "Clip";
			point1 = new DecimalCoordinate(0,0,0);
			point2 = point1.Clone();
			point3 = point1.Clone();
			drawMode = ClipDrawingMode.None;
			boxRadius = 3;
		}
		
		private int hitBox(MouseEventArgs e, NewGLMapView2D view)
		{
			decimal rad = boxRadius + 2;
			DecimalCoordinate hit = view.relativeToAbsolute(new DecimalCoordinate(e.X,view.Height-e.Y,0));
			DecimalCoordinate m = new DecimalCoordinate(-rad,-rad,0) / view.Zoom;
			DecimalCoordinate p = new DecimalCoordinate(rad,rad,0) / view.Zoom;
			DecimalCoordinate[] corners = new DecimalCoordinate[] { point1, point2, point3 };
			for (int i = 0; i < corners.Length; i++) {
				DecimalCoordinate point = view.NativeToXY(corners[i]);
				DecimalCoordinate pm = point+m;
				DecimalCoordinate pp = point+p;
				if (hit.X < pp.X && hit.X > pm.X && hit.Y > pm.Y && hit.Y < pp.Y) return i+1;
			}
			return 0;
		}
		
		public override System.Drawing.Image getImage()
		{
			return new Bitmap("cliptool.png");
		}
		
		public override BaseTool Copy(Document doc)
		{
			return new ClipTool(doc);
		}
		
		public override Cursor getCursor2D(ActionType atype, MouseEventArgs e, NewGLMapView2D view)
		{
			if (hitBox(e,view) > 0) return Cursors.Cross;
			return Cursors.Default;
		}
		
		public override Cursor getCursor3D(ActionType atype, MouseEventArgs e, MapView3D view)
		{
			return Cursors.Default;
		}
		
		public override bool actionNeeded2D(ActionType atype)
		{
			switch (atype) {
				case ActionType.MouseDown:
					return true;
				case ActionType.MouseUp:
					return true;
				case ActionType.MouseMove:
					return true;
				case ActionType.KeyPress:
					return true;
				case ActionType.KeyDown:
					return true;
			}
			return true;
		}
		
		public override bool actionNeeded3D(ActionType atype)
		{
			return false;
		}
		
		public override void performAction2D(ActionType atype, EventArgs e, NewGLMapView2D view)
		{
			MouseEventArgs me = (e as MouseEventArgs);
			KeyPressEventArgs kpe = (e as KeyPressEventArgs);
			DecimalCoordinate snapped;
			switch (atype) {
				case ActionType.MouseDown:
					int hit = hitBox(me,view);
					if (hit > 0) {
						if (hit == 1) drawMode = ClipDrawingMode.MovingPoint1;
						else if (hit == 2) drawMode = ClipDrawingMode.MovingPoint2;
						else if (hit == 3) drawMode = ClipDrawingMode.MovingPoint3;
					}
					else {
						snapped = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(new DecimalCoordinate(me.X,view.Height-me.Y,0))));
						drawMode = ClipDrawingMode.MovingPoint2;
						point1 = point1 - view.zeroUnusedDimension(point1) + snapped;
						point2 = point1.Clone();
						DecimalCoordinate minus = new DecimalCoordinate(view.GridSize, view.GridSize, view.GridSize);
						minus -= view.zeroUnusedDimension(minus);
						point3 = point1.Clone() - minus;
						associatedDocument.refreshAllViews();
					}
					break;
				case ActionType.MouseUp:
					drawMode = ClipDrawingMode.Drawn;
					break;
				case ActionType.MouseMove:
					if (drawMode == ClipDrawingMode.MovingPoint1) {
						snapped = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(new DecimalCoordinate(me.X,view.Height-me.Y,0))));
						point1 = point1 - view.zeroUnusedDimension(point1) + snapped;
						associatedDocument.refreshAllViews();
					}
					else if (drawMode == ClipDrawingMode.MovingPoint2) {
						snapped = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(new DecimalCoordinate(me.X,view.Height-me.Y,0))));
						point2 = point2 - view.zeroUnusedDimension(point2) + snapped;
						associatedDocument.refreshAllViews();
					} else if (drawMode == ClipDrawingMode.MovingPoint3) {
						snapped = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(new DecimalCoordinate(me.X,view.Height-me.Y,0))));
						point3 = point3 - view.zeroUnusedDimension(point3) + snapped;
						associatedDocument.refreshAllViews();
					}
					break;
				case ActionType.KeyPress:
					if (kpe.KeyChar == 27 || kpe.KeyChar == 13) drawMode = ClipDrawingMode.None;
					if (kpe.KeyChar == 13) {
						if (point1 != point2 && point2 != point3 && point1 != point3) {
							DecimalPlane pln = new DecimalPlane(point1, point2, point3);
							foreach (MapObject o in associatedDocument.SelectedObjects) {
								if (o is MapSolid) {
									MapSolid sol = (o as MapSolid);
									MapSolid[] spl = sol.split(pln);
									MapObject solParent = sol.Parent;
									if (spl[0] != null) {
										spl[0].setSelect(true);
										solParent.addChild(spl[0]);
									}
									if (spl[1] != null) {
										spl[1].setSelect(true);
										solParent.addChild(spl[1]);
									}
									sol.setSelect(false);
									solParent.removeChild(sol);
								}
							}
							associatedDocument.updateCache();
						}
					}
					associatedDocument.refreshAllViews();
					break;
				case ActionType.KeyDown:
					break;
			}
		}
		
		public override void performAction3D(ActionType atype, EventArgs e, MapView3D view)
		{
			return;
		}
		
		public override void render2D(NewGLMapView2D view)
		{
			//TODO
			if (drawMode == ClipDrawingMode.None) return;
			
			
			if (point1 != point2 && point2 != point3 && point1 != point3) {
				Renderer2D.setLineWidth(2);
				Renderer2D.setColour(Color.White);
				
				DecimalPlane pln = new DecimalPlane(point1, point2, point3);
				foreach (MapObject o in associatedDocument.SelectedObjects) {
					if (o is MapSolid) {
						MapSolid sol = (o as MapSolid);
						MapSolid[] spl = sol.split(pln);
						if (spl[0] != null) Renderer2D.renderMapObject(spl[0], true);
						if (spl[1] != null) Renderer2D.renderMapObject(spl[1], true);
					}
				}
				
				Renderer2D.setLineWidth(1);
			}
			
			DecimalCoordinate os1 = view.XYtoNative(new DecimalCoordinate(-boxRadius,-boxRadius,0)) / view.Zoom;
			DecimalCoordinate os2 = view.XYtoNative(new DecimalCoordinate(boxRadius,-boxRadius,0)) / view.Zoom;
			DecimalCoordinate os3 = view.XYtoNative(new DecimalCoordinate(boxRadius,boxRadius,0)) / view.Zoom;
			DecimalCoordinate os4 = view.XYtoNative(new DecimalCoordinate(-boxRadius,boxRadius,0)) / view.Zoom;
			
			Renderer2D.setColour(Color.Turquoise);
			Renderer2D.renderLineStrip(point1, point2);
			Renderer2D.renderLineStrip(point2, point3);
			Renderer2D.renderLineStrip(point3, point1);
			
			Renderer2D.setQuadMode();
			Renderer2D.setColour(Color.White);
			Renderer2D.renderPolygon(point1+os1,point1+os2,point1+os3,point1+os4);
			Renderer2D.renderPolygon(point2+os1,point2+os2,point2+os3,point2+os4);
			Renderer2D.renderPolygon(point3+os1,point3+os2,point3+os3,point3+os4);
			
			Renderer2D.setLineMode();
			Renderer2D.setColour(Color.Black);
			Renderer2D.renderLineLoop(point1+os1,point1+os2,point1+os3,point1+os4);
			Renderer2D.renderLineLoop(point2+os1,point2+os2,point2+os3,point2+os4);
			Renderer2D.renderLineLoop(point3+os1,point3+os2,point3+os3,point3+os4);
		}
		
		public override void render3D(MapView3D view)
		{
			if (drawMode == ClipDrawingMode.None) return;
			
			if (point1 == point2 || point2 == point3 || point1 == point3) return;
			DecimalPlane pln = new DecimalPlane(point1, point2, point3);
			
			Renderer3D.setColourWithAlpha(Color.FromArgb(100, Color.Turquoise));
			Renderer3D.disableTextures();
			
			int min = associatedDocument.Data.MapSizeLow;
			int max = associatedDocument.Data.MapSizeHigh;
			int fac = pln.generalFacing();
			DecimalCoordinate nad, blc, brc, tlc, trc, BL, BR, TL, TR;
			nad = blc = brc = tlc = trc = null;
			
			switch (fac) {
				case 1:	// X dir
					nad = new DecimalCoordinate(max * 2, 0, 0);
					blc = new DecimalCoordinate(min, min, min);
					brc = new DecimalCoordinate(min, min, max);
					tlc = new DecimalCoordinate(min, max, min);
					trc = new DecimalCoordinate(min, max, max);
					break;
				case 2:	// Y dir
					nad = new DecimalCoordinate(0, max * 2, 0);
					blc = new DecimalCoordinate(min, min, min);
					brc = new DecimalCoordinate(max, min, min);
					tlc = new DecimalCoordinate(min, min, max);
					trc = new DecimalCoordinate(max, min, max);
					break;
				case 3:	// Z dir
					nad = new DecimalCoordinate(0, 0, max * 2);
					blc = new DecimalCoordinate(min, min, min);
					brc = new DecimalCoordinate(max, min, min);
					tlc = new DecimalCoordinate(min, max, min);
					trc = new DecimalCoordinate(max, max, min);
					break;
			}
			BL = pln.intersectLine(blc, blc + nad, true, true);
			BR = pln.intersectLine(brc, brc + nad, true, true);
			TL = pln.intersectLine(tlc, tlc + nad, true, true);
			TR = pln.intersectLine(trc, trc + nad, true, true);
			
			Renderer3D.renderQuad(BL, TL, TR, BR);
			Renderer3D.renderQuad(BR, TR, TL, BL);
			
			//Renderer3D.disableDepthTesting();
			
			Renderer3D.switchTo2D();
			Renderer2D.setLineWidth(2);
			
			foreach (MapObject o in associatedDocument.SelectedObjects) {
				if (o is MapSolid) {
					MapSolid sol = (o as MapSolid);
					MapSolid[] spl = sol.split(pln);
					if (spl[0] != null) Renderer2D.renderMapObject(spl[0], true);
					if (spl[1] != null) Renderer2D.renderMapObject(spl[1], true);
				}
			}
			
			Renderer2D.setLineWidth(1);
			Renderer2D.switchTo3D();
			//Renderer3D.enableDepthTesting();
			Renderer3D.enableTextures();
		}
		
	}
}
