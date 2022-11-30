using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class EMSuiteConfiguration : Entity
    {
        public List<Site> Sites { get; protected set; }

        public EMSuiteConfiguration()
        {
            Sites = new List<Site>();
        }
    }
}
