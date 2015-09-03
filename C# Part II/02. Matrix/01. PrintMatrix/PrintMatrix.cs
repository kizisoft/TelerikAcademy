// Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

using System;

class PrintMatrix
{
    static void Main()
    {
        // Input matrix dimention
        Console.Write("Input matrix dimention: ");
        int n = int.Parse(Console.ReadLine());

        // Declare a rectangular matrix N x N
        int[,] myMatrix = new int[n, n];

        Console.WriteLine();

        // Subtask (a)
        PrintMatrix1(n, myMatrix);

        // Subtask (b)
        PrintMatrix2(n, myMatrix);

        // Subtask (c)
        PrintMatrix3(n, myMatrix);

        // Subtask (d)
        PrintMatrix4(n, myMatrix);
    }

    // Subtask (a)
    private static void PrintMatrix1(int n, int[,] myMatrix)
    {
        int count = 0;

        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                count++;
                myMatrix[col, row] = count;
            }
        }

        Console.WriteLine("Subtask (a):");

        Print(n, myMatrix);
    }

    // Subtask (b)
    private static void PrintMatrix2(int n, int[,] myMatrix)
    {
        int count = 1 - n;

        for (int col = 0; col < n; col++)
        {
            int inc = 1;

            if (col % 2 == 1)
            {
                inc = -1;
                count += n + 1;
            }
            else
            {
                count += n - 1;
            }

            for (int row = 0; row < n; row++)
            {
                count += inc;
                myMatrix[col, row] = count;
            }
        }

        Console.WriteLine("Subtask (b):");

        Print(n, myMatrix);
    }

    // Subtask (c)
    private static void PrintMatrix3(int n, int[,] myMatrix)
    {
        int count = 1;

        for (int i = n - 1; i >= 0; i--)
        {
            int row = i;
            for (int col = 0; col <= n - i - 1; col++)
            {
                myMatrix[col, row] = count;
                count++;
                row++;
            }
        }

        for (int i = 1; i < n; i++)
        {
            int col = i;
            for (int row = 0; row <= n - i - 1; row++)
            {
                myMatrix[col, row] = count;
                count++;
                col++;
            }
        }

        Console.WriteLine("Subtask (c):");

        Print(n, myMatrix);
    }

    // Subtask (d)
    private static void PrintMatrix4(int n, int[,] myMatrix)
    {
        int minX = 1;
        int maxX = n - 1;
        int minY = 0;
        int maxY = n - 1;
        int posX = 0;
        int posY = 0;
        int dirX = 0;
        int dirY = 1;

        for (int i = 1; i <= n * n; i++)
        {
            myMatrix[posX, posY] = i;

            posX += dirX;
            posY += dirY;

            if ((posX > maxX) && (dirX == 1))
            {
                posX--;
                posY--;
                dirX = 0;
                dirY = -1;
                maxX--;
            }
            else if ((posX < minX) && (dirX == -1))
            {
                posX++;
                posY++;
                dirX = 0;
                dirY = 1;
                minX++;
            }
            else if ((posY > maxY) && (dirY == 1))
            {
                posY--;
                posX++;
                dirY = 0;
                dirX = 1;
                maxY--;
            }
            else if ((posY < minY) && (dirY == -1))
            {
                posY++;
                posX--;
                dirY = 0;
                dirX = -1;
                minY++;
            }
        }

        Console.WriteLine("Subtask (d):");

        Print(n, myMatrix);
    }

    // Print the matrix
    private static void Print(int n, int[,] myMatrix)
    {
        Console.WriteLine("".PadLeft(40, '-'));

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,5}", myMatrix[col, row]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}