// Write a method that reverses the digits of given decimal number.
// Example: 256 -> 652

using System;
namespace ManageNumbers
{
    public class ReverseDigits
    {
        // Create a method that reverse a number
        private static string Reverse(string num)
        {
            // Creata a temporaly string
            string tmp = "";

            // Sum number digits from the end to the begining
            for (int i = 0; i < num.Length; i++)
            {
                tmp += num[num.Length - 1 - i];
            }

            // Return reversed number
            return tmp;
        }

        public static void Main()
        {
            // Input a number to reverse
            Console.Write("Input a number to reverse: ");
            string num = Console.ReadLine();

            decimal intNum = 0;
            if (!decimal.TryParse(num, out intNum) || intNum < 0)
            {
                Console.WriteLine("Incorrect number!");
                return;
            }

            // Call a Reverse method
            string res = Reverse(num);

            // Print the results
            Console.WriteLine("The reversed number: {0}", res);
        }
    }
}