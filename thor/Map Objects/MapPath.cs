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
	public class MapPath
	{
		string name;
		string type;
		int direction;
		List<MapNode> nodes;
		
		public const int ONEWAY = 0;
		public const int CIRCULAR = 1;
		public const int PINGPONG = 2;
		
		public List<MapNode> Nodes {
			get { return nodes; }
		}
		
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public string Type {
			get { return type; }
			set { type = value; }
		}
		
		public int Direction {
			get { return direction; }
			set { direction = value; }
		}
		
		public void addNode(MapNode mn)
		{
			nodes.Add(mn);
		}
		
		public MapPath()
		{
			name = "";
			type = "";
			direction = 0;
			nodes = new List<MapNode>();
		}
		
		public MapPath copy()
		{
			MapPath path = new MapPath();
			path.name = name;
			path.type = type;
			path.direction = direction;
			foreach (MapNode n in nodes) path.addNode(n.copy());
			return path;
		}
	}
}
