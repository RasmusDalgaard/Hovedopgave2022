using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Zone : Entity
    {
        public string Name { get; set; }
        public List<Channel> Channels { get; set; }

        public Zone(List<Channel> channels)
        {
            Channels = channels;
        }

        public Zone()
        {
        }
    }
}
