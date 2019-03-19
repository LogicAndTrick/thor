/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 7/08/2009
 * Time: 5:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	public enum TextureModeLeftClick {
		LiftSelect,
		Lift,
		Select
	}
	
	public enum TextureModeRightClick {
		Apply,
		ApplyAll
	}
	
	public enum TextureJustifyMode {
		Fit,
		Left,
		Right,
		Center,
		Top,
		Bottom
	}
	
	public enum TextureAlignMode {
		Face,
		World
	}
	/// <summary>
	/// Description of TextureTool.
	/// </summary>
	public class TextureTool : BaseTool
	{
		List<MapFace> selectedFaces;
		
		TextureModeLeftClick leftMode;
		TextureModeRightClick rightMode;
		
		TextureObject selectedTexture;
		MapFace lastSelectedFace;
		
		bool hideMask;
		
		public TextureTool(Document doc) : base(doc)
		{
			toolName = "Texture";
			leftMode = TextureModeLeftClick.LiftSelect;
			rightMode = TextureModeRightClick.Apply;
			selectedFaces = new List<MapFace>();
			toolWindow = new TextureToolForm(this);
			((TextureToolForm)toolWindow).PropertyChanged += new TexturePropertyChangedEventHandler(TextureTool_PropertyChanged);
			((TextureToolForm)toolWindow).TextureChanged += new TextureChangedEventHandler(TextureTool_TextureChanged);
			((TextureToolForm)toolWindow).TextureModeChanged += new TextureModeChangedEventHandler(TextureTool_TextureModeChanged);
			((TextureToolForm)toolWindow).HideMaskToggled += new TextureHideMaskToggledEventHandler(TextureTool_HideMaskToggled);
			((TextureToolForm)toolWindow).TextureApply += new TextureApplyEventHandler(TextureTool_TextureApply);
			((TextureToolForm)toolWindow).TextureAlign += new TextureAlignEventHandler(TextureTool_TextureAlign);
		}

		void TextureTool_TextureAlign(object sender, TextureAlignMode align)
		{
			foreach (MapFace f in selectedFaces) {
				switch (align) {
					case TextureAlignMode.Face:
						f.alignToFace();
						break;
					case TextureAlignMode.World:
						f.alignToWorld();
						break;
				}
				f.Rotation = 0;
			}
			updateForm();
			associatedDocument.refresh3DView();
		}

		void TextureTool_TextureApply(object sender, TextureObject texture)
		{
			if (texture == null) return;
			foreach (MapFace f in selectedFaces) {
				if (f.TextureResource != null) f.TextureResource.removeReference();
				texture.addReference();
				
				f.Texture = texture.ShortName;
				f.TextureResource = texture;
				f.calculateTextureCoordinates();
			}
			associatedDocument.refresh3DView();
		}

		void TextureTool_HideMaskToggled(object sender, bool hide)
		{
			hideMask = hide;
			foreach (MapFace f in selectedFaces) {
				f.DrawSelected = !hide;
			}
			associatedDocument.refresh3DView();
		}

		void TextureTool_TextureModeChanged(object sender, TextureModeChangeEventArgs e)
		{
			leftMode = e.Left;
			rightMode = e.Right;
		}

		void TextureTool_TextureChanged(object sender, TextureChangeEventArgs e)
		{
			selectedTexture = e.Texture;
		}

		void TextureTool_PropertyChanged(object sender, TexturePropertyChangeEventArgs e)
		{
			foreach (MapFace f in selectedFaces) {
				f.Uscale = e.ScaleX;
				f.Vscale = e.ScaleY;
				f.Uaxis.D = e.ShiftX;
				f.Vaxis.D = e.ShiftY;
				decimal diff = f.Rotation - e.Rotation;
				f.Rotation = e.Rotation;
				f.rotateTexture(diff); //has the added bonus of calculating the coordinates again
			}
			associatedDocument.refresh3DView();
		}
		
		#region Unused
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
			// do nothing
		}
		
		public override void render2D(NewGLMapView2D view)
		{
			// do nothing
		}
		#endregion
		
		#region Basics
		public override BaseTool Copy(Document doc)
		{
			return new TextureTool(doc);
		}
		
		public override Image getImage()
		{
			return new Bitmap("texturetool.png");
		}
		#endregion
		
		#region Util
		private void unselectAllFaces()
		{
			foreach (MapFace f in selectedFaces) {
				f.Selected = false;
				f.DrawSelected = false;
			}
			selectedFaces.Clear();
		}
		
		private void updateForm()
		{
			((TextureToolForm)toolWindow).update(selectedFaces);
			((TextureToolForm)toolWindow).setSelected(selectedTexture);
		}
		#endregion
		
		#region Actions
		private void keyDown(KeyEventArgs e, MapView3D view)
		{
			if (e.KeyCode == Keys.Escape) {
				
			}
		}
		
		private void mouseDown(MouseEventArgs e, MapView3D view)
		{
			if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) return;
			
			DecimalCoordinate start = view.CameraPosition.Clone();
			DecimalCoordinate end = view.ScreenToWorld(e.X, e.Y, 1);
			MapFace selectHolder = null;
			decimal? distHolder = null;
			DecimalCoordinate d;
			foreach (MapObject o in associatedDocument.ObjectCache) {
				if (o is MapSolid) {
					MapSolid s = o as MapSolid;
					foreach (MapFace f in s.Faces) {
						if (f.intersectLine(start, end, out d)) {
							decimal dist = (d - start).vectorMagnitude();
							if (distHolder == null || distHolder > dist) {
								selectHolder = f;
								distHolder = dist;
							}
						}
					}
				}
			}
			if (e.Button == MouseButtons.Left) leftClick(e, view, selectHolder);
			else if (e.Button == MouseButtons.Right) rightClick(e, view, selectHolder);
		}
		
		#region Left and Right Clicking
		private void leftClick(MouseEventArgs e, MapView3D view, MapFace selectHolder)
		{
			bool ctrl = Accessor.Instance.Control;
			bool shift = Accessor.Instance.Shift;
			
			if (!ctrl) {
				unselectAllFaces();
			}
			
			if (selectHolder != null) {
				List<MapFace> allFaces = new List<MapFace>();
				List<MapFace> otherFaces = new List<MapFace>();
				
				if (shift) {
					foreach (MapFace f in selectHolder.Parent.Faces) {
						if (!f.Selected) allFaces.Add(f);
						else otherFaces.Add(f);
					}
				} else {
					if (!selectHolder.Selected || selectedFaces.Count == 1) allFaces.Add(selectHolder);
					else otherFaces.Add(selectHolder);
				}
				
				if (leftMode == TextureModeLeftClick.Lift) {
					
					if (selectHolder.TextureResource != null)
						selectedTexture = selectHolder.TextureResource;
					
				} else if (leftMode == TextureModeLeftClick.Select || leftMode == TextureModeLeftClick.LiftSelect) {
					
					foreach (MapFace f in allFaces) {
						f.Selected = true;
						f.DrawSelected = !hideMask;
						if (!selectedFaces.Contains(f)) selectedFaces.Add(f);
						lastSelectedFace = f;
					}
					
					foreach (MapFace f in otherFaces) {
						f.Selected = false;
						f.DrawSelected = false;
						if (selectedFaces.Contains(f)) selectedFaces.Remove(f);
					}
					
				}
				if (leftMode == TextureModeLeftClick.LiftSelect) {
					
					foreach (MapFace f in allFaces) {
						if (f.TextureResource != null) {
							selectedTexture = f.TextureResource;
							break;
						}
					}
					
				}
			}
			updateForm();
		}
		
		private void rightClick(MouseEventArgs e, MapView3D view, MapFace selectHolder)
		{
			if (selectedTexture == null) return;
			
			bool alt = Accessor.Instance.Alt;
			bool shift = Accessor.Instance.Shift;
			
			// false, false use default
			// false, true 	apply to whole brush
			// true, false 	use alignment
			// true, true, 	apply to whole brush with alignment
			
			List<MapFace> allFaces = new List<MapFace>();
			if (shift) {
				foreach (MapFace f in selectHolder.Parent.Faces) {
					allFaces.Add(f);
				}
			} else {
				allFaces.Add(selectHolder);
			}
			
			foreach (MapFace f in allFaces) {
				//apply texture
				if (f.TextureResource != null) f.TextureResource.removeReference();
				selectedTexture.addReference();
				
				f.TextureResource = selectedTexture;
				f.Texture = selectedTexture.ShortName;
			
				if (lastSelectedFace != null && (alt || rightMode == TextureModeRightClick.ApplyAll)) {
					if (alt) {
						f.AlignTo(lastSelectedFace);
					} else {
						f.copyTextureSettings(lastSelectedFace);
					}
				}
				
				f.calculateTextureCoordinates();
			}
			
			associatedDocument.refresh3DView();
		}
		#endregion
		#endregion
		
		#region Virtual Overrides
		public override void selected(bool isSelect)
		{
			unselectAllFaces();
			if (isSelect) {
				foreach (MapObject o in associatedDocument.SelectedObjects) {
					if (o is MapSolid) {
						MapSolid s = o as MapSolid;
						foreach (MapFace f in s.Faces) {
							selectedFaces.Add(f);
						}
					}
				}
				associatedDocument.unselectAllObjects();
				foreach (MapFace f in selectedFaces) {
					f.Selected = true;
					f.DrawSelected = !hideMask;
				}
			}
			updateForm();
			base.selected(isSelect);
		}
		#endregion
		
		#region 3D Overrides
		public override bool actionNeeded3D(ActionType atype)
		{
			switch(atype) {
				case ActionType.KeyDown:
					return true;
				case ActionType.KeyPress:
					return false;
				case ActionType.MouseDown:
					return true;
				case ActionType.MouseMove:
					return false;
				case ActionType.MouseUp:
					return false;
				default:
					return false;
			}
		}
		
		public override Cursor getCursor3D(ActionType atype, MouseEventArgs e, MapView3D view)
		{
			return Cursors.Default;
		}
		
		public override void performAction3D(ActionType atype, EventArgs e, MapView3D view)
		{
			switch(atype) {
				case ActionType.KeyDown:
					keyDown(e as KeyEventArgs, view);
					break;
				case ActionType.KeyPress:
					return;
				case ActionType.MouseDown:
					mouseDown(e as MouseEventArgs, view);
					break;
				case ActionType.MouseMove:
					return;
				case ActionType.MouseUp:
					return;
			}
		}
		
		public override void render3D(MapView3D view)
		{
			// render the u and v axes of each selected face
			Renderer3D.disableDepthTesting();
			foreach (MapFace f in selectedFaces) {
				Renderer3D.disableTextures();
				Renderer3D.switchTo2D();
				Renderer2D.setLineWidth(1);
				DecimalCoordinate justOffSurface = f.Center - f.Plane.getNormal().normalise() * 0.5m;
				DecimalCoordinate upoint = justOffSurface + f.Uaxis.getCoordinate().normalise() * 20;
				DecimalCoordinate vpoint = justOffSurface + f.Vaxis.getCoordinate().normalise() * 20;
				Renderer2D.setColour(Color.Yellow);
				Renderer2D.renderLineStrip(justOffSurface, upoint);
				Renderer2D.setColour(Color.LightGreen);
				Renderer2D.renderLineStrip(justOffSurface, vpoint);
				Renderer2D.switchTo3D();
				Renderer3D.enableTextures();
			}
			Renderer3D.enableDepthTesting();
		}
		#endregion
	}
}
