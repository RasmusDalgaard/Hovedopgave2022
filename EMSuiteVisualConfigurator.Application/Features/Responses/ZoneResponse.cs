namespace EMSuiteVisualConfigurator.Application.Features.Responses
{
    public class ZoneResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ChannelResponse> Channels { get; set; }
    }
}
