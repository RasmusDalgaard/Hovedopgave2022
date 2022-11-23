using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EMSuiteVisualConfigurator.Data.Repositories;

namespace EMSuiteVisualConfigurator.Data.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EMSuiteVisualConfiguratorDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConection"), 
                b => b.MigrationsAssembly(typeof(EMSuiteVisualConfiguratorDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddScoped<AccessPointRepository>();

            return services;
        }
    }
}
