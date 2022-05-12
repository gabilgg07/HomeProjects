using System;
using Parking.Exceptions;

namespace Parking.Models
{
    public class Vehicle
    {
        private string _no;

        public Vehicle(string no)
        {
            this.No = no;
        }

        public string No {
            get
            {
                return _no;
            }
            set
            {
                //if (value.Length < 7)
                //{
                //    throw new VehicleNumberException("Nəqliyyat vasitəsinin nömrəsi düzgün qeyd edilməyib!");
                //}

                _no = value;
            }
        }
    }
}
