// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace PresentationDemo1
{
	[Register ("MyController1")]
	partial class MyController1
	{
		[Outlet]
		MonoTouch.UIKit.UILabel theLabel { get; set; }

		[Action ("OnTouch:")]
		partial void OnTouch (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (theLabel != null) {
				theLabel.Dispose ();
				theLabel = null;
			}
		}
	}
}
