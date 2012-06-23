using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace PerformanceTestingWebApp
{
    [ServiceContract]
    public interface IPerformanceTestingDataService
    {
        [OperationContract]
        int AddDevice(FullDeviceInfo deviceInfo);

        [OperationContract]
        DeviceInfo FindDeviceInfo(int databaseId);

        [OperationContract]
        List<DeviceInfo> GetDeviceList();

        [OperationContract]
        int AddPerformanceCubeResult(PerformanceCubeResult result);

        [OperationContract]
        void AddPerformanceCubeResults(List <PerformanceCubeResult> results);

        [OperationContract]
        List<PerformanceCubeResult> GetPerformanceCubeResults();
    }
}
