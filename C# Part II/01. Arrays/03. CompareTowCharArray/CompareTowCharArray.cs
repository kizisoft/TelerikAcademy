// Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class CompareTowCharArray
{
    static void Main()
    {
        // Enter first string to char array
        Console.Write("Enter first string: ");
        char[] str1 = Console.ReadLine().ToCharArray();

        // Enter second string to char array
        Console.Write("Enter second string: ");
        char[] str2 = Console.ReadLine().ToCharArray();

        // Get the minimum length of strings
        int length = Math.Min(str1.Length, str2.Length);

        for (int i = 0; i < length; i++)
        {
            // String 2 is before string 1
            if (str1[i] > str2[i])
            {
                Print(str2, str1);
            }

            // String 1 is before string 2
            if (str1[i] < str2[i])
            {
                Print(str1, str2);
            }
        }

        // If strings are equals then the string with smaller length is first
        if (str1.Length < str2.Length)
        {
            Print(str1, str2);
        }

        // String 2 is with smaller size
        Print(str2, str1);
    }

    // Print the strings by order and exit the program
    private static void Print(char[] str1, char[] str2)
    {
        Console.WriteLine("Lexicographicaly sorted strings: 1. {0}   2. {1}", new string(str1), new string(str2));
        Environment.Exit(0);
    }
}