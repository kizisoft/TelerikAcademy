using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08.EventsTimer
{
    public class TimerEvent
    {
        protected readonly string eventName;            // Store current object name

        private bool isRunning;                         // Is timer running
        private int delayMilliSeconds;                  // The delay between timer runs
        private string message;                         // Timer message
        private ulong repetitionCount;                  // Count timer runs

        // Declare a new event
        public event EventHandler<TimerEventArgs> RaiseTimerEvent;

        // Constructor to initialize the timer data
        public TimerEvent(int milliSeconds, TimerEventArgs e)
        {
            this.delayMilliSeconds = milliSeconds;
            this.eventName = e.OwnerName;
            this.message = e.Message;
        }

        // Property to return timer runs
        public ulong RepetitionCount { get { return this.repetitionCount; } }

        // Runs the timer and return the execution to main thread
        public void Run()
        {
            this.isRunning = true;
            Console.WriteLine("{0} started!", this.eventName);

            // Loops until stoped
            while (this.isRunning)
            {
                // Do not stop other threads until wait
                Thread.Sleep(this.delayMilliSeconds);

                // Count repetitions
                this.repetitionCount++;
                if (this.repetitionCount == ulong.MaxValue)
                {
                    this.isRunning = false;
                }

                // Call a virtual method that raise the event
                OnRaiseTimerEvent(new TimerEventArgs(eventName, this.message));
            }

            Console.WriteLine("{0} stoped!", this.eventName);
        }

        // Stops the timer
        public void Stop()
        {
            this.isRunning = false;
        }

        // Raise the event in virtual method
        protected virtual void OnRaiseTimerEvent(TimerEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler<TimerEventArgs> handler = RaiseTimerEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, new TimerEventArgs(e.OwnerName, String.Format("{0} say '{1}' to event subscriber!", e.OwnerName, e.Message)));
            }
        }

    }
}