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
	public class TextureJustifyEventArgs
	{
		TextureJustifyMode mode;
		bool treatAsOne;
		
		public TextureJustifyMode Mode {
			get { return mode; }
			set { mode = value; }
		}
		
		public bool TreatAsOne {
			get { return treatAsOne; }
			set { treatAsOne = value; }
		}
		
		public TextureJustifyEventArgs()
		{
			
		}
	}
}
