using Microsoft.EntityFrameworkCore;

namespace EFCoreInMemoryDb;

public class ApiContext : DbContext
{
    protected override void OnConfiguring
    (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "IDP");
    }
}
