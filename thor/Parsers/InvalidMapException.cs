/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 2/07/2009
 * Time: 6:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace thor
{
	/// <summary>
	/// Description of InvalidMapException.
	/// </summary>
	[Serializable]
	public class InvalidMapException : Exception
	{
		public InvalidMapException()
		{
			
		}
		
		public InvalidMapException(string message) : base(message)
		{
			
		}
		
		public InvalidMapException(string message, Exception innerException) : base(message, innerException)
		{
			
		}
		
		protected InvalidMapException(SerializationInfo info, StreamingContext context): base(info, context)
		{
			
		}
	}
}
