// *Write a program that finds the largest area of equal neighbor elements in a
// rectangular matrix and prints its size. 
//
// Example:
/*
5
6
1 3 2 2 2 4
3 3 3 2 4 4
4 3 1 2 3 3
4 3 1 3 3 1
4 3 3 3 1 1

*/
//
// Hint: you can use the algorithm "Depth-first search" or "Breadth-first search" (find them in Wikipedia).

using System;
using System.Collections.Generic;

class EqualNeighborElements
{
    // Create tow static matrix, one for the field and one to check already visited elements
    static string[,] myMatrix;
    static bool[,] visited;

    static void Main()
    {
        // Input matrix dimention
        Console.Write("Input matrix rows number: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Input matrix columns number: ");
        int cols = int.Parse(Console.ReadLine());

        // Initialize a rectangular matrix N x M
        myMatrix = new string[rows, cols];
        visited = new bool[rows, cols];

        // Input matrix N x M
        Console.WriteLine("Input {0} lines of {1} numbers delimited by Space: ", rows, cols);
        for (int i = 0; i < rows; i++)
        {
            Console.Write("Line {0}: ", i);
            string[] strIn = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int ii = 0; ii < cols; ii++)
            {
                myMatrix[i, ii] = strIn[ii];
            }
        }
        Console.WriteLine();

        // Create new list of pair elements to store coordinates of curently biggest field
        List<Tuple<int, int>> currentBiggest = new List<Tuple<int, int>>();

        // Loop for all the elements of the matrix
        for (int row = 0; row < myMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < myMatrix.GetLength(1); col++)
            {
                // Call a recursive method to return curent biggest field
                List<Tuple<int, int>> tmp = SearchPath(row, col, myMatrix[row, col], new List<Tuple<int, int>>());

                // If curent biggest field is smaller then temporaly created, then swap lists
                if (tmp.Count > currentBiggest.Count)
                {
                    currentBiggest = tmp;
                }
            }
        }

        // Print the results
        for (int row = 0; row < myMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < myMatrix.GetLength(1); col++)
            {
                Console.BackgroundColor = ConsoleColor.Black;

                // Change background color if it is a field element
                if (currentBiggest.IndexOf(new Tuple<int, int>(row, col)) >= 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }

                Console.Write("{0,5}", myMatrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    // Recursive method to search for neighbor elements
    private static List<Tuple<int, int>> SearchPath(int row, int col, string element, List<Tuple<int, int>> newList)
    {
        // Check end of recursion
        if ((row < 0) || (col < 0) || (row == myMatrix.GetLength(0)) || (col == myMatrix.GetLength(1)) || (myMatrix[row, col] != element) || visited[row, col])
        {
            return newList;
        }

        // Mark the element as visited
        visited[row, col] = true;

        // Add the curent element to the field list
        newList.Add(new Tuple<int, int>(row, col));

        SearchPath(row, col + 1, element, newList);     // Search right
        SearchPath(row + 1, col, element, newList);     // Search down
        SearchPath(row, col - 1, element, newList);     // Search left
        SearchPath(row - 1, col, element, newList);     // Search up

        // Return the result field list
        return newList;
    }
}