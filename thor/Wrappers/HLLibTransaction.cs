/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/07/2009
 * Time: 10:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace thor
{
	/// <summary>
	/// Description of HLLibTransaction.
	/// </summary>
	public class HLLibTransaction
	{
		private static int referencecount = 0;
		private static bool initialised = false;
		private static uint readVolatile = (uint)HLLib.FileMode.Read | (uint)HLLib.FileMode.Volatile;
		private static uint? boundId = null;
		
		private string packageFile;
		private HLLib.PackageType packageType;
		private uint packageId;
		private IntPtr packageRoot;
		private bool packageIsOpened;
		
		#region Public API
		public HLLibTransaction(string file)
		{
			referencecount++;
			packageFile = file;
			packageType = HLLib.PackageType.None;
			packageIsOpened = false;
			init();
			setPackageType();
			if (packageType == HLLib.PackageType.None) {
				Close();
				throw new HLLibException("This is not a valid HLLib package");
			}
			createBindOpen();
			if (!packageIsOpened) {
				Close();
				throw new HLLibException("Unable to open file " + file);
			}
			packageRoot = HLLib.hlPackageGetRoot();
			//ready to stream
		}
		
		public void Close()
		{
			bind();
			closeDelete();
			referencecount--;
			shutdown();
		}
		
		public TextureObject[] WadGetAll(TexturePackage pkg)
		{
			bind();
			if (packageType != HLLib.PackageType.Wad) {
				throw new HLLibException("This is not a WAD file");
			}
			List<TextureObject> ret = new List<TextureObject>();
			//get the number of items in the WAD
			uint numfiles = HLLib.hlFolderGetCount(packageRoot);
			for (uint i = 0; i < numfiles; i++) {
				// get a pointer to the "item" (in this case bitmap)
				IntPtr pSubItem = HLLib.hlFolderGetItem(packageRoot, i);
				// get the name of the texture
				string filename = HLLib.hlItemGetName(pSubItem);
				TextureObject tex = new TextureObject(filename, packageFile, pkg);
//				if (loadImage) {
//					// create the texture
//					MemoryStream ms = getStream(pSubItem);
//					Bitmap b = new Bitmap(ms);
//					tex.assignBitmap(b);
//				}
				ret.Add(tex);
			}
			return ret.ToArray();
		}
		
		public string[] WadGetNames()
		{
			bind();
			if (packageType != HLLib.PackageType.Wad) {
				throw new HLLibException("This is not a WAD file");
			}
			List<string> ret = new List<string>();
			//get the number of items in the WAD
			uint numfiles = HLLib.hlFolderGetCount(packageRoot);
			for (uint i = 0; i < numfiles; i++) {
				// get a pointer to the "item" (in this case bitmap)
				IntPtr pSubItem = HLLib.hlFolderGetItem(packageRoot, i);
				// get the texture filename and add it to the list
				string filename = HLLib.hlItemGetName(pSubItem);
				ret.Add(filename);
			}
			return ret.ToArray();
		}
		
		public Bitmap WadGet(string name)
		{
			bind();
			if (packageType != HLLib.PackageType.Wad) {
				throw new HLLibException("This is not a WAD file");
			}
			// find the texture with the correct name
			IntPtr pSubItem = HLLib.hlFolderGetItemByName(packageRoot, name, HLLib.FindType.Files);
			if (pSubItem != IntPtr.Zero) {
				//read the bitmap in from a stream
				MemoryStream ms = getStream(pSubItem);
				return new Bitmap(ms);
			} else {
				throw new HLLibException("A file with this name doesn't exist: " + name);
			}
		}
		
		public void WadGetSize(string name, out int w, out int h)
		{
			w = 0;
			h = 0;
			bind();
			if (packageType != HLLib.PackageType.Wad) {
				throw new HLLibException("This is not a WAD file");
			}
			// find the texture with the correct name
			IntPtr pSubItem = HLLib.hlFolderGetItemByName(packageRoot, name, HLLib.FindType.Files);
			if (pSubItem != IntPtr.Zero) {
				uint gw, gh, size;
				HLLib.hlWADFileGetImageSize(pSubItem, out size);
				IntPtr p = Marshal.AllocHGlobal((int)size);
				HLLib.hlWADFileGetImageData(pSubItem, out gw, out gh, out p);
				Marshal.FreeHGlobal(p);
				//read the bitmap in from a stream
				w = (int)gw;
				h = (int)gh;
			} else {
				throw new HLLibException("A file with this name doesn't exist.");
			}
		}
		#endregion
		
		#region Private HLLib Utils
		private void init()
		{
			if (!initialised && referencecount > 0) {
				HLLib.hlInitialize();
				initialised = true;
			}
		}
		
		private void shutdown()
		{
			if (initialised && referencecount == 0) {
				HLLib.hlShutdown();
				initialised = false;
			}
		}
		
		private void bind()
		{
			if (boundId == packageId) return;
			HLLib.hlBindPackage(packageId);
			boundId = packageId;
		}
		
		private void createBindOpen()
		{
			if (packageIsOpened) return;
			if (!HLLib.hlCreatePackage(packageType, out packageId)) {
				return;
			}
			bind();
			if (!HLLib.hlPackageOpenFile(packageFile, readVolatile)) {
				HLLib.hlDeletePackage(packageId);
				return;
			}
			packageIsOpened = true;
		}
		
		private void closeDelete()
		{
			if (!packageIsOpened) return;
			HLLib.hlPackageClose();
			HLLib.hlDeletePackage(packageId);
			boundId = null;
		}
		
		private void setPackageType()
		{
			// Copied directly from HLExtract (.NET version) by Ryan Gregg
			// Get the package type from the filename extension.
			packageType = HLLib.hlGetPackageTypeFromName(packageFile);
			
			// If the above fails, try getting the package type from the data at the start of the file.
			if(packageType == HLLib.PackageType.None && File.Exists(packageFile))
			{
				FileStream Reader = null;
				try
				{
					byte[] lpBuffer = new byte[HLLib.DefaultPackageTestBufferSize];
					Reader = new FileStream(packageFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					int iBytesRead = Reader.Read(lpBuffer, 0, lpBuffer.Length);
					if(iBytesRead > 0)
					{
						IntPtr lpBytesRead = Marshal.AllocHGlobal(iBytesRead);
						try
						{
							Marshal.Copy(lpBuffer, 0, lpBytesRead, iBytesRead);
							packageType = HLLib.hlGetPackageTypeFromMemory(lpBytesRead, (uint)iBytesRead);
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
		}
		
		private MemoryStream getStream(IntPtr pSubItem)
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
		#endregion
	}
}
