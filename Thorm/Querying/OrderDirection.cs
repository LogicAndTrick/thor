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
	/// The order to sort in an SQL order query
	/// </summary>
	public enum OrderDirection
	{
		/// <summary>
		/// Sort values smallest-to-largest
		/// </summary>
		Ascending,
		/// <summary>
		/// Sort values largest-to-smallest
		/// </summary>
		Descending
	}
}
