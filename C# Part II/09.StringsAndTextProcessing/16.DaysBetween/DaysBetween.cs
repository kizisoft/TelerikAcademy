//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
//Enter the first date: 27.02.2006
//Enter the second date: 3.03.2004
//Distance: 4 days

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.DaysBetween
{
    class DaysBetween
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first date: ");
            string firstDate = Console.ReadLine();
            Console.Write("Enter the second date: ");
            string secondDate = Console.ReadLine();
            string[] firstDateArray = firstDate.Split('.');
            string[] secondDateArray = secondDate.Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
            DateTime firstDt = new DateTime(int.Parse(firstDateArray[2]), int.Parse(firstDateArray[1]), int.Parse(firstDateArray[0]));
            DateTime secondDt = new DateTime(int.Parse(secondDateArray[2]), int.Parse(secondDateArray[1]), int.Parse(secondDateArray[0]));
            TimeSpan difference = new TimeSpan();
            int isBigger = firstDt.CompareTo(secondDt);
            //Check which date is bigger in order to receive positive difference
            if (isBigger >= 0)
            {
                difference = firstDt.Subtract(secondDt);
            }
            else
            {
                difference = secondDt.Subtract(firstDt);
            }
            int differenceDays = difference.Days;
            Console.WriteLine("Distance: {0} days", differenceDays);
        }
    }
}
