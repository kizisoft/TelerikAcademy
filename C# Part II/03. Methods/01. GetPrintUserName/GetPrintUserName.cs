// Write a method that asks the user for his name and prints “Hello, <name>”
// (for example, “Hello, Peter!”). Write a program to test this method.

using System;

class GetPrintUserName
{
    // Create a method to get and print name
    public static string GetPrintName()
    {
        // Get the name from console
        Console.Write("Input a name: ");
        string name = Console.ReadLine();
        Console.WriteLine();

        // Print and return name
        Console.WriteLine("The inputed name: {0}", name);
        return name;
    }

    static void Main()
    {
        // Call a methode to get and print name
        string name = GetPrintName();
    }
}