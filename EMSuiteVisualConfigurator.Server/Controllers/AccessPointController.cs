using Microsoft.AspNetCore.Mvc;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using MediatR;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries;

namespace EMSuiteVisualConfigurator.Server.Controllers
{
    public class AccessPointController : Controller
    {
        private readonly IAccessPointRepository _accessPointRepository;
        private readonly IMediator _mediator;
        public AccessPointController(IAccessPointRepository accessPointRepository, IMediator mediator)
        {
            _accessPointRepository = accessPointRepository;
            _mediator = mediator;
        }
        public async Task<IActionResult> GetAllAccessPoints()
        {
            var query = new GetAllAccessPointsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
