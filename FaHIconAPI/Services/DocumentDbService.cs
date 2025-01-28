using FaHIconAPI.Models;

namespace FaHIconAPI.Services
{
    public class DocumentDbService
    {
        public DocumentDbService()
        {
        }

        public Task<UserData> GetUserData(string userId)
        {
            return Task.FromResult(new UserData());
        }

        public Task<UserData> UpdateUserData(UserData userData)
        {
            return Task.FromResult(userData);
        }
    }
}
