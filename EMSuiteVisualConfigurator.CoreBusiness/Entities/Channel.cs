using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Channel : Entity
    {
        public bool IsAuthorized { get; protected set; } = true;

        public int Temperature { get; protected set; } = 1;

        public Channel(bool isAuthorized, int temperature)
        {
            IsAuthorized = isAuthorized;
            Temperature = temperature;
        }
        public Channel()
        {

        }
    }
}
