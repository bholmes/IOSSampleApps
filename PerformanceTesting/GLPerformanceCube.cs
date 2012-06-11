using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.GLKit;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics.ES20;
using MonoTouch.OpenGLES;

namespace PerformanceTesting
{
	public class GLPerformanceCube : UIViewController
	{
		GLKView _view;
		UIBarButtonItem _testButton;
		GLKBaseEffect _effect;
		Matrix4 _modelMatrix = Matrix4.Identity;
		UILabel _fpLabel;
		UILabel _numTrisLabel;
		UIStepper _numTrisStepper;
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = "GL Performance Cube";
			
			_testButton = new UIBarButtonItem ("Test", UIBarButtonItemStyle.Bordered, testButtonClicked);
			this.NavigationItem.RightBarButtonItem = _testButton;
			
			_setupGLView ();
			
			RectangleF rect = _view.Bounds;
			rect.X = 10; rect.Width -= 20;
			rect.Y = rect.Height - 35; rect.Height = 25;
			_numTrisLabel = new UILabel (rect);
			_numTrisLabel.Text = "triangles = " + ((_triangles) / 3);
			_numTrisLabel.BackgroundColor = UIColor.Clear;
			_numTrisLabel.TextColor = UIColor.White;
			_numTrisLabel.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin;
			_view.AddSubview (_numTrisLabel);
			
			_numTrisStepper = new UIStepper (rect);
			_numTrisStepper.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin;
			_numTrisStepper.MinimumValue = 0;
			rect.X = rect.Width - _numTrisStepper.Bounds.Width;
			_numTrisStepper.Frame = rect;
			_numTrisStepper.ValueChanged += HandleNumTrisStepperChanged;
			_view.AddSubview (_numTrisStepper);
			
			rect.X = 10; rect.Y -= 35;
			_fpLabel = new UILabel (rect);
			_fpLabel.Text = string.Empty;
			_fpLabel.BackgroundColor = UIColor.Clear;
			_fpLabel.TextColor = UIColor.White;
			_fpLabel.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin;
			_view.AddSubview (_fpLabel);
		}

		void HandleNumTrisStepperChanged (object sender, EventArgs e)
		{
			int value = (int)_numTrisStepper.Value;
			if (value == 0)
				value = 1;
			else
				value *= 10;
			
			createBuffers (value);
			this._view.Display ();
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			if (_vertexBuffers != null)
			{
				GL.DeleteBuffers (2, _vertexBuffers);
				_vertexBuffers = null;
			}
		}
		
		void _setupGLView ()
		{
			base.ViewDidLoad ();
			
			// Craete a new context if needed
			if (EAGLContext.CurrentContext == null)
				EAGLContext.SetCurrentContext (new EAGLContext (EAGLRenderingAPI.OpenGLES2));
			
			_view = new GLKView (this.View.Bounds);
			_view.Context = EAGLContext.CurrentContext;
			_view.WeakDelegate = this;
			this.View.AddSubview (_view);
			
			_effect = new GLKBaseEffect ();
			_effect.Light0.Position = new Vector4 (5, 5, 5, 1);
			_effect.Light0.Enabled = true;
			
			GL.Enable (All.CullFace);
			
			sizeGLView ();
			
			_modelMatrix = Matrix4.CreateRotationX ((float)Math.PI / 5f);
			_effect.Transform.ModelViewMatrix = _modelMatrix;
			
			createBuffers (1);
		}
		
		public override void ViewDidLayoutSubviews ()
		{
			base.ViewDidLayoutSubviews ();
			_view.Frame = this.View.Bounds;
			sizeGLView ();
		}

		void sizeGLView ()
		{
			float aspect = _view.Bounds.Height / _view.Bounds.Width;
			float worldBounds = 2;
			GL.Viewport (0, 0, (int)this.View.Bounds.Width, (int)this.View.Bounds.Height);
			_effect.Transform.ProjectionMatrix = Matrix4.CreateOrthographicOffCenter (-worldBounds, worldBounds, -worldBounds * aspect, worldBounds * aspect, -worldBounds, worldBounds);
		}
		
		uint [] _vertexBuffers;
		int _triangles;
	
		void createBuffers (int segments)
		{
			if (_vertexBuffers == null)
			{
				_vertexBuffers = new uint[2];	
			}
			else
			{
				GL.DeleteBuffers (2, _vertexBuffers);	
			}
			
			_triangles = segments * segments * 6 * 6;
			int trisPerFace = segments * segments;
			float [] verticies = new float [_triangles * 3];
			float [] normals = new float [_triangles * 3];
			
			verticies[0] = -1; verticies[1] = -1; verticies[2] = 0;
			verticies[3] =  1; verticies[4] = -1; verticies[5] = 0;
			verticies[6] = -1; verticies[7] =  1; verticies[8] = 0;
			
			verticies[ 9] = -1; verticies[10] =  1; verticies[11] = 0;
			verticies[12] =  1; verticies[13] = -1; verticies[14] = 0;
			verticies[15] =  1; verticies[16] =  1; verticies[17] = 0;
			
			float incr = 2f / (float)segments;
			float startPt = -1 + (incr / 2f);
			int index = 18;
			
			Matrix4 trans = Matrix4.CreateTranslation (startPt, startPt, 1);
			trans = Matrix4.Mult (Matrix4.Scale (1f/(float)segments), trans);
			transformFace (verticies, trans, verticies, 18, 0);
			
			trans = Matrix4.Identity;
			
			for (int i=1; i<segments; i++)
			{
				trans = Matrix4.Mult (trans, Matrix4.CreateTranslation (incr, 0, 0));
				transformFace (verticies, trans, verticies, 18, index);
				index += 18;
			}
			
			trans = Matrix4.Identity;
			int rowStride = index;
			
			for (int i=1; i<segments; i++)
			{
				trans = Matrix4.Mult (trans, Matrix4.CreateTranslation (0, incr, 0));
				transformFace (verticies, trans, verticies, rowStride, index);
				index += rowStride;
			}
			
			trans = Matrix4.CreateRotationY ((float)Math.PI);
			transformFace (verticies, trans, verticies, trisPerFace*6*3, trisPerFace*6*3);
			
			trans = Matrix4.CreateRotationY ((float)Math.PI / 2f);
			transformFace (verticies, trans, verticies, trisPerFace*6*3*2, trisPerFace*6*3*2);
			
			trans = Matrix4.CreateRotationX ((float)Math.PI / 2f);
			transformFace (verticies, trans, verticies, trisPerFace*6*3*2, trisPerFace*6*3*2*2);
			
			int normalIndex = 0;
			int normalStride = normals.Length / 6;
			fillNormals (normals, 0, 0, 1, normalIndex, normalStride);
			
			normalIndex += normalStride;
			fillNormals (normals, 0, 0, -1, normalIndex, normalStride);
			
			normalIndex += normalStride;
			fillNormals (normals, 1, 0, 0, normalIndex, normalStride);
			
			normalIndex += normalStride;
			fillNormals (normals, -1, 0, 0, normalIndex, normalStride);
			
			normalIndex += normalStride;
			fillNormals (normals, 0, -1, 0, normalIndex, normalStride);
			
			normalIndex += normalStride;
			fillNormals (normals, 0, 1, 0, normalIndex, normalStride);
			
			GL.GenBuffers(2, _vertexBuffers);
		    GL.BindBuffer(All.ArrayBuffer, _vertexBuffers[0]);
		    GL.BufferData(All.ArrayBuffer, (IntPtr)(verticies.Length * sizeof (float)), verticies, All.StaticDraw);
			 
			GL.BindBuffer(All.ArrayBuffer, _vertexBuffers[1]);
		    GL.BufferData(All.ArrayBuffer, (IntPtr)(normals.Length * sizeof (float)), normals, All.StaticDraw);
			
			if (_numTrisLabel != null)
				_numTrisLabel.Text = "triangles = " + ((_triangles) / 3);
		}
		
		void transformFace (float [] base1, Matrix4 trans, float [] target1, int length, int targetstart)
		{
			int j = targetstart;
			for (int i=0; i<length; i+=3, j+=3)
			{
				float x = base1[i] * trans.M11 + base1[i+1] * trans.M21 + base1[i+2] * trans.M31 + 1 * trans.M41;
				float y = base1[i] * trans.M12 + base1[i+1] * trans.M22 + base1[i+2] * trans.M32 + 1 * trans.M42;
				float z = base1[i] * trans.M13 + base1[i+1] * trans.M23 + base1[i+2] * trans.M33 + 1 * trans.M43;
				target1[j] = x;
				target1[j+1] = y;
				target1[j+2] = z;
			}
		}
		
		void fillNormals (float [] normals, float x, float y, float z, int index, int length)
		{
			for (int i=0; i<length; i+=3, index+=3)
			{
				normals [index] = x;
				normals [index+1] = y;
				normals [index+2] = z;
			}
		}
		
		[Export ("glkView:drawInRect:")]
		public void glkViewDrawInRect (GLKView view, RectangleF rect)
		{
			GL.ClearColor (0.0f, 0.0f, 0.0f, 1.0f);
			
			// Clear all old bits
			GL.Clear ((int)(All.ColorBufferBit));
			
			_effect.Transform.ModelViewMatrix = _modelMatrix;
			
			_effect.Material.AmbientColor = new Vector4 (.3f, 0f, 0f, 1f);
			_effect.Material.DiffuseColor = new Vector4 (.8f, 0f, 0f, 1f);
			_effect.Light0.AmbientColor = new Vector4 (.6f, .6f, .6f, 1f);
			_effect.PrepareToDraw ();
			
			GL.BindBuffer(All.ArrayBuffer, _vertexBuffers[0]);
			GL.EnableVertexAttribArray((uint)GLKVertexAttrib.Position); 
			GL.VertexAttribPointer((uint)GLKVertexAttrib.Position, 3, All.Float, false, 0, IntPtr.Zero);
			
			GL.BindBuffer(All.ArrayBuffer, _vertexBuffers[1]);
			GL.EnableVertexAttribArray((uint)GLKVertexAttrib.Normal); 
			GL.VertexAttribPointer((uint)GLKVertexAttrib.Normal, 3, All.Float, false, 0, IntPtr.Zero);
			
			GL.DrawArrays(All.Triangles, 0, _triangles);
			
			GL.Flush ();
		}
		
		void testButtonClicked (object sender, EventArgs e)
		{
			DateTime startTime = DateTime.Now;
			DateTime currentTime = DateTime.Now;
			
			float frameCount = 0f;
			
			while (true)
			{
				_modelMatrix = Matrix4.Mult (_modelMatrix, 
								Matrix4.CreateRotationY (.05f));
				
				_view.Display ();
				frameCount++;
				currentTime = DateTime.Now;
				
				if (currentTime.Subtract (startTime).TotalSeconds > 10)
					break;
			}
			
			float framesPerSecond = frameCount / ((float)currentTime.Subtract (startTime).TotalSeconds);
			
			_fpLabel.Text = "fps = " + framesPerSecond;
			
			//MonoTouch.TestFlight.TestFlight.SubmitFeedback (_fpLabel.Text);
		}
		
		public void RotateXY (float x, float y)
		{
			RectangleF rect = this.View.Bounds;
			float factor = rect.Width > rect.Height ? rect.Width : rect.Height;
			factor = 300/factor;
			
			Matrix4 rotMatrix = Matrix4.CreateFromAxisAngle (new Vector3 (_modelMatrix.M12, _modelMatrix.M22, _modelMatrix.M32),
			                                                    MathHelper.DegreesToRadians (x * factor));
			_modelMatrix = Matrix4.Mult (rotMatrix, _modelMatrix);
			
			rotMatrix = Matrix4.CreateFromAxisAngle (new Vector3 (_modelMatrix.M11, _modelMatrix.M21, _modelMatrix.M31),
			                                       		MathHelper.DegreesToRadians (y * factor));
			_modelMatrix = Matrix4.Mult (rotMatrix, _modelMatrix);
		}
		
		
		PointF _previousLocation;
		
		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			
			base.TouchesBegan (touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			_previousLocation = touch.LocationInView (touch.View);
		}
		
		public override void TouchesMoved (NSSet touches, UIEvent evt)
		{
			base.TouchesMoved (touches, evt);
			
			UITouch touch = touches.AnyObject as UITouch;
			
			PointF currentPoint = touch.LocationInView (touch.View);
			RotateXY (currentPoint.X - _previousLocation.X, currentPoint.Y - _previousLocation.Y);	
			_previousLocation = currentPoint;
			
			_view.Display ();
		}
	}
}

