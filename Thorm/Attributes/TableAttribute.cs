/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 10:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// This class represents a table.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class TableAttribute : Attribute
	{
		private string name;
		
		/// <summary>
		/// The name of the table in the database
		/// </summary>
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
		/// Default Constructor
		/// </summary>
		public TableAttribute()
		{
			name = null;
		}
	}
}
