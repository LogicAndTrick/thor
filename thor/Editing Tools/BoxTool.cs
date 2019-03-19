/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 14/02/2009
 * Time: 6:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using OpenTK.Graphics.OpenGL;

namespace thor
{
	/// <summary>
	/// Description of BoxTool.
	/// </summary>
	public abstract class BoxTool : BaseTool
	{
		#region Initialisation
		protected BoundingBox selectBox;
		protected BoxState state;
		
		protected DecimalCoordinate drawingStart;
		protected Cursor currentCursor;
		protected BoundingBox lastDrawnBox;
		
		protected DecimalCoordinate grabbedAt;
		
		protected DecimalCoordinate lastSnappedCoordinate;
		
		protected DecimalCoordinate[] resizeOffsets;
		protected int resizeSize;
		protected ResizeHandle currentHandle;
		protected bool moved;
		protected bool hasMemory;
		protected bool fullRefresh;
		
		protected bool drawText;
		protected Font textFont;
		//protected TextPrinter printer;
		
		protected enum BoxState {
			None,
			ReadyToDraw,
			Drawing,
			Drawn,
			Moving,
			Resizing,
			DoNothing
		}
		
		public enum ResizeHandle
		{
			TopRight = 0,
			TopCentre = 1,
			TopLeft = 2,
			CentreLeft = 3,
			CentreRight = 4,
			BottomRight = 5,
			BottomCentre = 6,
			BottomLeft = 7,
			None = 8
		}
		
		public BoxTool(Document doc) : base(doc)
		{
			toolName = "Box";
			selectBox = new BoundingBox(new DecimalCoordinate(0,0,0),new DecimalCoordinate(64,64,64));
			state = BoxState.None;
			drawingStart = new DecimalCoordinate(0,0,0);
			currentCursor = Cursors.Default;
			lastDrawnBox = new BoundingBox(selectBox);
			grabbedAt = new DecimalCoordinate(0,0,0);
			resizeSize = 4;
			int os = resizeSize * 2; //offset
			resizeOffsets = new DecimalCoordinate[] {
				new DecimalCoordinate(1,1,0) * os,		//TR
				new DecimalCoordinate(0,1,0) * os,		//TC
				new DecimalCoordinate(-1,1,0) * os,		//TL
				new DecimalCoordinate(-1,0,0) * os,		//CL
				new DecimalCoordinate(1,0,0) * os,		//CR
				new DecimalCoordinate(1,-1,0) * os,		//BR
				new DecimalCoordinate(0,-1,0) * os,		//BC
				new DecimalCoordinate(-1,-1,0) * os		//BL
			};
			currentHandle = ResizeHandle.None;
			moved = true;
			hasMemory = true;
			fullRefresh = false;
			drawText = true;
			//printer = new TextPrinter(TextQuality.High);
		}
		#endregion
		
		#region Util
		protected virtual ResizeHandle checkResizeHit(MouseEventArgs e, NewGLMapView2D view)
		{
			DecimalCoordinate hit = view.relativeToAbsolute(new DecimalCoordinate(e.X,view.Height-e.Y,0));
			DecimalCoordinate m = new DecimalCoordinate(-resizeSize,-resizeSize,0) / view.Zoom;
			DecimalCoordinate p = new DecimalCoordinate(resizeSize,resizeSize,0) / view.Zoom;
			DecimalCoordinate[] corners = selectBox.getPointArray(view);
			for (int i = 0; i < corners.Length; i++) {
				DecimalCoordinate point = corners[i] + resizeOffsets[i] / view.Zoom;
				DecimalCoordinate pm = point+m;
				DecimalCoordinate pp = point+p;
				if (hit.X < pp.X && hit.X > pm.X && hit.Y > pm.Y && hit.Y < pp.Y) return (ResizeHandle)i;
			}
			return ResizeHandle.None;
		}
		
		protected virtual Cursor cursorFromHandle(ResizeHandle h)
		{
			switch (h) {
				case ResizeHandle.TopLeft:
				case ResizeHandle.BottomRight:
					return Cursors.SizeNWSE;
				case ResizeHandle.TopCentre:
				case ResizeHandle.BottomCentre:
					return Cursors.SizeNS;
				case ResizeHandle.TopRight:
				case ResizeHandle.BottomLeft:
					return Cursors.SizeNESW;
				case ResizeHandle.CentreLeft:
				case ResizeHandle.CentreRight:
					return Cursors.SizeWE;
				case ResizeHandle.None:
					return Cursors.Default;
				default:
					throw new Exception();
			}
		}
		
		public override Cursor getCursor2D(ActionType atype, MouseEventArgs e, NewGLMapView2D view)
		{
			switch (state) {
				case BoxState.None:
					return Cursors.Default;
				case BoxState.Drawn:
					if (selectBox.withinBounds(e.X,view.Height-e.Y,view)) return Cursors.SizeAll;
					ResizeHandle tempRes = checkResizeHit(e,view);
					if (tempRes != ResizeHandle.None) return cursorFromHandle(tempRes);
					return Cursors.Default;
				case BoxState.ReadyToDraw:
					return Cursors.Default;
				case BoxState.Drawing:
					return Cursors.Cross;
				case BoxState.Moving:
					return Cursors.SizeAll;
				case BoxState.Resizing:
					return currentCursor;
			}
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
					if (state == BoxState.Moving) return true;
					if (state == BoxState.Drawing) return true;
					if (state == BoxState.ReadyToDraw) return true;
					if (state == BoxState.Resizing) return true;
					if (state == BoxState.DoNothing) return true;
					return false;
				case ActionType.KeyPress:
					return true;
				case ActionType.KeyDown:
					return true;
			}
			return true;
		}
		
		protected DecimalCoordinate[] getSpareDimension(NewGLMapView2D view, DecimalCoordinate start)
		{
			DecimalCoordinate[] ret = new DecimalCoordinate[2];
			ret[0] = start.Clone();
			ret[1] = start.Clone();
			switch (view.Orientation) {
				case Orientation2D.XY:
					ret[0].setZ(selectBox.TopLeftHigh.getZ());
					ret[1].setZ(selectBox.BottomRightLow.getZ());
					break;
				case Orientation2D.XZ:
					ret[0].setY(selectBox.TopLeftHigh.getY());
					ret[1].setY(selectBox.BottomRightLow.getY());
					break;
				case Orientation2D.YZ:
					ret[0].setX(selectBox.TopLeftHigh.getX());
					ret[1].setX(selectBox.BottomRightLow.getX());
					break;
			}
			return ret;
		}
		#endregion
		
		#region Actions
		public override void performAction2D(ActionType atype, EventArgs e, NewGLMapView2D view)
		{
			switch (atype) {
				case ActionType.MouseMove:
					moveMouse(e as MouseEventArgs,view);
					break;
				case ActionType.MouseDown:
					downMouse(e as MouseEventArgs,view);
					break;
				case ActionType.MouseUp:
					upMouse(e as MouseEventArgs,view);
					break;
				case ActionType.KeyPress:
					pressKey(e as KeyPressEventArgs,view);
					break;
				case ActionType.KeyDown:
					downKey(e as KeyEventArgs, view);
					break;
			}
			postActionCleanup();
			if (fullRefresh) associatedDocument.refreshAllViews();
			fullRefresh = false;
		}
		
		protected virtual void doResize(MouseEventArgs e, NewGLMapView2D view)
		{
			if (currentHandle == ResizeHandle.None) 
				throw new Exception("Oh dear, we are trying to resize without an offset.");
			DecimalCoordinate mouseRel = new DecimalCoordinate(e.X,view.Height-e.Y,0) - resizeOffsets[(int)currentHandle];
			DecimalCoordinate mouseAbs = view.relativeToAbsolute(mouseRel);
			DecimalCoordinate mouseUts = view.XYtoNative(mouseAbs);
			DecimalCoordinate snapped = view.snapToGrid(mouseUts);
			lastSnappedCoordinate = null;
			selectBox.applyResize(currentHandle,view,snapped);
		}
		
		protected virtual void doMove(MouseEventArgs e, NewGLMapView2D view)
		{
			DecimalCoordinate mouseRel = new DecimalCoordinate(e.X,view.Height-e.Y,0);
			DecimalCoordinate mouseAbs = view.relativeToAbsolute(mouseRel);
			DecimalCoordinate mouseUts = view.XYtoNative(mouseAbs);
			DecimalCoordinate snapped = view.snapToGrid(mouseUts + grabbedAt);
			selectBox.applyMove(view,snapped);
		}
		
		protected virtual void startMoving()
		{
			state = BoxState.Moving;
		}
		
		protected virtual void endMoving()
		{
			state = BoxState.Drawn;
		}
		
		protected virtual void startResizing(NewGLMapView2D view)
		{
			state = BoxState.Resizing;
		}
		
		protected virtual void endResizing()
		{
			state = BoxState.Drawn;
		}
		
		protected virtual void clickOutside(DecimalCoordinate snapped)
		{
			drawingStart = snapped.Clone();
			state = BoxState.ReadyToDraw;
		}
		#endregion
		
		#region Inputs
		protected virtual void moveMouse(MouseEventArgs e, NewGLMapView2D view)
		{
			moved = true;
			DecimalCoordinate mouseRel = new DecimalCoordinate(e.X,view.Height-e.Y,0);
			DecimalCoordinate snapped = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(mouseRel)));
			if (snapped == lastSnappedCoordinate) return;
			lastSnappedCoordinate = snapped;
			DecimalCoordinate[] spare;
			switch (state) {
				case BoxState.None:
					break;
				case BoxState.Drawn:
					break;
				case BoxState.ReadyToDraw:
					if ((object)drawingStart == null) return;
					if (snapped == drawingStart) return;
					state = BoxState.Drawing;
					if (hasMemory) {
						spare = getSpareDimension(view,drawingStart);
						selectBox.setBounds(true,drawingStart,snapped,spare[0],spare[1]);
					}
					else selectBox.setBounds(true,drawingStart,snapped);
					fullRefresh = true;
					break;
				case BoxState.Drawing:
					if (drawingStart == null) return;
					if (snapped == drawingStart) return;
					if (hasMemory) {
						spare = getSpareDimension(view,drawingStart);
						selectBox.setBounds(true,drawingStart,snapped,spare[0],spare[1]);
					}
					else selectBox.setBounds(true,drawingStart,snapped);
					fullRefresh = true;
					break;
				case BoxState.Moving:
					doMove(e,view);
					lastDrawnBox.setBounds(selectBox);
					fullRefresh = true;
					break;
				case BoxState.Resizing:
					doResize(e,view);
					lastDrawnBox.setBounds(selectBox);
					fullRefresh = true;
					break;
			}
		}
		
		protected virtual void downMouse(MouseEventArgs e, NewGLMapView2D view)
		{
			moved = false;
			DecimalCoordinate mouseRel = new DecimalCoordinate(e.X,view.Height-e.Y,0);
			DecimalCoordinate snapped = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(mouseRel)));
			switch (state) {
				case BoxState.None:
					drawingStart = snapped.Clone();
					state = BoxState.ReadyToDraw;
					return;
				case BoxState.ReadyToDraw:
					return;
				case BoxState.Drawn:
					ResizeHandle resHandle = checkResizeHit(e,view);
					if (resHandle != ResizeHandle.None) {
						currentHandle = resHandle;
						currentCursor = cursorFromHandle(resHandle);
						startResizing(view);
					}
					else if (selectBox.withinBounds(e.X,view.Height-e.Y,view)) {
						DecimalCoordinate tr = view.zeroUnusedDimension(selectBox.BottomLeftLow);
						grabbedAt = tr - view.XYtoNative(view.relativeToAbsolute(mouseRel));
						startMoving();
					}
					else {
						clickOutside(snapped);
					}
					return;
				case BoxState.Drawing:
					break;
				case BoxState.Moving:
					break;
				case BoxState.Resizing:
					break;
			}
		}
		
		protected virtual void upMouse(MouseEventArgs e, NewGLMapView2D view)
		{
			bool noFunct = false;
			if (!moved) {
				singleClick(e,view);
				fullRefresh = true;
				noFunct = true;
			}
			DecimalCoordinate mouseRel = new DecimalCoordinate(e.X,view.Height-e.Y,0);
			DecimalCoordinate snapped = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(mouseRel)));
			switch (state) {
				case BoxState.None:
					return;
				case BoxState.ReadyToDraw:
					state = BoxState.None;
					fullRefresh = true;
					return;
				case BoxState.Drawn:
					return;
				case BoxState.Drawing:
					if (snapped == drawingStart) state = BoxState.None;
					else {
						state = BoxState.Drawn;
						lastDrawnBox.setBounds(selectBox);
					}
					fullRefresh = true;
					break;
				case BoxState.Moving:
					if (noFunct) state = BoxState.Drawn;
					else endMoving();
					fullRefresh = true;
					break;
				case BoxState.Resizing:
					if (noFunct) state = BoxState.Drawn;
					else endResizing();
					fullRefresh = true;
					break;
			}
		}
		
		protected virtual void pressKey(KeyPressEventArgs e, NewGLMapView2D view)
		{
			if (e.KeyChar == 27) state = BoxState.None;
			fullRefresh = true;
		}
		
		protected virtual void downKey(KeyEventArgs e, NewGLMapView2D view)
		{
			
		}
		#endregion
		
		#region Abstract
		protected abstract void singleClick(MouseEventArgs e, NewGLMapView2D view);
		protected abstract void postActionCleanup();
		protected abstract Color getBoxRenderColour();
		#endregion
		
		#region Rendering
		public override void render2D(NewGLMapView2D view)
		{
			//TODO
			Color c = getBoxRenderColour();
			bool drawhandles = false;
			switch (state) {
				case BoxState.None:
					return;
				case BoxState.ReadyToDraw:
					return;
				case BoxState.Drawn:
					drawhandles = true;
					break;
				case BoxState.Drawing:
					break;
				case BoxState.Moving:
					if (!moved) drawhandles = true;
					break;
				case BoxState.Resizing:
					break;
				case BoxState.DoNothing:
					return;
			}
			//TODO: text
			/*
			DecimalCoordinate[] corners = selectBox.getPointArray(view);
			DecimalCoordinate tc = view.absoluteToRelative(corners[(int)ResizeHandle.TopCentre]);
			DecimalCoordinate lc = view.absoluteToRelative(corners[(int)ResizeHandle.CentreLeft]);
			string topText, leftText;
			switch (view.Orientation) {
				case Orientation2D.XY:
					topText = selectBox.X.ToString("0.00");
					leftText = selectBox.Y.ToString("0.00");
					break;
				case Orientation2D.XZ:
					topText = selectBox.X.ToString("0.00");
					leftText = selectBox.Z.ToString("0.00");
					break;
				case Orientation2D.YZ:
					topText = selectBox.Y.ToString("0.00");
					leftText = selectBox.Z.ToString("0.00");
					break;
				default:
					throw new Exception();
			}
			
			textFont = new Font(FontFamily.GenericSansSerif, 16, GraphicsUnit.Pixel);
			
			TextExtents topExtents = printer.Measure(topText, textFont);
			TextExtents leftExtents = printer.Measure(leftText, textFont);
			int twid = (int)topExtents.BoundingBox.Width;
			int thei = (int)topExtents.BoundingBox.Height;
			int tcx = (int)tc.X - twid / 2;
			int tcy = view.Height-(int)tc.Y - thei - resizeSize * 4;
			
			int lwid = (int)leftExtents.BoundingBox.Width;
			int lhei = (int)leftExtents.BoundingBox.Height;
			int lcx = (int)lc.X - twid - resizeSize * 4;
			int lcy = view.Height-(int)lc.Y - lhei / 2;
			
			Renderer2D.end();
			printer.Begin();
			
			GL.Translate(tcx, tcy, 0);
			printer.Print(topText, textFont, Color.White);
			GL.Translate(lcx - tcx, lcy - tcy, 0);
			printer.Print(leftText, textFont, Color.White);
			
			printer.End();
			Renderer2D.begin();
			
			textFont.Dispose();
			*/
			Renderer2D.setColour(c);
			Renderer2D.renderBox(selectBox.BottomLeftLow, selectBox.TopRightHigh);
			if (drawhandles) drawResizeHandles(view);
			
		}
		
		protected virtual void drawResizeHandles(NewGLMapView2D view)
		{
			DecimalCoordinate os1 = view.XYtoNative(new DecimalCoordinate(-resizeSize,-resizeSize,0)) / view.Zoom;
			DecimalCoordinate os2 = view.XYtoNative(new DecimalCoordinate(resizeSize,-resizeSize,0)) / view.Zoom;
			DecimalCoordinate os3 = view.XYtoNative(new DecimalCoordinate(resizeSize,resizeSize,0)) / view.Zoom;
			DecimalCoordinate os4 = view.XYtoNative(new DecimalCoordinate(-resizeSize,resizeSize,0)) / view.Zoom;
			DecimalCoordinate[] corners = selectBox.getPointArray(view);
			Renderer2D.setQuadMode();
			Renderer2D.setColour(Color.White);
			for (int i = 0; i < corners.Length; i++) {
				DecimalCoordinate point = view.XYtoNative(corners[i]) + view.XYtoNative(resizeOffsets[i]) / view.Zoom;
				Renderer2D.renderPolygon(point+os1,point+os2,point+os3,point+os4);
			}
			Renderer2D.setLineMode();
			Renderer2D.setColour(Color.Black);
			for (int i = 0; i < corners.Length; i++) {
				DecimalCoordinate point = view.XYtoNative(corners[i]) + view.XYtoNative(resizeOffsets[i]) / view.Zoom;
				Renderer2D.renderLineLoop(point+os1,point+os2,point+os3,point+os4);
			}
		}
		#endregion
		
		public override bool actionNeeded3D(ActionType atype)
		{
			return false;
		}
		
		public override Cursor getCursor3D(ActionType atype, MouseEventArgs e, MapView3D view)
		{
			return Cursors.Default;
		}
		
		public override void performAction3D(ActionType atype, EventArgs e, MapView3D view)
		{
			if (fullRefresh) associatedDocument.refreshAllViews();
			fullRefresh = false;
		}
		
		public override void render3D(MapView3D view)
		{
			if (state == BoxState.None || state == BoxState.ReadyToDraw || state == BoxState.DoNothing) return;
			Color c = getBoxRenderColour();
			Renderer3D.disableTextures();
			Renderer3D.switchTo2D();
			Renderer2D.setColour(c);
			Renderer2D.renderBox(selectBox);
			Renderer2D.switchTo3D();
			Renderer3D.enableTextures();
		}
	}
}
