using System;
namespace PerformanceTesting
{
	public class GLCubeResult
	{
		public GLCubeResult ()
		{
		}
		
		public GLCubeResult (int numberOfTriangles, double framePerSecond)
		{
			this.NumberOfTriangles = numberOfTriangles;
			this.FramesPerSecond = framePerSecond;
		}
		
		public int NumberOfTriangles {get;set;}
		public double FramesPerSecond {get;set;}
	}
}

