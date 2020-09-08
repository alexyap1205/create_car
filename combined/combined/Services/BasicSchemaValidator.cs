using System;
using System.Collections.Generic;
using combined.Models;
using combined.Repository;

namespace combined.Services
{
    public class BasicSchemaValidator
    {
        private readonly VehicleType _type;

        public VehicleType VehicleType => this._type;
        
        internal BasicSchemaValidator(VehicleType type)
        {
            _type = type;
        }
        
        internal bool IsSchemaValid(Dictionary<string, string> data)
        {
            var isValid = data.ContainsKey(VehiclePropertyConstants.Make) &&
                          data.ContainsKey(VehiclePropertyConstants.Model);

            if (isValid)
            {
                foreach (var typeCustomProperty in _type.CustomProperties)
                {
                    if (!(data.TryGetValue(typeCustomProperty.Name, out var value) &&
                          IsValidType(value, typeCustomProperty.Type)))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }

        private bool IsValidType(string data, CustomPropertyType propertyType)
        {
            switch (propertyType)
            {
                case CustomPropertyType.INTEGER:
                    return Int32.TryParse(data, out _);
                case CustomPropertyType.BOOLEAN:
                    return Boolean.TryParse(data, out _);
                default:
                    return true;
            }
        }
    }
}