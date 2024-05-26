using Microsoft.EntityFrameworkCore;
using ContentMicroservice.Models;

namespace ContentMicroservice.Data;

public class ContentDbContext(DbContextOptions<ContentDbContext> options) : DbContext(options)
{
    public DbSet<Content> Contents => Set<Content>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<CastMember> CastMembers => Set<CastMember>();
    public DbSet<Episode> Episodes => Set<Episode>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("uuid-ossp");
        modelBuilder.HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        modelBuilder.Entity<Content>().Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
        modelBuilder.Entity<CastMember>().Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
        modelBuilder.Entity<Episode>().Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
        modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
    }
}