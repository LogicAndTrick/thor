/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 19/06/2009
 * Time: 11:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace thor
{
	/// <summary>
	/// Description of NewGLMapView2D.
	/// </summary>
	public abstract class NewGLMapView2D : GLControl, IDisposable
	{
		#region Initialization
		// Parent document
		protected Document associatedDocument;
		
		public Document AssociatedDocument {
			get { return associatedDocument; }
			set { associatedDocument = value; }
		}
		
		// Control Properties
		protected bool isFocused;
		protected bool forceUpdate;
		protected DecimalCoordinate center;
		protected decimal gridSize;
		
		protected decimal zoom;
		protected Orientation2D orientation;
		
		public decimal GridSize {
			get { return gridSize; }
			set { gridSize = value; }
		}
		
		public DecimalCoordinate Center {
			get { return center; }
			set { center = value; }
		}
		
		public decimal Zoom {
			get { return zoom; }
			set { zoom = value; }
		}
		
		public Orientation2D Orientation {
			get { return orientation; }
			set { orientation = value; }
		}
		
		// Timers
		protected long lastTicks;
		protected long renders;
		protected decimal fps;
		protected Stopwatch ticker;
		protected Timer updater;
		
		// FPS Text
		protected Font font;
		//protected TextPrinter printer;
		
		// Object Cache
		protected List<MapObject> objectCache;
		
		// Grid Colours
		protected Color backColour;
		protected Color gridLineColour;
		protected Color gridZeroAxisColour;
		protected Color gridHighlightCustomColour;
		protected Color gridHighlight1024Colour;
		protected Color gridBoundaryColour;
		protected int gridCustomHighlightInterval;
		
		// Grid Options;
		protected bool gridHighlight1On;
		protected bool gridHighlight2On;
		
		protected int mapMin;
		protected int mapMax;
		
		bool disposed;
		
		public NewGLMapView2D(Document doc)
		{
			disposed = false;
			associatedDocument = doc;
			gridSize = 64;
			zoom = 1;
			isFocused = false;
			forceUpdate = true;
			objectCache = new List<MapObject>();
			
			mapMin = doc.Data.MapSizeLow;
			mapMax = doc.Data.MapSizeHigh;
			
			center = new DecimalCoordinate(0, 0, 0);
			//printer = new TextPrinter();
			//--------------------------
			initColours();
			initGL();
			initTimers();
		}
		
		private void initColours()
		{
			backColour = Color.Black;
			gridLineColour = Color.FromArgb(75,75,75);
			gridZeroAxisColour = Color.FromArgb(0,100,100);
			gridHighlightCustomColour = Color.FromArgb(115,115,115);
			gridHighlight1024Colour = Color.FromArgb(100,46,0);
			gridBoundaryColour = Color.Red;
			gridCustomHighlightInterval = 8;
			gridHighlight1On = true;
			gridHighlight2On = true;
			//---
			backColour = Accessor.Instance.ThorSettings.getColour("2DBackgroundColour");
			gridLineColour = Accessor.Instance.ThorSettings.getColour("2DGridColour");
			gridZeroAxisColour = Accessor.Instance.ThorSettings.getColour("2DZeroAxisColour");
			gridHighlightCustomColour = Accessor.Instance.ThorSettings.getColour("2DHighlight1Colour");
			gridHighlight1024Colour = Accessor.Instance.ThorSettings.getColour("2DHighlight2Colour");
			gridBoundaryColour = Accessor.Instance.ThorSettings.getColour("2DBoundaryColour");
			gridCustomHighlightInterval = Accessor.Instance.ThorSettings.getInt("Highlight1Distance");
			gridHighlight1On = Accessor.Instance.ThorSettings.getBool("Highlight1On");
			gridHighlight2On = Accessor.Instance.ThorSettings.getBool("Highlight2On");
		}
		
		private void initGL()
		{
			if (!Context.IsCurrent) {
				try {
					Context.MakeCurrent(null);
				} catch (Exception) {
					Log.LogMessage("Context error 2D");
					return;
				}
				MakeCurrent();
			}
			GL.ShadeModel(ShadingModel.Smooth);
			GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
			GL.Hint(HintTarget.LineSmoothHint, HintMode.Fastest);
			GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
			GL.Enable(EnableCap.Blend);
			GL.LineWidth(0.5f);
			GL.ClearDepth(1.0);
			GL.ClearColor(backColour);
		}
		
		private void initTimers()
		{
			lastTicks = 0;
			ticker = new Stopwatch();
			
			updater = new Timer();
			updater.Interval = 25;
			updater.Tick += new EventHandler(OnUpdateTick);
			
			ticker.Start();
			updater.Start();
		}
		#endregion
		
		public void update()
		{
			forceUpdate = true;
		}
		
		#region Events
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
		}
		
		protected override void OnKeyDown(KeyEventArgs e)
		{
			associatedDocument.SelectedTool.performAction2D(ActionType.KeyDown, e, this);
			base.OnKeyDown(e);
		}
		
		protected override void OnMouseMove(MouseEventArgs e)
		{
			this.Focus();
			
			this.Cursor = associatedDocument.SelectedTool.getCursor2D(ActionType.MouseMove, e, this);
			
			if (associatedDocument.SelectedTool.actionNeeded2D(ActionType.MouseMove)) {
        		associatedDocument.SelectedTool.performAction2D(ActionType.MouseMove, e, this);
        	}
			base.OnMouseMove(e);
		}
		
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (!isFocused) return;
            decimal newzoom = zoom;
        	if (e.Delta < 0) newzoom /= 1.2m;
        	if (e.Delta > 0) newzoom *= 1.2m;
        	if (newzoom < 1m/128m) newzoom = 1m/128m;
        	if (newzoom > 512) newzoom = 512;
        	//preserve mouse position
        	int tempx = e.X;
        	int tempy = this.Height-e.Y;
        	DecimalCoordinate cursor = new DecimalCoordinate(tempx, tempy, 0);
        	DecimalCoordinate before = relativeToAbsolute(cursor);
        	DecimalCoordinate after = relativeToAbsolute(cursor, newzoom);
        	//apply new settings
        	center -= (after - before);
        	zoom = newzoom;
			base.OnMouseWheel(e);
		}
		
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.Cursor = associatedDocument.SelectedTool.getCursor2D(ActionType.MouseUp, e, this);
			associatedDocument.SelectedTool.performAction2D(ActionType.MouseUp, e, this);
			base.OnMouseUp(e);
		}
		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.Cursor = associatedDocument.SelectedTool.getCursor2D(ActionType.MouseDown, e, this);
			associatedDocument.SelectedTool.performAction2D(ActionType.MouseDown, e, this);
			base.OnMouseDown(e);
		}
		
		protected override void OnResize(EventArgs e)
		{
			setupViewport();
			base.OnResize(e);
		}
		
		protected override void OnMouseLeave(EventArgs e)
		{
			isFocused = false;
			//ticker.Stop();
			//updater.Stop();
			base.OnMouseLeave(e);
		}
		
		protected override void OnMouseEnter(EventArgs e)
		{
			isFocused = true;
			//ticker.Start();
			//updater.Start();
			base.OnMouseEnter(e);
		}
		
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			associatedDocument.SelectedTool.performAction2D(ActionType.KeyPress, e, this);
			base.OnKeyPress(e);
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			forceUpdate = true;
			base.OnPaint(e);
		}
		#endregion

		#region Render Loop
		protected void OnUpdateTick(object sender, EventArgs e)
		{
			if (disposed) return;
			if (!isFocused && !forceUpdate) {
				return;
			}
			if (forceUpdate) forceUpdate = false;
			if (!Context.IsCurrent) {
				try {
					Context.MakeCurrent(null);
				} catch (Exception) {
					Log.LogMessage("Context error 2D");
					return;
				}
				MakeCurrent();
			}
			GL.Clear(ClearBufferMask.ColorBufferBit);
			GL.LoadIdentity();
			render();
			SwapBuffers();
		}
		
		protected void setupViewport()
		{
			if (disposed) return;
			if (!Context.IsCurrent) {
				Context.MakeCurrent(null);
				MakeCurrent();
			}
			int w = this.Width;
			int h = this.Height;
			GL.Viewport(0, 0, w, h);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
		}
		
		protected void render()
		{
			drawCamera();
			drawGrid();
			drawObjects();
			drawTools();
			drawFPS();
		}
		
		protected abstract void drawCamera();
		
		protected void drawGrid()
		{
			//distance between lines is the number of pixels per unit
			//multiplied by the grid distance, which is measured in units
			decimal grid = gridSize;
			decimal linedist = zoom * gridSize;
			while (linedist < 4) {
				linedist *= 8;
				grid *= 8;
			}
			Color c;
			GL.Begin(BeginMode.Lines);
			DecimalCoordinate[] coords = new DecimalCoordinate[4];
			for (int i = 0; i < coords.Length; i++) coords[i] = new DecimalCoordinate(0, 0, 0);
			for (decimal i = mapMin + grid; i < mapMax; i += grid) {
				if (i == 0) c = gridZeroAxisColour;
				else if (i % 1024 == 0 && gridHighlight2On) c = gridHighlight1024Colour;
				else if (i % (gridCustomHighlightInterval*gridSize) == 0 && gridHighlight1On) c = gridHighlightCustomColour;
				else c = gridLineColour;
				Renderer2D.setColour(c);
				double di = (double)i;
				coords[0] = new DecimalCoordinate(i, mapMin, 0);
				coords[1] = new DecimalCoordinate(i, mapMax, 0);
				coords[2] = new DecimalCoordinate(mapMin, i, 0);
				coords[3] = new DecimalCoordinate(mapMax, i, 0);
				Renderer2D.renderLineStrip(XYtoNative(coords[0]),XYtoNative(coords[1]));
				Renderer2D.renderLineStrip(XYtoNative(coords[2]),XYtoNative(coords[3]));
			}
			coords[0] = XYtoNative(new DecimalCoordinate(mapMin, mapMin, 0));
			coords[1] = XYtoNative(new DecimalCoordinate(mapMin, mapMax, 0));
			coords[2] = XYtoNative(new DecimalCoordinate(mapMax, mapMax, 0));
			coords[3] = XYtoNative(new DecimalCoordinate(mapMax, mapMin, 0));
			Renderer2D.setColour(gridBoundaryColour);
			Renderer2D.renderLineLoop(coords);
			GL.End();
		}
		
		protected void drawObjects()
		{
			//objectCache = associatedDocument.Map.Worldspawn.getAllChildren();
			GL.Begin(BeginMode.Lines);
			foreach (MapObject o in associatedDocument.ObjectCache) { //objectCache) {
				Renderer2D.renderMapObject(o);
			}
			GL.End();
		}
		
		protected void drawTools()
		{
			GL.Begin(BeginMode.Lines);
			foreach (BaseTool t in associatedDocument.Tools) {
				if (t != associatedDocument.SelectedTool) t.renderInactive2D(this);
			}
			associatedDocument.SelectedTool.render2D(this);
			GL.End();
		}
		
		protected void drawFPS()
		{
			renders++;
			decimal ticks = ticker.ElapsedMilliseconds - lastTicks;
			if (ticks >= 50) {
				lastTicks = ticker.ElapsedMilliseconds;
				fps = renders / ticks * 1000;
				renders = 0;
			}
			/*
			font = new Font(FontFamily.GenericSansSerif, 16, GraphicsUnit.Pixel);
			GL.Color3(Color.White);
			printer.Begin();
			GL.Translate(0, 0, 0);
			printer.Print(fps.ToString("0.0"), font, Color.White);
			printer.End();
			font.Dispose();
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();*/
		}
		#endregion
		
		#region Scaling and Snapping
		public abstract DecimalCoordinate XYtoNative(DecimalCoordinate orig);
		public abstract DecimalCoordinate NativeToXY(DecimalCoordinate orig);
		
		public abstract DecimalCoordinate zeroUnusedDimension(DecimalCoordinate orig);
		
		/// <summary>
		/// Converts a DecimalCoordinate that uses relative co-ordinates
		/// (i.e. where the co-ordinate is in respect the the current
		/// zoom and position of the current 2D view)
		/// and converts it into absolute co-ordinates
		/// (i.e. the map representation of a point)
		/// </summary>
		/// <param name="relative">A DecimalCoordinate that uses relative values.</param>
		public DecimalCoordinate relativeToAbsolute(DecimalCoordinate relative)
		{
			return relativeToAbsolute(relative,zoom);
		}
		
		/// <summary>
		/// Converts a DecimalCoordinate that uses relative co-ordinates
		/// (i.e. where the co-ordinate is in respect the the current
		/// zoom and position of the current 2D view)
		/// and converts it into absolute co-ordinates
		/// (i.e. the map representation of a point)
		/// </summary>
		/// <param name="relative">A DecimalCoordinate that uses relative values.</param>
		/// <param name="zoom">A decimal value to use as the zoom.</param>
		public DecimalCoordinate relativeToAbsolute(DecimalCoordinate relative, decimal zoom_value)
		{
			//now we are doing the exact opposite of the other function.
			//get our variables
			DecimalCoordinate tempcenter = center.Clone();
			tempcenter *= zoom_value;
			DecimalCoordinate zero = tempcenter - new DecimalCoordinate(this.Width/2,this.Height/2,0);
			DecimalCoordinate ret = relative.Clone();
			//forwards:
			/*
				ret *= zoom_value;
				ret -= zero;
			*/
			//backwards:
			ret += zero;
			ret /= zoom_value;
			//ret.setY(-ret.getY());
			//that should be it.
			return ret;
		}
		
		/// <summary>
		/// Converts a DecimalCoordinate that uses absolute co-ordinates
		/// (i.e. the map representation of a point)
		/// and converts it into relative co-ordinates
		/// (i.e. where the co-ordinate is in respect the the current
		/// zoom and position of the current 2D view)
		/// </summary>
		/// <param name="alsolute">A DecimalCoordinate that uses absolute values.</param>
		public DecimalCoordinate absoluteToRelative(DecimalCoordinate absolute)
		{
			return absoluteToRelative(absolute,zoom);
		}
		
		/// <summary>
		/// Converts a DecimalCoordinate that uses absolute co-ordinates
		/// (i.e. the map representation of a point)
		/// and converts it into relative co-ordinates
		/// (i.e. where the co-ordinate is in respect the the current
		/// zoom and position of the current 2D view)
		/// </summary>
		/// <param name="absolute">A DecimalCoordinate that uses absolute values.</param>
		/// <param name="zoom">A decimal value to use as the zoom.</param>
		public DecimalCoordinate absoluteToRelative(DecimalCoordinate absolute, decimal zoom_value)
		{
			//by default, 1 unit = 1 pixel, so no scaling would be necessary if zoom_value = 1.
			//if zoom_value < 1, all values must be scaled down.
			//if zoom_value > 1, all values must be scaled up.
			DecimalCoordinate ret = absolute.Clone();
			//ret.setY(-ret.getY());
			ret *= zoom_value;
			//next, all values need to be translated properly. this is the hard part.
			//the center of the screen is at the co-ordinate var center, which is absolute.
			//first we need to temporarily scale the center so that we are working in the same scale.
			DecimalCoordinate tempcenter = center.Clone();
			tempcenter *= zoom_value;
			//now we find the absolute zero co-ordinate. this is the same as relative (0,0,0).
			DecimalCoordinate zero = tempcenter - new DecimalCoordinate(this.Width/2,this.Height/2,0);
			//lets assume all these co-ords are scaled, and width and height are both 100px:
			//say our ret is (1,1,0), center is (0,0,0), and zero is (-50,-50,0).
			//to get ret to render in the right spot, it needs to be (51,51,0).
			//getting this number involves subtracting zero from ret.
			ret -= zero;
			//now we should have, hopefully, scaled this co-ordinate correctly.
			return ret;
		}
		
		/// <summary>
		/// Snaps the given coordinate in global or local space to the closest
		/// multiple of the current grid distance on the X, Y, and Z axes.
		/// </summary>
		/// <param name="dc">The coordinate to snap to grid.</param>
		/// <returns>A new coordinate, snapped to grid.</returns>
		public DecimalCoordinate snapToGrid(DecimalCoordinate dc)
		{
			//we want to snap to the nearest grid line
			decimal xval = dc.getX();
			decimal yval = dc.getY();
			decimal zval = dc.getZ();
			//start with x
			xval = Math.Round(dc.getX()/gridSize) * gridSize;
			if (xval < associatedDocument.Data.MapSizeLow) xval = associatedDocument.Data.MapSizeLow;
			if (xval > associatedDocument.Data.MapSizeHigh) xval = associatedDocument.Data.MapSizeHigh;
			//move on to y
			yval = Math.Round(dc.getY()/gridSize) * gridSize;
			if (yval < associatedDocument.Data.MapSizeLow) yval = associatedDocument.Data.MapSizeLow;
			if (yval > associatedDocument.Data.MapSizeHigh) yval = associatedDocument.Data.MapSizeHigh;
			//finish with z
			zval = Math.Round(dc.getZ()/gridSize) * gridSize;
			if (zval < associatedDocument.Data.MapSizeLow) zval = associatedDocument.Data.MapSizeLow;
			if (zval > associatedDocument.Data.MapSizeHigh) zval = associatedDocument.Data.MapSizeHigh;
			//get result
			DecimalCoordinate ret = new DecimalCoordinate(xval,yval,zval);
			return ret;
		}
		#endregion
		
		public new void Dispose()
		{
			disposed = true;
			ticker.Stop();
			updater.Stop();
			updater.Dispose();
			//printer.Dispose();
			base.Dispose(true);
		}
	}
}
