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
	/// Represents a Has-One or a Belongs-To relationship.
	/// </summary>
	public class OneAttribute : Attribute
	{
		string thisKey;
		string otherKey;
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
		/// The variable storage of the One instance in this class.
		/// </summary>
		public string Storage {
			get { return storage; }
			set { storage = value; }
		}
		
		/// <summary>
		/// Default Constructor
		/// </summary>
		public OneAttribute()
		{
			thisKey = null;
			otherKey = null;
			storage = null;
		}
	}
}
