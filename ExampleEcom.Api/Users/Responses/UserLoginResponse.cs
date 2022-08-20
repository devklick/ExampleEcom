namespace ExampleEcom.Api.Users.Responses
{
    public class UserLoginResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
