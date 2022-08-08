using System.Collections.Generic;
using DarkMatter.Stimtest.Models;

namespace DarkMatter.Stimtest.Repository
{
    public interface IStimtestRepository
    {
        IEnumerable<Models.Stimtest> GetStimtests(int ModuleId);
        Models.Stimtest GetStimtest(int StimtestId);
        Models.Stimtest GetStimtest(int StimtestId, bool tracking);
        Models.Stimtest AddStimtest(Models.Stimtest Stimtest);
        Models.Stimtest UpdateStimtest(Models.Stimtest Stimtest);
        void DeleteStimtest(int StimtestId);
    }
}
