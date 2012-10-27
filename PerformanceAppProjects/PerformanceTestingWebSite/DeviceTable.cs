using System;
using System.Collections.Generic;

#if UseServiceReference
using PerformanceTestingWebSite.PerformanceService;
#else
using PerformanceTestingWebSite;
#endif

namespace WebApplication1
{
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
				AddIfNew (false, result.DeviceDatabaseId, result.IsMonoTouch, deviceList);
			}
		}

		internal DeviceTable (List<MatrixTestResult> resultsArray, List<DeviceInfo> deviceList)
		{
			foreach(MatrixTestResult result in resultsArray)
			{
				AddIfNew (true, result.DeviceDatabaseId, true, deviceList);
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
		
		private void AddIfNew (bool ignoreMonoCheck, int resultDeviceDatabaseId, bool resultIsMonoTouch, List<DeviceInfo> deviceList)
		{
			for (int i=0; i<_deviceList.Count; i++)
			{
				DeviceForTable device = _deviceList[i];
				if (resultDeviceDatabaseId == device.DatabaseId)
				{
					if (ignoreMonoCheck || resultIsMonoTouch == device.IsMono)
					{
						return;
					}
				}
			}
			
			DeviceInfo di = deviceList.Find(dev => { return dev.DatabaseId == resultDeviceDatabaseId; });
			
			DeviceForTable newDevice = new DeviceForTable (resultDeviceDatabaseId,
			                                               ignoreMonoCheck || resultIsMonoTouch,
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

		internal int Find (int databaseId)
		{
			return this.Find (databaseId, true);
		}

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
}

