// Write a program that reads a date and time given in the format:
// day.month.year hour:minute:second and prints the date and time after 6 hours
// and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _17.PrintDayInBulgarian
{
    class PrintDayInBulgarian
    {
        static void Main()
        {
            // string dateIn = "20.01.2014 08:43:10";
            Console.Write("Input a date in format dd.mm.yyyy: ");
            string dateIn = Console.ReadLine();

            DateTime date = DateTime.ParseExact(dateIn, "dd.MM.yyyy HH:mm:ss", CultureInfo.CurrentCulture);
            date = date.AddHours(6.5);
            Console.WriteLine("{0:dddd} {0:dd.MM.yyyy HH:mm:ss}", date);
        }
    }
}