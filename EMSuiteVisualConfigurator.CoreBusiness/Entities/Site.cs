using EMSuiteVisualConfigurator.CoreBusiness.Primitives;


namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Site : Entity
    {
        public string Name { get; protected set; }
        public EMSuiteConfiguration Configuration { get; protected set; }
        public List<Zone> Zones { get; protected set; }

        public Site(string name)
        {
            Name = name;
            Zones = new List<Zone>();
        }

        private Site()
        {

        }
    }
}
