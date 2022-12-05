using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class ChannelProfile : Profile
    {
        public ChannelProfile()
        {
            CreateMap<Channel, ChannelResponse>();
            CreateMap<ChannelResponse, Channel>();
        }
    }
}
