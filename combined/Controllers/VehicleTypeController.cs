using System.Collections.Generic;
using combined.Models;
using combined.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace combined.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleTypeController : ControllerBase
    {
        private readonly ILogger<VehicleTypeController> _logger;
        private readonly IVehicleTypeRegisters _vehicleTypeRegisters;

        public VehicleTypeController(ILogger<VehicleTypeController> logger,
            IVehicleTypeRegisters vehicleTypeRegisters)
        {
            _logger = logger;
            _vehicleTypeRegisters = vehicleTypeRegisters;
        }

        [HttpGet]
        public IEnumerable<VehicleType> Get()
        {
            return _vehicleTypeRegisters.VehicleTypes;
        }

    }
}