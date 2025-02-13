using FaHIconAPI.Models;
using MongoDB.Driver;

namespace FaHIconAPI.Services
{
    public class DocumentDbService
    {
        private readonly IMongoCollection<UserData> _userDataCollection;

        public DocumentDbService(IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            IMongoDatabase database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
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
