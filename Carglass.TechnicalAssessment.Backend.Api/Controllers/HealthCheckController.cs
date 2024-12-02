using Microsoft.AspNetCore.Mvc;

namespace Carglass.TechnicalAssessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet("KeepAlive")]
        public IActionResult KeepAlive()
        {
            return Ok();
        }
    }
}
