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

namespace thor
{
	public class GameDataChoice
	{
		string key;
		string description;
		bool isOn;
		
		public bool IsOn {
			get { return isOn; }
		}
		
		public string Key {
			get { return key; }
		}
		
		public string Description {
			get { return description; }
		}
		
		public GameDataChoice(string k, string d, bool i)
		{
			key = k;
			description = d;
			isOn = i;
		}
		
		public GameDataChoice(string k, string d)
		{
			key = k;
			description = d;
			isOn = false;
		}
		
		/*
			//for choices
			0 : "Description"
			
			//for flags
			1 : "Description" : 0
		*/
		
		public override string ToString()
		{
			return ToString(false,false);
		}
		
		public string ToString(bool noquote, bool isflag)
		{
			if (isflag) noquote = true;
			string s = "";
			if (!noquote) s += "\"";
			s += key;
			if (!noquote) s += "\"";
			s += " : \"" + description + "\"";
			if (isflag) s += " : " + ((isOn)?1:0);
			return s;
		}
	}
}
