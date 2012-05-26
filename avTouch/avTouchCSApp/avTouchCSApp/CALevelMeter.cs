using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;


namespace avTouchCSApp
{
	[Register ("CALevelMeter")]
	public class CALevelMeter : UIView
	{
		[Export ("initWithFrame:")]
		public CALevelMeter (RectangleF frame) : base (frame)
		{
			
		}
		
		[Export ("initWithCoder:")]
		public CALevelMeter (NSCoder coder) : base (coder)
		{
			
		}
	}
}

