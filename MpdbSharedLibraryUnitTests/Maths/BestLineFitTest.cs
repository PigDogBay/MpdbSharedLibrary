
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.Maths;
namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{	
	/// <summary>
	///This is a test class for BestLineFitTest and is intended
	///to contain all BestLineFitTest Unit Tests
	///</summary>
	[TestClass()]
	public class BestLineFitTest
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
		///A test for Slope
		///</summary>
		[TestMethod()]
		public void Test1()
		{
			//Excel calculates for the points: 
			// y = 2.7x -1.7
			//R^2 = 0.9406
			//Zero line fit, y = 2.2593x
			BestLineFit target = new BestLineFit();
			target.Add(2, 3);
			target.Add(3, 7);
			target.Add(4, 10);
			target.Add(5, 11);

			Assert.AreEqual(2.7, target.Slope);
			Assert.AreEqual("-1.7000", target.Intercept.ToString("0.0000"));
			Assert.AreEqual("0.9406", target.RSquared.ToString("0.0000"));
			Assert.AreEqual("2.2593", target.SlopeThroughZero.ToString("0.0000"));
		}
	}
}
