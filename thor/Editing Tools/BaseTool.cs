/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 12/02/2009
 * Time: 3:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace thor
{

	/// <summary>
	/// Description of BaseTool.
	/// </summary>
	public abstract class BaseTool
	{
		protected Document associatedDocument;
		protected string toolName;
		protected Form toolWindow;
		
		public string ToolName {
			get { return toolName; }
			set { toolName = value; }
		}
		
		public Document AssociatedDocument {
			get { return associatedDocument; }
			set { associatedDocument = value; }
		}
		
		public BaseTool(Document doc)
		{
			associatedDocument = doc;
			toolName = "Base";
		}
		
		public abstract System.Drawing.Image getImage();
		public abstract BaseTool Copy(Document doc);
		
		public abstract Cursor getCursor2D(ActionType atype, MouseEventArgs e, NewGLMapView2D view);
		public abstract Cursor getCursor3D(ActionType atype, MouseEventArgs e, MapView3D view);
		
		public abstract bool actionNeeded2D(ActionType atype);
		public abstract bool actionNeeded3D(ActionType atype);
		
		public abstract void performAction2D(ActionType atype, EventArgs e, NewGLMapView2D view);
		public abstract void performAction3D(ActionType atype, EventArgs e, MapView3D view);
		
		public abstract void render2D(NewGLMapView2D view);
		public abstract void render3D(MapView3D view);
		
		public virtual void renderInactive2D(NewGLMapView2D view) { }
		public virtual void renderInactive3D(MapView3D view) { }
		
		public virtual void renderOverlay3D(MapView3D view) { }
		
		public virtual void selected(bool isSelect)
		{
			if (isSelect) {
				if (toolWindow != null) toolWindow.Show(Accessor.Instance.Main);
			} else {
				if (toolWindow != null) toolWindow.Hide();
			}
		}
	}
}
