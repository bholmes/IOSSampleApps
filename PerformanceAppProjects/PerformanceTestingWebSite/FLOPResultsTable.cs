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

            internal void WriteData(StringBuilder sbn, bool showMT, bool showObjC, bool enableBLAS)
			{
				if (HasMTResults && HasObjCResults) {
					if (showMT && showObjC) {
                        if (enableBLAS)
                            sbn.AppendFormat("['Device {0}', {1},{2},{3},{4},{5}],\n", 
						                  DeviceId, _csResult, _pInvokeResult, 
						                  _objCResult, _mtBLAS, _objCBLAS);
                        else
                            sbn.AppendFormat("['Device {0}', {1},{2},{3}],\n",
                                          DeviceId, _csResult, _pInvokeResult,
                                          _objCResult);
					}
					else if (showMT) {
                        if (enableBLAS)
						    sbn.AppendFormat ("['Device {0}', {1},{2},{3}],\n", 
						                      DeviceId, _csResult, _pInvokeResult, 
						                      _mtBLAS);
                        else
                            sbn.AppendFormat("['Device {0}', {1},{2}],\n",
                                              DeviceId, _csResult, _pInvokeResult);
					}
					else if (showObjC) {
                        if (enableBLAS) 
                            sbn.AppendFormat("['Device {0}', {1},{2}],\n", 
						                      DeviceId, _objCResult, _objCBLAS);
                        else
                            sbn.AppendFormat("['Device {0}', {1}],\n",
                                              DeviceId, _objCResult);
					}
				}
				else if (HasMTResults) {
					if (showMT && showObjC) {
                        if (enableBLAS) 
                            sbn.AppendFormat("['Device {0}', {1},{2},null,{3},null],\n", 
						                      DeviceId, _csResult, _pInvokeResult, 
						                      _mtBLAS);
                        else
                            sbn.AppendFormat("['Device {0}', {1},{2},null],\n",
                                              DeviceId, _csResult, _pInvokeResult);
					}
					else if (showMT) {
                        if (enableBLAS) 
                            sbn.AppendFormat("['Device {0}', {1},{2},{3}],\n", 
						                      DeviceId, _csResult, _pInvokeResult, 
						                      _mtBLAS);
                        else
                            sbn.AppendFormat("['Device {0}', {1},{2}],\n",
                                              DeviceId, _csResult, _pInvokeResult);
					}
				}
				else if (HasObjCResults) {

					if (showMT && showObjC) {
                        if (enableBLAS) 
                            sbn.AppendFormat("['Device {0}', null,null,{1},null,{2}],\n", 
						                      DeviceId, _objCResult, _objCBLAS);
                        else
                            sbn.AppendFormat("['Device {0}', null,null,{1}],\n",
                                              DeviceId, _objCResult);
					}
					else if (showObjC) {
                        if (enableBLAS) 
                            sbn.AppendFormat("['Device {0}', {1},{2}],\n", 
						                      DeviceId, _objCResult, _objCBLAS);
                        else
                            sbn.AppendFormat("['Device {0}', {1}],\n",
                                              DeviceId, _objCResult);
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
		
		internal void WriteData(StringBuilder sb, bool enableBLAS)
		{
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
                if (enableBLAS)
                    sb.Append("['Device', 'C#', 'PInvoke', 'Obj C','MT BLAS', 'Obj C BLAS'],");
                else
                    sb.Append("['Device', 'C#', 'PInvoke', 'Obj C'],");
			}
			else if (haveMT) {
                if (enableBLAS)
				    sb.Append ("['Device', 'C#', 'PInvoke','MT BLAS'],");
                else
                    sb.Append ("['Device', 'C#', 'PInvoke'],");
			}
			else if (haveObjC) {
                if (enableBLAS) 
                    sb.Append("['Device', 'Obj C', 'Obj C BLAS'],");
                else
                    sb.Append("['Device', 'Obj C'],");
			}

			foreach (ResultRow resultRow in _resultRows)
			{
				resultRow.WriteData(sb, haveMT, haveObjC, enableBLAS);
			}

			sb.Append ("]");
		}
	}
}

