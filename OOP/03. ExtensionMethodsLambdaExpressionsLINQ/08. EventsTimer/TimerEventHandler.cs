using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.EventsTimer
{
    class TimerEventHandler
    {
        // Store current object name
        protected readonly string eventHandlerName;

        // Store current object message
        private string message;

        // Constructor to store object dataa and to subscribe event
        public TimerEventHandler(TimerEventArgs e, TimerEvent timerEvent)
        {
            this.eventHandlerName = e.OwnerName;
            this.message = e.Message;

            // Subscribe to the event using C# 2.0 syntax
            timerEvent.RaiseTimerEvent += HandleTimerEvent;
        }

        // Define what actions to take when the event is raised. 
        void HandleTimerEvent(object sender, TimerEventArgs e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("{0} replay '{1}'.", this.eventHandlerName, this.message);
            Console.WriteLine();
        }

    }
}