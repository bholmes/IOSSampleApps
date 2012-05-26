using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace avTouchCSApp
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		
		avTouchViewController _ctrl;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			_ctrl = new avTouchViewController ();
			window.RootViewController = _ctrl;
			
			
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

