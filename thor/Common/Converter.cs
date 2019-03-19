/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 8/01/2009
 * Time: 12:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace thor
{
	/// <summary>
	/// Description of Converter.
	/// </summary>
	public static class Converter
	{
		public static DecimalCoordinate[][] planesToVertices(DecimalPlane[] sides)
		{
			int numsides = sides.Length;
			List<List<DecimalCoordinate>> itemarray = new List<List<DecimalCoordinate>>();
			for (int i = 0; i < numsides; i++) {
				itemarray.Add(new List<DecimalCoordinate>());
			}
			//iterate over all plane combinations
			for(int i = 0; i < numsides; i++)
			{
				for(int j = 0; j < numsides; j++)
				{
					for(int k = 0; k < numsides; k++)
					{
						//if the planes are not the same
						if(i != j && i != k && j != k)
						{
							//find if the planes intersect
							//and the intersection is inside valid bounds
							DecimalCoordinate c;
							bool itsn = getIntersect(sides[i],sides[j],sides[k], out c);
							c = c.round(8);
							if (itsn && inBounds(c))
							{
								bool legal = true;
								// Make sure the new vector is in the brush.
								for(int l = 0; l < numsides; l++)
								{
									// Don't check the planes that make up the vector.
									if(l != i && l != j && l != k)
									{
										DecimalPlane p = sides[l];
										if ((p.getNormal().dot(c) + p.getDist()) < 0)
										{
											legal = false;
											break;
										}
									}
								}
								if (legal)
								{
									if (!itemarray[i].Contains(c)) itemarray[i].Add(c);
									if (!itemarray[j].Contains(c)) itemarray[j].Add(c);
									if (!itemarray[k].Contains(c)) itemarray[k].Add(c);
								}
							}
						}
					}
				}
			}
			
			int cnt = 0;
			// Get the origin of the brush by averaging all vectors in all faces.
			DecimalCoordinate origin = new DecimalCoordinate(0,0,0);
			for(int i = 0; i < numsides; i++)
			{
				List<DecimalCoordinate> tempverts = itemarray[i];
				for(int j = 0; j < tempverts.Count; j++)
				{
					cnt++;
					origin += tempverts[j];
				}
			}
			origin /= cnt;
			
			DecimalCoordinate[][] ret = new DecimalCoordinate[numsides][];
			
			for(int i = 0; i < numsides; i++)
			{
				//try {
					//sort and arrange clockwise
					DecimalCoordinate[] temp = sortVertices(itemarray[i].ToArray(), sides[i].getNormal());
					temp = arrangeCCW(origin, temp);
					ret[i] = new DecimalCoordinate[temp.Length];
					for (int j = 0; j < temp.Length; j++) {
						ret[i][j] = temp[j];
					}
				//}
				//catch (Exception e) {
				//	//
				//	System.Windows.Forms.MessageBox.Show(e.Message);
				//}
			}
						
			return ret;
		}
		
		public static bool getIntersect(DecimalPlane p1, DecimalPlane p2, DecimalPlane p3, out DecimalCoordinate output)
		{
			DecimalCoordinate n1 = p1.getNormal();
			decimal d1 = -p1.getDist();
			DecimalCoordinate n2 = p2.getNormal();
			decimal d2 = -p2.getDist();
			DecimalCoordinate n3 = p3.getNormal();
			decimal d3 = -p3.getDist();
			
			DecimalCoordinate c1 = n2.cross(n3);
			DecimalCoordinate c2 = n3.cross(n1);
			DecimalCoordinate c3 = n1.cross(n2);
			
			output = c1;
			
			decimal denom = n1.dot(c1);
			if ( denom < 0.001m ) return false;
			
			output = ((c1 * d1) + (c2 * d2) + (c3 * d3)) / denom;
			
			return true;
		}
		
		private static bool inBounds(DecimalCoordinate c)
		{
			int bound_min = -16384;
			int bound_max = 16384;
			if(c.X < bound_min || c.X > bound_max) return false;
			if(c.Y < bound_min || c.Y > bound_max) return false;
			if(c.Z < bound_min || c.Z > bound_max) return false;
			return true;
		}
		
		private static DecimalCoordinate[] reverseCoordinateArray(DecimalCoordinate[] verts)
		{
			DecimalCoordinate[] newverts = (DecimalCoordinate[])verts.Clone();
			Array.Reverse(newverts);
			return newverts;
		}
		
		private static DecimalCoordinate[] arrangeCCW(DecimalCoordinate origin, DecimalCoordinate[] verts)
		{
			if (verts.Length < 3) return null;
			DecimalCoordinate faceorigin = makeOrigin(verts);
			
			DecimalCoordinate va = verts[0];
			DecimalCoordinate vb = verts[1];
			DecimalCoordinate vz = verts[verts.Length - 1];
			
			DecimalCoordinate ma = faceorigin - va;
			DecimalCoordinate mb = faceorigin - vb;
			DecimalCoordinate mz = faceorigin - vz;
			
			DecimalCoordinate mab = ((ma.cross(mb)).normalise() + faceorigin);
			DecimalCoordinate maz = ((ma.cross(mz)).normalise() + faceorigin);
			
			mb = origin - mab;
			mz = origin - maz;
			
			if (mb.vectorMagnitude() > mz.vectorMagnitude()) verts = reverseCoordinateArray(verts);
			
			return verts;
		}
		
		private static DecimalCoordinate makeOrigin(DecimalCoordinate[] verts)
		{
			DecimalCoordinate orig = new DecimalCoordinate(0,0,0);
			for(int i = 0; i < verts.Length; i++) orig += verts[i];
			decimal oinv = 1.0m / verts.Length;
			orig *= oinv;
			return orig;
		}
		
		private static DecimalCoordinate[] sortVertices(DecimalCoordinate[] verts, DecimalCoordinate normal)
		{
			int smallestindex;
			decimal smallestangle,tempangle;
			DecimalCoordinate origin = makeOrigin(verts);
			DecimalCoordinate temp;
			
			for (int i = 0; i < verts.Length - 2; i++) {
				smallestindex = -1;
				smallestangle = -1;
				DecimalCoordinate tempa = (verts[i] - origin).normalise();
				for (int j = 0; j < verts.Length; j++) {
					DecimalCoordinate tempb = (verts[j] - origin).normalise();
					//3 = 360 deg, 2 = 270, 1 = 180, 0 = 90, -1 = 0
					tempangle = tempa.dot(tempb);
					if (((tempa.cross(tempb)).dot(normal)) < 0) tempangle += 2;
					if (tempangle > smallestangle) {
						smallestangle = tempangle;
						smallestindex = j;
					}
				}
				
				if (smallestindex != i+1 && smallestindex != -1) {
					temp = verts[i+1];
					verts[i+1] = verts[smallestindex];
					verts[smallestindex] = temp;
				}
			}
			return verts;
		}
	}
}
