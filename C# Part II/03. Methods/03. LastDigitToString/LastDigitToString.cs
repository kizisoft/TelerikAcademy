// Write a method that returns the last digit of given integer as an
// English word. Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

using System;

class LastDigitToString
{
    // Create a enumeration tor the digit 0 - 9
    enum Digit { Zero = 0, One, Two, Three, Four, Five, Six, Seven, Eight, Nine }

    // Create a method to return the last digit as string
    public static string ReturnLastDigitAsString(int number)
    {
        // Get the last digith frol enum
        Digit val = (Digit)(number % 10);

        // Return the value as string
        return val.ToString();
    }

    static void Main()
    {
        // Input a number
        Console.Write("Input a number: ");
        int num = int.Parse(Console.ReadLine());

        // Call the methode to return digit as string
        string digitAsString = ReturnLastDigitAsString(num);

        // Print the result
        Console.WriteLine("The last digith as string: {0}", digitAsString);
    }
}