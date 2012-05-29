using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Collections.Generic;

namespace avTouchCSApp
{
	public partial class avTouchViewController : UIViewController
	{
		private UIBarButtonItem _editButton;
		AppProperties _appProperties = new AppProperties ();
		
		public avTouchViewController () : base ("avTouchViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			if (this.NavigationController != null)
			{
				this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
				_editButton = new UIBarButtonItem ("Edit", UIBarButtonItemStyle.Bordered, editButtonClicked);
				this.NavigationItem.RightBarButtonItem = _editButton;
				this.NavigationController.WeakDelegate = this;
			}
			
			controller.LoadProperties (_appProperties);
		}
		
		EditPropertiesController _editPropertiesCtrl;
		
		void editButtonClicked (object sender, EventArgs e)
		{
			_editPropertiesCtrl = new EditPropertiesController (_appProperties);	
			this.NavigationController.PushViewController (_editPropertiesCtrl, true);
		}
		
		[Export ("navigationController:willShowViewController:animated:")]
		public void WillShowViewController (UINavigationController navigationController, UIViewController viewController, bool animated)
		{
			if (viewController is avTouchViewController && _editPropertiesCtrl != null)
			{
				Console.WriteLine (_editPropertiesCtrl.Properties);
				controller.LoadProperties (_editPropertiesCtrl.Properties);
				_editPropertiesCtrl = null;
			}
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation == UIInterfaceOrientation.Portrait);
		}
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}
		
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}
		
		public override bool CanBecomeFirstResponder {
			get {
				return true;
			}
		}
		
		public override void RemoteControlReceived (UIEvent theEvent)
		{
			base.RemoteControlReceived (theEvent);
		}
	}
}

