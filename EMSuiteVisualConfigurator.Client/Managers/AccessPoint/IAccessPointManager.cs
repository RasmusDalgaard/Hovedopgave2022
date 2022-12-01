using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Commands;
using System.Net;

namespace EMSuiteVisualConfigurator.Client.Managers.AccessPoint
{
    public interface IAccessPointManager
    {
        Task<HttpStatusCode> CreateAccessPoint(CreateAccessPointCommand command);
    }
}
