using System.Text.Json.Serialization;

namespace ICS.WebAppCore
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}