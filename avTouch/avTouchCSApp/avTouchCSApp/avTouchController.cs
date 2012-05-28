using System;
using MonoTouch.Foundation;
using MonoTouch.AVFoundation;
using MonoTouch.UIKit;
using System.Text;
using MonoTouch.AudioToolbox;
using MonoTouch.ObjCRuntime;


namespace avTouchCSApp
{
	
	public partial class avTouchController : NSObject
	{
		AVAudioPlayer						player;
		UIImage								playBtnBG;
		UIImage								pauseBtnBG;
		NSTimer								updateTimer;
		NSTimer								rewTimer;
		NSTimer								ffwTimer;
		
		bool								inBackground;
		
		// amount to skip on rewind or fast forward
		const float SKIP_TIME  = 1.0f;
		// amount to play between skips
		const float SKIP_INTERVAL = .2f;
		
		public avTouchController ()
		{
		}
		
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			playBtnBG = UIImage.FromFile ("images/play.png");
			pauseBtnBG = UIImage.FromFile ("images/pause.png");
			
			playButton.SetImage (playBtnBG, UIControlState.Normal);
	
			this.registerForBackgroundNotifications ();
					
			updateTimer = null;
			rewTimer = null;
			ffwTimer = null;
			
			duration.AdjustsFontSizeToFitWidth = true;
			currentTime.AdjustsFontSizeToFitWidth = true;
			progressBar.MinValue = 0.0f;	
			
			// Load the the sample file, use mono or stero sample
			//NSUrl fileURL = NSUrl.FromFilename (NSBundle.MainBundle.PathForResource ("sample" , @"m4a"));
			NSUrl fileURL = NSUrl.FromFilename (NSBundle.MainBundle.PathForResource ("sample2ch" , @"m4a"));
		
			this.player = AVAudioPlayer.FromUrl (fileURL);
			if (this.player != null)
			{
				StringBuilder tmp = new StringBuilder ();
				tmp.AppendFormat ("{0} ({1} ch.)",  
				                  new System.IO.FileInfo (this.player.Url.RelativePath).Name, 
				                  player.NumberOfChannels);
				fileName.Text = tmp.ToString ();
				
				this.updateViewForPlayerInfo (this.player);
				this.updateViewForPlayerState (this.player);
				player.NumberOfLoops = 1;
				player.WeakDelegate = this;
				player.PrepareToPlay ();
			}
			
			AudioSession.Initialize();
			
			AVAudioSession.SharedInstance ().OutputChannelsChanged += delegate(object sender, AVChannelsEventArgs e) {
				Console.WriteLine ();
			};


			NSError setCategoryError;
			AVAudioSession.SharedInstance ().SetCategory (new NSString (AVAudioSession.CategoryPlayback.ToString ()), out setCategoryError);
			AVAudioSession.SharedInstance ().SetActive (true, out setCategoryError);
			UIApplication.SharedApplication.BeginReceivingRemoteControlEvents ();
			
			if (setCategoryError != null)
				Console.WriteLine (@"Error setting category! {0}", setCategoryError);

			AudioSession.AddListener (AudioSessionProperty.AudioRouteChange, RouteChangeListener);
		}

		void pausePlaybackForPlayer (AVAudioPlayer p)
		{
			player.Pause ();
			this.updateViewForPlayerState (p);
		}	
		
		void startPlaybackForPlayer (AVAudioPlayer p)
		{
			if (p.Play ())
			{
				this.updateViewForPlayerState (p);
			}
			else
				Console.WriteLine (@"Could not play {0}", p.Url);
		}
		
		partial void playButtonPressed (MonoTouch.UIKit.UIButton sender)
		{
			if (player.Playing)
				this.pausePlaybackForPlayer (player);
			else
				this.startPlaybackForPlayer (player);
		}

		partial void rewButtonPressed (MonoTouch.UIKit.UIButton sender)
		{
			if (rewTimer != null) 
				this.rewTimer.Invalidate ();
			rewTimer = NSTimer.CreateScheduledTimer (SKIP_INTERVAL, this, new Selector ("rewind"), 
			                                         player, true);	
	
		}

		partial void rewButtonReleased (MonoTouch.UIKit.UIButton sender)
		{
			if (rewTimer != null) 
				this.rewTimer.Invalidate ();
			rewTimer = null;	
		}

		partial void ffwButtonPressed (MonoTouch.UIKit.UIButton sender)
		{
			if (ffwTimer != null) 
				ffwTimer.Invalidate ();
			ffwTimer = NSTimer.CreateScheduledTimer (SKIP_INTERVAL, this, new Selector ("ffwd"), 
			                                         player, true);
		}

		partial void ffwButtonReleased (MonoTouch.UIKit.UIButton sender)
		{
			if (ffwTimer != null) 
				ffwTimer.Invalidate ();
			ffwTimer = null;	
		}

		partial void volumeSliderMoved (MonoTouch.UIKit.UISlider sender)
		{
			this.player.Volume = sender.Value;	
		}

		partial void progressSliderMoved (MonoTouch.UIKit.UISlider sender)
		{
			player.CurrentTime = sender.Value;
			this.updateCurrentTimeForPlayer (player);
		}
		
		void registerForBackgroundNotifications ()
		{
			NSNotificationCenter.DefaultCenter.AddObserver (this, new Selector ("setInBackgroundFlag"), 
					UIApplication.WillResignActiveNotification, null);
			
			NSNotificationCenter.DefaultCenter.AddObserver (this, new Selector ("clearInBackgroundFlag"), 
					UIApplication.WillEnterForegroundNotification, null);
		}
		
		[Export ("setInBackgroundFlag")]
		void setInBackgroundFlag ()
		{
			inBackground = true;
		}
		
		[Export ("clearInBackgroundFlag")]
		void clearInBackgroundFlag ()
		{
			inBackground = false;
		}
		
		void updateViewForPlayerInfo (AVAudioPlayer p)
		{
			StringBuilder bob = new StringBuilder ();
			bob.AppendFormat ("{0}:{1}", (int)(p.Duration / 60), ((int)(p.Duration % 60)).ToString ("D2"));
			duration.Text = bob.ToString ();
			progressBar.MaxValue = (float)p.Duration;
			volumeSlider.Value = p.Volume;
		}
		
		void updateCurrentTimeForPlayer (AVAudioPlayer p)
		{
			StringBuilder bob = new StringBuilder ();
			bob.AppendFormat ("{0}:{1}", (int)(p.CurrentTime / 60), ((int)(p.CurrentTime % 60)).ToString ("D2"));
			currentTime.Text = bob.ToString ();
			progressBar.Value = (float)p.CurrentTime;
		}
		
		[Export ("updateCurrentTime")]
		void updateCurrentTime ()
		{
			this.updateCurrentTimeForPlayer (this.player);
		}

		void updateViewForPlayerState (AVAudioPlayer p)
		{
			this.updateCurrentTimeForPlayer (p);

			if (this.updateTimer != null) 
				updateTimer.Invalidate ();
				
			if (p.Playing)
			{
				this.playButton.SetImage ((p.Playing) ? pauseBtnBG : playBtnBG, UIControlState.Normal);
				lvlMeter_in.Player = p;
				updateTimer = NSTimer.CreateScheduledTimer (.01, this, new Selector ("updateCurrentTime"), p, true);
			}
			else
			{
				this.playButton.SetImage ((p.Playing) ? pauseBtnBG : playBtnBG, UIControlState.Normal);
				lvlMeter_in.Player = null;
				updateTimer = null;
			}
			
		}
		
		void updateViewForPlayerStateInBackground (AVAudioPlayer p)
		{
			this. updateCurrentTimeForPlayer(p);
			
			if (p.Playing)
			{
				playButton.SetImage ((p.Playing) ? pauseBtnBG : playBtnBG, UIControlState.Normal);
			}
			else
			{
				playButton.SetImage ((p.Playing) ? pauseBtnBG : playBtnBG, UIControlState.Normal);
			}	
		}
		
		[Export ("rewind")]
		void rewind ()
		{
			AVAudioPlayer p = rewTimer.UserInfo as AVAudioPlayer;
			p.CurrentTime-= SKIP_TIME;
			this.updateCurrentTimeForPlayer (p);
		}
		
		[Export ("ffwd")]
		void ffwd ()
		{
			AVAudioPlayer p = ffwTimer.UserInfo as AVAudioPlayer;
			p.CurrentTime+= SKIP_TIME;
			this.updateCurrentTimeForPlayer (p);
		}

		[Export ("audioPlayerDidFinishPlaying:successfully:")]
		public void FinishedPlaying (AVAudioPlayer p, bool flag)
		{
			if (!flag)
				Console.WriteLine (@"Playback finished unsuccessfully");
				
			p.CurrentTime = 0f;
			if (inBackground)
			{
				this.updateViewForPlayerStateInBackground (p);
			}
			else
			{
				this.updateViewForPlayerState (p);
			}
		}
		
		[Export ("audioPlayerDecodeErrorDidOccur:error:")]
		public void DecoderError (AVAudioPlayer p, NSError error)
		{
			Console.WriteLine ("ERROR IN DECODE: {0}", error); 
		}
		
		// we will only get these notifications if playback was interrupted
		[Export ("audioPlayerBeginInterruption:")]
		public void BeginInterruption (AVAudioPlayer p)
		{
			Console.WriteLine (@"Interruption begin. Updating UI for new state");
			// the object has already been paused,	we just need to update UI
			if (inBackground)
			{
				this.updateViewForPlayerStateInBackground (p);
			}
			else
			{
				this.updateViewForPlayerState (p);
			}
		}
		
		[Export ("audioPlayerEndInterruption:")]
		public void EndInterruption (AVAudioPlayer p)
		{
			Console.WriteLine (@"Interruption ended. Resuming playback");
			this.startPlaybackForPlayer (p);
		}

		void RouteChangeListener (/*IntPtr 			inClientData,*/
							AudioSessionProperty	inID,
							int                  	inDataSize,
							IntPtr            		inData)
		{
			
			if (inID == AudioSessionProperty.AudioRouteChange) {
				
				NSDictionary routeDict = Runtime.GetNSObject (inData) as NSDictionary;
				
				NSNumber reasonValue = (NSNumber)routeDict.ValueForKey (new NSString ("OutputDeviceDidChange_Reason"));
		
				if ((AudioSessionRouteChangeReason)reasonValue.Int32Value ==  
				    AudioSessionRouteChangeReason.OldDeviceUnavailable) 
				{
					this.pausePlaybackForPlayer (this.player);
				}
			}
		}
		
	}
}

