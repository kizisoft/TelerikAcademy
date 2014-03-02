// 7. Write a class GSMTest to test the GSM class:
//    Create an array of few instances of the GSM class.
//    Display the information about the GSMs in the array.
//    Display the information about the static property IPhone4S.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    public class MobilePhoneTest
    {
        static void Main(string[] args)
        {
            List<MobilePhone> mobilePhones = new List<MobilePhone>();
            mobilePhones.Add(new MobilePhone("1020C", "Nokia", 1299.99m, "Jhon Dow", new Battery("2307", 15, 5, BatteryType.LiIon), new Display(new DisplaySize(1980, 1024), 65000000)));
            mobilePhones.Add(new MobilePhone("Galaxy NOTE", "Samsung"));
            mobilePhones.Add(new MobilePhone("AishE", "Nokia", 299.90m, battery: new Battery()));
            mobilePhones.Add(new MobilePhone("1020C", "Nokia", 1299.99m, display: new Display(new DisplaySize(1980, 1024), 65000000)));

            foreach (var phone in mobilePhones)
            {
                Console.WriteLine(phone);
            }

            Console.WriteLine(mobilePhones[0].IPhone4SInfo);
            Console.WriteLine(mobilePhones[1].IPhone4SInfo);

            Call call = new Call(DateTime.Now, DateTime.Now.AddSeconds(177), "Pesho");

            CallHistoryTest.Test();
        }
    }
}