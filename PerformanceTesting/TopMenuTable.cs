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
			switch (section)
			{
			case 0:
				return 2;
			default:
				return 0;
			}
		}
	
		[Export ("tableView:cellForRowAtIndexPath:")]
		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell ret = tableView.DequeueReusableCell ("RootItem1");
	        if (ret == null) {
				ret = new UITableViewCell (UITableViewCellStyle.Default, "RootItem1");
				ret.SelectionStyle = UITableViewCellSelectionStyle.None;
	        }
			if (indexPath.Section == 0)
			{
				switch (indexPath.Row)
				{
				case 0 :
					ret.TextLabel.Text = "GL Performance Cube";
					break;
				case 1 :
					ret.TextLabel.Text = "Local GL Results";
					break;
				default:
					break;
				}
			}
			return ret;
		}

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Section == 0)
			{
				switch (indexPath.Row)
				{
				case 0 :
					this.NavigationController.PushViewController (new GLPerformanceCube (), true);
					break;
				case 1 :
					this.NavigationController.PushViewController 
						(new GLCubeResultViewController (ResultData.Results.GLCubeResults), true);
					break;
				default:
					break;
				}
			}
			
		}
	}
}

