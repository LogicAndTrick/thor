/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 7/08/2009
 * Time: 5:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	public delegate void TextureModeChangedEventHandler(object sender, TextureModeChangeEventArgs e);
	public delegate void TexturePropertyChangedEventHandler(object sender, TexturePropertyChangeEventArgs e); 
	public delegate void TextureChangedEventHandler(object sender, TextureChangeEventArgs e);
	public delegate void TextureHideMaskToggledEventHandler(object sender, bool hide);
	public delegate void TextureJustifyEventHandler(object sender, TextureJustifyEventArgs e);
	public delegate void TextureApplyEventHandler(object sender, TextureObject texture);
	public delegate void TextureAlignEventHandler(object sender, TextureAlignMode align);

	/// <summary>
	/// Description of TextureToolForm.
	/// </summary>
	public partial class TextureToolForm : HotkeyEnabledForm
	{
		public event TexturePropertyChangedEventHandler PropertyChanged;
		public event TextureChangedEventHandler TextureChanged;
		public event TextureModeChangedEventHandler TextureModeChanged;
		public event TextureHideMaskToggledEventHandler HideMaskToggled;
		public event TextureJustifyEventHandler TextureJustify;
		public event TextureApplyEventHandler TextureApply;
		public event TextureAlignEventHandler TextureAlign;
		
		protected virtual void OnTextureAlign(TextureAlignMode align)
		{
			if (TextureAlign != null) {
				TextureAlign(this, align);
			}
		}
		
		protected virtual void OnTextureApply(TextureObject texture)
		{
			if (TextureApply != null) {
				TextureApply(this, texture);
			}
		}
		
		protected virtual void OnTextureJustify(TextureJustifyEventArgs e)
		{
			if (TextureJustify != null) {
				TextureJustify(this, e);
			}
		}
		
		protected virtual void OnHideMaskToggled(bool hide)
		{
			if (HideMaskToggled != null) {
				HideMaskToggled(this, hide);
			}
		}
		
		protected virtual void OnTextureModeChanged(TextureModeChangeEventArgs e)
		{
			if (TextureModeChanged != null) {
				TextureModeChanged(this, e);
			}
		}
		
		protected virtual void OnPropertyChanged(TexturePropertyChangeEventArgs e)
		{
			if (PropertyChanged != null) {
				PropertyChanged(this, e);
			}
		}
		
		protected virtual void OnTextureChanged(TextureChangeEventArgs e)
		{
			if (TextureChanged != null) {
				TextureChanged(this, e);
			}
		}
		
		bool updating;
		decimal scalexlast;
		decimal scaleylast;
		
		public TextureTool associatedTool;
		
		public TextureToolForm(TextureTool tool)
		{
			associatedTool = tool;
			updating = true;
			InitializeComponent();
			updating = false;
			cmbLeftClick.SelectedIndex = cmbRightClick.SelectedIndex = 0;
		}
		
		public void update(List<MapFace> faces)
		{
			updating = true;
			
			nudScaleX.BackColor = Color.White;
			nudScaleY.BackColor = Color.White;
			nudShiftX.BackColor = Color.White;
			nudShiftY.BackColor = Color.White;
			
			lblDetails.Text = "";
			tgSelected.ThumbSize = TextureThumbnailSize.Thumb64;
			
			List<TextureObject> textures = new List<TextureObject>();
			bool first = true;
			foreach (MapFace f in faces) {
				/*bool contained = false;
				foreach (TextureObject o in textures) {
					if (o.ShortName == f.TextureResource.ShortName) contained = true;
				}
				if (!contained) textures.Add(f.TextureResource);*/
				
				if (f.TextureResource != null && !textures.Contains(f.TextureResource)) {
					textures.Add(f.TextureResource);
				}
				
				if (first || nudScaleX.Value == f.Uscale) nudScaleX.Value = f.Uscale;
				else nudScaleX.BackColor = Color.LightGray;
				
				if (first || nudScaleY.Value == f.Vscale) nudScaleY.Value = f.Vscale;
				else nudScaleY.BackColor = Color.LightGray;
				
				if (first || nudShiftX.Value == f.Uaxis.D) nudShiftX.Value = f.Uaxis.D;
				else nudShiftX.BackColor = Color.LightGray;
				
				if (first || nudShiftY.Value == f.Vaxis.D) nudShiftY.Value = f.Vaxis.D;
				else nudShiftY.BackColor = Color.LightGray;
				
				if (first || nudRotation.Value == f.Rotation) nudRotation.Value = f.Rotation;
				else nudRotation.BackColor = Color.LightGray;
				
				first = false;
			}
			
			tgSelected.clearPackages();
			tgSelected.addTextures(textures);
			
			textures.Clear();
			
			updating = false;
		}
		
		public void setSelected(TextureObject o)
		{
			
			if (o != null && !tgSelected.Textures.Contains(o)) {
				List<TextureObject> l = new List<TextureObject>();
				l.Add(o);
				tgSelected.addTextures(l);
			}
			tgSelected.SelectedTexture = o;
			
			if (tgSelected.Textures.Count == 1) {
				tgSelected.ThumbSize = TextureThumbnailSize.Thumb128;
			}
			
			if (tgSelected.SelectedTexture != null) {
				lblDetails.Text = tgSelected.SelectedTexture.ShortName + " " +
					tgSelected.SelectedTexture.Width + " x " +
					tgSelected.SelectedTexture.Height;
			}
		}
		
		void changeProperties(object sender, EventArgs e)
		{
			if (updating) return;
			
			updating = true;
			if (nudScaleX.Value == 0) {
				nudScaleX.Value -= scalexlast;
			} else if (nudScaleY.Value == 0) {
				nudScaleY.Value -= scaleylast;
			}
			scalexlast = nudScaleX.Value;
			scaleylast = nudScaleY.Value;
			updating = false;
			
			TexturePropertyChangeEventArgs args = new TexturePropertyChangeEventArgs();
			args.ScaleX = nudScaleX.Value;
			args.ScaleY = nudScaleY.Value;
			args.ShiftX = (int)Math.Round(nudShiftX.Value);
			args.ShiftY = (int)Math.Round(nudShiftY.Value);
			args.Rotation = nudRotation.Value;
			args.LightmapScale = (int)Math.Round(nudLightmap.Value);
			OnPropertyChanged(args);
		}
		
		void NudScaleXValueChanged(object sender, EventArgs e)
		{
			nudScaleX.BackColor = Color.White;
			changeProperties(sender, e);
		}
		
		void NudScaleYValueChanged(object sender, EventArgs e)
		{
			nudScaleY.BackColor = Color.White;
			changeProperties(sender, e);
		}
		
		void NudShiftXValueChanged(object sender, EventArgs e)
		{
			nudShiftX.BackColor = Color.White;
			changeProperties(sender, e);
		}
		
		void NudShiftYValueChanged(object sender, EventArgs e)
		{
			nudShiftY.BackColor = Color.White;
			changeProperties(sender, e);
		}
		
		void NudRotationValueChanged(object sender, EventArgs e)
		{
			nudRotation.BackColor = Color.White;
			changeProperties(sender, e);
		}
		
		void NudLightmapValueChanged(object sender, EventArgs e)
		{
			
		}
		
		void ModeChanged(object sender, EventArgs e)
		{
			TextureModeChangeEventArgs args = new TextureModeChangeEventArgs();
			args.Left = (TextureModeLeftClick)cmbLeftClick.SelectedIndex;
			args.Right = (TextureModeRightClick)cmbRightClick.SelectedIndex;
			OnTextureModeChanged(args);
		}
		
		void TgSelectedSelectedTextureChanged(object sender, EventArgs e)
		{
			tgRecent.SelectedTexture = null;
			if (tgSelected.SelectedTexture == null) return;
			List<TextureObject> rts = associatedTool.AssociatedDocument.RecentTextures;
			if (rts.Contains(tgSelected.SelectedTexture)) rts.Remove(tgSelected.SelectedTexture);
			rts.Insert(0, tgSelected.SelectedTexture);
			tgRecent.clearPackages();
			tgRecent.addTextures(rts);
			TextureChangeEventArgs args = new TextureChangeEventArgs();
			args.Texture = tgSelected.SelectedTexture;
			OnTextureChanged(args);
		}
		
		void TgRecentSelectedTextureChanged(object sender, EventArgs e)
		{
			tgSelected.SelectedTexture = null;
			if (tgRecent.SelectedTexture == null) return;
			List<TextureObject> rts = associatedTool.AssociatedDocument.RecentTextures;
			if (rts.Contains(tgRecent.SelectedTexture)) rts.Remove(tgRecent.SelectedTexture);
			rts.Insert(0, tgRecent.SelectedTexture);
			tgRecent.clearPackages();
			tgRecent.addTextures(rts);
			TextureChangeEventArgs args = new TextureChangeEventArgs();
			args.Texture = tgRecent.SelectedTexture;
			OnTextureChanged(args);
		}
		
		void TxtRecentFilterTextChanged(object sender, EventArgs e)
		{
			tgRecent.Filter = txtRecentFilter.Text;
		}
		
		void JustifyClick(object sender, EventArgs e)
		{
			string md = ((Control)sender).Name.Replace("btnJustify", "");
			try {
				TextureJustifyMode mode = (TextureJustifyMode)Enum.Parse(typeof(TextureJustifyMode), md);
				TextureJustifyEventArgs args = new TextureJustifyEventArgs();
				args.Mode = mode;
				args.TreatAsOne = chkTreatAsOne.Checked;
				OnTextureJustify(args);
			} catch (ArgumentException) {
				//This shouldn't happen unless someone's been messing with the form naming
				MessageBox.Show("Someone messed with the form naming!");
			}
		}
		
		void ChkHideMaskCheckedChanged(object sender, EventArgs e)
		{
			OnHideMaskToggled(chkHideMask.Checked);
		}
		
		void BtnApplyClick(object sender, EventArgs e)
		{
			TextureObject sel = tgSelected.SelectedTexture;
			if (sel == null) sel = tgRecent.SelectedTexture;
			
			if (sel != null) OnTextureApply(sel);
		}
		
		void BtnBrowseClick(object sender, EventArgs e)
		{
			TextureObject tex = associatedTool.AssociatedDocument.showTextureBrowser();
			if (tex != null) {
				setSelected(tex);
			}
		}
		
		void BtnAlignWorldClick(object sender, EventArgs e)
		{
			OnTextureAlign(TextureAlignMode.World);
		}
		
		void BtnAlignFaceClick(object sender, EventArgs e)
		{
			OnTextureAlign(TextureAlignMode.Face);
		}
	}
}
