using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Controllers;
using Nop.Plugin.Misc.Multitenancy.Services;
using Nop.Plugin.Misc.Multitenancy.Models;
using System.Linq;
using Nop.Web.Framework.Models.DataTables;
using Nop.Plugin.Misc.Multitenancy.Domains;

namespace Nop.Plugin.Misc.Multitenancy.Controllers
{
    public class MultitenantController : BasePluginController
    {
        private readonly ITenantService _tenantService;

        public MultitenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public IActionResult List()
        {
            var tenants = _tenantService.GetAllTenants().ToList();
            var model = new TenantSearchModel();
            // Initialize additional search model properties if necessary

            return View("~/Plugins/Nop.Plugin.Misc.Multitenancy/Areas/Admin/Views/List.cshtml", model);
        }

        

        public IActionResult Create()
        {
            return View("~/Plugins/Nop.Plugin.Api/Views/Tenant/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(TenantModel model)
        {
            if (ModelState.IsValid)
            {
                var tenant = new Tenant
                {
                    Name = model.Name,
                    Email = model.Email
                };
                _tenantService.InsertTenant(tenant);
                return RedirectToAction("List");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var tenant = _tenantService.GetTenantById(id);
            if (tenant == null)
                return RedirectToAction("List");

            var model = new TenantModel
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Email = tenant.Email
            };
            return View("~/Plugins/Nop.Plugin.Api/Views/Tenant/Edit.cshtml", model);
        }

        [HttpPost]
        public IActionResult Edit(TenantModel model)
        {
            if (ModelState.IsValid)
            {
                var tenant = _tenantService.GetTenantById(model.Id);
                if (tenant == null)
                    return RedirectToAction("List");

                tenant.Name = model.Name;
                tenant.Email = model.Email;
                _tenantService.UpdateTenant(tenant);

                return RedirectToAction("List");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var tenant = _tenantService.GetTenantById(id);
            if (tenant == null)
                return RedirectToAction("List");

            _tenantService.DeleteTenant(tenant);
            return RedirectToAction("List");
        }
    }
}
