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
	/// Description of HistoryItem.
	/// </summary>
	public abstract class HistoryItem : IDisposable
	{
		/// <summary>
		/// A list of the affected objects. Key is the original object,
		/// Value is the object as it was before the operation.
		/// </summary>
		protected Dictionary<MapObject, MapObject> objectStore;
		
		public HistoryItem(List<MapObject> list)
		{
			objectStore = new Dictionary<MapObject, MapObject>();
			foreach (MapObject o in list) {
				objectStore.Add(o, o.copyExact());
			}
		}
		
		public void Dispose()
		{
			objectStore.Clear();
		}
		
		public abstract void Undo(MapClass map);
		public abstract void Redo(MapClass map);
	}
}
