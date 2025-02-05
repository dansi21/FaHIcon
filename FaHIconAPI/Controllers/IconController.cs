using FaHIconAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FaHIconAPI.Controllers
{
    [ApiController]
    public class IconController : Controller
    {
        public readonly FaHApiService _apiService;
        public readonly DocumentDbService _documentDb;

        public IconController(FaHApiService apiService, DocumentDbService documentDb) 
        {
            _apiService = apiService;
            _documentDb = documentDb;
        }

        [HttpGet]
        [Route("/icon/leaderboard/{userId}")]
        public async Task<IActionResult> GetLeaderboardIcon(string userId)
        {
            return Ok(await _apiService.GetUserData(userId));
        }
    }
}
