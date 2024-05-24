using Microsoft.EntityFrameworkCore;
using AuthMicroservice.Models;

namespace AuthMicroservice.Data;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
}