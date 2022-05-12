using System;
namespace Parking.EventArguments
{
    public class CapacityOverflowArgs : EventArgs
    {
        public string Message { get; set; }

        public int Capacity { get; set; }

        public int CurrentCount { get; set; }
    }
}
