using Nop.Plugin.Misc.Multitenancy.Domains;
using System.Collections.Generic;
using System.Linq;
using Nop.Data;

namespace Nop.Plugin.Misc.Multitenancy.Services
{
    public interface ITenantService
    {
        IQueryable<Tenant> GetAllTenants();
        Tenant GetTenantById(int id);
        void InsertTenant(Tenant Tenant);
        void UpdateTenant(Tenant Tenant);
        void DeleteTenant(Tenant Tenant);
    }
}
