using System.Collections.Generic;
using System.Threading.Tasks;
using combined.Models;

namespace combined.Services
{
    public interface IVehicleManager
    {
        Task<Vehicle> CreateAsync(Dictionary<string, string> data);
    }
}