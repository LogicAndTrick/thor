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
	/// Description of Scale.
	/// </summary>
	public class Scale : UnitTransformation
	{
		DecimalCoordinate scaleBy;
		DecimalCoordinate scaleRel;
		public Scale(DecimalCoordinate sizes, DecimalCoordinate relative)
		{
			scaleBy = sizes;
			scaleRel = relative;
		}
		
		public override DecimalCoordinate Operate(DecimalCoordinate c)
		{
			//do something
			/*
				DecimalCoordinate origCorner = getBBox().BottomLeftLow.Clone();
				for (int i = 0; i < vertices.Count; i++) vertices[i] = vertices[i].componentMultiply(scale);
				DecimalCoordinate newCorner = getBBox().BottomLeftLow.Clone();
				translation -= (newCorner - origCorner) - ((origCorner - relative).componentMultiply(scale) - (origCorner - relative));
			*/
			DecimalCoordinate tmp = c.componentMultiply(scaleBy);
			DecimalCoordinate ret = tmp.Clone();
			DecimalCoordinate distToRel = c - scaleRel;
			ret -= (tmp - c) - (distToRel.componentMultiply(scaleBy) - distToRel);
			return ret;
		}
	}
}
