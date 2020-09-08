using System.Collections.Generic;
using combined.Models;

namespace combined.Services
{
    public interface IValidator
    {
        bool IsValid(Dictionary<string, string> data);
    }
}