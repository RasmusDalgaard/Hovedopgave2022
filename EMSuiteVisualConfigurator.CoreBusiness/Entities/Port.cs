using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Port : Entity
    {
        public List<Channel> Channels { get; set; } = new List<Channel>();
        public int SensorSerialNumber { get; protected set; }
        public DateTime CreateDate { get; protected set; } = DateTime.Now;
        public Port()
        {
        }
    }
}
