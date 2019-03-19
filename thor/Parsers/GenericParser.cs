/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 6/09/2008
 * Time: 7:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace thor
{
	/// <summary>
	/// Parses a generic Valve file structure. a generic structure looks like this:
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
	/// entity_name
	/// {
	/// 	...
	/// }
	/// ...
	/// </summary>
	public class GenericParser
	{
		public GenericParser()
		{
		}
		
		public GenericStructure parseFromFile(string path)
		{
			//string f = System.IO.File.ReadAllText(path);
			GenericStructure s = new GenericStructure(path);
			//System.IO.File.WriteAllText("C:\\Documents and Settings\\Dan\\My Documents\\My Junk\\Downloads\\vhe_alt\\test\\twister.log",s.ToString());
			return s;
		}
	}
}
