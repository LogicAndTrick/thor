/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 11/08/2009
 * Time: 9:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace thor
{
	/// <summary>
	/// Description of HistoryCreate.
	/// </summary>
	public class HistoryCreate : HistoryItem
	{
		public HistoryCreate(List<MapObject> list) : base(list)
		{
			
		}
		
		public override void Undo(MapClass map)
		{
			//"un"create the given items
			foreach (KeyValuePair<MapObject, MapObject> kvp in objectStore) {
				map.Worldspawn.removeChild(kvp.Key);
			}
		}
		
		public override void Redo(MapClass map)
		{
			//"re"create the given items
			foreach (KeyValuePair<MapObject, MapObject> kvp in objectStore) {
				map.Worldspawn.addChild(kvp.Key);
			}
		}
	}
}
