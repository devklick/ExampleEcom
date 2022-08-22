using ExampleEcom.Domain.Repository;
using ExampleEcom.Infrastructure.Crypto.Jwt;
using Microsoft.AspNetCore.Http;

namespace ExampleEcom.Api.Middleware
{
    public class UserAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public UserAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepo, IJwtService jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userRepo.GetUser(userId.Value);
            }

            await _next(context);
        }
    }
}
