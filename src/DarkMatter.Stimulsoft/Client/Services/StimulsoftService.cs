using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using DarkMatter.Stimulsoft.Models;

namespace DarkMatter.Stimulsoft.Services
{
    public class StimulsoftService : ServiceBase, IStimulsoftService, IService
    {
        public StimulsoftService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Stimulsoft");

        public async Task<List<Models.Stimulsoft>> GetStimulsoftsAsync(int ModuleId)
        {
            List<Models.Stimulsoft> Stimulsofts = await GetJsonAsync<List<Models.Stimulsoft>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId));
            return Stimulsofts.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Stimulsoft> GetStimulsoftAsync(int StimulsoftId, int ModuleId)
        {
            return await GetJsonAsync<Models.Stimulsoft>(CreateAuthorizationPolicyUrl($"{Apiurl}/{StimulsoftId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.Stimulsoft> AddStimulsoftAsync(Models.Stimulsoft Stimulsoft)
        {
            return await PostJsonAsync<Models.Stimulsoft>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, Stimulsoft.ModuleId), Stimulsoft);
        }

        public async Task<Models.Stimulsoft> UpdateStimulsoftAsync(Models.Stimulsoft Stimulsoft)
        {
            return await PutJsonAsync<Models.Stimulsoft>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Stimulsoft.StimulsoftId}", EntityNames.Module, Stimulsoft.ModuleId), Stimulsoft);
        }

        public async Task DeleteStimulsoftAsync(int StimulsoftId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{StimulsoftId}", EntityNames.Module, ModuleId));
        }
    }
}
