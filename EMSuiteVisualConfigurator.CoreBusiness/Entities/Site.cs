using EMSuiteVisualConfigurator.CoreBusiness.Primitives;


namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Site : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public string TimeZoneId { get; set; } = string.Empty;
        public List<Zone> Zones { get; set; } = new List<Zone>();

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
