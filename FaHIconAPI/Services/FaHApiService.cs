using FaHIconAPI.Models;

namespace FaHIconAPI.Services
{
    public class FaHApiService
    {
        public FaHApiService()
        {
        }

        public Task GetUserData()
        {
            return Task.FromResult(new UserData());
        }
    }
}
