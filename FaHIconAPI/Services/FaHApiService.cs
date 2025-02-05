using FaHIconAPI.Models;
using System.Text.Json;

namespace FaHIconAPI.Services
{
    public class FaHApiService
    {
        public HttpClient client { get; set; }

        public FaHApiService()
        {
            client = new HttpClient();
        }

        public async Task<UserDataResponse> GetUserData(string userName)
        {
            HttpResponseMessage response = await client.GetAsync($"https://api.foldingathome.org/user/{userName}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                UserDataResponse? user = JsonSerializer.Deserialize<UserDataResponse>(content);
                return user;
            }
            else 
            {
                throw new ArgumentException("User not found");
            }
        }
    }
}
