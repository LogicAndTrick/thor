/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 9:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// Represents a filter on a table query
	/// </summary>
	public class SQLWhere
	{
		string first;
		Condition cond;
		string second;
		
		/// <summary>
		/// The first field in the comparison
		/// </summary>
		public string First {
			get { return first; }
		}
		
		/// <summary>
		/// The condition to use to compare
		/// </summary>
		public Condition Condition {
			get { return cond; }
		}
		
		/// <summary>
		/// The second field in the comparison
		/// </summary>
		public string Second {
			get { return second; }
		}
		
		/// <summary>
		/// Construct an SQL where representation
		/// </summary>
		/// <param name="field1">The first field to use</param>
		/// <param name="condition">The comparison condition to use</param>
		/// <param name="field2">The second field to use</param>
		public SQLWhere(string field1, Condition condition, string field2)
		{
			first = field1;
			cond = condition;
			second = field2;
		}
	}
}
