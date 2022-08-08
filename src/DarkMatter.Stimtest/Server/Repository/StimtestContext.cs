using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace DarkMatter.Stimtest.Repository
{
    public class StimtestContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.Stimtest> Stimtest { get; set; }

        public StimtestContext(ITenantManager tenantManager, IHttpContextAccessor accessor) : base(tenantManager, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
