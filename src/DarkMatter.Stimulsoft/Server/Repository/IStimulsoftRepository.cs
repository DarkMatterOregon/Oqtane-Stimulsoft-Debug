using System.Collections.Generic;
using DarkMatter.Stimulsoft.Models;

namespace DarkMatter.Stimulsoft.Repository
{
    public interface IStimulsoftRepository
    {
        IEnumerable<Models.Stimulsoft> GetStimulsofts(int ModuleId);
        Models.Stimulsoft GetStimulsoft(int StimulsoftId);
        Models.Stimulsoft GetStimulsoft(int StimulsoftId, bool tracking);
        Models.Stimulsoft AddStimulsoft(Models.Stimulsoft Stimulsoft);
        Models.Stimulsoft UpdateStimulsoft(Models.Stimulsoft Stimulsoft);
        void DeleteStimulsoft(int StimulsoftId);
    }
}
