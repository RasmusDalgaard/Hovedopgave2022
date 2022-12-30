using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using MediatR;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using System.Threading.Channels;

namespace EMSuiteVisualConfigurator.Application.Features.EMSuiteConfigurations.Commands
{
    public class CreateEMSuiteConfigurationCommand : IRequest<string>
    {
        public EMSuiteConfigurationDTO ConfigurationDTO { get; set; } = new();
        public List<AccessPointDTO> AccessPointDTOs { get; set; } = new();
    }

    internal class CreateEMSuiteConfigurationCommandHandler : IRequestHandler<CreateEMSuiteConfigurationCommand, string>
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;

        public CreateEMSuiteConfigurationCommandHandler(IConfigurationRepository configurationRepository, IMapper mapper)
        {
            _configurationRepository = configurationRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateEMSuiteConfigurationCommand command, CancellationToken cancellationToken)
        {
            //Run stored procedure for AccessPoint here
            //Link ConfigurationItems to Zone and site here 
            await _configurationRepository.InsertEquipment(command);
            await _configurationRepository.CreateSites(command);
            await _configurationRepository.CreateAndAddZones(command);
            await _configurationRepository.AddUserToSite(command);
            await _configurationRepository.AddUserToZone(command);
            await _configurationRepository.AllocateLoggerZone(command);
            return "success";
        }
    }
}

