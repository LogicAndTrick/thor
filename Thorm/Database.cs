/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 8:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;

namespace Thorm
{
	/// <summary>
	/// Database. The default implementation of the
	/// Thorm data context. Use it for everything,
	/// as we don't want references to different
	/// classes everywhere.
	/// </summary>
	public abstract class Database
	{
		#region Fields
		
		/// <summary>
		/// The internal connection instance
		/// </summary>
		protected IDbConnection conn;
		
		/// <summary>
		/// A cache of objects that are currently attached to the database
		/// </summary>
		protected Dictionary<object, EntityReference> attachedObjects;
		
		/// <summary>
		/// A cache of table columns to avoid over-reflection
		/// </summary>
		protected Dictionary<Type, List<string>> tableColumns;
		
		/// <summary>
		/// A list of to-be-inserted entities
		/// </summary>
		protected List<object> insertList;
		
		/// <summary>
		/// A list of to-be-deleted entities
		/// </summary>
		protected List<object> deleteList;
		
		/// <summary>
		/// A cache of all relationships that are attached to the database
		/// </summary>
		protected List<Relationship> relationshipList;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Get the current instance of the database
		/// </summary>
		public IDbConnection Connection {
			get { return conn; }
		}
		
		#endregion
		
		#region Initialisation
		
		/// <summary>
		/// Construct a database from a connection string.
		/// </summary>
		/// <param name="connectionString">The connection string to use</param>
		public Database(string connectionString)
		{
			conn = GetConnection();
			conn.ConnectionString = connectionString;
			Init();
		}
		
		/// <summary>
		/// Construct a database from a connection. Make sure that
		/// it is a compatible implementation.
		/// </summary>
		/// <param name="connection"></param>
		public Database(IDbConnection connection)
		{
			conn = connection;
			Init();
		}
		
		/// <summary>
		/// Initialise the database variables.
		/// </summary>
		protected virtual void Init()
		{
			attachedObjects = new Dictionary<object, EntityReference>();
			tableColumns = new Dictionary<Type, List<string>>();
			insertList = new List<object>();
			deleteList = new List<object>();
			relationshipList = new List<Relationship>();
		}
		
		#endregion
		
		#region Columns
		/// <summary>
		/// Shortcut method to find columns of a table. Caches column names
		/// to avoid unnescessary reflection.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public virtual List<string> ColumnsOf(Type type)
		{
			if (!tableColumns.ContainsKey(type)) {
				tableColumns.Add(type, Mirror.ColumnNamesOf(type));
			}
			return tableColumns[type];
		}
		#endregion
		
		#region Implementation
		
		/// <summary>
		/// Get a new connection object of the current implementation.
		/// </summary>
		/// <returns>An unconnected instance of IDbConnection.</returns>
		public abstract IDbConnection GetConnection();
		
		/// <summary>
		/// Get a new command object of the current implementation.
		/// </summary>
		/// <returns>An instance of IDbCommand.</returns>
		public abstract IDbCommand GetCommand();
		
		/// <summary>
		/// Get a new parameter object of the current implementation.
		/// </summary>
		/// <returns>An instance of IDbDataParameter.</returns>
		public abstract IDbDataParameter GetParameter();
		
		/// <summary>
		/// Get a new transaction object of the current implementation.
		/// </summary>
		/// <returns>An instance of IDbTransaction.</returns>
		public abstract IDbTransaction GetTransaction();
		
		/// <summary>
		/// Get the symbol used to represent parameterised variables within
		/// an SQL query, for this database implementation.
		/// </summary>
		/// <returns>The string to prepend to the variable name in a parameterised SQL query.</returns>
		public abstract string GetParamSymbol();
		
		/// <summary>
		/// Gets the last autoinc value of the given table.
		/// </summary>
		/// <param name="table">The table to get the last ID of</param>
		/// <returns>The last inserted ID in the table</returns>
		public abstract object GetLastInsertedRowId(Type table);
		
		#endregion
		
		#region Attach/Detach
		
		/// <summary>
		/// Attach an object to the database
		/// </summary>
		/// <param name="o">The object to attach</param>
		public virtual void Attach(object o)
		{
			if (attachedObjects.ContainsKey(o)) return;
			Mirror.CreateRelations(o, this);
			attachedObjects.Add(o, new EntityReference(o));
		}
		
		/// <summary>
		/// Detach an object from the database
		/// </summary>
		/// <param name="o">The object to detach</param>
		public virtual void Detach(object o)
		{
			if (!attachedObjects.ContainsKey(o)) return;
			attachedObjects.Remove(o);
			Mirror.DestroyRelations(o, this);
		}
		
		/// <summary>
		/// Attach a relation to the database
		/// </summary>
		/// <param name="r">The relation to attach</param>
		public virtual void AttachRelation(Relationship r)
		{
			if (relationshipList.Contains(r)) return;
			relationshipList.Add(r);
		}
		
		/// <summary>
		/// Detach a relation from the database
		/// </summary>
		/// <param name="r">The relation to detach</param>
		public virtual void DetachRelation(Relationship r)
		{
			if (!relationshipList.Contains(r)) return;
			r.Dispose();
			relationshipList.Remove(r);
		}
		
		#endregion
		
		#region Querying
		
		/// <summary>
		/// Get an instance of the query object to use
		/// </summary>
		/// <returns>A query instance for this implementation.</returns>
		public virtual Query<T> Query<T>()
		{
			return new Query<T>(this);
		}
		
		/// <summary>
		/// Get the row of table T with primary key value of the given id.
		/// </summary>
		/// <param name="id">The primary key value of the requested table row</param>
		/// <returns>A T instance with data from the requested row.</returns>
		public virtual T Get<T>(object id)
		{
			return Query<T>().Where(Mirror.PrimaryKeyOf(typeof(T)), Condition.Equal, id).ExecuteSingle();
		}
		
		/// <summary>
		/// Get one row of table T that matches the given query.
		/// The query must not rename T's columns, and must return
		/// all columns of table T. Column names must be unique.
		/// </summary>
		/// <param name="query">The SQL query to run on table T.</param>
		/// <returns>A T instance with data from the first result of the query.</returns>
		public virtual T Get<T>(string query)
		{
			return Query<T>().ExecuteSingle(query);
		}
		
		/// <summary>
		/// Gets all rows of table T
		/// </summary>
		/// <returns>A list of T's containing all data in table T.</returns>
		public virtual List<T> List<T>()
		{
			return Query<T>().ExecuteList();
		}
		
		/// <summary>
		/// Gets all rows of table T that matches the given query.
		/// The query must not rename T's columns, and must return
		/// all columns of table T. Column names must be unique.
		/// </summary>
		/// <param name="query">The SQL query to run on table T.</param>
		/// <returns>A list of T's containing all matches of the query.</returns>
		public virtual List<T> List<T>(string query)
		{
			return Query<T>().ExecuteList(query);
		}
		
		/// <summary>
		/// Get an instance of the nonquery object to use
		/// </summary>
		/// <returns>A nonquery instance for this implementation.</returns>
		public virtual NonQuery NonQuery()
		{
			return new NonQuery(this);
		}
		
		#endregion
		
		#region Raw Querying
		
		/// <summary>
		/// Run 'raw' nonquery (unchecked and unmanaged) on the database connection.
		/// Shortcut method; Useful for creating tables and manual updates.
		/// </summary>
		/// <param name="query">The query to run</param>
		public virtual void RawNonQuery(string query)
		{
			IDbCommand comm = GetCommand();
			comm.Connection = conn;
			comm.CommandText = query;
			conn.Open();
			comm.ExecuteNonQuery();
			conn.Close();
			comm.Dispose();
		}
		
		/// <summary>
		/// Run 'raw' parameterised nonquery (unchecked and unmanaged) on the database connection.
		/// Shortcut method; Useful for creating tables and manual updates.
		/// </summary>
		/// <param name="query">The query to run</param>
		/// <param name="paramlist">The parameters to use</param>
		public virtual void RawNonQuery(string query, Dictionary<int, string> paramlist)
		{
			IDbCommand comm = GetCommand();
			comm.Connection = conn;
			comm.CommandText = query;
			foreach (KeyValuePair<int, string> param in paramlist) {
				IDbDataParameter p = GetParameter();
				p.ParameterName = param.Key.ToString();
				p.Value = param.Value;
				comm.Parameters.Add(p);
			}
			conn.Open();
			comm.ExecuteNonQuery();
			conn.Close();
			comm.Dispose();
		}
		
		#endregion
		
		#region Insert/Delete
		
		/// <summary>
		/// Insert an object to the database.
		/// </summary>
		/// <param name="obj">The object to insert.</param>
		public virtual void Insert(object obj)
		{
			if (!attachedObjects.ContainsKey(obj)) Attach(obj);
			if (!insertList.Contains(obj)) insertList.Add(obj);
		}
		
		/// <summary>
		/// Delete an object from the database.
		/// </summary>
		/// <param name="obj">The object to delete.</param>
		public virtual void Delete(object obj)
		{
			if (!attachedObjects.ContainsKey(obj)) return;
			if (!deleteList.Contains(obj)) deleteList.Add(obj);
		}
		
		#endregion
		
		#region Save
		
		/// <summary>
		/// Commit all ORM changes to the database.
		/// </summary>
		public virtual void Save()
		{
			NonQuery query = NonQuery();
			query.StartTransaction();
			
			// Create
			foreach (object ins in insertList) {
				query.Insert(ins);
				attachedObjects[ins].Recalculate();
			}
			insertList.Clear();
			
			// Delete
			
			foreach (object del in deleteList) {
				if (attachedObjects[del].PrimaryKey != Mirror.GetValueOfPrimaryKey(del)) {
					Mirror.SetValueOfPrimaryKey(del, attachedObjects[del].PrimaryKey);
				}
				query.Delete(del);
				Detach(del);
			}
			deleteList.Clear();
			
			// Update
			foreach (KeyValuePair<object, EntityReference> kv in attachedObjects) {
				string ser = Mirror.SerializeColumns(kv.Key);
				if (ser != kv.Value.Serial) {
					string old = kv.Value.Serial;
					string[] splold = old.Split(';');
					string[] splnew = ser.Split(';');
					List<string> fields = new List<string>();
					string pk = Mirror.PrimaryKeyOf(kv.Key.GetType());
					for (int i = 0; i < splold.Length; i++) {
						if (splold[i] != splnew[i]) {
							string fname = splnew[i].Split('-')[0];
							if (fname == pk) {
								Mirror.SetValueOfPrimaryKey(kv.Key, kv.Value.PrimaryKey);
							} else {
								fields.Add(fname);
							}
						}
					}
					kv.Value.Recalculate();
					if (fields.Count == 0) continue;
					query.Update(kv.Key, fields);
				}
			}
			
			query.FinishTransaction();
			
			foreach (Relationship rel in relationshipList) {
				rel.Unbind();
			}
		}
		
		#endregion
	}
}