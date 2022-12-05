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

        public async Task<IEnumerable<EMSuiteConfiguration>> GetAllConfigurations()
        {
            return await _dbContext.emsuiteConfigurations.ToListAsync();
        }

        public async Task<EMSuiteConfiguration> GetConfigurationById(int id)
        {
            return await _dbContext.emsuiteConfigurations.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<EMSuiteConfiguration> CreateConfiguration(EMSuiteConfiguration configuration)
        {
            _dbContext.Add(configuration);
            await _dbContext.SaveChangesAsync();
            return configuration;
        }

        public async Task DeleteConfiguration(int id)
        {
            var configuration = await _dbContext.emsuiteConfigurations
                .FirstOrDefaultAsync(a => a.Id == id);
            if (configuration == null) return;

            _dbContext.emsuiteConfigurations.Remove(configuration);
            await _dbContext.SaveChangesAsync();
            //Retrieve Sensors and delete
        }
    }
}
