/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 11/03/2009
 * Time: 4:26 PM
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
	/// Description of CameraTool.
	/// </summary>
	public class CameraTool : BaseTool
	{
		protected bool leftclick;
		private bool hiddencursor;
		
		public CameraTool(Document doc) : base(doc)
		{
			leftclick = hiddencursor = false;
			toolName = "Camera";
		}
		
		public override Image getImage()
		{
			return new Bitmap("cameratool.png");
		}
		
		public override BaseTool Copy(Document doc)
		{
			return new CameraTool(doc);
		}
		
		public override bool actionNeeded2D(ActionType atype)
		{
			return false;
		}
		
		public override Cursor getCursor2D(ActionType atype, MouseEventArgs e, NewGLMapView2D view)
		{
			return Cursors.Default;
		}
		
		public override void performAction2D(ActionType atype, EventArgs e, NewGLMapView2D view)
		{
			return;
		}
		
		public override void render2D(NewGLMapView2D view)
		{
			return;
		}
		
		public override bool actionNeeded3D(ActionType atype)
		{
			if (atype == ActionType.KeyPress) return false;
			return true;
		}
		
		public override Cursor getCursor3D(ActionType atype, MouseEventArgs e, MapView3D view)
		{
			return Cursors.Default;
		}
		
		private void showCursor()
		{
			if (hiddencursor) {
				Cursor.Show();
				hiddencursor = false;
			}
		}
		
		private void hideCursor()
		{
			if (!hiddencursor) {
				Cursor.Hide();
				hiddencursor = true;
			}
		}
		
		public override void performAction3D(ActionType atype, EventArgs e, MapView3D view)
		{
			bool rightclick = view.RightClick;
			MouseEventArgs me = e as MouseEventArgs;
			switch (atype) {
				case ActionType.KeyPress:
					break;
				case ActionType.KeyDown:
					break;
				case ActionType.MouseDown:
					if (me.Button == MouseButtons.Left) {
						leftclick = true;
						hideCursor();
					}
					break;
				case ActionType.MouseMove:
					int diffx = Cursor.Position.X - view.MouseX;
		        	int diffy = view.MouseY - Cursor.Position.Y;
		        	if (diffx == 0 && diffy == 0) return;
					if (leftclick && rightclick) {
		    			view.goUp(diffy*3);
		    			view.goSideways(diffx*3);
		        		Cursor.Position = view.PointToScreen(new Point(view.Width/2,view.Height/2));
		    		}
		    		else if (leftclick) {
		    			view.goForward(diffy*3);
		    			view.goSideways(diffx*3);
		        		Cursor.Position = view.PointToScreen(new Point(view.Width/2,view.Height/2));
		    		}
		    		else if (rightclick) {
		        		view.mouseMove(diffx,diffy);
		        		Cursor.Position = view.PointToScreen(new Point(view.Width/2,view.Height/2));
		        	}
					break;
				case ActionType.MouseUp:
					if (me.Button == MouseButtons.Left) {
						leftclick = false;
						showCursor();
					}
					break;
			}
			view.UseDefaultNavigation = false;
		}
		
		public override void render3D(MapView3D view)
		{
			view.viewport2D();
			if (hiddencursor) {
				Renderer3D.switchTo2D();
				Renderer2D.end();
            	GL.LineWidth(2);
            	Renderer2D.begin();
            	Renderer2D.setColour(Color.White);
            	GL.Vertex2(view.Width/2-4,view.Height/2);
            	GL.Vertex2(view.Width/2+4,view.Height/2);
            	GL.Vertex2(view.Width/2,view.Height/2-4);
            	GL.Vertex2(view.Width/2,view.Height/2+4);
            	Renderer2D.switchTo3D();
			}
			view.viewport3D();
		}
	}
}
