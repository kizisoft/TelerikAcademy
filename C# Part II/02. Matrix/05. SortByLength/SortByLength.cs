// You are given an array of strings. Write a method that sorts the array
// by the length of its elements (the number of characters composing them).

using System;
using System.Collections;

class SortByLength
{
    // Create a new class that implement IComparer interface
    // and a function Compare that checks elements by length
    public class myLengthComparer : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            return (((string)x).Length).CompareTo(((string)y).Length);
        }
    }

    static void Main()
    {
        // Input the array length
        Console.Write("Input the length of the array: ");
        int n = int.Parse(Console.ReadLine());

        // Input the array
        string[] myArray = new string[n];
        for (int i = 0; i < n; i++)
        {
            myArray[i] = Console.ReadLine();
        }

        // Sort the array using comparer class to compare elements by length
        Array.Sort(myArray, new myLengthComparer());

        // Print the results
        Console.WriteLine();
        Console.WriteLine("Elements sorted by string length:");
        Console.WriteLine(string.Join(", ", myArray));
    }
}