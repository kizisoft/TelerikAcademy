using System;
using System.Diagnostics;
using System.Text;

class PrintASCII
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;     // Change console encoding to UTF8

        // Loop for all the 0xFFFF characters
        for (int i = 0; i <= char.MaxValue; i++)
        {
            // Write character and its hex and int values on the console
            Console.WriteLine("{0}     0x{1:x4}     {2}", (char)i, i, i);

            // Write character and its hex and int values on the debug output to display correctly characters under number 255
            Debug.WriteLine("{0}     0x{1:x4}     {2}", (char)i, i, i);
        }
    }
}