using AuthLearn.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthLearn.DAL.Contexts;

public class AuthContext(DbContextOptions<AuthContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
}