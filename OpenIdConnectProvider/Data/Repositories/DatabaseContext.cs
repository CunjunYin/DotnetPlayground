using Microsoft.EntityFrameworkCore;
using OpenIdConnectProvider.Data.Models;

namespace OpenIdConnectProvider.Data.Repositories;
public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<IdpServerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessToken> AccessTokens { get; set; }

    public virtual DbSet<AuthenticationCode> AuthenticationCodes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-F2QSIV4N;Database=IdpServer;Integrated Security=SSPI;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessToken>(entity =>
        {
            entity.ToTable("AccessToken");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .ValueGeneratedOnAdd();;
            entity.Property(e => e.Audience)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.Clientid)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.ExpiresIn).HasColumnType("datetime");
            entity.Property(e => e.Nounce)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Redirecturi)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.Responsetype)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.Scope)
                .HasMaxLength(300)
                .IsFixedLength();
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .IsFixedLength();
        });

        modelBuilder.Entity<AuthenticationCode>(entity =>
        {
            entity.ToTable("AuthenticationCode");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Audience)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.ClientId)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.Code)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.ExpiresIn).HasColumnType("datetime");
            entity.Property(e => e.Nounce)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.RedirectUri)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.ResponseType)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.Scope)
                .HasMaxLength(300)
                .IsFixedLength();
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .ValueGeneratedOnAdd();;
            entity.Property(e => e.ClientId)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("ClientID");
            entity.Property(e => e.Guid)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("GUID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.RedirectUris)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.Scope)
                .HasMaxLength(300)
                .IsFixedLength();
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshToken");

            entity.Property(e => e.Id)
                .IsFixedLength()
                .ValueGeneratedOnAdd();;
            entity.Property(e => e.Audience)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.ClientId)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.ExpiresIn).HasColumnType("datetime");
            entity.Property(e => e.RedirectUri)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.ResponseType)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.Scope)
                .HasMaxLength(300)
                .IsFixedLength();
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .ValueGeneratedOnAdd();;
            entity
                .HasNoKey()
                .ToTable("User");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Guid)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("GUID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}