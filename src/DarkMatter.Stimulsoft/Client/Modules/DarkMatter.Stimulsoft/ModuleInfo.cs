using Oqtane.Models;
using Oqtane.Modules;

namespace DarkMatter.Stimulsoft
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Stimulsoft",
            Description = "Stimulsoft",
            Version = "1.0.0",
            ServerManagerType = "DarkMatter.Stimulsoft.Manager.StimulsoftManager, DarkMatter.Stimulsoft.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "DarkMatter.Stimulsoft.Shared.Oqtane",
            PackageName = "DarkMatter.Stimulsoft" 
        };
    }
}
