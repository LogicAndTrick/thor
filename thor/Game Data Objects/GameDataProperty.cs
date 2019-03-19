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
	public class GameDataProperty : IComparable<GameDataProperty>
	{
		string name;
		GameDataVariableTypes variableType;
		string origtype;
		string shortDescription;
		string defaultValue;
		string longDescription;
		List<GameDataChoice> choices;
		
		public string Name {
			get { return name; }
		}
		
		public GameDataVariableTypes VariableType {
			get { return variableType; }
		}
		
		public string OrigType {
			get { return origtype; }
			set { origtype = value; }
		}
		
		public string ShortDescription {
			get { return shortDescription; }
		}
		
		public string DefaultValue {
			get { return defaultValue; }
		}
		
		public string LongDescription {
			get { return longDescription; }
		}
		
		public List<GameDataChoice> Choices {
			get { return choices; }
		}
		
		public GameDataProperty(string n, GameDataVariableTypes vt, string ot, string sd, string dv, string ld)
		{
			name = n;
			variableType = vt;
			origtype = ot.ToLower();
			shortDescription = sd;
			defaultValue = dv;
			longDescription = ld;
			choices = new List<GameDataChoice>();
		}
		
		public int CompareTo(GameDataProperty p)
		{
			if (this.name == p.name) return 0;
			if (this.name == "targetname") return -1;
			if (p.name == "targetname") return 1;
			return this.name.CompareTo(p.name);
		}
		
		private bool allIntegerPropertyKeys()
		{
			int i;
			foreach (GameDataChoice c in choices) {
				if (!int.TryParse(c.Key,out i)) return false;
			}
			return true;
		}
		
		public override string ToString()
		{
			return ToString("");
		}
		
		/*
			propname(choices) : "Short Desc" : 0 : "Long Desc" =
			[
				0 : "Description"
				...
			]
		
			propname(proptype) : "Short Desc" : 1 : "Long Desc"
		*/
		
		public string ToString(string prepend)
		{
			string s = "";
			s += prepend + name + "(" + origtype + ")";
			if (shortDescription != "" || defaultValue != "" || longDescription != "") s += " : \"" + shortDescription + "\"";
			//TODO: quotes around default values?
			if (defaultValue != "" || longDescription != "") s += " : \"" + defaultValue + "\"";
			if (longDescription != "") s += " : \"" + longDescription + "\"";
			if (choices.Count > 0) 
			{
				s += " =\r\n" + prepend + "[";
				bool noquote = allIntegerPropertyKeys();
				bool flag = false;
				if (variableType == GameDataVariableTypes.Flags) {
					noquote = true;
					flag = true;
				}
				foreach (GameDataChoice c in choices) {
					s += "\r\n" + prepend + "\t" + c.ToString(noquote,flag);
				}
				s += "\r\n" + prepend + "]";
			}
			return s;
		}
	}
}
