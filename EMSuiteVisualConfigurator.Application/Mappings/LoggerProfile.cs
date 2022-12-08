using AutoMapper;
using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Features.Responses;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class LoggerProfile : Profile
    {
        public LoggerProfile()
        {
            CreateMap<LoggerDTO, LoggerResponse>();

            CreateMap<LoggerResponse, LoggerDTO>();
        }
    }
}
