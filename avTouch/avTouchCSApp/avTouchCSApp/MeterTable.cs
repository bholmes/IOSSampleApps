using System;
namespace avTouchCSApp
{
	public class MeterTable
	{
		float		mMinDecibels;
		float		mDecibelResolution;
		float		mScaleFactor;
		float [] 	mTable;
		
		public MeterTable(float inMinDecibels = -80f, long inTableSize = 400, float inRoot = 2.0f)
		{
			this.mMinDecibels = inMinDecibels;
			this.mDecibelResolution = (this.mMinDecibels / (inTableSize - 1f)); 
			this.mScaleFactor = (1f / this.mDecibelResolution);
			
			if (inMinDecibels >= 0f)
			{
				Console.WriteLine ("MeterTable inMinDecibels must be negative");
				return;
			}
		
			mTable = new float[inTableSize];
		
			double minAmp = DbToAmp(inMinDecibels);
			double ampRange = 1f - minAmp;
			double invAmpRange = 1f / ampRange;
			
			double rroot = 1f / inRoot;
			for (long i = 0; i < inTableSize; ++i) 
			{
				double decibels = i * mDecibelResolution;
				double amp = DbToAmp(decibels);
				double adjAmp = (amp - minAmp) * invAmpRange;
				mTable[i] = (float)Math.Pow(adjAmp, rroot);
			}
		}
		
		float ValueAt(float inDecibels)
		{
			if (inDecibels < mMinDecibels) return  0f;
			if (inDecibels >= 0f) return 1f;
			int index = (int)(inDecibels * mScaleFactor);
			return mTable[index];
		}
		
		private double DbToAmp(double inDb)
		{
			return Math.Pow (10f, 0.05 * inDb);
		}
	}
}

