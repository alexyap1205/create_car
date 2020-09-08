using System.Collections;
using System.Collections.Generic;
using combined.Models;

namespace combined.Repository
{
    public interface IVehicleTypeRegisters
    {
        IEnumerable<VehicleType> VehicleTypes { get; }

        VehicleType GetVehicleType(string name);
    }
}