/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 8/07/2009
 * Time: 2:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace thor
{
	/// <summary>
	/// Description of MapObjectException.
	/// </summary>
	[Serializable]
	public class MapObjectException : Exception
	{
		public MapObjectException()
		{
			
		}
		
		public MapObjectException(string message) : base(message)
		{
			
		}
		
		public MapObjectException(string message, Exception innerException) : base(message, innerException)
		{
			
		}
		
		protected MapObjectException(SerializationInfo info, StreamingContext context): base(info, context)
		{
			
		}
	}
}
