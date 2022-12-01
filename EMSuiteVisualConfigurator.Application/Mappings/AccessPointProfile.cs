using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class AccessPointProfile : Profile
    {
        public AccessPointProfile()
        {
            CreateMap<AccessPoint, AccessPointResponse>();
            CreateMap<AccessPointResponse, AccessPoint>();
        }
    }
}
