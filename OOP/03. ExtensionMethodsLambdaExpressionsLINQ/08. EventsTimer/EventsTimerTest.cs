using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08.EventsTimer
{
    class EventsTimerTest
    {
        static void Main(string[] args)
        {
            // Create two timers with delay 1 and 2 sec
            TimerEvent timer1 = new TimerEvent(1000, new TimerEventArgs("Timer#1", "Hi, every 1 sec!"));
            TimerEvent timer2 = new TimerEvent(2000, new TimerEventArgs("Timer#2", "Hey, every 2 sec!"));

            // Create 3 handlers, two for first timer and one for the second
            TimerEventHandler timerHandler1 = new TimerEventHandler(new TimerEventArgs("TimerEventHandler#1", "Hello!"), timer1);
            TimerEventHandler timerHandler2 = new TimerEventHandler(new TimerEventArgs("TimerEventHandler#2", "Hello too!"), timer2);
            TimerEventHandler timerHandler3 = new TimerEventHandler(new TimerEventArgs("TimerEventHandler#2", "Hello too!"), timer1);

            // Start first timer
            Thread thread1 = new Thread(new ThreadStart(timer1.Run));
            thread1.Start();

            // Start second timer
            Thread thread2 = new Thread(new ThreadStart(timer2.Run));
            thread2.Start();

            // Stop second timer
            Thread.Sleep(10000);
            timer2.Stop();

            // Stop first timer
            Thread.Sleep(10000);
            timer1.Stop();
            Thread.Sleep(1000);

            // Print info how many times run each timer
            Console.WriteLine("Timer #1 counts {0} times", timer1.RepetitionCount);
            Console.WriteLine("Timer #2 counts {0} times", timer2.RepetitionCount);
        }
    }
}