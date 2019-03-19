/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 8:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Thorm
{
	/// <summary>
	/// A condition to use in an SQL where query
	/// </summary>
	public enum Condition
	{
		/// <summary>
		/// The two fields are equal
		/// </summary>
		Equal,
		/// <summary>
		/// The two fields are not equal
		/// </summary>
		NotEqual,
		/// <summary>
		/// The first field is less than the second field
		/// </summary>
		LessThan,
		/// <summary>
		/// The first field is greater than the second field
		/// </summary>
		GreaterThan,
		/// <summary>
		/// The first field is less than or equal to the second field
		/// </summary>
		LTEqual,
		/// <summary>
		/// The first field is greater than or equal to the second field
		/// </summary>
		GTEqual
	}
}
