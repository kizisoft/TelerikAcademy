// * Write a class Matrix, to holds a matrix of integers. Overload the
// operators for adding, subtracting and multiplying of matrices, indexer
// for accessing the matrix content and ToString().

using System;

class MatrixClass
{
    static void Main()
    {
        // This code test a new Matrix class

        #region Multiplay

        Console.WriteLine("-------------------- Multyplay --------------------");
        // Matrix 4x3
        Matrix matrix1 = new Matrix(4, 3);
        EnterMatrix(matrix1, new int[,] { { -1, 3, 5 }, { 2, 0, 0 }, { 1, 2, 3 }, { -4, 3, -2 } });
        Console.WriteLine("Matrix #1:");
        Console.WriteLine(matrix1);

        // Matrix 3x5
        Matrix matrix2 = new Matrix(3, 5);
        EnterMatrix(matrix2, new int[,] { { 8, 2, -1, 3, 5 }, { 2, 2, 1, 5, 0 }, { -2, 1, 4, 2, 3 } });
        Console.WriteLine("Matrix #2:");
        Console.WriteLine(matrix2);

        // Matrix #1 * Matrix #2
        Matrix matrix3 = matrix1 * matrix2;
        Console.WriteLine("Matrix #3 = Matrix #1 * Matrix #2");
        Console.WriteLine(matrix3);

        // Matrix #2 * Matrix #1
        matrix3 = matrix2 * matrix1;
        Console.WriteLine("Matrix #3 = Matrix #2 * Matrix #1");
        Console.WriteLine(matrix3);

        #endregion Multiplay

        #region Sum and Subtract

        Console.WriteLine("---------------- Sum and Subtract -----------------");

        // Matrix 4x3
        matrix1 = new Matrix(4, 3);
        EnterMatrix(matrix1, new int[,] { { -1, 3, 5 }, { 2, 0, 0 }, { 1, 2, 3 }, { -4, 3, -2 } });
        Console.WriteLine("Matrix #1:");
        Console.WriteLine(matrix1);

        // Matrix 4x3
        matrix2 = new Matrix(4, 3);
        EnterMatrix(matrix2, new int[,] { { 4, -1, 1 }, { 3, 1, -1 }, { 3, -1, 3 }, { -2, 1, -5 } });
        Console.WriteLine("Matrix #2:");
        Console.WriteLine(matrix2);

        // Matrix #1 + Matrix #2
        matrix3 = new Matrix(4, 3);
        matrix3 = matrix1 + matrix2;
        Console.WriteLine("Matrix #3 = Matrix #1 + Matrix #2");
        Console.WriteLine(matrix3);

        // Matrix #2 - Matrix #1
        matrix3 = new Matrix(4, 3);
        matrix3 = matrix2 - matrix1;
        Console.WriteLine("Matrix #3 = Matrix #2 - Matrix #1");
        Console.WriteLine(matrix3);

        #endregion Sum and Subtract
    }

    // Enter a data to the matrix. Matrix must implement IEnumerable and IEnumerable<T>
    // to be abe to set data at all. So set the data element by element.
    static void EnterMatrix(Matrix m, int[,] a)
    {
        for (int row = 0; row < m.Rows; row++)
        {
            for (int col = 0; col < m.Cols; col++)
            {
                m[row, col] = a[row, col];
            }
        }
    }
}