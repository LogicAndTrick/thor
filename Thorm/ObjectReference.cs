/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/10/2009
 * Time: 8:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// An ObjectReference stores serialised values of
	/// entities to see if they have changed.
	/// </summary>
	public class EntityReference
	{
		private object entity;
		private string serial;
		private object primaryKey;
		
		/// <summary>
		/// The entity that is stored.
		/// </summary>
		public object Entity {
			get { return entity; }
			set {
				entity = value;
				serial = Mirror.SerializeColumns(value);
				primaryKey = Mirror.GetValueOfPrimaryKey(value);
			}
		}
		
		/// <summary>
		/// The serialised version of the entity.
		/// </summary>
		public string Serial {
			get { return serial; }
			set { serial = value; }
		}
		
		/// <summary>
		/// The value of the primary key of the entity.
		/// </summary>
		public object PrimaryKey {
			get { return primaryKey; }
			set { primaryKey = value; }
		}
		
		/// <summary>
		/// Create a new entity reference
		/// </summary>
		/// <param name="o">The entity to reference</param>
		public EntityReference(object o)
		{
			Entity = o;
		}
		
		/// <summary>
		/// Recalculate the serial and primary key values of the entity.
		/// </summary>
		public void Recalculate()
		{
			serial = Mirror.SerializeColumns(entity);
			primaryKey = Mirror.GetValueOfPrimaryKey(entity);
		}
	}
}
