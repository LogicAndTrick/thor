/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 14/02/2009
 * Time: 6:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace thor
{
	/// <summary>
	/// Description of SelectTool.
	/// </summary>
	public class OldSelectTool : BoxTool
	{
		#region Initialisation
		
		protected SelectState selState;
		protected List<MapObject> selectedObjects;
		
		protected DecimalCoordinate startPosition;
		
		protected decimal currentRotation;
		protected decimal currentSkew;
		
		protected bool refreshedYet;
		
		protected DecimalCoordinate origSizes;
		protected DecimalCoordinate origResizePosition;
		protected Orientation2D resizeOrient;
		protected DecimalCoordinate newResizePosition;
		
		public OldSelectTool(Document doc) : base(doc)
		{
			toolName = "OldSelect";
			selState = SelectState.Resize;
			selectedObjects = new List<MapObject>();
			hasMemory = false;
			startPosition = new DecimalCoordinate(0,0,0);
			currentRotation = 0;
			currentSkew = 0;
		}
		
		public override BaseTool Copy(Document doc)
		{
			return new OldSelectTool(doc);
		}
		
		public override Image getImage()
		{
			return new Bitmap("selecttoollol.png");
		}
		#endregion
		
		#region Inputs
		protected override void singleClick(System.Windows.Forms.MouseEventArgs e, NewGLMapView2D view)
		{
			if (state == BoxState.Drawn || state == BoxState.ReadyToDraw || state == BoxState.None || state == BoxState.Moving) {
				if (selectedObjects.Count == 0 || Accessor.keyPressed(Keys.ControlKey) || (!selectBox.withinBounds(e.X,view.Height-e.Y,view) && checkResizeHit(e,view) == ResizeHandle.None)) {
					if (state == BoxState.Moving) endMoving();
					DecimalCoordinate actualPos = view.XYtoNative(view.relativeToAbsolute(new DecimalCoordinate(e.X,view.Height-e.Y,0)));
					decimal max = associatedDocument.Data.MapSizeHigh;
					decimal min = associatedDocument.Data.MapSizeLow;
					DecimalCoordinate maxco = new DecimalCoordinate(max,max,max);
					DecimalCoordinate minco = new DecimalCoordinate(min,min,min);
					DecimalCoordinate plus = maxco - view.zeroUnusedDimension(maxco);
					DecimalCoordinate minus = minco - view.zeroUnusedDimension(minco);
					foreach (MapObject o in associatedDocument.ObjectCache) {
						if (o.intersectLine2D(actualPos+minus,actualPos+plus,3/view.Zoom)) {
							if (!o.Selected) {
								selectedObjects.Add(o);
								o.setSelect(true);
							} else if (selectedObjects.Count > 1) {
								selectedObjects.Remove(o);
								o.setSelect(false);
							}
							state = BoxState.Drawn;
							resetSelectBounds();
							break;
						}
					}
					fullRefresh = true;
					return;
				}
			}
			if (selectedObjects.Count == 0) return;
			if ((state == BoxState.Drawn || state  == BoxState.Moving) && selectBox.withinBounds(e.X,view.Height-e.Y,view)) {
				if (selState == SelectState.Resize) selState = SelectState.Rotate;
				else if (selState == SelectState.Rotate) selState = SelectState.Skew;
				else selState = SelectState.Resize;
			}
		}
		
		protected override void pressKey(KeyPressEventArgs e, NewGLMapView2D view)
		{
			if (e.KeyChar == 13) {
				if (selectedObjects.Count > 0) return;
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
				selectedObjects = associatedDocument.Map.Worldspawn.selectTest(selectBox);
				if (selectedObjects.Count == 0) state = BoxState.None;
				else {
					resetSelectBounds();
				}
				fullRefresh = true;
			}
			else {
				base.pressKey(e, view);
			}
		}
		
		protected override void downKey(KeyEventArgs e, NewGLMapView2D view)
		{
			if (e.KeyCode == Keys.Delete) {
				/*foreach (MapObject mo in selectedObjects) {
					associatedDocument.Map.Worldspawn.removeChild(mo);
				}*/
				associatedDocument.removeFromMap(selectedObjects);
				selectedObjects.Clear();
				state = BoxState.None;
				fullRefresh = true;
			}
			else base.downKey(e, view);
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
					selectedObjects.Add(selectHolder);
					selectHolder.setSelect(true);
				} else if (selectedObjects.Count > 1) {
					selectedObjects.Remove(selectHolder);
					selectHolder.setSelect(false);
				}
				state = BoxState.Drawn;
			}
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
						associatedDocument.removeFromMap(selectedObjects);
						selectedObjects.Clear();
						state = BoxState.None;
						fullRefresh = true;
					}
					break;
			}
			base.performAction3D(atype, e, view);
		}
		#endregion
		
		#region Actions
		protected override void doResize(MouseEventArgs e, thor.NewGLMapView2D view)
		{
			if (!refreshedYet) {
				fullRefresh = true;
				refreshedYet = true;
			}
			if (selState == SelectState.Rotate) {
				DecimalCoordinate mouseRel = new DecimalCoordinate(e.X,view.Height-e.Y,0);
				newResizePosition = view.relativeToAbsolute(mouseRel);
				lastSnappedCoordinate = null;
				//--
				DecimalCoordinate origin = startPosition + origSizes / 2;
				DecimalCoordinate originTrans = view.NativeToXY(origin); //A
				//origRotation B
				//newRotation C
				DecimalCoordinate aVect = origResizePosition - originTrans;
				DecimalCoordinate bVect = newResizePosition - originTrans;
				//http://www.euclideanspace.com/maths/algebra/vectors/angleBetween/index.htm
				//If v1 and v2 are normalised:
				//angle = acos(v1 . v2)
				//axis = norm(v1 x v2)
				decimal cos_t = aVect.normalise().dot(bVect.normalise());
				if ((double)cos_t > 1) cos_t = 1;
				if ((double)cos_t < -1) cos_t = -1;
				decimal angle = (decimal)Math.Acos((double)cos_t);
				DecimalCoordinate axis = aVect.normalise().cross(bVect.normalise()).normalise().round(2);
				if (axis.Z < 0) angle = 2 * (decimal)Math.PI - angle;
				//snap to 15 degree increments
				if (Accessor.Instance.PressedKeys.Contains(Keys.ShiftKey)) {
					decimal snapto = 15 * (decimal)Math.PI / 180; //convert to radians
					angle = snapto * (decimal.Floor(angle/snapto));
				}
				currentRotation = angle;
			}
			else if (selState == SelectState.Skew) {
				DecimalCoordinate mouseRel = new DecimalCoordinate(e.X,view.Height-e.Y,0);
				DecimalCoordinate mouseAbs = view.relativeToAbsolute(mouseRel);
				//DecimalCoordinate mouseUts = view.NativeToXY(mouseAbs);
				DecimalCoordinate snapped = view.snapToGrid(mouseAbs);
				newResizePosition = mouseAbs;
				lastSnappedCoordinate = null;
				//--
				DecimalCoordinate diff = snapped - origResizePosition;
				switch (currentHandle) {
					case ResizeHandle.BottomCentre:
					case ResizeHandle.TopCentre:
						currentSkew = diff.X;
						break;
					case ResizeHandle.CentreLeft:
					case ResizeHandle.CentreRight:
						currentSkew = diff.Y;
						break;
				}
			}
			else base.doResize(e, view);
		}
		
		protected override void doMove(MouseEventArgs e, NewGLMapView2D view)
		{
			if (!refreshedYet) {
				fullRefresh = true;
				refreshedYet = true;
			}
			base.doMove(e, view);
		}
		
		protected override void startMoving()
		{
			if (Accessor.keyPressed(Keys.ControlKey)) return;
			startTransforming();
			base.startMoving();
		}
		
		protected override void endMoving()
		{
			endTransforming();
			base.endMoving();
		}
		
		protected override void startResizing(NewGLMapView2D view)
		{
			if (Accessor.keyPressed(Keys.ControlKey)) return;
			origResizePosition = selectBox.getPointArray(view)[(int)currentHandle];
			newResizePosition = origResizePosition.Clone();
			resizeOrient = view.Orientation;
			currentRotation = 0;
			currentSkew = 0;
			startTransforming();
			base.startResizing(view);
		}
		
		protected override void endResizing()
		{
			endTransforming();
			base.endResizing();
		}
		
		protected override void clickOutside(DecimalCoordinate snapped)
		{
			if (!Accessor.Instance.PressedKeys.Contains(Keys.ControlKey)) base.clickOutside(snapped);
		}
		#endregion
		
		#region Transformations
		protected void startTransforming()
		{
			refreshedYet = false;
			startPosition = selectBox.BottomLeftLow.Clone();
			origSizes = new DecimalCoordinate(selectBox.X, selectBox.Y, selectBox.Z);
			if (moved) {
				foreach (MapObject o in selectedObjects) o.Render = false;
				refreshedYet = true;
				fullRefresh = true;
			}
		}
		
		protected void endTransforming()
		{
			foreach (MapObject o in selectedObjects) o.Render = true;
			DecimalCoordinate origin = startPosition + origSizes / 2;
			DecimalCoordinate newSizes = new DecimalCoordinate(selectBox.X, selectBox.Y, selectBox.Z);
			DecimalCoordinate scale = newSizes.componentDivide(origSizes);
			CoordinateTransformation transform = new CoordinateTransformation();
			if (state == BoxState.Moving) {
				transform.AddTranslation(selectBox.BottomLeftLow - startPosition);
			}
			else if (state == BoxState.Resizing) {
				if (selState == SelectState.Rotate) {
					transform.AddRotationPoint(currentRotation,resizeOrient,origin);
				}
				else if (selState == SelectState.Skew) {
					DecimalCoordinate bskew = selectBox.BottomLeftLow.Clone();
					DecimalCoordinate tskew = selectBox.TopRightHigh.Clone();
					if (currentHandle == ResizeHandle.BottomCentre || currentHandle == ResizeHandle.CentreLeft) {
						bskew = selectBox.TopRightHigh.Clone();
						tskew = selectBox.BottomLeftLow.Clone();
					}
					transform.AddSkew(currentSkew,resizeOrient,currentHandle,bskew,tskew);
				}
				else if (selState == SelectState.Resize) {
					transform.AddScale(scale,startPosition);
					transform.AddTranslation(selectBox.BottomLeftLow - startPosition);
				}
			}
			if (Accessor.keyPressed(Keys.ShiftKey) && state == BoxState.Moving) {
				CoordinateTransformation temptrans = new CoordinateTransformation();
				List<MapObject> tempList = new List<MapObject>();
				foreach (MapObject o in selectedObjects) {
					//associatedDocument.Map.Worldspawn.addChild(o.copy(temptrans));
					tempList.Add(o.copy(temptrans));
				}
				associatedDocument.addToMap(tempList);
				tempList.Clear();
			}
			foreach (MapObject o in selectedObjects) o.applyTransformation(transform);
			resetSelectBounds();
			fullRefresh = true;
		}
		#endregion
		
		#region Util
		protected void resetSelectBounds()
		{
			if (selectedObjects.Count == 0) return;
			BoundingBox[] bbarr = new BoundingBox[selectedObjects.Count];
			for (int i = 0; i < selectedObjects.Count; i++) {
				bbarr[i] = selectedObjects[i].Bbox;
			}
			selectBox.setBounds(bbarr);
		}
		
		public void unselectAllObjects()
		{
			foreach (MapObject o in selectedObjects) {
				o.setSelect(false);
			}
			selectedObjects.Clear();
			state = BoxState.None;
			resetSelectBounds();
		}
		
		protected override void postActionCleanup()
		{
			if (state == BoxState.None || state == BoxState.Drawing || state == BoxState.ReadyToDraw) {
				selState = SelectState.Resize;
				if (selectedObjects.Count > 0) {
					unselectAllObjects();
					fullRefresh = true;
				}
			}
		}
		
		protected override Cursor cursorFromHandle(ResizeHandle h)
		{
			if (selState == SelectState.Rotate) {
				switch (h) {
					case ResizeHandle.TopLeft:
					case ResizeHandle.BottomRight:
					case ResizeHandle.TopRight:
					case ResizeHandle.BottomLeft:
						return CustomCursor.FromByteArray(ThorCursors.rotate);
					case ResizeHandle.TopCentre:
					case ResizeHandle.BottomCentre:
					case ResizeHandle.CentreLeft:
					case ResizeHandle.CentreRight:
					case ResizeHandle.None:
						return Cursors.Default;
					default:
						throw new Exception();
				}
			}
			else if (selState == SelectState.Skew) {
				switch (h) {
					case ResizeHandle.TopCentre:
					case ResizeHandle.BottomCentre:
						return Cursors.SizeWE;
					case ResizeHandle.CentreLeft:
					case ResizeHandle.CentreRight:
						return Cursors.SizeNS;
					case ResizeHandle.TopLeft:
					case ResizeHandle.BottomRight:
					case ResizeHandle.TopRight:
					case ResizeHandle.BottomLeft:
					case ResizeHandle.None:
						return Cursors.Default;
					default:
						throw new Exception();
				}
			}
			else return base.cursorFromHandle(h);
		}
		
		protected override ResizeHandle checkResizeHit(MouseEventArgs e, NewGLMapView2D view)
		{
			DecimalCoordinate hit = new DecimalCoordinate(e.X,view.Height-e.Y,0);
			DecimalCoordinate m = new DecimalCoordinate(-resizeSize,-resizeSize,0);
			DecimalCoordinate p = new DecimalCoordinate(resizeSize,resizeSize,0);
			if (selState == SelectState.Rotate) {
				DecimalCoordinate[] corners = selectBox.getPointArray(view);
				int[] points = new int[] {
					(int)ResizeHandle.TopRight,
					(int)ResizeHandle.TopLeft,
					(int)ResizeHandle.BottomRight,
					(int)ResizeHandle.BottomLeft,
				};
				for (int i = 0; i < points.Length; i++) {
					DecimalCoordinate point = view.absoluteToRelative(corners[points[i]]) + resizeOffsets[points[i]];
					DecimalCoordinate pm = point+m;
					DecimalCoordinate pp = point+p;
					if (hit.X < pp.X && hit.X > pm.X && hit.Y > pm.Y && hit.Y < pp.Y) return (ResizeHandle)points[i];
				}
				return ResizeHandle.None;
			}
			else if (selState == SelectState.Skew) {
				DecimalCoordinate[] corners = selectBox.getPointArray(view);
				int[] points = new int[] {
					(int)ResizeHandle.CentreLeft,
					(int)ResizeHandle.CentreRight,
					(int)ResizeHandle.BottomCentre,
					(int)ResizeHandle.TopCentre,
				};
				for (int i = 0; i < points.Length; i++) {
					DecimalCoordinate point = view.absoluteToRelative(corners[points[i]]) + resizeOffsets[points[i]];
					DecimalCoordinate pm = point+m;
					DecimalCoordinate pp = point+p;
					if (hit.X < pp.X && hit.X > pm.X && hit.Y > pm.Y && hit.Y < pp.Y) return (ResizeHandle)points[i];
				}
				return ResizeHandle.None;
			}
			else return base.checkResizeHit(e,view);
		}
		#endregion
		
		#region Rendering
		protected override Color getBoxRenderColour()
		{
			return Color.Yellow;
		}
		
		protected override void drawResizeHandles(NewGLMapView2D view)
		{
			//TODO
			if (selState == SelectState.Rotate) {
				DecimalCoordinate[] corners = selectBox.getPointArray(view);
				int[] points = new int[] {
					(int)ResizeHandle.TopRight,
					(int)ResizeHandle.TopLeft,
					(int)ResizeHandle.BottomRight,
					(int)ResizeHandle.BottomLeft
				};
				Renderer2D.setColour(Color.White);
				for (int i = 0; i < points.Length; i++) {
					Renderer2D.setPolygonMode();
					DecimalCoordinate point = view.XYtoNative(corners[points[i]]) + view.XYtoNative(resizeOffsets[points[i]]) / view.Zoom;
					Renderer2D.renderCircle(point, resizeSize / view.Zoom, view, true);
				}
				Renderer2D.setLineMode();
				Renderer2D.setColour(Color.Black);
				for (int i = 0; i < points.Length; i++) {
					DecimalCoordinate point = view.XYtoNative(corners[points[i]]) + view.XYtoNative(resizeOffsets[points[i]]) / view.Zoom;
					Renderer2D.renderCircle(point, resizeSize / view.Zoom, view, false);
				}
			}
			else if (selState == SelectState.Skew) {
				DecimalCoordinate[] corners = selectBox.getPointArray(view);
				DecimalCoordinate m = view.XYtoNative(new DecimalCoordinate(-resizeSize,-resizeSize,0)) / view.Zoom;
				DecimalCoordinate p = view.XYtoNative(new DecimalCoordinate(resizeSize,resizeSize,0)) / view.Zoom;
				int[] points = new int[] {
					(int)ResizeHandle.CentreLeft,
					(int)ResizeHandle.CentreRight,
					(int)ResizeHandle.BottomCentre,
					(int)ResizeHandle.TopCentre,
				};
				Renderer2D.setQuadMode();
				Renderer2D.setColour(Color.White);
				for (int i = 0; i < points.Length; i++) {
					DecimalCoordinate point = view.XYtoNative(corners[points[i]]) + view.XYtoNative(resizeOffsets[points[i]]) / view.Zoom;
					Renderer2D.renderRectangle(point+m, point+p, view, true);
				}
				Renderer2D.setLineMode();
				Renderer2D.setColour(Color.Black);
				for (int i = 0; i < points.Length; i++) {
					DecimalCoordinate point = view.XYtoNative(corners[points[i]]) + view.XYtoNative(resizeOffsets[points[i]]) / view.Zoom;
					Renderer2D.renderRectangle(point+m, point+p, view, false);
				}
			}
			else base.drawResizeHandles(view);
		}
		
		private CoordinateTransformation getTransform()
		{
			CoordinateTransformation transform = new CoordinateTransformation();
			if (selectedObjects.Count > 0 && moved) {
				if (state == BoxState.Moving) {
					transform.AddTranslation(selectBox.BottomLeftLow - startPosition);
				}
				else if (state == BoxState.Resizing) {
					if (selState == SelectState.Rotate) {
						DecimalCoordinate origin = startPosition + origSizes / 2;
						transform.AddRotationPoint(currentRotation,resizeOrient,origin);
					}
					else if (selState == SelectState.Skew) {
						DecimalCoordinate bskew = selectBox.BottomLeftLow.Clone();
						DecimalCoordinate tskew = selectBox.TopRightHigh.Clone();
						if (currentHandle == ResizeHandle.BottomCentre || currentHandle == ResizeHandle.CentreLeft) {
							bskew = selectBox.TopRightHigh.Clone();
							tskew = selectBox.BottomLeftLow.Clone();
						}
						transform.AddSkew(currentSkew,resizeOrient,currentHandle,bskew,tskew);
					}
					else if (selState == SelectState.Resize) {
						DecimalCoordinate newSizes = new DecimalCoordinate(selectBox.X, selectBox.Y, selectBox.Z);
						DecimalCoordinate scale = newSizes.componentDivide(origSizes);
						transform.AddScale(scale,startPosition);
						transform.AddTranslation(selectBox.BottomLeftLow - startPosition);
					}
				}
			}
			return transform;
		}
		
		private DecimalCoordinate orientationToVector(Orientation2D o)
		{
			if (o == Orientation2D.XY) return new DecimalCoordinate(0,0,1);
			else if (o == Orientation2D.YZ) return new DecimalCoordinate(1,0,0);
			else return new DecimalCoordinate(0,-1,0);
		}
		
		private void renderFlatBox(NewGLMapView2D view)
		{
			Color c = getBoxRenderColour();
			Renderer2D.setColour(c);
			DecimalCoordinate w = view.NativeToXY(origSizes);
			DecimalCoordinate p1 = view.NativeToXY(startPosition);
			DecimalCoordinate p3 = new DecimalCoordinate(p1.X + w.X, p1.Y + w.Y, 0);
			Renderer2D.renderRectangle(view.XYtoNative(p1), view.XYtoNative(p3), view, false);
		}
		
		public override void render2D(NewGLMapView2D view)
		{
			if (selectedObjects.Count > 0 && moved) {
				if (state == BoxState.Moving) {
					Renderer2D.pushMatrix();
					Renderer2D.translate(selectBox.BottomLeftLow - startPosition);
					foreach (MapObject o in selectedObjects) Renderer2D.renderMapObject(o);
					Renderer2D.popMatrix();
					base.render2D(view);
					return;
				}
				else if (state == BoxState.Resizing) {
					if (selState == SelectState.Rotate) {
						DecimalCoordinate origin = startPosition + origSizes / 2;
						Renderer2D.pushMatrix();
						Renderer2D.translate(origin);
						Renderer2D.rotate(currentRotation * 180 / (decimal)Math.PI, orientationToVector(resizeOrient));
						Renderer2D.translate(-origin);
						foreach (MapObject o in selectedObjects) Renderer2D.renderMapObject(o);
						renderFlatBox(view);
						Renderer2D.popMatrix();
						return;
					}
					else if (selState == SelectState.Skew) {
						DecimalCoordinate origin = startPosition;
						DecimalCoordinate transSizes = view.NativeToXY(origSizes);
						decimal skewAmountX = currentSkew / Math.Abs(transSizes.Y);
						decimal skewAmountY = currentSkew / Math.Abs(transSizes.X);
						if (currentHandle == ResizeHandle.CentreLeft || currentHandle == ResizeHandle.BottomCentre) {
							origin = startPosition + origSizes;
							skewAmountY *= -1;
							if (currentHandle == ResizeHandle.BottomCentre) skewAmountX *= -1;
						}
						if (currentHandle == ResizeHandle.CentreLeft || currentHandle == ResizeHandle.CentreRight) skewAmountX = 0;
						else skewAmountY = 0;
						Renderer2D.pushMatrix();
						Renderer2D.translate(origin);
						Renderer2D.skew(skewAmountX, skewAmountY, resizeOrient);
						Renderer2D.translate(-origin);
						foreach (MapObject o in selectedObjects) Renderer2D.renderMapObject(o);
						renderFlatBox(view);
						Renderer2D.popMatrix();
						return;
					}
					else if (selState == SelectState.Resize) {
						DecimalCoordinate newSizes = new DecimalCoordinate(selectBox.X, selectBox.Y, selectBox.Z);
						DecimalCoordinate scale = newSizes.componentDivide(origSizes);
						DecimalCoordinate scaledStart = startPosition.componentMultiply(scale);
						Renderer2D.pushMatrix();
						Renderer2D.translate(selectBox.BottomLeftLow - startPosition);
						Renderer2D.translate(-(scaledStart - startPosition));
						Renderer2D.scale(scale);
						foreach (MapObject o in selectedObjects) Renderer2D.renderMapObject(o);
						Renderer2D.popMatrix();
						base.render2D(view);
						return;
					}
				}
			}
			base.render2D(view);
		}
		
		public override void render3D(MapView3D view)
		{
			if (selectedObjects.Count == 0) return;
			Renderer3D.disableTextures();
			Renderer3D.switchTo2D();
			Renderer2D.setColour(getBoxRenderColour());
			foreach (MapObject mo in selectedObjects) Renderer2D.renderMapObject(mo, true, true);
			Renderer2D.switchTo3D();
			Renderer3D.enableTextures();
			if (selectedObjects.Count > 0 && moved && (state == BoxState.Resizing || state == BoxState.Moving)) {
				foreach (MapObject o in selectedObjects) o.Render = true;
				if (state == BoxState.Moving) {
					Renderer3D.pushMatrix();
					Renderer3D.translate(selectBox.BottomLeftLow - startPosition);
					foreach (MapObject o in selectedObjects) Renderer3D.renderMapObject(o);
					Renderer3D.popMatrix();
				}
				else if (state == BoxState.Resizing) {
					if (selState == SelectState.Rotate) {
						DecimalCoordinate origin = startPosition + origSizes / 2;
						Renderer3D.pushMatrix();
						Renderer3D.translate(origin);
						Renderer3D.rotate(currentRotation * 180 / (decimal)Math.PI, orientationToVector(resizeOrient));
						Renderer3D.translate(-origin);
						foreach (MapObject o in selectedObjects) Renderer3D.renderMapObject(o);
						Renderer3D.popMatrix();
					}
					else if (selState == SelectState.Skew) {
						DecimalCoordinate origin = startPosition;
						decimal skewAmountX = 0;
						decimal skewAmountY = 0;
						if (resizeOrient == Orientation2D.XY) {
							skewAmountX = currentSkew / Math.Abs(origSizes.Y);
							skewAmountY = currentSkew / Math.Abs(origSizes.X);
						} else if (resizeOrient == Orientation2D.XZ) {
							skewAmountX = currentSkew / Math.Abs(origSizes.Z);
							skewAmountY = currentSkew / Math.Abs(origSizes.X);
						} else if (resizeOrient == Orientation2D.YZ) {
							skewAmountX = currentSkew / Math.Abs(origSizes.Z);
							skewAmountY = currentSkew / Math.Abs(origSizes.Y);
						}
						if (currentHandle == ResizeHandle.CentreLeft || currentHandle == ResizeHandle.BottomCentre) {
							origin = startPosition + origSizes;
							skewAmountY *= -1;
							if (currentHandle == ResizeHandle.BottomCentre) skewAmountX *= -1;
						}
						if (currentHandle == ResizeHandle.CentreLeft || currentHandle == ResizeHandle.CentreRight) skewAmountX = 0;
						else skewAmountY = 0;
						Renderer3D.pushMatrix();
						Renderer3D.translate(origin);
						Renderer3D.skew(skewAmountX, skewAmountY, resizeOrient);
						Renderer3D.translate(-origin);
						foreach (MapObject o in selectedObjects) Renderer3D.renderMapObject(o);
						Renderer3D.popMatrix();
					}
					else if (selState == SelectState.Resize) {
						DecimalCoordinate newSizes = new DecimalCoordinate(selectBox.X, selectBox.Y, selectBox.Z);
						DecimalCoordinate scale = newSizes.componentDivide(origSizes);
						DecimalCoordinate scaledStart = startPosition.componentMultiply(scale);
						Renderer3D.pushMatrix();
						Renderer3D.translate(selectBox.BottomLeftLow - startPosition);
						Renderer3D.translate(-(scaledStart - startPosition));
						Renderer3D.scale(scale);
						foreach (MapObject o in selectedObjects) Renderer3D.renderMapObject(o);
						Renderer3D.popMatrix();
					}
				}
				foreach (MapObject o in selectedObjects) o.Render = false;
				return;
			}
			Renderer3D.setColourWithAlpha(Color.FromArgb(128, Color.Red));
			foreach (MapObject mo in selectedObjects) Renderer3D.renderMapObject(mo, true);
		}
		
		public override void renderInactive3D(MapView3D view)
		{
			if (selectedObjects.Count == 0) return;
			Renderer3D.switchTo2D();
			Renderer2D.setColour(getBoxRenderColour());
			foreach (MapObject mo in selectedObjects) Renderer2D.renderMapObject(mo, true);
			Renderer2D.switchTo3D();
			Renderer3D.setColourWithAlpha(Color.FromArgb(128, Color.Red));
			foreach (MapObject mo in selectedObjects) Renderer3D.renderMapObject(mo, true);
		}
		#endregion
	}
}
