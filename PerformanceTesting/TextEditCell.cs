using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;


namespace PerformanceTesting
{
	public class TextEditCell : UITableViewCell
	{
		UITextField _textField;
		
		public TextEditCell (string resuseIdentifier) : base (UITableViewCellStyle.Value1, "resuseIdentifier")
		{
			this.SelectionStyle = UITableViewCellSelectionStyle.None;
			
			_textField = new UITextField (new RectangleF (150, 10, 160, 30));
	        _textField.AdjustsFontSizeToFitWidth = true;
	        _textField.TextColor = UIColor.Black;
			_textField.Placeholder = "enter name";
			_textField.KeyboardType = UIKeyboardType.Default;
            _textField.ReturnKeyType = UIReturnKeyType.Done;
			
			_textField.BackgroundColor = UIColor.Clear;
	        _textField.AutocorrectionType = UITextAutocorrectionType.No; // no auto correction support
	        _textField.AutocapitalizationType = UITextAutocapitalizationType.None; // no auto capitalization support
	        _textField.TextAlignment = UITextAlignment.Right;
	        _textField.Tag = 0;
	        _textField.WeakDelegate = this;
			_textField.AutoresizingMask = UIViewAutoresizing.All;
	
	        //_textField.ClearButtonMode = UITextFieldViewMode.WhileEditing; // no clear 'x' button to the right
			_textField.ClearButtonMode = UITextFieldViewMode.Never; // no clear 'x' button to the right
			_textField.Enabled= true;
			_textField.Font = this.DetailTextLabel.Font;
			
			this.AddSubview (_textField);
		}
		
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();	
			
			float x = this.Subviews[0].Frame.X + this.TextLabel.Frame.X;
			
			RectangleF rect = this.TextLabel.Bounds;
			
			rect.X = x + rect.Width + 10;
			rect.Width = this.Bounds.Width - (rect.X + x);
			rect.Y = 10; rect.Height = 30;
			
			//rect.X += 150; rect.Width -= 150;
			_textField.Frame = rect;
			_textField.Font = this.DetailTextLabel.Font;
			_textField.TextColor = this.DetailTextLabel.TextColor;
			//_textField.BackgroundColor = UIColor.Black;
			//this.TextLabel.BackgroundColor = UIColor.Black;
		}	

		public UITextField TextField 
		{
			get 
			{
				return _textField;
			}
		}
		
		[Export ("textFieldDidEndEditing:")]
		public virtual void EditingEnded (UITextField textField)
		{
			DeviceInfo.OwnerName = textField.Text;
		}
		
		[Export ("textFieldShouldReturn:")]
		public virtual bool ShouldReturn (UITextField textField)
		{
			textField.ResignFirstResponder ();
			return false;
		}
	}
}

