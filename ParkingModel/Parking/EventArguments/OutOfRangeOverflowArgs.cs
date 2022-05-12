using System;
namespace Parking.EventArguments
{
    public class OutOfRangeOverflowArgs : EventArgs
    {
        public string Message { get; set; }

        public int ValueIndex { get; set; }

        public int DataLength { get; set; }

        public int Capacity { get; set; }

        public int CurrentCount { get; set; }
    }
}
