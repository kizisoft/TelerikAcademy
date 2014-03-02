// 1. Define a class that holds information about a mobile phone device:
//    model, manufacturer, price, owner, battery characteristics (model,
//    hours idle and hours talk) and display characteristics (size and
//    number of colors). Define 3 separate classes (class GSM holding
//    instances of the classes Battery and Display).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    public class MobilePhone
    {
        // 5. Use properties to encapsulate the data fields inside the GSM,
        //    Battery and Display classes. Ensure all fields hold correct
        //    data at any given time.

        private string model;
        private string manufacturer;
        private decimal price = 0;
        private string owner;
        private Battery battery;
        private Display display;

        public string Model
        {
            get { return model; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Model should not be empty");
                }
                model = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Manufacturer should not be empty");
                }
                manufacturer = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        // 6. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.

        public string IPhone4SInfo
        {
            get { return IPhone4S.GetInfo(); }
        }

        // 9. Add a property CallHistory in the GSM class to hold a list of
        //    the performed calls. Try to use the system class List<Call>.

        public List<Call> CallHistory { get; private set; }

        /****************/
        /* CONSTRUCTORS */
        /****************/

        // 2. Define several constructors for the defined classes that take different sets
        //    of arguments (the full information for the class or part of it). Assume that
        //    model and manufacturer are mandatory (the others are optional). All unknown
        //    data fill with null.

        public MobilePhone(string model, string manufacturer)
            : this(model, manufacturer, 0, null)
        {

        }

        public MobilePhone(string model, string manufacturer, decimal price)
            : this(model, manufacturer, price, null)
        {

        }

        public MobilePhone(string model, string manufacturer, decimal price, string owner = null, Battery battery = null, Display display = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            if (battery == null)
            {
                battery = new Battery();
            }
            this.battery = battery;
            if (display == null)
            {
                display = new Display();
            }
            this.display = display;
            this.CallHistory = new List<Call>();
        }

        // 4. Add a method in the GSM class for displaying all information about it. Try to override ToString().

        public override string ToString()
        {
            return string.Format("Phone   : {0} by {1}{2}", this.model, this.manufacturer, Environment.NewLine) +
                   string.Format("Price   : {0}{1}", this.price, Environment.NewLine) +
                   string.Format("Owner   : {0}{1}", this.owner, Environment.NewLine) +
                   string.Format("Battery : {0}{1}", this.battery.ToString() ?? "N/A", Environment.NewLine) +
                   string.Format("Display : {0}{1}", this.display.ToString() ?? "N/A", Environment.NewLine);
        }

        public void PrintPhoneinfo()
        {
            Console.WriteLine(this.ToString());
        }

        // 10. Add methods in the GSM class for adding and deleting calls
        //     from the calls history. Add a method to clear the call history.

        public void AddCall(Call call)
        {
            CallHistory.Add(call);
        }

        public bool DelCall(Call call)
        {
            return CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            CallHistory.Clear();
        }

        // 11. Add a method that calculates the total price of the calls
        //     in the call history. Assume the price per minute is fixed
        //     and is provided as a parameter.

        public decimal CalcCallCost(decimal pricePerMin, CallType callType)
        {
            return CallHistory.FindAll(x => ((x.PhoneCallType & callType) == x.PhoneCallType)).Sum(x => (decimal)x.Duration.TotalSeconds) / 60.0m * pricePerMin;
        }
    }
}