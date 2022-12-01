using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Responses;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using MediatR;

namespace EMSuiteVisualConfigurator.Application.Features.AccessPoints.Commands.CreateAccessPoint
{
    public class CreateAccessPointCommand : IRequest<AccessPointResponse>
    {
        public string Name { get; set; }

        public CreateAccessPointCommand(string name)
        {
            Name = name;
        }
    }

    internal class CreateAccessPointCommandHandler : IRequestHandler<CreateAccessPointCommand, AccessPointResponse>
    {
        private readonly IAccessPointRepository _accessPointRepository;
        private readonly IMapper _mapper;

        public CreateAccessPointCommandHandler(IAccessPointRepository accessPointRepository, IMapper mapper)
        {
            _accessPointRepository = accessPointRepository;
            _mapper = mapper;
        }

        public async Task<AccessPointResponse> Handle(CreateAccessPointCommand request, CancellationToken cancellationToken)
        {
            var newAccessPoint = new AccessPoint(request.Name);
            var persistedAccessPoint = await _accessPointRepository.CreateAccessPoint(newAccessPoint);
            return _mapper.Map<AccessPointResponse>(persistedAccessPoint);
        }
    }
}
