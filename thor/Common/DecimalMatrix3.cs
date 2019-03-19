/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 10/08/2008
 * Time: 11:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace thor
{
	/// <summary>
	/// Description of DecimalMatrix3.
	/// </summary>
	public class DecimalMatrix3
	{
		decimal[,] vals;
		public DecimalMatrix3()
		{
			vals = new decimal[3,3];
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					vals[i,j] = 0;
				}
			}
		}
		
		public DecimalCoordinate getRow(int row)
		{
			return new DecimalCoordinate(vals[row,0],vals[row,1],vals[row,2]);
		}
		
		public void setRow(int row, DecimalCoordinate c)
		{
			if (row < 0 || row > 2) return;
			vals[row,0] = c.getX();
			vals[row,1] = c.getY();
			vals[row,2] = c.getZ();
		}
		
		public DecimalCoordinate getColumn(int col)
		{
			return new DecimalCoordinate(vals[0,col],vals[1,col],vals[2,col]);
		}
		
		public void setColumn(int col, DecimalCoordinate c)
		{
			if (col < 0 || col > 2) return;
			vals[0,col] = c.getX();
			vals[1,col] = c.getY();
			vals[2,col] = c.getZ();
		}
		
		public decimal determinant()
		{
			//x1 y1 z1
			//x2 y2 z2
			//x3 y3 z3
			//det = x1 (y2 z3 - y3 z2) + x2 (y3 z1 - y1 z3) + x3 (y1 z2 - y2 z1)
			return (vals[0,0] * (vals[1,1] * vals[2,2] - vals[2,1] * vals[1,2])) +
				(vals[1,0] * (vals[2,1] * vals[0,2] - vals[0,1] * vals[2,2])) +
				(vals[2,0] * (vals[0,1] * vals[1,2] - vals[1,1] * vals[0,2]));
		}
	}
}
