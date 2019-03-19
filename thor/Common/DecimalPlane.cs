/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 10/08/2008
 * Time: 11:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace thor
{
	/// <summary>
	/// Description of DecimalPlane.
	/// </summary>
	public class DecimalPlane
	{
		DecimalCoordinate point1;
		DecimalCoordinate point2;
		DecimalCoordinate point3;
		DecimalCoordinate normal;
		decimal dist;
		// ax + by + cz + d = 0;
		decimal a;
		decimal b;
		decimal c;
		decimal d;
		
		public decimal A {
			get { return a; }
		}
		
		public decimal B {
			get { return b; }
		}
		
		public decimal C {
			get { return c; }
		}
		
		public decimal D {
			get { return d; }
		}
		
		public DecimalPlane(DecimalCoordinate p1, DecimalCoordinate p2, DecimalCoordinate p3)
		{
			point1 = p1;
			point2 = p2;
			point3 = p3;
			
			DecimalCoordinate ab = p1 - p2;
			DecimalCoordinate ac = p1 - p3;
			DecimalCoordinate crossed = ab.cross(ac);
			
			a = crossed.X;
			b = crossed.Y;
			c = crossed.Z;
			d = -(crossed.dot(p1));
			
			normal = ((p3 - p2).cross(p1 - p2)).normalise();
			dist = -1 * (normal.dot(p2));
		}
		
		public DecimalPlane(DecimalCoordinate norm, decimal distance)
		{
			a = norm.X;
			b = norm.Y;
			c = norm.Z;
			d = -distance;
			
			normal = norm.normalise();
			dist = distance;
			
			//TODO: points
		}
		
		/// <summary>
		/// Get the normal vector to the plane
		/// </summary>
		/// <returns>The normal of the plane</returns>
		public DecimalCoordinate getNormal()
		{
			return normal;
		}
		
		/// <summary>
		/// Get the distance from the plane to the origin
		/// </summary>
		/// <returns>The distance value of the plane</returns>
		public decimal getDist()
		{
			return dist;
		}
		
		public bool containsCorner(DecimalCoordinate co)
		{
			bool con = false;
			if (co.Equals(point1)) con = true;
			if (co.Equals(point2)) con = true;
			if (co.Equals(point3)) con = true;
			return con;
		}
		
		public DecimalCoordinate getCoordinate(int i)
		{
			if (i == 1) return point1.Clone();
			if (i == 2) return point2.Clone();
			if (i == 3) return point3.Clone();
			return new DecimalCoordinate(0,0,0);
		}
		
		/// <summary>
		/// Gets the general direction the plane is facing in.
		/// </summary>
		/// <returns>
		/// 1 if the X direction is dominant<br />
		/// 2 if the Y direction is dominant<br />
		/// 3 if the Z direction is dominant
		/// </returns>
		public int generalFacing()
		{
			DecimalCoordinate norm = getNormal().absolute().normalise();
			
			if (norm.Y > norm.X && norm.Y > norm.Z) return 2;
			else if (norm.X > norm.Z) return 1;
			else return 3;
		}
		
		/// <summary>
		/// Finds if the given point is above, below, or on the plane.
		/// </summary>
		/// <param name="co">The coordinate to test</param>
		/// <returns>
		/// value &lt; 0 if coordinate is below the plane<br />
		/// value &gt; 0 if coordinate is above the plane<br />
		///   value == 0 if coordinate is on the plane.
		///</returns>
		public int onPlane(DecimalCoordinate co)
		{
			//eval (s = Ax + By + Cz + D) at point (x,y,z)
			//if s > 0 then point is "above" the plane (same side as normal)
			//if s < 0 then it lies on the opposite side
			//if s = 0 then the point (x,y,z) lies on the plane
			decimal res = evalAtPoint(co);
			if (Math.Abs(res) < 0.001m) return 0;
			else if (res < 0) return -1;
			else return 1;
		}
		
		public decimal evalAtPoint(DecimalCoordinate co)
		{
			return a * co.X + b * co.Y + c * co.Z + d;
		}
		
		public DecimalCoordinate intersectLine(DecimalCoordinate start, DecimalCoordinate finish)
		{
			return intersectLine(start, finish, false, false);
		}
		
		public DecimalCoordinate intersectLine(DecimalCoordinate start, DecimalCoordinate finish, bool doubleSided)
		{
			return intersectLine(start, finish, doubleSided, false);
		}
		
		public DecimalCoordinate intersectLine(DecimalCoordinate start, DecimalCoordinate finish, bool doubleSided, bool ignoreSegment)
		{
			DecimalCoordinate direction = finish - start;
			DecimalCoordinate normal = getNormal();
			
			decimal denom = normal.dot(direction);
			// If denom is 0, line is parallel to plane
			// If denom is < 0, line is exiting the plane, not entering it
			if (Math.Abs(denom) < 0.001m || (!doubleSided && denom < 0.001m)) return null;
			
			DecimalCoordinate p3p1 = (point1 - start);
			decimal numer = normal.dot(p3p1);
			
			// If u is not between 0 and 1, it means that the line intersects,
			// But the segment between start and finish doesn't.
			// This is needed so we don't accidentally select things behind the camera.
			decimal u = numer / denom;
			if (!ignoreSegment && (u < 0 || u > 1)) return null;
			
			return start + u * direction;
		}
		
		public override string ToString()
		{
			return point1.ToString() + " " + point2.ToString() + " " + point3.ToString();
		}
		
		public string ToString(bool b)
		{
			return "( " + point1.ToString(b) + " ) ( " + point2.ToString(b) + " ) ( " + point3.ToString(b) + " )";
		}
		
		public DecimalPlane copy()
		{
			return new DecimalPlane(getNormal(), getDist());
		}
	}
}
