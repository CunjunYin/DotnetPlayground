using OpenIdConnectProvider.Core.Models;
using OpenIdConnectProvider.Core.DB;

namespace OpenIdConnectProvider.Core.Services;
public class ClientValidator: IClientValidator
{
    public readonly EFCoreInMemoryDb db;
    public ClientValidator(EFCoreInMemoryDb db){
        this.db = db;
    }

    public bool isValid(AuthorizationCodeModel model){
        // Validate client exist
        OpenIdConnectProvider.Models.Client client = db.Clients.Where(
            c => c.ClientID == model.client_id
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