namespace FaHIconAPI.Models
{
    public class UserData
    {
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public long Points { get; set; } = 0;
        public int Rank { get; set; } = 0;
        public DateTime LastUpdate { get; set; } = DateTime.MinValue;
    }
}
