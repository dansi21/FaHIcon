using FaHIconAPI.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.Serialization;
using System.Text.Json;

namespace FaHIconAPI.Services
{
    public class FaHApiService
    {
        private HttpClient _client { get; set; }
        private IMemoryCache _cache { get; set; }


        public FaHApiService(IMemoryCache cache)
        {
            _client = new HttpClient();
            _cache = cache;
        }

        public async Task<UserDataResponse> GetUserData(string userName)
        {
            if (_cache.TryGetValue(userName, out UserDataResponse? cached) && cached is not null)
                return cached;

            HttpResponseMessage response = await _client.GetAsync($"https://api.foldingathome.org/user/{userName}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                UserDataResponse? user = JsonSerializer.Deserialize<UserDataResponse>(content);
                if (user is null) throw new SerializationException("User could not be parsed");

                _cache.Set(userName, user, TimeSpan.FromMinutes(5));
                return user;
            }
            else
            {
                throw new ArgumentException("User not found");
            }
        }
    }
}
