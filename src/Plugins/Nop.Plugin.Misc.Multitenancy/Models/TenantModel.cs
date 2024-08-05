using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.Multitenancy.Models
{
    public record TenantModel : BaseNopEntityModel
    {
        [NopResourceDisplayName("Admin.Tenants.Fields.Name")]
        [Required]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Tenants.Fields.Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
