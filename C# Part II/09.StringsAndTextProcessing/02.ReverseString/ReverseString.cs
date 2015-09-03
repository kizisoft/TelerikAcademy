// Write a program that reads a string, reverses it and prints the result at the console.
// Example: "sample"  "elpmas".

using System;

namespace _02.ReverseString
{
    class ReverseString
    {
        static void Main()
        {
            // Input a string as char[]
            Console.Write("Input a string: ");
            char[] str = Console.ReadLine().ToCharArray();

            // Reverse the char array
            Array.Reverse(str);

            // Print the reversed string
            Console.WriteLine("Reversed string: {0}", new string(str));
        }
    }
}