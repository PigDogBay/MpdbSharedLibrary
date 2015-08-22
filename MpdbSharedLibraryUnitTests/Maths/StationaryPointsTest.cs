using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MpdBaileyTechnology.Shared.Maths;
namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
	/// <summary>
	///This is a test class for StationaryPointsTest and is intended
	///to contain all StationaryPointsTest Unit Tests
	///</summary>
	[TestClass()]
	public class StationaryPointsTest
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
		///A test for CalculateTurningPoints
		///</summary>
		[TestMethod()]
		public void CalculateTurningPointsTest()
		{
			//y = x*x + 2x -1
			//y' = 2x +2
			//Stationary point at x = - 1
			List<DPoint> points = new List<DPoint>();
			for (int i = -100; i < 101; i++)
			{
				double x = (double)i;
				double y = x * x + 2 * x - 1;
				points.Add(new DPoint(x, y));
			}
			StationaryPoints target = new StationaryPoints(points.ToArray());
			TurningPoint[] actual;
			actual = target.CalculateTurningPoints();
			Assert.AreEqual(1, actual.Length);
			Assert.IsFalse(actual[0].IsPeak);
			Assert.AreEqual(-1d, actual[0].Point.X);
			//Y = -2 at x = -1. Note turning point y value is NOT the differential
			Assert.AreEqual(-2d, actual[0].Point.Y);
			Assert.AreEqual(99, actual[0].Index);
		}

		[TestMethod()]
		public void CalculateTurningPointsTest2()
		{
			//y = x*x*x - x*x - x +1
			//y' = 3x*x -2x -1 = (3x+1)(x-1)
			//Stationary points solutions x = -1/3 (peak) , +1 (trough)
			List<DPoint> points = new List<DPoint>();
			for (double x = -10; x < 10; x=x+0.01)
			{
				double y = x * x * x - x * x - x + 1;
				points.Add(new DPoint(x, y));
			}
			Differentiator differentiator = new Differentiator(points);
			differentiator.SampleSize = 9;
			DPoint[] diffPoints = differentiator.Differentiate();
			StationaryPoints target = new StationaryPoints(points.ToArray(), diffPoints);
			target.Threshold = 0;
			TurningPoint[] actual;
			actual = target.CalculateTurningPoints();
			Assert.AreEqual(2, actual.Length);
			Assert.IsTrue(actual[0].IsPeak);
			Assert.AreEqual("-0.33", actual[0].Point.X.ToString("0.00"));
			Assert.IsFalse(actual[1].IsPeak);
			Assert.AreEqual("1.00", actual[1].Point.X.ToString("0.00"));
		}

	}
}
