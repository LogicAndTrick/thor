/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 22/02/2009
 * Time: 6:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using OpenTK.Graphics.OpenGL;

namespace thor
{
	/// <summary>
	/// Description of Rotation.
	/// </summary>
	public class Rotation : UnitTransformation
	{
		
		private Axis rotateAround;
		private decimal rotateAngle;
		private DecimalCoordinate transformx;
		private DecimalCoordinate transformy;
		private DecimalCoordinate transformz;
		
		public Rotation(decimal angle, Axis axis)
		{
			rotateAround = axis;
			rotateAngle = angle;
			Prepare();
		}
		
		public Rotation(decimal angle, Orientation2D orientation)
		{
			switch (orientation) {
				case Orientation2D.XY:
					rotateAround = Axis.Z;
					break;
				case Orientation2D.XZ:
					rotateAround = Axis.Y;
					break;
				case Orientation2D.YZ:
					rotateAround = Axis.X;
					break;
			}
			rotateAngle = angle;
			Prepare();
		}
		
		private void Prepare()
		{
			decimal cs = (decimal)Math.Cos((double)rotateAngle);
			decimal sn = (decimal)Math.Sin((double)rotateAngle);
			if (rotateAround == Axis.X) {
				transformx = new DecimalCoordinate(1,0,0);
				transformy = new DecimalCoordinate(0,cs,-sn);
				transformz = new DecimalCoordinate(0,sn,cs);
			}
			else if (rotateAround == Axis.Y) {
				transformx = new DecimalCoordinate(cs,0,-sn);
				transformy = new DecimalCoordinate(0,1,0);
				transformz = new DecimalCoordinate(sn,0,cs);
			}
			else {
				transformx = new DecimalCoordinate(cs,-sn,0);
				transformy = new DecimalCoordinate(sn,cs,0);
				transformz = new DecimalCoordinate(0,0,1);
			}
		}
		
		public override DecimalCoordinate Operate(DecimalCoordinate c)
		{
			//do something
			DecimalCoordinate ret = c.Clone();
			ret.X = c.dot(transformx);
			ret.Y = c.dot(transformy);
			ret.Z = c.dot(transformz);
			return ret;
		}
	}
}
