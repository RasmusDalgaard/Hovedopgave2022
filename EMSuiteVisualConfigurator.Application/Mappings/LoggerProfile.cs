using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class LoggerProfile : Profile
    {
        public LoggerProfile()
        {
            CreateMap<Logger, LoggerResponse>();

            CreateMap<LoggerResponse, Logger>();
        }
    }
}
