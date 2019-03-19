/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 1/08/2009
 * Time: 4:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace thor
{
	[DefaultValue(TextureThumbnailSize.Thumb128)]
	public enum TextureThumbnailSize {
		Thumb64,
		Thumb128,
		Thumb256,
		Thumb512
	}
	
	public delegate void SelectedTextureChangedEventHandler(object sender, EventArgs e);
	/// <summary>
	/// Description of TextureGridControl.
	/// </summary>
	public class TextureGridControl : UserControl
	{
		public event SelectedTextureChangedEventHandler SelectedTextureChanged;
		
		protected virtual void OnSelectedTextureChanged()
		{
			if (SelectedTextureChanged != null) {
				if (selectedTexture != null) {
					SelectedTextureChanged(this, new EventArgs());
				}
			}
		}
		
		List<TexturePackage> packages;
		List<TextureObject> textures;
		List<TextureObject> filteredTextures;
		string filter;
		int textureSize;
		int padding;
		int fontHeight;
		int smallHeight;
		float lastScrollPercentage;
		int lastIndex;
		PrivateFontCollection fontCollection;
		Font nameFont;
		Font smallFont;
		TextureObject selectedTexture;
		TextureThumbnailSize thumbSize;
		bool drawSizes;
		bool sortTextures;
		
		[DefaultValue(true)]
		public bool SortTextures {
			get { return sortTextures; }
			set { sortTextures = value; }
		}
		
		[DefaultValue(false)]
		public bool DrawSizes {
			get { return drawSizes; }
			set { drawSizes = value; }
		}
		
		public TextureThumbnailSize ThumbSize {
			get { return thumbSize; }
			set { setThumbSize(value); }
		}
		
		[Browsable(false)]
		public List<TextureObject> Textures {
			get { return textures; }
		}
		
		[DefaultValue("")]
		public string Filter {
			get { return filter; }
			set { setFilter(value); }
		}
		
		[Browsable(false)]
		public TextureObject SelectedTexture {
			get { return selectedTexture; }
			set {
				selectedTexture = value;
				OnSelectedTextureChanged();
				updateValues();
				Refresh();
			}
		}
		
		private void setThumbSize(TextureThumbnailSize size)
		{
			switch (size) {
				case TextureThumbnailSize.Thumb64:
					textureSize = 64;
					break;
				case TextureThumbnailSize.Thumb128:
					textureSize = 128;
					break;
				case TextureThumbnailSize.Thumb256:
					textureSize = 256;
					break;
				case TextureThumbnailSize.Thumb512:
					textureSize = 512;
					break;
			}
			thumbSize = size;
			updateValues();
			Refresh();
		}
		
		private void setFilter(string text)
		{
			filteredTextures.Clear();
			text = text.ToLower();
			foreach (TextureObject tex in textures) {
				if (tex.ShortName.ToLower().Contains(text)) filteredTextures.Add(tex);
			}
			filter = text;
			updateValues();
			Refresh();
		}
		
		public TextureGridControl()
		{
			DoubleBuffered = true;
			InitializeComponent();
			packages = new List<TexturePackage>();
			textures = new List<TextureObject>();
			filteredTextures = new List<TextureObject>();
			textureSize = 128;
			padding = 4;
			lastScrollPercentage = 0;
			lastIndex = 0;
			fontHeight = 16;
			smallHeight = 12;
			drawSizes = false;
			sortTextures = true;
			FontFamily fam = CustomFont.LoadFontFamily(ThorFonts.FreeSans, out fontCollection);
			if (fontCollection == null) throw new Exception();
			nameFont = new Font(fam, 12, GraphicsUnit.Pixel);
			smallFont = new Font(fam, 8, GraphicsUnit.Pixel);
			setThumbSize(TextureThumbnailSize.Thumb128);
			setFilter("");
		}
		
		public void addPackage(TexturePackage pkg)
		{
			packages.Add(pkg);
			foreach (TextureObject tex in pkg.Textures) textures.Add(tex);
			if (sortTextures) textures.Sort();
			setFilter(filter);
		}
		
		public void clearPackages()
		{
			packages.Clear();
			textures.Clear();
			setFilter(filter);
		}
		
		public void addTextures(List<TextureObject> texes)
		{
			foreach (TextureObject tex in texes) textures.Add(tex);
			if (sortTextures) textures.Sort();
			setFilter(filter);
		}
		
		private void updateValues()
		{
			if (textureSize == 0) return;
			
			int textHeight = fontHeight;
			if (thumbSize == TextureThumbnailSize.Thumb64) {
				textHeight = smallHeight;
			}
			
			int combinedx = textureSize + padding * 2;
			int combinedy = combinedx + textHeight;
			
			int maxx = Width / combinedx;
			int maxy = Height / combinedy;
			if (maxx <= 0) maxx = 1;
			if (maxy <= 0) maxy = 1;
			
			int numtex = filteredTextures.Count;
			
			int numrows = (int)Math.Ceiling(numtex / (float)maxx);
			int pixels = combinedy * (numrows) - (Height - padding * 2);// - (maxy - 1));
			int fullmax = pixels;//(int)Math.Ceiling(pixels) / 32.0);
			
			vScrollBar1.Minimum = 0;
			vScrollBar1.Maximum = fullmax;
			vScrollBar1.Enabled = (pixels != 0);
			
			lastIndex = Math.Max(0, (numrows - maxy - 1) * maxx);
			//vScrollBar1.Value = (int)(lastScrollPercentage * (float)vScrollBar1.Maximum);
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			// rawr :3
			Font selectedFont = nameFont;
			int textHeight = fontHeight;
			TextRenderingHint hint = TextRenderingHint.AntiAlias;
			if (thumbSize == TextureThumbnailSize.Thumb64) {
				selectedFont = smallFont;
				textHeight = smallHeight;
				hint = TextRenderingHint.SingleBitPerPixel;
			}
			
			
			
			int numtex = textures.Count;
			if (filter != "") numtex = filteredTextures.Count;
			
			if (numtex == 0) {
				return;
			}
			
			int combinedx = textureSize + padding * 2;
			int combinedy = combinedx + textHeight;
			
			int maxx = Width / combinedx;
			int maxy = Height / combinedy;
			if (Height % combinedy > 0) maxy++;
			if (maxx <= 0) maxx = 1;
			if (maxy <= 0) maxy = 1;
			
			int ytop = Math.Max(0, vScrollBar1.Value);// * 32;
			int row1 = ytop / combinedy;
			int offset = ytop % combinedy;
			if (offset > 0) maxy++;
			
			int index = row1 * maxx;
			if (index < 0) index = 0;
//			if (index >= lastIndex) {
//				index = lastIndex;
//				row1 = index / maxx;
//				offset = combinedy - (Height % combinedy);
//			}
			if (index >= filteredTextures.Count) return;
			
			int topx, topy, boty, actx, acty, widx, heiy;
			float ratio;
			
			Brush textback1 = new SolidBrush(Color.Black);
			Brush textback2 = new SolidBrush(Color.Red);
			Brush textback3 = new SolidBrush(Color.FromArgb(100, Color.Black));
			Pen border1 = new Pen(Color.FromArgb(35, 35, 35));
			Pen border2 = new Pen(Color.White, 2);
			
			for (int i = 0; i < maxy; i++) {
				topy = combinedy * i + padding - offset;
				boty = topy + textureSize + padding;
				for (int j = 0; j < maxx; j++) {
					topx = combinedx * j + padding;
					
					bool selected = false;
					if (filteredTextures[index] == selectedTexture) selected = true;
					
					Bitmap bit = filteredTextures[index].Texture;
					ratio = (float)bit.Height / (float)bit.Width;
					widx = bit.Width;
					heiy = bit.Height;
					
					if (widx > textureSize) {
						widx = textureSize;
						heiy = (int)(textureSize * ratio);
					}
					if (heiy > textureSize) {
						heiy = textureSize;
						widx = (int)(textureSize / ratio);
					}
					
					actx = topx + (textureSize - widx) / 2;
					acty = topy + (textureSize - heiy) / 2;
					
					e.Graphics.DrawImage(bit, actx, acty, widx, heiy);
					if (selected) {
						e.Graphics.DrawRectangle(border2, actx, acty, widx, heiy);
						e.Graphics.FillRectangle(textback2, topx, boty, textureSize, textHeight);
					} else {
						e.Graphics.FillRectangle(textback1, topx, boty, textureSize, textHeight);
					}
					
					e.Graphics.TextRenderingHint = hint;
					e.Graphics.DrawString(filteredTextures[index].ShortName, selectedFont, Brushes.White, topx, boty);
					e.Graphics.DrawRectangle(border1, topx - padding, topy - padding, combinedx, combinedy);
					
					if (drawSizes) {
						e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
						e.Graphics.FillRectangle(textback3, topx, topy, textureSize, fontHeight);
						e.Graphics.DrawString(filteredTextures[index].Width + "x" + filteredTextures[index].Height,
						                      nameFont, Brushes.White, topx, topy);
					}
					
					bit.Dispose();
					
					index++;
					if (index >= numtex) {
						i = maxy;
						j = maxx;
					}
				}
			}
			
			textback1.Dispose();
			textback2.Dispose();
			border1.Dispose();
			border2.Dispose();
			
			base.OnPaint(e);
		}
		
		void VScrollBar1ValueChanged(object sender, EventArgs e)
		{
			lastScrollPercentage = (float)vScrollBar1.Value / (float)vScrollBar1.Maximum;
			Refresh();
		}
		
		protected override void OnResize(EventArgs e)
		{
			updateValues();
			base.OnResize(e);
		}
		
		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) {
				selectedTexture = null;
				
				int textHeight = fontHeight;
				if (thumbSize == TextureThumbnailSize.Thumb64) {
					textHeight = smallHeight;
				}
				
				int combinedx = textureSize + padding * 2;
				int combinedy = combinedx + textHeight;
				
				int maxx = Width / combinedx;
				int maxy = Height / combinedy;
				if (Height % combinedy > 0) maxy++;
				if (maxx <= 0) maxx = 1;
				if (maxy <= 0) maxy = 1;
				
				int ytop = Math.Max(0, vScrollBar1.Value);// * 32;
				int row1 = ytop / combinedy;
				int offset = ytop % combinedy;
				if (offset > 0) maxy++;
				
				int index = row1 * maxx;
				if (index < 0) index = 0;
//				if (index >= lastIndex) {
//					index = lastIndex;
//					row1 = index / maxx;
//					offset = combinedy - (Height % combinedy);
//				}
				if (index >= filteredTextures.Count) return;
				
				int cx = e.X;
				int cy = e.Y + offset;
				
				int yrow = cy / combinedy;
				int xrow = cx / combinedx;
				index += maxx * yrow;
				index += xrow;
				
				int numtex = filteredTextures.Count;
				
				if (index < numtex) {
					selectedTexture = filteredTextures[index];
					OnSelectedTextureChanged();
				}
				
				Refresh();
			}
			base.OnMouseClick(e);
		}
		
		protected override void OnMouseEnter(EventArgs e)
		{
			Focus();
			base.OnMouseEnter(e);
		}
		
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			int textHeight = fontHeight;
			if (thumbSize == TextureThumbnailSize.Thumb64) {
				textHeight = smallHeight;
			}
			int newval = vScrollBar1.Value - (e.Delta / Math.Abs(e.Delta)) * (int)((textureSize + padding * 2 + textHeight));// / 32.0);
			if (newval > vScrollBar1.Maximum) newval = vScrollBar1.Maximum;
			if (newval < vScrollBar1.Minimum) newval = vScrollBar1.Minimum;
			vScrollBar1.Value = newval;
			base.OnMouseWheel(e);
		}
		
		#region Generated Code
				/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
				if (fontCollection != null) {
					fontCollection.Dispose();
				}
				if (nameFont != null) {
					nameFont.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.SuspendLayout();
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.vScrollBar1.LargeChange = 8;
			this.vScrollBar1.Location = new System.Drawing.Point(722, 0);
			this.vScrollBar1.Maximum = 1000;
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 338);
			this.vScrollBar1.TabIndex = 0;
			this.vScrollBar1.ValueChanged += new System.EventHandler(this.VScrollBar1ValueChanged);
			// 
			// TextureGridControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.vScrollBar1);
			this.MinimumSize = new System.Drawing.Size(100, 100);
			this.Name = "TextureGridControl";
			this.Size = new System.Drawing.Size(739, 338);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.VScrollBar vScrollBar1;
		#endregion
	}
}
