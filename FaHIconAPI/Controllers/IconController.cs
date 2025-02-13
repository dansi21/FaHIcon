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

        [HttpGet]
        [Route("/icon/test/{testString}")]
        public async Task<IResult> GetTestIcon(string testString)
        {
            var svg = $@"
                <svg xmlns='http://www.w3.org/2000/svg' width='120' height='20'>
                  <rect width='120' height='20' fill='#555'/>
                  <text x='60' y='14' fill='#fff' font-size='12' text-anchor='middle'>
                    {testString}
                  </text>
                </svg>";
            return Results.Text(svg, "image/svg+xml");
        }
    }
}
