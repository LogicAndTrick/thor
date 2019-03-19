/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 16/03/2009
 * Time: 9:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace thor
{
	/// <summary>
	/// Description of BrushInterface.
	/// </summary>
	public interface BrushInterface
	{
		string getName();
		BrushInterface copy();
		List<MapObject> makeBrush(BoundingBox box);
	}
}
