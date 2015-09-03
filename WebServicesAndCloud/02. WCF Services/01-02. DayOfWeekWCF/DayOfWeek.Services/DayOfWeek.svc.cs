namespace DayOfWeek.Services
{
    using System;
    using System.Globalization;

    public class DayOfWeek : IDayOfWeek
    {
        public string GetDayOfWeek(DateTime date)
        {
            return date.ToString("dddd", CultureInfo.CreateSpecificCulture("bg-BG"));
        }
    }
}