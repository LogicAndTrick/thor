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
	/// Description of HistoryEdit.
	/// </summary>
	public class HistoryEdit : HistoryItem
	{
		protected Dictionary<MapObject, MapObject> newObjectStore;
		
		public HistoryEdit(List<MapObject> list) : base(list)
		{
			newObjectStore = new Dictionary<MapObject, MapObject>();
		}
		
		public override void Undo(MapClass map)
		{
			newObjectStore.Clear();
			foreach (KeyValuePair<MapObject, MapObject> kvp in objectStore) {
				// record the new object
				newObjectStore.Add(kvp.Key, kvp.Key.copyExact());
				// restore the old object
				kvp.Key.copySettings(kvp.Value);
			}
		}
		
		public override void Redo(MapClass map)
		{
			// restore the new objects
			foreach (KeyValuePair<MapObject, MapObject> kvp in newObjectStore) {
				kvp.Key.copySettings(kvp.Value);
			}
		}
	}
}
