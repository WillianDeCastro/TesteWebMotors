using ApiDesafioWebMotors.Domain.Interfaces.Services;
using ApiDesafioWebMotors.Domain.Models;
using ApiDesafioWebMotors.Infra.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiDesafioWebMotors.Domain.Services
{
    public class ExternalWebMotorsService : IExternalWebMotorsService
    {
        private readonly IExternalWebMotorsRepository _extWebMotorsRepo;

        public ExternalWebMotorsService(IExternalWebMotorsRepository extWebMotorsRepo)
        {
            _extWebMotorsRepo = extWebMotorsRepo;
        }

        public async Task<List<Maker>> GetVehicleMakers()
        {
            var lstMakers = new List<Maker>();

            string json = await _extWebMotorsRepo.GetJsonMakersAsync();

            lstMakers = JsonConvert.DeserializeObject<List<Maker>>(json);

            return lstMakers;
        }

        public async Task<List<ModelVehicle>> GetVehicleModels(int makeId)
        {
            var lstModelsVehicle = new List<ModelVehicle>();

            string json = await _extWebMotorsRepo.GetJsonModelAsync(makeId);

            lstModelsVehicle = JsonConvert.DeserializeObject<List<ModelVehicle>>(json);

            return lstModelsVehicle;
        }

        public async Task<List<Vehicles>> GetVehicles(int pageId)
        {
            var lstVehicle = new List<Vehicles>();

            string json = await _extWebMotorsRepo.GetJsonVehicleAsync(pageId);

            lstVehicle = JsonConvert.DeserializeObject<List<Vehicles>>(json);

            return lstVehicle;
        }

        public async Task<List<VersionVehicle>> GetVehicleVersions(int modelID)
        {
            var lstVersionVehicle = new List<VersionVehicle>();

            string json = await _extWebMotorsRepo.GetJsonVehicleVersionAsync(modelID);

            lstVersionVehicle = JsonConvert.DeserializeObject<List<VersionVehicle>>(json);

            return lstVersionVehicle;
        }
    }
}
