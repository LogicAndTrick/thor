/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 27/07/2009
 * Time: 10:35 AM
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
	/// Description of TextureBrowserForm.
	/// </summary>
	public partial class TextureBrowserForm : Form
	{
		private TextureObject selectedTexture;
		
		public TextureObject SelectedTexture {
			get { return selectedTexture; }
		}
		
		public TextureBrowserForm()
		{
			InitializeComponent();
			comboBox1.SelectedIndex = (int)textureGridControl1.ThumbSize;
		}
		
		public void addPackage(TexturePackage pkg)
		{
			textureGridControl1.addPackage(pkg);
		}
		
		public void clearPackages()
		{
			textureGridControl1.clearPackages();
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			textureGridControl1.Filter = textBox1.Text;
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			textureGridControl1.ThumbSize = (TextureThumbnailSize)comboBox1.SelectedIndex;
		}
		
		void TextureGridControl1DoubleClick(object sender, EventArgs e)
		{
			if (textureGridControl1.SelectedTexture != null) {
				selectedTexture = textureGridControl1.SelectedTexture;
				DialogResult = DialogResult.OK;
				Hide();
			}
		}
		
		void BtnOKClick(object sender, EventArgs e)
		{
			if (textureGridControl1.SelectedTexture != null) {
				selectedTexture = textureGridControl1.SelectedTexture;
				DialogResult = DialogResult.OK;
				Hide();
			}
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Hide();
		}
	}
}
