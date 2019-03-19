/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 26/07/2009
 * Time: 11:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace thor
{
	/// <summary>
	/// Description of HLLibFunctions.
	/// </summary>
	public class HLLibFunctions
	{
		private static HLLibFunctions instance = new HLLibFunctions();
		private static uint readVolatile;
		
		static HLLibFunctions()
		{
			//called once after the standard constructor
			readVolatile = (uint)HLLib.FileMode.Read | (uint)HLLib.FileMode.Volatile;
		}
		
		private bool initialised;
		
		private HLLibFunctions()
		{
			//called first
			initialised = false;
		}
		
		private static void init()
		{
			if (!instance.initialised) {
				HLLib.hlInitialize();
				instance.initialised = true;
			}
		}
		
		private static void shutdown()
		{
			if (instance.initialised) {
				HLLib.hlShutdown();
				instance.initialised = false;
			}
		}
		
		private static HLLib.PackageType getPackageType(string file)
		{
			init();
			
			HLLib.PackageType ePackageType = HLLib.PackageType.None;
			// Copied directly from HLExtract (.NET version) by Ryan Gregg
			// Get the package type from the filename extension.
	        ePackageType = HLLib.hlGetPackageTypeFromName(file);

	        // If the above fails, try getting the package type from the data at the start of the file.
	        if(ePackageType == HLLib.PackageType.None && File.Exists(file))
	        {
                FileStream Reader = null;
                try
                {
                    byte[] lpBuffer = new byte[HLLib.DefaultPackageTestBufferSize];
                    Reader = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    int iBytesRead = Reader.Read(lpBuffer, 0, lpBuffer.Length);
                    if(iBytesRead > 0)
                    {
                        IntPtr lpBytesRead = Marshal.AllocHGlobal(iBytesRead);
                        try
                        {
                            Marshal.Copy(lpBuffer, 0, lpBytesRead, iBytesRead);
                            ePackageType = HLLib.hlGetPackageTypeFromMemory(lpBytesRead, (uint)iBytesRead);
                        }
                        finally
                        {
                            Marshal.FreeHGlobal(lpBytesRead);
                        }
                    }
                }
                finally
                {
                    if(Reader != null)
                    {
                        Reader.Close();
                    }
                }
	        }

	       return ePackageType;
		}
		
		private static uint createBindOpenPackage(HLLib.PackageType type, string file)
		{
			uint id;
			if (!HLLib.hlCreatePackage(type, out id)) {
				shutdown();
				throw new HLLibException("Unable to Create Package!");
			}
			HLLib.hlBindPackage(id);
			if (!HLLib.hlPackageOpenFile(file, readVolatile)) {
				HLLib.hlDeletePackage(id);
				shutdown();
				throw new HLLibException("Unable to Open File: " + file);
			}
			return id;
		}
		
		private static void closeDeletePackage(uint id)
		{
			HLLib.hlPackageClose();
			HLLib.hlDeletePackage(id);
		}
		
		private static MemoryStream streamFromPackage(IntPtr pSubItem)
		{
			MemoryStream ret = null;
			
			// create a stream to read in the file
			IntPtr pStream;
			if(HLLib.hlFileCreateStream(pSubItem, out pStream))
			{
				//open the stream to start reading
				if(HLLib.hlStreamOpen(pStream, (uint)HLLib.FileMode.Read))
				{
					// get the size of the stream
					uint size = HLLib.hlStreamGetStreamSize(pStream);
					// create the array of the size. used for the memorystream later.
					byte[] lpInput = new byte[size];
					// allocate space for the file stream
					IntPtr pFileStream = Marshal.AllocHGlobal((int)size);
					// read from the stream into the file stream
					HLLib.hlStreamRead(pStream, pFileStream, size);
					// copy memory from the file stream into the safe byte array
					Marshal.Copy(pFileStream, lpInput, 0, (int)size);
					// free the file stream to prevent memory leaks
					Marshal.FreeHGlobal(pFileStream);
					// close the stream, we don't need it anymore.
					HLLib.hlStreamClose(pStream);
					
					// Create a memory stream to read the byte array
					ret = new MemoryStream(lpInput);
				}
				// we're finished with the stream, free it
				HLLib.hlFileReleaseStream(pSubItem, pStream);
			}
			
			return ret;
		}
		/*
		public static TextureObject[] getAllTexturesFromWad(string wadfile)
		{
			List<TextureObject> ret = new List<TextureObject>();
			
			// get HLLib ready to rock
			init();
			
			// Find the package type of the file. In this case we want a WAD file.
			HLLib.PackageType type = getPackageType(wadfile);
			if (type != HLLib.PackageType.Wad) {
				// This isn't a WAD file! I am shocked and disgusted!
				shutdown();
				// Good lord!
				throw new HLLibException("This is not a WAD file!");
			}
			
			// Open the WAD file to reveal the gooey goodness within
			uint id = createBindOpenPackage(type, wadfile);
			
			// get a pointer to the package root
			IntPtr pItem = HLLib.hlPackageGetRoot();
			//get the number of items in the WAD
			uint numfiles = HLLib.hlFolderGetCount(pItem);
			for (uint i = 0; i < numfiles; i++) {
				// get a pointer to the "item" (in this case bitmap)
				IntPtr pSubItem = HLLib.hlFolderGetItem(pItem, i);
				string filename = HLLib.hlItemGetName(pItem);
				
				#region -- Snip --
//				
//					// WADs can't have folders so this check is not needed.
//					if(HLLib.hlItemGetType(pSubItem) != HLLib.DirectoryItemType.File) {
//						continue;
//					}
//					// get the width and the height of the image. Not needed.
//					HLLib.Attribute wid, hei;
//					HLLib.hlPackageGetItemAttribute(pSubItem, HLLib.PackageAttribute.WadItemWidth, out wid);
//					HLLib.hlPackageGetItemAttribute(pSubItem, HLLib.PackageAttribute.WadItemHeight, out hei);
//					int width = (int)(uint)wid.GetData();
//					int height = (int)(uint)hei.GetData();
//				
				#endregion
				
				MemoryStream ms = streamFromPackage(pSubItem);
				// Can't use Bitmap(width, height, stride, PixelFormat, Scan0) because
				// HLLib returns all bitmap data, not just the pixel info. So we use the
				// stream method instead, which works swimmingly.
				Bitmap b = new Bitmap(ms);
				// Finally, create the texture object and add it to the return list.
				TextureObject tex = new TextureObject(filename, wadfile);
				tex.assignBitmap(b);
				ret.Add(tex);
			}
			
			// stop doing things;
			
			// HLLib clean up
			closeDeletePackage(id);
			shutdown();
			
			return ret.ToArray();
		}
		
		public static Bitmap loadTextureFromWad(string wadfile, string texturename)
		{
			Bitmap ret = null;
			
			// get HLLib ready to rock
			init();
			
			// Find the package type of the file. In this case we want a WAD file.
			HLLib.PackageType type = getPackageType(wadfile);
			if (type != HLLib.PackageType.Wad) {
				// This isn't a WAD file! I am shocked and disgusted!
				shutdown();
				// Good lord!
				throw new HLLibException("This is not a WAD file!");
			}
			
			// Open the WAD file to reveal the gooey goodness within
			uint id = createBindOpenPackage(type, wadfile);
			
			// get a pointer to the package root
			IntPtr pItem = HLLib.hlPackageGetRoot();
			IntPtr pSubItem = HLLib.hlFolderGetItemByName(pItem, texturename, HLLib.FindType.Files);
			
			if (pSubItem != IntPtr.Zero) {
				//read the bitmap in from a stream
				MemoryStream ms = streamFromPackage(pSubItem);
				ret = new Bitmap(ms);
			}
			
			// stop doing things;
			
			// HLLib clean up
			closeDeletePackage(id);
			shutdown();
			
			return ret;
		}
		
		public static Bitmap resizeTexture(Bitmap orig, int maxwidth, int maxheight, bool disposeorig)
		{
			Image img = orig.GetThumbnailImage(maxwidth, maxheight, null, IntPtr.Zero);
			Bitmap ret = new Bitmap(img);
			img.Dispose();
			if (disposeorig) {
				orig.Dispose();
			}
			return ret;
		}
		
		public static string[] getAllTextureNamesFromWad(string wadfile)
		{
			List<string> ret = new List<string>();
			
			// get HLLib ready to rock
			init();
			
			// Find the package type of the file. In this case we want a WAD file.
			HLLib.PackageType type = getPackageType(wadfile);
			if (type != HLLib.PackageType.Wad) {
				// This isn't a WAD file! I am shocked and disgusted!
				shutdown();
				// Good lord!
				throw new HLLibException("This is not a WAD file!");
			}
			
			// Open the WAD file to reveal the gooey goodness within
			uint id = createBindOpenPackage(type, wadfile);
			
			// get a pointer to the package root
			IntPtr pItem = HLLib.hlPackageGetRoot();
			//get the number of items in the WAD
			uint numfiles = HLLib.hlFolderGetCount(pItem);
			for (uint i = 0; i < numfiles; i++) {
				// get a pointer to the "item" (in this case bitmap)
				IntPtr pSubItem = HLLib.hlFolderGetItem(pItem, i);
				// get the texture filename and add it to the list
				string filename = HLLib.hlItemGetName(pSubItem);
				ret.Add(filename);
			}
			
			// stop doing things;
			
			// HLLib clean up
			closeDeletePackage(id);
			shutdown();
			
			return ret.ToArray();
		}
		*/
	}
}
