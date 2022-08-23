using ExampleEcom.Domain.Aggregates.ProductAggregates;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExampleEcom.Domain.Context
{
    public interface IAppDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        DbSet<IdentityUserRole<int>> UserRoles { get; set; }
    }
}
