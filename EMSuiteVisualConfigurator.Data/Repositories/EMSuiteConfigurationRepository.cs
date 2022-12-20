using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using EMSuiteVisualConfigurator.Data.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EMSuiteVisualConfigurator.Data.Repositories
{
    public class EMSuiteConfigurationRepository : Repository<EMSuiteConfiguration>, IEMSuiteConfigurationRepository
    {
        public EMSuiteConfigurationRepository(EMSuiteVisualConfiguratorDbContext dbContext) : base(dbContext)
        {
        }

        public Task<EMSuiteConfiguration> CreateConfiguration(EMSuiteConfiguration emsuiteConfiguration)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfiguration(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EMSuiteConfiguration>> GetAllConfigurations()
        {
            throw new NotImplementedException();
        }

        public Task<EMSuiteConfiguration> GetConfigurationById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
