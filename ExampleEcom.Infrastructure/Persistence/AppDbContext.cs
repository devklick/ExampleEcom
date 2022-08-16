using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Aggregates.ProductAggregate;
using ExampleEcom.Domain.Context;

namespace ExampleEcom.Infrastructure.Persistence;
public class AppDbContext : IdentityDbContext<User>, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Product> Products => Set<Product>();
}
