using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Sensor : Entity
    {
        public AccessPoint AccessPoint { get; protected set; }
        public Sensor()
        {
        }
    }
}
