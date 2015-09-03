using System;

class MiddleNumbers
{
    static void Main()
    {
        // Constant for the divider
        const int divider = 5;

        // Set counter to 0
        int counter = 0;

        // Read the first number from the console
        Console.Write("Enter number 1: ");
        int num1 = int.Parse(Console.ReadLine());

        // Read the second number from the console
        Console.Write("Enter number 2: ");
        int num2 = int.Parse(Console.ReadLine());

        for (int i = num1; i <= num2; i++)
        {
            if (i % divider == 0)       // Increment the counter if number could be divided by divider
            {
                counter++;
            }
        }

        // Print the results
        Console.WriteLine("The count of numbers divided by {0} without reminder betwin {1} and {2}: {3}", divider, num1, num2, counter);
    }
}