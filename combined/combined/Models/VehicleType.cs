using System.Collections;
using System.Collections.Generic;

namespace combined.Models
{
    public class VehicleType
    {
        public string Name { get; }
        
        public IEnumerable<CustomProperty> CustomProperties { get; }

        public VehicleType(string name, IEnumerable<CustomProperty> customProperties)
        {
            Name = name;
            CustomProperties = new List<CustomProperty>(customProperties);
        }
    }
}