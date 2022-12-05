namespace EMSuiteVisualConfigurator.Application.Features.Responses
{
    public class PortResponse
    {
        public List<ChannelResponse> Channels { get; set; }
        public int Id { get; set; }
        public int SensorSerialNumber { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
