using System;
using System.Collections.Generic;
namespace PerformanceTesting
{
	public class GLCubeResults
	{
		private List<GLCubeResult> _results = new List<GLCubeResult> ();
		
		public GLCubeResults ()
		{
		}
		
		public int Count 
		{
			get 
			{
				return _results.Count;	
			}
		}
		
		public GLCubeResult this[int index]
		{
			get
			{
				return _results[index];	
			}
		}
		
		public void RemoveAt (int index)
		{
			_results.RemoveAt (index);
		}
		
		public void Add (GLCubeResult result)
		{
			_results.Add (result);	
		}
		
		public void Insert (int index, GLCubeResult result)
		{
			_results.Insert (index, result);	
		}
	}
}

