namespace _03.Exception
{
    using System;

    public class InvalidRangeException<T> : ApplicationException where T : IComparable
    {
        // Constructors
        public InvalidRangeException(string msg)
            : base(msg)
        {
        }

        public InvalidRangeException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }

        public InvalidRangeException(T start, T end, string msg, Exception innerEx = null)
            : base(msg, innerEx)
        {
            this.MinVal = start;
            this.MaxVal = end;
        }

        // Define properties for min and max value of the range
        public T MinVal { get; protected set; }

        public T MaxVal { get; protected set; }

        // Message to display
        public override string Message
        {
            get
            {
                if (this.MinVal.CompareTo(default(T)) != 0 && this.MaxVal.CompareTo(default(T)) != 0)
                {
                    return string.Format("{0} Value must be betwin [{1} and {2}].", base.Message, this.MinVal, this.MaxVal);
                }

                return base.Message;
            }
        }
    }
}