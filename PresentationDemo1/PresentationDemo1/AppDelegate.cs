using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MonoTouch.CoreGraphics;

namespace PresentationDemo1
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController _mainCtrl;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			UITableViewController tableViewCtrl = new UITableViewController (UITableViewStyle.Grouped);
		
			_mainCtrl = new UINavigationController (tableViewCtrl);
			tableViewCtrl.TableView = new MyTableView (_mainCtrl);

			window.RootViewController = _mainCtrl;

			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}

	public class MyTableView: UITableView
	{
		UINavigationController _mainCtrl;

		public MyTableView (UINavigationController mainCtrl)
		{
			_mainCtrl = mainCtrl;
			this.WeakDataSource = this;
			this.WeakDelegate = this;
		}

		[Export ("tableView:cellForRowAtIndexPath:")]
		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell ("Cell1");
			if (cell == null)
			{
				cell = new UITableViewCell (UITableViewCellStyle.Default, "Cell1");
			}
			
			cell.TextLabel.Text = "Item " + (indexPath.Row + 1);
			
			return cell;
		}
		
		[Export ("numberOfSectionsInTableView:")]
		public int NumberOfSections (UITableView tableView)
		{
			return 1;
		}
		
		[Export ("tableView:numberOfRowsInSection:")]
		public int RowsInSection (UITableView tableView, int section)
		{
			return 2;
		}

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public  void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			UIViewController newViewCtrl = new UIViewController ();
			newViewCtrl.Title = "Item " + (indexPath.Row + 1);

			newViewCtrl.View.BackgroundColor = UIColor.White;
			
			UILabel label = new UILabel (
				new System.Drawing.RectangleF (
					newViewCtrl.View.Bounds.GetMidX () - 75,
					newViewCtrl.View.Bounds.GetMidY () - 50,
					150, 30)
				);

			label.Text = "Hello";
			label.TextAlignment = UITextAlignment.Center;

			UIButton button = UIButton.FromType (UIButtonType.RoundedRect);
			button.SetTitle ("Click Me", UIControlState.Normal);
			button.Frame = new System.Drawing.RectangleF (
				newViewCtrl.View.Bounds.GetMidX () - 100,
				newViewCtrl.View.Bounds.GetMidY () - 15,
				200, 30
				);

			int touchCount = 1;

			button.TouchUpInside += delegate {
				label.Text = string.Format ("Clicked {0} times", touchCount++);
			};
			
			newViewCtrl.View.Add (label);
			newViewCtrl.View.Add (button);

			_mainCtrl.PushViewController (newViewCtrl, true);	
		}
	}
}

