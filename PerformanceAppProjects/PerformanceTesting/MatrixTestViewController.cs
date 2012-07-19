using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace PerformanceTesting
{
	public class MatrixTestViewController : UITableViewController
	{
		private MatrixTest [] _currentTests = new MatrixTest[3];
		private UIButton _runButton;

		public MatrixTestViewController () : base (UITableViewStyle.Grouped)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = "Matrix Test";
			this.TableView.WeakDataSource = this;
		}

		[Export ("tableView:titleForHeaderInSection:")]
		public virtual string TitleForHeader (UITableView tableView, int section)
		{
			switch (section)
			{
			case 1:
				return "C# Result";
			case 2:
				return "Objective C Result";
			case 3:
				return "BLAS Result";
			}

			return string.Empty;
		}

		[Export ("numberOfSectionsInTableView:")]
		public virtual int NumberOfSections (UITableView tableView)
		{
			if (_currentTests[2] != null)
				return 4;
			if (_currentTests[1] != null)
				return 3;
			if (_currentTests[0] != null)
				return 2;
			return 1;
		}

		[Export ("tableView:numberOfRowsInSection:")]
		public int RowsInSection (UITableView tableview, int section)
		{
			if (section != 0 && _currentTests != null && _currentTests[section-1] != null)
				return 5;

			return 0;
		}

		[Export ("tableView:cellForRowAtIndexPath:")]
		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell ret = null;
			
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
					ret.TextLabel.Text = "Matrix Size";
					ret.DetailTextLabel.Text = _currentTests[indexPath.Section-1].MatrixSize.ToString ();
					break;
				case 1:
					ret.TextLabel.Text = "Iterations";
					ret.DetailTextLabel.Text = _currentTests[indexPath.Section-1].Iterations.ToString ();
					break;
				case 2:
					ret.TextLabel.Text = "MFlops";
					ret.DetailTextLabel.Text = _currentTests[indexPath.Section-1].MFlops.ToString ("N3");
					break;
				case 3:
					ret.TextLabel.Text = "Time";
					ret.DetailTextLabel.Text = _currentTests[indexPath.Section-1].Seconds.ToString ("N3");
					break;
				case 4:
					ret.TextLabel.Text = "MFlops/Second";
					ret.DetailTextLabel.Text = _currentTests[indexPath.Section-1].MFlopsPerSecond.ToString ("N3");
					break;
				}
			}

			return ret;
		}

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{

		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}

		[Export ("tableView:heightForHeaderInSection:")]
		public virtual float GetHeightForHeader (UITableView tableView, int section)
		{
			return 44;
		}

		[Export ("tableView:viewForHeaderInSection:")]
		public virtual UIView GetViewForHeader (UITableView tableView, int section)
		{
			if (section == 0)
			{
				UIView view = new UIView (new RectangleF (0, 0, 300, 45));
				_runButton = UIButton.FromType (UIButtonType.RoundedRect);
				_runButton.Frame = new RectangleF (10, 10, 100, 35);
				_runButton.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin;
				_runButton.SetTitle ("Run", UIControlState.Normal);
				_runButton.TouchUpInside += TouchRunButton;
				view.BackgroundColor = UIColor.Clear;
				view.AddSubview (_runButton);

				return view;
			}

			return null;
		}

		void TouchRunButton (object sender, EventArgs e)
		{
			if(_runButton.Title (UIControlState.Normal) == "Running")
				return;

			_runButton.SetTitle ("Running", UIControlState.Normal);
			UIApplication.SharedApplication.IdleTimerDisabled = true;

			System.Threading.ThreadStart ts = new System.Threading.ThreadStart (() => {

				MatrixTestEngine engine = new MatrixTestEngine ();
				_currentTests[0] = engine.RunCSTest ();
				_currentTests[1] = engine.RunCTest (false);
				_currentTests[2] = engine.RunCTest (true);

				this.InvokeOnMainThread ( () => {
					this.TableView.ReloadData ();
					_runButton.SetTitle ("Run", UIControlState.Normal);
					UIApplication.SharedApplication.IdleTimerDisabled = false;
				});
			});

			ts.BeginInvoke (null, null);
		}
	}
}

	

