/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 10:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SQLite;

namespace Thorm.SQLite
{
	/// <summary>
	/// Description of SQLiteDatabase.
	/// </summary>
	public class SQLiteDatabase : Database
	{
		/// <summary>
		/// Construct a database from a connection string.
		/// </summary>
		/// <param name="connectionString">The connection string to use</param>
		public SQLiteDatabase(string connectionString) : base(connectionString)
		{
			
		}
		
		/// <summary>
		/// Construct a database from a connection. Make sure that
		/// it is a compatible implementation.
		/// </summary>
		/// <param name="connection"></param>
		public SQLiteDatabase(IDbConnection connection) : base(connection)
		{
			
		}
		
		/// <summary>
		/// Get a new connection object of the current implementation.
		/// </summary>
		/// <returns>An unconnected instance of IDbConnection.</returns>
		public override IDbConnection GetConnection()
		{
			return new SQLiteConnection();
		}
		
		/// <summary>
		/// Get a new command object of the current implementation.
		/// </summary>
		/// <returns>An instance of IDbCommand.</returns>
		public override IDbCommand GetCommand()
		{
			return new SQLiteCommand();
		}
		
		/// <summary>
		/// Get a new parameter object of the current implementation.
		/// </summary>
		/// <returns>An instance of IDbDataParameter.</returns>
		public override IDbDataParameter GetParameter()
		{
			return new SQLiteParameter();
		}
		
		/// <summary>
		/// Get a new transaction object of the current implementation.
		/// </summary>
		/// <returns>An instance of IDbTransaction.</returns>
		public override IDbTransaction GetTransaction()
		{
			return conn.BeginTransaction();
		}
		
		/// <summary>
		/// Get the symbol used to represent parameterised variables within
		/// an SQL query, for this database implementation.
		/// </summary>
		/// <returns>The string to prepend to the variable name in a parameterised SQL query.</returns>
		public override string GetParamSymbol()
		{
			return "@";
		}
		
		/// <summary>
		/// Gets the last autoinc value of the given table.
		/// </summary>
		/// <param name="table">The table to get the last ID of</param>
		/// <returns>The last inserted ID in the table</returns>
		public override object GetLastInsertedRowId(Type table)
		{
			IDbCommand comm = GetCommand();
			comm.Connection = conn;
			comm.CommandText = "select last_insert_rowid()";
			bool open = conn.State != ConnectionState.Closed;
			if (!open) conn.Open();
			object ret = comm.ExecuteScalar();
			if (!open) conn.Close();
			comm.Dispose();
			return ret;
		}
		
		/// <summary>
		/// Get an instance of the query object to use
		/// </summary>
		/// <returns>A query instance for this implementation.</returns>
		public override Query<T> Query<T>()
		{
			return new SQLiteQuery<T>(this);
		}
	}
}
