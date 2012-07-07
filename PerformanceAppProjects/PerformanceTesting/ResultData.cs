using System;
namespace PerformanceTesting
{
	public class ResultData
	{
		private GLCubeResults _glResults = new GLCubeResults ();
		
		public ResultData ()
		{
		}
		
		
		public GLCubeResults GLCubeResults {
			get 
			{
				return _glResults;
			}
		}
		
		private static ResultData _GResults = new ResultData ();
		
		public static ResultData Results
		{
			get 
			{
				return _GResults;
			}
		}
	}
}

