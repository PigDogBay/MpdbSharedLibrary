using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using MpdBaileyTechnology.Shared.Maths;
namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
	/// <summary>
	///This is a test class for QuadraticFitTest and is intended
	///to contain all QuadraticFitTest Unit Tests
	///</summary>
	[TestClass()]
	public class QuadraticFitTest
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
		/// Data from F200 / SMP40 temperature measurements
		/// Exel gives the following formula:
		/// y = -2E-05x2 + 1.0171x - 0.1298
		/// </summary>
		/// <returns></returns>
		DPoint[] realData()
		{
			DPoint[] points = new DPoint[]{
				new DPoint(49.98,50.527d),
				new DPoint(59.98,60.734d),
				new DPoint(69.98,70.938d),
				new DPoint(79.99	,81.12d),
				new DPoint(89.99	,91.288d),
				new DPoint(99.99	,101.451d),
				new DPoint(110	,111.609d),
				new DPoint(119.98	,121.752d),
				new DPoint(129.99	,131.88d),
				new DPoint(139.98	,142.008d),
				new DPoint(149.99	,152.14d),
				new DPoint(159.99	,162.253d),
				new DPoint(169.99	,172.361d),
				new DPoint(179.99	,182.474d),
				new DPoint(190	,192.591d),
				new DPoint(199.99	,202.686d),
				new DPoint(209.99	,212.796d),
				new DPoint(219.99	,222.898d),
				new DPoint(229.99	,233.01d),
				new DPoint(239.99	,243.097d),
				new DPoint(249.99	,253.199d),
				new DPoint(259.99	,263.276d),
				new DPoint(270	,273.357d),
				new DPoint(279.99	,283.424d),
				new DPoint(289.98	,293.484d),
				new DPoint(300	,303.556d),
				new DPoint(310	,313.63d),
				new DPoint(319.99	,323.689d),
				new DPoint(330	,333.758d),
				new DPoint(340	,343.827d),
				new DPoint(349.98	,353.888d),
				new DPoint(359.99	,363.98d),
				new DPoint(370	,374.092d),
				new DPoint(379.98	,384.186d),
				new DPoint(390	,394.349d),
				new DPoint(399.99	,404.49d)};

			return points;
		}

		/// <summary>
		///A test for GetXTermsMatrix
		///</summary>
		[TestMethod()]
		public void GetXTermsMatrixTest()
		{
			//Excel generated data, y = 5 -7x +2xx
			QuadraticFit target = new QuadraticFit();
			target.Points.Add(new DPoint(0, 5));
			target.Points.Add(new DPoint(1, 0));
			target.Points.Add(new DPoint(2, -1));
			target.Points.Add(new DPoint(3, 2));
			target.Points.Add(new DPoint(4, 9));
			target.Points.Add(new DPoint(5, 20));

			Matrix expected = new Matrix(new double[,]{
				{1,0,0},
				{1,1,1},
				{1,2,4},
				{1,3,9},
				{1,4,16},
				{1,5,25}});

			Matrix actual = target.GetXTermsMatrix();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ParametersTest()
		{
			QuadraticFit target = new QuadraticFit();
			target.Points.AddRange(realData());
			Matrix parameters = target.CalculateParameters();
			Debug.WriteLine(parameters.ToString());
			/// Exel gives the following formula:
			/// y = -2E-05x2 + 1.0171x - 0.1298
			//Constant term
			Assert.AreEqual("-0.1298", parameters[0, 0].ToString("0.0000"));
			//x term
			Assert.AreEqual("1.0171", parameters[1, 0].ToString("0.0000"));
			//x squared term
			Assert.AreEqual("-0.00002", parameters[2, 0].ToString("0.00000"));
		}

		/// <summary>
		///A test for Calculate
		///</summary>
		[TestMethod()]
		public void CalculateTest()
		{
			//Excel generated data, y = 5 -7x +2xx
			QuadraticFit target = new QuadraticFit(); // TODO: Initialize to an appropriate value
			target.Points.Add(new DPoint(0, 5));
			target.Points.Add(new DPoint(1, 0));
			target.Points.Add(new DPoint(2, -1));
			target.Points.Add(new DPoint(3, 2));
			target.Points.Add(new DPoint(4, 9));
			target.Points.Add(new DPoint(5, 20));
			target.CalculateParameters();

			Assert.AreEqual(3239, target.Calculate(42));
		}
	}
}
