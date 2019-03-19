/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 11/10/2008
 * Time: 5:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace thor
{
	public class MapEntityData
	{
		string name;
		int flags;
		List<MapProperty> properties;
		List<MapOutput> outputs;
		
		public List<MapProperty> Properties {
			get { return properties; }
		}
		
		public List<MapOutput> Outputs {
			get { return outputs; }
			set { outputs = value; }
		}
		
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public int Flags {
			get { return flags; }
			set { flags = value; }
		}
		
		public void addProperty(MapProperty mp)
		{
			properties.Add(mp);
		}
		
		public MapProperty getProperty(string propkey)
		{
			foreach (MapProperty p in properties) {
				if (p.Key == propkey) return p;
			}
			return null;
		}
		
		public void addOutput(MapOutput mo)
		{
			outputs.Add(mo);
		}
		
		public MapOutput getOutput(string outname)
		{
			foreach (MapOutput o in outputs) {
				if (o.Name == outname) return o;
			}
			return null;
		}
		
		public MapEntityData()
		{
			name = "";
			flags = 0;
			properties = new List<MapProperty>();
			outputs = new List<MapOutput>();
		}
		
		public MapEntityData copy()
		{
			MapEntityData dat = new MapEntityData();
			dat.name = name;
			dat.flags = flags;
			foreach (MapProperty p in properties) dat.addProperty(p.copy());
			foreach (MapOutput ot in outputs) dat.addOutput(ot.copy());
			return dat;
		}
	}
}
