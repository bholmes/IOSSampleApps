// This file has been autogenerated from parsing an Objective-C header file added in Xcode.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace PresentationDemo1
{
	public partial class MyController1 : UIViewController
	{
		int count = 1;
		public MyController1 (IntPtr handle) : base (handle)
		{
		}

		partial void OnTouch (NSObject sender)
		{
			theLabel.Text = string.Format("You clicked the button {0} times", count++);
		}
	}
}
