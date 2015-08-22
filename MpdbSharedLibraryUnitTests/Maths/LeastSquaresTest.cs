using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MpdBaileyTechnology.Shared.Maths;
namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
	/// <summary>
	///This is a test class for LeastSquaresTest and is intended
	///to contain all LeastSquaresTest Unit Tests
	///</summary>
	[TestClass()]
	public class LeastSquaresTest
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
		///A test for CalculateParameters
		///</summary>
		[TestMethod()]
		public void CalculateParametersTest()
		{
			LeastSquares target = new QuadraticFit();
			//Excel generated data, y = 5 -7x +2xx
			target.Points.Add(new DPoint(0, 5));
			target.Points.Add(new DPoint(1, 0));
			target.Points.Add(new DPoint(2, -1));
			target.Points.Add(new DPoint(3, 2));
			target.Points.Add(new DPoint(4, 9));
			target.Points.Add(new DPoint(5, 20));

			Matrix expected = new Matrix(new double[,]{
				{5},
				{-7},
				{2}});
			Matrix actual;
			actual = target.CalculateParameters();
			actual.FactorInScalar();
			//			Debug.WriteLine(actual.ToString());
			//			Debug.WriteLine(expected.ToString());
			//have to string compare due to double precision
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}

		/// <summary>
		///A test for CalculateParameters, y = x*x
		///</summary>
		[TestMethod()]
		public void CalculateParametersTest2()
		{
			LeastSquares target = new QuadraticFit();
			target.Points.Add(new DPoint(2, 4));
			target.Points.Add(new DPoint(4, 16));
			target.Points.Add(new DPoint(5, 25));

			Matrix expected = new Matrix(new double[,]{
				{0},
				{0},
				{1}});
			Matrix actual;
			actual = target.CalculateParameters();
			actual.FactorInScalar();
			//			Debug.WriteLine(actual.ToString());
			//			Debug.WriteLine(expected.ToString());
			//have to string compare due to double precision
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}

		/// <summary>
		///A test for GetYValuesMatrix
		///</summary>
		[TestMethod()]
		public void GetYValuesMatrixTest()
		{
			LeastSquares target = new QuadraticFit();
			//Excel generated data, y = 5 -7x +2xx
			target.Points.Add(new DPoint(0, 5));
			target.Points.Add(new DPoint(1, 0));
			target.Points.Add(new DPoint(2, -1));
			target.Points.Add(new DPoint(3, 2));
			target.Points.Add(new DPoint(4, 9));
			target.Points.Add(new DPoint(5, 20));

			Matrix expected = new Matrix(new double[,]{
				{5},
				{0},
				{-1},
				{2},
				{9},
				{20}});
			Matrix actual = target.GetYValuesMatrix();
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Using Excel:
		/// y = -0.3485x2 + 2.8758x + 1.0909
		/// R2 = 0.9564
		/// Sum(y) = 41
		/// </summary>
		DPoint[] testData1()
		{
			DPoint[] testData = new DPoint[]{
				new DPoint(0,1),
				new DPoint(1,3),
				new DPoint(2,6),
				new DPoint(3,7),
				new DPoint(4,8),
				new DPoint(5,6),
				new DPoint(6,5),
				new DPoint(7,4),
				new DPoint(8,2),
				new DPoint(9,-1)};
			return testData;
		}
		[TestMethod()]
		public void CalculateParametersTest3()
		{
			LeastSquares target = new QuadraticFit();
			target.Points.AddRange(testData1());
			Matrix coeff = target.CalculateParameters();
			Assert.AreEqual("1.0909", coeff[0, 0].ToString("0.0000"));
			Assert.AreEqual("2.8758", coeff[1, 0].ToString("0.0000"));
			Assert.AreEqual("-0.3485", coeff[2, 0].ToString("0.0000"));
		}

		/// <summary>
		///A test for CoefficientOfDetermination
		///</summary>
		[TestMethod()]
		public void CoefficientOfDeterminationTest()
		{
			LeastSquares target = new QuadraticFit();
			target.Points.AddRange(testData1());
			Matrix coeff = target.CalculateParameters();
			Assert.AreEqual(4.1, target.MeanYValue());
			Assert.AreEqual("0.9564", target.CoefficientOfDetermination().ToString("0.0000"));
		}
	}
}
