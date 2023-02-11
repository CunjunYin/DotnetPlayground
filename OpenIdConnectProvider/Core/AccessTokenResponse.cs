using Newtonsoft.Json;
using OpenIdConnectProvider.Core.Types;

namespace OpenIdConnectProvider.Core;

public class AccessTokenResponse {

    [JsonRequired]
    public string access_token { set; get; }

    [JsonRequired]
    public string refresh_token { set; get; }

    [JsonRequired]
    public string expires_in { set; get; }

    [JsonRequired]
    public string id_token { set; get; }

    [JsonRequired]
    public string token_type { set; get; }

    public string GenerateJsonErrorRespose()
    {
        return JsonConvert.SerializeObject(
            this,
            Formatting.Indented,
            new Newtonsoft.Json.Converters.StringEnumConverter()
        );
    }
}