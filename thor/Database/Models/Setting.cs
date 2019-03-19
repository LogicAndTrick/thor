/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 1/11/2009
 * Time: 10:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Thorm;

namespace thor.Models
{
	/// <summary>
	/// Description of Setting.
	/// </summary>
	[Table(Name="Settings")]
	public class Setting
	{
		public Setting()
		{
		}
		
		private int? id;
		private string key;
		private string val;
		
		[Column(Name="settingID"), PrimaryKey]
		public int? ID {
			get { return id; }
			set { id = value; }
		}
		
		[Column(Name="settingKey")]
		public string Key {
			get { return key; }
			set { key = value; }
		}
		
		[Column(Name="settingValue")]
		public string Val {
			get { return val; }
			set { val = value; }
		}
		
	}
}
