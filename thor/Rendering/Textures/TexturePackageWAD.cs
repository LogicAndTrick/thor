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
	public class TexturePackageWAD : TexturePackage
	{
		HLLibTransaction transaction;
		public TexturePackageWAD(string packagelocation) : base(packagelocation)
		{
			transaction = new HLLibTransaction(packagelocation);
		}
		
		public override void loadTextures()
		{
			try {
				foreach (TextureObject tex in transaction.WadGetAll(this)) {
					textures.Add(tex);
				}
				/*foreach (TextureObject tex in HLLibFunctions.getAllTexturesFromWad(fileName)) {
					textures.Add(tex);
				}
				foreach (string name in HLLibFunctions.getAllTextureNamesFromWad(fileName)) {
					TextureObject tex = new TextureObject(name, fileName);
					textures.Add(tex);
				}*/
			} catch (HLLibException e) {
				System.Windows.Forms.MessageBox.Show("Texture Error: " + e.Message);
			}
		}
		
		public override Bitmap getTexture(string name)
		{
			return transaction.WadGet(name);
		}
		
		public override void getTextureDimensions(string name, out int w, out int h)
		{
			transaction.WadGetSize(name, out w, out h);
		}
		
		public override void Dispose()
		{
			transaction.Close();
		}
	}
}
