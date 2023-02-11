﻿using System;
using System.Collections.Generic;

namespace OpenIdConnectProvider.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Guid { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
