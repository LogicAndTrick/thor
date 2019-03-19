/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 18/10/2008
 * Time: 5:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace thor
{
	/// <summary>
	/// Description of MapParserFactory.
	/// </summary>
	public static class MapParserFactory
	{
		public static MapParserInterface GetParser(string path)
		{
			MapParserInterface i;
			if (path.EndsWith(".rmf")) i = new RMFParser();
			else if (path.EndsWith(".map")) i = new MAPParser();
			else if (path.EndsWith(".vmf")) i = new VMFParser();
			else i = new RMFParser();
			return i;
		}
	}
}
