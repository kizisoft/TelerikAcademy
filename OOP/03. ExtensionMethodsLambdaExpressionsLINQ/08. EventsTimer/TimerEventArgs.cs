using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.EventsTimer
{
    public class TimerEventArgs : EventArgs
    {
        private string eventPublisherName;
        private string message;

        public TimerEventArgs(string eventPublisherName, string message = "")
        {
            this.eventPublisherName = eventPublisherName;
            this.message = message;
        }

        public string OwnerName
        {
            get { return eventPublisherName; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

    }
}