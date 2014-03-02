using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    public class Display
    {
        // size and number of colors
        public DisplaySize Size { get; private set; }
        public int NumberOfColors { get; private set; }

        public Display()
            : this(new DisplaySize(0, 0))
        {

        }

        public Display(DisplaySize size)
            : this(size, 0)
        {

        }

        public Display(int numberOfColors)
            : this(null, numberOfColors)
        {

        }

        public Display(DisplaySize size, int numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public override string ToString()
        {
            return string.Format("Display Size: {0}  Number Of Colors: {1}", this.Size.ToString(), this.NumberOfColors);
        }
    }
}