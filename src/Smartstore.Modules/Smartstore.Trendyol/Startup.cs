using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Smartstore.Core.Data;
using Smartstore.Data;
using Smartstore.Data.Providers;
using Smartstore.Engine;
using Smartstore.Engine.Builders;
using Smartstore.Trendyol.Services;

namespace Smartstore.Trendyol
{
    internal class Startup : StarterBase
    {
        public override void ConfigureServices(IServiceCollection services, IApplicationContext appContext)
        {
            services.AddTransient<IDbContextConfigurationSource<SmartDbContext>, SmartDbContextConfigurer>();
        }

        class SmartDbContextConfigurer : IDbContextConfigurationSource<SmartDbContext>
        {
            public void Configure(IServiceProvider services, DbContextOptionsBuilder builder)
            {
                builder.UseDbFactory(b =>
                {
                    b.AddModelAssembly(this.GetType().Assembly);
                });
            }
        }

        public override void ConfigureContainer(ContainerBuilder builder, IApplicationContext appContext)
        {
           builder.RegisterType<ClientServices>().As<IClientServices>().InstancePerLifetimeScope();
        }
    }
}
