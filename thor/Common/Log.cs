/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 23/02/2009
 * Time: 9:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace thor
{
	/// <summary>
	/// Description of Log.
	/// </summary>
	public static class Log
	{
		public static void LogMessage(string message)
		{
			Accessor.Instance.Main.LogMessage(message);
		}
		
		public static void DebugMessage(string message)
		{
			//if (Accessor.Instance.ThorSettings.getBool("Debug")) {
				Accessor.Instance.Main.LogMessage(message);
			//}
		}
	}
}
