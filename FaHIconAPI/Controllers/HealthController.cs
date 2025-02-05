using FaHIconAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FaHIconAPI.Controllers
{
    [ApiController]
    public class HealthController : Controller
    {
        [HttpGet]
        [Route("/health")]
        public IActionResult HealthCheck()
        {
            return Ok($"Healthy - {DateTime.UtcNow}");
        }
    }
}
