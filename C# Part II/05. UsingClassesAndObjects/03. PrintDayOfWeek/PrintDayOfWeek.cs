using System;

class PrintDayOfWeek
{
    static void Main()
    {
        // Create DateTime variable and set it with today
        DateTime dateTime = DateTime.Now;

        // Print day of week
        Console.WriteLine("Today is {0}", dateTime.DayOfWeek);

        // Print current date
        Console.WriteLine("Date is {0}/{1}/{2}", dateTime.Day, dateTime.Month, dateTime.Year);
    }
}