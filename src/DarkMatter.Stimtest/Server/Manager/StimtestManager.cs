using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using DarkMatter.Stimtest.Repository;

namespace DarkMatter.Stimtest.Manager
{
    public class StimtestManager : MigratableModuleBase, IInstallable, IPortable
    {
        private IStimtestRepository _StimtestRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IHttpContextAccessor _accessor;

        public StimtestManager(IStimtestRepository StimtestRepository, ITenantManager tenantManager, IHttpContextAccessor accessor)
        {
            _StimtestRepository = StimtestRepository;
            _tenantManager = tenantManager;
            _accessor = accessor;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new StimtestContext(_tenantManager, _accessor), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new StimtestContext(_tenantManager, _accessor), tenant, MigrationType.Down);
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.Stimtest> Stimtests = _StimtestRepository.GetStimtests(module.ModuleId).ToList();
            if (Stimtests != null)
            {
                content = JsonSerializer.Serialize(Stimtests);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.Stimtest> Stimtests = null;
            if (!string.IsNullOrEmpty(content))
            {
                Stimtests = JsonSerializer.Deserialize<List<Models.Stimtest>>(content);
            }
            if (Stimtests != null)
            {
                foreach(var Stimtest in Stimtests)
                {
                    _StimtestRepository.AddStimtest(new Models.Stimtest { ModuleId = module.ModuleId, Name = Stimtest.Name });
                }
            }
        }
    }
}