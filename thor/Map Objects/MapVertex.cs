/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 21/08/2009
 * Time: 9:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace thor
{
	/// <summary>
	/// Description of MapVertex.
	/// </summary>
	public class MapVertex
	{
		private DecimalCoordinate location;
		decimal textureV;
		decimal textureU;
		bool selected;
		MapFace parent;
		
		public DecimalCoordinate Location {
			get { return location; }
			set { location = value; }
		}
		
		public decimal TextureV {
			get { return textureV; }
			set { textureV = value; }
		}
		
		public decimal TextureU {
			get { return textureU; }
			set { textureU = value; }
		}
		
		public bool Selected {
			get { return selected; }
			set { selected = value; }
		}
		
		public MapFace Parent {
			get { return parent; }
			set { parent = value; }
		}
		
		public MapVertex(DecimalCoordinate c)
		{
			location = c.Clone();
		}
		
		public void applyTransformation(CoordinateTransformation transform)
		{
			location = transform.Operate(location);
		}
		
		public MapVertex getLeftNeighbour()
		{
			if (parent == null) return null;
			int index = parent.Vertices.IndexOf(this);
			int nbr = index - 1;
			if (nbr < 0) nbr += parent.Vertices.Count;
			return parent.Vertices[nbr];
		}
		
		public MapVertex getRightNeighbour()
		{
			if (parent == null) return null;
			int index = parent.Vertices.IndexOf(this);
			int nbr = index + 1;
			if (nbr >= parent.Vertices.Count) nbr -= parent.Vertices.Count;
			return parent.Vertices[nbr];
		}
		
		public static bool operator ==(MapVertex v1, MapVertex v2)
		{
			return v1.location == v2.location;
		}
		
		public static bool operator !=(MapVertex v1, MapVertex v2)
		{
			return v1.location != v2.location;
		}
		
		public override bool Equals(object obj)
		{
			if (obj is MapVertex) return (obj as MapVertex).location == this.location;
			return base.Equals(obj);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public MapVertex copy()
		{
			MapVertex v = new MapVertex(location);
			v.parent = this.parent;
			v.selected = this.selected;
			v.textureU = this.textureU;
			v.textureV = this.textureV;
			return v;
		}
	}
}
