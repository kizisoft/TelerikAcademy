using System;

class PrintNumbersFrom1to7
{
    static void Main()
    {
        // Input number N
        Console.Write("Input number N: ");
        int n = int.Parse(Console.ReadLine());

        // Loop to display all numbers
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("{0}", i);
        }
    }
}