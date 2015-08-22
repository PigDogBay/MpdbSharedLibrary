using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MpdBaileyTechnology.Shared.Maths
{
	public enum CurveFits
	{
		Interpolate,
		LinearZero,
		Linear,
		Quadratic,
		QuadraticThruZero
	}

	/// <summary>
	/// Interpolator uses the Strategy Pattern to implement various interpolation methods
	/// </summary>
	public abstract class Interpolator
	{
		/// <summary>
		/// Estimates the y value
		/// </summary>
		/// <param name="x">x-value</param>
		/// <returns>estimated y-value</returns>
		public abstract double Calculate(double x);
		/// <summary>
		/// Coefficient of determination, r squared, indicates how good models estimation of the y-value is.
		/// Nearer to 0 is poor, 1 is perfect.
		/// </summary>
		/// <returns>Coefficient of determination, r squared, a value 0-1</returns>
		public abstract double RSquared();

		public abstract double[] Coefficients();
		/// <summary>
		/// Factory method to create the required implementation of the interpolation algorithm
		/// </summary>
		/// <param name="fit">interpolation algorithm type</param>
		/// <param name="standards">Data points to be fitted</param>
		/// <returns>Interpolation algorithm</returns>
		public static Interpolator Create(CurveFits fit, IEnumerable<DPoint> standards)
		{
			Interpolator interp = null;
			//ensure points are sorted in order of x values
			List<DPoint> standardsList = new List<DPoint>(standards);
			standardsList.Sort((a, b) => a.X.CompareTo(b.X));
			switch (fit)
			{
				case CurveFits.Interpolate:
					interp = new SimpleInterpolator(standardsList);
					break;
				case CurveFits.LinearZero:
					interp = new BestLineThruOriginInterpolation(standardsList);
					break;
				case CurveFits.Linear:
					interp = new BestLineInterpolation(standardsList);
					break;
				case CurveFits.Quadratic:
					interp = new QuadraticInterpolator(standardsList);
					break;
				case CurveFits.QuadraticThruZero:
					interp = new QuadraticThruZeroInterpolator(standardsList);
					break;
				default:
					break;
			}
			return interp;
		}
	}

	/// <summary>
	/// Quadratic Interpolation, a function of the type y = ax^2  + bx + c
	/// is fitted to the data
	/// </summary>
	public class QuadraticInterpolator : Interpolator
	{
		QuadraticFit quadraticFit;

		public QuadraticInterpolator(IEnumerable<DPoint> standards)
		{
			quadraticFit = new QuadraticFit();
			quadraticFit.Points.AddRange(standards);
			quadraticFit.CalculateParameters();
		}
		public override double RSquared()
		{
			return quadraticFit.CoefficientOfDetermination();
		}
		public override double Calculate(double x)
		{
			return quadraticFit.Calculate(x);
		}

		public override double[] Coefficients()
		{
			Matrix coefficients = quadraticFit.CalculateParameters();
			return new double[] { coefficients[0, 0], coefficients[1, 0], coefficients[2, 0] };
		}
	}
	/// <summary>
	/// Quadratic Interpolation, a function of the type y = ax^2  + bx + c
	/// is fitted to the data
	/// </summary>
	public class QuadraticThruZeroInterpolator : Interpolator
	{
		QuadraticFitThruZero quadraticFit;

		public QuadraticThruZeroInterpolator(IEnumerable<DPoint> standards)
		{
			quadraticFit = new QuadraticFitThruZero();
			quadraticFit.Points.AddRange(standards);
			quadraticFit.CalculateParameters();
		}
		public override double RSquared()
		{
			return quadraticFit.CoefficientOfDetermination();
		}
		public override double Calculate(double x)
		{
			return quadraticFit.Calculate(x);
		}
		public override double[] Coefficients()
		{
			Matrix coefficients = quadraticFit.CalculateParameters();
			return new double[] { 0, coefficients[0, 0], coefficients[1, 0]};
		}

	}

	/// <summary>
	/// No function is actually fitted to the data points, instead, like a line chart, a straight line connects adjacent points.
	/// So a value x is mapped onto a straight line connecting the bounding standard data points
	/// 
	/// ??? - not sure to do when x is outside the data points range
	/// </summary>
	public class SimpleInterpolator : Interpolator
	{
		List<DPoint> standards;
		public SimpleInterpolator(IEnumerable<DPoint> standards)
		{
			this.standards = new List<DPoint>(standards);
		}
		public override double RSquared()
		{
			return 1;
		}

		public override double Calculate(double x)
		{
			DPoint lower = standards[0];
			DPoint upper = standards[standards.Count - 1];
			//find the two points that x lies between
			foreach (DPoint data in standards)
			{
				if (x >= data.X)
				{
					lower = data;
				}
				if (x < data.X)
				{
					upper = data;
					break;
				}
			}
			if (lower.Equals(upper))
			{
				//x is out of range, so use 2 outmost standards as limits
				lower = standards[0];
				upper = standards[standards.Count - 1];
			}

			//for a straight line y=mx+c
			//and two points (x1,y1), (x2,y2)
			// m = (y2-y1)/(x2-x1)
			// c = (y1x2-y2x1)/(x2-x1)
			double m = (upper.Y - lower.Y) / (upper.X - lower.X);
			double c = (lower.Y * upper.X - upper.Y * lower.X) / (upper.X - lower.X);
			double y = m*x+c;
			return y;
		}

		public override double[] Coefficients()
		{
			return null;
		}

	}

	/// <summary>
	/// Interpolation using a best line of fit through the data points
	/// </summary>
	public class BestLineInterpolation : Interpolator
	{
		BestLineFit bestLineFit;
		public BestLineInterpolation(IEnumerable<DPoint> standards)
		{
			bestLineFit = new BestLineFit(standards);
		}

		public override double Calculate(double x)
		{
			return bestLineFit.Slope * x + bestLineFit.Intercept;
		}

		public override double RSquared()
		{
			return bestLineFit.RSquared;
		}
		public override double[] Coefficients()
		{
			return new double[] { bestLineFit.Intercept, bestLineFit.Slope };
		}
	}

	/// <summary>
	/// Interpolation using a best line of fit through the data points, but the line also goes through the origin. 
	/// </summary>
	public class BestLineThruOriginInterpolation : Interpolator
	{
		BestLineFit bestLineFit;
		double rsquared;
		public BestLineThruOriginInterpolation(IEnumerable<DPoint> standards)
		{
			bestLineFit = new BestLineFit(standards);

			//I don't have a formula yet for rsquared, so I'll work it out
			// r^2 = 1 - SSE/SST
			// SSE = Σ(y-mean(y))^2
			//SST = Σ(y-f(x))^2

			//first find the mean of y
			double mean = 0;
			double SST = 0;
			double SSE = 0;
			double count = 0;
			foreach (DPoint point in standards)
			{
				mean += point.Y;
				count++;
			}
			mean /= count;
			foreach (DPoint point in standards)
			{
				double temp = (point.Y - mean);
				SST +=  temp*temp;
				temp = point.Y-bestLineFit.SlopeThroughZero*point.X;
				SSE += temp * temp;
			}

			rsquared = 1 - SSE / SST;
		}

		public override double Calculate(double x)
		{
			return bestLineFit.SlopeThroughZero * x;
		}

		public override double RSquared()
		{
			return rsquared;
		}
		public override double[] Coefficients()
		{
			return new double[] {0, bestLineFit.SlopeThroughZero };
		}
	}
}
