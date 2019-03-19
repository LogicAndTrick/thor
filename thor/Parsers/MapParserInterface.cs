/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 13/10/2008
 * Time: 7:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace thor
{
	/// <summary>
	/// Description of MapParserInterface.
	/// </summary>
	public interface MapParserInterface
	{
		/// <summary>
		/// Saves a map class to the specified path.
		/// </summary>
		/// <param name="map">The map class to save.</param>
		/// <param name="path">The location of the file to save to.</param>
		void save(Document doc, string path);
		
		/// <summary>
		/// Parses the structure of a file format representing a map.
		/// </summary>
		/// <param name="path">The full string path of the file to open.</param>
		/// <returns>A MapClass containing the data retrieved from the file.</returns>
		MapClass parse(string path);
		
		bool isError();
	}
}
