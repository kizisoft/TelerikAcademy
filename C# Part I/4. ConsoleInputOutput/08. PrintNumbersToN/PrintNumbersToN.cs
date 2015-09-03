using System;
using System.Threading;

class PrintNumbersToN
{
    static void Main()
    {
        int i = 1;              // Count from 1 to N
        int col = 0;            // Curent cursor position
        int direction = -1;     // 1 - moving right, -1 - moving left
        int bufferWidth = Console.BufferWidth / 8 - 1;      // Right border of the moving area

        // Read a number from the console
        Console.Write("Enter a number N: ");
        int n = int.Parse(Console.ReadLine());

        // Loop to N
        while (i <= n)
        {
            //Change direction of printing if out of the desired area
            if (col == bufferWidth || col == 0)
            {
                direction = -direction;
            }

            // Print on position = col
            Console.CursorLeft = col;
            Console.WriteLine(i);

            // Slowdown
            Thread.Sleep(100);

            // Increase counters
            col = col + direction;
            i++;
        }
    }
}