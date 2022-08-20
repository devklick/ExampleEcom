using ExampleEcom.Api.Common;
using ExampleEcom.Api.Users.Requests;
using ExampleEcom.Api.Users.Responses;

namespace ExampleEcom.Api.Users.Commands
{
    public class UserLoginCommand : MediatedRequest<UserLoginRequest, UserLoginResponse>
    {
        public UserLoginCommand(UserLoginRequest data) : base(data)
        { }
    }
}
