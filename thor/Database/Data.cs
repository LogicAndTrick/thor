/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 1/11/2009
 * Time: 9:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;

using Thorm;
using Thorm.SQLite;

namespace thor
{
	/// <summary>
	/// Description of Database.
	/// </summary>
	public sealed class Data
	{
		private static Data instance = new Data();
		
		public static Data Instance {
			get {
				return instance;
			}
		}
		
		private Database db;
		
		public static Database DB {
			get { return instance.db; }
		}
		
		private Data()
		{
			string dir = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"settings.db3");
			string conn = "Data Source=" + dir + ";Pooling=true;FailIfMissing=false";
			db = new SQLiteDatabase(conn);
		}
	}
}
