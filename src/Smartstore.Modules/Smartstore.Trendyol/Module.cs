﻿global using System;
global using System.Collections.Generic;
global using System.ComponentModel.DataAnnotations;
global using System.Linq;
global using System.Threading.Tasks;
global using Smartstore.Web.Modelling;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Smartstore.Engine.Modularity;
using Smartstore.Http;
using Smartstore.Trendyol.Configuration;

namespace Smartstore.Trendyol
{
    internal class Module : ModuleBase, IConfigurable
    {
        public ILogger Logger { get; set; } = NullLogger.Instance;

        public RouteInfo GetConfigurationRoute()
            => new("Configure", "Trendyol", new { area = "Admin" });

        public override async Task InstallAsync(ModuleInstallationContext context)
        {
            await TrySaveSettingsAsync<TrendyolApiSettings>();
            await ImportLanguageResourcesAsync();
            await base.InstallAsync(context);
        }

        public override async Task UninstallAsync()
        {
            await DeleteSettingsAsync<TrendyolApiSettings>();
            await DeleteLanguageResourcesAsync();
            await base.UninstallAsync();
        }
    }
}
