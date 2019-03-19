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
	/// Description of Translation.
	/// </summary>
	public class Translation : UnitTransformation
	{
		DecimalCoordinate trans;
		public Translation(DecimalCoordinate offset)
		{
			trans = offset.Clone();
		}
		
		public override DecimalCoordinate Operate(DecimalCoordinate c)
		{
			return c + trans;
		}
	}
}
