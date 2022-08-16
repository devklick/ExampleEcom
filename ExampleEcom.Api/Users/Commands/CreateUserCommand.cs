using ExampleEcom.Api.Users.Requests;
using ExampleEcom.Api.Users.Responses;
using MediatR;

namespace ExampleEcom.Api.Users.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public CreateUserRequest Data { get; }

        public CreateUserCommand(CreateUserRequest data)
        {
            Data = data;
        }
    }
}
