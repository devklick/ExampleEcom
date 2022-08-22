namespace ExampleEcom.Api.Users.Responses
{
    public class CreateUserResponse
    {
        public string UserName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public List<string> Roles { get; set; } = default!;
    }
}
