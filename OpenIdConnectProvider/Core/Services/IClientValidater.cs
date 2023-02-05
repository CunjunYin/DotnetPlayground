using OpenIdConnectProvider.Core.Models;

namespace OpenIdConnectProvider.Core.Services;
public interface IClientValidator {
    public bool isValid(AuthorizationCodeModel model);
}