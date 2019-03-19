/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 12/07/2009
 * Time: 2:42 PM
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
	/// Description of VMTool.
	/// </summary>
	public class VMTool : BoxTool
	{
		#region Initialisation
		private VMState vmState;
		
		private decimal boxRadius;
		
		private List<MapVertex> selectedVertices;
		private List<DecimalCoordinate> cache;
		private List<DecimalCoordinate> cache2d;
		
		DecimalCoordinate moveStart;
		
		private enum VMState {
			MovingVertex,
			None
		}
		
		public VMTool(Document doc) : base(doc)
		{
			toolName = "VM";
			hasMemory = false;
			vmState = VMState.None;
			selectedVertices = new List<MapVertex>();
			cache = new List<DecimalCoordinate>();
			cache2d = new List<DecimalCoordinate>();
			boxRadius = 3;
		}
		#endregion
		
		#region Cache
		private void updateCache()
		{
			cache.Clear();
			foreach (MapObject o in associatedDocument.SelectedObjects) {
				if (o is MapSolid) {
					MapSolid s = (o as MapSolid);
					foreach (MapFace f in s.Faces) {
						foreach (MapVertex v in f.Vertices) {
							DecimalCoordinate point = v.Location;
							if (!cache.Contains(point)) cache.Add(point);
						}
					}
				}
			}
		}
		#endregion
		
		#region Basic Implementation
		public override void selected(bool isSelect)
		{
			cache.Clear();
			if (isSelect) {
				updateCache();
			} else {
				selectedVertices.Clear();
			}
			base.selected(isSelect);
		}
		
		public override BaseTool Copy(Document doc)
		{
			return new VMTool(doc);
		}
		
		public override Image getImage()
		{
			return new Bitmap("vmtool.png");
		}
		
		protected override Color getBoxRenderColour()
		{
			return Color.Orange;
		}
		
		protected override void postActionCleanup()
		{
			// nothing
		}
		#endregion
		
		#region Util
		private List<MapVertex> hitTest(MouseEventArgs e, NewGLMapView2D view)
		{
			decimal rad = boxRadius + 1;
			DecimalCoordinate hit = view.relativeToAbsolute(new DecimalCoordinate(e.X,view.Height-e.Y,0));
			DecimalCoordinate m = new DecimalCoordinate(-rad,-rad,0) / view.Zoom;
			DecimalCoordinate p = new DecimalCoordinate(rad,rad,0) / view.Zoom;
			
			List<MapVertex> hitList = new List<MapVertex>();
			foreach (MapObject o in associatedDocument.SelectedObjects) {
				if (o is MapSolid) {
					MapSolid s = (o as MapSolid);
					foreach (MapFace f in s.Faces) {
						foreach (MapVertex v in f.Vertices) {
							DecimalCoordinate point = view.NativeToXY(v.Location);
							DecimalCoordinate pm = point+m;
							DecimalCoordinate pp = point+p;
							if (hit.X < pp.X && hit.X > pm.X && hit.Y > pm.Y && hit.Y < pp.Y) {
								// something here
								if (!hitList.Contains(v)) hitList.Add(v);
							}
						}
					}
				}
			}
			return hitList;
		}
		
		private List<MapVertex> hitTest(MouseEventArgs e, MapView3D view)
		{
			decimal rad = boxRadius + 1;
			DecimalCoordinate hit = new DecimalCoordinate(e.X,view.Height-e.Y,0);
			DecimalCoordinate m = new DecimalCoordinate(-rad,-rad,0);
			DecimalCoordinate p = new DecimalCoordinate(rad,rad,0);
			
			List<MapVertex> hitList = new List<MapVertex>();
			foreach (MapObject o in associatedDocument.SelectedObjects) {
				if (o is MapSolid) {
					MapSolid s = (o as MapSolid);
					foreach (MapFace f in s.Faces) {
						foreach (MapVertex v in f.Vertices) {
							DecimalCoordinate point = view.WorldToScreen(v.Location);
							DecimalCoordinate pm = point+m;
							DecimalCoordinate pp = point+p;
							if (hit.X < pp.X && hit.X > pm.X && hit.Y > pm.Y && hit.Y < pp.Y) {
								// something here
								if (!hitList.Contains(v)) hitList.Add(v);
							}
						}
					}
				}
			}
			return hitList;
		}
		#endregion
		
		protected override void moveMouse(MouseEventArgs e, NewGLMapView2D view)
		{
			if (vmState == VMState.MovingVertex && selectedVertices.Count > 0) {
				DecimalCoordinate moveFinish = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(new DecimalCoordinate(e.X,view.Height-e.Y,0))));
				DecimalCoordinate moveAll = moveFinish - moveStart;
				moveStart = moveFinish;
				foreach(MapVertex selvrt in selectedVertices) {
					MapVertex vert = selvrt.copy();
					MapSolid sol = vert.Parent.Parent;
					
					#region Later
					/**
					List<DecimalPlane> planes = new List<DecimalPlane>();
					foreach (MapFace f in sol.Faces) {
						if (f.Vertices.Contains(vert)) {
							MapVertex tempv = f.Vertices[f.Vertices.IndexOf(vert)];
							planes.Add(new DecimalPlane(tempv.getLeftNeighbour().Location, tempv.Location + moveAll, tempv.getRightNeighbour().Location));
						} else {
							planes.Add(f.Plane);
						}
					}
					try {
						DecimalCoordinate[][] verts = Converter.planesToVertices(planes.ToArray());
						for (int i = 0; i < sol.Faces.Count; i++) {
							sol.Faces[i].Vertices.Clear();
							sol.Faces[i].addVertices(verts[i]);
						}
						sol.reCalcBBox();
						foreach (MapFace f in sol.Faces) f.calculateTextureCoordinates();
					} catch (Exception) {
						
					}
					selectedVertices.Clear();
					foreach (MapFace f in sol.Faces) {
						if (f.Vertices.Contains(new MapVertex(vert.Location + moveAll))) {
							selectedVertices.Add(f.Vertices[f.Vertices.IndexOf(new MapVertex(vert.Location + moveAll))]);
						}
					}
					/**/
					#endregion
					
					CoordinateTransformation transform = new CoordinateTransformation();
					transform.AddTranslation(moveAll);
					foreach (MapFace f in sol.Faces) {
						if (f.Vertices.Contains(vert)) {
							MapVertex tempv = f.Vertices[f.Vertices.IndexOf(vert)];
							tempv.applyTransformation(transform);
						}
						f.reCalc2D();
						f.calculateTextureCoordinates();
					}
					sol.reCalcBBox();
				}
				updateCache();
				associatedDocument.refreshAllViews();
			}
			base.moveMouse(e, view);
		}
		
		protected override void downMouse(MouseEventArgs e, NewGLMapView2D view)
		{
			List<MapVertex> hitList = hitTest(e, view);
			
			bool selected = false;
			foreach (MapVertex sel in selectedVertices) {
				if (hitList.Contains(sel)) selected = true;
			}
			
			//Select the points underneath the mouse
			if (!selected) {
				if (state != BoxState.Drawn || !selectBox.withinBounds(e.X,view.Height-e.Y,view)) {
					if (!Accessor.keyPressed(Keys.ControlKey)) selectedVertices.Clear();
					if (Accessor.Instance.Shift) {
						selectedVertices.AddRange(hitList);
					} else if (hitList.Count > 0) {
						if (!selectedVertices.Contains(hitList[0])) selectedVertices.Add(hitList[0]);
					}
					else {
						state = BoxState.None;
						vmState = VMState.None;
					}
				}
			}
			
			if (hitList.Count > 0) {
				state = BoxState.DoNothing;
				vmState = VMState.MovingVertex;
				moveStart = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(new DecimalCoordinate(e.X,view.Height-e.Y,0))));
			}
			base.downMouse(e, view);
		}
		
		protected override void upMouse(MouseEventArgs e, NewGLMapView2D view)
		{
			if (!moved || (vmState == VMState.MovingVertex && selectedVertices.Count > 0)) {
				vmState = VMState.None;
				state = BoxState.None;
				associatedDocument.refreshAllViews();
			}
			base.upMouse(e, view);
		}
		
		protected override void singleClick(MouseEventArgs e, NewGLMapView2D view)
		{
			
		}
		
		public override bool actionNeeded3D(ActionType atype)
		{
			switch (atype) {
				case ActionType.MouseDown:
					return true;
				case ActionType.KeyDown:
					return true;
			}
			return base.actionNeeded3D(atype);
		}
		
		public override void performAction3D(ActionType atype, EventArgs e, MapView3D view)
		{
			switch (atype) {
				case ActionType.MouseDown:
					List<MapVertex> hitList = hitTest(e as MouseEventArgs, view);
					
					//Select the points underneath the mouse
						if (!Accessor.keyPressed(Keys.ControlKey)) selectedVertices.Clear();
						if (Accessor.Instance.Shift) {
							selectedVertices.AddRange(hitList);
						} else if (hitList.Count > 0) {
							if (!selectedVertices.Contains(hitList[0])) selectedVertices.Add(hitList[0]);
						}
					break;
				case ActionType.KeyDown:
					KeyEventArgs ke = e as KeyEventArgs;
					//
					break;
			}
			base.performAction3D(atype, e, view);
		}
		
		#region Rendering
		public override void render2D(NewGLMapView2D view)
		{
			DecimalCoordinate offset = view.XYtoNative(new DecimalCoordinate(boxRadius,boxRadius,0)) / view.Zoom;
			
			Renderer2D.setQuadMode();
			Renderer2D.setColour(Color.White);
			foreach (DecimalCoordinate point in cache) {
				Renderer2D.renderRectangle(point - offset, point + offset, view, true);
			}
			
			Renderer2D.setColour(Color.Red);
			foreach (MapVertex v in selectedVertices) {
				DecimalCoordinate point = v.Location;
				Renderer2D.renderRectangle(point - offset, point + offset, view, true);
			}
			
			Renderer2D.setLineMode();
			Renderer2D.setColour(Color.Black);
			foreach (DecimalCoordinate point in cache) {
				Renderer2D.renderRectangle(point - offset, point + offset, view, false);
			}
			
			base.render2D(view);
		}
		
		public override void render3D(MapView3D view)
		{
			Renderer3D.disableTextures();
			Renderer3D.disableDepthTesting();
			Renderer3D.switchTo2D();
			foreach (MapObject o in associatedDocument.SelectedObjects) {
				if (o is MapSolid) {
					Renderer2D.setColour(Color.White);
					Renderer2D.renderMapObject(o, true);
				}
			}
			
			Renderer2D.switchTo3D();
			Renderer3D.enableDepthTesting();
			Renderer3D.enableTextures();
			base.render3D(view);
		}
		
		public override void renderOverlay3D(MapView3D view)
		{
			cache2d.Clear();
			foreach (DecimalCoordinate pt in cache) {
				DecimalCoordinate point = view.WorldToScreen(pt);
				cache2d.Add(point);
			}
			
			DecimalCoordinate offset = new DecimalCoordinate(boxRadius,boxRadius,0);
			
			Renderer2D.setQuadMode();
			Renderer2D.setColour(Color.White);
			foreach (DecimalCoordinate point in cache2d) {
				Renderer2D.renderRectangle(point, boxRadius, true);
			}
			
			Renderer2D.setColour(Color.Red);
			foreach (MapVertex v in selectedVertices) {
				DecimalCoordinate point = view.WorldToScreen(v.Location);
				Renderer2D.renderRectangle(point, boxRadius, true);
			}
			
			Renderer2D.setLineMode();
			Renderer2D.setColour(Color.Black);
			foreach (DecimalCoordinate point in cache2d) {
				Renderer2D.renderRectangle(point, boxRadius, false);
			}
			
			base.renderOverlay3D(view);
		}
		#endregion
	}
}
