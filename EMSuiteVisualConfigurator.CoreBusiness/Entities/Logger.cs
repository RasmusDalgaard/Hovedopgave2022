using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Logger : Entity
    {
        public List<Port> Ports { get; protected set; }
        public int Battery { get; protected set; }
        public int SignalStrength { get; protected set; }
        public Logger()
        {
            Ports = new List<Port>();
        }
    }
}
