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
using System.Collections.Generic;

namespace thor
{
	public abstract class TexturePackage : IDisposable
	{
		protected List<TextureObject> textures;
		protected string fileName;
		protected List<Document> subscribers;
		
		public List<TextureObject> Textures {
			get { return textures; }
		}
		
		public string FileName {
			get { return fileName; }
		}
		
		public TexturePackage(string packagelocation)
		{
			textures = new List<TextureObject>();
			fileName = packagelocation;
			subscribers = new List<Document>();
		}
		
		public void addSubscriber(Document doc)
		{
			subscribers.Add(doc);
		}
		
		public void removeSubscriber(Document doc)
		{
			subscribers.Remove(doc);
		}
		
		public TextureObject getTextureObject(string name)
		{
			foreach (TextureObject o in textures) {
				if (o.ShortName == name) return o;
			}
			return null;
		}
		
		public abstract Bitmap getTexture(string name);
		public abstract void getTextureDimensions(string name, out int w, out int h);
		public abstract void loadTextures();
		public abstract void Dispose();
	}
}
