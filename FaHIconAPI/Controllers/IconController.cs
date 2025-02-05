using FaHIconAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FaHIconAPI.Controllers
{
    [ApiController]
    public class IconController : Controller
    {
        public readonly FaHApiService _apiService;

        public IconController(FaHApiService apiService) 
        {
            _apiService = apiService;
        }

        [HttpGet]
        [Route("/icon/leaderboard/{userId}")]
        public async Task<IActionResult> GetLeaderboardIcon(string userId)
        {
            FaHApiService service = new FaHApiService();
            return Ok(await service.GetUserData(userId));
        }
    }
}
