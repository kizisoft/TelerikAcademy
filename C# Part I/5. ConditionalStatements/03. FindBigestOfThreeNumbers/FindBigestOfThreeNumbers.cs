using System;

class FindBigestOfThreeNumbers
{
    static void Main()
    {
        int[] num = new int[3];                 // Create an array of int and set its values to 0
        int bigestNumb = int.MinValue;          // Store the current biggest number

        for (int i = 0; i < 3; i++)             // Read all 3 values from the console
        {
            Console.Write("Enter number {0}: ", i + 1);
            num[i] = int.Parse(Console.ReadLine());

            // Store the current biggest number
            if (num[i] > bigestNumb)
            {
                bigestNumb = num[i];
            }
        }

        // Print the result
        Console.WriteLine("The biggest number is: {0}", bigestNumb);
    }
}