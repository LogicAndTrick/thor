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
	public class MapVisgroup
	{
		string name;
		Color colour;
		int id;
		bool visible;
		
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public Color Colour {
			get { return colour; }
			set { colour = value; }
		}
		
		public int ID {
			get { return id; }
			set { id = value; }
		}
		
		public bool Visible {
			get { return visible; }
			set { visible = value; }
		}
		
		public MapVisgroup()
		{
			name = "";
			colour = Color.FromArgb(0,255,255,255);
			id = 0;
			visible = true;
		}
		
		public override string ToString()
		{
			return "Visgroup: "+name+" ID="+id+" Visible="+visible+" Color="+colour;
		}
	}
}
