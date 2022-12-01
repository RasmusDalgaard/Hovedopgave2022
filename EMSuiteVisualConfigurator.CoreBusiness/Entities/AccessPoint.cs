using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class AccessPoint : Entity
    {
        public string Name { get; protected set; }

        public Zone Zone { get; protected set; }

        public List<Sensor> sensors { get; protected set; }

        public AccessPoint(string name)
        {
            Name = name;
            sensors = new List<Sensor>();
        }

        private AccessPoint()
        {
            sensors = new List<Sensor>();
        }

    }
}
