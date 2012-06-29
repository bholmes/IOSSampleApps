using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PerformanceTestingWebApp
{
    [DataContract]
    public class PerformanceCubeResult
    {
        [DataMember]
        public int DatabaseId { get; set; }

        [DataMember]
        public int DeviceDatabaseId { get; set; }

        [DataMember]
        public int NumberOfTriangles { get; set; }

        [DataMember]
        public double FramesPerSecond { get; set; }

        [DataMember]
        public bool IsMonoTouch { get; set; }
    }
}
