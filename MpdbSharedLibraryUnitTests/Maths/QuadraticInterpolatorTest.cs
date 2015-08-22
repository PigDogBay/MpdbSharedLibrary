using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MpdBaileyTechnology.Shared.Maths;
namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
	/// <summary>
    ///This is a test class for QuadraticInterpolatorTest and is intended
    ///to contain all QuadraticInterpolatorTest Unit Tests
    ///</summary>
	[TestClass()]
	public class QuadraticInterpolatorTest
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

		List<DPoint> standards()
		{
			// y= 2x^2 -3x +8
			List<DPoint> standards = new List<DPoint>();
			standards.Add(new DPoint(0, 8));
			standards.Add(new DPoint(1, 7));
			standards.Add(new DPoint(2, 10));
			return standards;
		}


		/// <summary>
		///A test for Coefficients
		///</summary>
		[TestMethod()]
		public void CoefficientsTest()
		{
			QuadraticInterpolator target = new QuadraticInterpolator(standards());
			double[] actual;
			actual = target.Coefficients();
			Assert.AreEqual(3, actual.Length);
			Assert.AreEqual(8, actual[0]);
			Assert.AreEqual(-3, actual[1]);
			Assert.AreEqual(2, actual[2]);
		}
	}
}
