using System;

class PrintNextNumbers
{
    static void Main()
    {
        int count1 = 2;
        int count2 = -3;

        for (int i = 0; i < 5; i++)
        {
            Console.Write(count1 + ", " + count2);

            count1 += 2;
            count2 -= 2;

            if (i < 4)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();
    }
}