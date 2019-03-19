/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 11/10/2008
 * Time: 5:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace thor
{
	/// <summary>
	/// A Camera object. Stores the camera position, and where it is pointing.
	/// </summary>
	public class MapCamera
	{
		DecimalCoordinate eye;
		DecimalCoordinate look;
		
		/// <summary>
		/// Get or set the position of the camera.
		/// </summary>
		public DecimalCoordinate Eye {
			get { return eye; }
			set { eye = value; }
		}
		
		/// <summary>
		/// Get or set the coordinate the camera is looking at.
		/// </summary>
		public DecimalCoordinate Look {
			get { return look; }
			set { look = value; }
		}
		
		/// <summary>
		/// Basic constructor.
		/// </summary>
		public MapCamera()
		{
			eye = new DecimalCoordinate(0,0,0);
			look = new DecimalCoordinate(0,0,0);
		}
	}
}
