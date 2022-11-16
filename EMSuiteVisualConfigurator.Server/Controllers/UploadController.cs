using EMSuiteVisualConfigurator.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMSuiteVisualConfigurator.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public UploadController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpPost]
        public async Task Post([FromBody] ImageFile file)
        {
            var buf = Convert.FromBase64String(file.base64data);
            await System.IO.File.WriteAllBytesAsync(env.ContentRootPath + System.IO.Path.DirectorySeparatorChar + Guid.NewGuid().ToString("N") + "-" + file.fileName, buf);
        }
    }
}
