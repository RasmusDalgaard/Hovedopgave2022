namespace EMSuiteVisualConfigurator.Application.Features.Responses
{
    public class EMSuiteConfigurationResponse
    {
        public int Id { get; set; }
        public string ConfigurationName { get; set; }
        public List<SiteResponse> Sites { get; set; }
    }
}
