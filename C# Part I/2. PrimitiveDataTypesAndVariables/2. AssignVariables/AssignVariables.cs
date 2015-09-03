using System;

class AssignVariables
{
    static void Main()
    {
        // Declare variables
        double d1 = 34.567839023D;
        double d2 = 8923.1234857D;
        float f1 = 12.345F;
        float f2 = 3456.091F;

        // Write variables and variable system type on the console
        Console.WriteLine(d1.GetType().Name + " : " + d1);
        Console.WriteLine(d2.GetType().Name + " : " + d2);
        Console.WriteLine(f1.GetType().Name + " : " + f1);
        Console.WriteLine(f2.GetType().Name + " : " + f2);
    }
}