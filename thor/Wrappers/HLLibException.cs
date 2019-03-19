/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 27/07/2009
 * Time: 12:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace thor
{
	/// <summary>
	/// Description of HLLibException.
	/// </summary>
	[Serializable]
	public class HLLibException : Exception
	{
		public HLLibException()
		{
			
		}
		
		public HLLibException(string message) : base(message)
		{
			
		}
		
		public HLLibException(string message, Exception innerException) : base(message, innerException)
		{
			
		}
		
		protected HLLibException(SerializationInfo info, StreamingContext context): base(info, context)
		{
			
		}
	}
}
