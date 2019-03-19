/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/10/2009
 * Time: 1:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// A container to hold the values of a Has-One
	/// or a Belongs-To relationship
	/// </summary>
	public class One<T> : Relationship
	{
		private T entity;
		private string thisKey;
		private string otherKey;
		private string storage;
		private object parent;
		private bool bound;
		private Database database;
		private string thisKeySerialised;
		
		/// <summary>
		/// This table's join key
		/// </summary>
		public string ThisKey {
			get { return thisKey; }
			set { thisKey = value; }
		}
		
		/// <summary>
		/// The other table's join key
		/// </summary>
		public string OtherKey {
			get { return otherKey; }
			set { otherKey = value; }
		}
		
		/// <summary>
		/// The variable storage of the One instance in this class.
		/// </summary>
		public string Storage {
			get { return storage; }
			set { storage = value; }
		}
		
		/// <summary>
		/// the entity in the relation
		/// </summary>
		public T Entity {
			get { Bind(); return entity; }
		}
		
		/// <summary>
		/// The parent object storing the relation
		/// </summary>
		public object Parent {
			get { return parent; }
			set { parent = value; }
		}
		
		/// <summary>
		/// The database tied to this relation
		/// </summary>
		public Database Database {
			get { return database; }
			set { database = value; }
		}
		
		/// <summary>
		/// Construct a one relationship
		/// </summary>
		public One()
		{
			entity = default(T);
			thisKey = null;
			otherKey = null;
			storage = null;
			parent = null;
			bound = false;
			thisKeySerialised = null;
		}
		
		/// <summary>
		/// Bind the relationship and load the data
		/// </summary>
		protected override void Bind()
		{
			if (disposed) return;
			string tk = Mirror.GetPropertyValueForColumn(parent, thisKey).ToString();
			string tks = Mirror.MD5(tk);
			if (tks != thisKeySerialised) bound = false;
			if (bound) return;
			bound = true;
			thisKeySerialised = tks;
			entity = database.Query<T>().Where(otherKey, Condition.Equal, tk).ExecuteSingle();
		}
		
		/// <summary>
		/// Unbind the relationship and unload the data
		/// </summary>
		public override void Unbind()
		{
			bound = false;
			entity = default(T);
			thisKeySerialised = null;
		}
	}
}
