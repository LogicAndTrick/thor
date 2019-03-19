/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 5/09/2008
 * Time: 9:45 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace thor
{
	/// <summary>
	/// Description of DecimalCoordinate.
	/// </summary>
	public class DecimalCoordinate
	{
		decimal xval;
		decimal yval;
		decimal zval;
		
		double dxval;
		double dyval;
		double dzval;
		
		
		public decimal X {
			get { return xval; }
			set {
				xval = value;
				dxval = (double)value;
			}
		}
		
		public double DX {
			get { return dxval; }
		}
		
		public decimal Y {
			get { return yval; }
			set {
				yval = value;
				dyval = (double)value;
			}
		}
		
		public double DY {
			get { return dyval; }
		}
		
		public decimal Z {
			get { return zval; }
			set {
				zval = value;
				dzval = (double)value;
			}
		}
		
		public double DZ {
			get { return dzval; }
		}
		
		public DecimalCoordinate(decimal x, decimal y, decimal z)
		{
			xval = x;
			yval = y;
			zval = z;
			dxval = (double)x;
			dyval = (double)y;
			dzval = (double)z;
		}
		
		public bool Equals(DecimalCoordinate c)
		{
			bool equal = true;
			if (Math.Abs(c.getX()-xval) > 0.5m) equal = false;
			if (Math.Abs(c.getY()-yval) > 0.5m) equal = false;
			if (Math.Abs(c.getZ()-zval) > 0.5m) equal = false;
			return equal;
		}
		
		public decimal getX()
		{
			return xval;
		}
		
		public void setX(decimal x)
		{
			xval = x;
			dxval = (double)x;
		}
		
		public decimal getY()
		{
			return yval;
		}
		
		public void setY(decimal y)
		{
			yval = y;
			dyval = (double)y;
		}
		
		public decimal getZ()
		{
			return zval;
		}
		
		public void setZ(decimal z)
		{
			zval = z;
			dzval = (double)z;
		}
		
		public decimal dot(DecimalCoordinate c)
		{
			return ((this.xval * c.xval) + (this.yval * c.yval) + (this.zval * c.zval));
		}
		
		public DecimalCoordinate cross(DecimalCoordinate that)
		{
			decimal xv = (this.yval * that.zval) - (this.zval * that.yval);
			decimal yv = (this.zval * that.xval) - (this.xval * that.zval);
			decimal zv = (this.xval * that.yval) - (this.yval * that.xval);
			return new DecimalCoordinate(xv, yv, zv);
		}
		
		public DecimalCoordinate round()
		{
			return new DecimalCoordinate((decimal)Math.Round(xval,4),(decimal)Math.Round(yval,4),(decimal)Math.Round(zval,4));
		}
		
		public DecimalCoordinate round(int num)
		{
			return new DecimalCoordinate((decimal)Math.Round(xval,num),(decimal)Math.Round(yval,num),(decimal)Math.Round(zval,num));
		}
		
		public decimal vectorMagnitude()
		{
			return (decimal)Math.Sqrt(Math.Pow((double)xval,2) + Math.Pow((double)yval,2) + Math.Pow((double)zval,2));
		}
		
		public DecimalCoordinate normalise()
		{
			decimal len = this.vectorMagnitude();
			if (len == 0) return new DecimalCoordinate(0,0,0);
			return new DecimalCoordinate(xval/len,yval/len,zval/len);
		}
		
		public DecimalCoordinate absolute()
		{
			return new DecimalCoordinate(Math.Abs(xval), Math.Abs(yval), Math.Abs(zval));
		}
		
		public static bool operator ==(DecimalCoordinate c1, DecimalCoordinate c2)
		{
			decimal delta = 0.001m;
			if ((object)c1 == null || (object)c2 == null) {
				return ((object)c1 == null && (object)c2 == null);
			}
			return Math.Abs(c1.xval - c2.xval) < delta && 
				   Math.Abs(c1.yval - c2.yval) < delta &&
				   Math.Abs(c1.zval - c2.zval) < delta;
		}
		
		public static bool operator !=(DecimalCoordinate c1, DecimalCoordinate c2)
		{
			decimal delta = 0.001m;
			if ((object)c1 == null || (object)c2 == null) {
				return !((object)c1 == null && (object)c2 == null);
			}
			return Math.Abs(c1.xval - c2.xval) >= delta || 
				   Math.Abs(c1.yval - c2.yval) >= delta ||
				   Math.Abs(c1.zval - c2.zval) >= delta;
		}
		
		public override bool Equals(object obj)
		{
			if (obj is DecimalCoordinate) return (this == (DecimalCoordinate)obj);
			return base.Equals(obj);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public static DecimalCoordinate operator +(DecimalCoordinate c1,DecimalCoordinate c2)
		{
			return new DecimalCoordinate(c1.xval+c2.xval,c1.yval+c2.yval,c1.zval+c2.zval);
		}
		
		public static DecimalCoordinate operator -(DecimalCoordinate c1,DecimalCoordinate c2)
		{
			return new DecimalCoordinate(c1.xval-c2.xval,c1.yval-c2.yval,c1.zval-c2.zval);
		}
		
		public static DecimalCoordinate operator -(DecimalCoordinate c1)
		{
			return new DecimalCoordinate(-c1.xval,-c1.yval,-c1.zval);
		}
		
		public static DecimalCoordinate operator /(DecimalCoordinate c,decimal f)
		{
			if (f == 0) return new DecimalCoordinate(0,0,0);
			return new DecimalCoordinate(c.xval/f,c.yval/f,c.zval/f);
		}
		
		public static DecimalCoordinate operator *(DecimalCoordinate c,decimal f)
		{
			return new DecimalCoordinate(c.xval*f,c.yval*f,c.zval*f);
		}
		
		public static DecimalCoordinate operator *(decimal f,DecimalCoordinate c)
		{
			return c * f;
		}
		
		public DecimalCoordinate componentMultiply(DecimalCoordinate c)
		{
			return new DecimalCoordinate(this.xval*c.xval,this.yval*c.yval,this.zval*c.zval);
		}
		
		public DecimalCoordinate componentDivide(DecimalCoordinate c)
		{
			if (c.xval == 0) c.xval = 1;
			if (c.yval == 0) c.yval = 1;
			if (c.zval == 0) c.zval = 1;
			return new DecimalCoordinate(this.xval/c.xval,this.yval/c.yval,this.zval/c.zval);
		}
		
		public string ToString(bool a)
		{
			return xval.ToString("0.0000") + " " + yval.ToString("0.0000") + " " + zval.ToString("0.0000");
		}
		
		public override string ToString()
		{
			return "(" + xval.ToString("0.0000") + " " + yval.ToString("0.0000") + " " + zval.ToString("0.0000") + ")";
		}
		
		public DecimalCoordinate Clone()
		{
			return new DecimalCoordinate(xval,yval,zval);
		}
		
		public static DecimalCoordinate Parse(string s, char separator)
		{
			string[] str = s.Split(separator);
			return new DecimalCoordinate(decimal.Parse(str[0]), decimal.Parse(str[1]), decimal.Parse(str[2]));
		}
		
		public static DecimalCoordinate[] ParseMultiple(string s, char separator)
		{
			string[] str = s.Split(separator);
			int num = str.Length / 3;
			DecimalCoordinate[] ret = new DecimalCoordinate[num];
			for (int i = 0; i < num; i++) {
				ret[i] = new DecimalCoordinate(
						decimal.Parse(str[(i * 3) + 0], (System.Globalization.NumberStyles)0x00A4),
						decimal.Parse(str[(i * 3) + 1], (System.Globalization.NumberStyles)0x00A4),
						decimal.Parse(str[(i * 3) + 2], (System.Globalization.NumberStyles)0x00A4)
				);
			}
			return ret;
		}
	}
}
