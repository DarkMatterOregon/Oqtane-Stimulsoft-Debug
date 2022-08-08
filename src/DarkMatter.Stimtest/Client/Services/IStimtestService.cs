using System.Collections.Generic;
using System.Threading.Tasks;
using DarkMatter.Stimtest.Models;

namespace DarkMatter.Stimtest.Services
{
    public interface IStimtestService 
    {
        Task<List<Models.Stimtest>> GetStimtestsAsync(int ModuleId);

        Task<Models.Stimtest> GetStimtestAsync(int StimtestId, int ModuleId);

        Task<Models.Stimtest> AddStimtestAsync(Models.Stimtest Stimtest);

        Task<Models.Stimtest> UpdateStimtestAsync(Models.Stimtest Stimtest);

        Task DeleteStimtestAsync(int StimtestId, int ModuleId);
    }
}
