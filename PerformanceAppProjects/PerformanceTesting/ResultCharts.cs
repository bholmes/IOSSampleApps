using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace PerformanceTesting
{
	public class ResultCharts : UIViewController
	{
		UIWebView _webView;

		public ResultCharts ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_webView = new UIWebView (UIScreen.MainScreen.Bounds);
			_webView.LoadRequest (new NSUrlRequest (new NSUrl ("http://apps.slapholmesproductions.com/apps/PerformanceApp/default.aspx")));
			_webView.AutoresizingMask = UIViewAutoresizing.All;
			_webView.ScalesPageToFit = true;
			this.View.AutosizesSubviews = true;

			this.View.Add (_webView);
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
	}
}

