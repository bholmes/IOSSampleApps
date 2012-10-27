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
	internal class FLOPResultsTable
	{
		List<ResultRow> _resultRows = new List<ResultRow> ();
		
		private class ResultRow
		{
			internal bool HasMTResults {get;private set;}
			internal bool HasObjCResults {get;private set;}

			double _csResult, _pInvokeResult, _objCResult, _mtBLAS, _objCBLAS;

			internal ResultRow (int deviceId)
			{
				this.DeviceId = deviceId;
				HasMTResults = false;
				HasObjCResults = false;
			}

			internal void WriteData(StringBuilder sbn, int index, bool showMT, bool showObjC)
			{
				if (HasMTResults && HasObjCResults) {
					if (showMT && showObjC) {
						sbn.AppendFormat ("['Device {0}', {1},{2},{3},{4},{5}],\n", 
						                  index, _csResult, _pInvokeResult, 
						                  _objCResult, _mtBLAS, _objCBLAS);
					}
					else if (showMT) {
						sbn.AppendFormat ("['Device {0}', {1},{2},{3}],\n", 
						                  index, _csResult, _pInvokeResult, 
						                  _mtBLAS);
					}
					else if (showObjC) {
						sbn.AppendFormat ("['Device {0}', {1},{2}],\n", 
						                  index, _objCResult, _objCBLAS);
					}
				}
				else if (HasMTResults) {
					if (showMT && showObjC) {
						sbn.AppendFormat ("['Device {0}', {1},{2},null,{3},null],\n", 
						                  index, _csResult, _pInvokeResult, 
						                  _mtBLAS);
					}
					else if (showMT) {
						sbn.AppendFormat ("['Device {0}', {1},{2},{3}],\n", 
						                  index, _csResult, _pInvokeResult, 
						                  _mtBLAS);
					}
				}
				else if (HasObjCResults) {

					if (showMT && showObjC) {
						sbn.AppendFormat ("['Device {0}', null,null,{1},null,{2}],\n", 
						                  index, _objCResult, _objCBLAS);
					}
					else if (showObjC) {
						sbn.AppendFormat ("['Device {0}', {1},{2}],\n", 
						                  index, _objCResult, _objCBLAS);
					}
				}
			}

			internal void AddResultInfo (MatrixTestResult matResult)
			{
				if (matResult.IsMonoTouch)
				{
					HasMTResults = true;
					_csResult = matResult.CSTestResult;
					_pInvokeResult = matResult.CTestResult;
					_mtBLAS = matResult.BLASTestResult;
				}
				else
				{
					HasObjCResults = true;
					_objCResult = matResult.CTestResult;
					_objCBLAS = matResult.BLASTestResult;
				}
			}

			internal int DeviceId {get; private set;}
		}

		internal FLOPResultsTable (List<MatrixTestResult> resultsArray, DeviceTable deviceTable)
		{
			foreach (MatrixTestResult result in resultsArray)
			{
				int indexOfDevice = deviceTable.Find (result.DeviceDatabaseId);
				if (indexOfDevice > -1)
				{
					ResultRow resultRow = _resultRows.Find ((e)=>{return e.DeviceId == result.DeviceDatabaseId;});

					if (resultRow == null) {
						resultRow = new ResultRow (result.DeviceDatabaseId);
						_resultRows.Add (resultRow);
					}

					resultRow.AddResultInfo (result);
				}
			}
		}

		internal bool IsEmpty { get { return this._resultRows.Count == 0; } }
		
		internal void WriteData(StringBuilder sb)
		{
			int deviceIndex = 1;
			bool haveMT = false;
			bool haveObjC = false;

			sb.Append ("[\n");

			foreach (ResultRow resultRow in _resultRows)
			{
				haveMT = resultRow.HasMTResults;
				haveObjC = resultRow.HasObjCResults;

				if (haveMT && haveObjC)
					break;
			}

			if (haveMT && haveObjC) {
				sb.Append ("['Device', 'C#', 'PInvoke', 'Obj C','MT BLAS', 'Obj C BLAS'],");
			}
			else if (haveMT) {
				sb.Append ("['Device', 'C#', 'PInvoke','MT BLAS'],");
			}
			else if (haveObjC) {
				sb.Append ("['Device', 'Obj C', 'Obj C BLAS'],");
			}

			foreach (ResultRow resultRow in _resultRows)
			{
				resultRow.WriteData(sb, deviceIndex++, haveMT, haveObjC);
			}

			sb.Append ("]");
		}
	}
}

