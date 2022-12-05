using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class EMSuiteConfigurationProfile : Profile
    {
        public EMSuiteConfigurationProfile()
        {
            CreateMap<EMSuiteConfiguration, EMSuiteConfigurationResponse>(MemberList.None)
                .ForMember(response => response.Sites,
                opts => opts.MapFrom(entity => entity.Sites));

            CreateMap<EMSuiteConfigurationResponse, EMSuiteConfiguration>(MemberList.None)
                .ForMember(entity => entity.Sites,
                opts => opts.MapFrom(response => response.Sites));
        }
    }
}
