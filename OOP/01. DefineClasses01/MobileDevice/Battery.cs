using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    public class Battery
    {
        // model, hours idle and hours talk
        private string model;
        private decimal hoursIdle = 0;
        private decimal hoursTalk = 0;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public decimal HoursIdle
        {
            get { return hoursIdle; }
            set { hoursIdle = value; }
        }

        public decimal HoursTalk
        {
            get { return hoursTalk; }
            set { hoursTalk = value; }
        }

        public BatteryType BatteryType { get; set; }

        public Battery(string model = null, decimal hoursIdle = 0, decimal hoursTalk = 0, BatteryType batteryType = 0)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public override string ToString()
        {
            return string.Format("Model: {0}  Hours Idle: {1}  Hours Talk: {2}  Battery Type: {3}", model, hoursIdle, hoursTalk, BatteryType);
        }
    }
}