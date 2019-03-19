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
	/// Description of HistoryDelete.
	/// </summary>
	public class HistoryDelete : HistoryItem
	{
		public HistoryDelete(List<MapObject> list) : base(list)
		{
			
		}
		
		public override void Undo(MapClass map)
		{
			//"un"delete the given items
			foreach (KeyValuePair<MapObject, MapObject> kvp in objectStore) {
				map.Worldspawn.addChild(kvp.Key);
			}
		}
		
		public override void Redo(MapClass map)
		{
			//"re"delete the given items
			foreach (KeyValuePair<MapObject, MapObject> kvp in objectStore) {
				map.Worldspawn.removeChild(kvp.Key);
			}
		}
	}
}
