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
	public class TextureModeChangeEventArgs
	{
		TextureModeLeftClick left;
		TextureModeRightClick right;
		
		public TextureModeLeftClick Left {
			get { return left; }
			set { left = value; }
		}
		
		public TextureModeRightClick Right {
			get { return right; }
			set { right = value; }
		}
		
		public TextureModeChangeEventArgs()
		{
			
		}
	}
}
