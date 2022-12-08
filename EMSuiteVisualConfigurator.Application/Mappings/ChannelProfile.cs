using AutoMapper;
using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Features.Responses;

namespace EMSuiteVisualConfigurator.Application.Mappings
{
    public class ChannelProfile : Profile
    {
        public ChannelProfile()
        {
            CreateMap<ChannelDTO, ChannelResponse>();
            CreateMap<ChannelResponse, ChannelDTO>();
        }
    }
}
