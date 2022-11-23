using Microsoft.AspNetCore.Mvc;
using MediatR;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries.GetAllAccessPoints;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries.GetAccessPointById;

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
            var result = await _mediator.Send(new GetAllAccessPointsQuery());
            return Ok(result);
        }

        [HttpGet("{id")]
        public async Task<IActionResult> GetAccessPointById(int id)
        {
            var result = await _mediator.Send(new GetAccessPointByIdQuery(id));
            return Ok(result);
        }
    }
}
