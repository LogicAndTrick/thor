/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/10/2009
 * Time: 3:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Thorm
{
	/// <summary>
	/// A container to hold the values of a One-To-Many
	/// or a Has-And-Belongs-To-Many relationship
	/// </summary>
	public class Many<T> : Relationship
	{
		private List<T> entities;
		private string thisKey;
		private string otherKey;
		private string myKey;
		private string theirKey;
		private string through;
		private string storage;
		private object parent;
		private bool bound;
		private Database database;
		
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
		/// This table's join key in the Many-Many join table
		/// </summary>
		public string MyKey {
			get { return myKey; }
			set { myKey = value; }
		}
		
		/// <summary>
		/// The other table's join key in the Many-Many join table
		/// </summary>
		public string TheirKey {
			get { return theirKey; }
			set { theirKey = value; }
		}
		
		/// <summary>
		/// The database name of the Many-Many join table.
		/// Must be null if relationship is not Many-Many.
		/// </summary>
		public string Through {
			get { return through; }
			set { through = value; }
		}
		
		/// <summary>
		/// The variable storage of the Many instance in this class.
		/// </summary>
		public string Storage {
			get { return storage; }
			set { storage = value; }
		}
		
		/// <summary>
		/// The list of entities in the relation
		/// </summary>
		public List<T> Entities {
			get { Bind(); return entities; }
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
		/// Construct a many relationship
		/// </summary>
		public Many()
		{
			entities = new List<T>();
			thisKey = null;
			otherKey = null;
			myKey = null;
			theirKey = null;
			through = null;
			storage = null;
			parent = null;
			bound = false;
		}
		
		/// <summary>
		/// Bind the relationship and load the data
		/// </summary>
		protected override void Bind()
		{
			if (disposed) return;
			if (bound) return;
			bound = true;
			if (through == null) {
				entities = database.Query<T>()
					.Where(otherKey, Condition.Equal, Mirror.GetPropertyValueForColumn(parent, thisKey).ToString())
					.ExecuteList();
			} else {
				entities = database.Query<T>()
					.Join(through, otherKey, theirKey)
					.Where(through+"."+myKey, Condition.Equal, Mirror.GetPropertyValueForColumn(parent, thisKey).ToString())
					.ExecuteList();
			}
		}
		
		/// <summary>
		/// Unbind the relationship and unload the data
		/// </summary>
		public override void Unbind()
		{
			bound = false;
			entities.Clear();
		}
	}
}
