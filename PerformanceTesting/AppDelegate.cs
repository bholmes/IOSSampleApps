using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace PerformanceTesting
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController _nav;
		TopMenuTable _menu;
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
//			try
//			{
//				MonoTouch.TestFlight.TestFlight.
//					SetDeviceIdentifier (UIDevice.CurrentDevice.UniqueIdentifier);
//				
//				MonoTouch.TestFlight.TestFlight.
//					TakeOff ("token removed");
//			}
//			catch (Exception exp)
//			{
//				Console.WriteLine (exp.Message);	
//			}
			
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			_menu = new TopMenuTable ();
			_nav = new UINavigationController (_menu);
			_nav.NavigationBar.BarStyle = UIBarStyle.Black;
			
			window.RootViewController = _nav;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
	
	
	
	
}

