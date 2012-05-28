using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.AVFoundation;
using MonoTouch.CoreAnimation;
using MonoTouch.ObjCRuntime;
using System.Collections.Generic;


namespace avTouchCSApp
{
	[Register ("CALevelMeter")]
	public class CALevelMeter : UIView
	{
		const float kPeakFalloffPerSec = .7f;
		const float kLevelFalloffPerSec = .8f;
		const float kMinDBvalue = -80.0f;

		AVAudioPlayer				_player;
		List<int>					_channelNumbers = new List<int> ();
		List<LevelMeterItf>			_subLevelMeters = new List<LevelMeterItf> ();
		MeterTable					_meterTable;
		CADisplayLink				_updateTimer;
		bool						_showsPeaks;
		bool						_vertical;
		bool						_useGL;
		
		DateTime					_peakFalloffLastFire;
		
		[Export ("initWithFrame:")]
		public CALevelMeter (RectangleF frame) : base (frame)
		{
			_showsPeaks = true;
			//_channelNumbers = NSArray.FromObjects (new object[] {} [[NSArray alloc] initWithObjects:[NSNumber numberWithInt:0], nil];
			_channelNumbers = new List<int> ();
			_channelNumbers.Add (0);
			_vertical = (this.Frame.Width < this.Frame.Height) ? true : false; // NO;
			_useGL = true;
			_meterTable = new MeterTable(kMinDBvalue);
			this.layoutSubLevelMeters ();
			this.registerForBackgroundNotifications ();	
		}
		
		[Export ("initWithCoder:")]
		public CALevelMeter (NSCoder coder) : base (coder)
		{
			_showsPeaks = true;
			//_channelNumbers = NSArray.FromObjects (new object[] {} [[NSArray alloc] initWithObjects:[NSNumber numberWithInt:0], nil];
			_channelNumbers = new List<int> ();
			_channelNumbers.Add (0);
			_vertical = (this.Frame.Width < this.Frame.Height) ? true : false; // NO;
			_useGL = true;
			_meterTable = new MeterTable(kMinDBvalue);
			this.layoutSubLevelMeters ();
			this.registerForBackgroundNotifications ();	
		}

		void registerForBackgroundNotifications ()
		{
			NSNotificationCenter.DefaultCenter.AddObserver (this, 
			                                                new Selector ("pauseTimer"),
			                                                new NSString (UIApplication.WillResignActiveNotification.ToString ()),
			                                                null);
			
			NSNotificationCenter.DefaultCenter.AddObserver (this, 
			                                                new Selector ("resumeTimer"),
			                                                new NSString (UIApplication.WillEnterForegroundNotification.ToString ()),
			                                                null);
		}

		void layoutSubLevelMeters ()
		{
			int i;
			for (i=0; i<_subLevelMeters.Count; i++)
			{
				UIView thisMeter = _subLevelMeters[i] as UIView;
				thisMeter.RemoveFromSuperview ();
			}
			
			List <LevelMeterItf> meters_build = new List<LevelMeterItf> ();
			//NSMutableArray *meters_build = [[NSMutableArray alloc] initWithCapacity:[_channelNumbers count]];
			
			RectangleF totalRect;
			
			if (_vertical) 
				totalRect = new RectangleF(0f, 0f, this.Frame.Width + 2f, this.Frame.Height);
			else  
				totalRect = new RectangleF (0f, 0f, this.Frame.Width, this.Frame.Height + 2f);
			
			for (i=0; i<_channelNumbers.Count; i++)
			{
				RectangleF fr;
				
				if (_vertical) {
					fr = new RectangleF (
									totalRect.X + (((float)i / (float)_channelNumbers.Count) * totalRect.Width), 
									totalRect.Y, 
									(1f / (float)_channelNumbers.Count) * totalRect.Width - 2f, 
									totalRect.Height
									);
				} 
				else
				{
					fr = new RectangleF(
									totalRect.X, 
									totalRect.Y + (((float)i / (float)_channelNumbers.Count) * totalRect.Height), 
									totalRect.Width, 
									(1f / (float)_channelNumbers.Count) * totalRect.Height - 2f
									);
				}
				
				LevelMeterItf newMeter;
		
				if (_useGL) 
					newMeter = new GLLevelMeter (fr);
				else 
					newMeter = new LevelMeter (fr);
				
				newMeter.NumLights = 30;
				newMeter.Vertical = this._vertical;
				meters_build.Add (newMeter);
				this.AddSubview (newMeter as UIView);
			}	
			
			_subLevelMeters = meters_build;
		}
		
		[Export ("_refresh")]
		void _refresh ()
		{
			bool success = false;
		
			// if we have no queue, but still have levels, gradually bring them down
			if (_player == null)
			{
				float maxLvl = -1f;
	
				DateTime thisFire = DateTime.Now;
				// calculate how much time passed since the last draw
				TimeSpan timePassed = thisFire.Subtract (_peakFalloffLastFire);
				foreach (LevelMeterItf thisMeter in _subLevelMeters)
				{
					float newPeak, newLevel;
					newLevel = thisMeter.Level - ((float)timePassed.TotalSeconds) * kLevelFalloffPerSec;
					if (newLevel < 0f)
						newLevel = 0f;
					thisMeter.Level = newLevel;
					if (_showsPeaks)
					{
						newPeak = thisMeter.PeakLevel - ((float)timePassed.TotalSeconds) * kPeakFalloffPerSec;
						if (newPeak < 0f)
							newPeak = 0f;
						thisMeter.PeakLevel = newPeak;
						if (newPeak > maxLvl)
							maxLvl = newPeak;
					}
					else if (newLevel > maxLvl)
						maxLvl = newLevel;
					
					(thisMeter as UIView).SetNeedsDisplay ();
				}
				// stop the timer when the last level has hit 0
				if (maxLvl <= 0f)
				{
					_updateTimer.Invalidate ();
					_updateTimer = null;
				}
				
				_peakFalloffLastFire = thisFire;
				success = true;
			} 
			else
			{
				_player.UpdateMeters ();
				for (int i=0; i<_channelNumbers.Count; i++)
				{
					int channelIdx = _channelNumbers [i];
					LevelMeterItf channelView = _subLevelMeters[channelIdx];
					
					if (channelIdx >= _channelNumbers.Count) 
						goto bail;
					if (channelIdx > 127) 
						goto bail;
					
					channelView.Level = _meterTable.ValueAt (_player.AveragePower ((uint)i));
					
					if (_showsPeaks) 
						channelView.PeakLevel = _meterTable.ValueAt(_player.PeakPower ((uint)i));
					else
						channelView.PeakLevel = 0f;
					(channelView as UIView).SetNeedsDisplay ();
					success = true;		
				}
			}
			
		bail:
			
			if (!success)
			{
				foreach (LevelMeter thisMeter in _subLevelMeters) 
				{
					thisMeter.Level = 0f; 
					thisMeter.SetNeedsDisplay ();
				}
				Console.WriteLine ("ERROR: metering failed");
			}
		}

		[Export ("pauseTimer")]
		void pauseTimer ()
		{
			_updateTimer.Invalidate ();
			_updateTimer = null;
		}
		
		[Export ("resumeTimer")]
		void resumeTimer ()
		{
			if (_player != null)
			{
				_updateTimer = CADisplayLink.Create (this, new Selector ("_refresh"));
				_updateTimer.AddToRunLoop (NSRunLoop.Current, 
				                           new NSString (NSRunLoop.NSDefaultRunLoopMode.ToString ()));
			}
		}

		public AVAudioPlayer Player {
			get 
			{
				return _player;
			}
			set 
			{
				if ((_player == null) && (value != null))
				{
					if (_updateTimer != null)
						_updateTimer.Invalidate ();
					_updateTimer = CADisplayLink.Create (this, new Selector ("_refresh"));
					_updateTimer.AddToRunLoop (NSRunLoop.Current, 
					                           new NSString ((NSRunLoop.NSDefaultRunLoopMode.ToString ())));
			
				} 
				else if ((_player != null) && (value == null)) 
				{
					_peakFalloffLastFire = DateTime.Now;
				}
				
				_player = value;
				
				if (_player != null)
				{
					_player.MeteringEnabled = true;
					// now check the number of channels in the new queue, we will need to reallocate if this has changed
					if (_player.NumberOfChannels != _channelNumbers.Count)
					{
						if (_player.NumberOfChannels < 2)
							_channelNumbers = new List<int> (new int[] {0});
						else
							_channelNumbers = new List<int> (new int[] {0,1});
						layoutSubLevelMeters ();
					}
				} 
				else
				{
					foreach (UIView thisMeter in _subLevelMeters) 
					{
						thisMeter.SetNeedsDisplay ();
					}
				}
			}
		}
	}
}

