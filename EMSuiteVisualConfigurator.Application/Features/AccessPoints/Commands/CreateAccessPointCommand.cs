using AutoMapper;
using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using MediatR;

namespace EMSuiteVisualConfigurator.Application.Features.AccessPoints.Commands
{
    public class CreateAccessPointCommand : IRequest<int>
    {
        public AccessPointDTO AccessPointDTO { get; set; }
    }

    internal class CreateAccessPointCommandHandler : IRequestHandler<CreateAccessPointCommand, int>
    {
        private readonly IAccessPointRepository _accessPointRepository;
        private readonly IMapper _mapper;

        public CreateAccessPointCommandHandler(IAccessPointRepository accessPointRepository, IMapper mapper)
        {
            _accessPointRepository = accessPointRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAccessPointCommand command, CancellationToken cancellationToken)
        {
            //Run stored procedure here
            //var newAccessPoint = new AccessPoint(command.Loggers, command.IsAuthorized);
            //var persistedAccessPoint = await _accessPointRepository.CreateAccessPoint(newAccessPoint);
            return 1;
        }
    }
}
