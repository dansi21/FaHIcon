using FaHIconAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FaHIconAPI.Controllers
{
    [ApiController]
    public class IconController : Controller
    {
        private readonly FaHApiService _apiService;

        public IconController(FaHApiService apiService)
        {
            _apiService = apiService;
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
                  <linearGradient id='s' x2='0' y2='100%'>
                    <stop offset='0' stop-color='#bbb' stop-opacity='.1'/>
                    <stop offset='1' stop-opacity='.1'/>
                  </linearGradient>
                  <rect rx='3' width='120' height='20' fill='#555'/>
                  <rect rx='3' x='70' width='50' height='20' fill='#4c1'/>
                  <rect rx='3' width='120' height='20' fill='url(#s)'/>
                  <g fill='#fff' text-anchor='middle' font-family='DejaVu Sans,Verdana,Geneva,sans-serif' font-size='11'>
                    <text x='35' y='15'>FAH Points</text>
                    <text x='95' y='15'>{testString}</text>
                  </g>
                </svg>";
            return Results.Text(svg, "image/svg+xml");
        }

        [HttpGet]
        [Route("/icon/FAHPoints")]
        public async Task<IResult> GetFAHIcon([FromQuery]string userId)
        {
            var userData = await _apiService.GetUserData(userId);

            var svg = $@"
                <svg xmlns='http://www.w3.org/2000/svg' width='120' height='20'>
                  <linearGradient id='s' x2='0' y2='100%'>
                    <stop offset='0' stop-color='#bbb' stop-opacity='.1'/>
                    <stop offset='1' stop-opacity='.1'/>
                  </linearGradient>
                  <rect rx='3' width='120' height='20' fill='#555'/>
                  <path d='M70 0 H117 A3 3 0 0 1 120 3 V17 A3 3 0 0 1 117 20 H70 Z' fill='#4c1'/>
                  <rect rx='3' width='120' height='20' fill='url(#s)'/>
                  <g fill='#fff' text-anchor='middle' font-family='Trebuchet MS,Verdana,sans-serif' font-size='11'>
                    <text x='35' y='14'>F@H Points</text>
                    <text x='95' y='14'>{FormatService.ToBadgeNumber(userData.Points)}</text>
                  </g>
                </svg>";
            return Results.Text(svg, "image/svg+xml");
        }
    }
}
