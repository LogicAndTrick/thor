/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 22/02/2009
 * Time: 6:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace thor
{
	/// <summary>
	/// Description of Skew.
	/// </summary>
	public class Skew : UnitTransformation
	{
		private Axis skewOn;
		private Axis skewRespectTo;
		private decimal skewAmount;
		private DecimalCoordinate bottomCorner;
		private DecimalCoordinate topCorner;
		
		public Skew(decimal amount, Axis axis, Axis respect, DecimalCoordinate bottom, DecimalCoordinate top)
		{
			skewOn = axis;
			skewRespectTo = respect;
			skewAmount = amount;
			bottomCorner = bottom;
			topCorner = top;
			Prepare();
		}
		
		public Skew(decimal amount, Orientation2D orientation, BoxTool.ResizeHandle handle, DecimalCoordinate bottom, DecimalCoordinate top)
		{
			Axis skewVert;
			Axis skewHor;
			switch (orientation) {
				case Orientation2D.XY:
					skewVert = Axis.X;
					skewHor = Axis.Y;
					break;
				case Orientation2D.XZ:
					skewVert = Axis.X;
					skewHor = Axis.Z;
					break;
				case Orientation2D.YZ:
					skewVert = Axis.Y;
					skewHor = Axis.Z;
					break;
				default:
					throw new Exception("No orientation defined!");
			}
			switch (handle) {
				case OldSelectTool.ResizeHandle.BottomCentre:
				case OldSelectTool.ResizeHandle.TopCentre:
					skewOn = skewVert;
					skewRespectTo = skewHor;
					break;
				case OldSelectTool.ResizeHandle.CentreLeft:
				case OldSelectTool.ResizeHandle.CentreRight:
					skewOn = skewHor;
					skewRespectTo = skewVert;
					break;
				default:
					throw new Exception("Can't skew on that handle.");
			}
			skewAmount = amount;
			bottomCorner = bottom;
			topCorner = top;
			Prepare();
		}
		
		private decimal distance;
		private DecimalCoordinate distMultiply;
		
		private void Prepare()
		{
			DecimalCoordinate distances = topCorner - bottomCorner;
			distMultiply = new DecimalCoordinate(0,0,0);
			if (skewRespectTo == Axis.X) {
				distance = distances.X;
				distMultiply.X = 1;
			}
			else if (skewRespectTo == Axis.Y) {
				distance = distances.Y;
				distMultiply.Y = 1;
			}
			else {
				distance = distances.Z;
				distMultiply.Z = 1;
			}
		}
		
		public override DecimalCoordinate Operate(DecimalCoordinate c)
		{
			//do something
			DecimalCoordinate distances = c - bottomCorner;
			DecimalCoordinate dists = new DecimalCoordinate(0,0,0);
			decimal addcoord = (distances / distance * skewAmount).dot(distMultiply);
			if (skewOn == Axis.X) {
				dists.X = addcoord;
			}
			else if (skewOn == Axis.Y) {
				dists.Y = addcoord;
			}
			else {
				dists.Z = addcoord;
			}
			return c + dists;
		}
	}
}
