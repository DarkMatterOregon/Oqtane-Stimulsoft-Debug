using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using DarkMatter.Stimtest.Models;

namespace DarkMatter.Stimtest.Repository
{
    public class StimtestRepository : IStimtestRepository, ITransientService
    {
        private readonly StimtestContext _db;

        public StimtestRepository(StimtestContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Stimtest> GetStimtests(int ModuleId)
        {
            return _db.Stimtest.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Stimtest GetStimtest(int StimtestId)
        {
            return GetStimtest(StimtestId, true);
        }

        public Models.Stimtest GetStimtest(int StimtestId, bool tracking)
        {
            if (tracking)
            {
                return _db.Stimtest.Find(StimtestId);
            }
            else
            {
                return _db.Stimtest.AsNoTracking().FirstOrDefault(item => item.StimtestId == StimtestId);
            }
        }

        public Models.Stimtest AddStimtest(Models.Stimtest Stimtest)
        {
            _db.Stimtest.Add(Stimtest);
            _db.SaveChanges();
            return Stimtest;
        }

        public Models.Stimtest UpdateStimtest(Models.Stimtest Stimtest)
        {
            _db.Entry(Stimtest).State = EntityState.Modified;
            _db.SaveChanges();
            return Stimtest;
        }

        public void DeleteStimtest(int StimtestId)
        {
            Models.Stimtest Stimtest = _db.Stimtest.Find(StimtestId);
            _db.Stimtest.Remove(Stimtest);
            _db.SaveChanges();
        }
    }
}
