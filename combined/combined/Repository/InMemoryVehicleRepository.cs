using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using combined.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace combined.Repository
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly ILogger<InMemoryVehicleRepository> _logger;
        private readonly List<Vehicle> _vehiclesList;

        public IEnumerable<Vehicle> Vehicles => _vehiclesList;

        public InMemoryVehicleRepository(ILogger<InMemoryVehicleRepository> logger)
        {
            _logger = logger;
            _vehiclesList = new List<Vehicle>();
        }
        
        public async Task<Vehicle> AddNewAsync(Vehicle vehicle)
        {
            if (_vehiclesList.Any(x =>
                x.VehicleType.Name == vehicle.VehicleType.Name && x.Make == vehicle.Make && x.Model == vehicle.Model))
            {
                _logger.Log(LogLevel.Error, "Duplicate Vehicle Detected");
                throw new InvalidOperationException("Duplicate Vehicle Detected");
            }
            
            _vehiclesList.Add(vehicle);
            _logger.Log(LogLevel.Error, $"Vehicle Added: {JsonConvert.SerializeObject(vehicle)}");
            // To simulate a bit of delay
            await Task.Delay(1);
            return vehicle;
        }
    }
}