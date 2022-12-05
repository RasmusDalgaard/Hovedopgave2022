using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class AccessPointProfile : Profile
    {
        public AccessPointProfile()
        {
            CreateMap<AccessPoint, AccessPointResponse>(MemberList.None)
                .ForMember(response => response.Loggers,
                opts => opts.MapFrom(entity => entity.Loggers));

            CreateMap<AccessPointResponse, AccessPoint>(MemberList.None)
                .ForMember(entity => entity.Loggers,
                opts => opts.MapFrom(response => response.Loggers));
        }
    }
}
