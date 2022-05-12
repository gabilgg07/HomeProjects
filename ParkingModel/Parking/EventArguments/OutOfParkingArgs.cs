using System;
using Parking.Models;

namespace Parking.EventArguments
{
    public class OutOfParkingArgs : EventArgs
    {
        public string Message { get; set; }

        public int Capacity { get; set; }

        public int CurrentCount { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
