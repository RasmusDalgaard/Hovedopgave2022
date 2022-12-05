using EMSuiteVisualConfigurator.CoreBusiness.Primitives;
<<<<<<< HEAD
=======

>>>>>>> fbfa86293f30c681133223583ae6ec88a44f181a

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Port : Entity
    {
        public List<Channel> Channels { get; set; } = new List<Channel>();
        public int SensorSerialNumber { get; protected set; }
        public DateTime CreateDate { get; protected set; } = DateTime.Now;
        public Port(List<Channel> channels, int sensorSerialNumber)
        {
            Channels = channels;
            SensorSerialNumber = sensorSerialNumber;
        }
        public Port()
        {
        }
    }
}
