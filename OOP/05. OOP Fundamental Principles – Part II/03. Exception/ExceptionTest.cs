namespace _03.Exception
{
    using System;

    public class ExceptionTest
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("New InvalidRangeException test:");

            try
            {
                // Throw generic exception with type int 
                throw new InvalidRangeException<int>(100, 200, "Error!");
            }
            catch (InvalidRangeException<int> innerEx)
            {
                // Throw generic exception with type DataTime 
                throw new InvalidRangeException<DateTime>(new DateTime(1980, 1, 1), new DateTime(2014, 12, 31), "Invalid date!", innerEx);
            }
        }
    }
}