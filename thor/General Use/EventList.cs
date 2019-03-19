/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 3/11/2009
 * Time: 6:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace thor
{
	public enum ChangeEvent {
		Add,
		Remove
	}
	
	/// <summary>
	/// Cheap and nasty wrapper of a generic list
	/// </summary>
	public class EventList<T> : IList<T>
	{
		
		public event EventHandler<EventArgs<ChangeEvent>> Changed;
		protected virtual void OnChanged(ChangeEvent e) 
		{
			if (Changed != null) {
				Changed(this, new EventArgs<ChangeEvent>(e));
			}
		}
		
		List<T> wrapper;
		
		public EventList()
		{
			wrapper = new List<T>();
		}
		
		public T this[int index] {
			get { return wrapper[index]; }
			set { wrapper[index] = value; }
		}
		
		public int Count {
			get { return wrapper.Count; }
		}
		
		public bool IsReadOnly {
			get { return false; }
		}
		
		public int IndexOf(T item)
		{
			return wrapper.IndexOf(item);
		}
		
		public void Insert(int index, T item)
		{
			OnChanged(ChangeEvent.Add);
			wrapper.Insert(index, item);
		}
		
		public void RemoveAt(int index)
		{
			OnChanged(ChangeEvent.Remove);
			wrapper.RemoveAt(index);
		}
		
		public void Add(T item)
		{
			OnChanged(ChangeEvent.Add);
			wrapper.Add(item);
		}
		
		public void Clear()
		{
			// OnChanged(EventArgs.Empty);
			wrapper.Clear();
		}
		
		public bool Contains(T item)
		{
			return wrapper.Contains(item);
		}
		
		public void CopyTo(T[] array, int arrayIndex)
		{
			wrapper.CopyTo(array, arrayIndex);
		}
		
		public bool Remove(T item)
		{
			OnChanged(ChangeEvent.Remove);
			return wrapper.Remove(item);
		}
		
		public IEnumerator<T> GetEnumerator()
		{
			return wrapper.GetEnumerator();
		}
		
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return wrapper.GetEnumerator();
		}
		
		public void AddRange(IEnumerable<T> collection)
		{
			wrapper.AddRange(collection);
		}
		
		public T[] ToArray()
		{
			return wrapper.ToArray();
		}
	}
}
