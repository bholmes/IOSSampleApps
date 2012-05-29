using System;
namespace avTouchCSApp
{
	public interface LevelMeterItf 
	{
		float Level {
			get;set;
		}

		float PeakLevel {
			get;set;
		}

		bool Vertical {
			get;set;
		}
		
		void LoadProperties (AppProperties appProperties);
	}
}

