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
		private string _glChartName = "GLResultsChart";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (sm.IsInAsyncPostBack)
                return;

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "Foo", string.Format("emptyGLChart('{0}');", _glChartName), true);

#if UseServiceReference
			PerformanceTestingDataServiceClient svc = new PerformanceTestingDataServiceClient();
#else
            PerformanceTestingDataService svc = new PerformanceTestingDataService();
#endif
			List<DeviceInfo> deviceList = svc.GetDeviceList();
			List<PerformanceCubeResult> glResultsArray = svc.GetPerformanceCubeResults();
			List<MatrixTestResult> flopResultsArray = svc.GetPerformanceMatrixResults ();

			if (glResultsArray.Count != 0) {
				DeviceTable deviceTable = new DeviceTable (glResultsArray, deviceList);
				PopulateTable (deviceTable, GLDeviceList, false);
			}

			if (flopResultsArray.Count != 0) {
				DeviceTable deviceTable = new DeviceTable (flopResultsArray, deviceList);
				PopulateTable (deviceTable, FLOPDeviceList, true);
			}
        }

		void PopulateTable (DeviceTable deviceTable, GridView gridView, bool ignoreMonoField)
		{
			DataSet ds = new DataSet ("MyTables");
			ds.Tables.Add ("DeviceList");
			DataTable dt = ds.Tables ["DeviceList"];
			dt.Columns.Add ("Device");
			if (!ignoreMonoField)
				dt.Columns.Add ("Is Mono");
			dt.Columns.Add ("Hardware Key");

			for (int i = 0; i < deviceTable.NuberOfDevices; i++) {
				if (!ignoreMonoField)
					dt.Rows.Add (string.Format ("Device {0}", deviceTable [i].DatabaseId), deviceTable [i].IsMono, deviceTable [i].HardwareKey);
				else
					dt.Rows.Add (string.Format ("Device {0}", deviceTable [i].DatabaseId), deviceTable [i].HardwareKey);
			}
			gridView.DataSource = dt.DefaultView;
			gridView.DataBind ();
		}

        private void SyncDeviceTableCheckState(DeviceTable deviceTable, GridView gridView)
		{
            for (int i = 0; i < deviceTable.NuberOfDevices; i++)
			{
				CheckBox chkBx = gridView.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                deviceTable[i].Checked = chkBx.Checked;
			}
		}

		protected void DrawFLOPSButton_Click (object sender, EventArgs e)
		{
#if UseServiceReference
			PerformanceTestingDataServiceClient svc = new PerformanceTestingDataServiceClient();
#else
			PerformanceTestingDataService svc = new PerformanceTestingDataService();
#endif
			
			List<MatrixTestResult> flopResultsArray = svc.GetPerformanceMatrixResults ();
			DeviceTable deviceTable = new DeviceTable (flopResultsArray, 
			                                           svc.GetDeviceList ());
			
			SyncDeviceTableCheckState(deviceTable, GLDeviceList);
		}
		
		protected void DrawGLButton_Click(object sender, EventArgs e)
        {
#if UseServiceReference
            PerformanceTestingDataServiceClient svc = new PerformanceTestingDataServiceClient();
#else
            PerformanceTestingDataService svc = new PerformanceTestingDataService();
#endif

			List<PerformanceCubeResult> resultsArray = svc.GetPerformanceCubeResults();
			DeviceTable deviceTable = new DeviceTable (resultsArray, 
			                                           svc.GetDeviceList ());

            SyncDeviceTableCheckState(deviceTable, GLDeviceList);

			if (resultsArray.Count == 0)
            {
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ReloadChart1", string.Format("emptyGLChart('{0}');", _glChartName), true);
                return;
            }

            DeviceTable trimmedDeviceTable = deviceTable.CreateCheckedList();
            GLResultsTable resultTable = new GLResultsTable(resultsArray, trimmedDeviceTable);

            if (resultTable.IsEmpty)
            {
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ReloadChart1", string.Format("emptyGLChart('{0}');", _glChartName), true);
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
            sb.Append("drawGLWithData(");
            sb.Append(bob.ToString());
			sb.AppendFormat(", '{0}');", _glChartName);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ReloadChart1", sb.ToString(), true);
        }
    }

}