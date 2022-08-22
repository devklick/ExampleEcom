namespace ExampleEcom.Api.Users.Responses
{
    public class UserLoginResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Token { get; set; } = default!;
        public List<string> Roles { get; set; } = default!;
    }
}
