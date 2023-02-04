using OpenIdConnectProvider.Core.Models;

namespace OpenIdConnectProvider.Core.Services;
public interface IAuthenticationCode {
    public string GenerateCode();
}