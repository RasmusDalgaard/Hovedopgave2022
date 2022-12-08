using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Channel : Entity
    {
        public bool IsAuthorized { get; set; } = true;

        public int Temperature { get; set; } = 1;

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
