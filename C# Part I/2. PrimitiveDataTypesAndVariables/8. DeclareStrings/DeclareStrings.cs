using System;

class DeclareStrings
{
    static void Main()
    {
        // Print string using quoted strings
        string str1 = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(str1);

        // Print string using escape sequences
        string str2 = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine(str2);
    }
}