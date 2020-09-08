using System;
using System.Collections.Generic;
using combined.Models;
using combined.Repository;

namespace combined.Services
{
    public class CarValidator : BasicSchemaValidator, IValidator
    {
        // Not passing the Vehicle Type here, the validator itself should know what it needs to use.
        public CarValidator(IVehicleTypeRegisters registers) 
            : base(registers.GetVehicleType(VehicleTypeConstants.CAR))
        {
        }   
        
        public bool IsValid(Dictionary<string, string> data)
        {
            if (!base.IsSchemaValid(data))
                return false;
            
            // Perform Car specific validation here
            if (Convert.ToInt32(data[VehiclePropertyConstants.Doors]) < 2)
            {
                return false;
            }

            return true;
        }
    }
}