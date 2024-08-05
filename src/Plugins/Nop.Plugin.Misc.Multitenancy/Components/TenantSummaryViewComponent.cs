using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Nop.Plugin.Misc.Multitenancy.Services;
using System.Linq;

namespace Nop.Plugin.Misc.Multitenancy.Components
{
    [ViewComponent(Name = "TenantSummary")]
    public class TenantSummaryViewComponent : NopViewComponent
    {
        private readonly ITenantService _tenantService;

        public TenantSummaryViewComponent(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public IViewComponentResult Invoke()
        {
            var tenants = _tenantService.GetAllTenants().ToList();
            return View("~/Plugins/Nop.Plugin.Misc.Multitenancy/Views/Components/TenantSummary/Default.cshtml", tenants);
        }
    }
}
