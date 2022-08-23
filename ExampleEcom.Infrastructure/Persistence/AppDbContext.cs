using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ExampleEcom.Domain.Aggregates.ProductAggregates;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Context;
using ExampleEcom.Infrastructure.Persistence.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;


namespace ExampleEcom.Infrastructure.Persistence;
public class AppDbContext : IdentityDbContext<User, Role, int>, IAppDbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    public DbSet<Currency> Currencies => Set<Currency>();

    private readonly IConfiguration _configuration;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration, IPasswordHasher<User> passwordHasher) : base(options)
    {
        if (System.Diagnostics.Debugger.IsAttached == false)
        {
            System.Diagnostics.Debugger.Launch();
        }

        _configuration = configuration;
        _passwordHasher = passwordHasher;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplySingularizedSnakeCaseNamingConvention();
        builder.SeedRoles();
        builder.SeedUsers(_configuration, _passwordHasher);
        builder.SeedCurrencies();
    }
}
