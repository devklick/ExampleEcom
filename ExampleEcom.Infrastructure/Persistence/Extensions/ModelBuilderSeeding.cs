using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using Microsoft.Extensions.Configuration;

namespace ExampleEcom.Infrastructure.Persistence.Extensions
{
    public static class ModelBuilderSeeding
    {
        public static void SeedRoles(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role { Id = RoleConstants.SYSTEM_ADMIN_ROLE_ID, Name = RoleConstants.SYSTEM_ADMIN_ROLE_NAME },
                new Role { Id = RoleConstants.SITE_ADMIN_ROLE_ID, Name = RoleConstants.SITE_ADMIN_ROLE_NAME },
                new Role { Id = RoleConstants.SITE_USER_ROLE_ID, Name = RoleConstants.SITE_USER_ROLE_NAME }
            );
        }

        public static void SeedUsers(this ModelBuilder builder, IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            var adminUser = new User
            {
                Id = UserConstants.SYSTEM_ADMIN_USER_ID,
                Email = "system.admin@example-ecom.com",
                EmailConfirmed = true,
                FirstName = "SYSTEM",
                LastName = "ADMIN",
                LockoutEnabled = false,
                UserName = UserConstants.SYSTEM_ADMIN_USER_NAME,
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, configuration["SeedData:SystemAdmin:Password"]);
            builder.Entity<User>().HasData(adminUser);

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = RoleConstants.SYSTEM_ADMIN_ROLE_ID,
                UserId = UserConstants.SYSTEM_ADMIN_USER_ID
            },
            new IdentityUserRole<int>
            {
                RoleId = RoleConstants.SITE_ADMIN_ROLE_ID,
                UserId = UserConstants.SYSTEM_ADMIN_USER_ID
            });
        }
    }
}
