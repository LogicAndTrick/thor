/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 15/01/2009
 * Time: 7:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace thor
{
	/// <summary>
	/// Description of MapDisplacement.
	/// </summary>
	public class MapDisplacement : MapFace
	{
		#region Class Variables
		protected int power;
		protected int resolution;
		protected DecimalCoordinate startposition;
		protected decimal elevation;
		protected bool subdiv;
		protected DecimalCoordinate[,] points;
		protected DecimalCoordinate[,] origPoints;
		protected DecimalCoordinate[,] normals;
		protected decimal[,] distances;
		protected DecimalCoordinate[,] offsetNormals;
		protected DecimalCoordinate[,] offsets;
		protected decimal[,] alphas;
		#endregion
		
		#region Properties
		public int Power {
			get { return power; }
			set {
				power = value;
				int tempres = (int)Math.Pow(2,power);
				AssignNewPoints(resolution,tempres);
				resolution = tempres;
			}
		}
		
		public DecimalCoordinate[,] Normals {
			get { return normals; }
			set { normals = value; }
		}
		
		public decimal[,] Distances {
			get { return distances; }
			set { distances = value; }
		}
		
		public DecimalCoordinate[,] OffsetNormals {
			get { return offsetNormals; }
			set { offsetNormals = value; }
		}
		
		public DecimalCoordinate[,] Offsets {
			get { return offsets; }
			set { offsets = value; }
		}
		
		public int Resolution {
			get { return resolution; }
		}
		
		public DecimalCoordinate Startposition {
			get { return startposition; }
			set { startposition = value; }
		}
		
		public decimal Elevation {
			get { return elevation; }
			set { elevation = value; }
		}
		
		public bool Subdiv {
			get { return subdiv; }
			set { subdiv = value; }
		}
		
		public DecimalCoordinate[,] OrigPoints {
			get { return origPoints; }
			set { origPoints = value; }
		}
		
		public DecimalCoordinate[,] Points {
			get { return points; }
			set { points = value; }
		}
		
		public decimal[,] Alphas {
			get { return alphas; }
			set { alphas = value; }
		}
		#endregion
		
		#region Constructor
		public MapDisplacement() : base()
		{
			power = 3;
			resolution = (int)Math.Pow(2,power);
			startposition = new DecimalCoordinate(0,0,0);
			elevation = 0;
			subdiv = false;
			int size = resolution+1;
			//----
			origPoints = new DecimalCoordinate[size,size];
			points = new DecimalCoordinate[size,size];
			normals = new DecimalCoordinate[size,size];
			offsetNormals = new DecimalCoordinate[size,size];
			offsets = new DecimalCoordinate[size,size];
			alphas = new decimal[size,size];
			distances = new decimal[size,size];
		}
		#endregion
		
		#region Vertices
		public override void addVertex(DecimalCoordinate c)
		{
			if (vertices.Count + 1 > 4) {
				throw new MapObjectException("5-vertex displacement? No, that doesn't happen.");
			}
			base.addVertex(c);
			if (vertices.Count == 4) {
				calculatePointsFromNormals();
			}
		}
		
		public override void addVertices(params DecimalCoordinate[] coords)
		{
			if (vertices.Count + coords.Length > 4) {
				throw new MapObjectException("5-vertex displacement? No, that doesn't happen.");
			}
			base.addVertices(coords);
			if (vertices.Count == 4) {
				calculatePointsFromNormals();
			}
		}
		#endregion
		
		#region Transformation
		public override void applyTransformation(CoordinateTransformation transform)
		{
			base.applyTransformation(transform);
			startposition = transform.Operate(startposition);
			int size = resolution + 1;
			for (int i = 0; i < size; i++) {
				for (int j = 0; j < size; j++) {
					origPoints[i,j] = transform.Operate(origPoints[i,j]);
					points[i,j] = transform.Operate(points[i,j]);
				}
			}
			calculateNormalsFromPoints();
		}
		#endregion
		
		#region Point Calculations
		private void AssignNewPoints(int oldres, int newres)
		{
			//TODO: approximate new point values instead of zeroing
			int size = newres+1;
			origPoints = new DecimalCoordinate[size,size];
			points = new DecimalCoordinate[size,size];
			normals = new DecimalCoordinate[size,size];
			offsetNormals = new DecimalCoordinate[size,size];
			offsets = new DecimalCoordinate[size,size];
			alphas = new decimal[size,size];
			distances = new decimal[size,size];
			if (vertices.Count == 4) {
				calculatePointsFromNormals();
			}
		}
		
		private void calculatePointsFromNormals()
		{
			MapVertex start = new MapVertex(startposition);
			if (!vertices.Contains(start)) {
				throw new MapObjectException("Starting poing of a displacement must be one of the face's corners!");
			} else if (vertices.Count != 4) {
				throw new MapObjectException("Displacement has the incorrect number of points.");
			}
			int index = vertices.IndexOf(start);
			DecimalCoordinate[] corners = new DecimalCoordinate[4];
			for (int i = 0; i < 4; i++) {
				corners[i] = vertices[(index + i) % 4].Location;
			}
			int size = resolution + 1;
			DecimalCoordinate diff1 = (corners[1] - corners[0]) / resolution;
			DecimalCoordinate diff2 = (corners[2] - corners[3]) / resolution;
			DecimalCoordinate addElevation = plane.getNormal() * elevation;
			for (int i = 0; i < size; i++) {
				DecimalCoordinate startrow = startposition + i * diff1;
				DecimalCoordinate endrow = corners[3] + i * diff2;
				DecimalCoordinate diff3 = (endrow - startrow) / resolution;
				for (int j = 0; j < size; j++) {
					origPoints[i,j] = startrow + (j * diff3);
					points[i,j] = origPoints[i,j];		//Point if no displacement was applied
					points[i,j] += addElevation;		//Add elevation
					points[i,j] += offsets[i,j];		//Add offsets
					points[i,j] += normals[i,j].normalise() * distances[i,j]; //Apply the displacement
				}
			}
		}
		
		private void calculateNormalsFromPoints()
		{
			DecimalCoordinate addElevation = plane.getNormal() * elevation;
			int size = resolution + 1;
			for (int i = 0; i < size; i++) {
				for (int j = 0; j < size; j++) {
					DecimalCoordinate temp = points[i,j] - offsets[i,j] - addElevation;
					DecimalCoordinate diff = temp - origPoints[i,j];
					normals[i,j] = diff.normalise();
					distances[i,j] = diff.vectorMagnitude();
				}
			}
		}
		#endregion
		
		#region Copy
		public override MapFace copy(CoordinateTransformation transform)
		{
			MapDisplacement fac = new MapDisplacement();
			fac.texture = (string)texture.Clone();
			fac.vaxis = vaxis.copy();
			fac.uaxis = uaxis.copy();
			fac.rotation = rotation;
			fac.uscale = uscale;
			fac.vscale = vscale;
			fac.power = power;
			fac.resolution = resolution;
			fac.startposition = startposition.Clone();
			fac.elevation = elevation;
			fac.subdiv = subdiv;
			foreach (MapVertex v in vertices) fac.addVertex(v.Location.Clone());
			for (int i = 0; i < resolution + 1; i++) {
				for (int j = 0; j < resolution + 1; j++) {
					fac.points[i,j] = points[i,j].Clone();
					fac.origPoints[i,j] = origPoints[i,j].Clone();
					fac.normals[i,j] = normals[i,j].Clone();
					fac.offsetNormals[i,j] = offsetNormals[i,j].Clone();
					fac.offsets[i,j] = offsets[i,j].Clone();
					fac.distances[i,j] = distances[i,j];
					fac.alphas[i,j] = alphas[i,j];
				}
			}
			fac.applyTransformation(transform);
			fac.reCalc2D();
			return fac;
		}
		#endregion
	}
}
