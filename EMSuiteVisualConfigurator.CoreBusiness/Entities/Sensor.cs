using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Sensor : Entity
    {
        public string Name { get; protected set; }

        public Sensor(int id, string name)
        {
            Name = name;
        }

        private Sensor()
        {

        }
    }
}
