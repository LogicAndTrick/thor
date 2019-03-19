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
	/// Description of HistoryManager.
	/// </summary>
	public class HistoryManager
	{
		Document associatedDocument;
		List<HistoryTransaction> history;
		int maxEntries;
		int currentIndex;
		
		public HistoryManager(Document doc)
		{
			associatedDocument = doc;
			history = new List<HistoryTransaction>();
			maxEntries = 50;
			currentIndex = 0;
		}
		
		public HistoryTransaction StartTransaction(string description)
		{
			HistoryTransaction trans = new HistoryTransaction(description);
			return trans;
		}
		
		public void FinishTransaction(HistoryTransaction trans)
		{
			if (currentIndex > 0) {
				for (int i = 0; i < currentIndex; i++) {
					// don't remove at (i) because the list
					// reindexes itself after each remove
					history[0].Dispose();
					history.RemoveAt(0);
				}
			}
			currentIndex = 0;
			trans.Lock();
			history.Insert(0, trans);
			while (history.Count > maxEntries) {
				history.RemoveAt(maxEntries);
			}
		}
		
		public void Undo(MapClass map)
		{
			//System.Windows.Forms.MessageBox.Show("undo!");
			if (currentIndex < history.Count) {
				history[currentIndex].Undo(map);
				currentIndex++;
				associatedDocument.updateCache();
			}
		}
		
		public void Redo(MapClass map)
		{
			if (currentIndex > 0) {
				currentIndex--;
				history[currentIndex].Redo(map);
				associatedDocument.updateCache();
			}
		}
	}
}
