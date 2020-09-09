using System.Collections.Generic;
using System.Threading.Tasks;
using combined.Models;

namespace combined.Repository
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> Vehicles { get; }

        Task<Vehicle> AddNewAsync(Vehicle vehicle);
    }
}