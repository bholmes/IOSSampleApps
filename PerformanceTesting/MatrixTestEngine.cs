using System;

namespace PerformanceTesting
{
	public class MatrixTestEngine
	{
		public MatrixTestEngine ()
		{
		}

		public MatrixTest RunCSTest ()
		{
			MatrixTest test = null;
			int matrixSize = 128;
			int iterations = 1;
			while (test == null)
			{
				test = RunSingleCSTest (matrixSize, iterations); 
				if (test.Seconds < 1)
					matrixSize *=2;
				else if (test.Seconds < 2.5)
				{
					iterations *= 3;
				}
				else if (test.Seconds < 5)
				{
					iterations *= 2;
				}
				else
					continue;

				test = null;
			}

			return test;
		}

		private MatrixTest RunSingleCSTest (int matrixSize, int iterations)
		{
			MatrixTest testResult = new MatrixTest ();

			testResult.Iterations = 1;
			testResult.MatrixSize = matrixSize;

			double [] A = new double [matrixSize*matrixSize];
			double [] B = new double [matrixSize*matrixSize];
			double [] C = new double [matrixSize*matrixSize];

			int matrixSizeSquared = matrixSize * matrixSize;
			Random rand = new Random ();

			for (int i=0; i<matrixSizeSquared; i++) 
			{
				A[i] = rand.NextDouble ();
				B[i] = rand.NextDouble ();
		    }

			DateTime start = DateTime.Now;

			for (int i=0; i<iterations; i++)
				csMatrixMult (matrixSize, A, B, C);

			DateTime end = DateTime.Now;

			testResult.Seconds = end.Subtract (start).TotalSeconds;

			return testResult; 
		}

		private void csMatrixMult (int n, double [] A, double [] B, double [] C)
		{
		    int i, j, k;
		    double sum, a, b;
		    
		    for (i=0; i<n; i++) {
		        for (j=0; j<n; j++) {
		            sum = 0.0;
		            for (k=0; k<n; k++) {
		                a = A[i * n + k];
		                b = B[k * n + j];
		                sum += a * b;
		            }
		            C[i * n + j] = sum;
		        }
		    }
		}
	}
}

