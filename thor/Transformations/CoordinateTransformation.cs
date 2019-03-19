/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 22/02/2009
 * Time: 6:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace thor
{
	/// <summary>
	/// Description of CoordinateTransformation.
	/// </summary>
	public class CoordinateTransformation
	{
		List<UnitTransformation> transforms;
		Random rand;
		
		public Random Rand {
			get { return rand; }
		}
		
		public CoordinateTransformation()
		{
			transforms = new List<UnitTransformation>();
			rand = new Random();
		}
		
		public void Clear()
		{
			transforms.Clear();
		}
		
		public void AddTranslation(DecimalCoordinate translation)
		{
			transforms.Add(new Translation(translation));
		}
		
		public void AddScale(DecimalCoordinate scale, DecimalCoordinate relative)
		{
			transforms.Add(new Scale(scale,relative));
		}
		
		#region Rotation
		public void AddRotationOrigin(DecimalCoordinate angles)
		{
			if (angles.X != 0) transforms.Add(new Rotation(angles.X,Axis.X));
			if (angles.Y != 0) transforms.Add(new Rotation(angles.Y,Axis.Y));
			if (angles.Z != 0) transforms.Add(new Rotation(angles.Z,Axis.Z));
		}
		
		public void AddRotationOrigin(decimal angle, Axis axis)
		{
			transforms.Add(new Rotation(angle,axis));
		}
		
		public void AddRotationOrigin(decimal angle, Orientation2D orientation)
		{
			transforms.Add(new Rotation(angle,orientation));
		}
		
		public void AddRotationPoint(DecimalCoordinate angles, DecimalCoordinate point)
		{
			AddTranslation(-point);
			AddRotationOrigin(angles);
			AddTranslation(point);
		}
		
		public void AddRotationPoint(decimal angle, Axis axis, DecimalCoordinate point)
		{
			AddTranslation(-point);
			AddRotationOrigin(angle,axis);
			AddTranslation(point);
		}
		
		public void AddRotationPoint(decimal angle, Orientation2D orientation, DecimalCoordinate point)
		{
			AddTranslation(-point);
			AddRotationOrigin(angle,orientation);
			AddTranslation(point);
		}
		
		public void AddRotationAxis(decimal angle, DecimalCoordinate axis) {
			transforms.Add(new AxisRotation(angle, axis));
		}
		#endregion
		
		public void AddSkew(decimal amount, Orientation2D orientation, BoxTool.ResizeHandle handle, DecimalCoordinate bottom, DecimalCoordinate top)
		{
			transforms.Add(new Skew(amount,orientation,handle,bottom,top));
		}
		
		public DecimalCoordinate Operate(DecimalCoordinate c)
		{
			DecimalCoordinate ret = c.Clone();
			foreach (UnitTransformation ut in transforms) ret = ut.Operate(ret).round(8);
			return ret;
		}
	}
}
