using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Responses;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
