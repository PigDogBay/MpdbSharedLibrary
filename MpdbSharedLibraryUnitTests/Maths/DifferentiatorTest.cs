using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MpdBaileyTechnology.Shared.Maths;
namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
	public struct Measurement
	{
		private double _Wavelength;
		public double Wavelength
		{
			get
			{
				return _Wavelength;
			}
		}
		private double _Transmittance;
		public double Transmittance
		{
			get
			{
				return _Transmittance;
			}
		}
		public Measurement(double w, double t)
		{
			_Wavelength = w;
			_Transmittance = t;
		}
	}
	
	/// <summary>
    ///This is a test class for DifferentiatorTest and is intended
    ///to contain all DifferentiatorTest Unit Tests
    ///</summary>
	[TestClass()]
	public class DifferentiatorTest
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
		///A test for Differentiate
		///</summary>
		[TestMethod()]
		public void DifferentiateConstructorTest()
		{
			Differentiator target = new Differentiator();
		}
		DPoint[] createPoints()
		{
			DPoint[] points = new DPoint[1000];
			int index = 0;
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					points[index] = new DPoint(index, j);
					index++;
				}
				for (int j = 0; j < 100; j++)
				{
					points[index] = new DPoint(index, 100-j);
					index++;
				}
			}
			return points;
		}
		public void DifferentiateConstructorTest2()
		{
			DPoint[] points = createPoints();
			Differentiator target = new Differentiator(points);
			Assert.AreEqual(points.Length,target.Points.Length);
		}

		/// <summary>
		///A test for Add
		///</summary>
		[TestMethod()]
		public void AddTest2()
		{
			Differentiator target = new Differentiator();
			//y = 2xx +3x + 4
			//y' = 4x +3 
			target.Add(new DPoint(0, 4));
			target.Add(new DPoint(1, 9));
			target.Add(new DPoint(2, 18));
			DPoint[] points = target.Points;
			Assert.AreEqual(3, points.Length);
			Assert.AreEqual(0, points[0].X);
			Assert.AreEqual(4, points[0].Y);
			Assert.AreEqual(1, points[1].X);
			Assert.AreEqual(9, points[1].Y);
			Assert.AreEqual(2, points[2].X);
			Assert.AreEqual(18, points[2].Y);
		}

		/// <summary>
		///A test for Add
		///</summary>
		[TestMethod()]
		public void AddTest1()
		{
			DPoint[] points = createPoints();
			Differentiator target = new Differentiator(points);
			target.Add(2, -2);
			target.Add(5, 31);
			target.Add(10, 166);
			Assert.AreEqual(points.Length+3, target.Points.Length);
		}
		/// <summary>
		///A test for Add
		///</summary>
		[TestMethod()]
		public void AddTest3()
		{
			Differentiator target = new Differentiator();
			List<Measurement> list = new List<Measurement>();
			list.Add(new Measurement(2, -2));
			list.Add(new Measurement(5, 31));
			list.Add(new Measurement(10, 166));
			target.Add(list, "Wavelength", "Transmittance");
			DPoint[] points = target.Points;
			Assert.AreEqual(3, points.Length);
			Assert.AreEqual(2, points[0].X);
			Assert.AreEqual(-2, points[0].Y);
			Assert.AreEqual(5, points[1].X);
			Assert.AreEqual(31, points[1].Y);
			Assert.AreEqual(10, points[2].X);
			Assert.AreEqual(166, points[2].Y);
		}

		[TestMethod()]
		public void Differentiate1()
		{
			DPoint[] points = createPoints();
			Differentiator target = new Differentiator(points);
			DPoint[] diffPoints = target.Differentiate();
			Assert.AreEqual(points.Length, diffPoints.Length);
			Assert.AreEqual(points[50].X, diffPoints[50].X);
			Assert.AreEqual(points[500].X, diffPoints[500].X);
			//gradient = 1
			Assert.AreEqual(1d, diffPoints[50].Y);
			//gradient  = -1
			Assert.AreEqual(-1d, diffPoints[150].Y);
			//turning point
			Assert.AreEqual(0d, diffPoints[100].Y);
		}
		/// <summary>
		/// Check that end points are correctly calculated
		/// </summary>
		[TestMethod()]
		public void EndPoints()
		{
			DPoint[] points = createPoints();
			Differentiator target = new Differentiator(points);
			DPoint[] diffPoints = target.Differentiate();
			Assert.AreEqual(0, diffPoints[0].X);
			Assert.AreEqual(1, diffPoints[0].Y);
			Assert.AreEqual(999, diffPoints[999].X);
			Assert.AreEqual(-1, diffPoints[999].Y);

		}
		/// <summary>
		/// Larger sample size than data
		/// </summary>
		[TestMethod()]
		public void SampleSize()
		{
			Differentiator target = new Differentiator();
			target.SampleSize = 9;
			//y=2x+1
			target.Add(new DPoint(0, 1));
			target.Add(new DPoint(1, 3));
			target.Add(new DPoint(2, 5));
			DPoint[] diffPoints = target.Differentiate();
			Assert.AreEqual(3, diffPoints.Length);
			//expect best line fit, which has gadient of 2
			Assert.AreEqual(2, diffPoints[0].Y);
			Assert.AreEqual(2, diffPoints[1].Y);
			Assert.AreEqual(2, diffPoints[2].Y);
		}
		/// <summary>
		/// Check algorithm gives resaonable results for differentiating a curve
		/// y = 3x*x -2x + 1
		/// y' = 6x-2
		/// </summary>
		[TestMethod()]
		public void Accuracy()
		{
			List<DPoint> points = new List<DPoint>();
			for (int i = -100; i < 101; i++)
			{
				double x = (double)i;
				double y = 3 * x * x - 2 * x + 1;
				points.Add(new DPoint(x, y));
			}
			Differentiator target = new Differentiator(points);
			DPoint[] diffPoints = target.Differentiate();
			//x=0, y' = -2
			Assert.AreEqual(0d, diffPoints[100].X);
			Assert.AreEqual(-2d, diffPoints[100].Y);
			//x=1, y'=4
			Assert.AreEqual(1d, diffPoints[101].X);
			Assert.AreEqual(4d, diffPoints[101].Y);
			//x=-1, y'=-8
			Assert.AreEqual(-1d, diffPoints[99].X);
			Assert.AreEqual(-8d, diffPoints[99].Y);
			//x=42, y'=250
			Assert.AreEqual(42d, diffPoints[142].X);
			Assert.AreEqual(250d, diffPoints[142].Y);
		}

	}
}
