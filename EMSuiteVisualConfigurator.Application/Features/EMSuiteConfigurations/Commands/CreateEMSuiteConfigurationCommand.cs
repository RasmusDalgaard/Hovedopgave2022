using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using MediatR;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.Application.DTOs;

namespace EMSuiteVisualConfigurator.Application.Features.EMSuiteConfigurations.Commands
{
    public class CreateEMSuiteConfigurationCommand : IRequest<int>
    {
        public EMSuiteConfigurationDTO ConfigurationDTO { get; set; }
        public List<AccessPointDTO> AccessPointDTOs { get; set; } = new();
    }

    internal class CreateEMSuiteConfigurationCommandHandler : IRequestHandler<CreateEMSuiteConfigurationCommand, int>
    {
        private readonly IEMSuiteConfigurationRepository _emsuiteConfigurationRepository;
        private readonly IMapper _mapper;

        public CreateEMSuiteConfigurationCommandHandler(IEMSuiteConfigurationRepository emsuiteConfigurationRepository, IMapper mapper)
        {
            _emsuiteConfigurationRepository = emsuiteConfigurationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEMSuiteConfigurationCommand command, CancellationToken cancellationToken)
        {
            //Run stored procedure for AccessPoint here

            //Link ConfigurationItems to Zone and site here 

            return 1;
        }
    }
}

