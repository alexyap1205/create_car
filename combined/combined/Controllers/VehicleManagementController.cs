using System.Collections.Generic;
using System.Threading.Tasks;
using combined.Repository;
using combined.Services;
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
        private readonly IValidatorFactory _validatorFactory;
        private readonly IVehicleManagerFactory _managerFactory;

        public VehicleManagementController(ILogger<VehicleManagementController> logger,
            IVehicleTypeRegisters vehicleTypeRegisters,
            IValidatorFactory validatorFactory,
            IVehicleManagerFactory managerFactory)
        {
            _logger = logger;
            _vehicleTypeRegisters = vehicleTypeRegisters;
            _validatorFactory = validatorFactory;
            _managerFactory = managerFactory;
        }

        [HttpPost]
        [Route("create-vehicle")]
        public async Task<IActionResult> CreateVehicleAsync([FromBody] Dictionary<string, string> attributes)
        {
            if (!attributes.TryGetValue(VehiclePropertyConstants.VehicleType, out var type))
                return BadRequest();

            var vehicleType = _vehicleTypeRegisters.GetVehicleType(type);
            if (vehicleType == null)
                return BadRequest();

            var validator = _validatorFactory.Create(vehicleType);
            if (!validator.IsValid(attributes))
                return BadRequest();

            var manager = _managerFactory.Create(vehicleType);
            var vehicle = await manager.CreateAsync(attributes);
            if (vehicle == null)
                return BadRequest();
            
            return Ok();
        }
    }
}