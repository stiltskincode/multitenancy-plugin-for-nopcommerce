using Nop.Core;

namespace Nop.Plugin.Misc.Multitenancy.Domains
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}