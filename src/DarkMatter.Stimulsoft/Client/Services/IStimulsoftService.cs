using System.Collections.Generic;
using System.Threading.Tasks;
using DarkMatter.Stimulsoft.Models;

namespace DarkMatter.Stimulsoft.Services
{
    public interface IStimulsoftService 
    {
        Task<List<Models.Stimulsoft>> GetStimulsoftsAsync(int ModuleId);

        Task<Models.Stimulsoft> GetStimulsoftAsync(int StimulsoftId, int ModuleId);

        Task<Models.Stimulsoft> AddStimulsoftAsync(Models.Stimulsoft Stimulsoft);

        Task<Models.Stimulsoft> UpdateStimulsoftAsync(Models.Stimulsoft Stimulsoft);

        Task DeleteStimulsoftAsync(int StimulsoftId, int ModuleId);
    }
}
