using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using combined.Models;

namespace combined.Repository
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehiclesList;

        public IEnumerable<Vehicle> Vehicles => _vehiclesList;

        public InMemoryVehicleRepository()
        {
            _vehiclesList = new List<Vehicle>();
        }
        
        public async Task<Vehicle> AddNewAsync(Vehicle vehicle)
        {
            if (_vehiclesList.Any(x =>
                x.VehicleType.Name == vehicle.VehicleType.Name && x.Make == vehicle.Make && x.Model == vehicle.Model))
            {
                throw new InvalidOperationException("Duplicate Vehicle Detected");
            }
            
            _vehiclesList.Add(vehicle);
            // To simulate a bit of delay
            await Task.Delay(1);
            return vehicle;
        }
    }
}