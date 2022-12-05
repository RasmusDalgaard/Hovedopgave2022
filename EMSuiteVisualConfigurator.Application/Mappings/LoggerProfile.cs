using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class LoggerProfile : Profile
    {
        public LoggerProfile()
        {
            CreateMap<Logger, LoggerResponse>(MemberList.None)
                .ForMember(response => response.Ports,
                opts => opts.MapFrom(entity => entity.Ports));

            CreateMap<LoggerResponse, Logger>(MemberList.None)
                .ForMember(entity => entity.Ports,
                opts => opts.MapFrom(response => response.Ports));
        }
    }
}
