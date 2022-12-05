using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EMSuiteVisualConfigurator.Data.Repositories;
using EMSuiteVisualConfigurator.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;

namespace EMSuiteVisualConfigurator.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EMSuiteVisualConfiguratorDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly(typeof(EMSuiteVisualConfiguratorDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddScoped<IAccessPointRepository, AccessPointRepository>();
            services.AddScoped<IEMSuiteConfigurationRepository, EMSuiteConfigurationRepository>();
            return services;
        }
    }
}
