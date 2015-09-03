// Write a method that calculates the number of workdays between today
// and given date, passed as parameter. Consider that workdays are all
// days from Monday to Friday except a fixed list of public holidays
// specified preliminary as array.

using System;
using System.Collections.Generic;

class CalcWorkingDays
{

    static void Main()
    {
        // Preset holidays
        List<DateTime> holidays = new List<DateTime>();
        holidays.Add(new DateTime(2014, 3, 3));
        holidays.Add(new DateTime(2014, 12, 24));
        holidays.Add(new DateTime(2014, 12, 25));
        holidays.Add(new DateTime(2014, 12, 31));

        // Print holidays
        Console.WriteLine("Preset holidays:");
        foreach (var date in holidays)
        {
            Console.WriteLine(date.ToString("d"));
        }
        Console.WriteLine();

        // Start of period = today
        DateTime dateTime = DateTime.Now.Date;

        // Input end of period
        Console.Write("Input end of period (ex: {0}): ", dateTime.ToString("d"));
        DateTime endDate = DateTime.Parse(Console.ReadLine());

        // Count working days
        int count = 0;

        // Loop for all the days of period
        while (dateTime <= endDate)
        {
            // Increase count if it's working day
            if (dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday && !holidays.Contains(dateTime))
            {
                count++;
            }

            // Check next day
            dateTime = dateTime.AddDays(1);
        }

        // Print the result
        Console.WriteLine("The working days in the period = {0}", count);
    }
}