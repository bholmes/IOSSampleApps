using System;
using MonoTouch.UIKit;
using MonoTouch.GLKit;
using MonoTouch.OpenGLES;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.CoreAnimation;
using OpenTK.Graphics.ES11;
using MonoTouch.CoreGraphics;


namespace avTouchCSApp
{
	public class GLLevelMeter : GLKView, LevelMeterItf
	{
		uint						_numLights;
		float						_level, _peakLevel;
		LevelMeterColorThreshold []	_colorThresholds;
		bool						_vertical;
		bool						_variableLightIntensity;
		float 						_maxIntensity = 1f;
		
		float                     	_scaleFactor;
		int           				_backingWidth;
		int           				_backingHeight;
		
		[Export ("initWithFrame:")]
		public GLLevelMeter (RectangleF frame) : base (frame)
		{
			_performInit ();	
		}
		
		[Export ("initWithCoder:")]
		public GLLevelMeter (NSCoder coder) : base (coder)
		{
			_performInit ();
		}
		
		void _performInit ()
		{
			_level = 0f;
			_numLights = 0;
			_variableLightIntensity = true;
			    
			_colorThresholds = new LevelMeterColorThreshold[3];
			_colorThresholds[0].maxValue = 0.6f;
			_colorThresholds[0].color = UIColor.FromRGBA(0, 1f, 0, 1f);
			_colorThresholds[1].maxValue = 0.9f;
			_colorThresholds[1].color = UIColor.FromRGBA(1f, 1f, 0, 1f);
			_colorThresholds[2].maxValue = 1f;
			_colorThresholds[2].color = UIColor.FromRGBA(1, 0, 0, 1f);
			_vertical = (this.Frame.Size.Width < this.Frame.Size.Height) ? true : false;
		    
			if (this.RespondsToSelector (new Selector ("setContentScaleFactor")))
			{
				_scaleFactor = this.ContentScaleFactor = UIScreen.MainScreen.Scale;
		    } 
			else
			{
		        _scaleFactor = 1.0f;
		    }
			
			this._setupView ();

		}
		
		void _setupView ()
		{
			// Craete a new context if needed
			if (EAGLContext.CurrentContext == null)
				EAGLContext.SetCurrentContext (new EAGLContext (EAGLRenderingAPI.OpenGLES1));
			
			this.Context = EAGLContext.CurrentContext;
			
			_backingWidth = (int)this.Bounds.Width;
			_backingHeight = (int)this.Bounds.Height;
			// Sets up matrices and transforms for OpenGL ES
			GL.Viewport(0, 0, _backingWidth, _backingHeight);
			GL.MatrixMode(All.Projection);
			GL.LoadIdentity();
			GL.Ortho(0, _backingWidth, 0, _backingHeight, -1.0f, 1.0f);
			GL.MatrixMode(All.Modelview);
			
			// Clears the view with black
			GL.ClearColor (0.0f, 0.0f, 0.0f, 1.0f);
			
			GL.Color4(1.0f,1.0f,1.0f,0.5f);	
			GL.BlendFunc(All.SrcAlpha, All.One);
			
			GL.Enable (All.Blend);		
			GL.Disable (All.DepthTest);

		}
		
		public override void Draw (RectangleF a_rect)
		{
			// Set the back color to black
			GL.ClearColor (0.0f, 0.0f, 0.0f, 1.0f);
			
			// Clear all old bits
			GL.Clear ((int)(All.ColorBufferBit));
			
			GL.PushMatrix();
	
			RectangleF bds;
			
			if (_vertical)
			{
		        GL.Scale (1f, -1f, 1f);
				bds = new RectangleF (0f, -1f, 
				          	this.Bounds.Width * _scaleFactor, 
				            this.Bounds.Height * _scaleFactor);
			} else {
				GL.Translate(0f, this.Bounds.Height * _scaleFactor, 0f);
				GL.Rotate(-90f, 0f, 0f, 1f);
				bds = new RectangleF (0f, 1f, 
				        	this.Bounds.Height * _scaleFactor, 
				          	this.Bounds.Width * _scaleFactor);
			}
			
			if (_numLights == 0)
			{
				int i;
				float currentTop = 0f;
				
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
					
					float [] vertices = new float[] {
						rect.GetMinX (), rect.GetMinY (),
						rect.GetMaxX (), rect.GetMinY (),
						rect.GetMinX (), rect.GetMaxY (),
						rect.GetMaxX (), rect.GetMaxY ()
					};
					
					CGColor clr = thisThresh.color.CGColor;
					if (clr.NumberOfComponents != 4) 
						goto bail;
					float [] rgba;
					rgba = clr.Components;
					GL.Color4 (rgba[0], rgba[1], rgba[2], _maxIntensity);
					
					
					GL.VertexPointer(2, All.Float, 0, vertices);
					GL.EnableClientState (All.VertexArray);
					
					GL.DrawArrays(All.TriangleStrip, 0, 4);
					
					
					if (_level < thisThresh.maxValue) 
						break;
					
					currentTop = val;
				}
			}
			else
			{
				int light_i;
				float lightMinVal = 0f;
				float insetAmount, lightVSpace;
				lightVSpace = bds.Height / (float)_numLights;
				
				if (lightVSpace < 4f) 
					insetAmount = 0f;
				else if (lightVSpace < 8f) 
					insetAmount = 0.5f;
				else 
					insetAmount = 1f;
				
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
						lightIntensity = LevelMeter.LEVELMETER_CLAMP(0f, lightIntensity, _maxIntensity);
						if ((!_variableLightIntensity) && (lightIntensity > 0f)) lightIntensity = _maxIntensity;
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
										   bds.Y * (bds.Height * ((float)(light_i) / (float)_numLights)), 
										   bds.Width,
										   bds.Height * (1f / (float)_numLights)
										   );
					lightRect = lightRect.Inset (insetAmount, insetAmount);
		
					float [] vertices = {
						lightRect.GetMinX (), lightRect.GetMinY (),
						lightRect.GetMaxX (), lightRect.GetMinY (),
						lightRect.GetMinX (), lightRect.GetMaxY (),
						lightRect.GetMaxX (), lightRect.GetMaxY ()
					};			
		            
					GL.VertexPointer(2, All.Float, 0, vertices);
					GL.EnableClientState (All.VertexArray);
					
					if (lightIntensity == 1f)
					{
						CGColor clr = lightColor.CGColor;
						if (clr.NumberOfComponents != 4) 
							goto bail;
						
						float []  rgba;
						rgba = clr.Components;
						GL.Color4 (rgba[0], rgba[1], rgba[2], 1f);
						GL.DrawArrays(All.TriangleStrip, 0, 4);
					} else if (lightIntensity > 0f) {
						CGColor clr = lightColor.CGColor;
						if (clr.NumberOfComponents != 4) 
							goto bail;
						
						float []  rgba;
						rgba = clr.Components;
						GL.Color4(rgba[0], rgba[1], rgba[2], lightIntensity);
						GL.DrawArrays(All.TriangleStrip, 0, 4);
					}
					
					lightMinVal = lightMaxVal;
				}
			}
			
		bail:	
			GL.PopMatrix ();
			
			GL.Flush ();
		}

		#region LevelMeterItf implementation
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
		
		#endregion
	}
}

