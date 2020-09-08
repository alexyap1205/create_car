using combined.Models;

namespace combined.Services
{
    public interface IVehicleManagerFactory
    {
        IVehicleManager Create(VehicleType type);
    }
}