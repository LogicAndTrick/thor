/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 4/11/2009
 * Time: 9:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace thor
{
	/// <summary>
	/// Generic EventArgs, for easy eventing goodness!
	/// </summary>
	public class EventArgs<T> : EventArgs
	{
		public EventArgs(T val)
		{
			this.val = val;
		}
		
		private T val;
		
		public T Value
		{
			get { return val; }
		}
	}
}
