using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Plugin.Misc.Multitenancy.Infrastructure
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.AreaName == "Admin")
            {
                viewLocations = new[]
                {
                    $"/Plugins/Nop.Plugin.Misc.Multitenancy/Areas/Admin/Views/{context.ControllerName}/{context.ViewName}.cshtml",
                    $"/Plugins/Nop.Plugin.Misc.Multitenancy/Areas/Admin/Views/Shared/{context.ViewName}.cshtml",
                    $"/Areas/Admin/Views/Shared/{context.ViewName}.cshtml"
                }.Concat(viewLocations);
            }
            else
            {
                viewLocations = new[]
                {
                    $"/Plugins/Nop.Plugin.Misc.Multitenancy/Views/{context.ControllerName}/{context.ViewName}.cshtml",
                    $"/Plugins/Nop.Plugin.Misc.Multitenancy/Views/Shared/{context.ViewName}.cshtml",
                    $"/Areas/Admin/Views/Shared/{context.ViewName}.cshtml"
                }.Concat(viewLocations);
            }

            return viewLocations;
        }
    }
}
