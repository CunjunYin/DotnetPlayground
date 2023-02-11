using Microsoft.AspNetCore.Mvc;

namespace OpenIdConnectProvider.Core.Models;

public class CodeExchangeModel {

    [FromBody]
    public string audience { get; set; }
    [FromBody]
    public string client_id { get; set; }
    [FromBody]
    public string client_secret{ get; set; }
    [FromBody]
    public string code { get; set; }
    [FromBody]
    public string grant_type { get; set; }
    [FromBody]
    public string redirect_uri { get; set; }
}