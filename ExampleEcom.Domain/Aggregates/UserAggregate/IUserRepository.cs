using ExampleEcom.Domain.Aggregates.UserAggregates;

namespace ExampleEcom.Domain.Repository
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
    }
}
