using EMSuiteVisualConfigurator.CoreBusiness.Primitives;


namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Site : Entity
    {
        public string Name { get; protected set; } = string.Empty;
        public string Address { get; protected set; } = string.Empty;
        public string PostCode { get; protected set; } = string.Empty;
        public string TimeZoneId { get; protected set; } = string.Empty;
        public List<Zone> Zones { get; protected set; } = new List<Zone>();

        public Site(string name, string address, string postCode, string timeZoneId)
        {
            Name = name;
            Address = address;
            PostCode = postCode;
            TimeZoneId = timeZoneId;
        }

        public Site()
        {

        }
    }
}
