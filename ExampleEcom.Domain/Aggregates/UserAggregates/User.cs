using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace ExampleEcom.Domain.Aggregates.UserAggregates
{
    public class User : IdentityUser<int>
    {
        [Required, StringLength(64)]
        public string FirstName { get; set; } = default!;

        [Required, StringLength(64)]
        public string LastName { get; set; } = default!;

        public List<Role> Roles { get; set; }
    }
}
