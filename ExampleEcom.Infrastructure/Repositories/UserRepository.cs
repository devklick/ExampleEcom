using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Common;
using ExampleEcom.Domain.Context;
using ExampleEcom.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExampleEcom.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAppDbContext _context;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, IAppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<Result<User>> CreateUser(User user, string password, params string[] roles)
        {
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
                return FailedUserResult(result);

            foreach (var role in roles)
            {
                result = await _userManager.AddToRoleAsync(user, role);

                if (!result.Succeeded)
                    return FailedUserResult(result);
            }

            return new Result<User>
            {
                Success = true,
                Data = user,
                Errors = result.Errors?.Select(e => new ErrorDetail(e.Code, e.Description)).ToList()
            };
        }

        public async Task<Result<User>> GetUser(int id)
        {
            var user = _context.Users.Include(u => u.Roles).SingleOrDefault(u => u.Id == id);

            var result = new Result<User>
            {
                Data = user,
                Success = user != null,
            };
            if (user == null) result.AddError("UserNotFound", "No user found with the specified ID");
            return await Task.FromResult(result);
        }

        public async Task<Result<User?>> Login(string usernameOrEmail, string password, bool persist = true)
        {
            var result = new Result<User?>();

            var user = _context.Users.SingleOrDefault(u => u.UserName == usernameOrEmail || u.Email == usernameOrEmail);

            if (user == null)
            {
                result.AddError("UserNotFound", "No user found with the the specified username or email address");
                return result;
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, password, persist, false);

            if (!signInResult.Succeeded)
            {
                result.AddError("InvalidPassword", "The specified password does not match");
            }
            else
            {
                result.Success = true;
                result.Data = user;
            }

            return result;
        }

        private Result<User> FailedUserResult(IdentityResult result) => new()
        {
            Success = false,
            Errors = result.Errors?.Select(e => new ErrorDetail(e.Code, e.Description)).ToList()
        };
    }
}
