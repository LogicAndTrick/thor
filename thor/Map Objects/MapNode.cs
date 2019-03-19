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
	public class MapNode
	{
		DecimalCoordinate position;
		int id;
		string name;
		List<MapProperty> properties;
		
		public List<MapProperty> Properties {
			get { return properties; }
		}
		
		public DecimalCoordinate Position {
			get { return position; }
			set { position = value; }
		}
		
		public int Id {
			get { return id; }
			set { id = value; }
		}
		
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public void addProperty(MapProperty mp)
		{
			properties.Add(mp);
		}
		
		public MapNode()
		{
			position = new DecimalCoordinate(0,0,0);
			id = 0;
			name = "";
			properties = new List<MapProperty>();
		}
		
		public MapNode copy()
		{
			MapNode node = new MapNode();
			node.position = position.Clone();
			node.id = id;
			node.name = name;
			foreach (MapProperty p in properties) node.addProperty(p.copy());
			return node;
		}
	}
}
