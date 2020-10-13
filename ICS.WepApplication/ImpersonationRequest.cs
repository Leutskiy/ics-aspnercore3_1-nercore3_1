using System.Text.Json.Serialization;

namespace ICS.WebAppCore.Controllers
{
    public class ImpersonationRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}