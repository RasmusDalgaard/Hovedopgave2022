using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class EMSuiteConfiguration : Entity
    {
        public string ConfigurationName { get; set; }
        public List<Site> Sites { get; set; } = new List<Site>();

        public EMSuiteConfiguration(string configurationName, List<Site> sites)
        {
            ConfigurationName = configurationName;
            Sites = sites;
        }
        public EMSuiteConfiguration()
        {
        }
    }
}
