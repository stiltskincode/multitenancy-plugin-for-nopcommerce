using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;

namespace  Nop.Plugin.Misc.Multitenancy.Infrastructure
{
    public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapControllerRoute("Plugin.Multitenancy.Tenant.List", "Admin/Multitenant/List",
                new { controller = "Multitenant", action = "List" });

            routeBuilder.MapControllerRoute("Plugin.Multitenancy.Tenant.Create", "Admin/Multitenant/Create",
                new { controller = "Multitenant", action = "Create" });

            routeBuilder.MapControllerRoute("Plugin.Multitenancy.Tenant.Edit", "Admin/Multitenant/Edit",
                new { controller = "Multitenant", action = "Edit" });

            routeBuilder.MapControllerRoute("Plugin.Multitenancy.Tenant.Delete", "Admin/Multitenant/Delete",
                new { controller = "Multitenant", action = "Delete" });
        }

        public int Priority => 0;
    }
}
