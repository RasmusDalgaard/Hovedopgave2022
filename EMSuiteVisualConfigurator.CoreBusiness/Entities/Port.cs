using EMSuiteVisualConfigurator.CoreBusiness.Primitives;


namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Port : Entity
    {
        public List<Channel> channels { get; protected set; }
        public int sensorSerialNumber { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public Port()
        {
            channels = new List<Channel>();
            CreateDate = DateTime.Now;
        }
    }
}
