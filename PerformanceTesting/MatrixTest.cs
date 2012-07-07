using System;

namespace PerformanceTesting
{
	public class MatrixTest
	{
		public MatrixTest ()
		{
			this.MatrixSize = 128;
			this.Iterations = 1;
		}

		public int MatrixSize {get; set;}
		public int Iterations {get; set;}
		public double MFlops 
		{
			get
			{

				int matrixSize = this.MatrixSize;

				return 2.0*matrixSize*matrixSize*matrixSize*this.Iterations / 1000000.0;
			}
		}
		public double MFlopsPerSecond 
		{
			get
			{
				return this.MFlops/Seconds;
			}
		}
		public double Seconds {get;set;}
	}
}

