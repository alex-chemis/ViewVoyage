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
}