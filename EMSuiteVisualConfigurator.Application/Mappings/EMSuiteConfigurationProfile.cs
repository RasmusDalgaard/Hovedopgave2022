using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class EMSuiteConfigurationProfile : Profile
    {
        public EMSuiteConfigurationProfile()
        {
            CreateMap<EMSuiteConfiguration, EMSuiteConfigurationResponse>();

            CreateMap<EMSuiteConfigurationResponse, EMSuiteConfiguration>();
        }
    }
}
