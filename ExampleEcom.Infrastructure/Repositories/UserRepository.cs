using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Common;
using ExampleEcom.Domain.Context;
using ExampleEcom.Domain.Repository;
using Microsoft.AspNetCore.Identity;

namespace ExampleEcom.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IAppDbContext _context;

        public UserRepository(UserManager<User> userManager, IAppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Result<User>> CreateUser(User user, string password)
        {
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            var result = await _userManager.CreateAsync(user);

            return new Result<User>
            {
                Success = result.Succeeded,
                Data = result.Succeeded ? user : null,
                Errors = result.Errors?.Select(e => new ErrorDetail(e.Code, e.Description)).ToList()
            };
        }

        public async Task<Result<User?>> Login(string usernameOrEmail, string password)
        {
            var result = new Result<User?>();
            var user = _context.Users.SingleOrDefault(u => u.UserName == usernameOrEmail || u.Email == usernameOrEmail);

            if (user == null)
            {
                result.AddError("UserNotFound", "No user found with the the specified username or email address");
            }
            else if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                result.AddError("InvalidPassword", "The specified password does not match");
            }
            else
            {
                result.Success = true;
                result.Data = user;
            }

            return await Task.FromResult(result);
        }
    }
}
