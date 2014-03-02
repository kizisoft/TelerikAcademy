// 8. Create a class Call to hold a call performed through a GSM. It should
//    contain date, time, dialed phone number and duration (in seconds).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    public class Call
    {
        private DateTime startCallDateTime;
        private DateTime endCallDateTime;
        private string phoneNumber;

        public string CallDate
        {
            get
            {
                return startCallDateTime.ToString("dd.mm.yyyy");
            }
        }

        public string CallTime
        {
            get
            {
                return startCallDateTime.ToString("hh:mm:ss");
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return endCallDateTime - startCallDateTime;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
        }

        public CallType PhoneCallType { get; private set; }

        public Call(DateTime startCall, DateTime endCall, string phoneNumber, CallType callType = CallType.Dailed)
        {
            this.startCallDateTime = startCall;
            this.endCallDateTime = endCall;
            this.phoneNumber = phoneNumber;
            this.PhoneCallType = callType;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}{2}", this.PhoneNumber, this.PhoneCallType, Environment.NewLine) +
                   string.Format("{0} - {1} - {2}", this.CallTime, this.CallDate,this.Duration);
        }
    }
}