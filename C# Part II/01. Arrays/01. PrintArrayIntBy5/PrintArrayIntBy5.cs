// Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5.
// Print the obtained array on the console.

using System;

class PrintArrayIntBy5
{
    static void Main()
    {
        // Create new array of 20 elements
        int[] arrayInt = new int[20];

        // Loop 20 times and store in array i * 5
        for (int i = 0; i < 20; i++)
        {
            arrayInt[i] = i * 5;
            Console.WriteLine("N = {0},  N * 5 = {1}", i, arrayInt[i]);
        }
    }
}