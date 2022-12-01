using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Responses;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using MediatR;


namespace EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries
{
    public class GetAccessPointByIdQuery : IRequest<AccessPointResponse>
    {
        public int Id { get; set; }
        public GetAccessPointByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetAccessPointByIdQueryHandler : IRequestHandler<GetAccessPointByIdQuery, AccessPointResponse>
    {
        private readonly IAccessPointRepository _accessPointRepository;
        private readonly IMapper _mapper;

        public GetAccessPointByIdQueryHandler(IAccessPointRepository accessPointRepository, IMapper mapper)
        {
            _accessPointRepository = accessPointRepository;
            _mapper = mapper;
        }

        public async Task<AccessPointResponse> Handle(GetAccessPointByIdQuery request, CancellationToken cancellationToken)
        {
            var accessPoint = await _accessPointRepository.GetAccessPointById(request.Id);
            return _mapper.Map<AccessPointResponse>(accessPoint);
        }
    }
}
