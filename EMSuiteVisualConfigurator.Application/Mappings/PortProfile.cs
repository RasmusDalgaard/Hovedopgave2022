using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class PortProfile : Profile
    {
        public PortProfile()
        {
            CreateMap<Port, PortResponse>();

            CreateMap<PortResponse, Port>();
        }
    }
}
