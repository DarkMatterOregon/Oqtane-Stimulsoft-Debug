using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using DarkMatter.Stimulsoft.Models;

namespace DarkMatter.Stimulsoft.Repository
{
    public class StimulsoftRepository : IStimulsoftRepository, ITransientService
    {
        private readonly StimulsoftContext _db;

        public StimulsoftRepository(StimulsoftContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Stimulsoft> GetStimulsofts(int ModuleId)
        {
            return _db.Stimulsoft.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Stimulsoft GetStimulsoft(int StimulsoftId)
        {
            return GetStimulsoft(StimulsoftId, true);
        }

        public Models.Stimulsoft GetStimulsoft(int StimulsoftId, bool tracking)
        {
            if (tracking)
            {
                return _db.Stimulsoft.Find(StimulsoftId);
            }
            else
            {
                return _db.Stimulsoft.AsNoTracking().FirstOrDefault(item => item.StimulsoftId == StimulsoftId);
            }
        }

        public Models.Stimulsoft AddStimulsoft(Models.Stimulsoft Stimulsoft)
        {
            _db.Stimulsoft.Add(Stimulsoft);
            _db.SaveChanges();
            return Stimulsoft;
        }

        public Models.Stimulsoft UpdateStimulsoft(Models.Stimulsoft Stimulsoft)
        {
            _db.Entry(Stimulsoft).State = EntityState.Modified;
            _db.SaveChanges();
            return Stimulsoft;
        }

        public void DeleteStimulsoft(int StimulsoftId)
        {
            Models.Stimulsoft Stimulsoft = _db.Stimulsoft.Find(StimulsoftId);
            _db.Stimulsoft.Remove(Stimulsoft);
            _db.SaveChanges();
        }
    }
}
