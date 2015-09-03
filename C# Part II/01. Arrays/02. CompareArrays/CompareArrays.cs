// Write a program that reads two arrays from the console and compares them element by element.

using System;

class CompareArrays
{
    static void Main()
    {
        // Contain a sign
        string sign = "<=>";

        // Input the arrays length
        Console.Write("Input the length of the arrays: ");
        int n = int.Parse(Console.ReadLine());

        // Declare the arrays
        int[] array1 = new int[n];
        int[] array2 = new int[n];

        // Input array1 and array2
        InputArray(n, 1, array1);
        Console.WriteLine();
        InputArray(n, 2, array2);
        Console.WriteLine();

        // Compare element by element and print the sign
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("array1[{0}] {1} {2} {3} array2[{0}]", i, array1[i], sign[array1[i].CompareTo(array2[i]) + 1], array2[i]);
        }
    }

    // Input array
    private static void InputArray(int n, int num, int[] array)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write("Input array{0}[{1}] = ", num, i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
}