namespace DayOfWeek.ConsoleClient
{
    using System;
    using System.Text;

    using ServiceReferenceDayOfWeek;

    class Program
    {
        static void Main(string[] args)
        {
            var client = new DayOfWeekClient();
            var result = client.GetDayOfWeek(DateTime.Now);
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(result);
        }
    }
}