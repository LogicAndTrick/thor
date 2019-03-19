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
	public class TexturePropertyChangeEventArgs : EventArgs
	{
		private decimal scaleX;
		private decimal scaleY;
		private int shiftX;
		private int shiftY;
		private decimal rotation;
		private int lightmapScale;
		
		public decimal ScaleX {
			get { return scaleX; }
			set { scaleX = value; }
		}
		
		public decimal ScaleY {
			get { return scaleY; }
			set { scaleY = value; }
		}
		
		public int ShiftX {
			get { return shiftX; }
			set { shiftX = value; }
		}
		
		public int ShiftY {
			get { return shiftY; }
			set { shiftY = value; }
		}
		
		public decimal Rotation {
			get { return rotation; }
			set { rotation = value; }
		}
		
		public int LightmapScale {
			get { return lightmapScale; }
			set { lightmapScale = value; }
		}
		public TexturePropertyChangeEventArgs()
		{
			
		}
	}
}
