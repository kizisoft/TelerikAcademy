// Write a method GetMax() with two parameters that returns the bigger of
// two integers. Write a program that reads 3 integers from the console and
// prints the biggest of them using the method GetMax().

using System;

class GetMaxNumber
{
    // Creata a methode to return bigger of tow numbers
    public static int GetMax(int num1, int num2)
    {
        // Check if it is bigger or equal and return value
        if (num1 >= num2)
        {
            return num1;
        }
        return num2;
    }

    static void Main()
    {
        // Input first number
        Console.Write("Enter the first number: ");
        int num1 = int.Parse(Console.ReadLine());

        // Input second number
        Console.Write("Enter the second number: ");
        int num2 = int.Parse(Console.ReadLine());

        // Input third number
        Console.Write("Enter the third number: ");
        int num3 = int.Parse(Console.ReadLine());

        // Use a method twice to get the maximum of 3 numbers
        int res = GetMax(num1, num2);
        res = GetMax(res, num3);

        // Print the result
        Console.WriteLine("The biggest of [{0}, {1}, {2}] = {3}", num1, num2, num3, res);
    }
}