using ApiDesafioWebMotors.Infra.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiDesafioWebMotors.Infra.Data.Repositories
{
    public class ExternalWebMotorsRepository : IExternalWebMotorsRepository
    {

        public async Task<string> GetJsonMakersAsync()
        {
            using (HttpClient cli = new HttpClient())
            {
                return await cli.GetStringAsync("http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make");
            }
        }

        public async Task<string> GetJsonModelAsync(int makeId)
        {
            using (HttpClient cli = new HttpClient())
            {
                return await cli.GetStringAsync($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID={makeId}");
            }
        }

        public async Task<string> GetJsonVehicleVersionAsync(int ModelID)
        {
            using (HttpClient cli = new HttpClient())
            {
                return await cli.GetStringAsync($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID={ModelID}");
            }
        }

        public async Task<string> GetJsonVehicleAsync(int pageId)
        {
            using (HttpClient cli = new HttpClient())
            {
                return await cli.GetStringAsync($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Vehicles?Page={pageId}");
            }
        }

    }
}
