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
	public class MapProperty
	{
		string key;
		string val;
		
		public string Key {
			get { return key; }
			set { key = value; }
		}
		
		public string Value {
			get { return val; }
			set { val = value; }
		}
		
		public MapProperty()
		{
			key = "";
			val = "";
		}
		
		public DecimalCoordinate getCoordinate()
		{
			string[] split = val.Split(' ');
			try {
				return new DecimalCoordinate(decimal.Parse(split[0]), decimal.Parse(split[1]), decimal.Parse(split[2]));
			} catch (Exception) {
				return null;
			}
		}
		
		public void setCoordinate(DecimalCoordinate c)
		{
			val = (int)Math.Round(c.X) + " " + (int)Math.Round(c.Y) + " " + (int)Math.Round(c.Z);
		}
		
		public MapProperty copy()
		{
			MapProperty pro = new MapProperty();
			pro.key = (string)key.Clone();
			pro.val = (string)val.Clone();
			return pro;
		}
	}
}
