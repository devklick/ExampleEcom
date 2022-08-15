using ExampleEcom.Domain.Models;

namespace ExampleEcom.Domain.Repository
{
    public interface IAccountRepository
    {
        Task<Account> Create(Account account);
    }
}