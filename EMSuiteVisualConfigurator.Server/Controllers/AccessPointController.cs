using Microsoft.AspNetCore.Mvc;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using MediatR;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries.GetAllAccessPoints;

namespace EMSuiteVisualConfigurator.Server.Controllers
{
    public class AccessPointController : Controller
    {
        private readonly IMediator _mediator;
        public AccessPointController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccessPoints()
        {
            var query = new GetAllAccessPointsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
