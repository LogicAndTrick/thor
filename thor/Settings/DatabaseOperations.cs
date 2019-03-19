/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 26/04/2009
 * Time: 1:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace thor
{
	/// <summary>
	/// Description of DatabaseOperations.
	/// </summary>
	public static class DatabaseOperations
	{
		#region Schema
		public static List<string> getTableNames(SQLiteConnection conn)
		{
			conn.Open();
			DataTable sch = conn.GetSchema("Tables");
			conn.Close();
			List<string> tables = new List<string>();
			foreach (DataRow r in sch.Rows) {
				tables.Add(r[2].ToString().ToLower());
			}
			sch.Dispose();
			return tables;
		}
		#endregion
		
		#region Table Exist
		public static bool tableExists(SQLiteConnection conn, string table)
		{
			if (getTableNames(conn).Contains(table.ToLower())) return true;
			return false;
		}
		
		public static bool tablesExist(SQLiteConnection conn, params string[] tables)
		{
			List<string> names = getTableNames(conn);
			foreach (string s in tables) if (!names.Contains(s.ToLower())) return false;
			return true;
		}
		#endregion
		
		#region Autoincrement
		public static int getNextAutoIncrement(SQLiteConnection conn, string table, string aifield)
		{
			string query = "SELECT " + aifield + " FROM " + table + " ORDER BY " + aifield + " DESC LIMIT 1";
			List<object[]> res = getResult(conn, query);
			int last = 1;
			if (res.Count == 1) {
				last = (int)(long)res[0][0];
			}
			return last;
		}
		#endregion
		
		#region Get Results
		public static List<object[]> getResult(SQLiteConnection conn, SQLiteCommand comm)
		{
			List<object[]> ret = new List<object[]>();
			conn.Open();
			DbDataReader result = comm.ExecuteReader(CommandBehavior.CloseConnection);
			while (result.Read())
			{
				object[] row = new object[result.FieldCount];
				result.GetValues(row);
				ret.Add(row);
			}
			result.Close();
			result.Dispose();
			comm.Dispose();
			conn.Close();
			return ret;
		}
		
		public static List<object[]> getResult(SQLiteConnection conn, string query, string[] parameters)
		{
			SQLiteCommand dbcmd = new SQLiteCommand(conn);
			dbcmd.CommandText = query;
			for (int i = 0; i < parameters.Length; i++) {
				dbcmd.Parameters.Add("@"+i, DbType.String).Value = parameters[i];
			}
			return getResult(conn,dbcmd);
		}
		
		public static List<object[]> getResult(SQLiteConnection conn, string query)
		{
			return getResult(conn, query, new string[0]);
		}
		
		public static List<Dictionary<string, object>> getNamedResult(SQLiteConnection conn, SQLiteCommand comm)
		{
			List<Dictionary<string, object>> ret = new List<Dictionary<string, object>>();
			conn.Open();
			DbDataReader result = comm.ExecuteReader(CommandBehavior.CloseConnection);
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
			conn.Close();
			return ret;
		}
		
		public static List<Dictionary<string, object>> getNamedResult(SQLiteConnection conn, string query, string[] parameters)
		{
			SQLiteCommand dbcmd = new SQLiteCommand(conn);
			dbcmd.CommandText = query;
			for (int i = 0; i < parameters.Length; i++) {
				dbcmd.Parameters.Add("@"+i, DbType.String).Value = parameters[i];
			}
			return getNamedResult(conn,dbcmd);
		}
		
		public static List<Dictionary<string, object>> getNamedResult(SQLiteConnection conn, string query)
		{
			return getNamedResult(conn, query, new string[0]);
		}
		#endregion
		
		#region Table Create and Drop
		public static void createTable(SQLiteConnection conn, string tablename, string[][] properties)
		{
			string[] rows = new string[properties.Length];
			for (int i = 0; i < properties.Length; i++) {
				rows[i] = string.Join(" ",properties[i]);
			}
			string create = "CREATE TABLE " + tablename + " (";
			create += string.Join(", ",rows);
			create += ")";
			SQLiteCommand dbcmd = new SQLiteCommand(conn);
			dbcmd.CommandText = create;
			conn.Open();
			dbcmd.ExecuteNonQuery();
			dbcmd.Dispose();
			conn.Close();
		}
		
		public static void dropTable(SQLiteConnection conn, string tablename)
		{
			SQLiteCommand dbcmd = new SQLiteCommand(conn);
			dbcmd.CommandText = "DROP TABLE IF EXISTS " + tablename;
			conn.Open();
			dbcmd.ExecuteNonQuery();
			dbcmd.Dispose();
			conn.Close();
		}
		#endregion
		
		#region Insert and Update
		public static void insert(SQLiteConnection conn, string table, string[] fields, string[] values)
		{
			if (fields.Length != values.Length) throw new Exception("Fields num doesn't match values num");
			string create = "INSERT INTO " + table + " (";
			create += string.Join(",",fields);
			create += ") VALUES (";
			string[] strfields = new string[fields.Length];
			for (int i = 0; i < fields.Length; i++) strfields[i] = "@" + fields[i];
			create += string.Join(",",strfields);
			create += ")";
			SQLiteCommand dbcmd = new SQLiteCommand(conn);
			dbcmd.CommandText = create;
			for (int i = 0; i < fields.Length; i++) {
				dbcmd.Parameters.Add("@"+fields[i], DbType.String).Value = values[i];
			}
			conn.Open();
			dbcmd.ExecuteNonQuery();
			dbcmd.Dispose();
			conn.Close();
		}
		
		public static void update(SQLiteConnection conn, string table, string[] fields, string[] values,
		                          string wherefield, string whereequal)
		{
			if (fields.Length != values.Length) throw new Exception("Fields num doesn't match values num");
			string[] strfields = new string[fields.Length];
			for (int i = 0; i < fields.Length; i++) strfields[i] = fields[i] + " = " + "@" + fields[i];
			string create = "UPDATE " + table + " SET ";
			create += string.Join(", ",strfields);
			create += " WHERE " + wherefield + " = @whereequal";
			SQLiteCommand dbcmd = new SQLiteCommand(conn);
			dbcmd.CommandText = create;
			for (int i = 0; i < fields.Length; i++) {
				dbcmd.Parameters.Add("@"+fields[i], DbType.String).Value = values[i];
			}
			dbcmd.Parameters.Add("@whereequal", DbType.String).Value = whereequal;
			conn.Open();
			dbcmd.ExecuteNonQuery();
			dbcmd.Dispose();
			conn.Close();
		}
		
		public static void insertOrUpdate(SQLiteConnection conn, string table, string[] fields, string[] values,
		                                  string wherefield, string whereequal)
		{
			string find = "SELECT * FROM " + table;
			find += " WHERE " + wherefield + " = @1";
			List<object[]> res = getResult(conn, find, new string[] { wherefield, whereequal });
			if (res.Count > 0) update(conn, table, fields, values, wherefield, whereequal);
			else {
				Array.Resize(ref fields, fields.Length + 1);
				fields[fields.Length - 1] = wherefield;
				Array.Resize(ref values, values.Length + 1);
				values[values.Length - 1] = whereequal;
				insert(conn, table, fields, values);
			}
		}
		#endregion
	}
}
