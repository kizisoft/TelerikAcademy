// Write a program that reads a rectangular matrix of size N x M and finds
// in it the square 3 x 3 that has maximal sum of its elements.

using System;

class MaxSubMatrixSumSequence
{
    static void Main()
    {
        // Input matrix dimention
        Console.Write("Input matrix dimention N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Input matrix dimention M: ");
        int m = int.Parse(Console.ReadLine());

        // Declare a rectangular matrix N x M
        int[,] myMatrix = new int[n, m];

        // Input matrix N x M
        Console.WriteLine("Input {0} lines of {1} numbers delimited by Space: ", m, n);
        for (int i = 0; i < m; i++)
        {
            Console.Write("Line {0}: ", i);
            string[] strIn = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int ii = 0; ii < n; ii++)
            {
                myMatrix[ii, i] = int.Parse(strIn[ii]);
            }
        }

        // Print inputed matrix
        Console.WriteLine();
        Console.WriteLine("Inputed matrix:");
        Print(0, 0, n, m, myMatrix);

        int maxSum = int.MinValue;
        int maxSumPosX = 0;
        int maxSumPosY = 0;

        // Calculate maximal sum of submatrix 3x3
        for (int row = 0; row < m - 3; row++)
        {
            for (int col = 0; col < n - 3; col++)
            {
                int currentSum = CalcSum(row, col, myMatrix);

                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                    maxSumPosX = col;
                    maxSumPosY = row;
                }
            }
        }

        // Print the result
        Console.WriteLine();
        Console.WriteLine("Maximal sum of a matrix 3x3 = {0}", maxSum);
        Print(maxSumPosX, maxSumPosY, 3, 3, myMatrix);
    }

    // Calculate and return current sum of the matrix elements
    private static int CalcSum(int row, int col, int[,] myMatrix)
    {
        int currentSum = 0;

        for (int y = row; y < row + 3; y++)
        {
            for (int x = col; x < col + 3; x++)
            {
                currentSum += myMatrix[x, y];
            }
        }
        return currentSum;
    }

    // Print the matrix
    private static void Print(int x, int y, int n, int m, int[,] myMatrix)
    {
        for (int row = y; row < y + m; row++)
        {
            for (int col = x; col < x + n; col++)
            {
                Console.Write("{0,5}", myMatrix[col, row]);
            }
            Console.WriteLine();
        }
    }
}