using ExampleEcom.Domain.Aggregates.UserAggregates;

namespace ExampleEcom.Domain.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user, string password);
    }
}
