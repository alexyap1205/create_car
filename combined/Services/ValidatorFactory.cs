using combined.Models;
using combined.Repository;

namespace combined.Services
{
    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IVehicleTypeRegisters _registers;

        public ValidatorFactory(IVehicleTypeRegisters registers)
        {
            _registers = registers;
        }
        
        public IValidator Create(VehicleType type)
        {
            switch (type.Name)
            {
                case VehicleTypeConstants.CAR:
                    return new CarValidator(_registers);
                    break;
                default:
                    return null;
            }
        }
    }
}