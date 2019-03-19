/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/10/2009
 * Time: 2:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// Represents a join between two tables
	/// </summary>
	public class SQLJoin
	{
		Type table;
		string tableName;
		string thisKey;
		string otherKey;
		
		/// <summary>
		/// Class type of the table to join
		/// </summary>
		public Type Table {
			get { return table; }
		}
		
		/// <summary>
		/// Name of the table to join
		/// </summary>
		public string TableName {
			get { return tableName; }
		}
		
		/// <summary>
		/// Name of this table's key to join on
		/// </summary>
		public string ThisKey {
			get { return thisKey; }
		}
		
		/// <summary>
		/// Name of the join table's key to join on
		/// </summary>
		public string OtherKey {
			get { return otherKey; }
		}
		
		/// <summary>
		/// Create an SQL join representation
		/// </summary>
		/// <param name="tbl">Table type to join</param>
		/// <param name="tk">This table's join key</param>
		/// <param name="ok">Join table's join key</param>
		public SQLJoin(Type tbl, string tk, string ok)
		{
			table = tbl;
			thisKey = tk;
			otherKey = ok;
		}
		
		/// <summary>
		/// Create an SQL join representation
		/// </summary>
		/// <param name="tbl">Table name to join</param>
		/// <param name="tk">This table's join key</param>
		/// <param name="ok">Join table's join key</param>
		public SQLJoin(string tbl, string tk, string ok)
		{
			tableName = tbl;
			thisKey = tk;
			otherKey = ok;
		}
	}
}
