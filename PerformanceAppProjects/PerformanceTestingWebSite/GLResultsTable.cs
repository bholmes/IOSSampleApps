using System;
using System.Collections.Generic;
using System.Text;

#if UseServiceReference
using PerformanceTestingWebSite.PerformanceService;
#else
using PerformanceTestingWebSite;
#endif

namespace WebApplication1
{
	internal class GLResultsTable
	{
		List<ResultRow> _resultRows = new List<ResultRow> ();
		
		private class ResultRow
		{
			double [] _fpsArray;
			
			internal ResultRow (int numTriangles, int numCols)
			{
				NumTrangles = numTriangles;
				_fpsArray = new double[numCols];
			}
			
			internal int NumTrangles {get; private set;}
			
			internal double this[int index]
			{
				get
				{
					return this._fpsArray[index];
				}
				set
				{
					_fpsArray[index] = value;
				}
			}
			
			internal void WriteData(StringBuilder sb)
			{
				sb.AppendFormat("[{0}", NumTrangles);
				for (int i = 0; i < _fpsArray.Length; i++)
				{
					sb.AppendFormat(", {0}", _fpsArray[i] < 0.000000001 ? "null" : _fpsArray[i].ToString ());
				}
				sb.AppendFormat("],\n");
			}
		}
		internal GLResultsTable (List<PerformanceCubeResult> resultsArray, DeviceTable deviceTable)
		{
			foreach (PerformanceCubeResult result in resultsArray)
			{
				int indevOfDevice = deviceTable.Find(result.DeviceDatabaseId, result.IsMonoTouch);
				if (indevOfDevice > -1)
				{
					DeviceTable.DeviceForTable dft = deviceTable[indevOfDevice];
					if (dft != null && dft.Checked)
					{
						bool insert = true;
						int insertIndex = 0;
						for (int i=0; i<this._resultRows.Count;i++)
						{
							if (_resultRows[i].NumTrangles == result.NumberOfTriangles)
							{
								insert = false;
								insertIndex = i;
								break;
							}
							else if (_resultRows[i].NumTrangles > result.NumberOfTriangles)
							{
								insertIndex = i;
								break;
							}
							else if (i+1==_resultRows.Count)
							{
								insertIndex = _resultRows.Count;
							}
						}
						
						ResultRow row;
						
						if (insert)
						{
							row = new ResultRow (result.NumberOfTriangles, deviceTable.NuberOfDevices);
							if (insertIndex < _resultRows.Count)
								_resultRows.Insert (insertIndex, row);
							else
								_resultRows.Add (row);
						}
						else
							row = _resultRows[insertIndex];
						
						row[indevOfDevice] = result.FramesPerSecond;
					}
				}
			}
		}
		
		internal bool IsEmpty { get { return this._resultRows.Count == 0; } }
		
		internal void WriteData(StringBuilder sb)
		{
			foreach (ResultRow resultRow in _resultRows)
			{
				resultRow.WriteData(sb);
			}
		}
	}
}

