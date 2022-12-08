using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using MediatR;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Features.EMSuiteConfigurations.Commands
{
    public class CreateEMSuiteConfigurationCommand : IRequest<EMSuiteConfigurationResponse>
    {
        public string ConfigurationName { get; set; }
        public List<Site> Sites { get; set; } = new List<Site>();
    }

    internal class CreateEMSuiteConfigurationCommandHandler : IRequestHandler<CreateEMSuiteConfigurationCommand, EMSuiteConfigurationResponse>
    {
        private readonly IEMSuiteConfigurationRepository _emsuiteConfigurationRepository;
        private readonly IMapper _mapper;

        public CreateEMSuiteConfigurationCommandHandler(IEMSuiteConfigurationRepository emsuiteConfigurationRepository, IMapper mapper)
        {
            _emsuiteConfigurationRepository = emsuiteConfigurationRepository;
            _mapper = mapper;
        }

        public async Task<EMSuiteConfigurationResponse> Handle(CreateEMSuiteConfigurationCommand command, CancellationToken cancellationToken)
        {
            var configuration = new EMSuiteConfiguration(command.ConfigurationName, command.Sites);
            var persistedConfiguration = await _emsuiteConfigurationRepository.CreateConfiguration(configuration);
            return _mapper.Map<EMSuiteConfigurationResponse>(persistedConfiguration);
        }
    }
}

