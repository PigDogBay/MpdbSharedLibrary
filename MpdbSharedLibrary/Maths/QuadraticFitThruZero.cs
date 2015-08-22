using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Maths
{
	public class QuadraticFitThruZero : LeastSquares
	{
		public QuadraticFitThruZero()
		{
		}
		/// <summary>
		/// A quadratic function has the form:
		/// 
		/// f(X) = a +bX + cXX
		/// 
		/// This method calculates the matrix of the X terms for each data point, without the coefficients (eg a=b=c=1)
		/// </summary>
		/// <returns>Matrix of the X terms of an quadratic equation</returns>
		public override Matrix GetXTermsMatrix()
		{
			double[,] matrixX = new double[Points.Count, 2];
			for (int i = 0; i < Points.Count; i++)
			{
				//X
				matrixX[i, 0] = Points[i].X;
				//X squared
				matrixX[i, 1] = Points[i].X * Points[i].X;
			}
			return new Matrix(matrixX);
		}

		public override double Calculate(double x)
		{
			if (parameters == null)
			{
				throw new InvalidOperationException("The equation parameters must be calculated first");
			}
			return parameters[0, 0] * x + parameters[1, 0] * x * x;
		}
	}
}
