using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

namespace PresentationDemo1
{
	public class MyTableView2: UITableView
	{
		UINavigationController _mainCtrl;
		
		public MyTableView2 (UINavigationController mainCtrl)
		{
			_mainCtrl = mainCtrl;
			this.WeakDataSource = this;
			this.WeakDelegate = this;
		}
		
		[Export ("tableView:numberOfRowsInSection:")]
		public int RowsInSection (UITableView tableView, int section)
		{
			return 2;
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
