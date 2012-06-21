using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace PerformanceTesting
{
	public class DeviceInfoViewController : UITableViewController
	{
		public DeviceInfoViewController () : base (UITableViewStyle.Grouped)
		{
			
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.TableView.WeakDataSource = this;
			
			UIBarButtonItem registerButton = new UIBarButtonItem 
				("Register", UIBarButtonItemStyle.Plain, registerButtonClicked);
			this.NavigationItem.RightBarButtonItem = registerButton;
		}
		
		void registerButtonClicked (object sender, EventArgs e)
		{
			
		}
		
		[Export ("numberOfSectionsInTableView:")]
		public virtual int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		
		[Export ("tableView:numberOfRowsInSection:")]
		public int RowsInSection (UITableView tableview, int section)
		{
			return 6;
		}
	
		[Export ("tableView:cellForRowAtIndexPath:")]
		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell ret;
			
			if (indexPath.Row < 5)
			{
				ret = tableView.DequeueReusableCell ("RootItem1");
		        if (ret == null) 
				{
					ret = new UITableViewCell (UITableViewCellStyle.Value1, "RootItem1");
					ret.SelectionStyle = UITableViewCellSelectionStyle.None;
		        }
				
				switch (indexPath.Row)
				{
				case 0:
					ret.TextLabel.Text = "Device Name";
					ret.DetailTextLabel.Text = DeviceInfo.DeviceName;
					break;
				case 1:
					ret.TextLabel.Text = "OS Name";
					ret.DetailTextLabel.Text = DeviceInfo.OSName;
					break;
				case 2:
					ret.TextLabel.Text = "OS Version";
					ret.DetailTextLabel.Text = DeviceInfo.OSVersion;
					break;
				case 3:
					ret.TextLabel.Text = "Model Name";
					ret.DetailTextLabel.Text = DeviceInfo.ModelName;
					break;
				case 4:
					ret.TextLabel.Text = "Model Id";
					ret.DetailTextLabel.Text = DeviceInfo.SpecificHWVersion;
					break;
				case 5:
					ret.TextLabel.Text = "Owner Name";
					ret.DetailTextLabel.Text = DeviceInfo.OwnerName;
					break;
					
				default:
					break;
				}
			}
			else
			{
				ret = tableView.DequeueReusableCell ("RootItem2");
		        if (ret == null) 
				{
					ret = new TextEditCell ("RootItem2");
		        }	
				
				ret.TextLabel.Text = "Owner Name";
				((TextEditCell)ret).TextField.Text = DeviceInfo.OwnerName;
			}
			
			return ret;
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
	}
}

