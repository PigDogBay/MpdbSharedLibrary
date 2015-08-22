using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Maths
{
	/// <summary>
	/// Structure to hold a X,Y data point
	/// </summary>
	public struct DPoint
	{
		public double X;
		public double Y;

		public DPoint(double X, double Y)
		{
			this.X = X;
			this.Y = Y;
		}

		public override string ToString()
		{
			return string.Format("({0},{1})", X.ToString(), Y.ToString());
		}
	}
}
