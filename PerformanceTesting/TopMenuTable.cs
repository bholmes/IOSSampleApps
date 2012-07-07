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
		
		[Export ("numberOfSectionsInTableView:")]
		public virtual int NumberOfSections (UITableView tableView)
		{
			return 3;
		}

		
		[Export ("tableView:numberOfRowsInSection:")]
		public int RowsInSection (UITableView tableview, int section)
		{
			switch (section)
			{
			case 0:
				return 3;
			case 1:
				return 1;
			case 2:
				return 1;
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
				case 2 :
					ret.TextLabel.Text = "Remote GL Results";
					break;
				default:
					break;
				}
			}
			else if (indexPath.Section == 1)
			{
				switch (indexPath.Row)
				{
				case 0 :
					ret.TextLabel.Text = "Matrix Test";
					break;
				default:
					break;
				}
			}
			else if (indexPath.Section == 2)
			{
				ret.TextLabel.Text = "View Device Info";	
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
				case 2 :
					this.NavigationController.PushViewController 
						(GLCubeResultViewController.FromRemoteResults (), true);
					break;
				default:
					break;
				}
			}
			else if (indexPath.Section == 1)
			{
				this.NavigationController.PushViewController (new MatrixTestViewController (), true);	
			}
			else if (indexPath.Section == 2)
			{
				this.NavigationController.PushViewController (new DeviceInfoViewController (), true);	
			}
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
	}
}

