using System;
using System.Collections.Generic;

namespace OpenIdConnectProvider.Data.Models;

public partial class RefreshToken
{
    public int Id { get; set; }

    public string? Token { get; set; }

    public string? Audience { get; set; }

    public string? ClientId { get; set; }

    public string? ResponseType { get; set; }

    public string? Scope { get; set; }

    public string? RedirectUri { get; set; }

    public string? UserId { get; set; }

    public bool? Used { get; set; }

    public DateTime? ExpiresIn { get; set; }
}
