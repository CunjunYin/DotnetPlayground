using OpenIdConnectProvider.Core.Models;
namespace OpenIdConnectProvider.Data;

public interface IClients {

    public Client getClient(string ID);
}