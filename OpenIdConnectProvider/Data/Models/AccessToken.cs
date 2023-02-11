using System;
using System.Collections.Generic;

namespace OpenIdConnectProvider.Data.Models;

public partial class AccessToken
{
    public string Id { get; set; } = null!;

    public string? Token { get; set; }

    public string? Audience { get; set; }

    public string? Clientid { get; set; }

    public string? Responsetype { get; set; }

    public string? Scope { get; set; }

    public string? Redirecturi { get; set; }

    public string? Nounce { get; set; }

    public string? UserId { get; set; }

    public DateTime? ExpiresIn { get; set; }
}
