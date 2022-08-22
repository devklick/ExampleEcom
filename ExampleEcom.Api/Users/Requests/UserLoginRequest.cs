using System.ComponentModel.DataAnnotations;

namespace ExampleEcom.Api.Users.Requests
{
    public class UserLoginRequest
    {
        [Required]
        public string UserNameOrEmail { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
    }
}
