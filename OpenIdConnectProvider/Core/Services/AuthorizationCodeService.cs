using System;
using System.Security.Cryptography;

namespace OpenIdConnectProvider.Core.Services;

public class AuthorizationCodeService: IAuthenticationCode
{
    private readonly string _clientId;
    private readonly string _redirectUri;
    private readonly string _state;
    private readonly string _scope;
    private readonly string _userId;

    public AuthorizationCodeService(string clientId, string redirectUri, string state, string scope, string userId)
    {
        _clientId = clientId;
        _redirectUri = redirectUri;
        _state = state;
        _scope = scope;
        _userId = userId;
    }

    public string GenerateCode()
    {
        // Combine the clientId, redirectUri, state, scope, and userId into a single string
        var code = _clientId + _redirectUri + _state + _scope + _userId;

        // Use a hash function to generate a unique code
        using (var sha256 = SHA256.Create())
        {
            var hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(code));
            return Convert.ToBase64String(hash);
        }
    }
}

