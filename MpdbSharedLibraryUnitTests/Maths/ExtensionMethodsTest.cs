using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using MpdBaileyTechnology.Shared.Maths;
namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
   
    /// <summary>
    ///This is a test class for MathsTest and is intended
    ///to contain all MathsTest Unit Tests
    ///</summary>
	[TestClass()]
	public class ExtensionMethodsTest
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
		///A test for RoundToSignificance
		///</summary>
		[TestMethod()]
		public void RoundToSignificanceTest()
		{
			Assert.AreEqual(32, ExtensionMethods.RoundToSignificance(31, 2));
			Assert.AreEqual(34, ExtensionMethods.RoundToSignificance(33, 2));
			Assert.AreEqual(34, ExtensionMethods.RoundToSignificance(34, 2));
			Assert.AreEqual(36, ExtensionMethods.RoundToSignificance(35, 2));
			Assert.AreEqual(38, ExtensionMethods.RoundToSignificance(37, 2));
			Assert.AreEqual(35, ExtensionMethods.RoundToSignificance(36, 5));
			Assert.AreEqual(420, ExtensionMethods.RoundToSignificance(419, 10));
			Assert.AreEqual(410, ExtensionMethods.RoundToSignificance(414, 10));
			Assert.AreEqual(420, ExtensionMethods.RoundToSignificance(417, 10));
			Assert.AreEqual(420, ExtensionMethods.RoundToSignificance(416, 10));
			Assert.AreEqual(415, ExtensionMethods.RoundToSignificance(417, 5));
		}

		/// <summary>
		///A test for RoundToSignificantDigits
		///</summary>
		[TestMethod()]
		public void RoundToSignificantDigitsTest()
		{
			double d1 = 123.456d;
			Assert.AreEqual(d1.RoundToSignificantDigits(1), 100d);
			Assert.AreEqual(d1.RoundToSignificantDigits(2), 120d);
			Assert.AreEqual(d1.RoundToSignificantDigits(3), 123d);
			Assert.AreEqual(d1.RoundToSignificantDigits(4), 123.5d);
			Assert.AreEqual(d1.RoundToSignificantDigits(5), 123.46d);
			Assert.AreEqual(d1.RoundToSignificantDigits(6), 123.456d);
			d1 = 654.321d;
			Assert.AreEqual(d1.RoundToSignificantDigits(1), 700d);
			Assert.AreEqual(d1.RoundToSignificantDigits(2), 650d);
			Assert.AreEqual(d1.RoundToSignificantDigits(3), 654d);
			Assert.AreEqual(d1.RoundToSignificantDigits(4), 654.3d);
			Assert.AreEqual(d1.RoundToSignificantDigits(5), 654.32d);
			Assert.AreEqual(d1.RoundToSignificantDigits(6), 654.321d);
		}
		[TestMethod()]
		public void MeanTest1()
		{
			double[] d = { 0d, 200d};
			Assert.AreEqual(100d, d.Mean());
		}
		[TestMethod()]
		public void MeanTest2()
		{
			double[] d = { 1d, 2d, 3d, 4d, 5d };
			Assert.AreEqual(3d, d.Mean());
		}
		[TestMethod()]
		public void StandardDeviationTest1()
		{
			double[] d = { 2, 4, 4, 4, 5, 5, 7, 9 };
			Assert.AreEqual(2, d.StandardDeviation());
		}
		[TestMethod()]
		public void StandardDeviationTest2()
		{
			double[] d = { 1,2,3,4,5};
			Assert.AreEqual(Math.Sqrt(2), d.StandardDeviation());
		}


	}
}
