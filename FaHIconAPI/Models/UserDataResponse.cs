using System.Text.Json.Serialization;

namespace FaHIconAPI.Models
{
    public class UserDataResponse
    {
        [JsonPropertyName("name")]
        public string UserName { get; set; } = "";
        [JsonPropertyName("score")]
        public long Points { get; set; } = 0;
        [JsonPropertyName("rank")]
        public int Rank { get; set; } = 0;
    }
}
