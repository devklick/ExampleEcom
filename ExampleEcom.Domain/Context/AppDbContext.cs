using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Aggregates.ProductAggregate;

namespace ExampleEcom.Domain.Context;
public class AppDbContext : IdentityDbContext<IdentityUser>, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<User> Users => Set<User>();
}
