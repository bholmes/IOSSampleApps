using System;

namespace PerformanceTesting
{
	public class MatrixTestEngine
	{
		interface TestRunItf
		{
			MatrixTest RunSingleTest (int matrixSize, int iterations);
		}

		class CTestRun : TestRunItf
		{
			private bool _useblas = false;

			public CTestRun (bool useBlas)
			{
				_useblas = useBlas;
			}

			#region TestRunItf implementation
			public MatrixTest RunSingleTest (int matrixSize, int iterations)
			{
				MatrixMultInfo info = new MatrixMultInfo ();
				info.matrixSize = matrixSize;
				info.numberIterations = iterations;
				info.useblas = _useblas;

				RunMatrixTest (ref info);

				MatrixTest ret = new MatrixTest ();
				ret.Iterations = info.numberIterations;
				ret.MatrixSize = info.matrixSize;
				ret.Seconds = info.totalTime;

				return ret;
			}
			#endregion

			private struct MatrixMultInfo
			{
			    public int matrixSize;
			    public int numberIterations;
			    public double MFlops;
			    public double totalTime;
			    public double matrixMultiplyTime;
			    public bool useblas;
			};

			[System.Runtime.InteropServices.DllImport ("__Internal")]
			private static extern void  RunMatrixTest (ref MatrixMultInfo info);
		}

		class CSTestRun : TestRunItf
		{
			#region TestRunItf implementation
			public MatrixTest RunSingleTest (int matrixSize, int iterations)
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
			#endregion

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

		public MatrixTestEngine ()
		{
		}

		static MatrixTest RunTest (TestRunItf testRunner)
		{
			MatrixTest test = null;
			int matrixSize = 128;
			int iterations = 1;
			while (test == null) {
				test = testRunner.RunSingleTest (matrixSize, iterations);
				if (test.Seconds < 1)
					matrixSize *= 2;
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

		public MatrixTest RunCTest (bool useBlas)
		{
			return RunTest (new CTestRun (useBlas));

		}

		public MatrixTest RunCSTest ()
		{
			return RunTest (new CSTestRun ());
		}
	}
}

