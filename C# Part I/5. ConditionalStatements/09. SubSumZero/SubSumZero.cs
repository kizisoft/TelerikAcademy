using System;
using System.Collections.Generic;
using System.Text;

class SumZero
{
    static void Main()
    {
        // Input how many numbers to read from the console
        Console.Write("Input count of numbers from [2..25]: ");
        int n = int.Parse(Console.ReadLine());

        // Create an anrry to hold the numbers
        int[] numbers = new int[n];

        // Coment this part and uncoment the part below if you want to generate the numbers random
        /* => */
        for (int i = 0; i < n; i++)
        {
            Console.Write("Input number {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        /* <= */

        // Uncoment this part and comment the upper one if you want to generate the numbers random
        /* ==>>
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            numbers[i] = rand.Next(-100, 100);
            Console.Write(numbers[i] + " ");
        }
        <<== */

        Console.WriteLine();

        // Calculate number of repetitions
        double length = Math.Pow(2, numbers.Length);

        // Create a list to hold the curent solution number
        List<int> lst = new List<int>();

        // Loop for all possible solutions
        for (int i = 1; i < length; i++)
        {
            long j = i;
            long num = 0;
            int sum = 0;

            while (j > 0)
            {
                if ((j & 1) == 1)               // Calculate possible solutions by getting binary
                {
                    sum += numbers[num];        // Accumulate the sum
                }
                num++;
                j >>= 1;
            }

            // If the subsum is 0 add the number of solution to the list
            if (sum == 0)
            {
                lst.Add(i);
            }
        }

        Console.WriteLine("Number of solutions: {0}", lst.Count);

        // If the number of solutions is bigger then 0 print on the console
        if (lst.Count > 0)
        {
            Console.WriteLine("Press ENTER to see the sums...");
            Console.ReadLine();

            for (int i = 0; i < lst.Count; i++)
            {
                long j = lst[i];
                long num = 0;
                long sum = 0;

                StringBuilder str = new StringBuilder("The sum is: ");

                while (j > 0)
                {
                    if ((j & 1) == 1)
                    {
                        str.AppendFormat("{0}[{1}] + ", numbers[num], num);
                        sum += numbers[num];
                    }
                    num++;
                    j >>= 1;
                }

                str.Remove(str.Length - 2, 2);
                str.AppendFormat(" = {0}", sum);

                Console.WriteLine(str);
            }
        }
    }
}