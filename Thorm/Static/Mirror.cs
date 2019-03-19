/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/10/2009
 * Time: 10:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Thorm
{
	/// <summary>
	/// Reflection-based helper functions.
	/// </summary>
	public static class Mirror
	{
		/// <summary>
		/// Get the database table name of the given type
		/// </summary>
		/// <param name="type">The type to get the table name of</param>
		/// <returns>The table name of the type</returns>
		public static string TableNameOf(Type type)
		{
			foreach (Attribute attr in type.GetCustomAttributes(true)) {
				TableAttribute ta = attr as TableAttribute;
				if (ta != null) {
					if (ta.Name != null) {
						return ta.Name;
					} else {
						return type.Name;
					}
				}
			}
			throw new ThormException("This object does not have a table name!");
		}
		
		/// <summary>
		/// Get the database primary key name of the given type
		/// </summary>
		/// <param name="type">The type to get the primary key of</param>
		/// <returns>The primary key name of the type</returns>
		public static string PrimaryKeyOf(Type type)
		{
			foreach (PropertyInfo prop in type.GetProperties()) {
				ColumnAttribute ca = null;
				PrimaryKeyAttribute pka = null;
				foreach (Attribute attr in prop.GetCustomAttributes(true)) {
					if (ca == null) ca = attr as ColumnAttribute;
					if (pka == null) pka = attr as PrimaryKeyAttribute;
					if (pka != null && ca != null) {
						if (ca.Name != null) return ca.Name;
						return prop.Name;
					}
				}
			}
			throw new ThormException("This object does not have a primary key!");
		}
		
		/// <summary>
		/// Get the type of the primary key of the given type
		/// </summary>
		/// <param name="type">The type to get the primary key type of</param>
		/// <returns>The primary key type of the type</returns>
		public static Type GetTypeOfPrimaryKey(Type type)
		{
			foreach (PropertyInfo prop in type.GetProperties()) {
				ColumnAttribute ca = null;
				PrimaryKeyAttribute pka = null;
				foreach (Attribute attr in prop.GetCustomAttributes(true)) {
					if (ca == null) ca = attr as ColumnAttribute;
					if (pka == null) pka = attr as PrimaryKeyAttribute;
					if (pka != null && ca != null) {
						return prop.PropertyType;
					}
				}
			}
			throw new ThormException("This object does not have a primary key!");
		}
		
		/// <summary>
		/// Get the value of the primary key of the given object
		/// </summary>
		/// <param name="obj">The object to get the primary key value of</param>
		/// <returns>The primary key value of the object</returns>
		public static object GetValueOfPrimaryKey(object obj)
		{
			string pk = PrimaryKeyOf(obj.GetType());
			return GetPropertyValueForColumn(obj, pk);
		}
		
		/// <summary>
		/// Set the value of the primary key of the given object
		/// </summary>
		/// <param name="obj">The object to set the primary key value of</param>
		/// <param name="val">The value of the primary key to set</param>
		public static void SetValueOfPrimaryKey(object obj, object val)
		{
			val = DataTypeMapping.CastObjectTo(GetTypeOfPrimaryKey(obj.GetType()), val);
			string pk = PrimaryKeyOf(obj.GetType());
			SetProperty(obj, GetPropertyForColumn(obj.GetType(), pk), val);
		}
		
		/// <summary>
		/// Create an instance of the templated class using the default, zero-argument constructor
		/// </summary>
		/// <returns>An instance of the class</returns>
		public static T InstanceOf<T>()
		{
			Type type = typeof(T);
			ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);
			T instance = (T)info.Invoke(new object[0]);
			return instance;
		}
		
		/// <summary>
		/// Get the class property name for the given database column in a table
		/// </summary>
		/// <param name="type">The table type containing the column</param>
		/// <param name="columnName">The name of the column</param>
		/// <returns>The name of the property holding this column</returns>
		public static string GetPropertyForColumn(Type type, string columnName)
		{
			foreach (PropertyInfo prop in type.GetProperties()) {
				foreach (Attribute attr in prop.GetCustomAttributes(true)) {
					ColumnAttribute ca = attr as ColumnAttribute;
					if (ca != null) {
						if (ca.Name == columnName || prop.Name == columnName) {
							return prop.Name;
						}
					}
				}
			}
			throw new ThormException("This object does not have a property that maps to column " + columnName + "!");
		}
		
		/// <summary>
		/// Get the class property value for the given database column in a table
		/// </summary>
		/// <param name="obj">The table object containing the column</param>
		/// <param name="columnName">The name of the column</param>
		/// <returns>The value of the property holding this column</returns>
		public static object GetPropertyValueForColumn(object obj, string columnName)
		{
			string propName = GetPropertyForColumn(obj.GetType(), columnName);
			PropertyInfo prop = obj.GetType().GetProperty(propName);
			if (prop != null) {
				return prop.GetValue(obj, null);
			}
			throw new ThormException("This object does not have a property that maps to column " + columnName + "!");
		}
		
		/// <summary>
		/// Get all the column names of the given type
		/// </summary>
		/// <param name="type">The table type to get the column names of</param>
		/// <returns>A list of all the column names of the type</returns>
		public static List<string> ColumnNamesOf(Type type)
		{
			List<string> cols = new List<string>();
			foreach (PropertyInfo prop in type.GetProperties()) {
				foreach (Attribute attr in prop.GetCustomAttributes(true)) {
					ColumnAttribute ca = attr as ColumnAttribute;
					if (ca != null) {
						cols.Add(ca.Name ?? prop.Name);
					}
				}
			}
			return cols;
		}
		
		/// <summary>
		/// Set the values of columns in a given object
		/// </summary>
		/// <param name="obj">The object to set the column values of</param>
		/// <param name="values">A dictionary of column names mapping to values</param>
		public static void SetColumnNames<T>(T obj, Dictionary<string, object> values)
		{
			Type type = typeof(T);
			
			foreach (KeyValuePair<string, object> kv in values) {
				try {
					string propname = Mirror.GetPropertyForColumn(typeof(T), kv.Key);
					PropertyInfo prop = type.GetProperty(propname);
					if (prop != null) {
						prop.SetValue(obj, DataTypeMapping.CastObjectTo(prop.PropertyType, kv.Value), null);
					}
				} catch (ThormException) {
					// Don't map this column
				}
			}
		}
		
		/// <summary>
		/// Hash a string using the MD5 hashing algoritm
		/// </summary>
		/// <param name="unencrypted">The unhashed string to encrypt</param>
		/// <returns>The string hashed with MD5</returns>
		public static string MD5(string unencrypted)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] hash = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(unencrypted));
			StringBuilder hex = new StringBuilder();
			foreach (byte b in hash) {
				hex.Append(b.ToString("X2"));
			}
			return hex.ToString();
		}
		
		/// <summary>
		/// Serialise the columns of an object to uniquely identify it
		/// </summary>
		/// <param name="obj">The object to serialise</param>
		/// <returns>A string containing the serialised object</returns>
		public static string SerializeColumns(object obj)
		{
			StringBuilder b = new StringBuilder("ThormSerializedObject;");
			Type type = obj.GetType();
			foreach (PropertyInfo prop in type.GetProperties()) {
				foreach (Attribute attr in prop.GetCustomAttributes(true)) {
					ColumnAttribute ca = attr as ColumnAttribute;
					if (ca != null) {
						object val = prop.GetValue(obj, null);
						string tostr = (val == null) ? "NULL" : val.ToString();
						b.Append(ca.Name ?? prop.Name);
						b.Append("-");
						b.Append(MD5(tostr));
						b.Append(";");
					}
				}
			}
			return b.ToString();
		}
		
		/// <summary>
		/// Make sure that the 'storage' field of a relationship is the proper type
		/// and initialise it if it is not already initialised.
		/// </summary>
		/// <param name="obj">The object with the field to check</param>
		/// <param name="storageField">The info of the field to check</param>
		/// <returns></returns>
		private static bool CheckStorageField(object obj, FieldInfo storageField)
		{
			if (storageField == null) {
				return false;
			}
			if (!storageField.FieldType.IsGenericType) {
				return false;
			}
			if (storageField.FieldType.GetGenericTypeDefinition() != typeof(One<>) && storageField.FieldType.GetGenericTypeDefinition() != typeof(Many<>)) {
				return false;
			}
			object storageInstance = storageField.GetValue(obj);
			// Instantiate the storage field if it isn't already
			if (storageInstance == null) {
				storageField.SetValue(obj, storageField.FieldType.GetConstructor(System.Type.EmptyTypes).Invoke(new object[0]));
			}
			return true;
		}
		
		/// <summary>
		/// Set the property of an object
		/// </summary>
		/// <param name="obj">The object with the property to set</param>
		/// <param name="propertyName">The name of the property to set</param>
		/// <param name="value">The value to set the property to</param>
		private static void SetProperty(object obj, string propertyName, object value)
		{
			Type type = obj.GetType();
			PropertyInfo prop = type.GetProperty(propertyName);
			if (prop != null) {
				prop.SetValue(obj, value, null);
			}
		}
		
		/// <summary>
		/// Create the relations of an object and associate them
		/// with the given database
		/// </summary>
		/// <param name="obj">The object to create relations on</param>
		/// <param name="db">The database to associate the relations with</param>
		public static void CreateRelations(object obj, Database db)
		{
			Type type = obj.GetType();
			foreach (PropertyInfo prop in type.GetProperties()) {
				foreach (Attribute attr in prop.GetCustomAttributes(true)) {
					OneAttribute oa = attr as OneAttribute;
					ManyAttribute ma = attr as ManyAttribute;
					if (oa != null) {
						//find the storage instance
						string storage = oa.Storage ?? prop.Name.ToLower();
						FieldInfo storageField = type.GetField(storage, BindingFlags.NonPublic | BindingFlags.Instance);
						if (!CheckStorageField(obj, storageField)) {
							throw new ThormException("Storage field " + storage + " is invalid in " + type.Name + " : " + prop.Name);
						}
						// Set the relevant properties of the storage field
						object storageInstance = storageField.GetValue(obj);
						string thiskey = oa.ThisKey ?? PrimaryKeyOf(type);
						string otherkey = oa.OtherKey ?? PrimaryKeyOf(prop.PropertyType);
						SetProperty(storageInstance, "ThisKey", thiskey);
						SetProperty(storageInstance, "OtherKey", otherkey);
						SetProperty(storageInstance, "Storage", storage);
						SetProperty(storageInstance, "Parent", obj);
						SetProperty(storageInstance, "Database", db);
						db.AttachRelation(storageInstance as Relationship);
					}
					if (ma != null) {
						//find the storage instance
						string storage = ma.Storage ?? prop.Name.ToLower();
						FieldInfo storageField = type.GetField(storage, BindingFlags.NonPublic | BindingFlags.Instance);
						if (!CheckStorageField(obj, storageField)) {
							throw new ThormException("Storage field " + storage + " is invalid in " + type.Name + " : " + prop.Name);
						}
						Type gentype = prop.PropertyType.GetGenericArguments()[0];
						// Set the relevant properties of the storage field
						object storageInstance = storageField.GetValue(obj);
						string thiskey = ma.ThisKey ?? PrimaryKeyOf(type);
						string otherkey = ma.OtherKey ?? PrimaryKeyOf(gentype);
						string mykey = ma.MyKey ?? type.Name + PrimaryKeyOf(type);
						string theirkey = ma.TheirKey ?? gentype.Name + PrimaryKeyOf(gentype);
						string through = ma.Through;
						SetProperty(storageInstance, "ThisKey", thiskey);
						SetProperty(storageInstance, "OtherKey", otherkey);
						SetProperty(storageInstance, "MyKey", mykey);
						SetProperty(storageInstance, "TheirKey", theirkey);
						SetProperty(storageInstance, "Through", through);
						SetProperty(storageInstance, "Storage", storage);
						SetProperty(storageInstance, "Parent", obj);
						SetProperty(storageInstance, "Database", db);
						db.AttachRelation(storageInstance as Relationship);
					}
				}
			}
		}
		
		/// <summary>
		/// Break the relations of an object and remove the
		/// associations it has with the given database
		/// </summary>
		/// <param name="obj">The object to destroy relations on</param>
		/// <param name="db">The database to remove the associations from</param>
		public static void DestroyRelations(object obj, Database db)
		{
			Type type = obj.GetType();
			foreach (FieldInfo field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)) {
				if (!field.FieldType.IsGenericType) continue;
				if (field.FieldType.GetGenericTypeDefinition() != typeof(One<>)
				    && field.FieldType.GetGenericTypeDefinition() != typeof(Many<>)) continue;
				object inst = field.GetValue(obj);
				db.DetachRelation(inst as Relationship);
			}
		}
	}
}
