using System;
namespace Parking.Exceptions
{
    public class VehicleNumberException : Exception
    {
        public VehicleNumberException()
        {
        }

        public VehicleNumberException(string message)
            :base(message)
        {
        }
    }
}
