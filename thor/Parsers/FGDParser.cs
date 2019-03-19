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
using System.IO;
using System.Text.RegularExpressions;

namespace thor
{
	/// <summary>
	/// Parses an FGD (Forge Game Data) file and outputs
	/// a definitions file for use as an entity reference.
	/// </summary>
	public class FGDParser
	{
		string currentpath;
		public FGDParser()
		{
			currentpath = "";
		}
		
		#region Util
		private string[] splitOutsideQuotes(string str, char split)
		{
			if (split == '"') throw new Exception("Can't split outside quotes if your split char is a quote!");
			List<string> spl = new List<string>();
			int last = 0;
			bool inquote = false;
			for (int i = 0; i < str.Length; i++)
			{
				char current = str[i];
				if (current == '"') inquote = !inquote;
				else if (current == split && !inquote) {
					string tmp = str.Substring(last,i-last);
					spl.Add(tmp);
					last = i+1;
				}
				if (i == str.Length-1) {
					string tmp = str.Substring(last,(i+1)-last);
					spl.Add(tmp);
				}
			}
			return spl.ToArray();
		}
		
		private GameDataVariableTypes stringToGDVarType(string type)
		{
			string sw = type.ToLower();
			switch (sw) {
				case "axis":
					return GameDataVariableTypes.Axis;
				case "angle":
					return GameDataVariableTypes.Angle;
				case "bool":
					return GameDataVariableTypes.Bool;
				case "choices":
					return GameDataVariableTypes.Choices;
				case "color255":
					return GameDataVariableTypes.Color255;
				case "color1":
					return GameDataVariableTypes.Color1;
				case "decal":
					return GameDataVariableTypes.Decal;
				case "filterclass":
					return GameDataVariableTypes.FilterClass;
				case "flags":
					return GameDataVariableTypes.Flags;
				case "float":
					return GameDataVariableTypes.Float;
				case "integer":
					return GameDataVariableTypes.Integer;
				case "material":
					return GameDataVariableTypes.Material;
				case "node_dest":
					return GameDataVariableTypes.NodeDest;
				case "origin":
					return GameDataVariableTypes.Origin;
				case "other":
					return GameDataVariableTypes.Other;
				case "pointentityclass":
					return GameDataVariableTypes.PointEntityClass;
				case "scene":
					return GameDataVariableTypes.Scene;
				case "sidelist":
					return GameDataVariableTypes.Sidelist;
				case "sound":
					return GameDataVariableTypes.Sound;
				case "sprite":
					return GameDataVariableTypes.Sprite;
				case "string":
					return GameDataVariableTypes.String;
				case "studio":
					return GameDataVariableTypes.Studio;
				case "target_destination":
					return GameDataVariableTypes.TargetDestination;
				case "target_name_or_class":
					return GameDataVariableTypes.TargetNameOrClass;
				case "target_source":
					return GameDataVariableTypes.TargetSource;
				case "vecline":
					return GameDataVariableTypes.Vecline;
				case "vector":
					return GameDataVariableTypes.Vector;
				case "void":
					return GameDataVariableTypes.Void;
				default:
					return GameDataVariableTypes.Other;
			}
			throw new Exception("How did you get here?");
		}
		
		private string cleanLine(string line)
		{
			string ret = line;
			//strip comments
			/*
				holy crap. removing this:
				ret = Regex.Replace(line, "(.*?)//.*", "$1", RegexOptions.Multiline);
				and inserting this:
			*/
			if (ret.Contains("//")) {
				ret = ret.Substring(0,ret.IndexOf("//"));
			}
			/*
				sped this up a hundredfold! note to self: watch out for inefficient regexes.
				could it be the lazy quantifier?
				another note to self: stop using regexes when a simple solution is available!
				the below regex is ok because it strips all multiple occurances of 
				whitespace (newlines, tabs, spaces) into a single space, and it's fast.
			*/
			//strip all whitespace characters into a single space
			ret = Regex.Replace(ret, @"\s+", " ", RegexOptions.Multiline);
			//strip leading and trailing spaces
			ret = ret.Trim(" ".ToCharArray());
			//our line is now ready for parsing!
			return ret;
		}
		#endregion
		
		#region Parse
		private GameDataObject parseObject(ref StreamReader sr, string firstline)
		{
			char[] space = new char[] {' '};
			/*
				Let's say we start with:
				@BaseClass base(TestClass) color( 1 12 123) = ClassName : 
					"A description "+ 
					"with more than " + 
					"one line." 
				[
					...
				]
			*/
			//firstline is assumed to be cleaned already
			string line;
			//append all the lines up to the opening bracket
			string full = firstline;
			bool empty = false;
			if (full.EndsWith("]")) {
				empty = true;
				full = full.TrimEnd("[ ]".ToCharArray());
			}
			/*
				this accomodates for:
				
				1.
				@BaseClass []
				
				2.
				@BaseClass [
					...
				]
				
				3.
				@BaseClass
				[
					...
				]
			*/
			if (!empty && !full.EndsWith("[")) {
				while ((line = sr.ReadLine()) != null) {
					line = cleanLine(line);
					if (line == "[") break;
					full += " " + line;
				}
			}
			/*
				Now we should have (in string var "full"):
				@BaseClass base(TestClass) color( 1 12 123) = ClassName : "A description "+ "with more than " + "one line."
			*/
			//seperate the class type, the behaviours, the name, and the description.
			string classtype = "";
			string classbehav = "";
			string classname = "";
			string classdesc = "";
			//get the class type (example @BaseClass)
			classtype = full.Substring(0,full.IndexOf(' '));
			/*
				var classtype = @BaseClass
			*/
			full = full.Substring(full.IndexOf(' ')+1).Trim(space);
			/*
				var first = base(TestClass) color( 1 12 123) = ClassName : "A description "+ "with more than " + "one line."
			*/
			classbehav = full.Substring(0,full.IndexOf('=')).Trim(space);
			/*
				var classbehav = base(TestClass) color( 1 12 123)
			*/
			full = full.Substring(full.IndexOf('=')+1).Trim(space);
			/*
				var first = ClassName : "A description "+ "with more than " + "one line."
			*/
			classname = full; //for when there's no description
			if (full.IndexOf(':') >= 0) {
				classname = full.Substring(0,full.IndexOf(':')).Trim(space);
				/*
					var classname = ClassName
				*/
				full = full.Substring(full.IndexOf(':')+1).Trim(space);
				/*
					var first = "A description "+ "with more than " + "one line."
				*/
				classdesc = full;
				/*
					var classdesc = "A description "+ "with more than " + "one line."
				*/
			}
			//-----------------------------------------------------------------------------------
			/*
				var classtype = @BaseClass
			*/
			classtype = classtype.Substring(1).ToLower().Replace("class","");
			/*
				var classtype = base
			*/
			GameDataClassTypes finalClassType = GameDataClassTypes.Base;
			switch (classtype) {
				case "base":
					finalClassType = GameDataClassTypes.Base;
					break;
				case "filter":
					finalClassType = GameDataClassTypes.Filter;
					break;
				case "keyframe":
					finalClassType = GameDataClassTypes.KeyFrame;
					break;
				case "move":
					finalClassType = GameDataClassTypes.Move;
					break;
				case "npc":
					finalClassType = GameDataClassTypes.NPC;
					break;
				case "point":
					finalClassType = GameDataClassTypes.Point;
					break;
				case "solid":
					finalClassType = GameDataClassTypes.Solid;
					break;
				default:
					throw new Exception("Invalid class type: " + classtype);
			}
			
			List<string> tempbehavs = new List<string>();
			bool openbracket = false;
			bool openquote = false;
			int lastbreak = 0;
			int numquotes = 0;
			int numbrackets = 0;
			for (int i = 0; i < classbehav.Length; i++) {
				char c = classbehav[i];
				if (c == '"') {
					if (!openbracket) throw new Exception("Invalid behaviour string - quote outside a bracket construct: "+classbehav);
					numquotes++;
					openquote = !openquote;
				}
				if (numquotes > 2) throw new Exception("Invalid behaviour string - too many quotes inside a bracket construct: "+classbehav);
				if (openquote) continue;
				if (c == '(') {
					if (openbracket) throw new Exception("Invalid behaviour string - open bracket inside a bracket construct: "+classbehav);
					openbracket = true;
					numbrackets++;
				}
				if (c == ')') {
					if (!openbracket) throw new Exception("Invalid behaviour string - close bracket with no opening bracket: "+classbehav);
					openbracket = false;
					numbrackets++;
				}
				if (numbrackets > 2) throw new Exception("Invalid behaviour string - too many bracket constructs without a break: "+classbehav);
				if (openbracket) continue;
				if (c == ' ' || i == classbehav.Length-1) {
					if (openbracket || openquote) throw new Exception("Invalid behaviour string - this should be impossible to reach: "+classbehav);
					string temp = classbehav.Substring(lastbreak,i-lastbreak+1).Trim(space);
					tempbehavs.Add(temp);
					lastbreak = i;
					numquotes = 0;
					numbrackets = 0;
				}
			}
			
			List<GameDataBehaviour> finalClassBehaviours = new List<GameDataBehaviour>();
			List<string> finalClassBases = new List<string>();
			foreach (string behavstring in tempbehavs) {
				string bname = behavstring;
				string bval = "";
				if (behavstring.Contains("(")) {
					if (!behavstring.EndsWith(")")) throw new Exception("Invalid behaviour string - does not end with a closing bracket: "+classbehav);
					bname = behavstring.Substring(0,behavstring.IndexOf('('));
					bval = behavstring.Substring(behavstring.IndexOf('(')).Trim("( )".ToCharArray());
				}
				if (bname == "base") {
					string[] bbase = bval.Split(',');
					for (int i = 0; i < bbase.Length; i++) {
						bbase[i] = bbase[i].Trim(space);
					}
					finalClassBases.AddRange(bbase);
				}
				else {
					GameDataBehaviour gdb = new GameDataBehaviour(bname,bval);
					finalClassBehaviours.Add(gdb);
				}
			}
			
			if (classdesc.IndexOf('"') >= 0) {
				string[] descTokens = classdesc.Split('"');
				/*
					var descTokens = { '', 'A description ', '+ ', 'with more than ', ' + ', 'one line.', '' }
				*/
				if (descTokens.Length > 3) {
					for (int i = 2; i < descTokens.Length-1; i += 2) {
						descTokens[i] = descTokens[i].Trim(space);
						if (descTokens[i] != "+") throw new Exception("Invalid description format - expected '+', actual '"+descTokens[i]+"': " + string.Join("~",descTokens));
					}
				}
				/*
					var cldesctokens = { '', 'A description ', '+', 'with more than ', '+', 'one line.', '' }
				*/
				string properdesc = "";
				for (int i = 1; i < descTokens.Length; i += 2) {
					properdesc += descTokens[i];
				}
				/*
					var properdesc = A description with more than one line.
				*/
				classdesc = properdesc;
				/*
					var classdesc = A description with more than one line.
				*/
			}
			
			//-----------------------------------------------------------------------------------
			
			GameDataObject ret = new GameDataObject(classname,classdesc,finalClassType);
			ret.Behaviours.AddRange(finalClassBehaviours);
			ret.BaseClasses.AddRange(finalClassBases);
			
			
			//class has no variables/IO
			if (empty) {
				return ret;
			}
			
			//-----------------------------------------------------------------------------------
			//read to the end of the class
			string lastline = "";
			bool invalidplus = false;
			while ((line = sr.ReadLine()) != null) {
				line = cleanLine(line);
				if (line == "]" || invalidplus) break;
				if (line == "") continue;
				string addline = line;
				while(addline.EndsWith("+") || addline.EndsWith(":")) {
					addline = cleanLine(sr.ReadLine()).TrimStart(new char[] {'"',' '});
					if (addline == "]") {
						invalidplus = true;
						line = line.TrimEnd(new char[] {' ','+','"'});
					}
					else {
						line = line.TrimEnd(new char[] {' ','+','"'}) + " " + addline;
					}
				}
				bool haschoices = false;
				string origLine = line;
				if (splitOutsideQuotes(line, '=').Length > 1) {
				//if (line.Contains("=")) {
					haschoices = true;
					line = line.Substring(0, line.IndexOf('='));
				}
				string[] linetokens = splitOutsideQuotes(line,':');
				for (int i = 0; i < linetokens.Length; i++) {
					linetokens[i] = linetokens[i].Trim(space);
				}
				if (linetokens.Length < 1) throw new Exception("Not enough properties: "+line);
				if (linetokens[0].ToLower().StartsWith("input ") || linetokens[0].ToLower().StartsWith("output ")) {
					string[] subtokens = new string[]
					{
						linetokens[0].Substring(0,linetokens[0].IndexOf(' ')).Trim(space),
						linetokens[0].Substring(linetokens[0].IndexOf(' ')).Trim(space)
					};
					GameDataIOTypes iotype;
					subtokens[0] = subtokens[0].ToLower().Trim(space);
					if (subtokens[0] == "input") iotype = GameDataIOTypes.Input;
					else if (subtokens[0] == "output") iotype = GameDataIOTypes.Output;
					else throw new Exception("Invalid IO type: "+subtokens[0]);
					string nametype = subtokens[1];
					string name = nametype.Substring(0,nametype.IndexOf('('));
					string type = nametype.Substring(nametype.IndexOf('(')).Trim("( )".ToCharArray());
					GameDataVariableTypes vartype = stringToGDVarType(type);
					string description = "";
					if (linetokens.Length > 1) {
						description = string.Join(":",linetokens,1,linetokens.Length-1).Trim(new char[] {'"',' '});
					}
					GameDataIO gdio = new GameDataIO(iotype,name,vartype,type,description);
					ret.IO.Add(gdio);
				}
				else {
					if (linetokens.Length < 1) throw new Exception("Not enough properties: "+line);
					string nametype = linetokens[0].Trim(space);
					string shortdescription = "";
					if (linetokens.Length > 1) {
						shortdescription = linetokens[1].Trim(new char[] {'"',' '});
					}
					string defaultvalue = "";
					if (linetokens.Length > 2) {
						defaultvalue = linetokens[2].Trim(new char[] {'"',' '});
					}
					string longdescription = "";
					if (linetokens.Length > 3) {
						longdescription = string.Join(":",linetokens,3,linetokens.Length-3).Trim(new char[] {'"',' '});
					}
					if (nametype.IndexOf('(') < 0) throw new Exception("Invalid nametype: "+lastline);
					string name = nametype.Substring(0,nametype.IndexOf('('));
					string type = nametype.Substring(nametype.IndexOf('(')).Trim("( )".ToCharArray());
					GameDataVariableTypes vartype = stringToGDVarType(type);
					GameDataProperty gdp = new GameDataProperty(name,vartype,type,shortdescription,defaultvalue,longdescription);
					if (haschoices) {
						int idx = origLine.IndexOf('=') + 1;
						string all = cleanLine(origLine.Substring(idx, origLine.Length - idx));
						while (splitOutsideQuotes(all, ']').Length <= 1) {
							all += "\n" + cleanLine(sr.ReadLine());
						}
						//[ 1 : "Initially dark" : 0 ]
						//OR
						//[
						//	1: "Initially dark" : 0
						//]
						all = all.Replace("[", "[\n").Replace("]", "\n]");
						string[] lines = splitOutsideQuotes(all, '\n');
						//string ob = "";
						//while (ob == "") ob = cleanLine(sr.ReadLine());
						//if (ob != "[") throw new Exception("Choice start not an open bracket");
						string subline;
						//while ((subline = sr.ReadLine()) != null) {
						bool first = true;
						foreach (string subline1 in lines) {
							subline = cleanLine(subline1);
							if (subline == "]") break;
							if (subline == "") continue;
							if (first) {
								if (subline != "[") throw new Exception("Choice start not an open bracket");
								first = false;
								continue;
							}
							string[] sublinetokens = splitOutsideQuotes(subline,':');
							if (sublinetokens.Length < 2) throw new Exception("Invalid number of parameters: "+subline + "||" + String.Join(":",sublinetokens));
							for (int i = 0; i < sublinetokens.Length; i++) {
								sublinetokens[i] = sublinetokens[i].Trim(new char[] {'"',' '});
							}
							GameDataChoice gdc;
							string key = sublinetokens[0];
							string desc = sublinetokens[1];
							if (vartype == GameDataVariableTypes.Flags) {
								bool ison = false;
								if (sublinetokens.Length > 2) ison = (sublinetokens[2] == "1");
								gdc = new GameDataChoice(key,desc,ison);
							}
							else {
								gdc = new GameDataChoice(key,desc);
							}
							gdp.Choices.Add(gdc);
						}
					}
					ret.Properties.Add(gdp);
				}
				lastline = line;
			}
			
			return ret;
		}
		
		private bool parseLine(ref StreamReader sr, ref GameData gd)
		{
			return parseLine(ref sr, ref gd, false);
		}
		
		private bool parseLine(ref StreamReader sr, ref GameData gd, bool forediting)
		{
			string line = sr.ReadLine();
			if (line == null) return false;
			line = cleanLine(line);
			if (line == "") return true;
			if (!line.StartsWith("@")) return true;
			//line starts with @, so is a valid FGD entry
			if (line.StartsWith("@include ")) {
				string include = line.Substring("@include ".Length).Trim(new char[] {'"'});
				gd.Includes.Add(include);
				if (!forediting) {
					//merge this FGD with another one
					string temppath = currentpath;
					string folder = Path.GetDirectoryName(temppath);
					string newfile = Path.Combine(folder,include);
					gd.merge(parse(newfile));
					currentpath = temppath;
				}
			}
			else if (line.StartsWith("@mapsize")) {
				//set the bounds of the map
				string vals = line.Substring("@mapsize".Length).Trim("()".ToCharArray()).Replace(" ","");
				string[] tokens = vals.Split(",".ToCharArray());
				if (tokens.Length != 2) throw new Exception();
				gd.setMapSize(tokens[0],tokens[1]);
			}
			else {
				//this is a regular FGD class
				gd.addClass(parseObject(ref sr,line));
			}
			
			return true;
		}
		#endregion
		
		public GameData parse(string path)
		{
			currentpath = path;
			StreamReader sr = new StreamReader(path);
			GameData gd = new GameData();
			while(parseLine(ref sr,ref gd));
			sr.Close();
			gd.createDependencies();
			return gd;
		}
		
		public GameData parseForEditing(string path)
		{
			currentpath = path;
			StreamReader sr = new StreamReader(path);
			GameData gd = new GameData();
			while(parseLine(ref sr,ref gd, true));
			sr.Close();
			return gd;
		}
	}
}
