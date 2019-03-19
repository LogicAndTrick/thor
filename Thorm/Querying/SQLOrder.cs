/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 9:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// Represents a sorting on a table column
	/// </summary>
	public class SQLOrder
	{
		string column;
		OrderDirection direction;
		
		/// <summary>
		/// The name of the column to sort on
		/// </summary>
		public string Column {
			get { return column; }
		}
		
		/// <summary>
		/// The direction to sort
		/// </summary>
		public OrderDirection Direction {
			get { return direction; }
		}
		
		/// <summary>
		/// Create an SQL order representation
		/// </summary>
		/// <param name="field">The column to sort on</param>
		/// <param name="order">The direction to sort</param>
		public SQLOrder(string field, OrderDirection order)
		{
			column = field;
			direction = order;
		}
	}
}
