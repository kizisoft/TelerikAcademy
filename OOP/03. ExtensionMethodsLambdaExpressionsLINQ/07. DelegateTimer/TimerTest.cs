using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.DelegateTimer
{
    // This class tests a class Timer
    static class TimerTest
    {
        static void Main(string[] args)
        {
            // Delegate with method PrintFirst for second timer
            TimerRun action = new TimerRun(PrintFirst);
            Timer timer1 = new Timer(action, "Tik  : 1 sec", 1);

            // Delegate with method PrintFirst for second timer
            action = new TimerRun(PrintSecond);
            Timer timer2 = new Timer(action, "Taak : 2 sec", 2);

            // Start first timer
            Thread thread = new Thread(new ThreadStart(timer1.Run));
            Console.WriteLine("Timer #1 started!");
            thread.Start();

            // Start second timer
            thread = new Thread(new ThreadStart(timer2.Run));
            Console.WriteLine("Timer #2 started!");
            thread.Start();

            // Wait to synhronize main thread with timers treads
            Thread.Sleep(10000);

            // Stop first timer
            thread = new Thread(new ThreadStart(timer1.Stop));
            Console.WriteLine("Timer #1 stoped!");
            thread.Start();

            // Wait to synhronize main thread with timers treads
            Thread.Sleep(6000);

            // Stop second timer
            thread = new Thread(new ThreadStart(timer2.Stop));
            Console.WriteLine("Timer #2 stoped!");
            thread.Start();

            // Wait to synhronize main thread with timers treads
            Thread.Sleep(2000);

            Console.WriteLine("That's all folks!");
            Console.WriteLine();

            // Print info how many times run each timer
            Console.WriteLine("Timer #1 counts {0} times", timer1.RepetitionCount);
            Console.WriteLine("Timer #2 counts {0} times", timer2.RepetitionCount);
        }

        // Called by first deligate in first timer
        static void PrintFirst(string str)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(str);
            Console.WriteLine("method #1");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

        // Called by second deligate in second timer
        static void PrintSecond(string str)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(str);
            Console.WriteLine("method #2");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
    }
}