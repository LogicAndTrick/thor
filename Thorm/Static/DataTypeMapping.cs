/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/10/2009
 * Time: 12:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// Maps data types to 'Thorm-safe' types
	/// </summary>
	public static class DataTypeMapping
	{
		/// <summary>
		/// Cast the given object to the required type.
		/// </summary>
		/// <param name="type">The type to cast to</param>
		/// <param name="obj">The object to cast</param>
		/// <returns>The object, in the required type.</returns>
		public static object CastObjectTo(Type type, object obj)
		{
			object ret = obj;
			// Use this for nullable types
			if (type.IsGenericType) type = type.GetGenericArguments()[0];
			
			string objstr = obj.ToString();
			
			     if (type == typeof(int)) 		ret = int.Parse(objstr);
			else if (type == typeof(decimal)) 	ret = decimal.Parse(objstr);
			else if (type == typeof(DateTime)) 	ret = DateTime.Parse(objstr);
			else if (type == typeof(string)) 	ret = objstr;
			return ret;
		}
	}
}
