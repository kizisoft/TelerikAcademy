using System;

class SpiralMatrix
{
    static void Main()
    {
        // Input N
        Console.Write("Input N (0<N<=20): ");
        int n = int.Parse(Console.ReadLine());

        // Verify range of N
        if (n <= 0 || n > 20)
        {
            Console.WriteLine("Error n range!");
            return;
        }

        int i = 1, x = 0, y = 0, lo = 0, hi = n - 1;
        int[,] dim = new int[n, n];                     // Create array matrix to store numbers
        char dir = 'r';

        do
        {
            // Set current number to the matrix
            dim[y, x] = i;

            // Check the direction of mooving obove the matrix
            if (dir == 'r')
            {
                if (x < hi)
                {
                    x++;
                }
                else
                {
                    y++;
                    dir = 'd';
                }
            }
            else if (dir == 'd')
            {
                if (y < hi)
                {
                    y++;
                }
                else
                {
                    x--;
                    dir = 'l';
                }
            }
            else if (dir == 'l')
            {
                if (x > lo)
                {
                    x--;
                }
                else
                {
                    lo++;
                    y--;
                    dir = 'u';
                }
            }
            else if (dir == 'u')
            {
                if (y > lo)
                {
                    y--;
                }
                else
                {
                    x++;
                    hi--;
                    dir = 'r';
                }
            }

            i++;
        } while (i <= n * n);

        // Draw matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,4}", dim[row, col]);
            }
            Console.WriteLine();
        }
    }
}