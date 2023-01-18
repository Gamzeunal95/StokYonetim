using System.Text.Json.Serialization;

namespace StokYonetim.WebUI.Models
{
    public class Token
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("expiration")]
        public string Expiration { get; set; }
        [JsonPropertyName("userid")]
        public string UserId { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }

    }
}
