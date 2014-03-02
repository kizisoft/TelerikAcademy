// 12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
//     Create an instance of the GSM class.
//     Add few calls.
//     Display the information about the calls.
//     Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
//     Remove the longest call from the history and calculate the total price again.
//     Finally clear the call history and print it.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    public static class CallHistoryTest
    {
        public static void Test()
        {
            MobilePhone gsm = new MobilePhone("Galaxy NOTE", "Samsung");
            gsm.CallHistory.Add(new Call(DateTime.Now, DateTime.Now.AddSeconds(177), "Pesho"));
            gsm.CallHistory.Add(new Call(DateTime.Now, DateTime.Now.AddSeconds(77), "Gesho"));
            gsm.CallHistory.Add(new Call(DateTime.Now, DateTime.Now.AddSeconds(17), "Tosho"));
            gsm.CallHistory.Add(new Call(DateTime.Now, DateTime.Now.AddSeconds(87), "Pesho"));
            gsm.CallHistory.Add(new Call(DateTime.Now, DateTime.Now.AddSeconds(107), "Peci", CallType.Received));
            gsm.CallHistory.Add(new Call(DateTime.Now, DateTime.Now.AddSeconds(207), "Misho"));
            gsm.CallHistory.Add(new Call(DateTime.Now, DateTime.Now.AddSeconds(123), "Pesho", CallType.Received));
            gsm.CallHistory.Add(new Call(DateTime.Now, DateTime.Now.AddSeconds(47), "Mama"));
            gsm.CallHistory.Add(new Call(DateTime.Now, DateTime.Now.AddSeconds(35), "Tosho"));
            gsm.CallHistory.Add(new Call(DateTime.Now, DateTime.Now.AddSeconds(333), "Misho", CallType.Received));

            Console.WriteLine("Call history:");
            foreach (var call in gsm.CallHistory)
            {
                Console.WriteLine(call);
            }

            Console.WriteLine();
            Console.WriteLine("Total cost: {0}", gsm.CalcCallCost(0.37m, (CallType.Dailed | CallType.Missed | CallType.Received)).ToString("C"));

            Call max = null;
            var maxDur = TimeSpan.MinValue;
            foreach (var item in gsm.CallHistory)
            {
                if (item.Duration > maxDur)
                {
                    maxDur = item.Duration;
                    max = item;
                }
            }

            Console.WriteLine("Max duration call: {0}", max);
            gsm.DelCall(max);
            Console.WriteLine("Total cost without max element: {0}", gsm.CalcCallCost(0.37m, (CallType.Dailed | CallType.Missed | CallType.Received)).ToString("C"));
            Console.WriteLine();

            gsm.ClearCallHistory();
            Console.WriteLine("Call history after clear it:");
            foreach (var call in gsm.CallHistory)
            {
                Console.WriteLine(call);
            }
        }
    }
}