using Microsoft.AspNetCore.Mvc;
using MediatR;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries.GetAllAccessPoints;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries.GetAccessPointById;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Commands.CreateAccessPoint;

namespace EMSuiteVisualConfigurator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPointController : ControllerBase
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccessPointById(int id)
        {
            var result = await _mediator.Send(new GetAccessPointByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccessPoint(int id, string name)
        {
            var result = await _mediator.Send(new CreateAccessPointCommand(id, name));
            return Ok(result);
        }
    }
}
