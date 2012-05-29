using System;
using MonoTouch.Dialog;


namespace avTouchCSApp
{
	public class EditPropertiesController : DialogViewController
	{
		AppProperties _appProperties;
		BindingContext _bctx;
		public AppProperties Properties
		{
			get
			{
				_bctx.Fetch ();
				return _appProperties;	
			}
		}
		
		public EditPropertiesController (AppProperties appProperties) : base (null, true)
		{
			_appProperties = appProperties;
			_bctx = new BindingContext (null, _appProperties, "Properties");
			this.Root = _bctx.Root;
		}
	}
}

