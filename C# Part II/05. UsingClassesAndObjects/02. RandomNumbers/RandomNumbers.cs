// Write a program that generates and prints to the console 10
// random values in the range [100, 200].

using System;

class RandomNumbers
{
    static void Main()
    {
        // Create random
        Random rnd = new Random();
        for (int i = 0; i < 10; i++)
        {
            // Print next number betwin [100,200]
            Console.WriteLine(rnd.Next(100, 200));
        }
    }
}