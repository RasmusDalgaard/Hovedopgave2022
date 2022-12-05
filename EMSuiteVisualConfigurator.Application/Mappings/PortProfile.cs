using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class PortProfile : Profile
    {
        public PortProfile()
        {
            CreateMap<Port, PortResponse>(MemberList.None)
                .ForMember(response => response.Channels,
                opts => opts.MapFrom(entity => entity.Channels));

            CreateMap<PortResponse, Port>(MemberList.None)
                .ForMember(entity => entity.Channels,
                opts => opts.MapFrom(response => response.Channels));
        }
    }
}
