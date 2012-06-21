using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Text;
using PerformanceTesting.PerformanceTestingWebService;
using System.Collections.Generic;

namespace PerformanceTesting
{
	public class GLCubeResultViewController : UITableViewController
	{
		GLCubeResults _glResults;
		object _glResultsLock = new object ();
		bool _isRemote = false;
		
		public static GLCubeResultViewController FromRemoteResults ()
		{
			GLCubeResultViewController ret = new GLCubeResultViewController ();
			ret._isRemote = true;
			
			PerformanceTestingDataService service = new PerformanceTestingDataService ();
			
			service.BeginGetPerformanceCubeResults ((result) => {
				PerformanceCubeResult [] results = service.EndGetPerformanceCubeResults (result);
				
				lock (ret._glResultsLock)
				{
					foreach (PerformanceCubeResult res in results)
					{
						ret._glResults.Add (new GLCubeResult (res.NumberOfTriangles,res.FramesPerSecond));	
					}
				}
				
				ret.InvokeOnMainThread (()=> {
					ret.TableView.ReloadData ();
				});
				
			}, null);
			
			return ret;
		}
		
		public GLCubeResultViewController (GLCubeResults glResults) : base (UITableViewStyle.Grouped)
		{
			_glResults = glResults;
		}
		
		private GLCubeResultViewController () : base (UITableViewStyle.Grouped)
		{
			_glResults = new GLCubeResults ();
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.TableView.WeakDataSource = this;
			
			if (!_isRemote)
			{
				UIBarButtonItem editButton = new UIBarButtonItem 
					("Edit", UIBarButtonItemStyle.Plain, editButtonClicked);
				UIBarButtonItem postButton = new UIBarButtonItem 
					("Post", UIBarButtonItemStyle.Plain, postButtonClicked);
				
				this.NavigationItem.SetRightBarButtonItems (
					new UIBarButtonItem[] {editButton, postButton}, false);
			}
		}
		
		void postButtonClicked (object sender, EventArgs e)
		{
			List<PerformanceCubeResult> results = new List<PerformanceCubeResult>(_glResults.Count);
			PerformanceTestingDataService service = new PerformanceTestingDataService ();
			
			for (int i=0; i<_glResults.Count; i++)
			{
				PerformanceCubeResult result = new PerformanceCubeResult ();
				result.DeviceDatabaseId = DeviceInfo.DatabaseId;
				result.DeviceDatabaseIdSpecified = true;
				result.NumberOfTriangles = _glResults[i].NumberOfTriangles;
				result.NumberOfTrianglesSpecified = true;
				result.FramesPerSecond = _glResults[i].FramesPerSecond;
				result.FramesPerSecondSpecified = true;
				results.Add (result);
			}
			
			service.BeginAddPerformanceCubeResults (
					results.ToArray (), (addResult) => {
					Console.WriteLine ("Done");
				}, null);
		}
		
		void editButtonClicked (object sender, EventArgs e)
		{
			this.SetEditing (!this.Editing, true);
			
			if (this.Editing)
			{
				this.NavigationItem.RightBarButtonItem.Title = "Done";
				this.NavigationItem.RightBarButtonItem.Style = UIBarButtonItemStyle.Done;
				
			}
			else
			{
				this.NavigationItem.RightBarButtonItem.Title = "Edit";
				this.NavigationItem.RightBarButtonItem.Style = UIBarButtonItemStyle.Plain;
			}
			
		}
		
		[Export ("tableView:numberOfRowsInSection:")]
		public int RowsInSection (UITableView tableview, int section)
		{
			lock (_glResultsLock)
			{
				return _glResults.Count;
			}
		}
	
		[Export ("tableView:cellForRowAtIndexPath:")]
		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell ret = tableView.DequeueReusableCell ("GLCubeResultRow");
	        if (ret == null) {
				ret = new UITableViewCell (UITableViewCellStyle.Value1, "GLCubeResultRow");
	        }
			
			GLCubeResult result;
			
			lock (_glResultsLock)
			{
				result = _glResults[indexPath.Row];
			}
			
			ret.SelectionStyle = UITableViewCellSelectionStyle.None;
			ret.TextLabel.Text = result.NumberOfTriangles + " triangles";
			ret.DetailTextLabel.Text = result.FramesPerSecond.ToString ("N2") + " fps";
			
			return ret;
		}

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			return;
		}
		
		[Export ("tableView:editingStyleForRowAtIndexPath:")]
		public UITableViewCellEditingStyle EditingStyleForRow (UITableView tableView, NSIndexPath indexPath)
		{
			// No editing style if not editing or the index path is nil.
		    if (!this.Editing || indexPath == null)
				return UITableViewCellEditingStyle.None;
		    // Determine the editing style based on whether the cell is a placeholder for adding content or already 
		    // existing content. Existing content can be deleted.   
		    if (this.Editing) 
		    {
		        return UITableViewCellEditingStyle.Delete;
		    }
			
		    return UITableViewCellEditingStyle.None;
		}

		
		[Export ("tableView:commitEditingStyle:forRowAtIndexPath:")]
		public void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete) 
		    {
				_glResults.RemoveAt (indexPath.Row);
		        this.TableView.ReloadData ();
		    }
		}
		[Export ("tableView:canMoveRowAtIndexPath:")]
		public virtual bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
		{
			return true;
		}

		[Export ("tableView:moveRowAtIndexPath:toIndexPath:")]
		public virtual void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
		{
			GLCubeResult result = _glResults[sourceIndexPath.Row];
			_glResults.RemoveAt (sourceIndexPath.Row);
			_glResults.Insert (destinationIndexPath.Row, result);
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
	}
}

