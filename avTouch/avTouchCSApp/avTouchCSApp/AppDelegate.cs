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
		UINavigationController _nav;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			_ctrl = new avTouchViewController ();
			_nav = new UINavigationController (_ctrl);
			window.RootViewController = _nav;
			
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

