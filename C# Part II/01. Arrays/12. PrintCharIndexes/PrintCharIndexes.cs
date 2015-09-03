// Write a program that creates an array containing all letters from the alphabet (A-Z).
// Read a word from the console and print the index of each of its letters in the array.

using System;

class PrintCharIndexes
{
    static void Main()
    {
        // Initilize array - it is sorted
        char[] alphabet = new char[26];
        for (char i = 'a'; i <= 'z'; i++)
        {
            alphabet[i - 'a'] = i;
        }

        // Enter a word and convert it to lowercase
        Console.Write("Write a word: ");
        string word = Console.ReadLine().ToLower();

        // Print results using binary search
        for (int i = 0; i < word.Length; i++)
        {
            Console.Write(" " + Array.BinarySearch(alphabet, word[i]));
        }
        Console.WriteLine();
    }
}