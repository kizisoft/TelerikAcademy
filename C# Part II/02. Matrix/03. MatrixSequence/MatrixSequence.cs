// We are given a matrix of strings of size N x M. Sequences in the matrix we
// define as sets of several neighbor elements located on the same line, column
// or diagonal. Write a program that finds the longest sequence of equal strings
// in the matrix. 
/* Example:
6
4
ha fi ho HI hi hi
fo ha HI xx fi ho
xx HI ha xx fi ho
HI xx ha xx hi fi
*/

using System;
using System.Collections.Generic;

class MatrixSequence
{
    static void Main()
    {
        // Input matrix dimention
        Console.Write("Input matrix dimention N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Input matrix dimention M: ");
        int m = int.Parse(Console.ReadLine());

        // Declare a rectangular matrix N x M
        string[,] myMatrix = new string[n, m];

        // Input matrix N x M
        Console.WriteLine("Input {0} lines of {1} numbers delimited by Space: ", m, n);
        for (int i = 0; i < m; i++)
        {
            Console.Write("Line {0}: ", i);
            string[] strIn = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int ii = 0; ii < n; ii++)
            {
                myMatrix[ii, i] = strIn[ii];
            }
        }
        Console.WriteLine();

        // Here we store the longest sequence in format (col, row)
        List<Tuple<int, int>> bestSequence = new List<Tuple<int, int>>();

        // Find largest sequence
        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                // Horizontal search
                List<Tuple<int, int>> tmp = FindSequence("H", col, row, n, m, myMatrix);
                if (bestSequence.Count < tmp.Count) { bestSequence = tmp; }

                // Vertical  search
                tmp = FindSequence("V", col, row, n, m, myMatrix);
                if (bestSequence.Count < tmp.Count) { bestSequence = tmp; }

                // Right diagonal search
                tmp = FindSequence("DR", col, row, n, m, myMatrix);
                if (bestSequence.Count < tmp.Count) { bestSequence = tmp; }

                // Left diagonal search
                tmp = FindSequence("DL", col, row, n, m, myMatrix);
                if (bestSequence.Count < tmp.Count) { bestSequence = tmp; }
            }
        }

        // Print results
        Console.WriteLine("Best sequence elements position (x, y):");
        foreach (var item in bestSequence)
        {
            Console.Write(" ({0}, {1}) = {2} ", item.Item1, item.Item2, myMatrix[item.Item1, item.Item2]);
        }
        Console.WriteLine();
    }

    // Return curently biggest sequence
    private static List<Tuple<int, int>> FindSequence(string dir, int col, int row, int n, int m, string[,] myMatrix)
    {
        string tmpElement = myMatrix[col, row];
        List<Tuple<int, int>> res = new List<Tuple<int, int>>();
        res.Add(new Tuple<int, int>(col, row));

        switch (dir)
        {
            case "H":   // Horizontal
                for (int i = col + 1; i < n; i++)
                {
                    if (myMatrix[i, row] != tmpElement) { break; }
                    res.Add(new Tuple<int, int>(i, row));
                }
                break;

            case "V":   // Vertical
                for (int i = row + 1; i < m; i++)
                {
                    if (myMatrix[col, i] != tmpElement) { break; }
                    res.Add(new Tuple<int, int>(col, i));
                }
                break;

            case "DR":  // Right diagonal
                for (int i = 1; (row + i < m) && (col + i < n); i++)
                {
                    if (myMatrix[col + i, row + i] != tmpElement) { break; }
                    res.Add(new Tuple<int, int>(col + i, row + i));
                }
                break;

            case "DL":  // Left diagonal
                for (int i = 1; (row + i < m) && (col - i >= 0); i++)
                {
                    if (myMatrix[col - i, row + i] != tmpElement) { break; }
                    res.Add(new Tuple<int, int>(col - i, row + i));
                }
                break;
        }

        return res;
    }
}