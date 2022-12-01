using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Commands;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace EMSuiteVisualConfigurator.Client.Managers.AccessPoint
{
    public class AccessPointManager : IAccessPointManager
    {
        private readonly HttpClient _httpClient;

        public AccessPointManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpStatusCode> CreateAccessPoint(CreateAccessPointCommand command)
        {
            var response = await _httpClient.PostAsJsonAsync("api/accesspoint", command);
            return response.StatusCode;
        }
    }
}
