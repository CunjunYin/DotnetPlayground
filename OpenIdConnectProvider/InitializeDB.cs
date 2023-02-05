using OpenIdConnectProvider.Core.DB;
using OpenIdConnectProvider.Models;

namespace OpenIdConnectProvider;
public class InitializeDB {

    public static void Initialize(WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetService<EFCoreInMemoryDb>();

        var user1 = new User
        {
            GUID = new Guid().ToString(),
            Name = "test1",
            Email = "test1@test.mail.com",
            Password = "test1password"
        };

        var user2 = new User
        {
            GUID = new Guid().ToString(),
            Name = "test2",
            Email = "test2@test.mail.com",
            Password = "test2password"
        };

        db.Users.Add(user1);
        db.Users.Add(user2);

        var client1 = new Client
        {
            GUID = new Guid().ToString(),
            Name = "test1",
            ClientID = "9f893898-74bb-422b-a7a5-8acb427452b2",
            Scope = "read:name read:email",
            IsActive = true,
            RedirectUris = "https://localhost:5000/",
        };

        var client2 = new Client
        {
            GUID = new Guid().ToString(),
            Name = "test1",
            ClientID = "1eb11666-d615-45f3-b8d4-724c3caaae52",
            Scope = "read:name",
            IsActive = true,
            RedirectUris = "https://localhost:5000/",
        };

        db.Clients.Add(client1);
        db.Clients.Add(client2);
        db.SaveChanges();
    }
}