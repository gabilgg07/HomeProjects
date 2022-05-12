using System;
using Parking.EventArguments;

namespace Parking.Delegates
{
    public delegate void CapacityOverflowHandler(object sender, CapacityOverflowArgs e);
}
