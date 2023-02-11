using OpenIdConnectProvider.Core.Models;
using OpenIdConnectProvider.Data.Repositories;

namespace OpenIdConnectProvider.Core.Services;
public class ClientValidator: IClientValidator
{
    public readonly DatabaseContext db;
    public ClientValidator(DatabaseContext db){
        this.db = db;
    }

    public bool isValid(AuthorizationCodeModel model){
        // Validate client exist
        var client = db.Clients.Where(
            c => c.ClientId == model.client_id
        ).FirstOrDefault();

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