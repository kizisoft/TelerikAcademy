using System;

class PrintCurrentDateTime
{
    static void Main()
    {
        Console.WriteLine("Current date is: " + DateTime.Now.Date);
        Console.WriteLine("Current time is: " + DateTime.Now.TimeOfDay);
    }
}