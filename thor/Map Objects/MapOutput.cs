/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 4/01/2009
 * Time: 8:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace thor
{
	/// <summary>
	/// Description of MapOutput.
	/// </summary>
	public class MapOutput
	{
		string name;
		string target;
		string input;
		string parameter;
	 	decimal delay;
	 	bool once;
		
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public string Target {
			get { return target; }
			set { target = value; }
		}
		
		public string Input {
			get { return input; }
			set { input = value; }
		}
		
		public string Parameter {
			get { return parameter; }
			set { parameter = value; }
		}
	 	
		public decimal Delay {
			get { return delay; }
			set { delay = value; }
		}
	 	
		public bool Once {
			get { return once; }
			set { once = value; }
		}
	 	
		public MapOutput()
		{
			name = "";
			target = "";
			input = "";
			parameter = "";
		 	delay = 0;
		 	once = false;
		}
		
		public MapOutput copy()
		{
			MapOutput opt = new MapOutput();
			opt.name = (string)name.Clone();
			opt.target = (string)target.Clone();
			opt.input = (string)input.Clone();
			opt.parameter = (string)parameter.Clone();
			opt.delay = delay;
			opt.once = once;
			return opt;
		}
	}
}
