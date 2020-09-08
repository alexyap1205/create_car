using combined.Models;
using combined.Repository;

namespace combined.Services
{
    public class VehicleManagerFactory : IVehicleManagerFactory
    {
        private readonly IVehicleTypeRegisters _registers;
        private readonly IVehicleRepository _repository;

        public VehicleManagerFactory(IVehicleTypeRegisters registers, IVehicleRepository repository)
        {
            _registers = registers;
            _repository = repository;
        }
        
        public IVehicleManager Create(VehicleType type)
        {
            switch (type.Name)
            {
                case VehicleTypeConstants.CAR:
                    return new CarManager(_repository, _registers);
                default:
                    return null;
            }
        }
    }
}