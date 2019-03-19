/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 1/08/2009
 * Time: 7:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace thor
{
	/// <summary>
	/// Description of CustomFont.
	/// </summary>
	public static class CustomFont
	{
		/* http://blog.andreloker.de/post/2008/07/03/Load-a-font-from-disk-stream-or-byte-array.aspx */
		// load font family from byte array
		public static FontFamily LoadFontFamily(byte[] buffer, out PrivateFontCollection fontCollection) {
			// pin array so we can get its address
			var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			try {
				var ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
				fontCollection = new PrivateFontCollection();
				fontCollection.AddMemoryFont(ptr, buffer.Length);
				return fontCollection.Families[0];
			} finally {
				// don't forget to unpin the array!
				handle.Free();
			}
		}
	}
}
