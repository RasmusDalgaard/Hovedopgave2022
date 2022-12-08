using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Port : Entity
    {
        public List<Channel> Channels { get; set; } = new List<Channel>();
        public int SensorSerialNumber { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Port()
        {
        }
    }
}
