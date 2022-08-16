using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Context;
using ExampleEcom.Domain.Repository;

namespace ExampleEcom.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IAppDbContext _context;

        public UserRepository(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            throw new NotImplementedException();
        }
    }
}
