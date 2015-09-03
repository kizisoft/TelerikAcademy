using System;
using System.Globalization;
using System.Threading;

class InputDifferentTypes
{
    static void Main()
    {
        int i = 0;
        double d = 0;

        // Set the curent culture to invariante to use "." instate of ","
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        // Input a string, integer or double
        Console.Write("Write a string or integer or double: ");
        string str = Console.ReadLine();

        if (int.TryParse(str, out i))
        {
            Console.WriteLine("It is an integer number {0} + 1 = {1}", i, i + 1);       // Integer number
        }
        else if (double.TryParse(str, out d))
        {
            Console.WriteLine("It is a double number {0} + 1 = {1}", d, d + 1           // Double number
                );
        }
        else
        {
            Console.WriteLine("It is a string {0} + * = {1}", str, str + "*");          // String expresion
        }
    }
}