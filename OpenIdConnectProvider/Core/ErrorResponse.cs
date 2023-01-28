using Newtonsoft.Json;
using OpenIdConnectProvider.Core.Types;

namespace OpenIdConnectProvider.Core;

public class ErrorResponse
{
    public ErrorResponseType Error { get; set; }
    public string ErrorDescription { get; set; }

    public string GenerateJsonErrorRespose()
    {
        return JsonConvert.SerializeObject(
            this,
            Formatting.Indented,
            new Newtonsoft.Json.Converters.StringEnumConverter()
        );
    }
}