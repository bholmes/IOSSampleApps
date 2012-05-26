// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace avTouchCSApp
{
	[Register ("avTouchController")]
	partial class avTouchController
	{
		[Outlet]
		avTouchCSApp.CALevelMeter lvlMeter_in { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel fileName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton playButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ffwButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton rewButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider volumeSlider { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider progressBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel currentTime { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel duration { get; set; }

		[Action ("playButtonPressed:")]
		partial void playButtonPressed (MonoTouch.UIKit.UIButton sender);

		[Action ("rewButtonPressed:")]
		partial void rewButtonPressed (MonoTouch.UIKit.UIButton sender);

		[Action ("rewButtonReleased:")]
		partial void rewButtonReleased (MonoTouch.UIKit.UIButton sender);

		[Action ("ffwButtonPressed:")]
		partial void ffwButtonPressed (MonoTouch.UIKit.UIButton sender);

		[Action ("ffwButtonReleased:")]
		partial void ffwButtonReleased (MonoTouch.UIKit.UIButton sender);

		[Action ("volumeSliderMoved:")]
		partial void volumeSliderMoved (MonoTouch.UIKit.UISlider sender);

		[Action ("progressSliderMoved:")]
		partial void progressSliderMoved (MonoTouch.UIKit.UISlider sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (lvlMeter_in != null) {
				lvlMeter_in.Dispose ();
				lvlMeter_in = null;
			}

			if (fileName != null) {
				fileName.Dispose ();
				fileName = null;
			}

			if (playButton != null) {
				playButton.Dispose ();
				playButton = null;
			}

			if (ffwButton != null) {
				ffwButton.Dispose ();
				ffwButton = null;
			}

			if (rewButton != null) {
				rewButton.Dispose ();
				rewButton = null;
			}

			if (volumeSlider != null) {
				volumeSlider.Dispose ();
				volumeSlider = null;
			}

			if (progressBar != null) {
				progressBar.Dispose ();
				progressBar = null;
			}

			if (currentTime != null) {
				currentTime.Dispose ();
				currentTime = null;
			}

			if (duration != null) {
				duration.Dispose ();
				duration = null;
			}
		}
	}
}
