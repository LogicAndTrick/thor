/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 27/02/2009
 * Time: 8:12 PM
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
	/// Description of EntityTool.
	/// </summary>
	public class EntityTool : BaseTool
	{
		DecimalCoordinate location;
		EntityDrawingMode drawMode;
		
		decimal boxRadius;
		
		public enum EntityDrawingMode
		{
			None,
			Drawn,
			Moving
		}
		
		public EntityTool(Document doc) : base(doc)
		{
			toolName = "Entity";
			location = new DecimalCoordinate(0,0,0);
			drawMode = EntityDrawingMode.None;
			boxRadius = 5;
		}
		
		public override Image getImage()
		{
			return new Bitmap("entitytool.png");
		}
		
		public override BaseTool Copy(Document doc)
		{
			return new EntityTool(doc);
		}
		
		public override bool actionNeeded2D(ActionType atype)
		{
			switch (atype) {
				case ActionType.MouseDown:
					return true;
				case ActionType.MouseUp:
					return true;
				case ActionType.MouseMove:
					if (drawMode == EntityDrawingMode.Moving) return true;
					return false;
				case ActionType.KeyPress:
					return true;
				case ActionType.KeyDown:
					return true;
			}
			return true;
		}
		
		public override Cursor getCursor2D(ActionType atype, MouseEventArgs e, NewGLMapView2D view)
		{
			switch (drawMode) {
				case EntityDrawingMode.None:
					return Cursors.Default;
				case EntityDrawingMode.Drawn:
					DecimalCoordinate mouseRel = new DecimalCoordinate(e.X,view.Height-e.Y,0);
					DecimalCoordinate locatRel = view.absoluteToRelative(view.XYtoNative(location));
					if (mouseRel.X < locatRel.X + boxRadius &&
					    mouseRel.X > locatRel.X - boxRadius &&
					    mouseRel.Y < locatRel.Y + boxRadius &&
					    mouseRel.Y > locatRel.Y - boxRadius) return Cursors.Cross;
					return Cursors.Default;
				case EntityDrawingMode.Moving:
					return Cursors.Cross;
			}
			return Cursors.Default;
		}
		
		public override void performAction2D(ActionType atype, EventArgs e, NewGLMapView2D view)
		{
			MouseEventArgs me = (e as MouseEventArgs);
			KeyPressEventArgs kpe = (e as KeyPressEventArgs);
			DecimalCoordinate snapped;
			switch (atype) {
				case ActionType.MouseDown:
					snapped = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(new DecimalCoordinate(me.X,view.Height-me.Y,0))));
					drawMode = EntityDrawingMode.Moving;
					location = location - view.zeroUnusedDimension(location) + snapped;
					associatedDocument.refreshAllViews();
					break;
				case ActionType.MouseUp:
					drawMode = EntityDrawingMode.Drawn;
					break;
				case ActionType.MouseMove:
					if (drawMode == EntityDrawingMode.Moving) {
						snapped = view.snapToGrid(view.XYtoNative(view.relativeToAbsolute(new DecimalCoordinate(me.X,view.Height-me.Y,0))));
						location = location - view.zeroUnusedDimension(location) + snapped;
						associatedDocument.refreshAllViews();
					}
					break;
				case ActionType.KeyPress:
					pressKey(kpe, view);
					break;
				case ActionType.KeyDown:
					break;
			}
		}
		
		private void placeEntityAt(DecimalCoordinate c)
		{
			string entName = Accessor.Instance.Main.ObjectTools.getSelectedString();
			GameDataObject ent = associatedDocument.Data.getClass(entName, GameDataClassTypes.Point);
			if (ent != null) {
				MapEntity mapEnt = new MapEntity();
				mapEnt.EntityData = ent;
				foreach (GameDataProperty o in ent.Properties) {
					if (o.DefaultValue != "") {
						MapProperty p = new MapProperty();
						p.Key = o.Name;
						p.Value = o.DefaultValue;
						mapEnt.Data.addProperty(p);
					}
				}
				mapEnt.Data.Name = entName;
				mapEnt.Origin = c.Clone();
				
				HistoryTransaction trans = associatedDocument.History.StartTransaction("Create " + entName + " entity");
				trans.Create(mapEnt);
				associatedDocument.addToMap(mapEnt);
				associatedDocument.History.FinishTransaction(trans);
				
				
				drawMode = EntityDrawingMode.None;
				associatedDocument.refreshAllViews();
			}
		}
		
		private void pressKey(KeyPressEventArgs e, NewGLMapView2D view)
		{
			if (e.KeyChar == 13) {
				if (drawMode != EntityDrawingMode.None) {
					placeEntityAt(location);
				}
			}
		}
		
		public override void render2D(NewGLMapView2D view)
		{
			if (drawMode == EntityDrawingMode.None) return;
			DecimalCoordinate off = new DecimalCoordinate(boxRadius, boxRadius, boxRadius) / view.Zoom;
			Color col = Color.FromArgb(255,29,255,74);
			Renderer2D.setColour(col);
			Renderer2D.renderBox(location - off, location + off);
			decimal min = associatedDocument.Data.MapSizeLow;
			decimal max = associatedDocument.Data.MapSizeHigh;
			Renderer2D.renderLineStrip(new DecimalCoordinate(min, location.Y, location.Z),
			                           new DecimalCoordinate(max, location.Y, location.Z));
			Renderer2D.renderLineStrip(new DecimalCoordinate(location.X, min, location.Z),
			                           new DecimalCoordinate(location.X, max, location.Z));
			Renderer2D.renderLineStrip(new DecimalCoordinate(location.X, location.Y, min),
			                           new DecimalCoordinate(location.X, location.Y, max));
		}
		
		public override bool actionNeeded3D(ActionType atype)
		{
			return (atype == ActionType.MouseDown);
		}
		
		public override Cursor getCursor3D(ActionType atype, MouseEventArgs e, MapView3D view)
		{
			return Cursors.Default;
		}
		
		public override void performAction3D(ActionType atype, EventArgs e, MapView3D view)
		{
			if (atype != ActionType.MouseDown) return;
			MouseEventArgs me = e as MouseEventArgs;
			if (me.Button != MouseButtons.Left) return;
			DecimalCoordinate start = view.CameraPosition.Clone();
			DecimalCoordinate end = view.ScreenToWorld(me.X, me.Y, 1);
			DecimalCoordinate intersectHolder = null;
			decimal? distHolder = null;
			foreach (MapObject o in associatedDocument.ObjectCache) {
				if (o.intersectLine3D(start, end)) {
					DecimalCoordinate d = o.getIntersectLine3D(start, end);
					decimal dist = (d - start).vectorMagnitude();
					if (distHolder == null || distHolder > dist) {
						intersectHolder = d;
						distHolder = dist;
					}
				}
			}
			if (intersectHolder != null) {
				placeEntityAt(intersectHolder);
			}
		}
		
		public override void render3D(MapView3D view)
		{
			if (drawMode == EntityDrawingMode.None) return;
			int rad = 8;
			DecimalCoordinate off = new DecimalCoordinate(rad, rad, rad);
			Color col = Color.FromArgb(255,29,255,74);
			Renderer3D.setColour(col);
			Renderer3D.renderBox(location - off, location + off);
			decimal min = associatedDocument.Data.MapSizeLow;
			decimal max = associatedDocument.Data.MapSizeHigh;
			Renderer3D.switchTo2D();
			Renderer2D.renderLineStrip(new DecimalCoordinate(min, location.Y, location.Z),
			                           new DecimalCoordinate(max, location.Y, location.Z));
			Renderer2D.renderLineStrip(new DecimalCoordinate(location.X, min, location.Z),
			                           new DecimalCoordinate(location.X, max, location.Z));
			Renderer2D.renderLineStrip(new DecimalCoordinate(location.X, location.Y, min),
			                           new DecimalCoordinate(location.X, location.Y, max));
			Renderer2D.switchTo3D();
		}
		
		public override void selected(bool isSelect)
		{
			DockObject o = Accessor.Instance.Main.ObjectTools;
			if (isSelect) {
				List<string> entList = new List<string>();
				foreach (GameDataObject gd in associatedDocument.Data.getClasses(GameDataClassTypes.Point)) {
					entList.Add(gd.Name);
				}
				o.setList(entList);
				o.enableList(false);
				o.setSelected(associatedDocument.GameConfig.PointEntity);
			} else {
				o.clearList();
				o.disableList();
			}
			base.selected(isSelect);
		}
	}
}
