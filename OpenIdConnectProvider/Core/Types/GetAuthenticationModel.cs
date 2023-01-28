using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenIdConnectProvider.Core.Types
{
    public class GetAuthenticationModel
    {
        [Required]
        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        [Required]
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }

        [Required]
        [JsonPropertyName("responseType")]
        public string ResponseType { get; set; }

        [Required]
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [Required]
        [JsonPropertyName("callback")]
        public string CallbackUri { get; set; }
    }
}
