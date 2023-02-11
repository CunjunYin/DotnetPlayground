using OpenIdConnectProvider.Core.Models;

namespace OpenIdConnectProvider.Core.Services;

public interface ICodeValidater {
    public bool isValid(CodeExchangeModel model);
}