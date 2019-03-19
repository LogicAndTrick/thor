/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 11/08/2009
 * Time: 10:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace thor
{
	/// <summary>
	/// Description of HistoryTransaction.
	/// </summary>
	public class HistoryTransaction : IDisposable
	{
		List<HistoryItem> items;
		bool locked;
		
		public HistoryTransaction(string text)
		{
			items = new List<HistoryItem>();
			locked = false;
		}
		
		public void Dispose()
		{
			foreach (HistoryItem i in items) i.Dispose();
			items.Clear();
		}
		
		public void Lock()
		{
			locked = true;
		}
		
		public void Undo(MapClass map)
		{
			if (!locked) return;
			// do the actions backwards
			for (int i = items.Count - 1; i >= 0; i--) {
				items[i].Undo(map);
			}
		}
		
		public void Redo(MapClass map)
		{
			if (!locked) return;
			// do the actions backwards
			for (int i = items.Count - 1; i >= 0; i--) {
				items[i].Redo(map);
			}
		}
		
		public void Select(List<MapObject> list)
		{
			if (locked) return;
			HistorySelect sl = new HistorySelect(list);
			items.Add(sl);
		}
		
		public void Select(MapObject o)
		{
			if (locked) return;
			List<MapObject> list = new List<MapObject>();
			list.Add(o);
			Select(list);
		}
		
		public void Edit(List<MapObject> list)
		{
			if (locked) return;
			HistoryEdit ed = new HistoryEdit(list);
			items.Add(ed);
		}
		
		public void Edit(MapObject o)
		{
			if (locked) return;
			List<MapObject> list = new List<MapObject>();
			list.Add(o);
			Edit(list);
		}
		
		public void Create(List<MapObject> list)
		{
			if (locked) return;
			HistoryCreate cr = new HistoryCreate(list);
			items.Add(cr);
		}
		
		public void Create(MapObject o)
		{
			if (locked) return;
			List<MapObject> list = new List<MapObject>();
			list.Add(o);
			Create(list);
		}
		
		public void Delete(List<MapObject> list)
		{
			if (locked) return;
			HistoryDelete dl = new HistoryDelete(list);
			items.Add(dl);
		}
		
		public void Delete(MapObject o)
		{
			if (locked) return;
			List<MapObject> list = new List<MapObject>();
			list.Add(o);
			Delete(list);
		}
	}
}
