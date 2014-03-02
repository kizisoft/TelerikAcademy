// 7. Using delegates write a class Timer that has can execute
//    certain method at each t seconds.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.DelegateTimer
{
    public delegate void TimerRun(string str);

    public class Timer
    {
        private bool isRunning;                     // Is timer running
        private TimerRun runList;                   // Delegate with function to execute
        private int delaySeconds;                   // The delay between timer runs
        private ulong repetitionCount;              // Count timer runs
        private string str;                         // Stores a string to print

        // Constructor
        public Timer(TimerRun func, string str, int sec = 3)
        {
            if (func == null)
            {
                throw new NullReferenceException("Creation of Null delegate is not possible!");
            }

            this.runList = func;
            this.delaySeconds = sec * 1000;
            this.str = str;
        }

        // Property to return timer runs
        public ulong RepetitionCount { get { return this.repetitionCount; } }

        // This function run the timer
        public void Run()
        {
            // Starting datas
            this.isRunning = true;
            this.repetitionCount = 0;

            // Run until not stoped or repetitions increased to max value
            while (this.isRunning)
            {
                // Sleep this thread and continue with others for delay seconds
                Thread.Sleep(this.delaySeconds);

                // Run the delegate function
                this.runList(this.str);

                // Count repetitions
                this.repetitionCount++;
                if (this.repetitionCount == ulong.MaxValue)
                {
                    this.isRunning = false;
                }
            }
        }

        // Stops the counter
        public void Stop()
        {
            this.isRunning = false;
        }

    }
}