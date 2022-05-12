using System;
using Parking.EventArguments;

namespace Parking.Delegates
{
    public delegate void OutOfParkingHandler(object sender, OutOfParkingArgs e);
}
