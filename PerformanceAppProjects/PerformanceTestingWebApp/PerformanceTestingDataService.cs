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
        List<PerformanceCubeResult> _cubeResults = new List<PerformanceCubeResult>();

        public int AddDevice(FullDeviceInfo deviceInfo)
        {
            FullDeviceInfo existing = _devices.Find(e => e.UniqueId.Equals(deviceInfo.UniqueId));

            if (existing != null)
            {
                existing.ModelName = deviceInfo.ModelName;
                existing.UIIdion = deviceInfo.UIIdion;
                existing.SpecificHWVersion = deviceInfo.SpecificHWVersion;
                existing.OSName = deviceInfo.OSName;
                existing.OSVersion = deviceInfo.OSVersion;
                existing.SystemName = deviceInfo.SystemName;
                existing.OwnerName = deviceInfo.OwnerName;

                return existing.DatabaseId;
            }

            deviceInfo.DatabaseId = _devices.Count;
            _devices.Add(deviceInfo);

            return deviceInfo.DatabaseId;
        }

        public DeviceInfo FindDeviceInfo(int databaseId)
        {
            FullDeviceInfo existing = _devices.Find(e => e.DatabaseId == databaseId);

            if (existing != null)
            {
                return new DeviceInfo(existing);
            }

            return null;
        }

        public List<DeviceInfo> GetDeviceList()
        {
            List<DeviceInfo> retList = new List<DeviceInfo>();

            foreach (FullDeviceInfo di in _devices)
                retList.Add(new DeviceInfo (di));

            return retList;
        }

        public int AddPerformanceCubeResult(PerformanceCubeResult result)
        {
            result.DatabaseId = _cubeResults.Count;
            _cubeResults.Add(result);

            return result.DatabaseId;
        }

        public void AddPerformanceCubeResults(List<PerformanceCubeResult> results)
        {
            foreach (PerformanceCubeResult result in results)
            {
                AddPerformanceCubeResult(result);
            }
        }

        public List<PerformanceCubeResult> GetPerformanceCubeResults()
        {
            return _cubeResults;
        }
    }
}
