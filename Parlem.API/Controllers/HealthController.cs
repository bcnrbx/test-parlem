using Microsoft.AspNetCore.Mvc;
using Parlem.Services.Health;

namespace Parlem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : Controller
    {
        private readonly IHealthService _healthService;

        public HealthController(
            IHealthService healthService
            )
        {
            _healthService = healthService;
        }

        [HttpGet("alive")]
        public async Task<IActionResult> IsAliveCheck()
        {
            return Ok(await _healthService.GetHealthStatusAsync());
        }
    }
}
