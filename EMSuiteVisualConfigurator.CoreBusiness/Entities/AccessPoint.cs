using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class AccessPoint : Entity
    {
        public string Name { get; protected set; }
        public List<Logger> Loggers { get; protected set; }

        public bool IsAuthorized { get; protected set; }

        public AccessPoint(string name, List<Logger> loggers, bool isAutorized)
        {
            Name = name;
            Loggers = loggers;
            IsAuthorized = isAutorized;
        }

        public AccessPoint()
        {
            Name = "DefaultName";
            Loggers = new List<Logger>();
            IsAuthorized = true;
        }

    }
}
