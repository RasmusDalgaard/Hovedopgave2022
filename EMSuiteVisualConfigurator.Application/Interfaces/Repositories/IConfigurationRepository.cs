using EMSuiteVisualConfigurator.Application.Features.EMSuiteConfigurations.Commands;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.Interfaces.Repositories
{
    public interface IConfigurationRepository
    {
        public Task InsertEquipment(CreateEMSuiteConfigurationCommand command);
        public Task CreateSites(CreateEMSuiteConfigurationCommand command);
        public Task CreateAndAddZones(CreateEMSuiteConfigurationCommand command);
        public Task AddUserToSite(CreateEMSuiteConfigurationCommand command);

        public Task AllocateLoggerZone(CreateEMSuiteConfigurationCommand command);

        public Task AddUserToZone(CreateEMSuiteConfigurationCommand command);

    }
}
