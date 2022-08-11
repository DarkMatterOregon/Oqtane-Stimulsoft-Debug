using Oqtane.Models;
using Oqtane.Modules;

namespace DarkMatter.StimtestDashboard
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "StimtestDashboard",
            Description = "StimtestDashboard",
            Version = "1.0.0",
            ServerManagerType = "DarkMatter.StimtestDashboard.Manager.StimtestManager, DarkMatter.StimtestDashboard.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "DarkMatter.StimtestDashboard.Shared.Oqtane",
            PackageName = "DarkMatter.StimtestDashboard"
        };
    }
}
