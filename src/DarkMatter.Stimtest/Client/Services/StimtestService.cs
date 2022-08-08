using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using DarkMatter.Stimtest.Models;

namespace DarkMatter.Stimtest.Services
{
    public class StimtestService : ServiceBase, IStimtestService, IService
    {
        public StimtestService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Stimtest");

        public async Task<List<Models.Stimtest>> GetStimtestsAsync(int ModuleId)
        {
            List<Models.Stimtest> Stimtests = await GetJsonAsync<List<Models.Stimtest>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId));
            return Stimtests.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Stimtest> GetStimtestAsync(int StimtestId, int ModuleId)
        {
            return await GetJsonAsync<Models.Stimtest>(CreateAuthorizationPolicyUrl($"{Apiurl}/{StimtestId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.Stimtest> AddStimtestAsync(Models.Stimtest Stimtest)
        {
            return await PostJsonAsync<Models.Stimtest>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, Stimtest.ModuleId), Stimtest);
        }

        public async Task<Models.Stimtest> UpdateStimtestAsync(Models.Stimtest Stimtest)
        {
            return await PutJsonAsync<Models.Stimtest>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Stimtest.StimtestId}", EntityNames.Module, Stimtest.ModuleId), Stimtest);
        }

        public async Task DeleteStimtestAsync(int StimtestId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{StimtestId}", EntityNames.Module, ModuleId));
        }
    }
}
