using AutoMapper;
using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Features.Responses;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class PortProfile : Profile
    {
        public PortProfile()
        {
            CreateMap<PortDTO, PortResponse>();

            CreateMap<PortResponse, PortDTO>();
        }
    }
}
