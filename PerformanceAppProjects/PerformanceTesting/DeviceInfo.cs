using System;
using System.Runtime.InteropServices;
using System.Text;
using MonoTouch.UIKit;


namespace PerformanceTesting
{
	public class DeviceInfo
	{
		private DeviceInfo ()
		{
			
		}
		
		public static string DeviceName
		{
			get 
			{
				return UIDevice.CurrentDevice.Name;	
			}
		}
		
		public static string OSName
		{
			get 
			{
				return UIDevice.CurrentDevice.SystemName;	
			}
		}
		
		public static string OSVersion
		{
			get 
			{
				return UIDevice.CurrentDevice.SystemVersion;	
			}
		}
		
		public static string ModelName
		{
			get 
			{
				return UIDevice.CurrentDevice.Model;	
			}
		}
		
		static private string _specificHWVersion;
		
		public static string SpecificHWVersion 
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
		
		public static string UniqueId 
		{
			get 
			{
				return UIDevice.CurrentDevice.UniqueIdentifier;	
			}
		}
		
		public static string UIIdion 
		{
			get 
			{
				return UIDevice.CurrentDevice.UserInterfaceIdiom.ToString ();	
			}
		}
		
		public static string OwnerName {get;set;}
		
		public static int DatabaseId {get;set;}
		
		[DllImport (MonoTouch.Constants.SystemLibrary, EntryPoint="sysctlbyname")]
		private static extern int sysctlbyname ([MarshalAs (UnmanagedType.LPStr)]string name,
		                                        IntPtr oldp, ref IntPtr oldlenp, IntPtr newp, 
		                                        IntPtr newlen);
		
		[DllImport (MonoTouch.Constants.SystemLibrary, EntryPoint="sysctlbyname")]
		private static extern int sysctlbyname2 ([MarshalAs (UnmanagedType.LPStr)]string name,
		                                         StringBuilder oldp, ref IntPtr oldlenp, IntPtr newp, 
		                                         IntPtr newlen);
		
	}
}

