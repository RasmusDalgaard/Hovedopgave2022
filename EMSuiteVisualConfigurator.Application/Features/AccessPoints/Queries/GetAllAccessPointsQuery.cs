using AutoMapper;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries
{
    public class GetAllAccessPointsQuery : IRequest<List<GetAllAccessPointsResponse>>
    {
    }

    internal class GetAllAccessPointsQueryHandler : IRequestHandler<GetAllAccessPointsQuery, List<GetAllAccessPointsResponse>>
    {
        private readonly IAccessPointRepository _accessPointRepository;
        private readonly IMapper _mapper;

        public GetAllAccessPointsQueryHandler(IAccessPointRepository accessPointRepository, IMapper mapper)
        {
            _accessPointRepository = accessPointRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAccessPointsResponse>> Handle(GetAllAccessPointsQuery request, CancellationToken cancellation)
        {
            var accessPoints = await _accessPointRepository.GetAllAccessPoints();
            return _mapper.Map<List<GetAllAccessPointsResponse>>(accessPoints);
        }
    }
}
