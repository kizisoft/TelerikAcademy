using System;

class AssignStringToObject
{
    static void Main()
    {
        // Declare variables
        string str1 = "Hello";
        string str2 = "world";

        object obj = str1 + " " + str2;         // Assign new variable of type object with 3 strings
        Console.WriteLine(obj);

        string str3 = (string)obj;              // Create new string variable and assign it with obj convertet to string
        Console.WriteLine(str3);
    }
}