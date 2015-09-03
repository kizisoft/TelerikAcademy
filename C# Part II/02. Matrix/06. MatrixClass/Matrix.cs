using System;
using System.Collections;

class Matrix
{
    // Store a matrix in private integer array
    private int[,] matrix;

    // Create property to return matrix rows length
    public int Rows { get { return matrix.GetLength(0); } }

    // Create property to return matrix columns length
    public int Cols { get { return matrix.GetLength(1); } }

    // Declare indexer for the Matrix class
    public int this[int row, int col]
    {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
    }

    // Constructor - create new int matrix
    public Matrix(int row, int col)
    {
        matrix = new int[row, col];
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
            res += Environment.NewLine;
        }

        // Return the result
        return res;
    }

    // Predefine operator "*" to work for Matrix class
    public static Matrix operator *(Matrix matrix1, Matrix matrix2)
    {
        // Check if it is possible to multiply
        if (matrix1.Cols != matrix2.Rows)
        {
            return null;
        }

        // Create a temporaly matrix to return as result
        Matrix res = new Matrix(matrix1.Rows, matrix2.Cols);

        for (int row = 0; row < matrix1.Rows; row++)
        {
            for (int col = 0; col < matrix2.Cols; col++)
            {
                int tmp = 0;

                // Multiply col by row
                for (int i = 0; i < matrix1.Cols; i++)
                {
                    tmp += matrix1[row, i] * matrix2[i, col];
                }

                // Store the result into the result matrix
                res[row, col] = tmp;
            }
        }

        // Return the result
        return res;
    }

    // Predefine operator "+" to work for Matrix class
    public static Matrix operator +(Matrix matrix1, Matrix matrix2)
    {
        // Call a method to sum
        return Sum(1, matrix1, matrix2);
    }

    // Predefine operator "-" to work for Matrix class
    public static Matrix operator -(Matrix matrix1, Matrix matrix2)
    {
        // Call a method to subtract
        return Sum(-1, matrix1, matrix2);
    }

    // Sum or subtract matrices
    private static Matrix Sum(int sign, Matrix matrix1, Matrix matrix2)
    {
        // Check if matrices has same dimentions
        if ((matrix1.Rows != matrix2.Rows) || (matrix1.Cols != matrix2.Cols))
        {
            return null;
        }

        // Create a temporaly matrix to return as result
        Matrix res = new Matrix(matrix1.Rows, matrix1.Cols);

        for (int row = 0; row < matrix1.Rows; row++)
        {
            for (int col = 0; col < matrix1.Cols; col++)
            {
                // Check to sum or to subtract
                if (sign < 0)
                {
                    res[row, col] = matrix1[row, col] - matrix2[row, col];
                }
                else
                {
                    res[row, col] = matrix1[row, col] + matrix2[row, col];
                }
            }
        }

        // Return the result
        return res;
    }
}