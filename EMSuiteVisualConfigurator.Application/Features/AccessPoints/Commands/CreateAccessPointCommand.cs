using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Responses;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using MediatR;

namespace EMSuiteVisualConfigurator.Application.Features.AccessPoints.Commands
{
    public class CreateAccessPointCommand : IRequest<AccessPointResponse>
    {
        public string Name { get; set; }
        public List<Logger> Loggers { get; set; }
        public bool IsAuthorized { get; set; }       
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

        public async Task<AccessPointResponse> Handle(CreateAccessPointCommand command, CancellationToken cancellationToken)
        {
            var newAccessPoint = new AccessPoint(command.Name, command.Loggers, command.IsAuthorized);
            var persistedAccessPoint = await _accessPointRepository.CreateAccessPoint(newAccessPoint);
            return _mapper.Map<AccessPointResponse>(persistedAccessPoint);
        }
    }
}
