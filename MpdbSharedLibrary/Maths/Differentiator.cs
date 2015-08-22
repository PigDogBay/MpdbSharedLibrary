using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MpdBaileyTechnology.Shared.Maths
{
	/// <summary>
	/// Differentiates a data set
	/// </summary>
	public class Differentiator
	{
		int sampleSize = 9;
		List<DPoint> points;

		/// <summary>
		/// The differential algorithm takes a sample of data around a point to calculate the best line fit, the slope of the best line
		/// is then considered to be that points differential value. Use smaller sample sizes if you have smooth continuous data, uses larger sample sizes
		/// if the data is noisy, as larger sample sample sizes will give a better average.
		/// </summary>
		public int SampleSize
		{
			get { return sampleSize; }
			set { sampleSize = value; }
		}
		public DPoint[] Points { get { return points.ToArray(); } }

		public Differentiator()
		{
			points = new List<DPoint>();
		}
		public Differentiator(IEnumerable<DPoint> pts)
		{
			points = new List<DPoint>(pts);
		}
		public void Add(DPoint point)
		{
			points.Add(point);
		}
		public void Add(double x, double y)
		{
			points.Add(new DPoint(x, y));
		}
		/// <summary>
		/// Uses reflection to fill the points list
		/// </summary>
		/// <param name="values">Enumeration of objects containg x/y values</param>
		/// <param name="xField">Property name of the x value</param>
		/// <param name="yField">Property name of the y value</param>
		public void Add<T>(IEnumerable<T> values, string xField, string yField)
		{
			PropertyInfo pInfoX = values.ElementAt(0).GetType().GetProperty(xField);
			PropertyInfo pInfoY = values.ElementAt(0).GetType().GetProperty(yField);
			foreach (object obj in values)
			{
				points.Add(new DPoint((double)pInfoX.GetValue(obj, null), (double)pInfoY.GetValue(obj, null)));
			}
		}
		/// <summary>
		/// If there is enough data, a moving sample averaged differentiation is performed.
		/// Here a sample of data is taken, a best line fitted, the differential of the mid point is the slope of the best line.
		/// The sample statrting index is then moved along by one, for the next differential to be calculated.
		/// Since only the midpoint of the sample is calculated, the start and end points of the entire data set will be missed. In these
		/// cases a best line is fitted for these values.
		/// 
		/// For data sets smaller than the sample size, a best line is fitted whose slope is assigned to each points differential value.
		///
		/// Note that the points are first sorted in ascending order
		/// Note that points with the same x value will give have a NaN differential value
		/// </summary>
		/// <returns>Array of points whose Y-values are the differential values</returns>
		public DPoint[] Differentiate()
		{
			DPoint[] diffPoints = null;
			if (points.Count>sampleSize)
			{
				diffPoints = SampleAveragedDifferentiation();
			}
			else
			{
				diffPoints = SmallDataSet();
			}
			return diffPoints.ToArray();
		}
		/// <summary>
		/// Uses a moving sample and best line slope to calculate the differentials for each data point
		/// </summary>
		/// <returns></returns>
		DPoint[] SampleAveragedDifferentiation()
		{
			//ensure points are sorted, in order of x value
			points.Sort((a, b) => a.X.CompareTo(b.X));

			List<DPoint> diffPoints = new List<DPoint>();
			int start = sampleSize / 2;
			int end = points.Count - start;

			//Start points: calculate best line fit of the first batch of points
			//and set the differential as the lines slope.
			List<DPoint> selection = points.GetRange(0, sampleSize);
			BestLineFit bl = new BestLineFit(selection);
			for (int i = 0; i < start; i++)
			{
				diffPoints.Add(new DPoint(points[i].X, bl.Slope));
			}
			//mid points
			for (int i = start; i < end; i++)
			{
				selection = points.GetRange(i - start, sampleSize);
				bl = new BestLineFit(selection);
				diffPoints.Add(new DPoint(points[i].X, bl.Slope));
			}
			//end points, use the last calculated best line fit
			for (int i = end; i < points.Count; i++)
			{
				diffPoints.Add(new DPoint(points[i].X, bl.Slope));
			}
			return diffPoints.ToArray();
		}
		/// <summary>
		/// Simply fits a best line to calculate the differential
		/// </summary>
		/// <returns></returns>
		DPoint[] SmallDataSet()
		{
			List<DPoint> diffPoints = new List<DPoint>();
			BestLineFit bl = new BestLineFit(points);
			for (int i = 0; i < points.Count; i++)
			{
				diffPoints.Add(new DPoint(points[i].X, bl.Slope));
			}
			return diffPoints.ToArray();
		}
	}
}
