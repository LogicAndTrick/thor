/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 21/12/2008
 * Time: 3:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace thor
{
	public class GameDataBehaviour
	{
		string name;
		string val;
		
		public string Name {
			get { return name; }
		}
		
		public string Value {
			get { return val; }
		}
		
		public GameDataBehaviour(string n, string v)
		{
			name = n;
			val = v;
		}
		
		public DecimalCoordinate[] getSize()
		{
			// size(-16 -16 -36, 16 16 36)
			string[] split = val.Replace(",", "").Split(' ');
			try {
				return new DecimalCoordinate[] {
					new DecimalCoordinate(decimal.Parse(split[0]), decimal.Parse(split[1]), decimal.Parse(split[2])),
					new DecimalCoordinate(decimal.Parse(split[3]), decimal.Parse(split[4]), decimal.Parse(split[5]))
				};
			} catch (Exception) {
				return null;
			}
		}
		
		public Color getColor()
		{
			// color(0 200 200)
			string[] split = val.Split(' ');
			try {
				return Color.FromArgb(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
			} catch (Exception) {
				return Color.Magenta;
			}
		}
		
		public override string ToString()
		{
			return name + "(" + val + ")";
		}
	}
}
