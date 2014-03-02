// 8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
//
// 9. Implement an indexer this[row, col] to access the inner matrix cells.
//
// 10. Implement the operators + and - (addition and subtraction of matrices of the same size)
//     and * for matrix multiplication. Throw an exception when the operation cannot be
//     performed. Implement the true operator (check for non-zero elements).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Matrix
{
    public class Matrix<T>
    {
        // Store a 2 dimension matrix of T
        private T[,] matrix;

        // Create property to return matrix rows and cols length
        public int Rows { get { return this.matrix.GetLength(0); } }
        public int Cols { get { return this.matrix.GetLength(0); } }

        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
        }

        // Constructor to create matrix
        public Matrix(T[,] matrix)
            : this(matrix.GetLength(0), matrix.GetLength(1))
        {
            for (int rows = 0; rows < this.Rows; rows++)
            {
                for (int cols = 0; cols < this.Cols; cols++)
                {
                    this.matrix[rows, cols] = matrix[rows, cols];
                }
            }
        }

        // Declare indexer for the Matrix class
        public T this[int row, int col]
        {
            get { return this.matrix[row, col]; }
            set { this.matrix[row, col] = value; }
        }

        // Predefine operator "*" to work for Matrix class
        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            // Check if it is possible to multiply
            if (matrix1.Cols != matrix2.Rows)
            {
                throw new FormatException("Matrices cannot be multiplied!");
            }

            // Create a temporaly matrix to return as result
            Matrix<T> res = new Matrix<T>(matrix1.Rows, matrix2.Cols);

            for (int row = 0; row < matrix1.Rows; row++)
            {
                for (int col = 0; col < matrix2.Cols; col++)
                {
                    T tmp = default(T);

                    // Multiply col by row
                    for (int i = 0; i < matrix1.Cols; i++)
                    {
                        try
                        {
                            tmp += (dynamic)matrix1[row, i] * matrix2[i, col];
                        }
                        catch (Exception)
                        {
                            throw new ArithmeticException("One or more element of the matrices is not a number!");
                        }
                    }

                    // Store the result into the result matrix
                    res[row, col] = tmp;
                }
            }

            // Return the result
            return res;
        }

        // Predefine operator "+" to work for Matrix class
        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            // Call a method to sum
            return Sum(1, matrix1, matrix2);
        }

        // Predefine operator "-" to work for Matrix class
        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            // Call a method to subtract
            return Sum(-1, matrix1, matrix2);
        }

        // Sum or subtract matrices
        private static Matrix<T> Sum(int sign, Matrix<T> matrix1, Matrix<T> matrix2)
        {
            // Check if matrices has same dimentions
            if ((matrix1.Rows != matrix2.Rows) || (matrix1.Cols != matrix2.Cols))
            {
                throw new FormatException("Matrices has a different dimentions!");
            }

            // Create a temporaly matrix to return as result
            Matrix<T> res = new Matrix<T>(matrix1.Rows, matrix1.Cols);

            for (int row = 0; row < matrix1.Rows; row++)
            {
                for (int col = 0; col < matrix1.Cols; col++)
                {
                    try
                    {
                        // Check to sum or to subtract
                        if (sign < 0)
                        {
                            res[row, col] = (dynamic)matrix1[row, col] - matrix2[row, col];
                        }
                        else
                        {
                            res[row, col] = (dynamic)matrix1[row, col] + matrix2[row, col];
                        }
                    }
                    catch (Exception)
                    {
                        throw new ArithmeticException("One or more element of the matrices is not a number!");
                    }
                }
            }

            // Return the result
            return res;
        }

        // Predefine operator true
        public static bool operator true(Matrix<T> matrix)
        {
            for (int rows = 0; rows < matrix.Rows; rows++)
            {
                for (int cols = 0; cols < matrix.Cols; cols++)
                {
                    try
                    {
                        if ((dynamic)matrix[rows, cols] == 0)
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        throw new ArithmeticException("One or more element of the matrices is not a number!");
                    }
                }
            }

            return true;
        }

        // Predefine operator false
        public static bool operator false(Matrix<T> matrix)
        {
            for (int rows = 0; rows < matrix.Rows; rows++)
            {
                for (int cols = 0; cols < matrix.Cols; cols++)
                {
                    try
                    {
                        if ((dynamic)matrix[rows, cols] == 0)
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        throw new ArithmeticException("One or more element of the matrices is not a number!");
                    }
                }
            }

            return true;
        }

        // Override ToString() to return Matrix as string
        public override string ToString()
        {
            // Declare string result
            string res = null;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    // Add next matrix element to the string
                    res += string.Format("{0,5}", this[row, col]);
                }

                // Add symbol for new line to the string
                if (row < this.Rows - 1)
                {
                    res += Environment.NewLine;
                }
            }

            // Return the result
            return res;
        }
    }
}