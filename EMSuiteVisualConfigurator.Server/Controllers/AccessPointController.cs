using Microsoft.AspNetCore.Mvc;
using MediatR;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Queries;
using EMSuiteVisualConfigurator.Application.Features.AccessPoints.Commands;

namespace EMSuiteVisualConfigurator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPointController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IMediator _mediator;
        public AccessPointController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
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
        public async Task<IActionResult> CreateAccessPoint(CreateAccessPointCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
