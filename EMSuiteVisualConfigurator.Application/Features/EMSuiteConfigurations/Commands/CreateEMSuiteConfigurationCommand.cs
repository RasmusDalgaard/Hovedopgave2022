using AutoMapper;
using EMSuiteVisualConfigurator.Application.Features.Responses;
using MediatR;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Features.EMSuiteConfigurations.Commands
{
    public class CreateEMSuiteConfigurationCommand : IRequest<string>
    {
        public EMSuiteConfigurationDTO ConfigurationDTO { get; set; } = new EMSuiteConfigurationDTO();
        public List<AccessPointDTO> AccessPointDTOs { get; set; } = new();
    }

    internal class CreateEMSuiteConfigurationCommandHandler : IRequestHandler<CreateEMSuiteConfigurationCommand, string>
    {
        private readonly IEMSuiteConfigurationRepository _emsuiteConfigurationRepository;
        private readonly IMapper _mapper;

        public CreateEMSuiteConfigurationCommandHandler(IEMSuiteConfigurationRepository emsuiteConfigurationRepository, IMapper mapper)
        {
            _emsuiteConfigurationRepository = emsuiteConfigurationRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateEMSuiteConfigurationCommand command, CancellationToken cancellationToken)
        {
			//Run stored procedure for AccessPoint here
			//Link ConfigurationItems to Zone and site here 
			List<AccessPointDTO> accessPoints = command.AccessPointDTOs;
			string SPJSON = "[";

			foreach (AccessPointDTO ap in accessPoints)
			{
				SPJSON += "{\"au\":true,\"ls\":[";

				foreach (LoggerDTO logger in ap.Loggers)
				{
					SPJSON += "{";
					SPJSON += "\"ps\":[";
					foreach (PortDTO port in logger.Ports)
					{
						SPJSON += "{";
						SPJSON += "\"cs\":[";

						foreach (ChannelDTO channel in port.Channels)
						{
							SPJSON += "{\"au\": " + channel.IsAuthorized.ToString().ToLower() + ",";
							SPJSON += "\"n\": " + channel.Id + ",";
							SPJSON += "\"t\": " + channel.Temperature + "}";
							if (channel != port.Channels.Last())
							{
								SPJSON+= ",";
							}
						}

						SPJSON += "],";
						SPJSON += "\"pn\": " + port.Id + ",";
						SPJSON += "\"ssn\": " + port.SensorSerialNumber + ",";
						var time = DateTime.SpecifyKind(port.CreateDate, DateTimeKind.Utc);
						//SPJSON += "\"cd\": \"" + port.CreateDate.ToString() + "\"}";
						string y = "{0:O}";
						string x = string.Format(y,port.CreateDate);
						SPJSON += "\"cd\": \"" + x +"\"}";
						if (port != logger.Ports.Last())
						{
							SPJSON += ",";
						}
						else
						{
							SPJSON+= "]";
						}
					}

					SPJSON += ", \"sn\":" + logger.Id;
					SPJSON += ", \"bt\":" + logger.Battery;
					SPJSON += ", \"ss\":" + logger.SignalStrength;
					SPJSON += "}";
				}

				SPJSON += "],\"sn\": " + ap.Id +"}";
				if (ap != accessPoints.Last())
				{
					SPJSON += ",";
				}
			}
			SPJSON += "]";
			return SPJSON;
        }
    }
}

