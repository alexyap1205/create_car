using System.ComponentModel.DataAnnotations;
using combined.Models;

namespace combined.Services
{
    public interface IValidatorFactory
    {
        IValidator Create(VehicleType type);
    }
}