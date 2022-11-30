using Microsoft.AspNetCore.Mvc;
using MediatR;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries.GetAllAccessPoints;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries.GetAccessPointById;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Commands.CreateAccessPoint;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Requests;

namespace EMSuiteVisualConfigurator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPointController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly IMediator _mediator;
        public AccessPointController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            this.env = env;
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
        public async Task<IActionResult> CreateAccessPoint(AccessPointRequest request)
        {
            var result = await _mediator.Send(new CreateAccessPointCommand(request.Name));
            return Ok(result);
        }
    }
}
