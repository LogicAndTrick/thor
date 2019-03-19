/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 12/08/2009
 * Time: 7:36 PM
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
	/// Description of BaseSelectTool.
	/// </summary>
	public abstract class BaseSelectTool : BoxTool
	{
		protected bool flowToBase;
		protected bool useGroupSelect;
		
		public BaseSelectTool(Document doc) : base(doc)
		{
			hasMemory = false;
			flowToBase = false;
			useGroupSelect = true;
		}
		
		#region Inputs
		protected override void singleClick(MouseEventArgs e, NewGLMapView2D view)
		{
			if (!Accessor.keyPressed(Keys.ControlKey)) {
				unselectAllObjects();
			}
			DecimalCoordinate actualPos = view.XYtoNative(view.relativeToAbsolute(new DecimalCoordinate(e.X,view.Height-e.Y,0)));
			decimal max = associatedDocument.Data.MapSizeHigh;
			decimal min = associatedDocument.Data.MapSizeLow;
			DecimalCoordinate maxco = new DecimalCoordinate(max,max,max);
			DecimalCoordinate minco = new DecimalCoordinate(min,min,min);
			DecimalCoordinate plus = maxco - view.zeroUnusedDimension(maxco);
			DecimalCoordinate minus = minco - view.zeroUnusedDimension(minco);
			bool done = false;
			foreach (MapObject o in associatedDocument.ObjectCache) {
				if (o.intersectLine2D(actualPos+minus,actualPos+plus,3/view.Zoom)) {
					if (!o.Selected) {
						associatedDocument.SelectedObjects.Add(o);
						o.setSelect(true);
						done = true;
					} else if (associatedDocument.SelectedObjects.Count > 1) {
						associatedDocument.SelectedObjects.Remove(o);
						o.setSelect(false);
						done = true;
					}
					if (done) {
						state = BoxState.Drawn;
						cascadeSelection();
						resetSelectBounds();
						break;
					}
				}
			}
		}
		
		protected override void downKey(KeyEventArgs e, NewGLMapView2D view)
		{
			if (e.KeyCode == Keys.Delete) unselectAllObjects();
			base.downKey(e, view);
		}
		
		protected override void pressKey(KeyPressEventArgs e, NewGLMapView2D view)
		{
			if (e.KeyChar == 13) {
				if (associatedDocument.SelectedObjects.Count > 0) return;
				//if the box has 0 for the width on any one axis, make that value infinite
				//if it's more than one we'd just have a line, and that shouldn't select
				//anything, because it doesn't in Hammer.
				int zerocount = 0;
				int max = associatedDocument.Data.MapSizeHigh;
				int min = associatedDocument.Data.MapSizeLow;
				DecimalCoordinate bll = selectBox.BottomLeftLow.Clone();
				DecimalCoordinate trh = selectBox.TopRightHigh.Clone();
				if (selectBox.X == 0) {
					bll.setX(min);
					trh.setX(max);
					zerocount++;
				}
				if (selectBox.Y == 0) {
					bll.setY(min);
					trh.setY(max);
					zerocount++;
				}
				if (selectBox.Z == 0) {
					bll.setZ(min);
					trh.setZ(max);
					zerocount++;
				}
				if (zerocount > 1) {
					state = BoxState.None;
					return;
				}
				else if (zerocount > 0) selectBox.setBounds(bll,trh);
				associatedDocument.SelectedObjects.Clear();
				associatedDocument.SelectedObjects.AddRange(associatedDocument.Map.Worldspawn.selectTest(selectBox));
				if (associatedDocument.SelectedObjects.Count == 0) state = BoxState.None;
				else {
					cascadeSelection();
					resetSelectBounds();
				}
				fullRefresh = true;
			}
			else {
				base.pressKey(e, view);
			}
		}
		#endregion
		
		#region 3D selection
		private void select3D(MouseEventArgs e, MapView3D view)
		{
			if (e.Button != MouseButtons.Left) return;
			if (!Accessor.keyPressed(Keys.ControlKey)) {
				unselectAllObjects();
			}
			DecimalCoordinate start = view.CameraPosition.Clone();
			DecimalCoordinate end = view.ScreenToWorld(e.X, e.Y, 1);
			MapObject selectHolder = null;
			decimal? distHolder = null;
			foreach (MapObject o in associatedDocument.ObjectCache) {
				if (o.intersectLine3D(start, end)) {
					DecimalCoordinate d = o.getIntersectLine3D(start, end);
					decimal dist = (d - start).vectorMagnitude();
					if (distHolder == null || distHolder > dist) {
						selectHolder = o;
						distHolder = dist;
					}
				}
			}
			if (selectHolder != null) {
				if (!selectHolder.Selected) {
					associatedDocument.SelectedObjects.Add(selectHolder);
					selectHolder.setSelect(true);
				} else if (associatedDocument.SelectedObjects.Count > 1) {
					associatedDocument.SelectedObjects.Remove(selectHolder);
					selectHolder.setSelect(false);
				}
				state = BoxState.Drawn;
			}
			cascadeSelection();
			resetSelectBounds();
			fullRefresh = true;
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
					select3D((e as MouseEventArgs), view);
					break;
				case ActionType.KeyDown:
					KeyEventArgs ke = e as KeyEventArgs;
					if (ke.KeyCode == Keys.Delete) {
						/*foreach (MapObject mo in selectedObjects) {
							associatedDocument.Map.Worldspawn.removeChild(mo);
						}*/
						associatedDocument.removeFromMap(associatedDocument.SelectedObjects);
						associatedDocument.SelectedObjects.Clear();
						state = BoxState.None;
						fullRefresh = true;
					}
					break;
			}
			base.performAction3D(atype, e, view);
		}
		#endregion
		
		#region Actions
		protected override void clickOutside(DecimalCoordinate snapped)
		{
			if (!Accessor.Instance.PressedKeys.Contains(Keys.ControlKey)) base.clickOutside(snapped);
		}
		
		protected override void startMoving()
		{
			if (flowToBase) base.startMoving();
			if (associatedDocument.SelectedObjects.Count > 0) return;
			base.startMoving();
		}
		
		protected override void endMoving()
		{
			if (flowToBase) base.endMoving();
			if (associatedDocument.SelectedObjects.Count > 0) return;
			base.endMoving();
		}
		
		protected override void startResizing(NewGLMapView2D view)
		{
			if (flowToBase) base.startResizing(view);
			if (associatedDocument.SelectedObjects.Count > 0) return;
			base.startResizing(view);
		}
		
		protected override void endResizing()
		{
			if (flowToBase) base.endResizing();
			if (associatedDocument.SelectedObjects.Count > 0) return;
			base.endResizing();
		}
		
		protected override void doMove(MouseEventArgs e, NewGLMapView2D view)
		{
			if (flowToBase) base.doMove(e, view);
			if (associatedDocument.SelectedObjects.Count > 0) return;
			base.doMove(e, view);
		}
		
		protected override void doResize(MouseEventArgs e, NewGLMapView2D view)
		{
			if (flowToBase) base.doResize(e, view);
			if (associatedDocument.SelectedObjects.Count > 0) return;
			base.doResize(e, view);
		}
		#endregion
		
		#region Util
		protected virtual void cascadeSelection()
		{
			associatedDocument.updateCache();
			if (useGroupSelect) {
				foreach (MapObject o in associatedDocument.SelectedObjects) {
					MapObject obj = o;
					while (!(obj.Parent is MapWorld)) {
						obj = obj.Parent;
					}
					obj.setSelect(true);
					obj.selectAllChildren(true);
				}
				associatedDocument.updateCache();
			}
			selectHistory(associatedDocument.SelectedObjects, true);
		}
		
		protected void resetSelectBounds()
		{
			if (associatedDocument.SelectedObjects.Count == 0) return;
			List<BoundingBox> bbarr = new List<BoundingBox>();
			foreach (MapObject o in associatedDocument.SelectedObjects) {
				if (o is MapSolid || (o is MapEntity && o.Children.Count == 0)) bbarr.Add(o.Bbox);
			}
			selectBox.setBounds(bbarr.ToArray());
		}
		
		public virtual void unselectAllObjects()
		{
			selectHistory(associatedDocument.SelectedObjects, false);
			foreach (MapObject o in associatedDocument.SelectedObjects) {
				o.setSelect(false);
			}
			associatedDocument.SelectedObjects.Clear();
			if (state != BoxState.ReadyToDraw) state = BoxState.None;
			resetSelectBounds();
		}
		
		protected override void postActionCleanup()
		{
			if (state == BoxState.None || state == BoxState.Drawing || state == BoxState.ReadyToDraw) {
				if (associatedDocument.SelectedObjects.Count > 0) {
					unselectAllObjects();
					fullRefresh = true;
				}
			}
		}
		
		protected override ResizeHandle checkResizeHit(MouseEventArgs e, NewGLMapView2D view)
		{
			if (flowToBase) return base.checkResizeHit(e, view);
			return ResizeHandle.None;
		}
		
		public override Cursor getCursor2D(ActionType atype, MouseEventArgs e, NewGLMapView2D view)
		{
			if (flowToBase) return base.getCursor2D(atype, e, view);
			if (associatedDocument.SelectedObjects.Count > 0) return Cursors.Default;
			return base.getCursor2D(atype, e, view);
		}
		
		protected void selectHistory(MapObject o, bool select)
		{
			List<MapObject> l = new List<MapObject>();
			l.Add(o);
			selectHistory(l, select);
		}
		
		protected void selectHistory(List<MapObject> list, bool select)
		{
			string s = "Selected ";
			if (!select) s = "Unselected ";
			HistoryTransaction trans = associatedDocument.History.StartTransaction(s + list.Count + " objects");
			trans.Select(list);
			associatedDocument.History.FinishTransaction(trans);
		}
		#endregion
		
		#region Rendering
		protected override Color getBoxRenderColour()
		{
			return Color.Yellow;
		}
		
		protected override void drawResizeHandles(NewGLMapView2D view)
		{
			if (flowToBase) base.drawResizeHandles(view);
		}
		
		public override void render2D(NewGLMapView2D view)
		{
			base.render2D(view);
		}
		
		public override void render3D(MapView3D view)
		{
			base.render3D(view);
		}
		
		public override void renderInactive3D(MapView3D view)
		{
			base.renderInactive3D(view);
		}
		#endregion
	}
}
