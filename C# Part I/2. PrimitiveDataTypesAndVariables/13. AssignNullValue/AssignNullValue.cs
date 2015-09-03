using System;

class AssignNullValue
{
    static void Main()
    {
        // Declare nullable variables
        int? i = null;
        double? d = null;

        // Print initial values - Null
        Console.WriteLine("Free variables: Int = {0}; Double = {1}", i, d);

        // Print Null * Null
        Console.WriteLine("Null Int * Null Double = {0}", i * d);

        // Change d from Null to number
        d = 101;
        Console.WriteLine("Set Double to 101: Double = {0}", d);

        // Try to sum number and Null
        d = d + i;
        Console.WriteLine("Double + Null Int = {0}", d);
    }
}