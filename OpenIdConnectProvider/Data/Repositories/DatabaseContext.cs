using Microsoft.EntityFrameworkCore;
using OpenIdConnectProvider.Data.Models;

namespace OpenIdConnectProvider.Data.Repositories;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
    { }

    public DbSet<AccessToken> AccessTokens { get; set; }
    public DbSet<AuthenticationCode> AuthenticationCodes { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
}