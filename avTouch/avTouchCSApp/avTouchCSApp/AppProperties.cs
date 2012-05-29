using System;
using MonoTouch.Dialog;
using System.Collections.Generic;
using System.Text;


namespace avTouchCSApp
{
	public class AppProperties
	{
		[Section("Meter Properties")]
		
		[RadioSelection ("meterTypes"), Caption("Type")]
		public int meterTypeId = 0;
		public IList<string> meterTypes = new List<string> (new string [] {"GL", "Core Graphics"});
		
		[Caption ("Intensity")]
		[Range (0, 1, ShowCaption=true)]
		public float meterIntensity = .7f;
		
		[Caption ("# Lights")]
		[Range (0, 100, ShowCaption=true)]
		public float numLights = 30;
		
		[Caption ("Show Peaks")]
		public bool showPeaks = true;
		
		[Caption ("Variable Light Intensity")]
		public bool variableLightIntensity = true;
		
		[Section("Player Properties")]
		
		[RadioSelection ("playerFiles"), Caption("File")]
		public int playerFileId = 0;
		public IList<string> playerFiles = new List<string> (new string [] {"water drops 1ch", "water drops 2ch"});
		
		public override string ToString ()
		{
			StringBuilder bob = new StringBuilder ();
			bob.AppendFormat ("Type = {0}, ", meterTypes [meterTypeId]);
			bob.AppendFormat ("Intensity = {0}, ", meterIntensity);
			bob.AppendFormat ("# Lights = {0}, ", (int)numLights);
			bob.AppendFormat ("Show Peaks = {0}, ", showPeaks ? "Yes" : "No");
			bob.AppendFormat ("Variable Light Intensity = {0}", 
			                  variableLightIntensity ? "Yes" : "No");
			
			bob.AppendFormat ("File = {0}, ", playerFiles [playerFileId]);
			
			return bob.ToString ();
		}
	}
}

