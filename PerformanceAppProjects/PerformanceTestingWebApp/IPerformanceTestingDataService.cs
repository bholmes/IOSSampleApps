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
        List<DeviceInfo> GetDeviceList();
    }
}
