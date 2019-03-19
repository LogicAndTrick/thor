/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 6/09/2008
 * Time: 8:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace thor
{
	/// <summary>
	/// Holds values parsed from a generic Valve structure. It holds a single entity:
	/// entity_name
	/// {
	/// 	"property" "value"
	/// 	subentity_name
	/// 	{
	/// 		"property" "value
	/// 		subentity_name
	/// 		{
	/// 			...
	/// 		}
	/// 	}
	/// }
	/// In this format
	/// (string) textrep = entity_name\n{\n"property" "value\nsubentity_name\n"property" "value\nsubentity_name\n...\n}\n}\n}
	/// (string) this.name = entityname
	/// (dictionary) this.propertylist = {[property,value],...}
	/// (List(GenericStructure)) this.substructures = {name=subentity_name,propertylist={[property,value],...},
	/// 										substructures={name=subentity_name,...}}
	/// </summary>
	public class GenericStructure
	{
		public Dictionary<string, string> PropertyList {
			get { return propertylist; }
			set { propertylist = value; }
		}
		
		private string name;
		private string path;
		private Dictionary<string, string> propertylist;
		private List<GenericStructure> substructures;
		private bool error;
		private StreamReader streamread;
		
		public GenericStructure(string p)
		{
			initialize();
			path = p;
			streamread = new StreamReader(path);
			parsePath();
		}
		
		public GenericStructure()
		{
			initialize();
		}
		
		private void initialize()
		{
			propertylist = new Dictionary<string, string>();
			substructures = new List<GenericStructure>();
			error = false;
		}
		
		public bool isError()
		{
			return error;
		}
		
		/// <summary>
		/// takes a string and sees if it is a valid structure opening string.
		/// a valid structure opening string contains only the letters from a-z, 
		/// digits, and underscores.
		/// </summary>
		/// <param name="s">the string to check validity on. must be trimmed
		/// before being passed to this function.</param>
		/// <returns>true if the string is a valid structure opener, false
		/// otherwise</returns>
		private bool validStructStartString(string s)
		{
			if (s == "" || s == null) return false;
			string t = s.ToLower().TrimStart("abcdefghijklmnopqrstuvwxyz_".ToCharArray());
			if (t != "") return false;
			return true;
		}
		
		/// <summary>
		/// takes a string and sees if it is a valid structure property string.
		/// a valid structure property string contains the letters from a-z, 
		/// digits, underscores, and has exactly four double quotes ("), more
		/// than 0 spaces. it can also contain brackets, decimal points,
		/// hyphens, slashes, etc. a...z 0...9 () [] - .
		/// </summary>
		/// <param name="s">the string to check validity on. must be trimmed
		/// before being passed to this function.</param>
		/// <returns>true if the string is a valid structure opener, false
		/// otherwise</returns>
		private bool validStructPropertyString(string s)
		{
			if (s == "" || s == null) return false;
			string t = s.ToLower();
			if (!t.Contains("\" \"")) return false;
			if (!t.StartsWith("\"")) return false;
			if (!t.EndsWith("\"")) return false;
			if (t.Replace("\"","").Length != s.Length - 4) return false;
			return true;
		}
		
		/// <summary>
		/// takes a string in the form:
		/// "property" "value"
		/// and adds the property-value combination to this.
		/// </summary>
		/// <param name="s">the property-value string to add</param>
		private void addProperty(string s)
		{
			s = s.Substring(1);
			string p = s.Substring(0,s.IndexOf("\""));
			s = s.Substring(s.IndexOf("\"")+3);
			string v = s.Substring(0,s.IndexOf("\""));
			propertylist.Add(p,v);
		}
		
		private void addSubstructure(GenericStructure s)
		{
			this.substructures.Add(s);
		}
		
		/// <summary>
		/// takes a string and sees if it is a valid structure opening bracket.
		/// a valid structure opening bracket consists of "{" and nothing else.
		/// </summary>
		/// <param name="s">the string to check validity on. must be trimmed
		/// before being passed to this function.</param>
		/// <returns>true if the string is a valid structure opening bracket,
		/// false otherwise</returns>
		private bool validStructOpeningBracket(string s)
		{
			if (s != "{") return false;
			return true;
		}
		
		/// <summary>
		/// takes a string and sees if it is a valid structure closing bracket.
		/// a valid structure closing bracket consists of "}" and nothing else.
		/// </summary>
		/// <param name="s">the string to check validity on. must be trimmed
		/// before being passed to this function.</param>
		/// <returns>true if the string is a valid structure closing bracket,
		/// false otherwise</returns>
		private bool validStructClosingBracket(string s)
		{
			if (s != "}") return false;
			return true;
		}
		
		/// <summary>
		/// Steps to follow when parsing a generic block:
		/// 1. the first line (given) is the name of the structure.
		/// 2. read each line that follows the pattern "name" "value", and store in the propertylist. if
		/// 	a line does not follow this pattern, it is either the opening of a new structure
		/// 	(word with no quotes), or the closing of the current structure (closing bracket).
		/// 3a. (opening of new structure) deal with the new structure.
		/// 3b. (closing of current structure) finished.
		/// </summary>
		private GenericStructure processStruct(string firstline)
		{
			GenericStructure gs = new GenericStructure();
			gs.name = firstline;
			string line;
			line = streamread.ReadLine().Trim();
			if (!validStructOpeningBracket(line)) {
				error = true;
				return gs;
			}
			while ((line = streamread.ReadLine()) != null)
			{
				line = line.Trim();
				if (validStructClosingBracket(line)) return gs;
				else if (validStructPropertyString(line)) gs.addProperty(line);
				else if (validStructStartString(line)) gs.addSubstructure(processStruct(line));
				//else skip
			}
			return gs;
		}
		
		
		/// <summary>
		/// Steps to follow when parsing a generic file:
		/// 1. parse each line, looking for struct starts.
		/// 2. when you reach a start, deal with it, then repeat until end.
		/// </summary>
		private void parsePath()
		{
			if (path == "" || path == null) {
				error = true;
				return;
			}
			this.name = "top";
			string line; //each line will be stored here as it is read
			//parse each line.
			while((line = streamread.ReadLine()) != null)
			{
				line = line.Trim();
				if (validStructStartString(line)) this.addSubstructure(processStruct(line));
				//else skip
			}
			streamread.Close();
		}
		
		/// <summary>
		/// Not an actual tostring method - this is currently for debugging purposes only.
		/// </summary>
		/// <returns>A string representation of the current GenericStructure.</returns>
		public override string ToString()
		{
			string str = "";
			str += name+"\r\n"+
				"	properties:\r\n";
			foreach (KeyValuePair<string,string> kvp in propertylist) {
				str += "		"+kvp.Key + ": " + kvp.Value + "\r\n";
			}
			str += "	substructures:\r\n";
			foreach (GenericStructure s in substructures) {
				str += s.ToString(1) + "\r\n";
			}
			str += "end";
			return str;
		}
		
		/// <summary>
		/// Not an actual tostring method - this is currently for debugging purposes only.
		/// </summary>
		/// <param name="tabs">The number of tabs to place before each line</param>
		/// <returns>A string representation of the current GenericStructure.</returns>
		public string ToString(int tabs)
		{
			string tabst = "";
			for (int i = 0; i < tabs*2; i++) tabst += "	";
			string str = "";
			str += tabst+name+"\r\n"+
				tabst+"	properties:\r\n";
			foreach (KeyValuePair<string,string> kvp in propertylist) {
				str += tabst+"		"+kvp.Key + ": " + kvp.Value + "\r\n";
			}
			str += tabst+"	substructures:\r\n";
			foreach (GenericStructure s in substructures) {
				str += s.ToString(tabs + 1) + "\r\n";
			}
			str += tabst+"end";
			return str;
		}
		
		/// <summary>
		/// Gets the name of the current GenericStructure.
		/// </summary>
		/// <returns></returns>
		public string getName()
		{
			return name;
		}
		
		public string getProperty(string key)
		{
			if (propertylist.ContainsKey(key)) return propertylist[key];
			else return null;
		}
		
		public GenericStructure[] substructuresNamed(string n)
		{
			List<GenericStructure> gslist = new List<GenericStructure>();
			foreach(GenericStructure gs in substructures) {
				if (gs.name == n) gslist.Add(gs);
				GenericStructure[] sub = gs.substructuresNamed(n);
				foreach (GenericStructure sgs in sub)
				{
					gslist.Add(sgs);
				}
			}
			return gslist.ToArray();
		}
		
		public GenericStructure substructureNamed(string n)
		{
			foreach(GenericStructure gs in substructures) {
				if (gs.name == n) return gs;
			}
			return null;
		}
	}
}
