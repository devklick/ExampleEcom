using ExampleEcom.Api.Accounts.Requests;
using ExampleEcom.Api.Accounts.Responses;
using MediatR;

namespace ExampleEcom.Api.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<CreateAccountResponse>
    {
        public CreateAccountRequest Data { get; }

        public CreateAccountCommand(CreateAccountRequest data)
        {
            Data = data;
        }
    }
}