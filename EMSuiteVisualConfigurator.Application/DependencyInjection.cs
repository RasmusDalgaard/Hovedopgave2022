using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using EMSuiteVisualConfigurator.Application.Mappings;
using System.Reflection;
using MediatR;

namespace EMSuiteVisualConfigurator.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EMSuiteConfigurationProfile());
                mc.AddProfile(new SiteProfile());
                mc.AddProfile(new ZoneProfile());
                mc.AddProfile(new AccessPointProfile());
                mc.AddProfile(new LoggerProfile());
                mc.AddProfile(new PortProfile());
                mc.AddProfile(new ChannelProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
