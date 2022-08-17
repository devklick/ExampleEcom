using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Aggregates.ProductAggregate;
using ExampleEcom.Domain.Context;
using ExampleEcom.Infrastructure.Persistence.Extensions;

namespace ExampleEcom.Infrastructure.Persistence;
public class AppDbContext : IdentityDbContext<User>, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplySingularizedSnakeCaseNamingConvention();
        base.OnModelCreating(builder);
    }
}
