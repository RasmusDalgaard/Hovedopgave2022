namespace EMSuiteVisualConfigurator.Application.Features.Responses
{
    public class AccessPointResponse
    {
        public List<LoggerResponse> Loggers { get; set; }
        public int Id { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
