using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class SiteProfile : Profile
    {
        public SiteProfile()
        {
            CreateMap<Site, SiteResponse>(MemberList.None)
                .ForMember(response => response.Zones,
                opts => opts.MapFrom(entity => entity.Zones));

            CreateMap<SiteResponse, Site>(MemberList.None)
                .ForMember(entity => entity.Zones,
                opts => opts.MapFrom(response => response.Zones));
        }
    }
}
