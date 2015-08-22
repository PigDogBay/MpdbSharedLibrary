using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Maths
{
	public static class ExtensionMethods
	{
		/// <summary>
		/// Routine used to ensure that a number is rounded to its nearest significant interval. Particularly used by wavelength
		/// calculations to ensure that a given wavelength is valid for the connected instrument (eg rounded to the nearest 1nm)
		/// A better way to do this would be to use modulus and remainder
		/// </summary>
		/// <param name="number">The number that requires rounding/checking</param>
		/// <param name="significance">Resolution of the intervals</param>
		/// <returns>NUmber round to the nearest interval</returns>
		/// <example>RoundToSignificance(419,10) returns 420</example>
		/// <example>RoundToSignificance(417,2) returns 418</example>
		/// <example>RoundToSignificance(417,5) returns 415</example>
		public static double RoundToSignificance(this double number, double resolution)
		{
			double d = number / resolution;
			//The AwayFromZero mode, is to ensure when the resolution is 2, that it is always rounded upwards
			d = System.Math.Round(d, 0, MidpointRounding.AwayFromZero);
			return d * resolution;
		}
		/// <summary>
		/// Rounds to the specified number of significant places
		/// </summary>
		/// <param name="d">Double instance to act on (extension method)</param>
		/// <param name="digits">number of significant digits to round to</param>
		/// <returns>Rounded double</returns>
		public static double RoundToSignificantDigits(this double d, int digits)
		{
            double scale = System.Math.Pow(10, System.Math.Floor(System.Math.Log10(d)) + 1);
            return scale * System.Math.Round(d / scale, digits);
		}
		public static double Mean(this IEnumerable<double> values)
		{
			//find the average
			double avg = 0;
			foreach (double value in values)
			{
				avg += value;
			}
			double n = (double)values.Count();
			avg = avg / n;
			return avg;
		}
		/// <summary>
		/// Calculates the Standard Deviation of an array of values
		/// http://en.wikipedia.org/wiki/Standard_deviation
		/// 
		///  σ = √ (  (1/n)  Σ( (x-avg)²)  )
		///  
		/// Or using the re-arranged formula
		///  σ = √ ( (nΣx² - (Σx)²)/n²)
		///  
		/// These formula assume the entire population of data is used
		/// </summary>
		/// <param name="values">Array of values to be assessed</param>
		/// <returns>Standard Deviation σ </returns>
		public static double StandardDeviation(this IEnumerable<double> values)
		{
			double n = (double)values.Count();
			double sum = 0;
			double sumOfSquares = 0;
			foreach (double x in values)
			{
				sum = sum + x;
				sumOfSquares = sumOfSquares + x * x;
			}
			double stdevp = (n * sumOfSquares - sum * sum) / (n * n);
            return System.Math.Sqrt(stdevp);
		}

	}
}
