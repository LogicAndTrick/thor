/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 3/08/2008
 * Time: 3:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace thor
{
	/// <summary>
	/// Description of Vector4.
	/// </summary>
	public class Vector4
	{
		decimal[] values;
		
		public decimal A {
			get { return values[0]; }
			set { values[0] = value; }
		}
		
		public decimal B {
			get { return values[1]; }
			set { values[1] = value; }
		}
		
		public decimal C {
			get { return values[2]; }
			set { values[2] = value; }
		}
		
		public decimal D {
			get { return values[3]; }
			set { values[3] = value; }
		}
		
		public Vector4()
		{
			values = new decimal[4];
		}
		
		public Vector4(decimal a, decimal b, decimal c, decimal d)
		{
			values = new decimal[] { a, b, c, d };
		}
		
		public Vector4(DecimalCoordinate coord, decimal trans)
		{
			values = new decimal[] { coord.X, coord.Y, coord.Z, trans };
		}
		
		public Vector4 copy()
		{
			return new Vector4(values[0],values[1],values[2],values[3]);
		}
		
		public DecimalCoordinate getCoordinate()
		{
			return new DecimalCoordinate(values[0], values[1], values[2]);
		}
		
		public void setCoordinate(DecimalCoordinate c)
		{
			values[0] = c.X;
			values[1] = c.Y;
			values[2] = c.Z;
		}
		
		public decimal getValue(int x)
		{
			try {
				return values[x];
			}
			catch (Exception e) {
				System.Windows.Forms.MessageBox.Show("ERROR: "+e.Message,"OH NOES");
				return 0;
			}
		}
		
		public void setValue(int x, decimal v)
		{
			try {
				values[x] = v;
			}
			catch (Exception e) {
				System.Windows.Forms.MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public override string ToString()
		{
			return "[" + values[0].ToString("0.0000") + " " + values[1].ToString("0.0000") + " " + values[2].ToString("0.0000") + " " + values[3].ToString("0.0000") + "]";
		}
		
		public string ToString(bool b)
		{
			return "[ " + values[0].ToString("0.0000") + " " + values[1].ToString("0.0000") + " " + values[2].ToString("0.0000") + " " + values[3].ToString("0.0000") + " ]";
		}
	}
}
