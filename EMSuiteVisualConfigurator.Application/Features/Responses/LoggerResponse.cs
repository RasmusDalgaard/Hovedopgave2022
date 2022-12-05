namespace EMSuiteVisualConfigurator.Application.Features.Responses
{
    public class LoggerResponse
    {
        public List<PortResponse> Ports { get; set; }
        public int Id { get; set; }
        public int Battery { get; set; }
        public int SignalStrength { get; set; }
    }
}
