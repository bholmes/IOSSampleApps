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
        FullDeviceInfo FindFullDeviceInfo(string uniqueId);

        [OperationContract]
        List<DeviceInfo> GetDeviceList();

        [OperationContract]
        int AddPerformanceCubeResult(PerformanceCubeResult result, bool isMonoTouch);

        [OperationContract]
        void AddPerformanceCubeResults(List <PerformanceCubeResult> results, bool isMonoTouch);

        [OperationContract]
        List<PerformanceCubeResult> GetPerformanceCubeResults();

        [OperationContract]
        List<PerformanceCubeResult> GetPerformanceCubeResultsForMonoTouch();

        [OperationContract]
        List<PerformanceCubeResult> GetPerformanceCubeResultsForObjectiveC();

        [OperationContract]
        PerformanceCubeResult FindPerformanceCubeResult(int id);
    }
}
