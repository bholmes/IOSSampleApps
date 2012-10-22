using System;
using System.Runtime.InteropServices;
using System.Text;
using MonoTouch.UIKit;
using PerformanceTesting.PerformanceTestingWebService;


namespace PerformanceTesting
{
	public class DeviceInfo
	{
		private DeviceInfo ()
		{
			
		}
		
		public string DeviceName
		{
			get 
			{
				return UIDevice.CurrentDevice.Name;	
			}
		}
		
		public string OSName
		{
			get 
			{
				return UIDevice.CurrentDevice.SystemName;	
			}
		}
		
		public string OSVersion
		{
			get 
			{
				return UIDevice.CurrentDevice.SystemVersion;	
			}
		}
		
		public string ModelName
		{
			get 
			{
				return UIDevice.CurrentDevice.Model;	
			}
		}
		
		private string _specificHWVersion;
		
		public string SpecificHWVersion 
		{
			get
			{
				if (_specificHWVersion == null)
				{
					IntPtr size = IntPtr.Zero;
					sysctlbyname ("hw.machine", IntPtr.Zero, ref size, IntPtr.Zero, IntPtr.Zero);
					
					size = (IntPtr)((int)size + 2);
					StringBuilder buff = new StringBuilder ((int)size);
					sysctlbyname2 ("hw.machine", buff, ref size, IntPtr.Zero, IntPtr.Zero);
					
					_specificHWVersion = buff.ToString ();
				}
				
				return _specificHWVersion;
			}
		}
		
		public string UniqueId 
		{
			get 
			{
				return UIDevice.CurrentDevice.UniqueIdentifier;	
			}
		}
		
		public string UIIdion 
		{
			get 
			{
				return UIDevice.CurrentDevice.UserInterfaceIdiom.ToString ();	
			}
		}

		private void fetchInfoFromServer ()
		{
			PerformanceTestingDataService service = new PerformanceTestingDataService ();
			FullDeviceInfo di = service.FindFullDeviceInfo (this.UniqueId);
			if (di == null)
			{
				this.RegisterWithServer ();
			}

			else
			{
				this.DatabaseId = di.DatabaseId;
				this.OwnerName = di.OwnerName;
			}
		}

		public void RegisterWithServer ()
		{
			FullDeviceInfo deviceInfo = new FullDeviceInfo ();
			
			deviceInfo.ModelName = this.ModelName;
			deviceInfo.UIIdion = this.UIIdion;
			deviceInfo.SpecificHWVersion = this.SpecificHWVersion;
			deviceInfo.OSName = this.OSName;
			deviceInfo.OSVersion = this.OSVersion;
			deviceInfo.UniqueId = this.UniqueId;
			deviceInfo.SystemName = this.DeviceName;
			deviceInfo.OwnerName = this.OwnerName;
			
			PerformanceTestingDataService service = new PerformanceTestingDataService ();
			
			service.BeginAddDevice (deviceInfo, (result) => {
				Console.WriteLine ("Done");
				this.DatabaseId = service.EndAddDevice (result);
			} , null);
		}
		
		public string OwnerName {get;set;}
		
		public int DatabaseId {get;set;}
		
		[DllImport (MonoTouch.Constants.SystemLibrary, EntryPoint="sysctlbyname")]
		private static extern int sysctlbyname ([MarshalAs (UnmanagedType.LPStr)]string name,
		                                        IntPtr oldp, ref IntPtr oldlenp, IntPtr newp, 
		                                        IntPtr newlen);
		
		[DllImport (MonoTouch.Constants.SystemLibrary, EntryPoint="sysctlbyname")]
		private static extern int sysctlbyname2 ([MarshalAs (UnmanagedType.LPStr)]string name,
		                                         StringBuilder oldp, ref IntPtr oldlenp, IntPtr newp, 
		                                         IntPtr newlen);

		private static DeviceInfo _GDevice = null;
		public static DeviceInfo CurrentDevice
		{
			get
			{
				if (_GDevice == null)
				{
					_GDevice = new DeviceInfo ();
					_GDevice.fetchInfoFromServer ();
				}

				return _GDevice;
			}
		}
		
	}
}

