using ExampleEcom.Domain.Aggregates.UserAggregates;

namespace ExampleEcom.Infrastructure.Crypto.Jwt
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        int? ValidateToken(string token);
    }
}
