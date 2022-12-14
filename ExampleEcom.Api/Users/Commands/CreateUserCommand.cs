using ExampleEcom.Api.Common;
using ExampleEcom.Api.Users.Requests;
using ExampleEcom.Api.Users.Responses;
using MediatR;

namespace ExampleEcom.Api.Users.Commands
{
    public class CreateUserCommand : MediatedRequest<CreateUserRequest, CreateUserResponse>
    {
        public CreateUserCommand(CreateUserRequest data) : base(data)
        { }
    }
}
