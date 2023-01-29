using Newtonsoft.Json;
using OpenIdConnectProvider.Core.Types;

namespace OpenIdConnectProvider.Core;

public class AccessTokenResponse {
    [JsonRequired]
    string access_token { set; get; }

    [JsonRequired]
    string token_type { set; get; }

    [JsonRequired]
    string expires_in { set; get; }

    [JsonRequired]
    string refresh_token { set; get; }

    string scope { set; get; }

    public string GenerateJsonErrorRespose()
    {
        return JsonConvert.SerializeObject(
            this,
            Formatting.Indented,
            new Newtonsoft.Json.Converters.StringEnumConverter()
        );
    }
}