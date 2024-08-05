using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.Multitenancy.Domains;

namespace Nop.Plugin.Misc.Multitenancy.Mapping.Builders
{
    public class PluginBuilder : NopEntityBuilder<Tenant>
    {
        #region Methods
    
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
        }

        #endregion
    }
}