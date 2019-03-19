/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 16/08/2009
 * Time: 8:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace thor
{
	/// <summary>
	/// Description of HistorySelect.
	/// </summary>
	public class HistorySelect : HistoryItem
	{
		public HistorySelect(List<MapObject> list) : base(list)
		{
		}
		
		public override void Undo(MapClass map)
		{
			// odd one this; redo and undo are the same!
			foreach (KeyValuePair<MapObject, MapObject> kvp in objectStore) {
				kvp.Key.setSelect(!kvp.Key.Selected);
			}
		}
		
		public override void Redo(MapClass map)
		{
			// odd one this; redo and undo are the same!
			foreach (KeyValuePair<MapObject, MapObject> kvp in objectStore) {
				kvp.Key.setSelect(!kvp.Key.Selected);
			}
		}
	}
}
