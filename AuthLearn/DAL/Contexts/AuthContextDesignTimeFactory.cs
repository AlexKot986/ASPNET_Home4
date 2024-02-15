using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AuthLearn.DAL.Contexts;

public class AuthContextDesignTimeFactory : IDesignTimeDbContextFactory<AuthContext>
{
    public AuthContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=auth_user_db;Username=postgres;Password=example");
        return new AuthContext(optionsBuilder.Options);
    }
}
