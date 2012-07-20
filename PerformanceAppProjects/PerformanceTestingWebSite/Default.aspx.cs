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

            List<PerformanceCubeResult> resultsArray = svc.GetPerformanceCubeResultsForMonoTouch();
            List<DeviceInfo> deviceList = svc.GetDeviceList();

            if (resultsArray.Count != 0)
            {
                DataSet ds = new DataSet("MyTables");
                ds.Tables.Add("DeviceList");
                DataTable dt = ds.Tables["DeviceList"];
                dt.Columns.Add("Device");
                dt.Columns.Add("Hardware Key");

				List <PerformanceCubeResult> results = new List<PerformanceCubeResult> (resultsArray);
                List<int> deviceIndexList = GetDeviceIndexList(results);
                
				results.Sort ((x, y) => {return 1;});

                for (int i = 1; i <= deviceIndexList.Count; i++)
                {
                    DeviceInfo di = deviceList.Find(dev => { return dev.DatabaseId == deviceIndexList[i - 1]; });
                    if (di != null)
                    {
                        dt.Rows.Add(string.Format("Device {0}", di.DatabaseId), di.SpecificHWVersion);
                    }
                    else
                    {
                        dt.Rows.Add(string.Format("Device {0}", i));
                    }
                }

                DeviceList.DataSource = dt.DefaultView;
                DeviceList.DataBind();
            }
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
#if UseServiceReference
            PerformanceTestingDataServiceClient svc = new PerformanceTestingDataServiceClient();
#else
            PerformanceTestingDataService svc = new PerformanceTestingDataService();
#endif

            List<PerformanceCubeResult> resultsArray = svc.GetPerformanceCubeResultsForMonoTouch();
            List<DeviceInfo> deviceList = svc.GetDeviceList();

            if (resultsArray.Count == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ReloadChart1", string.Format("emptyChart('{0}');", _chartName), true);
                return;
            }

			List<PerformanceCubeResult> results = new List<PerformanceCubeResult> (resultsArray);
			List<int> deviceIndexList = GetDeviceIndexList(results);

            for (int i = deviceIndexList.Count - 1; i >= 0; i--)
            {
                CheckBox chkBx = DeviceList.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (chkBx != null && chkBx.Checked)
                {
                    continue;
                }

				results.RemoveAll ( (xx) => 
				                   {
					return xx.DeviceDatabaseId == deviceIndexList[i];
				});
                deviceIndexList.RemoveAt(i);
            }

			if (results.Count == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ReloadChart1", string.Format("emptyChart('{0}');", _chartName), true);
                return;
            }

			results.Sort ((x, y) => {return x.NumberOfTriangles - y.NumberOfTriangles;});

            StringBuilder bob = new StringBuilder();
            bob.AppendFormat("[\n['Triangles'");

            for (int i = 1; i <= deviceIndexList.Count; i++)
            {
                DeviceInfo di = deviceList.Find(dev => { return dev.DatabaseId == deviceIndexList[i - 1]; });
                if (di != null)
                {
                    bob.AppendFormat(", 'Device {0} - {1}'", di.DatabaseId, di.SpecificHWVersion);
                }
                else
                {
                    bob.AppendFormat(", 'Device {0}'", i);
                }
            }

            bob.AppendFormat("],\n");

            object[] rowData = new object[deviceIndexList.Count];
            int curNumTriagles = 0;

            foreach (PerformanceCubeResult result in results)
            {
                if (curNumTriagles != result.NumberOfTriangles)
                {
                    if (curNumTriagles != 0)
                    {
                        WriteRowAndReset(deviceIndexList, bob, rowData, curNumTriagles);
                    }

                    curNumTriagles = result.NumberOfTriangles;
                }

                int dIndex = deviceIndexList.FindIndex(idx => { return result.DeviceDatabaseId == idx; });
                rowData[dIndex] = result.FramesPerSecond;
            }

            WriteRowAndReset(deviceIndexList, bob, rowData, curNumTriagles);

            bob.AppendFormat("]");

            StringBuilder sb = new StringBuilder();
            sb.Append("drawWithData(");
            sb.Append(bob.ToString ());
            sb.Append(", 'myIOSChart');");

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ReloadChart1", sb.ToString(), true);
        }

        private static void WriteRowAndReset(List<int> deviceIndexList, StringBuilder bob, object[] rowData, int curNumTriagles)
        {
            bob.AppendFormat("[{0}", curNumTriagles);
            for (int i = 0; i < deviceIndexList.Count; i++)
            {
                bob.AppendFormat(", {0}", rowData[i] == null ? "null" : rowData[i]);
                rowData[i] = null;
            }
            bob.AppendFormat("],\n");
        }

        private List<int> GetDeviceIndexList(List<PerformanceCubeResult> results)
        {
            List<int> deviceIndexList = new List<int>();
			for (int i=results.Count-1; i>=0; i--)
            {
				PerformanceCubeResult result = results[i];
                if (deviceIndexList.Count == 0 || result.DeviceDatabaseId != deviceIndexList.Last())
                {
                    deviceIndexList.Add(result.DeviceDatabaseId);
                }
            }

            return deviceIndexList;
        }
    }
}