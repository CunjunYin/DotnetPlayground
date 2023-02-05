using Microsoft.EntityFrameworkCore;
using OpenIdConnectProvider.Models;

namespace OpenIdConnectProvider.Core.DB;

public class EFCoreInMemoryDb : DbContext
{

    public EFCoreInMemoryDb(DbContextOptions<EFCoreInMemoryDb> options):base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "IDPDB");
    }
    public DbSet<AccessToken> AccessTokens { get; set; }
    public DbSet<AuthenticationCode> AuthenticationCodes { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
}
