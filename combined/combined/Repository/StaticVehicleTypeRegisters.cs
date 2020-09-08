using System.Collections.Generic;
using System.Linq;
using combined.Models;

namespace combined.Repository
{
    /// <summary>
    /// This is a temporary class to store all registers for now.
    /// TODO: Should be moved to a database 
    /// </summary>
    public class StaticVehicleTypeRegisters : IVehicleTypeRegisters
    {
        public IEnumerable<VehicleType> VehicleTypes { get; }
        private readonly Dictionary<string, VehicleType> _internalDictionary;

        public StaticVehicleTypeRegisters()
        {
            var staticTypes = new List<VehicleType>
            {
                new VehicleType(name: VehicleTypeConstants.CAR, customProperties:new List<CustomProperty>
                {
                   new CustomProperty(VehiclePropertyConstants.Engine, CustomPropertyType.STRING),
                   new CustomProperty(VehiclePropertyConstants.Doors, CustomPropertyType.INTEGER),
                   new CustomProperty(VehiclePropertyConstants.Wheels, CustomPropertyType.INTEGER),
                   new CustomProperty(VehiclePropertyConstants.BodyType, CustomPropertyType.STRING)
                })
            };

            _internalDictionary = staticTypes.ToDictionary(x => x.Name, x => x);
            
            VehicleTypes = new List<VehicleType>(staticTypes);
        }
        
        public VehicleType GetVehicleType(string name)
        {
            if (_internalDictionary.TryGetValue(name, out var vehicleType))
            {
                return vehicleType;
            }

            return null;
        }
    }
}