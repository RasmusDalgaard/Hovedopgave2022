using AutoMapper;
using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Features.Responses;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class ZoneProfile : Profile
    {
        public ZoneProfile()
        {
            CreateMap<ZoneDTO, ZoneResponse>();

            CreateMap<ZoneResponse, ZoneDTO>();
        }
    }
}
