using System;
using System.Collections.Generic;

namespace OpenIdConnectProvider.Data.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Guid { get; set; }

    public string? Name { get; set; }

    public string? ClientId { get; set; }

    public string? Scope { get; set; }

    public string? RedirectUris { get; set; }

    public short? Lifetime { get; set; }

    public bool? IsActive { get; set; }
}
