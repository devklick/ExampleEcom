using System.ComponentModel.DataAnnotations;

namespace ExampleEcom.Api.Users.Requests
{
    public class CreateUserRequest
    {
        // TODO: Consider FluentValidation instead of DataAnnotations
        [Required, MinLength(6), MaxLength(64)]
        public string UserName { get; set; } = default!;

        [Required] // TODO: Verify that validation is handled in Program.cs (dont think it is)
        public string Password { get; set; } = default!;

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
    }
}
