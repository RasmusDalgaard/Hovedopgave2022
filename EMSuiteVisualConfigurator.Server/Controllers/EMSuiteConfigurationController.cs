using EMSuiteVisualConfigurator.Application.Features.EMSuiteConfigurations.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMSuiteVisualConfigurator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EMSuiteConfigurationController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IMediator _mediator;
        public EMSuiteConfigurationController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfiguration(CreateEMSuiteConfigurationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

