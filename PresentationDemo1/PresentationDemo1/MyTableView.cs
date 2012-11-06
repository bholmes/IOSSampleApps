using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

namespace PresentationDemo1
{
	public class MyTableView: UITableView
	{
		public MyTableView (UINavigationController mainCtrl)
		{
			this.DataSource = new MyDataSource ();
			this.Delegate = new MyTableDelegate (){MainCtrl = mainCtrl};
		}

		private class MyDataSource : UITableViewDataSource
		{
			public override int RowsInSection (UITableView tableView, int section)
			{
				return 2;
			}
			
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell ("Cell1");
				if (cell == null)
				{
					cell = new UITableViewCell (UITableViewCellStyle.Default, "Cell1");
				}
				
				cell.TextLabel.Text = "Item " + (indexPath.Row + 1);
				
				return cell;
			}
		}
		
		private class MyTableDelegate : UITableViewDelegate
		{
			public UINavigationController MainCtrl {get;set;}
			
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
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
				
				MainCtrl.PushViewController (newViewCtrl, true);	
			}
		}
	}
}

