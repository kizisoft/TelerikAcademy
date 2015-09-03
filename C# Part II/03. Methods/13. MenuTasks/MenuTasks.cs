/* Write a program that can solve these tasks:
     - Reverses the digits of a number
     - Calculates the average of a sequence of integers
     - Solves a linear equation a * x + b = 0
 
   Create appropriate methods.
   Provide a simple text-based menu for the user to choose which task to solve.

   Validate the input data:
     - The decimal number should be non-negative
     - The sequence should not be empty
     - a should not be equal to 0
*/

using System;
using ManageNumbers;
using System.Threading;
using System.Globalization;

namespace ManageNumbers
{
    class MenuTasks
    {
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
                case 1:     // Reverses the digits of a number
                    PrintTaskName("Reverses the digits of a number", 1);
                    ReverseDigits.Main();
                    PrintTaskEnd();
                    break;
                case 2:     // Calculates the average of integers
                    PrintTaskName("Calculates the average of integers", 2);
                    int[] intSequence = InputSequence();
                    Console.WriteLine("The integer average of a sequence is: {0}", ManageNumbers.AvrgNumbers(intSequence));
                    PrintTaskEnd();
                    break;
                case 3:     // Solves a linear equation a*x + b = 0
                    PrintTaskName("Solves a linear equation a*x + b = 0", 3);

                    // Input coeficient a
                    decimal aCoef = 0;
                    do
                    {
                        Console.Write("Input a coeficient of linear equation a = ");
                        if (!decimal.TryParse(Console.ReadLine(), out aCoef) || aCoef == 0)
                        {
                            Console.WriteLine("Incorrect! Value must be a number different then zero!");
                        }
                    } while (aCoef == 0);

                    // Input coeficient b
                    decimal bCoef = 0;
                    while (true)
                    {
                        Console.Write("Input a coeficient of linear equation b = ");
                        if (!decimal.TryParse(Console.ReadLine(), out bCoef))
                        {
                            Console.WriteLine("Incorrect! Value must be a number!");
                            continue;
                        }
                        break;
                    }

                    // Print the result
                    Console.WriteLine("The result of the linear equation is x = {0}", -bCoef / aCoef);

                    PrintTaskEnd();
                    return;
            }
        }

        // This methode return a not null sequence
        private static int[] InputSequence()
        {
            // Input a length of the sequence
            int len = 0;
            do
            {
                Console.Write("Input a length of the integer sequence: ");
                if (!int.TryParse(Console.ReadLine(), out len) || len == 0)
                {
                    Console.WriteLine("Incorrect! Value must be integer number bigger then zero!");
                }
            } while (len <= 0);

            int[] res = new int[len];

            // Enter the sequence
            while (len > 0)
            {
                Console.Write("Input elenemt int[{0}] = ", len);
                if (!int.TryParse(Console.ReadLine(), out res[len - 1]))
                {
                    Console.WriteLine("Incorrect! Value must be integer number!");
                    continue;
                }

                len--;
            }

            // Return the result
            return res;
        }

        // Print the end and wait for a key
        private static void PrintTaskEnd()
        {
            Console.Write("Press any key to return to the MENU...");
            Console.ReadKey();
        }

        // Print the header of the tasks
        private static void PrintTaskName(string str, int num)
        {
            Console.Clear();
            Console.WriteLine("( {0} ) -------------- {1} -------------- ( {0} )", num, str);
            Console.WriteLine();
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

        // Print the main menu
        private static void PrintMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                 MENU");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("( 1 ) Reverses the digits of a number");
            Console.WriteLine("( 2 ) Calculates the average of a sequence of integers");
            Console.WriteLine("( 3 ) Solves a linear equation a * x + b = 0");
            Console.WriteLine("( 0 ) Exit");
            Console.WriteLine();
            Console.Write("Make your choice: ");
        }
    }
}