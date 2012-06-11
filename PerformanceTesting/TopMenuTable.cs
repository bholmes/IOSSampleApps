using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace PerformanceTesting
{
	public class TopMenuTable : UITableViewController
	{
		public TopMenuTable () : base (UITableViewStyle.Grouped)
		{
			
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = "Menu";
			this.TableView.WeakDataSource = this;
		}	
		
		[Export ("tableView:numberOfRowsInSection:")]
		public int RowsInSection (UITableView tableview, int section)
		{
			return 1;	
		}
	
		[Export ("tableView:cellForRowAtIndexPath:")]
		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell ret = tableView.DequeueReusableCell ("RootItem1");
	        if (ret == null) {
				ret = new UITableViewCell (UITableViewCellStyle.Default, "RootItem1");
	        }
			ret.TextLabel.Text = "GL Performance Cube";
			return ret;
		}

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			this.NavigationController.PushViewController (new GLPerformanceCube (), true);
		}
	}
}

