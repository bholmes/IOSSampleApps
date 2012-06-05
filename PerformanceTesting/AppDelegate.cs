using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MonoTouch.GLKit;
using MonoTouch.OpenGLES;
using System.Drawing;
using OpenTK.Graphics.ES11;
using OpenTK;


namespace PerformanceTesting
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController _nav;
		TopMenuTable _menu;
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			_menu = new TopMenuTable ();
			_nav = new UINavigationController (_menu);
			_nav.NavigationBar.BarStyle = UIBarStyle.Black;
			
			window.RootViewController = _nav;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
	
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
	
	public class GLPerformanceCube : GLKViewController //UIViewController
	{
		GLKView _view;
		float angle = 0;
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = "GL Performance Cube";
			_setupView ();
		}
		
		void _setupView ()
		{
			base.ViewDidLoad ();
			
			// Craete a new context if needed
			if (EAGLContext.CurrentContext == null)
				EAGLContext.SetCurrentContext (new EAGLContext (EAGLRenderingAPI.OpenGLES1));
			
			_view = new GLKView (this.View.Bounds);
			_view.Context = EAGLContext.CurrentContext;
			_view.WeakDelegate = this;
			this.View.AddSubview (_view);
			
			float aspect = this.View.Bounds.Height / this.View.Bounds.Width;
			float worldBounds = 1.5f;
			
			GL.Viewport(0, 0, (int)this.View.Bounds.Width, (int)this.View.Bounds.Height);
			GL.MatrixMode(All.Projection);
			GL.LoadIdentity();
			GL.Ortho(-worldBounds, worldBounds, -worldBounds * aspect, 
			         worldBounds * aspect, -worldBounds, worldBounds);
			GL.MatrixMode(All.Modelview);
		}
		
		[Export ("glkView:drawInRect:")]
		public void glkViewDrawInRect (GLKView view, RectangleF rect)
		{
			GL.PushMatrix ();
			GL.ClearColor (0.0f, 0.0f, 0.0f, 1.0f);
			
			// Clear all old bits
			GL.Clear ((int)(All.ColorBufferBit));
			
			GL.Rotate (angle, 0, 1, 0);
			
			float [] vertices = {
				-1, -1,
				 1, -1, 
				-1,  1
			};		
			
			GL.Color4 (1f, 0f, 0f, 1f);
            
			GL.VertexPointer(2, All.Float, 0, vertices);
			GL.EnableClientState (All.VertexArray);
			
			GL.DrawArrays(All.Triangles, 0, 3);
			
			vertices = new float [] {
				-1,  1,
				 1, -1,
				 1,  1
			};		
			
			GL.Color4 (0f, 0f, 1f, 1f);
            
			GL.VertexPointer(2, All.Float, 0, vertices);
			GL.EnableClientState (All.VertexArray);
			
			GL.DrawArrays(All.Triangles, 0, 3);
			
			GL.Flush ();
			GL.PopMatrix ();
		}
	}
}

