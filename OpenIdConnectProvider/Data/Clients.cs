
using OpenIdConnectProvider.Core.Models;


namespace OpenIdConnectProvider.Data;

public class Clients: IClients {
    public List<Client> clients{ get; set; } = new List<Client>();
    public Clients() {
        clients.Add(new Client{
            GUID = "GUID1",
            IsActive = true,
            Name = "Test Client 1",
            ClientID = "test1",
            Scope = new List<string>{"name:read"},
            RedirectUris = new List<string>{
                "https://localhost:5000/"
            },
        });

        clients.Add(new Client{
            GUID = "GUID2",
            IsActive = true,
            Name = "Test Client 2",
            ClientID = "test2",
            Scope = new List<string>{"name:read"},
            RedirectUris = new List<string>{
                "https://localhost:5001/"
            },
        });
    }

    public Client getClient(string ID) {
        return clients.Find(x => x.ClientID == ID);
    }
}