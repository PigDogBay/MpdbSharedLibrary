using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using MpdBaileyTechnology.Shared.Maths;
namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
	/// <summary>
	///This is a test class for MatrixTest and is intended
	///to contain all MatrixTest Unit Tests
	///</summary>
	[TestClass()]
	public class MatrixTest
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
		///A test for Transpose
		///</summary>
		[TestMethod()]
		public void TransposeTest()
		{
			double[,] targetArray = {
							   {1,2},
							   {3,4}};
			double[,] expectedArray ={
									{1,3},
									{2,4}};

			Matrix target = new Matrix(targetArray);
			Matrix transpose = target.Transpose();
			Matrix expected = new Matrix(expectedArray);
			Assert.AreNotEqual(expected, target);
			Assert.AreEqual(expected, transpose);
		}
		[TestMethod()]
		public void TransposeTest2()
		{
			double[,] targetArray = {
							   {1,2},
							   {3,4},
							   {5,6}};
			double[,] expectedArray ={
									{1,3,5},
									{2,4,6}};

			Matrix target = new Matrix(targetArray);
			Matrix transpose = target.Transpose();
			Matrix expected = new Matrix(expectedArray);
			Assert.AreNotEqual(expected, target);
			Assert.AreEqual(expected, transpose);
		}
		[TestMethod()]
		public void TransposeTest3()
		{
			double[,] targetArray = {
							   {1,2,3},
							   {4,5,6},
							   {7,8,9}};
			double[,] expectedArray ={
									{1,4,7},
									{2,5,8},
									{3,6,9}};

			Matrix target = new Matrix(targetArray);
			Matrix transpose = target.Transpose();
			Matrix expected = new Matrix(expectedArray);
			Assert.AreNotEqual(expected, target);
			Assert.AreEqual(expected, transpose);
		}
		[TestMethod()]
		public void TransposeTest4()
		{
			double[,] targetArray ={
									{1,3,5},
									{2,4,6}};
			double[,] expectedArray = {
							   {1,2},
							   {3,4},
							   {5,6}};

			Matrix target = new Matrix(targetArray);
			Matrix transpose = target.Transpose();
			Matrix expected = new Matrix(expectedArray);
			Assert.AreNotEqual(expected, target);
			Assert.AreEqual(expected, transpose);
		}
		[TestMethod()]
		public void MultiplyTest()
		{
			double[,] arrayA = {
							   {1,2},
							   {3,4}};
			double[,] arrayB = {
							   {5,6},
							   {7,8}};
			double[,] arrayExpected = {
							   {19,22},
							   {43,50}};
			Matrix matrixA = new Matrix(arrayA);
			Matrix matrixB = new Matrix(arrayB);
			Matrix matrixExpected = new Matrix(arrayExpected);
			Matrix matrixActual = matrixA.Multiply(matrixB);
			Assert.IsTrue(matrixExpected.Equals(matrixActual));
		}
		[TestMethod()]
		public void MultiplyTest2()
		{
			double[,] arrayA = {
							   {1,2},
							   {3,4}};
			double[,] arrayB = {
							   {5,6},
							   {7,8}};
			double[,] arrayExpected = {
							   {19,22},
							   {43,50}};
			Matrix matrixA = new Matrix(arrayA);
			Matrix matrixB = new Matrix(arrayB);
			Matrix matrixExpected = new Matrix(arrayExpected);
			matrixA.Scaler = 2;
			matrixB.Scaler = 7;
			matrixExpected.Scaler = 2 * 7;
			Matrix matrixActual = matrixA.Multiply(matrixB);
			Assert.IsTrue(matrixExpected.Equals(matrixActual));
		}
		[TestMethod()]
		public void MultiplyTest3()
		{
			double[,] arrayA = {
							   {1,2,3}};
			double[,] arrayB = { { 1 }, { 2 }, { 3 } };
			double[,] arrayExpected = { { 14 } };
			Matrix matrixA = new Matrix(arrayA);
			Matrix matrixB = new Matrix(arrayB);
			Matrix matrixExpected = new Matrix(arrayExpected);
			Matrix matrixActual = matrixA.Multiply(matrixB);
			Assert.IsTrue(matrixExpected.Equals(matrixActual));
		}
		/// <summary>
		/// Can multiply matrices if they don't match correctly
		/// </summary>
		[TestMethod()]
		[ExpectedException(typeof(InvalidOperationException))]
		public void MultiplyTest4()
		{
			double[,] arrayA = { 
							   { 1,1 }, 
							   { 2,2 }, 
							   { 3,3 } };
			double[,] arrayB = {
							   {1,2,3,4}};
			Matrix matrixA = new Matrix(arrayA);
			Matrix matrixB = new Matrix(arrayB);
			Matrix matrixActual = matrixA.Multiply(matrixB);
		}
		[TestMethod()]
		public void MultiplyTest5()
		{
			double[,] arrayA = {
							   { 1,1 }, 
							   { 2,2 }, 
							   { 3,3 } };
			double[,] arrayB = { { 1, 2, 3 }, { 4, 5, 6 } };
			double[,] arrayExpected = { { 5, 7, 9 }, { 10, 14, 18 }, { 15, 21, 27 } };
			Matrix matrixA = new Matrix(arrayA);
			Matrix matrixB = new Matrix(arrayB);
			Matrix matrixExpected = new Matrix(arrayExpected);
			Matrix matrixActual = matrixA.Multiply(matrixB);
			Debug.WriteLine(matrixActual.ToString());
			Assert.IsTrue(matrixExpected.Equals(matrixActual));
		}
		[TestMethod()]
		public void EqualsTest()
		{
			double[,] array1 = {
							   {1,2},
							   {3,4}};
			double[,] sameArray1 = {
							   {1,2},
							   {3,4}};

			double[,] array2 = {
							   {1,2},
							   {3,5}};
			Matrix target = new Matrix(array1);
			Matrix matrix2 = new Matrix(array1);
			Matrix matrix3 = new Matrix(sameArray1);
			Matrix matrix4 = new Matrix(array2);

			Assert.IsTrue(target.Equals(target));
			Assert.IsFalse(target.Equals(null));
			Assert.IsFalse(target.Equals("Hello"));
			Assert.IsTrue(target.Equals(matrix2));
			Assert.IsTrue(target.Equals(matrix3));
			Assert.IsFalse(target.Equals(matrix4));
		}
		[TestMethod()]
		public void EqualsTest2()
		{
			double[,] array1 = {
								   {1,2},
								   {3,4}};
			double[,] array2 = {
								   {2,4},
								   {6,8}};
			Matrix matrix1 = new Matrix(array1, 1);
			Matrix matrix2 = new Matrix(array2, 1);
			Matrix matrix3 = new Matrix(array1, 2);
			Assert.IsFalse(matrix1.Equals(matrix2));
			Assert.IsTrue(matrix2.Equals(matrix3));
		}
		/// <summary>
		///A test for Inverse, check to see if exception is thrown
		///only square matrices can be inverted
		///</summary>
		[TestMethod()]
		[ExpectedException(typeof(InvalidOperationException))]
		public void InverseExTest()
		{
			double[,] array = {
								  {1,2,3},
								  {4,5,6}};
			Matrix matrix = new Matrix(array);
			matrix.Inverse();
		}

		/// <summary>
		///A test for Inverse
		///</summary>
		[TestMethod()]
		public void InverseTest()
		{
			Matrix identityMatrix = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } });
			Matrix matrix = new Matrix(new double[,] { { 1, 3 }, { 2, 4 } });
			Matrix inverse = matrix.Inverse();
			Matrix expected = new Matrix(new double[,] { { 4, -3 }, { -2, 1 } }, -0.5);
			Assert.IsTrue(inverse.Equals(expected));

			Matrix multA = matrix.Multiply(inverse);
			Matrix multB = inverse.Multiply(matrix);
			Assert.IsTrue(multA.Equals(identityMatrix));
			Assert.IsTrue(multB.Equals(identityMatrix));
		}
		[TestMethod()]
		public void InverseTest2()
		{
			Matrix matrix = new Matrix(new double[,] { 
					{ 1, 3, 0 }, 
					{ 0, -2, 1 },
					{-1,0,0}});
			Matrix expected = new Matrix(new double[,] { 
					{ 0, 0, -3 }, 
					{ 1, 0, 1 },
					{2,3,2}}, 1d / 3d);

			Matrix inverse = matrix.Inverse();
			Debug.WriteLine(inverse.ToString());
			Assert.IsTrue(expected.Equals(inverse));
			Matrix mult = matrix.Multiply(inverse);
			Debug.WriteLine(mult.ToString());

		}
		[TestMethod()]
		public void InverseTest3()
		{
			double[,] targetArray = {
							   {1,-3,-2,7,9,1},
							   {0,4,-1,4,55,7},
							   {2,1,0,11,33,44},
							   {3,4,5,6,7,8},
							   {1,2,3,98,65,3},
							   {0,0,33,2,45,67}};
			Matrix target = new Matrix(targetArray);
			Matrix inverse = target.Inverse();
			Matrix expected = new Matrix(new double[,]{
				{1,0,0,0,0,0},
				{0,1,0,0,0,0},
				{0,0,1,0,0,0},
				{0,0,0,1,0,0},
				{0,0,0,0,1,0},
				{0,0,0,0,0,1}});
			Matrix actual = inverse * target;
			Assert.AreEqual(expected, actual);
			actual = target * inverse;
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for Determinant
		///</summary>
		[TestMethod()]
		public void DeterminantTest()
		{
			double[,] targetArray = {
							   {1,-3,-2},
							   {0,4,-1},
							   {2,1,0}};

			Matrix target = new Matrix(targetArray);
			double actual = target.Determinant();
			Assert.AreEqual(23, actual);
		}

		/// <summary>
		///A test for GetMinor
		///</summary>
		[TestMethod()]
		public void GetMinorTest()
		{
			double[,] targetArray = {
							   {1,-3,-2},
							   {0,4,-1},
							   {2,1,0}};
			Matrix target = new Matrix(targetArray);
			int x = 0;
			int y = 0;
			Matrix expected = new Matrix(new double[,]{
				{4,-1},
				{1,0}});
			Matrix actual;
			actual = target.GetMinor(x, y);
			Assert.AreEqual(expected, actual);
			x = 1;
			y = 1;
			expected = new Matrix(new double[,]{
				{1,-2},
				{2,0}});
			actual = target.GetMinor(x, y);
			Assert.AreEqual(expected, actual);
			x = 2;
			y = 0;
			expected = new Matrix(new double[,]{
				{0,4},
				{2,1}});
			actual = target.GetMinor(x, y);
			Assert.AreEqual(expected, actual);
		}
		/// <summary>
		///A test for GetMinor
		///</summary>
		[TestMethod()]
		public void GetMinorTest2()
		{
			double[,] targetArray = {
							   {1,-3,-2,7,9,1},
							   {0,4,-1,4,55,7},
							   {2,1,0,11,33,44},
							   {3,4,5,6,7,8},
							   {1,2,3,98,65,3},
							   {0,0,33,2,45,67}};
			Matrix target = new Matrix(targetArray);
			int x = 0;
			int y = 0;
			Matrix expected = new Matrix(new double[,]{
				{4,-1,4,55,7},
				{1,0,11,33,44},
				{4,5,6,7,8},
				{2,3,98,65,3},
				{0,33,2,45,67}});
			Matrix actual;
			actual = target.GetMinor(x, y);
			Assert.AreEqual(expected, actual);
			x = 3;
			y = 4;
			expected = new Matrix(new double[,]{
							   {1,-3,-2,9,1},
							   {0,4,-1,55,7},
							   {2,1,0,33,44},
							   {3,4,5,7,8},
							   {0,0,33,45,67}});
			actual = target.GetMinor(x, y);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void CoFactorTest()
		{
			double[,] targetArray = {
							   {4,7,0},
							   {0,-1,1},
							   {2,-2,5}};
			Matrix target = new Matrix(targetArray);
			Assert.AreEqual(-3, target.CoFactor(0, 0));
			Assert.AreEqual(2, target.CoFactor(1, 0));
			Assert.AreEqual(2, target.CoFactor(2, 0));
			Assert.AreEqual(-35, target.CoFactor(0, 1));
			Assert.AreEqual(20, target.CoFactor(1, 1));
			Assert.AreEqual(22, target.CoFactor(2, 1));
			Assert.AreEqual(7, target.CoFactor(0, 2));
			Assert.AreEqual(-4, target.CoFactor(1, 2));
			Assert.AreEqual(-4, target.CoFactor(2, 2));
		}
		[TestMethod()]
		public void DeterminantTest2()
		{
			double[,] targetArray = {
							   {4,7,0},
							   {0,-1,1},
							   {2,-2,5}};
			Matrix target = new Matrix(targetArray);
			Assert.AreEqual(2, target.Determinant());

			targetArray = new double[,]{
							   {4,7,0,56,78,12},
							   {4,7,0,56,78,12},
							   {4,7,0,56,78,12},
							   {0,0,0,0,0,0},
							   {4,7,0,56,78,12},
							   {2,-2,51,22,33,3}};
			target = new Matrix(targetArray);
			Assert.AreEqual(0, target.Determinant());
		}
		[TestMethod()]
		public void AdjointTest()
		{
			double[,] targetArray = {
							   {4,7,0},
							   {0,-1,1},
							   {2,-2,5}};
			Matrix target = new Matrix(targetArray);
			Matrix adjoint = new Matrix(new double[,]{
				{-3,-35,7},
				{2,20,-4},
				{2,22,-4}});
			Assert.AreEqual<Matrix>(adjoint, target.Adjoint());
		}
		[TestMethod()]
		public void AddTest()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,2,3},
				{4,5,6},
				{7,8,9}});
			Matrix matrixB = new Matrix(new double[,]{
				{-4,0,2},
				{2,-1,-1},
				{6,-5,2}});
			Matrix result = matrixA + matrixB;
			Matrix expected = new Matrix(new double[,]{
				{-3,2,5},
				{6,4,5},
				{13,3,11}});
			Assert.AreEqual<Matrix>(expected, result);
			result = matrixB + matrixA;
			Assert.AreEqual<Matrix>(expected, result);
		}
		[TestMethod()]
		public void AddTest2()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,2,3},
				{4,5,6},
				{7,8,9}}, 2);
			Matrix matrixB = new Matrix(new double[,]{
				{-4,0,2},
				{2,-1,-1},
				{6,-5,2}}, 3);
			Matrix result = matrixA + matrixB;
			Matrix expected = new Matrix(new double[,]{
				{-10,4,12},
				{14,7,9},
				{32,1,24}});
			Assert.AreEqual<Matrix>(expected, result);
			result = matrixB + matrixA;
			Assert.AreEqual<Matrix>(expected, result);
		}
		[TestMethod()]
		public void SubtractTest()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,2,3},
				{4,5,6},
				{7,8,9}});
			Matrix matrixB = new Matrix(new double[,]{
				{-4,0,2},
				{2,-1,-1},
				{6,-5,2}});
			Matrix result = matrixA - matrixB;
			Matrix expected = new Matrix(new double[,]{
				{5,2,1},
				{2,6,7},
				{1,13,7}});
			Assert.AreEqual<Matrix>(expected, result);
			result = matrixB + matrixA;
			Assert.AreNotEqual<Matrix>(expected, result);
		}
		[TestMethod()]
		public void SubtractTest2()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,2,3},
				{4,5,6},
				{7,8,9}}, 2);
			Matrix matrixB = new Matrix(new double[,]{
				{-4,0,2},
				{2,-1,-1},
				{6,-5,2}}, 3);
			Matrix result = matrixA - matrixB;
			Matrix expected = new Matrix(new double[,]{
				{14,4,0},
				{2,13,15},
				{-4,31,12}});
			Assert.AreEqual<Matrix>(expected, result);
			result = matrixB + matrixA;
			Assert.AreNotEqual<Matrix>(expected, result);
		}

		[TestMethod()]
		public void FactorInScalarTest()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,2,3},
				{4,5,6},
				{7,8,9}}, 2);
			Matrix expected = new Matrix(new double[,]{
				{2,4,6},
				{8,10,12},
				{14,16,18}});
			matrixA.FactorInScalar();
			Assert.AreEqual<Matrix>(expected, matrixA);
			Assert.AreEqual(1, matrixA.Scaler);
		}



		/// <summary>
		///A test for Item
		///</summary>
		[TestMethod()]
		public void ItemTest()
		{
			double[,] targetArray = {
							   {1,-3,-2,7,9,1},
							   {0,4,-1,4,55,7},
							   {2,1,0,11,33,44},
							   {3,4,5,6,7,8},
							   {1,2,3,98,65,3},
							   {0,0,33,2,45,67}};
			Matrix target = new Matrix(targetArray);
			Assert.AreEqual(-3, target[0, 1]);
			Assert.AreEqual(7, target[3, 4]);
			Assert.AreEqual(98, target[4, 3]);
		}

		//
		//Scalar Testing
		//
		[TestMethod()]
		public void MinorScalarTest()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,2,3},
				{4,5,6},
				{7,8,9}}, 10);
			Matrix minorActual = matrixA.GetMinor(0, 0);
			Matrix minorExpected = new Matrix(new double[,]{
				{50,60},
				{80,90}});
			Assert.AreEqual<Matrix>(minorActual, minorExpected);
		}
		[TestMethod()]
		public void DeterminantScalarTest1()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,1},
				{2,3}}, 10);
			Assert.AreEqual(100, matrixA.Determinant());
			matrixA.FactorInScalar();
			Assert.AreEqual(100, matrixA.Determinant());

			matrixA = new Matrix(new double[,]{
				{3,6},
				{8,1}}, 7);
			Assert.AreEqual(-45d * 49d, matrixA.Determinant());
			matrixA.FactorInScalar();
			Assert.AreEqual(-45d * 49d, matrixA.Determinant());
		}

		[TestMethod()]
		public void DeterminantScalarTest2()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,1,3,4},
				{0,5,6,7},
				{4,-5,3,7},
				{7,8,0,10}}, 10);

			double det = matrixA.Determinant();
			matrixA.FactorInScalar();
			double det2 = matrixA.Determinant();

			Assert.AreEqual(det, det2);
		}
		[TestMethod()]
		public void DeterminantScalarTest3()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,1,3},
				{1,0,0},
				{7,8,0}}, 10);

			double det = matrixA.Determinant();
			Assert.AreEqual(24000, det);
			matrixA.FactorInScalar();
			double det2 = matrixA.Determinant();
			Assert.AreEqual(det, det2);
		}
		[TestMethod()]
		public void CoFactorScalarTest()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,1,3},
				{1,-1,0},
				{2,3,0}}, 10);

			double cof = matrixA.CoFactor(0, 2);
			Assert.AreEqual(300, cof);
		}
		[TestMethod()]
		public void CoFactorScalarTest2()
		{
			Matrix matrixA = new Matrix(new double[,]{
							   {1,-3,-2,7,9,1},
							   {0,4,-1,4,55,7},
							   {2,1,0,11,33,44},
							   {3,4,5,6,7,8},
							   {1,2,3,98,65,3},
							   {0,0,33,2,45,67}}, 42);

			double cof = matrixA.CoFactor(3, 3);
			matrixA.FactorInScalar();
			double cof2 = matrixA.CoFactor(3, 3);
			Assert.AreEqual(cof, cof2);
		}
		[TestMethod()]
		public void AdjointScalarTest()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,1,3},
				{1,0,0},
				{7,8,0}}, 10);

			Matrix adjoint1 = matrixA.Adjoint();
			matrixA.FactorInScalar();
			Matrix adjoint2 = matrixA.Adjoint();
			Assert.AreEqual<Matrix>(adjoint1, adjoint2);
		}
		[TestMethod()]
		public void AdjointScalarTest2()
		{
			Matrix matrixA = new Matrix(new double[,]{
							   {1,-3,-2,7,9,1},
							   {0,4,-1,4,55,7},
							   {2,1,0,11,33,44},
							   {3,4,5,6,7,8},
							   {1,2,3,98,65,3},
							   {0,0,33,2,45,67}}, 42);

			Matrix adjoint1 = matrixA.Adjoint();
			matrixA.FactorInScalar();
			Matrix adjoint2 = matrixA.Adjoint();
			Assert.AreEqual<Matrix>(adjoint1, adjoint2);
		}
		[TestMethod()]
		public void InverseScalarTest()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,1,3},
				{1,0,0},
				{7,8,0}}, 10);
			Matrix inverse1 = matrixA.Inverse();
			matrixA.FactorInScalar();
			Matrix inverse2 = matrixA.Inverse();
			Assert.AreEqual<Matrix>(inverse1, inverse2);
		}
		[TestMethod()]
		public void InverseScalarTest2()
		{
			Matrix matrixA = new Matrix(new double[,]{
							   {1,-3,-2,7,9,1},
							   {0,4,-1,4,55,7},
							   {2,1,0,11,33,44},
							   {3,4,5,6,7,8},
							   {1,2,3,98,65,3},
							   {0,0,33,2,45,67}}, 42);
			Matrix inverse1 = matrixA.Inverse();
			matrixA.FactorInScalar();
			Matrix inverse2 = matrixA.Inverse();
			Assert.AreEqual(inverse1, inverse2);
			Matrix actual = inverse2 * matrixA;
			Matrix expected = new Matrix(new double[,]{
				{1,0,0,0,0,0},
				{0,1,0,0,0,0},
				{0,0,1,0,0,0},
				{0,0,0,1,0,0},
				{0,0,0,0,1,0},
				{0,0,0,0,0,1}});
			Assert.AreEqual<Matrix>(expected, actual);
		}

		//
		// Matrix mathematical properties
		//

		/// <summary>
		///  Det (A) = Det (transpose(A))
		/// </summary>
		[TestMethod()]
		public void propertyA1()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,1},
				{2,3}}, 10);

			double det = matrixA.Determinant();
			Matrix transpose = matrixA.Transpose();
			double detT = transpose.Determinant();
			Assert.AreEqual(det, detT);
		}
		[TestMethod()]
		public void propertyA2()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,3,0},
				{0,-2,1},
				{-1,0,0}}, -2);

			double det = matrixA.Determinant();
			Matrix transpose = matrixA.Transpose();
			double detT = transpose.Determinant();
			Assert.AreEqual(det, detT);
		}
		[TestMethod()]
		public void propertyA3()
		{
			Matrix matrixA = new Matrix(new double[,]{
							   {1,-3,-2,7,9,1},
							   {0,4,-1,4,55,7},
							   {2,1,0,11,33,44},
							   {3,4,5,6,7,8},
							   {1,2,3,98,65,3},
							   {0,0,33,2,45,67}}, 42);

			double det = matrixA.Determinant();
			Matrix transpose = matrixA.Transpose();
			double detT = transpose.Determinant();
			Assert.AreEqual(det, detT);
		}
		/// <summary>
		///  Matrices are non-commutative:
		///		AB != BA
		///		
		/// However they are associative and distributive
		///		(AB)C = A(BC)
		///		(A+B)C = AC+BC
		/// </summary>
		[TestMethod()]
		public void propertyB1()
		{
			Matrix matrixA = new Matrix(new double[,]{
				{1,3,0},
				{4,-2,1},
				{-1,3,0}}, -2);
			Matrix matrixB = new Matrix(new double[,]{
				{1,-3,5},
				{0,2,1},
				{-1,0,1}}, -7);
			Matrix matrixC = new Matrix(new double[,]{
				{1,3,8},
				{-2,-2,1},
				{-2,1,0}});

			Assert.AreNotEqual<Matrix>(matrixA * matrixB, matrixB * matrixA);
			Assert.AreEqual<Matrix>((matrixA * matrixB) * matrixC, matrixA * (matrixB * matrixC));
			Assert.AreEqual<Matrix>((matrixA + matrixB) * matrixC, matrixA * matrixC + matrixB * matrixC);
		}


	}
}
