using EMSuiteVisualConfigurator.CoreBusiness.Primitives;


namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Zone : Entity
    {
        public string Name { get; protected set; }

        public Zone(int id, string name)
        {
            Name = name;
        }

        private Zone()
        {

        }
    }
}
