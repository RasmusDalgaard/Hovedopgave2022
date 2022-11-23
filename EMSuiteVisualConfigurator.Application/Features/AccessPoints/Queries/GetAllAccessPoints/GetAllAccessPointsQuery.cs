using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Responses;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using MediatR;

namespace EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries.GetAllAccessPoints
{
    public class GetAllAccessPointsQuery : IRequest<List<AccessPointResponse>>
    {
    }

    internal class GetAllAccessPointsQueryHandler : IRequestHandler<GetAllAccessPointsQuery, List<AccessPointResponse>>
    {
        private readonly IAccessPointRepository _accessPointRepository;
        private readonly IMapper _mapper;

        public GetAllAccessPointsQueryHandler(IAccessPointRepository accessPointRepository, IMapper mapper)
        {
            _accessPointRepository = accessPointRepository;
            _mapper = mapper;
        }

        public async Task<List<AccessPointResponse>> Handle(GetAllAccessPointsQuery request, CancellationToken cancellation)
        {
            var accessPoints = await _accessPointRepository.GetAllAccessPoints();
            return _mapper.Map<List<AccessPointResponse>>(accessPoints);
        }
    }
}
