using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class AccessPoint : Entity
    {
        public string Name { get; protected set; }

        public AccessPoint(string name)
        {
            Name = name;
        }

        private AccessPoint()
        {

        }

    }
}
