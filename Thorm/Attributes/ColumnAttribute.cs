/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 11:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// This property represents a column.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ColumnAttribute : Attribute
	{
		private string name;
		
		/// <summary>
		/// The name of the column in the database, in case it is not named the same.
		/// </summary>
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
		/// Default Constructor
		/// </summary>
		public ColumnAttribute()
		{
			name = null;
		}
	}
}
