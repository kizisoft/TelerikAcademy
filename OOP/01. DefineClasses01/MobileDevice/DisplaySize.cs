using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    public class DisplaySize
    {
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }

        public DisplaySize(int x, int y)
        {
            this.SizeX = x;
            this.SizeY = y;
        }

        public override string ToString()
        {
            return string.Format("x({0}):y({1})", SizeX, SizeY);
        }
    }
}