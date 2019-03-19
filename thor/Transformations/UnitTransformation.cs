/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 22/02/2009
 * Time: 6:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace thor
{
	/// <summary>
	/// Description of UnitTransformation.
	/// </summary>
	public abstract class UnitTransformation
	{
		public UnitTransformation()
		{
		}
		
		public abstract DecimalCoordinate Operate(DecimalCoordinate c);
	}
}
