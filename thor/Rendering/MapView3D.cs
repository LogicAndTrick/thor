/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 17/01/2009
 * Time: 1:20 PM
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
	/// Description of MapView3D.
	/// </summary>
	public class MapView3D : GLControl, IDisposable
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
		protected decimal rotation;
		protected decimal elevation;
		protected DecimalCoordinate cameraPosition;
		protected int mouseX;
		protected int mouseY;
		protected bool rightClick;
		protected bool hiddenCursor;
		protected bool useDefaultNavigation;
		protected decimal clipDistance;
		
		protected bool noMouseUpdate;
		
		public DecimalCoordinate CameraPosition {
			get { return cameraPosition; }
		}
		
		public int MouseX {
			get { return mouseX; }
			set { mouseX = value; }
		}
		
		public int MouseY {
			get { return mouseY; }
			set { mouseY = value; }
		}
		
		public bool RightClick {
			get { return rightClick; }
		}
		
		public bool UseDefaultNavigation {
			get { return useDefaultNavigation; }
			set { useDefaultNavigation = value; }
		}
		
		//TODO: FPS display
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
		
		// Colours
		protected Color voidColour;
		
		// Calculations and junk
		double[] modelView;
		double[] projectionView;
		int[] viewport;
		
		bool disposed;
		
		public MapView3D(Document doc)
		{
			disposed = false;
			
			modelView = new double[16];
			projectionView = new double[16];
			viewport = new int[4];
			
			associatedDocument = doc;
			voidColour = Color.Black;
			clipDistance = 50000;
			rightClick = false;
			hiddenCursor = false;
			useDefaultNavigation = true;
			forceUpdate = true;
			noMouseUpdate = false;
			objectCache = new List<MapObject>();
			//printer = new TextPrinter();
			//--------------------------
			initCamera();
			initGL();
			initTimers();
		}
		
		protected override void OnHandleDestroyed(EventArgs e)
		{
			Log.LogMessage("Destroyed");
			base.OnHandleDestroyed(e);
		}
		
		public void initCamera()
		{
			cameraPosition = new DecimalCoordinate(0,0,0);
			rotation = 270;
			elevation = 90;
		}
		
		protected void initGL()
		{
			GL.ShadeModel(ShadingModel.Smooth);		//turns smooth shading on
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);	//nice-looking perspective stuff
            GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);	//line AA
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);	//tells OGL what blending
            GL.Enable(EnableCap.Blend);				//turns on blending stuff				//method to use
            GL.ClearDepth(1.0);	
            GL.ClearColor(voidColour);				//set the background colour
            GL.Enable(EnableCap.DepthTest);			//enables depth testing (which face is in front/behind)
            GL.DepthFunc(DepthFunction.Lequal);		//face is behind if it is less than or equal
            GL.CullFace(CullFaceMode.Front);		//culls the back of each face
            GL.Enable(EnableCap.CullFace);			//turns on back culling
		}
		
		private void initTimers()
		{
			lastTicks = 0;
			ticker = new Stopwatch();
			
			updater = new Timer();
			updater.Interval = 25;
			updater.Tick += new EventHandler(onUpdateTick);
			
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
			if (e.KeyCode == Keys.Z && !e.Control && !e.Alt && !e.Shift) {
				rightClick = !rightClick;
				if (rightClick) hideCursor();
				else showCursor();
			}
			associatedDocument.SelectedTool.performAction3D(ActionType.KeyDown,e,this);
			base.OnKeyDown(e);
		}
		
		protected override void OnMouseMove(MouseEventArgs e)
		{
			Focus();
			
			this.Cursor = associatedDocument.SelectedTool.getCursor3D(ActionType.MouseMove, e, this);
			
        	useDefaultNavigation = true;
        	if (associatedDocument.SelectedTool.actionNeeded3D(ActionType.MouseMove)) {
        		associatedDocument.SelectedTool.performAction3D(ActionType.MouseMove, e, this);
        	}
        	if (useDefaultNavigation && !noMouseUpdate) {
				int diffx = Cursor.Position.X - mouseX;
	        	int diffy = mouseY - Cursor.Position.Y;
	        	if (diffx == 0 && diffy == 0) return;
        		if (rightClick) {
	        		this.mouseMove(diffx,diffy);
	        		Cursor.Position = PointToScreen(new Point(Width/2,Height/2));
        		}
        	}
        	mouseX = Cursor.Position.X;
        	mouseY = Cursor.Position.Y;
			base.OnMouseMove(e);
		}
		
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			goForward((decimal)(e.Delta));
			base.OnMouseWheel(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.Cursor = associatedDocument.SelectedTool.getCursor3D(ActionType.MouseUp, e, this);
        	associatedDocument.SelectedTool.performAction3D(ActionType.MouseUp, e, this);
			base.OnMouseUp(e);
		}
		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.Cursor = associatedDocument.SelectedTool.getCursor3D(ActionType.MouseDown, e, this);
        	associatedDocument.SelectedTool.performAction3D(ActionType.MouseDown, e, this);
			base.OnMouseDown(e);
		}

		
		protected override void OnResize(EventArgs e)
		{
			SetupViewport();
			base.OnResize(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			isFocused = false;
			base.OnMouseLeave(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			isFocused = true;
			base.OnMouseEnter(e);
		}
		
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			associatedDocument.SelectedTool.performAction3D(ActionType.KeyPress, e, this);
			base.OnKeyPress(e);
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			forceUpdate = true;
			base.OnPaint(e);
		}
		#endregion
		
		#region Rendering
		protected void onUpdateTick(object sender, EventArgs e)
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
					Log.LogMessage("Context error 3D");
					return;
				}
				MakeCurrent();
			}
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			GL.LoadIdentity();
			handleInput();
			render();
			SwapBuffers();
			//forceUpdate = false;
        }
		
		protected void render()
		{
			drawCamera();
			updateMatrices();
			drawOrientationLines();
			
            GL.Enable(EnableCap.Texture2D);			//enable textures
			drawObjects();
			drawTools();
            GL.Disable(EnableCap.Texture2D);		//disable textures
            
			draw2D();
			GL.Flush();
		}
		
		protected void drawCamera()
		{
			float xrot = (float)cameraPosition.X + (float)(Math.Cos((double)(360.0m - rotation)*Math.PI/180)*Math.Sin((double)(180.0m - elevation)*Math.PI/180));
			float yrot = (float)cameraPosition.Y + (float)(Math.Sin((double)(360.0m - rotation)*Math.PI/180)*Math.Sin((double)(180.0m - elevation)*Math.PI/180));
			float zrot = (float)cameraPosition.Z + (float)(Math.Cos((double)(180.0m - elevation)*Math.PI/180));
			Matrix4d lookat = Matrix4d.LookAt((double)cameraPosition.X,(double)cameraPosition.Y,(double)cameraPosition.Z,
			           xrot,yrot,zrot,
			           0.0,0.0,1.0);
			GL.MultMatrix(ref lookat);
			/*OpenTK Graphics.Glu.LookAt((double)cameraPosition.X,(double)cameraPosition.Y,(double)cameraPosition.Z,
			           xrot,yrot,zrot,
			           0.0,0.0,1.0);*/
		}
		
		protected void updateMatrices()
		{
			GL.GetDouble(GetPName.ModelviewMatrix, modelView);
			GL.GetDouble(GetPName.ProjectionMatrix, projectionView);
			GL.GetInteger(GetPName.Viewport, viewport);
		}
		
		protected void drawOrientationLines()
		{
			GL.LineWidth(1.0f);
			GL.Begin(BeginMode.Lines);
			GL.Color3(1.0,0.0,0.0);
			GL.Vertex3(0.0,0.0,0.0);
			GL.Vertex3(100.0,0.0,0.0);
			GL.Color3(0.0,1.0,0.0);
			GL.Vertex3(0.0,0.0,0.0);
			GL.Vertex3(0.0,100.0,0.0);
			GL.Color3(0.0,0.0,1.0);
			GL.Vertex3(0.0,0.0,0.0);
			GL.Vertex3(0.0,0.0,100.0);
			GL.End();
		}
		
		protected void drawObjects()
		{
			//objectCache = associatedDocument.Map.Worldspawn.getAllChildren();
			GL.Begin(BeginMode.Triangles);
			//associatedDocument.Map.Worldspawn.draw3D(this);
			foreach (MapObject o in associatedDocument.ObjectCache) { //objectCache) {
				Renderer3D.renderMapObject(o);
			}
			GL.End();
		}
		
		protected void drawTools()
		{
			GL.Begin(BeginMode.Triangles);
			foreach (BaseTool t in associatedDocument.Tools) {
				if (t != associatedDocument.SelectedTool) t.renderInactive3D(this);
			}
			associatedDocument.SelectedTool.render3D(this);
			GL.End();
		}
		
		protected void draw2D()
		{
			viewport2D();
			if (hiddenCursor) {
            	GL.LineWidth(2);
            	GL.Begin(BeginMode.Lines);
            	GL.Color3(Color.White);
            	GL.Vertex2(Width/2-4,Height/2);
            	GL.Vertex2(Width/2+4,Height/2);
            	GL.Vertex2(Width/2,Height/2-4);
            	GL.Vertex2(Width/2,Height/2+4);
            	GL.End();
            	GL.LineWidth(1);
			}
			
			GL.Begin(BeginMode.Lines);
			associatedDocument.SelectedTool.renderOverlay3D(this);
			GL.End();
			
			//TODO: Text
			/*renders++;
			decimal ticks = ticker.ElapsedMilliseconds - lastTicks;
			if (ticks >= 50) {
				lastTicks = ticker.ElapsedMilliseconds;
				fps = renders / ticks * 1000;
				renders = 0;
			}
			font = new Font(FontFamily.GenericSansSerif, 16, GraphicsUnit.Pixel);
			GL.Color3(Color.White);
			GL.Disable(EnableCap.DepthTest);
			printer.Begin();
			//GL.MatrixMode(MatrixMode.Projection);
			//GL.LoadIdentity();
			//GL.Ortho(0, Width, 0, Height, -1, 1);
			//GL.MatrixMode(MatrixMode.Modelview);
			//GL.LoadIdentity();
			//GL.Rotate(10, 1, 0, 0);
			GL.Translate(10, 10, 0);
			printer.Print("test" + fps.ToString("0.0"), font, Color.White);
			printer.End();
			GL.Enable(EnableCap.DepthTest);
			font.Dispose();*/
			viewport3D();
		}
		#endregion
		
		#region Screen/World
		/// <summary>
		/// Project 2D coordinates to a very large distance away
		/// from the camera, and in the direction the camera is looking,
		/// corresponding to the x and y values given. Can be used as an endpoint
		/// for a line (starting at the camera location).
		/// </summary>
		/// <param name="x">The X screen coordinate</param>
		/// <param name="y">The Y screen coordinate</param>
		/// <param name="z">The Z screen coordinage (should usually be 1)</param>
		/// <returns>A coordinate with a large magnitude that is on the projected line</returns>
		public DecimalCoordinate ScreenToWorld(int x, int y, int z)
		{
			double[] projectionMatrix = new double[16];
	        double[] modelViewMatrix = new double[16];
	        int[] viewport = new int[4];
	        
			//GL.MatrixMode(MatrixMode.Projection);
			//GL.LoadMatrix(projectionMatrix);
			GL.GetDouble(GetPName.ProjectionMatrix, projectionMatrix);
			
			//GL.MatrixMode(MatrixMode.Modelview);
			//GL.LoadMatrix(modelViewMatrix);
			GL.GetDouble(GetPName.ModelviewMatrix, modelViewMatrix);
			
			GL.GetInteger(GetPName.Viewport, viewport);
			
			/*object boxedZ = (float)0.0;
			GL.ReadPixels(x, Height - y, 1, 1, PixelFormat.DepthComponent, PixelType.Float,boxedZ);
			float z = (float)boxedZ;*/
			
			Vector3 result;
			OpenTK.Graphics.Glu.UnProject(new Vector3(x, Height-y, z), modelViewMatrix, projectionMatrix, viewport, out result);
			DecimalCoordinate ret = new DecimalCoordinate((decimal)result.X, (decimal)result.Y, (decimal)result.Z);
			//this is if the eye is at 0,0,0 and pointed at 270,0
			//we want to rotate up by our elevation value,
			//and then rotate around to the appropriate rotation value.
			CoordinateTransformation transform = new CoordinateTransformation();
			DecimalCoordinate rotate = new DecimalCoordinate(elevation,0,270-rotation);
			rotate *= (decimal)Math.PI/180; //convert to radians
			transform.AddRotationOrigin(rotate);
			//finally, we want to translate everything to the camera position
			transform.AddTranslation(cameraPosition);
			ret = transform.Operate(ret);
			return ret;
		}
		
		public DecimalCoordinate WorldToScreen(DecimalCoordinate world)
		{
			/* 
			 * Using this so I can gluProject without having to worry about the
			 * glGetDouble calls not being allowed between glBegin and glEnd.
			 * 
			 * http://www.opengl.org/wiki/GluProject_and_gluUnProject_code
			 * 
			 * "The code here comes from glh library (OpenGL Helper Library),
			 * 	which is for Windows, LGPL license"
			 * 	http://www.geocities.com/vmelkon/glhlibrary.html
			 */
			
			double xval = world.DX;
			double yval = world.DY;
			double zval = world.DZ;
			DecimalCoordinate output = new DecimalCoordinate(0, 0, 0);
			
			double[] transform = new double[8];
			transform[0] = modelView[0] * xval + modelView[4] * yval+modelView[8]  * zval + modelView[12];
			transform[1] = modelView[1] * xval + modelView[5] * yval+modelView[9]  * zval + modelView[13];
			transform[2] = modelView[2] * xval + modelView[6] * yval+modelView[10] * zval + modelView[14];
			transform[3] = modelView[3] * xval + modelView[7] * yval+modelView[11] * zval + modelView[15];
			transform[4] = projectionView[0] * transform[0] + projectionView[4] * transform[1] + projectionView[8]  * transform[2] + projectionView[12] * transform[3];
			transform[5] = projectionView[1] * transform[0] + projectionView[5] * transform[1] + projectionView[9]  * transform[2] + projectionView[13] * transform[3];
			transform[6] = projectionView[2] * transform[0] + projectionView[6] * transform[1] + projectionView[10] * transform[2] + projectionView[14] * transform[3];
			transform[7] = -transform[2];
			
			if (transform[7] == 0.0) throw new DivideByZeroException();
			transform[7] = 1.0/transform[7];
			
			transform[4] *= transform[7];
			transform[5] *= transform[7];
			transform[6] *= transform[7];
			
			output.X = (decimal)((transform[4] * 0.5 + 0.5) * viewport[2] + viewport[0]);
			output.Y = (decimal)((transform[5] * 0.5 + 0.5) * viewport[3] + viewport[1]);
			output.Z = 0; //(decimal)((1.0 + transform[6]) * 0.5);

			return output;
		}
		#endregion
		
		#region Cursor
		protected void hideCursor()
		{
			if (!hiddenCursor) {
				hiddenCursor = true;
				Cursor.Hide();
			}
		}
		
		protected void showCursor()
		{
			if (hiddenCursor) {
				hiddenCursor = false;
				Cursor.Show();
			}
		}
		#endregion
		
		#region OpenGL Viewport
		public void viewport3D()
		{
			int w = this.Width;
			int h = this.Height;
			GL.Viewport(0, 0, w, h);				//makes the viewport the same size as the control
            double ratio = w / (double)h;
            GL.MatrixMode(MatrixMode.Projection);	//move into the projection mode, to mess with
            GL.LoadIdentity();						//view stuff
            double far = (double)clipDistance;
            OpenTK.Graphics.Glu.Perspective(60.0, ratio, 0.1, far);	//create the FOV, etc.
   
            GL.MatrixMode(MatrixMode.Modelview);	//move back into the model view mode
            GL.LoadIdentity();
		}
		
		public void viewport2D()
		{
			int w = this.Width;
			int h = this.Height;
			GL.Viewport(0, 0, w, h);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
		}
		
		protected void SetupViewport()
		{
			if (disposed) return;
			if (Context == null) return;
			if (!Context.IsCurrent) {
				Context.MakeCurrent(null);
				MakeCurrent();
			}
			viewport3D();
		}
		#endregion
		
		#region Input Control
		public void mouseMove(int movex, int movey)
		{
			rotation += movex/2.0m;
			if (rotation < 0) rotation += 360;
			rotation = rotation % 360;
			elevation += movey/2.0m;
			if (elevation < 0.01m) elevation = 0.01m;
			if (elevation > 179.9m) elevation = 179.9m;
		}
		
		public void goForward(decimal dist)
		{
			//go forward in the direction of the lookat vector
			decimal xrot = (decimal)(Math.Cos((double)(360.0m - rotation)*Math.PI/180)*Math.Sin((double)(180.0m - elevation)*Math.PI/180));
			decimal yrot = (decimal)(Math.Sin((double)(360.0m - rotation)*Math.PI/180)*Math.Sin((double)(180.0m - elevation)*Math.PI/180));
			decimal zrot = (decimal)(Math.Cos((double)(180.0m - elevation)*Math.PI/180));
			DecimalCoordinate c = new DecimalCoordinate(xrot,yrot,zrot);
			c = (c / c.vectorMagnitude()) * dist;
			/*xpos += c.getX();
			ypos += c.getY();
			zpos += c.getZ();*/
			cameraPosition += c;
		}
		
		public void goSideways(decimal dist)
		{
			decimal trot = rotation;
			decimal posneg = 1.0m;
			trot += 90*posneg;
			if (trot < 0) trot += 360;
			trot = trot % 360;
			decimal xrot = (decimal)Math.Cos((double)(360.0m - trot)*Math.PI/180);
			decimal yrot = (decimal)Math.Sin((double)(360.0m - trot)*Math.PI/180);
			DecimalCoordinate c = new DecimalCoordinate(xrot,yrot,0);
			c = (c / c.vectorMagnitude()) * dist;
			/*xpos += c.getX();
			ypos += c.getY();*/
			cameraPosition += c;
		}
		
		public void goUp(decimal dist)
		{
			decimal telv = elevation;
			decimal trot = rotation;
			telv += 90;
			if (telv > 180) {
				telv = 180 - (telv - 180);
				trot += 180;
				if (trot < 0) trot += 360;
				trot = trot % 360;
			}
			decimal xrot = (decimal)(Math.Cos((double)(360.0m - trot)*Math.PI/180)*Math.Sin((double)(180.0m - telv)*Math.PI/180));
			decimal yrot = (decimal)(Math.Sin((double)(360.0m - trot)*Math.PI/180)*Math.Sin((double)(180.0m - telv)*Math.PI/180));
			decimal zrot = (decimal)(Math.Cos((double)(180.0m - telv)*Math.PI/180));
			DecimalCoordinate c = new DecimalCoordinate(xrot,yrot,zrot);
			c = (c / c.vectorMagnitude()) * dist;
			cameraPosition += c;
		}
		
		protected void handleInput()
		{
			decimal travelspeed = 20.0m;
			if (Accessor.keyPressed(Keys.ShiftKey)) travelspeed *= 3;
        	if (Accessor.keyPressed(Keys.D)) this.goSideways(travelspeed);
        	if (Accessor.keyPressed(Keys.A)) this.goSideways(-travelspeed);
        	if (Accessor.keyPressed(Keys.W)) this.goForward(travelspeed);
        	if (Accessor.keyPressed(Keys.S)) this.goForward(-travelspeed);
        	if (Accessor.keyPressed(Keys.R)) this.initCamera();
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
