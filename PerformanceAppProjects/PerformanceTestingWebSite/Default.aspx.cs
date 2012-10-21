//#define UseServiceReference

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;


#if UseServiceReference
using PerformanceTestingWebSite.PerformanceService;
#else
using PerformanceTestingWebSite;
#endif

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page 
    {
        private string _chartName = "myIOSChart";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (sm.IsInAsyncPostBack)
                return;

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Foo", string.Format("emptyChart('{0}');", _chartName), true);

#if UseServiceReference
            PerformanceTestingDataServiceClient svc = new PerformanceTestingDataServiceClient();
#else
            PerformanceTestingDataService svc = new PerformanceTestingDataService();
#endif

			List<PerformanceCubeResult> resultsArray = svc.GetPerformanceCubeResults();
            List<DeviceInfo> deviceList = svc.GetDeviceList();

            if (resultsArray.Count != 0)
            {
                DataSet ds = new DataSet("MyTables");
                ds.Tables.Add("DeviceList");
                DataTable dt = ds.Tables["DeviceList"];
                dt.Columns.Add("Device");
				dt.Columns.Add("Is Mono");
				dt.Columns.Add("Hardware Key");

                DeviceTable deviceTable = new DeviceTable(resultsArray, deviceList);

                for (int i = 0; i < deviceTable.NuberOfDevices; i++)
                {
                    dt.Rows.Add(string.Format("Device {0}", deviceTable[i].DatabaseId), deviceTable[i].IsMono, deviceTable[i].HardwareKey);
                }

                DeviceList.DataSource = dt.DefaultView;
                DeviceList.DataBind();
            }
        }

        private void SyncDeviceTableCheckState(DeviceTable deviceTable)
		{
            for (int i = 0; i < deviceTable.NuberOfDevices; i++)
			{
				CheckBox chkBx = DeviceList.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                deviceTable[i].Checked = chkBx.Checked;
			}
		}

        protected void Button1_Click(object sender, EventArgs e)
        {
#if UseServiceReference
            PerformanceTestingDataServiceClient svc = new PerformanceTestingDataServiceClient();
#else
            PerformanceTestingDataService svc = new PerformanceTestingDataService();
#endif

			List<PerformanceCubeResult> resultsArray = svc.GetPerformanceCubeResults();
			DeviceTable deviceTable = new DeviceTable (resultsArray, 
			                                           svc.GetDeviceList ());

            SyncDeviceTableCheckState(deviceTable);

			if (resultsArray.Count == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ReloadChart1", string.Format("emptyChart('{0}');", _chartName), true);
                return;
            }

            DeviceTable trimmedDeviceTable = deviceTable.CreateCheckedList();
            ResultsTable resultTable = new ResultsTable(resultsArray, trimmedDeviceTable);

            if (resultTable.IsEmpty)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ReloadChart1", string.Format("emptyChart('{0}');", _chartName), true);
                return;
            }

            StringBuilder bob = new StringBuilder();
            bob.AppendFormat("[\n['Triangles'");

            for (int i = 0; i < trimmedDeviceTable.NuberOfDevices; i++)
            {
                bob.AppendFormat(", 'Device {0} - {1}'", trimmedDeviceTable[i].DatabaseId, trimmedDeviceTable[i].IsMono ? "With Mono" : "W/O Mono"); 
            }

            bob.AppendFormat("],\n");

            resultTable.WriteData(bob);
            bob.AppendFormat("]");

            StringBuilder sb = new StringBuilder();
            sb.Append("drawWithData(");
            sb.Append(bob.ToString());
            sb.Append(", 'myIOSChart');");

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ReloadChart1", sb.ToString(), true);
        }
    }

	internal class DeviceTable
	{
		internal class DeviceForTable
		{
			internal DeviceForTable (int databaseId, bool isMono, string hardwareKey)
			{
				this.DatabaseId = databaseId;
				this.IsMono = isMono;
				this.HardwareKey = hardwareKey;
				this.Checked = false;
			}

			public int DatabaseId {get; private set;}
			public bool IsMono {get; private set;}
			public string HardwareKey {get; private set;}
			public bool Checked {get; set;}
		}

		List<DeviceForTable> _deviceList = new List<DeviceForTable> ();

		internal DeviceTable (List<PerformanceCubeResult> resultsArray, List<DeviceInfo> deviceList)
		{
			foreach(PerformanceCubeResult result in resultsArray)
			{
				AddIfNew (result, deviceList);
			}
		}

        private DeviceTable() { }

        internal DeviceTable CreateCheckedList()
        {
            DeviceTable newTable = new DeviceTable();

            foreach (DeviceForTable dft in _deviceList)
            {
                if (dft.Checked)
                    newTable._deviceList.Add(dft);
            }

            return newTable;
        }

		private void AddIfNew (PerformanceCubeResult result, List<DeviceInfo> deviceList)
		{
			for (int i=0; i<_deviceList.Count; i++)
			{
				DeviceForTable device = _deviceList[i];
				if (result.DeviceDatabaseId == device.DatabaseId)
				{
					if (result.IsMonoTouch == device.IsMono)
					{
						return;
					}
				}
			}

			DeviceInfo di = deviceList.Find(dev => { return dev.DatabaseId == result.DeviceDatabaseId; });

			DeviceForTable newDevice = new DeviceForTable (result.DeviceDatabaseId,
			                                               result.IsMonoTouch,
			                                               di.SpecificHWVersion);
			_deviceList.Add (newDevice);
		}

		internal DeviceForTable this[int i]
		{
			get
			{
				return this._deviceList[i]; 
			}
		}

		internal int NuberOfDevices {get{return _deviceList.Count;}}

		internal int Find (int databaseId, bool isMono)
		{
			for (int i=0; i<_deviceList.Count; i++)
			{
				DeviceForTable dft = _deviceList[i];
				if (dft.DatabaseId == databaseId && dft.IsMono == isMono)
				{
					return i;
				}
			}

			return -1;
		}
	}

	internal class ResultsTable
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
		internal ResultsTable (List<PerformanceCubeResult> resultsArray, DeviceTable deviceTable)
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