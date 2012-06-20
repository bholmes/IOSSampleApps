using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace PerformanceTestingWebApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PerformanceTestingDataService : IPerformanceTestingDataService
    {
        List<FullDeviceInfo> _devices = new List<FullDeviceInfo> ();

        public int AddDevice(FullDeviceInfo deviceInfo)
        {
            FullDeviceInfo existing = _devices.Find(e => e.UniqueId.Equals(deviceInfo.UniqueId));

            if (existing != null)
            {
                return existing.DatabaseId;
            }

            deviceInfo.DatabaseId = _devices.Count;
            _devices.Add(deviceInfo);

            return deviceInfo.DatabaseId;
        }

        public List<DeviceInfo> GetDeviceList()
        {
            List<DeviceInfo> retList = new List<DeviceInfo>();

            foreach (FullDeviceInfo di in _devices)
                retList.Add(new DeviceInfo (di));

            return retList;
        }
    }
}
