using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PerformanceTestingWebSite
{
    [DataContract]
    public class MatrixTestResult
    {
        [DataMember]
        public int DatabaseId { get; set; }

        [DataMember]
        public int DeviceDatabaseId { get; set; }

        [DataMember]
        public double CSTestResult { get; set; }

        [DataMember]
        public double CTestResult { get; set; }

        [DataMember]
        public double BLASTestResult { get; set; }

        [DataMember]
        public bool IsMonoTouch { get; set; }
    }
}
