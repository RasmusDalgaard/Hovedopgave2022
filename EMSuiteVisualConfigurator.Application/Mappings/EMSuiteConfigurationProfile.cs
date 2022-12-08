using AutoMapper;
using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Features.Responses;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class EMSuiteConfigurationProfile : Profile
    {
        public EMSuiteConfigurationProfile()
        {
            CreateMap<EMSuiteConfigurationDTO, EMSuiteConfigurationResponse>();

            CreateMap<EMSuiteConfigurationResponse, EMSuiteConfigurationDTO>();
        }
    }
}
