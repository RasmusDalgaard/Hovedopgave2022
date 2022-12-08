using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class AccessPoint : Entity
    {
        public List<Logger> Loggers { get; set; } = new List<Logger>();

        public bool IsAuthorized { get; set; } = false;

        public AccessPoint(List<Logger> loggers, bool isAutorized)
        {
            Loggers = loggers;
            IsAuthorized = isAutorized;
        }

        public AccessPoint()
        {
        }

    }
}
