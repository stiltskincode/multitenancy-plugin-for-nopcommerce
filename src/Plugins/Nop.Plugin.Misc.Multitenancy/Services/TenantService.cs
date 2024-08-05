using System.Linq;
using Nop.Data;
using Nop.Plugin.Misc.Multitenancy.Domains;

namespace Nop.Plugin.Misc.Multitenancy.Services
{
    public class TenantService : ITenantService
    {
        private readonly IRepository<Tenant> _tenantRepository;

        public TenantService(IRepository<Tenant> tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public IQueryable<Tenant> GetAllTenants()
        {
            return _tenantRepository.Table;
        }

        public Tenant GetTenantById(int id)
        {
            return _tenantRepository.GetById(id);
        }

        public void InsertTenant(Tenant tenant)
        {
            _tenantRepository.Insert(tenant);
        }

        public void UpdateTenant(Tenant tenant)
        {
            _tenantRepository.Update(tenant);
        }

        public void DeleteTenant(Tenant tenant)
        {
            _tenantRepository.Delete(tenant);
        }
    }
}
