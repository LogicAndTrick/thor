/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 10:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace Thorm
{
	/// <summary>
	/// Thorm's exception class.
	/// </summary>
	[Serializable]
	public class ThormException : Exception
	{
		/// <summary>
		/// Create a new instance of ThormException.
		/// </summary>
		public ThormException()
		{
			
		}
		
		/// <summary>
		/// Create a new instance of ThormException.
		/// </summary>
		/// <param name="message">The message to use</param>
		public ThormException(string message) : base(message)
		{
			
		}
		
		/// <summary>
		/// Create a new instance of ThormException.
		/// </summary>
		/// <param name="message">The message to use</param>
		/// <param name="innerException">The inner exception of this exception</param>
		public ThormException(string message, Exception innerException) : base(message, innerException)
		{
			
		}
		
		/// <summary>
		/// Create a new instance of ThormException.
		/// </summary>
		/// <param name="info">The SerializationInfo to use</param>
		/// <param name="context">The StreamingContext to use</param>
		protected ThormException(SerializationInfo info, StreamingContext context): base(info, context)
		{
			
		}
	}
}
