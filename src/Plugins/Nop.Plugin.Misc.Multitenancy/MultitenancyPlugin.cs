
using Nop.Services.Plugins;
using Nop.Data.Migrations;
using Nop.Services.Localization;
using System.Collections.Generic;
using Nop.Web.Framework.Menu;
using System.Linq;
using Nop.Services.Common;
using Nop.Plugin.Misc.Multitenancy.Migrations;
using Nop.Services.Logging;
using System.Threading.Tasks;


namespace Nop.Plugin.Misc.Multitenancy
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class MultitenancyPlugin : BasePlugin, IAdminMenuPlugin, IMiscPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IMigrationManager _migrationManager;

        private readonly ILogger _logger;

        public MultitenancyPlugin(ILocalizationService localizationService, IMigrationManager migrationManager, ILogger logger)
        {
            _localizationService = localizationService;
            _migrationManager = migrationManager;
            _logger = logger;
        }

        public override async Task InstallAsync()
        {
            _logger.Information("Installing MultitenancyPlugin...");

            _logger.Information("Installing MultitenancyPlugin: add or  update resource");
            // Add localized resources
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Admin.Multitenancy.Fields.Name"] = "Name",
                ["Admin.Multitenancy.Fields.Email"] = "Email",
                ["Admin.Multitenancy.AddNew"] = "Add a new tenant",
                ["Admin.Multitenancy.List"] = "Tenants"
            });


            _logger.Information("Installing MultitenancyPlugin: apply up migration");
            // Apply database schema changes
            _migrationManager.ApplyUpMigrations(typeof(SchemaMigration).Assembly);


            await base.InstallAsync();

            _logger.Information("Installing MultitenancyPlugin: finished");
        }

        public override async Task UninstallAsync()
        {
            // Remove database schema changes
            _migrationManager.ApplyDownMigrations(typeof(SchemaMigration).Assembly);

            // Remove localized resources
            await _localizationService.DeleteLocaleResourcesAsync("Admin.Multitenancy");

            await base.UninstallAsync();
        }

        public async Task ManageSiteMapAsync(SiteMapNode rootNode)
        {
            var menuItem = new SiteMapNode
            {
                SystemName = "Multitenant Management",
                Title = await _localizationService.GetResourceAsync("Admin.Multitenancy.List"),
                ControllerName = "Multitenant",
                ActionName = "List",
                Visible = true,
                IconClass = "far fa-dot-circle",
            };

            var configurationNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Configuration");
            if (configurationNode != null)
                configurationNode.ChildNodes.Add(menuItem);
            else
                rootNode.ChildNodes.Add(menuItem);
        }
    }
}