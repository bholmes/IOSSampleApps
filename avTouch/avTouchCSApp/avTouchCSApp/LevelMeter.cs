using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;


namespace avTouchCSApp
{
	public class LevelMeter : UIView, LevelMeterItf
	{
		uint						_numLights;
		float						_level, _peakLevel;
		LevelMeterColorThreshold []	_colorThresholds;
		bool						_vertical;
		bool						_variableLightIntensity;
		float 						_maxIntensity = 1f;
		UIColor						_bgColor;
		UIColor	 					_borderColor;
		
		[Export ("initWithFrame:")]
		public LevelMeter (RectangleF frame) : base (frame)
		{
			_performInit ();	
		}
		
		[Export ("initWithCoder:")]
		public LevelMeter (NSCoder coder) : base (coder)
		{
			_performInit ();
		}
		
		void _performInit ()
		{
			_level = 0f;
			_numLights = 0;
			_variableLightIntensity = true;
			_bgColor = UIColor.FromRGBA (0, 0, 0, 0.6f);
			_borderColor = UIColor.FromRGBA (0, 0, 0, 1f);
			_colorThresholds = new LevelMeterColorThreshold[3];
			_colorThresholds[0].maxValue = 0.25f;
			_colorThresholds[0].color = UIColor.FromRGBA (0, 1, 0, 1f);
			_colorThresholds[1].maxValue = 0.8f;
			_colorThresholds[1].color = UIColor.FromRGBA (1, 1, 0, 1f);
			_colorThresholds[2].maxValue = 1f;
			_colorThresholds[2].color = UIColor.FromRGBA (1, 0, 0, 1f);
			_vertical = (this.Frame.Size.Width < this.Frame.Size.Height) ? true : false;
		}
		
		public override void Draw (RectangleF a_rect)
		{
			CGColorSpace cs;
			CGContext cxt;
			RectangleF bds;
			
			cxt = UIGraphics.GetCurrentContext ();
			cs = CGColorSpace.CreateDeviceRGB();
			
			if (_vertical)
			{
				cxt.TranslateCTM (0, this.Bounds.Size.Height);
				cxt.ScaleCTM (1f, -1f);
				bds = this.Bounds;
			} 
			else
			{
				cxt.TranslateCTM (0, this.Bounds.Size.Height);
				cxt.RotateCTM ((float)(-Math.PI / 2f) );
				bds = new RectangleF (0f, 0f, this.Bounds.Size.Height, this.Bounds.Size.Width);
			}
			
			cxt.SetFillColorSpace (cs);
			cxt.SetStrokeColorSpace (cs);
			
			if (_numLights == 0)
			{
				int i;
				float currentTop = 0f;
				
				if (_bgColor != null)
				{
					_bgColor.SetColor ();
					cxt.FillRect (bds);
				}
				
				for (i=0; i<_colorThresholds.Length; i++)
				{
					LevelMeterColorThreshold thisThresh = _colorThresholds[i];
					float val = Math.Min (thisThresh.maxValue, _level);
					
					RectangleF rect = new RectangleF(
											 0, 
											 (bds.Height) * currentTop, 
											 bds.Width, 
											 (bds.Height) * (val - currentTop)
											 );
					
					CGColor clr = new CGColor (thisThresh.color.CGColor, _maxIntensity); 
					cxt.SetFillColor (clr);
					cxt.FillRect(rect);
					
					if (_level < thisThresh.maxValue) 
						break;
					
					currentTop = val;
				}
				
				if (_borderColor != null)
				{
					_borderColor.SetColor ();
					cxt.StrokeRect( bds.Inset (.5f, .5f));
				}
			
			} 
			else
			{
				int light_i;
				float lightMinVal = 0f;
				float insetAmount, lightVSpace;
				lightVSpace = bds.Height / (float)_numLights;
				if (lightVSpace < 4f) insetAmount = 0f;
				else if (lightVSpace < 8f) insetAmount = 0.5f;
				else insetAmount = 1f;
				
				int peakLight = -1;
				if (_peakLevel > 0f)
				{
					peakLight = (int)(_peakLevel * _numLights);
					if (peakLight >= _numLights)
						peakLight = (int)(_numLights - 1);
				}
				
				for (light_i=0; light_i<_numLights; light_i++)
				{
					float lightMaxVal = (float)(light_i + 1) / (float)_numLights;
					float lightIntensity;
					RectangleF lightRect;
					UIColor lightColor;
					
					if (light_i == peakLight)
					{
						lightIntensity = _maxIntensity;
					} 
					else
					{
						lightIntensity = (_level - lightMinVal) / (lightMaxVal - lightMinVal);
						lightIntensity = LEVELMETER_CLAMP(0f, lightIntensity, _maxIntensity);
						
						if ((!_variableLightIntensity) && (lightIntensity > 0f)) 
							lightIntensity = _maxIntensity;
					}
					
					lightColor = _colorThresholds[0].color;
					int color_i;
					for (color_i=0; color_i<(_colorThresholds.Length-1); color_i++)
					{
						LevelMeterColorThreshold thisThresh = _colorThresholds[color_i];
						LevelMeterColorThreshold nextThresh = _colorThresholds[color_i + 1];
						if (thisThresh.maxValue <= lightMaxVal) 
							lightColor = nextThresh.color;
					}
					
					lightRect = new RectangleF(
										   0f, 
										   bds.Height * ((float)(light_i) / (float)_numLights), 
										   bds.Width,
										   bds.Height * (1f / (float)_numLights)
										   );
					lightRect = lightRect.Inset (insetAmount, insetAmount);
					
					if (_bgColor != null)
					{
						_bgColor.SetColor ();
						cxt.FillRect (lightRect);
					}
					
					if (lightIntensity == 1f)
					{
						lightColor.SetColor ();
						cxt.FillRect (lightRect);
					} 
					else if (lightIntensity > 0f)
					{
						CGColor clr = new CGColor (lightColor.CGColor, lightIntensity); 
						cxt.SetFillColor (clr);
						cxt.FillRect (lightRect);
						clr.Dispose ();
					}
					
					if (_borderColor != null)
					{
						_borderColor.SetColor ();
						cxt.StrokeRect (lightRect.Inset (0.5f, 0.5f));
					}
					
					lightMinVal = lightMaxVal;
				}
				
			}
			
			cs.Dispose ();

		}
		
		public static float LEVELMETER_CLAMP(float min, float x, float max)
		{
			return x < min ? min : (x > max ? max : x);
		}

		public float Level {
			get {
				return _level;
			}
			set {
				_level = value;
			}
		}

		public float PeakLevel {
			get {
				return _peakLevel;
			}
			set {
				_peakLevel = value;
			}
		}

		public bool Vertical {
			get {
				return _vertical;
			}
			set {
				_vertical = value;
			}
		}

		public void LoadProperties (AppProperties appProperties)
		{
			this._maxIntensity = appProperties.meterIntensity;
			this._numLights = (uint)appProperties.numLights;
			this._variableLightIntensity = appProperties.variableLightIntensity;
			
			this.SetNeedsDisplay ();
		}
	}
}

