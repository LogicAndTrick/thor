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
	/// <summary>
	/// Description of TextureManager.
	/// </summary>
	public class TextureManager
	{
		private static TextureManager instance = new TextureManager();
		
		static TextureManager()
		{
			
		}
		
		List<TexturePackage> packages;
		
		private TextureManager()
		{
			packages = new List<TexturePackage>();
		}
		
		public static TexturePackage addWADFile(string file)
		{
			TexturePackage pack = new TexturePackageWAD(file);
			pack.loadTextures();
			instance.packages.Add(pack);
			return pack;
		}
	}
}
