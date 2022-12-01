using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Zone : Entity
    {
        public List<AccessPoint> AccessPoints { get; protected set; }

        public Site Site { get; protected set; }

        public Zone()
        {
            AccessPoints = new List<AccessPoint>();
        }
    }
}
