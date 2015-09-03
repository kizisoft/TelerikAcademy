using System;

class PrintGreaterNumber
{
    static void Main()
    {
        // Read the first number from the console
        Console.Write("Enter number 1: ");
        int num1 = int.Parse(Console.ReadLine());

        // Read the second number from the console
        Console.Write("Enter number 2: ");
        int num2 = int.Parse(Console.ReadLine());

        Console.WriteLine("The bigger number of ({0},{1}): {2}", num1, num2, Math.Max(num1, num2));     // Use Math function to return the max number

        Console.WriteLine("Another way to do it: {0}", GetMaxNumber(num1, num2));        // Another interesting way to compare numbers
    }

    // Create function that return the bigger number
    public static int GetMaxNumber(int num1, int num2)
    {
        int[] res = { num1, num2 };                     // Assign numbers to an array
        uint k = (uint)(num1 - num2) >> 31;             // Return 1 or 0 depending of the sign of subtraction num1 - num2. The last bit of the number is sign bit

        return res[k];                                  // Return the bigger value
    }
}