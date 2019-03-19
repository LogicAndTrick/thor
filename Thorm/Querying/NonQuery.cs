/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/10/2009
 * Time: 6:41 PM
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
	/// Description of NonQuery.
	/// </summary>
	public class NonQuery
	{
		#region Fields
		
		/// <summary>
		/// The database associated with this NQ
		/// </summary>
		protected Database db;
		
		/// <summary>
		/// This transaction (if any) this NQ is using
		/// </summary>
		protected IDbTransaction transaction;
		
		#endregion
		
		#region Constructor
		
		/// <summary>
		/// Construct an NQ instance
		/// </summary>
		/// <param name="database"></param>
		public NonQuery(Database database)
		{
			db = database;
			transaction = null;
		}
		
		#endregion
		
		#region Transaction
		
		/// <summary>
		/// Start a NQ transaction
		/// </summary>
		public virtual void StartTransaction()
		{
			db.Connection.Open();
			transaction = db.GetTransaction();
		}
		
		/// <summary>
		/// Commit the current NQ transaction
		/// </summary>
		public virtual void FinishTransaction()
		{
			transaction.Commit();
			transaction = null;
			db.Connection.Close();
		}
		
		/// <summary>
		/// Rollback the current NQ transaction
		/// </summary>
		public virtual void CancelTransaction()
		{
			transaction.Rollback();
			transaction = null;
			db.Connection.Close();
		}
		
		#endregion
		
		#region Execute
		
		/// <summary>
		/// Execute a single NQ
		/// </summary>
		/// <param name="query">The query to execute</param>
		/// <param name="paramlist">The parameters to use</param>
		protected virtual void ExecuteNonQuery(string query, Dictionary<int, string> paramlist)
		{
			IDbCommand comm = db.GetCommand();
			comm.Connection = db.Connection;
			comm.CommandText = query;
			comm.Transaction = transaction;
			foreach (KeyValuePair<int, string> param in paramlist) {
				IDbDataParameter p = db.GetParameter();
				p.ParameterName = param.Key.ToString();
				p.Value = param.Value;
				comm.Parameters.Add(p);
			}
			comm.ExecuteNonQuery();
			comm.Dispose();
		}
		
		#endregion
		
		#region Insert/Delete/Update
		
		/// <summary>
		/// Insert an object into the database
		/// </summary>
		/// <param name="o">The object to insert</param>
		public virtual void Insert(object o)
		{
			string table = Mirror.TableNameOf(o.GetType());
			StringBuilder b = new StringBuilder("INSERT INTO ");
			b.Append(table);
			b.Append(" (");
			//columns
			List<string> cols = db.ColumnsOf(o.GetType());
			string allcol = String.Join(", ", cols.ToArray());
			b.Append(allcol);
			b.Append(") VALUES (");
			//values
			Dictionary<int, string> paramlist = new Dictionary<int, string>();
			for (int i = 0; i < cols.Count; i++) {
				if (i > 0) b.Append(", ");
				object val = Mirror.GetPropertyValueForColumn(o, cols[i]);
				if (val != null) {
					b.Append(db.GetParamSymbol());
					b.Append(i);
					paramlist.Add(i, val.ToString());
				} else {
					b.Append("NULL");
				}
			}
			b.Append(")");
			ExecuteNonQuery(b.ToString(), paramlist);
			Mirror.SetValueOfPrimaryKey(o, db.GetLastInsertedRowId(o.GetType()));
		}
		
		/// <summary>
		/// Update an object in the database
		/// </summary>
		/// <param name="o">The object to update</param>
		public virtual void Update(object o)
		{
			Update(o, db.ColumnsOf(o.GetType()));
		}
		
		/// <summary>
		/// Update an object in the database
		/// </summary>
		/// <param name="o">The object to update</param>
		/// <param name="fieldsToUpdate">The fields of the object to update</param>
		public virtual void Update(object o, List<string> fieldsToUpdate)
		{
			string table = Mirror.TableNameOf(o.GetType());
			StringBuilder b = new StringBuilder("UPDATE ");
			b.Append(table);
			b.Append(" SET ");
			Dictionary<int, string> paramlist = new Dictionary<int, string>();
			for (int i = 0; i < fieldsToUpdate.Count; i++) {
				if (i > 0) b.Append(", ");
				b.Append(fieldsToUpdate[i]);
				b.Append(" = ");
				b.Append(db.GetParamSymbol());
				b.Append(i+1);
				object val = Mirror.GetPropertyValueForColumn(o, fieldsToUpdate[i]);
				paramlist.Add(i+1, val.ToString());
			}
			b.Append(" WHERE ");
			b.Append(Mirror.PrimaryKeyOf(o.GetType()));
			b.Append(" = ");
			b.Append(db.GetParamSymbol());
			b.Append("0");
			paramlist.Add(0, Mirror.GetValueOfPrimaryKey(o).ToString());
			ExecuteNonQuery(b.ToString(), paramlist);
		}
		
		/// <summary>
		/// Delete an object from the database
		/// </summary>
		/// <param name="o">The object to delete</param>
		public virtual void Delete(object o)
		{
			string table = Mirror.TableNameOf(o.GetType());
			StringBuilder b = new StringBuilder("DELETE FROM ");
			b.Append(table);
			Dictionary<int, string> paramlist = new Dictionary<int, string>();
			b.Append(" WHERE ");
			b.Append(Mirror.PrimaryKeyOf(o.GetType()));
			b.Append(" = ");
			b.Append(db.GetParamSymbol());
			b.Append("0");
			paramlist.Add(0, Mirror.GetValueOfPrimaryKey(o).ToString());
			ExecuteNonQuery(b.ToString(), paramlist);
		}
		
		#endregion
	}
}
