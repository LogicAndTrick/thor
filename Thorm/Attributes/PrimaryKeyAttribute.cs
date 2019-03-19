/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 11:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// This column is the primary key
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class PrimaryKeyAttribute : Attribute
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		public PrimaryKeyAttribute()
		{
		}
	}
}
