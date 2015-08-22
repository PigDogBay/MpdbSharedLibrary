using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Maths
{
	/// <summary>
	/// Co-ordinate information and whether the point represents a peak or trough
	/// </summary>
	public struct TurningPoint
	{
		/// <summary>
		/// X and Y value of the data point
		/// </summary>
		public DPoint Point;
		/// <summary>
		/// True - turning point is a peak
		/// False - turning point is a trough
		/// </summary>
		public bool IsPeak;

		/// <summary>
		/// index of the point in the data set
		/// </summary>
		public int Index;

		public TurningPoint(DPoint point, bool isPeak, int index)
		{
			this.Point = point;
			this.IsPeak = isPeak;
			this.Index = index;
		}
	}

	public class StationaryPoints
	{
		double threshold = 0;
		DPoint[] diffPoints;
		DPoint[] points;
		List<TurningPoint> turningPoints;

		public double Threshold
		{
			get { return threshold; }
			set { threshold = value; }
		}

		enum SPSS
		{
			Nothing,
			StartOfPeak,
			EndOfPeak,
			StartOfTrough,
			EndOfTrough,
			Plateau,
		}

		public StationaryPoints(DPoint[] points)
		{
			this.points = points;
			this.diffPoints = new Differentiator(points).Differentiate();
		}
		public StationaryPoints(DPoint[] points, DPoint[] diffPoints)
		{
			this.points = points;
			this.diffPoints = diffPoints;
		}
		/// <summary>
		/// Calculates the peaks and troughs of the data set.
		/// </summary>
		/// <returns>An array of  the peaks and troughs of the data set</returns>
		public TurningPoint[] CalculateTurningPoints()
		{
			turningPoints = new List<TurningPoint>();
			smoothDiffPoints();
			findTurningPoints();
			return turningPoints.ToArray();
		}
		void smoothDiffPoints()
		{
			if (threshold == 0d)
			{
				//no smoothing required
				return;
			}
			double yMin = diffPoints.Min(s => s.Y);
			double range = diffPoints.Max(s => s.Y) - yMin;
			for (int i = 0; i < diffPoints.Length; i++)
			{
				double d = Math.Abs(diffPoints[i].Y / range);
				if (d < threshold)
				{
					diffPoints[i] = new DPoint(diffPoints[i].X, 0);
				}
			}
		}
		void findTurningPoints()
		{
			int startIndex = 0;
			SPSS state = SPSS.Nothing;
			for (int i = 0; i < diffPoints.Length; i++)
			{
				double y = diffPoints[i].Y;
				if (y == 0d)
				{
					continue;
				}
				switch (state)
				{
					case SPSS.Nothing:
						state = SPSS.StartOfPeak;
						if (y < 0)
						{
							state = SPSS.StartOfTrough;
						}
						startIndex = i;
						break;
					case SPSS.StartOfPeak:
						if (y < 0)
						{
							state = SPSS.EndOfPeak;
						}
						break;
					case SPSS.EndOfPeak:
						scanForPeak(startIndex, i);
						state = SPSS.Nothing;
						break;
					case SPSS.StartOfTrough:
						if (y > 0)
						{
							state = SPSS.EndOfTrough;
						}
						break;
					case SPSS.EndOfTrough:
						scanForTrough(startIndex, i);
						state = SPSS.Nothing;
						break;
					default:
						break;
				}
			}
		}
		void scanForPeak(int startIndex, int endIndex)
		{
			DPoint pt = points[startIndex];
			int index = startIndex;
			for (int i = startIndex; i <= endIndex; i++)
			{
				if (pt.Y < points[i].Y)
				{
					pt = points[i];
					index = i;
				}
			}
			turningPoints.Add(new TurningPoint(pt,true,index));
		}
		void scanForTrough(int startIndex, int endIndex)
		{
			DPoint pt = points[startIndex];
			int index = startIndex;
			for (int i = startIndex; i <= endIndex; i++)
			{
				if (pt.Y > points[i].Y)
				{
					pt = points[i];
					index = i;
				}
			}
			turningPoints.Add(new TurningPoint(pt, false, index));
		}

	}
}
