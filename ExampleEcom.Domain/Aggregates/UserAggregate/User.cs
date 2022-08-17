using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace ExampleEcom.Domain.Aggregates.UserAggregates
{
    public class User : IdentityUser
    {
        [Required, StringLength(64)]
        public string FirstName { get; set; }

        [Required, StringLength(64)]
        public string LastName { get; set; }
    }
}
