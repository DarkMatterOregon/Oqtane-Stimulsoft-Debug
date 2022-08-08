using Oqtane.Models;
using Oqtane.Modules;

namespace DarkMatter.Stimtest
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Stimtest",
            Description = "Stimtest",
            Version = "1.0.0",
            ServerManagerType = "DarkMatter.Stimtest.Manager.StimtestManager, DarkMatter.Stimtest.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "DarkMatter.Stimtest.Shared.Oqtane",
            PackageName = "DarkMatter.Stimtest" 
        };
    }
}
