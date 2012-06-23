using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PerformanceTestingWebApp
{
    [DataContract]
    public class DeviceInfo
    {
        public DeviceInfo (FullDeviceInfo fullDI)
        {
            this.DatabaseId = fullDI.DatabaseId;
            this.ModelName = fullDI.ModelName;
            this.UIIdion = fullDI.UIIdion;
            this.SpecificHWVersion = fullDI.SpecificHWVersion;
            this.OSName = fullDI.OSName;
            this.OSVersion = fullDI.OSVersion;
        }

        public DeviceInfo() { }

        [DataMember]
        public int DatabaseId { get; set; }
        
        [DataMember]
        public string ModelName { get; set; }
        
        [DataMember]
        public string UIIdion { get; set; }
        
        [DataMember]
        public string SpecificHWVersion { get; set; }
        
        [DataMember]
        public string OSName { get; set; }
        
        [DataMember]
        public string OSVersion { get; set; }
    }

    [DataContract]
    public class FullDeviceInfo
    {
        [DataMember]
        public int DatabaseId { get; set; }

        [DataMember]
        public string ModelName { get; set; }

        [DataMember]
        public string UIIdion { get; set; }

        [DataMember]
        public string SpecificHWVersion { get; set; }

        [DataMember]
        public string OSName { get; set; }

        [DataMember]
        public string OSVersion { get; set; }

        [DataMember]
        public string UniqueId { get; set; }

        [DataMember]
        public string SystemName { get; set; }

        [DataMember]
        public string OwnerName { get; set; }
    }
}
