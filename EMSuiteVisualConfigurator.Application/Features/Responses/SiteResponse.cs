namespace EMSuiteVisualConfigurator.Application.Features.Responses
{
    public class SiteResponse
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string TimeZoneId { get; set; }
        public List<ZoneResponse> Zones { get; set; }
    }
}
