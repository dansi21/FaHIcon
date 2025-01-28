using Microsoft.AspNetCore.Mvc;

namespace FaHIconAPI.Controllers
{
    [ApiController]
    public class IconController : Controller
    {
        [HttpGet]
        [Route("/icon/leaderboard/{userId}")]
        public IActionResult GetLeaderboardIcon(string userId)
        {
            
            return View();
        }
    }
}
