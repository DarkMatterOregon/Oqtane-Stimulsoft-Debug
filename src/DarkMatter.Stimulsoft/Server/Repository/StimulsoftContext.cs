using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace DarkMatter.Stimulsoft.Repository
{
    public class StimulsoftContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.Stimulsoft> Stimulsoft { get; set; }

        public StimulsoftContext(ITenantManager tenantManager, IHttpContextAccessor accessor) : base(tenantManager, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
