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
	/// A Query is a SELECT statement ONLY.
	/// To refine your query, use the various
	/// (chainable) methods.
	/// </summary>
	public class Query<T>
	{
		/// <summary>
		/// The database that this query is using
		/// </summary>
		protected Database db;
		
		/// <summary>
		/// The list of WHERE conditions in the query
		/// </summary>
		protected List<SQLWhere> wheres;
		
		/// <summary>
		/// The list of ORDER conditions in the query
		/// </summary>
		protected List<SQLOrder> orders;
		
		/// <summary>
		/// The list of JOIN conditions in the query
		/// </summary>
		protected List<SQLJoin> joins;
		
		/// <summary>
		/// The offset (if any) of the query. If this
		/// isn't null, limit can't be null either.
		/// </summary>
		protected int? offset;
		
		/// <summary>
		/// The limit (if any) of the query
		/// </summary>
		protected int? limit;
		
		/// <summary>
		/// Construct a query from the given database
		/// </summary>
		/// <param name="database">The database to use</param>
		public Query(Database database)
		{
			db = database;
			wheres = new List<SQLWhere>();
			orders = new List<SQLOrder>();
			joins = new List<SQLJoin>();
			offset = null;
			limit = null;
			paramNum = 0;
			parameters = new Dictionary<int, string>();
		}
		
		/// <summary>
		/// Add a WHERE condition to the query
		/// </summary>
		/// <param name="field1">The first field to use</param>
		/// <param name="condition">The condition to use</param>
		/// <param name="field2">The second field to use</param>
		/// <returns>this</returns>
		public Query<T> Where(string field1, Condition condition, object field2)
		{
			if (field1.IndexOf('.') < 0) {
				field1 = Mirror.TableNameOf(typeof(T)) + "." + field1;
			}
			SQLWhere where = new SQLWhere(field1, condition, field2.ToString());
			wheres.Add(where);
			return this;
		}
		
		/// <summary>
		/// Add an ORDER condition to the query
		/// </summary>
		/// <param name="field">The field to sort on</param>
		/// <param name="direction">The direction to sort</param>
		/// <returns>this</returns>
		public Query<T> Order(string field, OrderDirection direction)
		{
			SQLOrder order = new SQLOrder(field, direction);
			orders.Add(order);
			return this;
		}
		
		/// <summary>
		/// Add a LIMIT condition to the query
		/// </summary>
		/// <param name="take">The number of results to limit to</param>
		/// <returns>this</returns>
		public Query<T> Limit(int take)
		{
			limit = take;
			return this;
		}
		
		/// <summary>
		/// Add a LIMIT condition and an OFFSET condition to the query
		/// </summary>
		/// <param name="take">The number of results to limit to</param>
		/// <param name="skip">The number of results to offset</param>
		/// <returns>this</returns>
		public Query<T> Limit(int take, int skip)
		{
			limit = take;
			offset = skip;
			return this;
		}
		
		/// <summary>
		/// Add a JOIN condition to the query. Uses the generic
		/// type argument to find the correct table to join.
		/// </summary>
		/// <param name="thisKey">The field in this table to join on</param>
		/// <param name="otherKey">The field in the other table to join on</param>
		/// <returns>this</returns>
		public Query<T> Join<J>(string thisKey, string otherKey)
		{
			SQLJoin join = new SQLJoin(typeof(J), thisKey, otherKey);
			joins.Add(join);
			return this;
		}
		
		/// <summary>
		/// Add a JOIN condition to the query.
		/// </summary>
		/// <param name="type">The table type to join</param>
		/// <param name="thisKey">The field in this table to join on</param>
		/// <param name="otherKey">The field in the other table to join on</param>
		/// <returns>this</returns>
		public Query<T> Join(Type type, string thisKey, string otherKey)
		{
			SQLJoin join = new SQLJoin(type, thisKey, otherKey);
			joins.Add(join);
			return this;
		}
		
		/// <summary>
		/// Add a JOIN condition to the query.
		/// </summary>
		/// <param name="table">The table name to join</param>
		/// <param name="thisKey">The field in this table to join on</param>
		/// <param name="otherKey">The field in the other table to join on</param>
		/// <returns>this</returns>
		public Query<T> Join(string table, string thisKey, string otherKey)
		{
			SQLJoin join = new SQLJoin(table, thisKey, otherKey);
			joins.Add(join);
			return this;
		}
		
		/// <summary>
		/// The number of parameters we are using currently
		/// </summary>
		protected int paramNum;
		
		/// <summary>
		/// The actual parameters we are using currently
		/// </summary>
		protected Dictionary<int, string> parameters;
		
		/// <summary>
		/// Reset parameter data and prepare to generate SQL
		/// </summary>
		protected void StartBuild()
		{
			paramNum = 0;
			parameters.Clear();
		}
		
		/// <summary>
		/// Construct the WHERE condition string
		/// </summary>
		/// <returns>The WHERE string of the query</returns>
		protected virtual string BuildWhere()
		{
			if (wheres.Count == 0) return "";
			StringBuilder b = new StringBuilder("WHERE");
			bool and = false;
			foreach (SQLWhere w in wheres) {
				b.Append(" ");
				if (and) {
					b.Append("AND ");
				}
				b.Append(w.First);
				b.Append(" ");
				b.Append(StringFromCondition(w.Condition));
				b.Append(" ");
				b.Append(db.GetParamSymbol());
				b.Append(paramNum);
				parameters.Add(paramNum, w.Second);
				paramNum++;
				and = true;
			}
			return b.ToString();
		}
		
		/// <summary>
		/// Construct the ORDER condition string
		/// </summary>
		/// <returns>The ORDER string of the query</returns>
		protected virtual string BuildOrder()
		{
			if (orders.Count == 0) return "";
			StringBuilder b = new StringBuilder("ORDER BY");
			bool comma = false;
			foreach (SQLOrder o in orders) {
				if (comma) {
					b.Append(",");
				}
				b.Append(" ");
				b.Append(o.Column);
				b.Append(" ");
				b.Append(StringFromOrder(o.Direction));
				comma = true;
			}
			return b.ToString();
		}
		
		/// <summary>
		/// Construct the JOIN condition string
		/// </summary>
		/// <returns>The JOIN string of the query</returns>
		protected virtual string BuildJoin()
		{
			if (joins.Count == 0) return "";
			List<string> jn = new List<string>();
			foreach (SQLJoin j in joins) {
				string tablename = (j.Table == null) ? j.TableName : Mirror.TableNameOf(j.Table);
				jn.Add("LEFT JOIN " + tablename + " ON " + Mirror.TableNameOf(typeof(T)) + "." + j.ThisKey + " = " + tablename + "." + j.OtherKey);
			}
			return String.Join(" ", jn.ToArray());
		}
		
		/// <summary>
		/// Construct the SELECT fields string
		/// </summary>
		/// <returns>The SELECT fields string of the query</returns>
		protected virtual string BuildSelect()
		{
			List<string> select = new List<string>();
			List<string> thiscols = db.ColumnsOf(typeof(T));
			string thistable = Mirror.TableNameOf(typeof(T));
			foreach (string col in thiscols) {
				select.Add(thistable + "." + col);
			}
			foreach (SQLJoin j in joins) {
				if (j.Table != null) {
					List<string> theircols = db.ColumnsOf(j.Table);
					string theirtable = Mirror.TableNameOf(j.Table);
					foreach (string col in theircols) {
						select.Add(theirtable + "." + col + " AS " + theirtable + "_" + col);
					}
				}
			}
			return String.Join(", ", select.ToArray());
		}
		
		/// <summary>
		/// Converts a Condition into an SQL-usable representation
		/// </summary>
		/// <param name="c">The condition to convert</param>
		/// <returns>The value of the condition as a string</returns>
		protected virtual string StringFromCondition(Condition c)
		{
			switch (c) {
				case Condition.Equal:
					return "=";
				case Condition.GreaterThan:
					return ">";
				case Condition.GTEqual:
					return ">=";
				case Condition.LessThan:
					return "<";
				case Condition.LTEqual:
					return "<=";
				case Condition.NotEqual:
					return "!=";
				default:
					throw new Exception();
			}
		}
		
		/// <summary>
		/// Converts an OrderDirection into an SQL-usable representation
		/// </summary>
		/// <param name="o">The order direction to convert</param>
		/// <returns>The value of the order direction as a string</returns>
		protected virtual string StringFromOrder(OrderDirection o)
		{
			switch (o) {
				case OrderDirection.Ascending:
					return "ASC";
				case OrderDirection.Descending:
					return "DESC";
				default:
					throw new Exception();
			}
		}
		
		/// <summary>
		/// Build the complete SQL query
		/// </summary>
		/// <returns>The parameterised SQL representation of this query</returns>
		protected virtual string BuildQuery()
		{
			StartBuild();
			if (limit.HasValue) {
				if (offset.HasValue) {
					wheres.Add(new SQLWhere("thorm_row_num", Condition.GTEqual, offset.ToString()));
					wheres.Add(new SQLWhere("thorm_row_num", Condition.LTEqual, (offset + limit).ToString()));
				} else {
					wheres.Add(new SQLWhere("thorm_row_num", Condition.LTEqual, limit.ToString()));
				}
			}
			string wherestr = BuildWhere();
			string orderstr = BuildOrder();
			string joinstr = BuildJoin();
			string select = BuildSelect();
			
			StringBuilder b = new StringBuilder("SELECT ");
			b.Append(select);
			b.Append(" FROM ");
			if (limit.HasValue) {
  				b.Append("(SELECT ROW_NUMBER OVER (");
  				if (orderstr != "") {
  					b.Append(orderstr);
  				} else {
  					b.Append("ORDER BY (SELECT 0)");
  				}
  				b.Append(") AS thorm_row_num, * FROM ");
  				b.Append(Mirror.TableNameOf(typeof(T)));
  				if (joinstr != "") {
  					b.Append(" ");
  					b.Append(joinstr);
  				}
  				b.Append(") thorm_temp_table");
  				if (wherestr != "") {
					b.Append(" ");
					b.Append(wherestr);
				}
			} else {
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
			}
			
			return b.ToString();
		}
		
		/// <summary>
		/// Return the values of an SQL query
		/// </summary>
		/// <param name="query">The query to run</param>
		/// <returns>The values of the query result</returns>
		protected virtual List<Dictionary<string, object>> ExecuteResult(string query)
		{
			return ExecuteResult(query, new Dictionary<int, string>());
		}
		
		/// <summary>
		/// Return the values of a parameterised SQL query
		/// </summary>
		/// <param name="query">The query to run</param>
		/// <param name="paramlist">The parameters to use</param>
		/// <returns>The values of the query result</returns>
		protected virtual List<Dictionary<string, object>> ExecuteResult(string query, Dictionary<int, string> paramlist)
		{
			IDbCommand comm = db.GetCommand();
			comm.Connection = db.Connection;
			comm.CommandText = query;
			foreach (KeyValuePair<int, string> param in paramlist) {
				IDbDataParameter p = db.GetParameter();
				p.ParameterName = param.Key.ToString();
				p.Value = param.Value;
				comm.Parameters.Add(p);
			}
			List<Dictionary<string, object>> ret = new List<Dictionary<string, object>>();
			db.Connection.Open();
			IDataReader result = comm.ExecuteReader();
			string[] names = new string[result.FieldCount];
			for (int i = 0; i < result.FieldCount; i++) {
				names[i] = result.GetName(i);
			}
			while (result.Read()) {
				object[] row = new object[result.FieldCount];
				result.GetValues(row);
				Dictionary<string, object> ins = new Dictionary<string, object>();
				for (int i = 0; i < result.FieldCount; i++) {
					ins.Add(names[i], row[i]);
				}
				ret.Add(ins);
			}
			result.Close();
			result.Dispose();
			comm.Dispose();
			db.Connection.Close();
			return ret;
		}
		
		/// <summary>
		/// Return the current query as a list
		/// </summary>
		/// <returns>A list of results</returns>
		public List<T> ExecuteList()
		{
			return List(ExecuteResult(BuildQuery(), parameters));
		}
		
		/// <summary>
		/// Return a custom query as a list
		/// </summary>
		/// <returns>A list of results</returns>
		public List<T> ExecuteList(string query)
		{
			return List(ExecuteResult(query));
		}
		
		/// <summary>
		/// Return the current query as a single result
		/// </summary>
		/// <returns>A single result</returns>
		public T ExecuteSingle()
		{
			return Single(ExecuteResult(BuildQuery(), parameters));
		}
		
		/// <summary>
		/// Return a custom query as a single result
		/// </summary>
		/// <returns>A single result</returns>
		public T ExecuteSingle(string query)
		{
			return Single(ExecuteResult(query));
		}
		
		private List<T> List(List<Dictionary<string, object>> result)
		{
			List<T> list = new List<T>();
			foreach (Dictionary<string, object> item in result) {
				T inst = Mirror.InstanceOf<T>();
				Mirror.SetColumnNames<T>(inst, item);
				list.Add(inst);
				db.Attach(inst);
			}
			return list;
		}
		
		private T Single(List<Dictionary<string, object>> result)
		{
			if (result.Count > 0) {
				T inst = Mirror.InstanceOf<T>();
				Mirror.SetColumnNames<T>(inst, result[0]);
				db.Attach(inst);
				return inst;
			}
			return default(T);
		}
		
		/// <summary>
		/// Get the SQL that will be used if this query is executed
		/// </summary>
		/// <returns>The SQL representation of this query</returns>
		public override string ToString()
		{
			return BuildQuery();
		}
	}
}
