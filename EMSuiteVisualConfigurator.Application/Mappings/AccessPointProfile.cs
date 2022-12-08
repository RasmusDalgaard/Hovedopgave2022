using AutoMapper;
using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Features.Responses;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class AccessPointProfile : Profile
    {
        public AccessPointProfile()
        {
            CreateMap<AccessPointDTO, AccessPointResponse>();

            CreateMap<AccessPointResponse, AccessPointDTO>();
        }
    }
}
