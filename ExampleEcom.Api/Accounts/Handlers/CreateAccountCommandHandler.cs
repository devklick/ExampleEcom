using ExampleEcom.Api.Accounts.Commands;
using ExampleEcom.Api.Accounts.Responses;
using ExampleEcom.Domain.Repository;
using MediatR;

namespace ExampleEcom.Api.Accounts.Handlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new CreateAccountResponse());
        }
    }
}