using EMSuiteVisualConfigurator.CoreBusiness.Entities;

namespace EMSuiteVisualConfigurator.Application.Interfaces.Repositories
{
    public interface IEMSuiteConfigurationRepository : IRepository<EMSuiteConfiguration>
    {
        Task<IEnumerable<EMSuiteConfiguration>> GetAllConfigurations();

        Task<EMSuiteConfiguration> GetConfigurationById(int id);

        Task<EMSuiteConfiguration> CreateConfiguration(EMSuiteConfiguration emsuiteConfiguration);

        Task DeleteConfiguration(int id);
    }
}
