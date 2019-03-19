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
	public class GameDataIO
	{
		GameDataIOTypes ioType;
		GameDataVariableTypes variableType;
		string description;
		string name;
		string origtype;
		
		public string OrigType {
			get { return origtype; }
			set { origtype = value; }
		}
		
		public string Name {
			get { return name; }
		}
		
		public GameDataIOTypes IOType {
			get { return ioType; }
		}
		
		public GameDataVariableTypes VariableType {
			get { return variableType; }
		}
		
		public string Description {
			get { return description; }
		}
		
		public GameDataIO(GameDataIOTypes io, string n, GameDataVariableTypes var, string ot, string desc)
		{
			ioType = io;
			name = n;
			variableType = var;
			origtype = ot.ToLower();
			description = desc;
		}
		
		/*
			input inname(intype) : "Description"
		*/
		
		public override string ToString()
		{
			string s = "";
			if (ioType == GameDataIOTypes.Input) s += "input";
			else if (ioType == GameDataIOTypes.Output) s += "output";
			s += " " + name + "(" + origtype + ")";
			if (description != "") s += " : \"" + description + "\"";
			return s;
		}
	}
}
