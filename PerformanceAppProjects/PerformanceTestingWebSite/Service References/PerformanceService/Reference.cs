﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PerformanceTestingWebSite.PerformanceService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FullDeviceInfo", Namespace="http://schemas.datacontract.org/2004/07/PerformanceTestingWebSite")]
    [System.SerializableAttribute()]
    public partial class FullDeviceInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DatabaseIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModelNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OSNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OSVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OwnerNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SpecificHWVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SystemNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UIIdionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UniqueIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DatabaseId {
            get {
                return this.DatabaseIdField;
            }
            set {
                if ((this.DatabaseIdField.Equals(value) != true)) {
                    this.DatabaseIdField = value;
                    this.RaisePropertyChanged("DatabaseId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ModelName {
            get {
                return this.ModelNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelNameField, value) != true)) {
                    this.ModelNameField = value;
                    this.RaisePropertyChanged("ModelName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OSName {
            get {
                return this.OSNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OSNameField, value) != true)) {
                    this.OSNameField = value;
                    this.RaisePropertyChanged("OSName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OSVersion {
            get {
                return this.OSVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.OSVersionField, value) != true)) {
                    this.OSVersionField = value;
                    this.RaisePropertyChanged("OSVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OwnerName {
            get {
                return this.OwnerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OwnerNameField, value) != true)) {
                    this.OwnerNameField = value;
                    this.RaisePropertyChanged("OwnerName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SpecificHWVersion {
            get {
                return this.SpecificHWVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.SpecificHWVersionField, value) != true)) {
                    this.SpecificHWVersionField = value;
                    this.RaisePropertyChanged("SpecificHWVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SystemName {
            get {
                return this.SystemNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SystemNameField, value) != true)) {
                    this.SystemNameField = value;
                    this.RaisePropertyChanged("SystemName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UIIdion {
            get {
                return this.UIIdionField;
            }
            set {
                if ((object.ReferenceEquals(this.UIIdionField, value) != true)) {
                    this.UIIdionField = value;
                    this.RaisePropertyChanged("UIIdion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UniqueId {
            get {
                return this.UniqueIdField;
            }
            set {
                if ((object.ReferenceEquals(this.UniqueIdField, value) != true)) {
                    this.UniqueIdField = value;
                    this.RaisePropertyChanged("UniqueId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeviceInfo", Namespace="http://schemas.datacontract.org/2004/07/PerformanceTestingWebSite")]
    [System.SerializableAttribute()]
    public partial class DeviceInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DatabaseIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModelNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OSNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OSVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SpecificHWVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UIIdionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DatabaseId {
            get {
                return this.DatabaseIdField;
            }
            set {
                if ((this.DatabaseIdField.Equals(value) != true)) {
                    this.DatabaseIdField = value;
                    this.RaisePropertyChanged("DatabaseId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ModelName {
            get {
                return this.ModelNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelNameField, value) != true)) {
                    this.ModelNameField = value;
                    this.RaisePropertyChanged("ModelName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OSName {
            get {
                return this.OSNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OSNameField, value) != true)) {
                    this.OSNameField = value;
                    this.RaisePropertyChanged("OSName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OSVersion {
            get {
                return this.OSVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.OSVersionField, value) != true)) {
                    this.OSVersionField = value;
                    this.RaisePropertyChanged("OSVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SpecificHWVersion {
            get {
                return this.SpecificHWVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.SpecificHWVersionField, value) != true)) {
                    this.SpecificHWVersionField = value;
                    this.RaisePropertyChanged("SpecificHWVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UIIdion {
            get {
                return this.UIIdionField;
            }
            set {
                if ((object.ReferenceEquals(this.UIIdionField, value) != true)) {
                    this.UIIdionField = value;
                    this.RaisePropertyChanged("UIIdion");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PerformanceCubeResult", Namespace="http://schemas.datacontract.org/2004/07/PerformanceTestingWebSite")]
    [System.SerializableAttribute()]
    public partial class PerformanceCubeResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DatabaseIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DeviceDatabaseIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double FramesPerSecondField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsMonoTouchField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumberOfTrianglesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DatabaseId {
            get {
                return this.DatabaseIdField;
            }
            set {
                if ((this.DatabaseIdField.Equals(value) != true)) {
                    this.DatabaseIdField = value;
                    this.RaisePropertyChanged("DatabaseId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DeviceDatabaseId {
            get {
                return this.DeviceDatabaseIdField;
            }
            set {
                if ((this.DeviceDatabaseIdField.Equals(value) != true)) {
                    this.DeviceDatabaseIdField = value;
                    this.RaisePropertyChanged("DeviceDatabaseId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double FramesPerSecond {
            get {
                return this.FramesPerSecondField;
            }
            set {
                if ((this.FramesPerSecondField.Equals(value) != true)) {
                    this.FramesPerSecondField = value;
                    this.RaisePropertyChanged("FramesPerSecond");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsMonoTouch {
            get {
                return this.IsMonoTouchField;
            }
            set {
                if ((this.IsMonoTouchField.Equals(value) != true)) {
                    this.IsMonoTouchField = value;
                    this.RaisePropertyChanged("IsMonoTouch");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumberOfTriangles {
            get {
                return this.NumberOfTrianglesField;
            }
            set {
                if ((this.NumberOfTrianglesField.Equals(value) != true)) {
                    this.NumberOfTrianglesField = value;
                    this.RaisePropertyChanged("NumberOfTriangles");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PerformanceService.IPerformanceTestingDataService")]
    public interface IPerformanceTestingDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerformanceTestingDataService/AddDevice", ReplyAction="http://tempuri.org/IPerformanceTestingDataService/AddDeviceResponse")]
        int AddDevice(PerformanceTestingWebSite.PerformanceService.FullDeviceInfo deviceInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerformanceTestingDataService/FindDeviceInfo", ReplyAction="http://tempuri.org/IPerformanceTestingDataService/FindDeviceInfoResponse")]
        PerformanceTestingWebSite.PerformanceService.DeviceInfo FindDeviceInfo(int databaseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerformanceTestingDataService/FindFullDeviceInfo", ReplyAction="http://tempuri.org/IPerformanceTestingDataService/FindFullDeviceInfoResponse")]
        PerformanceTestingWebSite.PerformanceService.FullDeviceInfo FindFullDeviceInfo(string uniqueId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerformanceTestingDataService/GetDeviceList", ReplyAction="http://tempuri.org/IPerformanceTestingDataService/GetDeviceListResponse")]
        System.Collections.Generic.List<PerformanceTestingWebSite.PerformanceService.DeviceInfo> GetDeviceList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerformanceTestingDataService/AddPerformanceCubeResult", ReplyAction="http://tempuri.org/IPerformanceTestingDataService/AddPerformanceCubeResultRespons" +
            "e")]
        int AddPerformanceCubeResult(PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerformanceTestingDataService/AddPerformanceCubeResults", ReplyAction="http://tempuri.org/IPerformanceTestingDataService/AddPerformanceCubeResultsRespon" +
            "se")]
        void AddPerformanceCubeResults(System.Collections.Generic.List<PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult> results);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerformanceTestingDataService/GetPerformanceCubeResults", ReplyAction="http://tempuri.org/IPerformanceTestingDataService/GetPerformanceCubeResultsRespon" +
            "se")]
        System.Collections.Generic.List<PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult> GetPerformanceCubeResults();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerformanceTestingDataService/GetPerformanceCubeResultsForMon" +
            "oTouch", ReplyAction="http://tempuri.org/IPerformanceTestingDataService/GetPerformanceCubeResultsForMon" +
            "oTouchResponse")]
        System.Collections.Generic.List<PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult> GetPerformanceCubeResultsForMonoTouch();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerformanceTestingDataService/GetPerformanceCubeResultsForObj" +
            "ectiveC", ReplyAction="http://tempuri.org/IPerformanceTestingDataService/GetPerformanceCubeResultsForObj" +
            "ectiveCResponse")]
        System.Collections.Generic.List<PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult> GetPerformanceCubeResultsForObjectiveC();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerformanceTestingDataService/FindPerformanceCubeResult", ReplyAction="http://tempuri.org/IPerformanceTestingDataService/FindPerformanceCubeResultRespon" +
            "se")]
        PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult FindPerformanceCubeResult(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPerformanceTestingDataServiceChannel : PerformanceTestingWebSite.PerformanceService.IPerformanceTestingDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PerformanceTestingDataServiceClient : System.ServiceModel.ClientBase<PerformanceTestingWebSite.PerformanceService.IPerformanceTestingDataService>, PerformanceTestingWebSite.PerformanceService.IPerformanceTestingDataService {
        
        public PerformanceTestingDataServiceClient() {
        }
        
        public PerformanceTestingDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PerformanceTestingDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PerformanceTestingDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PerformanceTestingDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int AddDevice(PerformanceTestingWebSite.PerformanceService.FullDeviceInfo deviceInfo) {
            return base.Channel.AddDevice(deviceInfo);
        }
        
        public PerformanceTestingWebSite.PerformanceService.DeviceInfo FindDeviceInfo(int databaseId) {
            return base.Channel.FindDeviceInfo(databaseId);
        }
        
        public PerformanceTestingWebSite.PerformanceService.FullDeviceInfo FindFullDeviceInfo(string uniqueId) {
            return base.Channel.FindFullDeviceInfo(uniqueId);
        }
        
        public System.Collections.Generic.List<PerformanceTestingWebSite.PerformanceService.DeviceInfo> GetDeviceList() {
            return base.Channel.GetDeviceList();
        }
        
        public int AddPerformanceCubeResult(PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult result) {
            return base.Channel.AddPerformanceCubeResult(result);
        }
        
        public void AddPerformanceCubeResults(System.Collections.Generic.List<PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult> results) {
            base.Channel.AddPerformanceCubeResults(results);
        }
        
        public System.Collections.Generic.List<PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult> GetPerformanceCubeResults() {
            return base.Channel.GetPerformanceCubeResults();
        }
        
        public System.Collections.Generic.List<PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult> GetPerformanceCubeResultsForMonoTouch() {
            return base.Channel.GetPerformanceCubeResultsForMonoTouch();
        }
        
        public System.Collections.Generic.List<PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult> GetPerformanceCubeResultsForObjectiveC() {
            return base.Channel.GetPerformanceCubeResultsForObjectiveC();
        }
        
        public PerformanceTestingWebSite.PerformanceService.PerformanceCubeResult FindPerformanceCubeResult(int id) {
            return base.Channel.FindPerformanceCubeResult(id);
        }
    }
}