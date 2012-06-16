using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Text;

namespace PerformanceTesting
{
	public class GLCubeResultViewController : UITableViewController
	{
		GLCubeResults _glResults;
		
		public GLCubeResultViewController (GLCubeResults glResults) : base (UITableViewStyle.Plain)
		{
			_glResults = glResults;
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.TableView.WeakDataSource = this;
			
			UIBarButtonItem editButton = new UIBarButtonItem 
				("Edit", UIBarButtonItemStyle.Plain, editButtonClicked);
			this.NavigationItem.RightBarButtonItem = editButton;
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
			return _glResults.Count;
		}
	
		[Export ("tableView:cellForRowAtIndexPath:")]
		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell ret = tableView.DequeueReusableCell ("GLCubeResultRow");
	        if (ret == null) {
				ret = new UITableViewCell (UITableViewCellStyle.Subtitle, "GLCubeResultRow");
	        }
			
			GLCubeResult result = _glResults[indexPath.Row];
			
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
	}
}

