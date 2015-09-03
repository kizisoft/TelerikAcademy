using System;

class CheckThirdDigit
{
    static void Main()
    {
        const int digitChecker = 7;                         // Checker number
        const int digitChecked = 3;                         // Position of the checker digith

        Console.Write("Enter an integer number: ");
        // Read an integer from the console
        int num = int.Parse(Console.ReadLine());

        // Check if the number is more then 3 digits
        if (num < 100)
        {
            Console.WriteLine("The number is less then 3 digits!");
            return;
        }

        int div1 = (int)Math.Pow(10, digitChecked);         // Calculate the number of mask
        int div2 = (int)Math.Pow(10, digitChecked - 1);     // Clculate the divider - 10 times lower

        Console.WriteLine((num % div1) / div2 == digitChecker);     // To check exact digith of number get the modul of number and divide it 10 times lower number
    }
}