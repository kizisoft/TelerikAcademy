// Write a program that reads a number and prints it as a decimal number,
// hexadecimal number, percentage and in scientific notation. Format the
// output aligned right in 15 symbols.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11.FormatNumber
{
    class FormatNumber
    {
        static void Main()
        {
            Console.Write("Input a number: ");
            int number = int.Parse(Console.ReadLine());

            // Decimal number
            Console.WriteLine("{0,15:D}", number);

            // Hexadecimal number
            Console.WriteLine("{0,15:X}", number);

            // Percentage
            Console.WriteLine("{0,15:P}", number);

            // Scientific notation
            Console.WriteLine("{0,15:E}", number);
        }
    }
}