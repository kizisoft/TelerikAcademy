// Write methods that calculate the surface of a triangle by given:
// Side and an altitude to it;
// Three sides;
// Two sides and an angle between them.
// Use System.Math

using System;
using System.Globalization;
using System.Threading;

class TriangleSurface
{
    private static void PrintMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" TRIANGLE SURFACE BY GIVEN");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
        Console.WriteLine("( 1 ) Side and an altitude to it");
        Console.WriteLine("( 2 ) Three sides");
        Console.WriteLine("( 3 ) Two sides and an angle between them");
        Console.WriteLine("( 0 ) Exit");
        Console.WriteLine();
        Console.Write("Choose a number: ");
    }

    // Return user choice or -1 if no such option
    private static int GetChoice()
    {
        int choice = 0;
        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out choice) && (choice >= 0 && choice < 4))
        {
            return choice;
        }

        // Print Incorrect!
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" Incorrect choice!");
        Console.ForegroundColor = ConsoleColor.Gray;
        Thread.Sleep(1000);
        return -1;
    }

    // This method do all the tasks
    private static void DoTask(int choice)
    {
        switch (choice)
        {
            case 0:     // Exit
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   Goodbye...");
                Console.ForegroundColor = ConsoleColor.Gray;
                Environment.Exit(0);
                break;
            case 1:     // Side and an altitude to it
                PrintTaskName("Side and an altitude to it");
                Console.Write("Input a side value: ");
                decimal side = decimal.Parse(Console.ReadLine());
                Console.Write("Input an altitude value: ");
                decimal altitude = decimal.Parse(Console.ReadLine());

                // Calculate and print surface
                Console.WriteLine("Triangle surface = {0}", side * altitude / 2);
                PrintTaskEnd();
                break;
            case 2:     // Three sides
                PrintTaskName("Three sides");
                Console.Write("Input a side A value: ");
                float sideA = float.Parse(Console.ReadLine());
                Console.Write("Input a side B value: ");
                float sideB = float.Parse(Console.ReadLine());
                Console.Write("Input a side C value: ");
                float sideC = float.Parse(Console.ReadLine());

                // Calculate p
                double p = CalcHeron(sideA, sideB, sideC);

                double res = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));

                Console.WriteLine("Triangle surface = {0}", res);
                PrintTaskEnd();
                break;
            case 3:     // Two sides and an angle between them
                PrintTaskName("Two sides and an angle between them");
                Console.Write("Input a side A value: ");
                sideA = float.Parse(Console.ReadLine());
                Console.Write("Input a side B value: ");
                sideB = float.Parse(Console.ReadLine());
                Console.Write("Input an angle: ");
                float angle = float.Parse(Console.ReadLine());
                // Calculate and print surface
                Console.WriteLine("Triangle surface = {0}", sideA * sideB * Math.Sin(angle * Math.PI / 180) / 2);
                PrintTaskEnd();
                break;
        }
    }

    // Calculate Heron formula
    private static double CalcHeron(float a, float b, float c)
    {
        return (a + b + c) / 2;
    }

    // Print name of the task
    private static void PrintTaskName(string taskName)
    {
        Console.Clear();
        Console.Write("----- ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(taskName);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(" -----");
        Console.WriteLine();
    }

    // Print the end and wait for a key
    private static void PrintTaskEnd()
    {
        Console.WriteLine();
        Console.Write("Press any key to return to the MENU...");
        Console.ReadKey();
    }

    static void Main()
    {
        // Set the curent culture to invariante to use "." instate of ","
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        while (true)
        {
            // Print main menu of the program
            PrintMenu();

            // Get user choice
            int choice = GetChoice();

            // Do the user choice task
            DoTask(choice);
        }
    }
}