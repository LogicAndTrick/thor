/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 31/10/2009
 * Time: 10:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Thorm
{
	/// <summary>
	/// A relationship between two tables
	/// </summary>
	public abstract class Relationship : IDisposable
	{
		/// <summary>
		/// Whether this relationship has been disposed or not
		/// </summary>
		protected bool disposed;
		
		/// <summary>
		/// Bind the relationship and load the data
		/// </summary>
		protected abstract void Bind();
		
		/// <summary>
		/// Unbind the relationship and unload the data
		/// </summary>
		public abstract void Unbind();
		
		/// <summary>
		/// Unbind, unload, and destroy the relationship
		/// </summary>
		public void Dispose()
		{
			Unbind();
			disposed = true;
		}
	}
}
