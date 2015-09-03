using System;

class DivWithoutRemainder
{
    static void Main()
    {
        while (1 < 2)
        {
            Console.Write("Enter an integer number: ");
            int num = int.Parse(Console.ReadLine());                       // Read an integer from the console

            bool isDiv = (num % 7 == 0) && (num % 5 == 0);                  // Check if the num could be divide by 7 and 5 with reminder 0

            Console.WriteLine("The number {0} could be divide by 7 and 5 without remainder: {1}", num, isDiv);
        }
    }
}