using EMSuiteVisualConfigurator.CoreBusiness.Primitives;


namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Site : Entity
    {
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string PostCode { get; protected set; }
        public string TimeZoneId { get; protected set; }
        public List<Zone> Zones { get; protected set; } = new List<Zone>();

        public Site(string name, string address, string postCode, string timeZoneId)
        {
            Name = name;
            Address = address;
            PostCode = postCode;
            TimeZoneId = timeZoneId;
        }

        private Site()
        {

        }
    }
}
