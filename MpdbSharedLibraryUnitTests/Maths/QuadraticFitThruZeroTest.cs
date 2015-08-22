using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MpdBaileyTechnology.Shared.Maths;
namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
	/// <summary>
    ///This is a test class for QuadraticFitThruZeroTest and is intended
    ///to contain all QuadraticFitThruZeroTest Unit Tests
    ///</summary>
	[TestClass()]
	public class QuadraticFitThruZeroTest
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
		///A test for Calculate
		///</summary>
		[TestMethod()]
		public void GetXTermsMatrixTest()
		{
			//data for y = -7x +2xx
			QuadraticFitThruZero target = new QuadraticFitThruZero();
			target.Points.Add(new DPoint(0, 0));
			target.Points.Add(new DPoint(1, -5));
			target.Points.Add(new DPoint(2, -6));
			target.Points.Add(new DPoint(3, -3));
			target.Points.Add(new DPoint(4, 4));
			target.Points.Add(new DPoint(5, 15));

			Matrix expected = new Matrix(new double[,]{
				{0,0},
				{1,1},
				{2,4},
				{3,9},
				{4,16},
				{5,25}});

			Matrix actual = target.GetXTermsMatrix();
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for GetXTermsMatrix
		///</summary>
		[TestMethod()]
		public void CalculateTest()
		{
			QuadraticFitThruZero target = new QuadraticFitThruZero();
			//data for y = -7x +2xx
			target.Points.Add(new DPoint(0, 0));
			target.Points.Add(new DPoint(1, -5));
			target.Points.Add(new DPoint(2, -6));
			target.Points.Add(new DPoint(3, -3));
			target.Points.Add(new DPoint(4, 4));
			target.Points.Add(new DPoint(5, 15));
			Matrix parameters = target.CalculateParameters();
			Assert.AreEqual(3234, target.Calculate(42));

		}

		[TestMethod()]
		public void ParametersTest()
		{
			//data for y = -7x +2xx
			QuadraticFitThruZero target = new QuadraticFitThruZero();
			target.Points.Add(new DPoint(0, 0));
			target.Points.Add(new DPoint(1, -5));
			target.Points.Add(new DPoint(2, -6));
			target.Points.Add(new DPoint(3, -3));
			target.Points.Add(new DPoint(4, 4));
			target.Points.Add(new DPoint(5, 15));
			Matrix parameters = target.CalculateParameters();
			//x term
			Assert.AreEqual("-7.0000", parameters[0, 0].ToString("0.0000"));
			//x squared term
			Assert.AreEqual("2.0000", parameters[1, 0].ToString("0.0000"));

		}
	}
}
