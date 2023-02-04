using OpenIdConnectProvider.Data;
using OpenIdConnectProvider.Core.Models;


namespace OpenIdConnectProvider.Core.Services;
public class ClientValidator: IClientValidator
{
    private IClients _clients;
    public ClientValidator(IClients clients){
        _clients = clients;
    }

    public ClientValidator(Clients clients){
        _clients = clients;
    }

    public bool isValid(AuthorizationCode model){
        // Validate client exist
        Client client = _clients.getClient(model.client_id);
        if (client == null) {
            return false;
        }

        // Validate scope
        string[] scopes = model.scope.Split(' ');
        foreach (string scope in scopes)
        {
            if (client.Scope.IndexOf(scope) == -1)
            {
                return false;
            }
        }

        return true;
    }
}