// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace PresentationDemo1
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIToolbar toolbar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel theLabel { get; set; }

		[Action ("OnTouch:")]
		partial void OnTouch (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (toolbar != null) {
				toolbar.Dispose ();
				toolbar = null;
			}

			if (theLabel != null) {
				theLabel.Dispose ();
				theLabel = null;
			}
		}
	}
}
