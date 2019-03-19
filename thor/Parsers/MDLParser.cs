/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 17/08/2009
 * Time: 1:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace thor
{
	/// <summary>
	/// Description of MDLParser.
	/// </summary>
	public static class MDLParser
	{
		public static Model parse(Stream file)
		{
			byte[] buffer = new byte[file.Length];
			file.Read(buffer, 0, (int)file.Length);
			return new GSModel();
		}
	}
}
