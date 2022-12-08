using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Logger : Entity
    {
        public List<Port> Ports { get; set; } = new List<Port>();
        public int Battery { get; set; } = 0;
        public int SignalStrength { get; set; } = 0;
        public Logger()
        {
            Ports.Add(new Port
            {
                Channels = new List<Channel>()
                {
                    new Channel(true, 1),
                }
            });
            Ports.Add(new Port
            {
                Channels = new List<Channel>()
                {
                    new Channel(true, 1),
                    new Channel(true, 1),
                    new Channel(true, 1),
                }
            });
        }
    }
}
