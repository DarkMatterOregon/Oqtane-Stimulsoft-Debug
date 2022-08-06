using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using DarkMatter.Stimulsoft.Repository;

namespace DarkMatter.Stimulsoft.Manager
{
    public class StimulsoftManager : MigratableModuleBase, IInstallable, IPortable
    {
        private IStimulsoftRepository _StimulsoftRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IHttpContextAccessor _accessor;

        public StimulsoftManager(IStimulsoftRepository StimulsoftRepository, ITenantManager tenantManager, IHttpContextAccessor accessor)
        {
            _StimulsoftRepository = StimulsoftRepository;
            _tenantManager = tenantManager;
            _accessor = accessor;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new StimulsoftContext(_tenantManager, _accessor), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new StimulsoftContext(_tenantManager, _accessor), tenant, MigrationType.Down);
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.Stimulsoft> Stimulsofts = _StimulsoftRepository.GetStimulsofts(module.ModuleId).ToList();
            if (Stimulsofts != null)
            {
                content = JsonSerializer.Serialize(Stimulsofts);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.Stimulsoft> Stimulsofts = null;
            if (!string.IsNullOrEmpty(content))
            {
                Stimulsofts = JsonSerializer.Deserialize<List<Models.Stimulsoft>>(content);
            }
            if (Stimulsofts != null)
            {
                foreach(var Stimulsoft in Stimulsofts)
                {
                    _StimulsoftRepository.AddStimulsoft(new Models.Stimulsoft { ModuleId = module.ModuleId, Name = Stimulsoft.Name });
                }
            }
        }
    }
}