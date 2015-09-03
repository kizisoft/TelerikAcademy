using System;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace NumeralSystems
{
    class NumeralSystems
    {
        private static char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        private static string[] binary = new string[] { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };

        [StructLayout(LayoutKind.Explicit)]
        struct DoubleLongUnion
        {
            [FieldOffset(0)]
            public ulong ULong;
            [FieldOffset(0)]
            public double Double;
        }

        public static ulong DoubleToLong(double d)
        {
            return new DoubleLongUnion { Double = d }.ULong;
        }

        private static int InputIntValue()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Input a numer:");
                string strIn = Console.ReadLine();
                int intValue;
                bool isIntValue = int.TryParse(strIn, out intValue);

                if (isIntValue)
                {
                    return intValue;
                }

                Console.WriteLine("Wrong input! Enter an integer value!");
                Thread.Sleep(2000);
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" NUMERAL SYSTEMS CONVERTER");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("( 1 ) Decimal -> Binary");
            Console.WriteLine("( 2 ) Binary -> Decimal");
            Console.WriteLine("( 3 ) Hexadecimal -> Decimal");
            Console.WriteLine("( 4 ) Decimal -> Hexadecimal");
            Console.WriteLine("( 5 ) Hexadecimal -> Binary");
            Console.WriteLine("( 6 ) Binary -> Hexadecimal");
            Console.WriteLine("( 7 ) Binary -> Any (less then 16)");
            Console.WriteLine("( 8 ) Print decimal in binary");
            Console.WriteLine("( 0 ) Exit");
            Console.WriteLine();
            Console.Write("Choose a number: ");
        }

        // Return user choice or -1 if no such option
        private static int GetChoice()
        {
            int choice = 0;
            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out choice) && (choice >= 0 && choice < 9))
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
                case 1:     // Decimal -> Binary
                    PrintTaskName("Decimal -> Binary");
                    Console.Write("Input a decimal number: ");
                    long l = long.Parse(Console.ReadLine());
                    Console.WriteLine("{0} (Bin)", ConvertFromDecimal(l, 2));
                    PrintTaskEnd();
                    break;
                case 2:     // Binary -> Decimal
                    PrintTaskName("Binary -> Decimal");
                    Console.Write("Input a binary number: ");
                    Console.WriteLine("{0} (Dec)", ConvertToDecimal(Console.ReadLine(), 2));
                    PrintTaskEnd();
                    break;
                case 3:     // Hexadecimal -> Decimal
                    PrintTaskName("Hexadecimal -> Decimal");
                    Console.Write("Input a hexadecimal number: ");
                    Console.WriteLine("{0} (Dec)", ConvertToDecimal(Console.ReadLine(), 16));
                    PrintTaskEnd();
                    break;
                case 4:     //  Decimal -> Hexadecimal
                    PrintTaskName("Decimal -> Hexadecimal");
                    Console.Write("Input a decimal number: ");
                    l = long.Parse(Console.ReadLine());
                    Console.WriteLine("{0} (Hex)", ConvertFromDecimal(l, 16));
                    PrintTaskEnd();
                    break;
                case 5:     // Hexadecimal -> Binary
                    PrintTaskName("Hexadecimal -> Binary");
                    Console.Write("Input a hexadecimal number: ");
                    string str = Console.ReadLine().ToUpper();
                    Console.WriteLine("{0} (Bin)", HexToBin(str));
                    PrintTaskEnd();
                    break;
                case 6:     // Binary -> Hexadecimal
                    PrintTaskName("Binary -> Hexadecimal");
                    Console.Write("Input a binary number: ");
                    str = Console.ReadLine().ToUpper();
                    Console.WriteLine("{0} (Hex)", BinToHex(str));
                    PrintTaskEnd();
                    break;
                case 7:     // Binary -> Any (less then 16)
                    PrintTaskName("Binary -> Any (less then 16)");
                    Console.Write("Input the base of numeral system for converted number [2..16]: ");
                    int srcBase = int.Parse(Console.ReadLine());
                    Console.Write("Input a numbut in ({0}) numeral system: ", srcBase);
                    l = ConvertToDecimal(Console.ReadLine(), srcBase);
                    Console.Write("Input the base of numeral system to convert: ");
                    int targetBase = int.Parse(Console.ReadLine());
                    Console.WriteLine("{0} ({1})", ConvertFromDecimal(l, targetBase), targetBase);
                    PrintTaskEnd();
                    break;
                case 8:     // Print decimal in binary
                    PrintTaskName("Print decimal in binary");
                    Console.Write("Input a double number: ");
                    ulong ul = DoubleToLong(double.Parse(Console.ReadLine()));
                    str = ConvertFromDecimal(ul, 2);
                    if (str.Length < 64)
                    {
                        str = str.Insert(0, "0");
                    }
                    Console.WriteLine(str.Length);
                    Console.WriteLine("Sign = {0}", str[0]);
                    Console.WriteLine("Exponent = {0} ", str.Substring(1, 11));
                    Console.WriteLine("Mantissa = {0}", str.Substring(12, 51));
                    PrintTaskEnd();
                    break;
            }
        }

        private static string BinToHex(string str)
        {
            StringBuilder resStr = new StringBuilder("");
            for (int i = str.Length - 1; i >= 0; )
            {
                StringBuilder tmp = new StringBuilder("");
                for (int j = 0; j < 4; j++)
                {
                    if (i >= 0)
                    {
                        tmp.Insert(0, str[i]);
                    }
                    else
                    {
                        tmp.Insert(0, "0");
                    }
                    i--;
                }
                int index = Array.IndexOf(binary, tmp.ToString());
                resStr.Insert(0, numbers[index]);
            }
            return resStr.ToString();
        }

        private static string HexToBin(string str)
        {
            StringBuilder resStr = new StringBuilder("");
            for (int i = 0; i < str.Length; i++)
            {
                int index = Array.IndexOf(numbers, str[i]);
                resStr.Append(binary[index]);
            }
            return resStr.ToString();
        }

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

        private static string ConvertFromDecimal(long num, int baseSys)
        {
            StringBuilder str = new StringBuilder("");

            while (num > 0)
            {
                str.Insert(0, numbers[num % baseSys]);
                num /= baseSys;
            }

            return str.ToString();
        }

        private static string ConvertFromDecimal(ulong num, int baseSys)
        {
            StringBuilder str = new StringBuilder("");

            while (num > 0)
            {
                str.Insert(0, numbers[num % (ulong)baseSys]);
                num /= (ulong)baseSys;
            }

            return str.ToString();
        }

        private static long ConvertToDecimal(string numStr, int baseSys)
        {
            long sum = 0;
            char[] numArray = numStr.ToCharArray();
            Array.Reverse(numArray);
            numStr = (new string(numArray)).ToUpper();
            for (int i = 0; i < numStr.Length; i++)
            {
                int index = Array.IndexOf(numbers, numStr[i]);
                sum += index * Pow(baseSys, i);
            }
            return sum;
        }

        private static long Pow(long x, int pow)
        {
            long res = 1;
            for (int i = 0; i < pow; i++)
            {
                res *= x;
            }
            return res;
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
}