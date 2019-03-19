/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 26/07/2009
 * Time: 11:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

using OpenTK.Graphics.OpenGL;

namespace thor
{
	/// <summary>
	/// Description of TextureObject
	/// </summary>
	public class TextureObject : IDisposable, IComparable
	{
		int references;
		uint glId;
		string textureName;
		string shortName;
		string package;
		
		int width;
		int height;
		
		public int Width {
			get { return width; }
		}
		
		public int Height {
			get { return height; }
		}
		
		TexturePackage parent;
		
		public int References {
			get { return references; }
		}
		
		public uint GlId {
			get { return glId; }
		}
		
		public string TextureName {
			get { return textureName; }
		}
		
		public string ShortName {
			get { return shortName; }
		}
		
		public string Package {
			get { return package; }
		}
		
		public TextureObject(string texname, string packagename, TexturePackage owner)
		{
			references = 0;
			glId = 0;
			textureName = texname;
			package = packagename;
			parent = owner;
			string[] sp = texname.Split('.');
			shortName = string.Join(".", sp, 0, sp.Length - 1);
			// parent.getTextureDimensions(textureName, out width, out height);
		}
		
		public Bitmap Texture {
			get {
				Bitmap bit = parent.getTexture(textureName);
				width = bit.Width;
				height = bit.Height;
				return bit;
			}
		}
		
		private void register()
		{
			GL.GenTextures(1, out glId);
			GL.BindTexture(TextureTarget.Texture2D, glId);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
			//GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (int)TextureEnvMode.Modulate);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.GenerateMipmap, 1);
			Bitmap file = Texture;
			Rectangle rect = new Rectangle(0, 0, width, height);
			BitmapData data = file.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			//Glu.Build2DMipmap(TextureTarget.Texture2D, (int)PixelInternalFormat.Rgba, width, height, OpenTK.Graphics.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
			//GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, OpenTK.Graphics.PixelFormat.Rgba, PixelType.UnsignedByte, data.Scan0);
			file.UnlockBits(data);
			file.Dispose();
		}
		
		private void unregister()
		{
			
		}
		
		public void addReference()
		{
			if (references == 0) register();
			references++;
		}
		
		public void removeReference()
		{
			references--;
			if (references == 0) unregister();
		}
		
		public void Dispose()
		{
			if (references > 0) throw new Exception();
			unregister();
		}
		
		public int CompareTo(object obj)
		{
			if (obj is TextureObject) {
				return shortName.CompareTo((obj as TextureObject).shortName);
			} else {
				return 0;
			}
		}
	}
}
