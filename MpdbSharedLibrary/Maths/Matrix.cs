using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Maths
{
	/// <summary>
	/// The matrix has you
	/// 
	/// The matrix wraps a rectangular double array, double[,] and a scalar quantity that multiplies each element.
	/// 
	/// Rectangular array notes:
	/// 
	/// double[,] matrix = {
	///							{1,2,3},
	///							{3,4,5}};
	///							
	/// The matrix has 2 rows and 3 columns, corresponding to double[2,3].
	/// 
	/// </summary>
	public class Matrix
	{
		//array containing the matrix elements
		double[,] matrix;
		//scalar that multiplies the matrix
		double scalar;

		/// <summary>
		/// Gets the number of columns in the matrix
		/// </summary>
		public int Columns
		{
			get { return matrix.GetLength(1); }
		}
		/// <summary>
		/// Gets the number of rows in the matrix
		/// </summary>
		public int Rows
		{
			get { return matrix.GetLength(0); }
		}
		public double Scaler
		{
			get { return scalar; }
			set { scalar = value; }
		}
		public Matrix(double[,] matrix) : this(matrix, 1) { }
		public Matrix(double[,] matrix, double scalar)
		{
			this.matrix = matrix;
			this.scalar = scalar;
		}
		/// <summary>
		/// Gets/Sets the element at the specified row and column
		/// Note the scalar is ignored during this operation, so you will have to multiply
		/// by the scalar if you want it actual value;
		/// 
		/// (C# note - this property is called an indexer)
		/// </summary>
		/// <param name="row">Row of the element, first row is 0</param>
		/// <param name="column">Column of the element, first column is 0</param>
		/// <returns>Element at the specified row and column</returns>
		public double this[int row, int column]
		{
			get { return matrix[row, column]; }
			set { matrix[row, column] = value; }
		}
		/// <summary>
		/// Multiplies two matrices together
		/// </summary>
		/// <param name="matrixA">Left hand matrix</param>
		/// <param name="matrixB">Right hand matrix</param>
		/// <returns>Resultant matrix</returns>
		public static Matrix operator *(Matrix matrixA, Matrix matrixB)
		{
			return matrixA.Multiply(matrixB);
		}
		public static Matrix operator +(Matrix matrixA, Matrix matrixB)
		{
			return matrixA.Add(matrixB);
		}
		public static Matrix operator -(Matrix matrixA, Matrix matrixB)
		{
			return matrixA.Subtract(matrixB);
		}
		public override string ToString()
		{
			StringBuilder sbuff = new StringBuilder();

			int cols = matrix.GetLength(1);
			int rows = matrix.GetLength(0);
			for (int y = 0; y < rows; y++)
			{
				for (int x = 0; x < cols; x++)
				{
					sbuff.Append(matrix[y, x].ToString());
					sbuff.Append(" ");
				}
				sbuff.Append("\r\n");
			}
			sbuff.Append("Scalar is ");
			sbuff.Append(scalar.ToString());
			sbuff.Append("\r\n");
			return sbuff.ToString();
		}
		public override bool Equals(object obj)
		{
			//quick check to see if same object
			if (base.Equals(obj))
			{
				return true;
			}
			//basic checks on null and type
			if (obj == null || !(obj is Matrix))
			{
				return false;
			}
			//We know the object is a matrix 
			Matrix mB = (Matrix)obj;
			//check rank of the matrix
			if (this.Columns != mB.Columns || this.Rows != this.Rows)
			{
				return false;
			}

			//check each element is the same
			for (int y = 0; y < this.Rows; y++)
			{
				for (int x = 0; x < this.Columns; x++)
				{
					double element1 = matrix[y, x] * scalar;
					double element2 = mB.matrix[y, x] * mB.scalar;
					if (element1 != element2)
					{
						return false;
					}
				}
			}
			//must be the same
			return true;
		}
		public override int GetHashCode()
		{
			//ToString pretty much describes the matrix, and string has a pretty good hashcode generator
			return this.ToString().GetHashCode();
		}
		/// <summary>
		/// Transpose the rows into columns
		/// </summary>
		/// <returns>New matrix that is the transpose of this</returns>
		public Matrix Transpose()
		{
			double[,] transpose = new double[Columns, Rows];
			for (int y = 0; y < Rows; y++)
			{
				for (int x = 0; x < Columns; x++)
				{
					transpose[x, y] = matrix[y, x];
				}
			}
			return new Matrix(transpose, scalar);
		}
		/// <summary>
		/// Adds the two matrices together
		/// Result = A + B = B + A 
		/// </summary>
		/// <param name="matrixB">Specified matrix to add to this one</param>
		/// <returns>Result</returns>
		public Matrix Add(Matrix matrixB)
		{
			if (matrixB.Columns != this.Columns || matrixB.Rows != this.Rows)
			{
				throw new InvalidOperationException("Matrices can only be added when both matrices have the same number columns and rows");
			}
			double[,] result = new double[this.Rows, this.Columns];
			//row
			for (int y = 0; y < Rows; y++)
			{
				//column
				for (int x = 0; x < Columns; x++)
				{
					result[y, x] = matrix[y, x] * scalar + matrixB.matrix[y, x] * matrixB.scalar;
				}
			}
			return new Matrix(result);
		}
		/// <summary>
		/// Subtracts the specified matrix from this matrix:
		/// Result = A - B
		/// </summary>
		/// <param name="matrixB">Matrix B</param>
		/// <returns>Result</returns>
		public Matrix Subtract(Matrix matrixB)
		{
			if (matrixB.Columns != this.Columns || matrixB.Rows != this.Rows)
			{
				throw new InvalidOperationException("Matrices can only be subtracted when both matrices have the same number columns and rows");
			}
			double[,] result = new double[this.Rows, this.Columns];
			//row
			for (int y = 0; y < Rows; y++)
			{
				//column
				for (int x = 0; x < Columns; x++)
				{
					result[y, x] = matrix[y, x] * scalar - matrixB.matrix[y, x] * matrixB.scalar;
				}
			}
			return new Matrix(result);
		}
		/// <summary>
		/// Multiplies each element by the scalar and then resets the scalar to 1;
		/// </summary>
		public void FactorInScalar()
		{
			//row
			for (int y = 0; y < Rows; y++)
			{
				//column
				for (int x = 0; x < Columns; x++)
				{
					//multiply the element by the scalar
					matrix[y, x] = matrix[y, x] * scalar;
				}
			}
			//reset scalar
			scalar = 1d;
		}
		/// <summary>
		/// Multiplies this matrix (matrix A) with input matrix B and returns the result matrix, C:
		///  AB = C;
		///  
		/// Note that matrix multiplication is not commmutative, eg
		/// AB does not equal BA
		/// </summary>
		/// <exception cref="InvalidOperationException">Matrices can only be multiplied when the columns of matrix A is the same as rows of matrix B</exception>
		/// <param name="matrixB">Right hand sidde matrix of the multiplication</param>
		/// <returns>Returns result matrix, C</returns>
		public Matrix Multiply(Matrix matrixB)
		{
			int colsA = Columns;
			int rowsA = Rows;
			int colsB = matrixB.Columns;
			int rowsB = matrixB.Rows;

			//check matrices can be multiplied
			if (colsA != rowsB)
			{
				throw new InvalidOperationException("Matrices can only be multiplied when the columns of matrix A is the same as rows of matrix B");
			}
			double[,] result = new double[rowsA, colsB];

			//row
			for (int y = 0; y < rowsA; y++)
			{
				//column
				for (int x = 0; x < colsB; x++)
				{
					//multiply the row(y) of matrix A with column(x) of matrix B
					double total = 0;
					for (int i = 0; i < colsA; i++)
					{
						total += (matrix[y, i] * matrixB.matrix[i, x]);
					}
					result[y, x] = total;
				}
			}
			//scalars are multiplied in the usual way
			double resultScalar = this.scalar * matrixB.scalar;
			return new Matrix(result, resultScalar);
		}
		/// <summary>
		/// Calculates the inverse of the matrix 
		/// A' A = A' A = I, where A' is the inverse
		/// 
		/// The inverse matrix of A, is defined as the Adjoint of A divided by the determinant of A
		/// </summary>
		/// <exception cref="InvalidOperationException">Matrix must have the same number of rows and columns for the inverse matrix to be calculated</exception>
		/// <returns>Inverse matrix</returns>
		public Matrix Inverse()
		{
			if (Columns != Rows)
			{
				throw new InvalidOperationException("Matrix must have the same number of rows and columns for the inverse matrix to be calculated");
			}
			Matrix invMatrix = null;
			if (Rows == 2)
			{
				//( a b ) -1      __1_  (d -b)
				//( c d )     =	ad-bc	 (-c a)
				double[,] inverse = new double[Columns, Rows];
				double det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
				inverse[0, 0] = matrix[1, 1];
				inverse[1, 1] = matrix[0, 0];
				inverse[0, 1] = -matrix[0, 1];
				inverse[1, 0] = -matrix[1, 0];
				invMatrix = new Matrix(inverse);
				invMatrix.Scaler = 1 / (scalar * det);
			}
			else
			{
				// The inverse matrix of A, is defined as the Adjoint of A divided by the determinant of A
				invMatrix = Adjoint();
				invMatrix.scalar = 1 / Determinant();
			}
			return invMatrix;
		}

		/// <summary>
		/// Uses the Laplace expansion to recursively compute the determinant, eg
		/// | a b c |
		/// | d e f | = a. |e f|  - b.|d f| + c.|d e|
		/// | g h i |        |h i|       |g i|       |g h|
		/// 
		/// </summary>
		/// <returns>Determinant of the matrix</returns>
		public double Determinant()
		{
			if (Columns != Rows)
			{
				throw new InvalidOperationException("Matrix must have the same number of rows and columns for the determinant of the matrix to be calculated");
			}
			//need to apply the scalar

			return determinant(matrix);
		}
		/// <summary>
		/// The minor is the matrix that remains when the row and column containing the specified
		/// cell are removed.
		/// </summary>
		/// <param name="col">column number (starting at 0)</param>
		/// <param name="row">row number (starting at 0)</param>
		/// <returns>The minor matrix</returns>
		public Matrix GetMinor(int col, int row)
		{
			if (Columns != Rows)
			{
				throw new InvalidOperationException("Matrix must have the same number of rows and columns for the minor to be calculated");
			}
			double[,] array = getMinor(matrix, col, row);
			return new Matrix(array, this.scalar);
		}
		/// <summary>
		/// The co-factor is the determinant of the matrix that remains when the row and column containing the
		/// specified element is removed. The co-factor may also be multiplied by -1, depending on the element's position:
		/// + - + -
		/// - + - +
		/// + - + -
		/// </summary>
		/// <param name="col">column number (starting at 0)</param>
		/// <param name="row">row number (starting at 0)</param>
		/// <returns>The cofactor of the specified element</returns>
		public double CoFactor(int col, int row)
		{
			if (Columns != Rows)
			{
				throw new InvalidOperationException("Matrix must have the same number of rows and columns for the co-factor to be calculated");
			}
			double[,] array = getMinor(matrix, col, row);
			double cofactor = determinant(array);
			//need to work out sign:
			int i = col - row;
			if ((i % 2) != 0)
			{
				cofactor = -cofactor;
			}
			return cofactor;
		}
		/// <summary>
		/// The adjoint of a matrix is defined as the transpose of the matrix of its co-factors
		/// </summary>
		/// <returns>The adjoint of the matrix</returns>
		public Matrix Adjoint()
		{
			if (Columns != Rows)
			{
				throw new InvalidOperationException("Matrix must have the same number of rows and columns for the adjoint to be calculated");
			}
			//create array to hold the adjoint elements
			double[,] tmpArray = new double[Columns, Rows];
			int length = matrix.GetLength(0);

			for (int y = 0; y < length; y++)
			{
				for (int x = 0; x < length; x++)
				{
					tmpArray[y, x] = CoFactor(x, y);
				}
			}
			//ignore the scalar, as the CoFactor() will take of that
			Matrix adjoint = new Matrix(tmpArray);
			return adjoint.Transpose();
		}
		/// <summary>
		/// Optimized version of Determinant, that only uses double[,]
		/// See Determinant()
		/// </summary>
		/// <param name="array">Matrix array to compute</param>
		/// <returns>Determinant of the matrix</returns>
		private double determinant(double[,] array)
		{
			int length = array.GetLength(0);
			if (length == 2)
			{
				return (array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0]) * scalar * scalar;
			}
			double det = 0;
			//get minors and recurse down
			for (int i = 0; i < length; i++)
			{
				//get the minor
				double[,] minor = getMinor(array, i, 0);
				//find correct sign
				if (i % 2 == 0)
				{
					det += determinant(minor) * array[0, i] * scalar;
				}
				else
				{
					det -= determinant(minor) * array[0, i] * scalar;
				}
			}
			return det;
		}

		private double[,] getMinor(double[,] array, int xPos, int yPos)
		{
			int length = array.GetLength(0);
			//get the minor
			double[,] minor = new double[length - 1, length - 1];
			int mY = 0;
			for (int y = 0; y < length; y++)
			{
				if (y == yPos)
				{
					//skip this one
					continue;
				}
				int mX = 0;
				for (int x = 0; x < length; x++)
				{
					if (x == xPos)
					{
						//skip this one
						continue;
					}
					minor[mY, mX] = array[y, x];
					mX++;
				}
				mY++;
			}
			return minor;
		}
	}
}
