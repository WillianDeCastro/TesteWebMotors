using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiDesafioWebMotors.Infra.Data.Interfaces.Repositories
{
    public interface IExternalWebMotorsRepository
    {
        Task<string> GetJsonMakersAsync();
        Task<string> GetJsonModelAsync(int makeId);
        Task<string> GetJsonVehicleVersionAsync(int ModelID);
        Task<string> GetJsonVehicleAsync(int pageId);
    }
}
