using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using combined.Models;
using combined.Repository;

namespace combined.Services
{
    public class CarManager : IVehicleManager
    {
        private readonly IVehicleRepository _repository;
        private readonly VehicleType _vehicleType;

        public CarManager(IVehicleRepository repository, IVehicleTypeRegisters register)
        {
            _repository = repository;
            _vehicleType = register.GetVehicleType(VehicleTypeConstants.CAR);
        }
        
        public async Task<Vehicle> CreateAsync(Dictionary<string, string> data)
        {
            // TODO: Ideally we should validate, for this time we assume it was validated by a CarValidator before calling this.
            var car = new Car(_vehicleType, data[VehiclePropertyConstants.Make], data[VehiclePropertyConstants.Model])
            {
                Engine = data[VehiclePropertyConstants.Engine],
                Wheels = Convert.ToInt32(data[VehiclePropertyConstants.Wheels]),
                Doors = Convert.ToInt32(data[VehiclePropertyConstants.Doors]),
                BodyType = data[VehiclePropertyConstants.BodyType]
            };
            return await _repository.AddNewAsync(car);
        }
    }
}