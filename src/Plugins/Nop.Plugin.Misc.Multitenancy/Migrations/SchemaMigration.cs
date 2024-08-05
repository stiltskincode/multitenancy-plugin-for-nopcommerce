using FluentMigrator;
using Nop.Data.Mapping;
using Nop.Data.Migrations;
using Nop.Data.Extensions;
using Nop.Plugin.Misc.Multitenancy.Domains;

namespace Nop.Plugin.Misc.Multitenancy.Migrations
{
    [NopMigration("2023/08/03 09:30:17:6455422", "Nop.Plugin.Misc.Multitenancy schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(Tenant))).Exists())
            {
                Create.TableFor<Tenant>();             
            }
        }

    }
}