using System;

class IsPrime
{
    // Create a function that check if a number is prime
    public static bool isPrime(int num)
    {
        // Exclude all even numbers
        if ((num & 1) == 0)
        {
            if (num == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // If the value is not even and != 2 check all other dividers
        for (int i = 3; (i * i) <= num; i += 2)
        {
            if ((num % i) == 0)     // If the reminder of the division is not 0 return false (not prime)
            {
                return false;
            }
        }
        return num != 1;
    }

    static void Main()
    {
        Console.Write("Enter an integer number: ");
        // Read an integer from the console
        int num = int.Parse(Console.ReadLine());

        //Call the check method and print the result
        Console.WriteLine("The number is prime: {0}", isPrime(num));
    }
}