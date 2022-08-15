using System.ComponentModel.DataAnnotations;

namespace ExampleEcom.Api.Accounts.Requests
{
    public class CreateAccountRequest
    {
        // TODO: Consider FluentValidation instead of DataAnnotations
        [Required, MinLength(6), MaxLength(64)]
        public string Username { get; set; }

        [Required] // TODO: Verify that validation is handled in Program.cs (dont think it is)
        public string Password { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}