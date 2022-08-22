using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Common;

namespace ExampleEcom.Domain.Repository
{
    public interface IUserRepository
    {
        Task<Result<User>> CreateUser(User user, string password, params string[] roles);
        Task<Result<User>> GetUser(int id);
        Task<Result<User?>> Login(string usernameOrEmail, string password, bool persist = true);
    }
}
