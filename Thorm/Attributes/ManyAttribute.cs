/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/10/2009
 * Time: 1:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// Represents a One-To-Many or a
	/// Has-And-Belongs-To-Many relationship.
	/// </summary>
	public class ManyAttribute : Attribute
	{
		string thisKey;
		string otherKey;
		string myKey;
		string theirKey;
		string through;
		string storage;
		
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
		/// Default Constructor
		/// </summary>
		public ManyAttribute()
		{
			thisKey = null;
			otherKey = null;
			myKey = null;
			theirKey = null;
			through = null;
			storage = null;
		}
	}
}
