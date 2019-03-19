/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 8/08/2009
 * Time: 10:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace thor
{
	/// <summary>
	/// Description of AxisRotation.
	/// </summary>
	public class AxisRotation : UnitTransformation
	{
		DecimalCoordinate[] matrix;
		
		public AxisRotation(decimal angle, DecimalCoordinate axis)
		{
			/*
			http://www.euclideanspace.com/maths/algebra/matrix/transforms/index.htm
			t*x*x + c  		t*x*y - z*s  	t*x*z + y*s
			t*x*y + z*s 	t*y*y + c 		t*y*z - x*s
			t*x*z - y*s 	t*y*z + x*s 	t*z*z + c
			
			
			c = cos(angle)
			s = sin(angle)
			t = 1 - c
			*/
			
			decimal c = (decimal)Math.Cos((double)angle);
			decimal s = (decimal)Math.Sin((double)angle);
			decimal t = 1 - c;
			
			decimal x = axis.X;
			decimal y = axis.Y;
			decimal z = axis.Z;
			
			decimal txx = x * x * t;
			decimal txy = x * y * t;
			decimal txz = x * z * t;
			decimal tyy = y * y * t;
			decimal tyz = y * z * t;
			decimal tzz = z * z * t;
			
			decimal xs = x * s;
			decimal ys = y * s;
			decimal zs = z * s;
			
			
			matrix = new DecimalCoordinate[] {
				new DecimalCoordinate(txx + c,  txy - zs, txz + ys),
				new DecimalCoordinate(txy + zs, tyy + c,  tyz - xs),
				new DecimalCoordinate(txz - ys, tyz + xs, tzz + c)
			};
		}
		
		public override DecimalCoordinate Operate(DecimalCoordinate c)
		{
			return new DecimalCoordinate(matrix[0].dot(c),
			                             matrix[1].dot(c),
			                             matrix[2].dot(c));
		}
	}
}
