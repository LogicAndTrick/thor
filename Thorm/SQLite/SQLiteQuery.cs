/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 10:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;

namespace Thorm.SQLite
{
	/// <summary>
	/// Description of SQLiteQuery.
	/// </summary>
	public class SQLiteQuery<T> : Query<T>
	{
		/// <summary>
		/// Construct a query from the given database
		/// </summary>
		/// <param name="database">The database to use</param>
		public SQLiteQuery(Database database) : base(database)
		{
			
		}
		
		/// <summary>
		/// Build the complete SQL query
		/// </summary>
		/// <returns>The parameterised SQL representation of this query</returns>
		protected override string BuildQuery()
		{
			StartBuild();
			
			string wherestr = BuildWhere();
			string orderstr = BuildOrder();
			string joinstr = BuildJoin();
			string select = BuildSelect();
			
			StringBuilder b = new StringBuilder("SELECT ");
			b.Append(select);
			b.Append(" FROM ");
			b.Append(Mirror.TableNameOf(typeof(T)));
			if (joinstr != "") {
				b.Append(" ");
				b.Append(joinstr);
			}
			if (wherestr != "") {
				b.Append(" ");
				b.Append(wherestr);
			}
			if (orderstr != "") {
				b.Append(" ");
				b.Append(orderstr);
			}
			
			if (limit.HasValue) {
				b.Append(" LIMIT ");
				b.Append(limit.Value);
				if (offset.HasValue) {
					b.Append(" OFFSET ");
					b.Append(offset.Value);
				}
			}
			
			return b.ToString();
		}
	}
}
