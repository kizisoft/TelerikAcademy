using System;

namespace MobileDevice
{
    [Flags]
    public enum CallType
    {
        Dailed = 1,
        Received = 2,
        Missed = 4
    }
}