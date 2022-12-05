using EMSuiteVisualConfigurator.Application.Features.EMSuiteConfigurations.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMSuiteVisualConfigurator.Server.Controllers
{
    public class EMSuiteConfigurationController : Controller
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

            [HttpPost]
            public async Task<IActionResult> CreateAccessPoint(CreateEMSuiteConfigurationCommand command)
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
        }
    }
}
