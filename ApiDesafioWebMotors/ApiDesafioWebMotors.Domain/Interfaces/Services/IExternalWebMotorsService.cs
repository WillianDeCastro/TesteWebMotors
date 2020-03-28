using ApiDesafioWebMotors.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiDesafioWebMotors.Domain.Interfaces.Services
{
    public interface IExternalWebMotorsService
    {
        Task<List<Maker>> GetVehicleMakers();
        Task<List<ModelVehicle>> GetVehicleModels(int makeId);
        Task<List<VersionVehicle>> GetVehicleVersions(int modelID);
        Task<List<Vehicles>> GetVehicles(int pageId);
    }
}
