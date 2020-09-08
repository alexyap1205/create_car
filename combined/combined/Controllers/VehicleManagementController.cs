using System.Collections.Generic;
using System.Threading.Tasks;
using combined.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace combined.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleManagementController : ControllerBase
    {
        private readonly ILogger<VehicleManagementController> _logger;
        private readonly IVehicleTypeRegisters _vehicleTypeRegisters;

        public VehicleManagementController(ILogger<VehicleManagementController> logger,
            IVehicleTypeRegisters vehicleTypeRegisters)
        {
            _logger = logger;
            _vehicleTypeRegisters = vehicleTypeRegisters;
        }

        // [HttpPost]
        // [Route("create-vehicle")]
        // public async Task<IActionResult> CreateVehicleAsync([FromBody] Dictionary<string, string> attributes)
        // {
        //     
        // }

    }
}