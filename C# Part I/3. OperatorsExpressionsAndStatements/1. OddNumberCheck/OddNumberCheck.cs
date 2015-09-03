using System;

class OddNumberCheck
{
    // Create enumeration type for "ODD" and "EVEN"
    enum EvenOdd { EVEN = 0, ODD = 1 };

    static void Main()
    {
        while (1 < 2)
        {
            Console.Write("Enter an integer number: ");

            // Read an integer from the console
            int num = int.Parse(Console.ReadLine());

            // Get the value "ODD" or "EVEN" from enumeration
            EvenOdd evenOdd = (EvenOdd)(Math.Abs(num % 2));

            Console.WriteLine("The number {0} is {1}.", num, evenOdd);
        }
    }
}