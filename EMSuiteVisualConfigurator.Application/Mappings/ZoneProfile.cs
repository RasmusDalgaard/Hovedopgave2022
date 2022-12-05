using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class ZoneProfile : Profile
    {
        public ZoneProfile()
        {
            CreateMap<Zone, ZoneResponse>(MemberList.None)
                .ForMember(response => response.Channels,
                opts => opts.MapFrom(entity => entity.Channels));

            CreateMap<ZoneResponse, Zone>(MemberList.None)
                .ForMember(entity => entity.Channels,
                opts => opts.MapFrom(response => response.Channels));
        }
    }
}
