using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Context;
using ExampleEcom.Domain.Repository;
using Microsoft.AspNetCore.Identity;

namespace ExampleEcom.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> CreateUser(User user, string password)
        {
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            var result = await _userManager.CreateAsync(user);
            return user;
        }
    }
}
