namespace _05.BitArray64
{
    using System;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        // Private fields
        private ulong listBits64 = 0;

        // Constructors
        public BitArray64(ulong val = 0)
        {
            this.listBits64 = val;
        }

        // Operators overload
        public int this[int i]
        {
            get
            {
                CheckIndexRange(i);
                return (int)((this.listBits64 >> i) & 1);
            }

            set
            {
                CheckIndexRange(i);
                if (value < 0 | value > 1)
                {
                    throw new OverflowException("Value should be only 0 or 1");
                }

                this.listBits64 |= ((ulong)value) << i;
            }
        }

        public static bool operator ==(BitArray64 val1, BitArray64 val2)
        {
            return BitArray64.Equals(val1, val2);
        }

        public static bool operator !=(BitArray64 val1, BitArray64 val2)
        {
            return !BitArray64.Equals(val1, val2);
        }

        // Public methods
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.listBits64.GetHashCode();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(string.Empty, new BitArray64(this.listBits64));
        }

        // Private methods
        private static void CheckIndexRange(int i)
        {
            if (i > 63 | i < 0)
            {
                throw new IndexOutOfRangeException("The index must be betwin [0..63]");
            }
        }
    }
}