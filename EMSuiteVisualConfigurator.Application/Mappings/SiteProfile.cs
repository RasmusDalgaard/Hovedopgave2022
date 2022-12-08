using AutoMapper;
using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Features.Responses;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class SiteProfile : Profile
    {
        public SiteProfile()
        {
            CreateMap<SiteDTO, SiteResponse>();

            CreateMap<SiteResponse, SiteDTO>();
        }
    }
}
