/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 12/08/2009
 * Time: 7:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	public enum SelectState
	{
		Resize,
		Rotate,
		Skew
	}
	
	/// <summary>
	/// Description of NewSelectTool.
	/// </summary>
	public class SelectTool : BaseSelectTool
	{
		#region Initialisation
		SelectState selState;
		
		protected DecimalCoordinate startPosition;
		
		protected decimal currentRotation;
		protected decimal currentSkew;
		
		protected DecimalCoordinate origSizes;
		protected DecimalCoordinate origResizePosition;
		protected Orientation2D resizeOrient;
		protected DecimalCoordinate newResizePosition;
		
		public SelectTool(Document doc) : base(doc)
		{
			toolName = "Select";
			flowToBase = true;
			selState = SelectState.Resize;
			startPosition = new DecimalCoordinate(0,0,0);
			currentRotation = 0;
			currentSkew = 0;
		}
		
		public override BaseTool Copy(Document doc)
		{
			return new SelectTool(doc);
		}
		
		public override Image getImage()
		{
			return new Bitmap("selecttoollol.png");
		}
		#endregion
		
		#region Inputs
		protected override void singleClick(MouseEventArgs e, NewGLMapView2D view)
		{
			if ( ( state == BoxState.Drawn || state == BoxState.Moving || state == BoxState.None || state == BoxState.ReadyToDraw )
			    && ( associatedDocument.SelectedObjects.Count == 0 || Accessor.keyPressed(Keys.ControlKey)
			        || ( !selectBox.withinBounds(e.X,view.Height-e.Y,view) && checkResizeHit(e,view) == ResizeHandle.None )
			       )
			   )
			{
				base.singleClick(e, view);
			}
			if (associatedDocument.SelectedObjects.Count == 0) return;
			if ((state == BoxState.Drawn || state == BoxState.Moving) &&
			    	selectBox.withinBounds(e.X,view.Height-e.Y,view)) {
				selState = (SelectState)(((int)selState + 1) % 3);
			}
		}
		
		protected override void downKey(KeyEventArgs e, NewGLMapView2D view)
		{
			if (e.KeyCode == Keys.Delete) {
				associatedDocument.removeFromMap(associatedDocument.SelectedObjects);
				//associatedDocument.SelectedObjects.Clear();
				state = BoxState.None;
				fullRefresh = true;
			}
			else base.downKey(e, view);
		}
		#endregion
		
		#region Actions
		protected override void doResize(MouseEventArgs e, NewGLMapView2D view)
		{
			fullRefresh = true;
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
			fullRefresh = true;
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
		#endregion
		
		#region Transformations
		protected void startTransforming()
		{
			startPosition = selectBox.BottomLeftLow.Clone();
			origSizes = new DecimalCoordinate(selectBox.X, selectBox.Y, selectBox.Z);
			if (moved) {
				foreach (MapObject o in associatedDocument.SelectedObjects) o.Render = false;
				fullRefresh = true;
			}
		}
		
		protected void endTransforming()
		{
			foreach (MapObject o in associatedDocument.SelectedObjects) o.Render = true;
			CoordinateTransformation transform = getTransform();
			if (Accessor.keyPressed(Keys.ShiftKey) && state == BoxState.Moving) {
				List<MapObject> tempList = new List<MapObject>();
				
				List<MapObject> tempSelect = new List<MapObject>();
				tempSelect.AddRange(associatedDocument.SelectedObjects);
				if (useGroupSelect) {
					tempSelect.Clear();
					foreach (MapObject o in associatedDocument.SelectedObjects) {
						MapObject obj = o;
						while (!(obj.Parent is MapWorld)) {
							obj = obj.Parent;
						}
						if (!tempSelect.Contains(obj)) tempSelect.Add(obj);
					}
				}
				
				foreach (MapObject o in tempSelect) {
					if (o is MapWorld) continue;
					if (!useGroupSelect) {
						if ((o is MapGroup) || ((o is MapEntity) && o.Children.Count != 0)) continue;
					}
					tempList.Add(o.copy(transform));
				}
				HistoryTransaction trans = associatedDocument.History.StartTransaction("Cloned " + tempList.Count + " objects");
				trans.Create(tempList);
				associatedDocument.History.FinishTransaction(trans);
				
				associatedDocument.addToMap(tempList);
				unselectAllObjects();
				foreach (MapObject o in tempList) o.setSelect(true);
				cascadeSelection();
				tempList.Clear();
			} else {
				HistoryTransaction trans = associatedDocument.History.StartTransaction("Transformed " + associatedDocument.SelectedObjects.Count + " objects");
				trans.Edit(associatedDocument.SelectedObjects);
				associatedDocument.History.FinishTransaction(trans);
				foreach (MapObject o in associatedDocument.SelectedObjects) o.applyTransformation(transform);
			}
			resetSelectBounds();
			fullRefresh = true;
		}
		
		protected CoordinateTransformation getTransform()
		{
			CoordinateTransformation transform = new CoordinateTransformation();
			if (associatedDocument.SelectedObjects.Count > 0 && moved) {
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
		#endregion
		
		#region Util
		public override void unselectAllObjects()
		{
			foreach (MapObject o in associatedDocument.SelectedObjects) o.Render = true;
			base.unselectAllObjects();
		}
		protected override void postActionCleanup()
		{
			if (state == BoxState.None || state == BoxState.Drawing || state == BoxState.ReadyToDraw) {
				selState = SelectState.Resize;
			}
			base.postActionCleanup();
		}
		
		protected override System.Windows.Forms.Cursor cursorFromHandle(ResizeHandle h)
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
		
		protected override ResizeHandle checkResizeHit(System.Windows.Forms.MouseEventArgs e, NewGLMapView2D view)
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
		
		private DecimalCoordinate orientationToVector(Orientation2D o)
		{
			if (o == Orientation2D.XY) return new DecimalCoordinate(0,0,1);
			else if (o == Orientation2D.YZ) return new DecimalCoordinate(1,0,0);
			else return new DecimalCoordinate(0,-1,0);
		}
		
		public override void render2D(NewGLMapView2D view)
		{
			if (associatedDocument.SelectedObjects.Count > 0 && moved) {
				if (state == BoxState.Moving) {
					Renderer2D.pushMatrix();
					Renderer2D.translate(selectBox.BottomLeftLow - startPosition);
					foreach (MapObject o in associatedDocument.SelectedObjects) Renderer2D.renderMapObject(o);
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
						foreach (MapObject o in associatedDocument.SelectedObjects) Renderer2D.renderMapObject(o);
						Renderer2D.setColour(getBoxRenderColour());
						Renderer2D.renderBox(selectBox);
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
						foreach (MapObject o in associatedDocument.SelectedObjects) Renderer2D.renderMapObject(o);
						Renderer2D.setColour(getBoxRenderColour());
						Renderer2D.renderBox(selectBox);
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
						foreach (MapObject o in associatedDocument.SelectedObjects) Renderer2D.renderMapObject(o);
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
			if (associatedDocument.SelectedObjects.Count == 0) return;
			
			// render lines of original locations
			Renderer3D.disableTextures();
			Renderer3D.switchTo2D();
			Renderer2D.setColour(getBoxRenderColour());
			foreach (MapObject mo in associatedDocument.SelectedObjects) {
				Renderer2D.renderMapObject(mo, true, true);
			}
			Renderer2D.switchTo3D();
			Renderer3D.enableTextures();
			
			//render objects in transformed locations
			if (associatedDocument.SelectedObjects.Count > 0 && moved && (state == BoxState.Resizing || state == BoxState.Moving)) {
				foreach (MapObject o in associatedDocument.SelectedObjects) o.Render = true;
				if (state == BoxState.Moving) {
					Renderer3D.pushMatrix();
					Renderer3D.translate(selectBox.BottomLeftLow - startPosition);
					foreach (MapObject o in associatedDocument.SelectedObjects) Renderer3D.renderMapObject(o);
					Renderer3D.popMatrix();
				}
				else if (state == BoxState.Resizing) {
					if (selState == SelectState.Rotate) {
						DecimalCoordinate origin = startPosition + origSizes / 2;
						Renderer3D.pushMatrix();
						Renderer3D.translate(origin);
						Renderer3D.rotate(currentRotation * 180 / (decimal)Math.PI, orientationToVector(resizeOrient));
						Renderer3D.translate(-origin);
						foreach (MapObject o in associatedDocument.SelectedObjects) Renderer3D.renderMapObject(o);
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
						foreach (MapObject o in associatedDocument.SelectedObjects) Renderer3D.renderMapObject(o);
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
						foreach (MapObject o in associatedDocument.SelectedObjects) Renderer3D.renderMapObject(o);
						Renderer3D.popMatrix();
					}
				}
				foreach (MapObject o in associatedDocument.SelectedObjects) o.Render = false;
				return;
			}
			Renderer3D.setColour(Color.Red);
			foreach (MapObject mo in associatedDocument.SelectedObjects) Renderer3D.renderMapObject(mo, true);
		}
		#endregion
	}
}
