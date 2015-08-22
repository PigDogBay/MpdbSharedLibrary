using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Maths
{
	/// <summary>
	/// This class fits a function, y=f(x), to a set of X,Y data values
	/// using the method of least squares.
	/// 
	/// Matrices are used to calculate the fit, see CalculateParameters()
	/// 
	/// Subclasses implement the following methods that implement the function details:
	///		Calculate(double x): returns f(x)
	///		GetXTermsMatrix(): returns a matrix of each of the terms of the function, so that
	///			
	///			Y = Xβ   (Y is column vector of Y values, β is column vector of the function parameters/coefficients)
	/// 
	/// For a quadratic, X matrix is implemented as such
	///		1   x1   x1^2
	///		1   x2   x2^2
	///		1   x3   x3^2    where x1, x2, x3... are the various x data values
	///	 
	/// Y column vector
	///		y1
	///		y2
	///		y3		where y1,y2,y3...are the various y data values
	///		
	/// β column vector of the coefficients of the polynomial terms:
	///		a
	///		b
	///		c   (where y = a + bx + cx^2)
	///		
	///  Reference:
	///  http://en.wikipedia.org/wiki/Linear_least_squares
	/// </summary>
	public abstract class LeastSquares
	{
		private List<DPoint> points = new List<DPoint>();
		protected Matrix parameters;

		/// <summary>
		/// Gets the list of DataPoints that specify the X,Y data values that least squares algorithm will function fit
		/// </summary>
		public List<DPoint> Points
		{
			get { return points; }
		}
		/// <summary>
		/// For a quadratic, X matrix is implemented as such
		///		1   x1   x1^2
		///		1   x2   x2^2
		///		1   x3   x3^2    where x1, x2, x3... are the various x data values
		///		
		///  (Note there are no coefficients,as these are the what we are ultimately trying to find and will be calculated in CalculateParameters())
		/// </summary>
		/// <returns>Matrix of the X terms of a function for each x value in the list of X,Y data points</returns>
		public abstract Matrix GetXTermsMatrix();
		/// <summary>
		/// Calculates the  y value, y = f(x)
		/// Where f(x) is the function that has been calculated to fit the data points
		/// Please note that the function parameters must be calculated first before this method can be called
		/// </summary>
		/// <param name="x">x value</param>
		/// <returns>Calculated y - value</returns>
		public abstract double Calculate(double x);

		/// <summary>
		/// Column vector of the y data values
		/// </summary>
		/// <returns>Column matrix of the y values</returns>
		public Matrix GetYValuesMatrix()
		{
			double[,] yvalues = new double[points.Count, 1];
			for (int i = 0; i < points.Count; i++)
			{
				yvalues[i, 0] = points[i].Y;
			}
			Matrix matrix = new Matrix(yvalues);
			return matrix;
		}

		/// <summary>
		/// Calculatest the function parameters, β column vector
		/// 
		/// The function uses the following matrix equation to calculate the parameters
		/// 
		/// β = Inverse(transpose(X) X) transpose(X)Y
		/// 
		/// Where X is the matrix returned by GetXTermsMatrix() and Y is a column vector of the Y data values
		/// </summary>
		/// <returns>Column matrix, β, of the function parameters</returns>
		public Matrix CalculateParameters()
		{
			Matrix X = GetXTermsMatrix();
			Matrix transposeX = X.Transpose();
			Matrix tmp = transposeX * X;
			tmp = tmp.Inverse();
			tmp = tmp * transposeX;
			tmp = tmp * GetYValuesMatrix();
			tmp.FactorInScalar();
			this.parameters = tmp;
			return tmp;
		}
		/// <summary>
		/// Calculates the mean Y value of the data
		/// </summary>
		/// <returns>mean Y value of the data</returns>
		public double MeanYValue()
		{
			double mean = 0;
			foreach (DPoint point in points)
			{
				mean += point.Y;
			}
			return mean / points.Count; ;
		}
		/// <summary>
		/// Sum of the squared errors is defined as
		/// SSE = Σ (y-f(x))^2
		/// 
		/// Where y is the y value of a data point, f(x) is the calculated value of y
		/// 
		/// </summary>
		/// <returns>Sum of the squared errors</returns>
		public double SumOfSquaredErrors()
		{
			double sse = 0;
			foreach (DPoint point in points)
			{
				double difference = point.Y - Calculate(point.X);
				sse += (difference * difference);
			}
			return sse;
		}
		/// <summary>
		/// Total sum of squares:
		/// 
		///			SST = Σ (y-ŷ)^2
		/// 
		/// Where ŷ is the mean of the y data values.
		/// </summary>
		/// <returns>Total sum of squares</returns>
		public double TotalSumOfSquares()
		{
			double sst = 0;
			double mean = MeanYValue();
			foreach (DPoint point in points)
			{
				double difference = point.Y - mean;
				sst += (difference * difference);
			}
			return sst;
		}
		/// <summary>
		///  The coefficient of determination (R-squared value) gives a indication of how well the model fits the data.
		///  The values range from 0 to 1, 0 - poor fit, 1 - perfect fit
		///  
		///		R^2 = 1 - (SSE/SST)
		///		
		/// SSE - Sum of squared errors
		/// SST - Total sum of squares
		/// </summary>
		/// <returns>Coefficient of determination (R-squared Value)</returns>
		public double CoefficientOfDetermination()
		{
			return 1 - (SumOfSquaredErrors() / TotalSumOfSquares());
		}
	}
}
