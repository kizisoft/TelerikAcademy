using System;

class CalcSum
{
    static void Main()
    {
        // Define accuracy of 0.001d
        const int power = 3;
        double accuracy = 1 / Math.Pow(10, power);

        double sum = 1;             // Current sum
        double oldSum = 0;          // Previous sum
        int sign = 1;               // Sign of next member of the sum

        // Loop until needed accuracy
        for (int i = 2; Math.Abs(sum - oldSum) > accuracy; i++)
        {
            oldSum = sum;
            sum = sum + sign * 1.0d / i;
            sign = -sign;           // Change sign for the next calculation
        }

        // Print the result
        Console.WriteLine("The sum with accuracy {0} is: {1}", accuracy, Math.Round(oldSum, power));
    }
}