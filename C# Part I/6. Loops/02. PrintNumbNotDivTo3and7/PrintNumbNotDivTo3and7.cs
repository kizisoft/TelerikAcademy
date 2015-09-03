using System;

class PrintNumbNotDivTo3and7
{
    static void Main()
    {
        // Input number N
        Console.Write("Input number N: ");
        int n = int.Parse(Console.ReadLine());

        // Loop to display all numbers
        for (int i = 1; i <= n; i++)
        {
            if (!(i % 3 == 0 && i % 7 == 0))
            {
                Console.WriteLine("{0}", i);
            }
        }
    }
}