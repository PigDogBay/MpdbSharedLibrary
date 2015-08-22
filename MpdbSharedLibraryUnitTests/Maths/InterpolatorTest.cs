using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MpdBaileyTechnology.Shared.Maths;
namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{


	/// <summary>
	///This is a test class for InterpolatorTest and is intended
	///to contain all InterpolatorTest Unit Tests
	///</summary>
	[TestClass()]
	public class InterpolatorTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion

		/// <summary>
		/// Data checked in Excel
		/// Sx = 14
		/// Sy = 31
		/// Sxx = 54
		/// Sxy = 122
		/// mean(y) = 7.75
		/// Slope = 2.7, intercept = -1.7
		/// Slope of line thru origin = 2.2593
		/// R^2 = 0.9406
		/// R^2 for line thru origin = 0.913
		/// 
		/// Quadratic Equation
		/// y = -0.75x2 + 7.95x - 9.95
		/// R2 = 0.9987
		/// 
		/// Quadratic thru zero
		/// y = 0.0804x2 + 1.9256x
		/// R2 = 0.9212
		/// </summary>
		/// <returns></returns>
		List<DPoint> standards()
		{
			List<DPoint> standards = new List<DPoint>();
			standards.Add(new DPoint(2, 3));
			standards.Add(new DPoint(3, 7));
			standards.Add(new DPoint(4, 10));
			standards.Add(new DPoint(5, 11));
			return standards;
		}

		/// <summary>
		///A test for Interpolator Calculate
		///</summary>
		[TestMethod()]
		public void InterpolatorCalculateTest()
		{
			List<DPoint> standards = new List<DPoint>();
			standards.Add(new DPoint(3, 2));
			standards.Add(new DPoint(4, 3));
			standards.Add(new DPoint(5, 6));
			standards.Add(new DPoint(6, 4));
			standards.Add(new DPoint(7, 5));
			SimpleInterpolator target = new SimpleInterpolator(standards);
			Assert.AreEqual(2, target.Calculate(3));
			Assert.AreEqual(3, target.Calculate(4));
			Assert.AreEqual(6, target.Calculate(5));
			Assert.AreEqual(4, target.Calculate(6));
			Assert.AreEqual(5, target.Calculate(7));

			//half-way between
			Assert.AreEqual(2.5, target.Calculate(3.5));
			Assert.AreEqual(4.5, target.Calculate(4.5));
			Assert.AreEqual(5, target.Calculate(5.5));
			Assert.AreEqual(4.5, target.Calculate(6.5));
		}

		/// <summary>
		///A test for BestLineThruOriginInterpolation Calculate
		///</summary>
		[TestMethod()]
		public void BestLineThruOriginCalculateTest()
		{
			BestLineThruOriginInterpolation target = new BestLineThruOriginInterpolation(standards());
			Assert.AreEqual("0.9130", target.RSquared().ToString("0.0000"));
			//passes thru origin
			Assert.AreEqual(0, target.Calculate(0));
			Assert.AreEqual("2259.3", target.Calculate(1000).ToString("0.0"));
		}
		/// <summary>
		///A test for BestLineInterpolation Calculate
		///</summary>
		[TestMethod()]
		public void BestLineCalculateTest()
		{
			BestLineInterpolation target = new BestLineInterpolation(standards());
			Assert.AreEqual("0.9406", target.RSquared().ToString("0.0000"));
			//passes thru origin
			Assert.AreEqual("-1.700", target.Calculate(0).ToString("0.000"));
			Assert.AreEqual("2698.3", target.Calculate(1000).ToString("0.0"));
		}
		/// <summary>
		///A test for QuadraticInterpolation Calculate
		///</summary>
		[TestMethod()]
		public void QuadraticCalculateTest()
		{
			QuadraticInterpolator target = new QuadraticInterpolator(standards());
			Assert.AreEqual("0.9987", target.RSquared().ToString("0.0000"));
			//passes thru origin
			Assert.AreEqual("-9.950", target.Calculate(0).ToString("0.000"));
			Assert.AreEqual("-742059.95", target.Calculate(1000).ToString("0.00"));
		}
		[TestMethod()]
		public void QuadraticThruZeroCalculateTest()
		{
			//y = 0.0804x2 + 1.9256x
			//R2 = 0.9212
			QuadraticThruZeroInterpolator target = (QuadraticThruZeroInterpolator)Interpolator.Create(CurveFits.QuadraticThruZero, standards());
			Assert.AreEqual("0.9212", target.RSquared().ToString("0.0000"));
			//passes thru origin
			Assert.AreEqual("0.000", target.Calculate(0).ToString("0.000"));
			Assert.AreEqual("222.7", target.Calculate(42).ToString("0.0"));
		}

		[TestMethod()]
		public void Create()
		{
			List<DPoint> stds = standards();
			Interpolator target = Interpolator.Create(CurveFits.LinearZero, stds);
			Assert.IsTrue(target is BestLineThruOriginInterpolation);
			Assert.AreEqual("0.9130", target.RSquared().ToString("0.0000"));

			target = Interpolator.Create(CurveFits.Linear, stds);
			Assert.IsTrue(target is BestLineInterpolation);
			Assert.AreEqual("0.9406", target.RSquared().ToString("0.0000"));

			target = Interpolator.Create(CurveFits.Interpolate, stds);
			Assert.IsTrue(target is SimpleInterpolator);
			Assert.AreEqual("1.0000", target.RSquared().ToString("0.0000"));

			target = Interpolator.Create(CurveFits.Quadratic, stds);
			Assert.IsTrue(target is QuadraticInterpolator);
			Assert.AreEqual("0.9987", target.RSquared().ToString("0.0000"));
		}
	}
}
